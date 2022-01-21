using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Data.Repositories;
using AutoMapper;
using Veterinary.Data.Dtos.Users;
using Microsoft.AspNetCore.Authorization;
using Veterinary.Auth.Model;


// Vartotojų kontroleris
namespace Veterinary.Controllers
{
    [ApiController]
    [Route("api/users")]        // Pagrindinis kelias
    public class UsersController : ControllerBase
    {
        // Repozitorijos apsirašymas 
        private readonly IUserRepository _userRepository;

        // Formatų keitimo kintamasis
        private readonly IMapper _mapper;

        // Per konstruktorių sukuriama repozitorija ir mapinimas
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        // GET ALL - visų vartotoju paėmimas pagal prisijungusiu vartotojo teises
        [HttpGet]
        [Authorize(Roles = UserRoles.DoctorOrAdmin)] // Gali tik gydytojas ar admin pasiekti veiksmus
        public async Task<IEnumerable<UserDto>> GetAll()
        {            
            // Kuomet prisijungęs daktaro teisėmi vartotojas (tik paprastus vartotojus mato)
            if (User.IsInRole(UserRoles.DoctorUser))
            {
                var usersSimple = await _userRepository.GetAll(UserRoles.DoctorUser);
                // Duomenys iš bazės formato pakeičiami į atvaizdavimo formatą
                return usersSimple.Select(o => _mapper.Map<UserDto>(o));
            }
            // Kuomet prisijungęs admino teisėmi vartotojas (visus vartotojus mato)            
            var users = await _userRepository.GetAll(UserRoles.Admin);
            // Duomenys iš bazės formato pakeičiami į atvaizdavimo formatą
            return users.Select(o => _mapper.Map<UserDto>(o));
            
        }


        // GET - konkretaus vartotojo paėmimas pagal prisijungusiu vartotojo teises
        [HttpGet("{id}")]
        //[Authorize(Roles = UserRoles.DoctorOrAdmin)] // Gali tik gydytojas ar admin pasiekti veiksmus
        public async Task<ActionResult<UserDto>> Get(string id)
        {
            // Kuomet prisijungęs daktaro teisėmi vartotojas (tik paprastus vartotojus mato)
            //if (User.IsInRole(UserRoles.DoctorUser))
            //{
            //    var userSimple = await _userRepository.Get(id, UserRoles.DoctorUser);
            //    // Tikrinama ar yra toks vartotojas
            //    if (userSimple == null)
            //    {
            //        return NotFound(new { message = $"Tokio id kliento nėra." });
            //    }
            //}

            // Kuomet prisijungęs admino teisėmi vartotojas (visus vartotojus mato) 
            var user = await _userRepository.Get(id, UserRoles.Admin);
            // Tikrinama ar yra toks vartotojas
            //if (user == null)
            //{
            //    return NotFound(new { message = $"Tokio id vartotojo nėra." });
            //}
            // Duomenys iš bazės formato pakeičiami į atvaizdavimo formatą
            return Ok(_mapper.Map<UserDto>(user));
        }


        // PUT - konkretaus vartotojo duomenų atnaujinimas
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)] // Gali atlikti veiksmus tik adminas
        public async Task<ActionResult<UserDto>> Put(string id, UserUpdateDto userdto)
        {
            var user = await _userRepository.Get(id, UserRoles.Admin);
            // Tikrinama ar yra toks vartotojas
            if (user == null)
            {
                return NotFound(new { message = $"Tokio id vartotojo nėra." });
            }
            // Duomenys iš koregavimo formato pekeičiame į bazės formatą
            _mapper.Map(userdto, user);
            await _userRepository.Put(user);
            // Duomenys iš bazės formato pekeičiame į atvaizdavimo formatą
            return Ok(_mapper.Map<UserDto>(user));
        }


        // DELETE - konkretaus vartotjo pašalinimas
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)] // Gali atlikti veiksmus tik adminas
        public async Task<ActionResult<UserDto>> Delete(string id)
        {
            var user = await _userRepository.Get(id, UserRoles.Admin);
            // Tikrinama ar yra toks vartotojas
            if (user == null)
            {
                return NotFound(new { message = $"Tokio id vartotojo nėra." });
            }
            await _userRepository.Delete(user);
            // gražinimas 204 kodas ir tusčia reikšmė
            return NoContent(); 
        }

    }
}
