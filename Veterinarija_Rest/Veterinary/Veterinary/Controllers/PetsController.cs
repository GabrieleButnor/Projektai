using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Data.Repositories;
using Veterinary.Data.Dtos.Pets;
using Veterinary.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Veterinary.Auth.Model;


// Augintinių kontroleris
namespace Veterinary.Controllers
{
    [ApiController]
    [Route("api/users/{userId}/pets")]        // Pagrindinis kelias per vartotoją (rolę ir konkretų vartotoją)

    public class PetsController : ControllerBase
    {
        // Repozitorijos apsirašymas 
        private readonly IPetRepository _petRepository;
        private readonly IUserRepository _userRepository;
        // Formatų keitimo kintamasis
        private readonly IMapper _mapper;
        // Autorizacija
        private readonly IAuthorizationService _authorizationService;


        // per konstruktorių sukuriama repozitorijos ir mapinimas
        public PetsController(IPetRepository petRepository, IMapper mapper, IUserRepository userRepository, IAuthorizationService authorizationService)
        {
            _petRepository = petRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _authorizationService = authorizationService;
        }


        // GET ALL - visų vartotojo turimų augintinių paėmimas
        [HttpGet]
        [Authorize(Roles = UserRoles.SimpleDocAdmin)]
        public async Task<IEnumerable<PetDto>> GetAllOfAsync(string userId)
        {
            // Kuomet prisijungęs paprastas vartotojas (tik savo augintinius visu mato)
            if (User.IsInRole(UserRoles.SimpleUser))
            {
                var petsSimple = await _petRepository.GetAllOf(userId, User.FindFirst(CustomClaims.UserId).Value, UserRoles.SimpleUser);
                return petsSimple.Select(o => _mapper.Map<PetDto>(o));
            }
            // Kuomet prisijungęs admino ar daktaro teisėmi vartotojas (visus vartotojus mato) 
            var pets = await _petRepository.GetAllOf(userId, User.FindFirst(CustomClaims.UserId).Value, UserRoles.DoctorUser);
            return pets.Select(o => _mapper.Map<PetDto>(o));
        }


        // GET - konkretaus vortotojo augintinio paėmimas
        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.SimpleDocAdmin)]
        public async Task<ActionResult<PetDto>> GetAsync(string userId, int id)
        {
            var user = await _userRepository.Get(userId, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojas
            if (user == null)
            {
                return NotFound(new { message = $"Neteisinga užklausa." });
            }

            var petIs = await _petRepository.Get(userId, User.FindFirst(CustomClaims.UserId).Value, id, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojo augintinis
            if (petIs == null)
            {
                return NotFound(new { message = $"Tokio id = '{id}' augintinio nėra." });
            }

            // Kuomet prisijungęs paprastas vartotojas (tik savo augintinį mato)
            if (User.IsInRole(UserRoles.SimpleUser))
            {
                var petSimple = await _petRepository.Get(userId, User.FindFirst(CustomClaims.UserId).Value, id, UserRoles.SimpleUser);
                // Tikrinama ar yra toks prisijungusio vartotojo augintinis
                if (petSimple == null)
                {
                    return Forbid();
                }
                // Duomenys iš bazės formato pakeičiami į atvaizdavimo formatą
                return Ok(_mapper.Map<PetDto>(petSimple));
            }

            // Kuomet prisijungęs admino ar daktaro teisėmi vartotojas (mato bet kuri konkretų augintinį)    
            var pet = await _petRepository.Get(userId, User.FindFirst(CustomClaims.UserId).Value, id, UserRoles.DoctorUser);
            // Duomenys iš bazės formato pakeičiami į atvaizdavimo formatą
            return Ok(_mapper.Map<PetDto>(pet));
        }



        // POST - naujo vartotojo gyvūno sukūrimas
        [HttpPost]
        [Authorize(Roles = UserRoles.SimpleOrAdmin)]
        public async Task<ActionResult<PetDto>> PostAsync(string userId, PetPostDto petdto)
        {
            if(User.IsInRole(UserRoles.SimpleUser) && userId == User.FindFirst(CustomClaims.UserId).Value)
            {
                // Duomenys iš sukūrimo formato pekeičiame į bazės formatą
                var petSimple = _mapper.Map<Pet>(petdto);
                // Sukūriams ir priskiriamas augintiniui vartotojas seimininkas 
                petSimple.fk_UserId = User.FindFirst(CustomClaims.UserId).Value;
                await _petRepository.Create(petSimple);
                // 201 kodas ir sukurtas duom gražinamas
                return Created($"api/users/{userId}/pets/{petSimple.Id}", _mapper.Map<PetDto>(petSimple));
            }
            else if (User.IsInRole(UserRoles.SimpleUser) && userId != User.FindFirst(CustomClaims.UserId).Value)
            {
                return Forbid();
            }

            var user = await _userRepository.Get(userId, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojas
            if (user == null)
            {
                return NotFound(new { message = $"Tokio kliento nėra." });
            }
            // Duomenys iš sukūrimo formato pekeičiame į bazės formatą
            var pet = _mapper.Map<Pet>(petdto);
            // Sukūriams ir priskiriamas augintiniui vartotojas seimininkas (pagal kuriam kuriame )
            pet.fk_UserId = userId;
            await _petRepository.Create(pet);
            // 201 kodas ir sukurtas duom gražinamas
            return Created($"api/users/{userId}/pets/{pet.Id}", _mapper.Map<PetDto>(pet));
        }


        // PUT - konkretaus vartotojo augintinio duomenų atnaujinimas
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.SimpleOrAdmin)]
        public async Task<ActionResult<PetDto>> PutAsync(string userId, int id, PetUpdateDto petDto)
        {
            var user = await _userRepository.Get(userId, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojas
            if (user == null)
            {
                return NotFound(new { message = $"Neteisinga užklausa." });
            }

            var oldPet = await _petRepository.Get(userId, User.FindFirst(CustomClaims.UserId).Value, id, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojo augintinis
            if (oldPet == null)
            {
                return NotFound(new { message = $"Tokio id = '{id}' augintinio nėra." });
            }

            // Tikriname ar prisijungias vartotojas yra resurso kūrėjas
            var auth = await _authorizationService.AuthorizeAsync(User, oldPet, PolicyNames.SameUser);
            if (!auth.Succeeded)
            {
                return Forbid(); // Grąžinamas 403 kodas, kad neturi teisės keisti
            }

            // Duomenys iš koregavimo formato pekeičiame į bazės formatą
            _mapper.Map(petDto, oldPet);
            await _petRepository.Put(oldPet);
            // Duomenys iš bazės formato pekeičiame į atvaizdavimo formatą
            return Ok(_mapper.Map<PetDto>(oldPet));
        }


        // DELETE - konkretraus vartotojo augintinio panaikinimas
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.SimpleOrAdmin)]
        public async Task<ActionResult> DeleteAsync(string userId, int id)
        {
            var user = await _userRepository.Get(userId, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojas
            if (user == null)
            {
                return NotFound(new { message = $"Neteisinga užklausa." });
            }

            var pet = await _petRepository.Get(userId, User.FindFirst(CustomClaims.UserId).Value, id, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojo augintinis
            if (pet == null)
            {
                return NotFound(new { message = $"Tokio id = '{id}' augintinio nėra." });
            }

            // Tikriname ar prisijungias vartotojas yra resurso kūrėjas
            var auth = await _authorizationService.AuthorizeAsync(User, pet, PolicyNames.SameUser);
            if (!auth.Succeeded)
            {
                return Forbid(); // Grąžinamas 403 kodas, kad neturi teisės keisti
            }

            await _petRepository.Delete(pet);
            return NoContent(); // Grąžinamas 204 kodas ir tusčia reikšmė
        }
    }
}
