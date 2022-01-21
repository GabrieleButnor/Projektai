using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Data.Repositories;
using Veterinary.Data.Dtos.Visits;
using Veterinary.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Veterinary.Auth.Model;
using Veterinary.Data.Dtos.Services;


// Vizitų kontroleris
namespace Veterinary.Controllers
{
    [ApiController]
    [Route("api/users/{userId}/pets/{petId}/visits")]        // Pagrindinis kelias per vartotojų augintinius
        
    public class VisitsController : ControllerBase
    {
        // Repozitorijos apsirašymas 
        private readonly IPetRepository _petRepository;
        private readonly IUserRepository _userRepository;
        private readonly IVisitRepository _visitRepository;
        private readonly IVisitServicesRepository _visitServiceRepository;
        private readonly IServiceRepository _serviceRepository;

        // Formatų keitimo kintamasis
        private readonly IMapper _mapper;

        // Per konstruktorių sukuriama repozitorijos ir mapinimas
        public VisitsController(IVisitRepository visitRepository, IPetRepository petRepository, IUserRepository userRepository,
            IMapper mapper, IVisitServicesRepository visitServiceRepository, IServiceRepository serviceRepository)
        {
            _visitRepository = visitRepository;
            _petRepository = petRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _visitServiceRepository = visitServiceRepository;
            _serviceRepository = serviceRepository;
        }


        // GET ALL - vartotojo konkretaus augintinio visų vizitų paėmimas
        [HttpGet]
        [Authorize(Roles = UserRoles.SimpleDocAdmin)]
        public async Task<ActionResult<VisitDto>> GetAllOfAsync(string userId, int petId)
        {
            var user = await _userRepository.Get(userId, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojas
            if (user == null)
            {
                return NotFound(new { message = $"Neteisinga užklausa." });
            }

            var userPets = await _petRepository.Get(userId, User.FindFirst(CustomClaims.UserId).Value, petId, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojo augintinis
            if (userPets == null)
            {
                return NotFound(new { message = $"Tokio id = '{petId}' augintinio nėra." });
            }

            // Kuomet prisijungęs paprastas vartotojas mato tik savo augintinių vizitus
            if (User.IsInRole(UserRoles.SimpleUser))
            {
                var petSimple = await _petRepository.Get(userId, User.FindFirst(CustomClaims.UserId).Value, petId, UserRoles.SimpleUser);
                // Tikrinama ar yra toks prisijungusio vartotojo augintinis
                if (petSimple == null)
                {
                    return Forbid();
                }
                var visitsSimple = await _visitRepository.GetAllOf(userId, petId);
                // Duomenys iš bazės formato pakeičiami į atvaizdavimo formatą
                return Ok(visitsSimple.Select(o => _mapper.Map<VisitDto>(o)));
            }

            // Kuomet prisijungęs admino ar daktaro teisėmi vartotojas mato bet kurio gyvuno vizitus
            var visits = await _visitRepository.GetAllOf(userId, petId);
            // Duomenys iš bazės formato pakeičiami į atvaizdavimo formatą
            return Ok(visits.Select(o => _mapper.Map<VisitDto>(o)));
        }



        // GET - konkretaus vortotojo augintinio vizito paėmimas
        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.SimpleDocAdmin)]
        public async Task<ActionResult<VisitServiceDto>> GetAsync(string userId, int petId, int id)
        {
            var user = await _userRepository.Get(userId, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojas
            if (user == null)
            {
                return NotFound(new { message = $"Neteisinga užklausa." });
            }

            var userPets = await _petRepository.Get(userId, User.FindFirst(CustomClaims.UserId).Value, petId, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojo augintinis
            if (userPets == null)
            {
                return NotFound(new { message = $"Tokio id = '{petId}' augintinio nėra." });
            }
                        
            var visit = await _visitRepository.Get(userId, petId, id);
            // Ar egzistuoja toks vartotojo augintinio vizitas
            if (visit == null)
            {
                return NotFound(new { message = $"Tokio id = '{id}' vizito nėra." });
            }


            // Kuomet prisijungęs paprastas vartotojas mato tik savo augintinių vizitus
            if (User.IsInRole(UserRoles.SimpleUser))
            {
                var petSimple = await _petRepository.Get(userId, User.FindFirst(CustomClaims.UserId).Value, petId, UserRoles.SimpleUser);
                // Tikrinama ar yra toks prisijungusio vartotojo augintinis
                if (petSimple == null)
                {
                    return Forbid();
                }
                var visitSimple = await _visitRepository.Get(userId, petId, id);
                // Ar egzistuoja toks vartotojo augintinio vizitas
                if (visitSimple == null)
                {
                    return Forbid();
                }

                // Atrenkami vizito paslaugų id
                var visitServicesSimple = await _visitServiceRepository.GetAllOf(id);
                var allServiceIdSimple = visitServicesSimple.Select(o => o.fk_ServiceId).ToArray();

                // Paimami vizitui priskirtų paslaugų duomenys
                List<ServiceDto> serviceListSimple = new List<ServiceDto>();
                foreach (var i in allServiceIdSimple)
                {
                    var servise = await _serviceRepository.Get(i);
                    serviceListSimple.Add(_mapper.Map<ServiceDto>(servise));
                }

                // Sudaromas pilnas vizito aprašymas vaizduojant ir priskirtas paslaugas
                var fullvisitSimple = _mapper.Map<VisitServiceDto>(visit);
                fullvisitSimple.Services = serviceListSimple;

                return Ok(fullvisitSimple);

            }

            // Kuomet prisijungęs admino ar daktaro teisėmi vartotojas mato bet kurio gyvuno vizitus

            // Atrenkami vizito paslaugų id
            var visitServices = await _visitServiceRepository.GetAllOf(id);
            var allServiceId = visitServices.Select(o => o.fk_ServiceId).ToArray();

            // Paimami vizitui priskirtų paslaugų duomenys
            List<ServiceDto> serviceList = new List<ServiceDto>();
            foreach (var i in allServiceId)
            {
                var servise = await _serviceRepository.Get(i);
                serviceList.Add(_mapper.Map<ServiceDto>(servise));
            }

            // Sudaromas pilnas vizito aprašymas vaizduojant ir priskirtas paslaugas
            var fullvisit = _mapper.Map<VisitServiceDto>(visit);
            fullvisit.Services = serviceList;

            return Ok(fullvisit);
           
        }


        // POST - naujo vartotojo gyvūno vizito sukūrimas
        [HttpPost]
        [Authorize(Roles = UserRoles.SimpleOrAdmin)]
        public async Task<ActionResult<VisitDto>> PostAsync(string userId, int petId, VisitPostDto visitdto)
        {
            var user = await _userRepository.Get(userId, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojas
            if (user == null)
            {
                return NotFound(new { message = $"Neteisinga užklausa." });
            }

            var userPets = await _petRepository.Get(userId, User.FindFirst(CustomClaims.UserId).Value, petId, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojo augintinis
            if (userPets == null)
            {
                return NotFound(new { message = $"Tokio id = '{petId}' augintinio nėra." });
            }


            // Kuomet prisijungęs paprastas vartotojas mato tik savo augintinių vizitus
            if (User.IsInRole(UserRoles.SimpleUser))
            {
                var petSimple = await _petRepository.Get(userId, User.FindFirst(CustomClaims.UserId).Value, petId, UserRoles.SimpleUser);
                // Tikrinama ar yra toks prisijungusio vartotojo augintinis
                if (petSimple == null)
                {
                    return Forbid();
                }

                // Atsiskiriam vizitui priskirtų paslaugų id
                List<VisitServicePostDtocs> serviceIdListSimple = visitdto.ServicesId;

                // Duomenys iš sukūrimo formato pekeičiame į bazės formatą
                var visitSimple = _mapper.Map<Visit>(visitdto);
                // Priskiriame gyvūną kuriame kuriamas vizitas
                visitSimple.fk_PetId = petId;
                await _visitRepository.Create(visitSimple);

                // Sukuriame vizitui paslaugų pirksyrimą, per tarpinę lentelę
                foreach (var e in serviceIdListSimple)
                {
                    var service = _serviceRepository.Get(e.Id);
                    if (service != null)
                    {
                        Visit_Services element = new Visit_Services();
                        element.fk_VisitId = visitSimple.Id;
                        element.fk_ServiceId = e.Id;
                        _visitServiceRepository.Create(element);
                    }
                }
                // 201 kodas ir sukurtas duom gražinamas
                return Created($"/api/users/{userId}/pets/{petId}/visits/{visitSimple.Id}", _mapper.Map<VisitDto>(visitSimple));
            }

            // Kuomet prisijungęs admino ar daktaro teisėmi vartotojas mato bet kurio gyvuno vizitus

            // Atsiskiriam vizitui priskirtų paslaugų id
            List<VisitServicePostDtocs> serviceIdList = visitdto.ServicesId;

            // Duomenys iš sukūrimo formato pekeičiame į bazės formatą
            var visit = _mapper.Map<Visit>(visitdto);
            // Priskiriame gyvūną kuriame kuriamas vizitas
            visit.fk_PetId = petId;
            await _visitRepository.Create(visit);

            // Sukuriame vizitui paslaugų pirksyrimą, per tarpinę lentelę
            foreach (var e in serviceIdList)
            {
                var service = _serviceRepository.Get(e.Id);
                if (service != null)
                {
                    Visit_Services element = new Visit_Services();
                    element.fk_VisitId = visit.Id;
                    element.fk_ServiceId = e.Id;
                    _visitServiceRepository.Create(element);
                }
            }

            // 201 kodas ir sukurtas duom gražinamas
            return Created($"/api/users/{userId}/pets/{petId}/visits/{visit.Id}", _mapper.Map<VisitDto>(visit));
        }


        // PUT - konkretaus vartotojo augintinio vizito duomenų atnaujinimas
        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.DoctorOrAdmin)]
        public async Task<ActionResult<VisitDto>> PutAsync(string userId, int petId, int id, VisitUpdateDto visitDto)
        {
            var user = await _userRepository.Get(userId, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojas
            if (user == null)
            {
                return NotFound(new { message = $"Neteisinga užklausa." });
            }

            var userPets = await _petRepository.Get(userId, User.FindFirst(CustomClaims.UserId).Value, petId, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojo augintinis
            if (userPets == null)
            {
                return NotFound(new { message = $"Tokio id = '{petId}' augintinio nėra." });
            }

            var oldVisit = await _visitRepository.Get(userId, petId, id);
            // Ar egzistuoja toks vartotojo augintinio vizitas
            if (oldVisit == null)
            {
                return NotFound(new { message = $"Tokio id = '{id}' vizito nėra." });
            }

            // Duomenys iš koregavimo formato pekeičiame į bazės formatą
            _mapper.Map(visitDto, oldVisit);

            await _visitRepository.Put(oldVisit);
            // Duomenys iš bazės formato pekeičiame į atvaizdavimo formatą
            return Ok(_mapper.Map<VisitDto>(oldVisit));
        }


        // DELETE - konkretraus vartotojo augintinio vizito  panaikinimas
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.DoctorOrAdmin)]
        public async Task<ActionResult> DeleteAsync(string userId, int petId, int id)
        {
            var user = await _userRepository.Get(userId, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojas
            if (user == null)
            {
                return NotFound(new { message = $"Neteisinga užklausa." });
            }

            var userPets = await _petRepository.Get(userId, User.FindFirst(CustomClaims.UserId).Value, petId, UserRoles.DoctorUser);
            // Ar egzistuoja toks vartotojo augintinis
            if (userPets == null)
            {
                return NotFound(new { message = $"Tokio id = '{petId}' augintinio nėra." });
            }

            var visit = await _visitRepository.Get(userId, petId, id);
            // Ar egzistuoja toks vartotojo augintinio vizitas
            if (visit == null)
            {
                return NotFound(new { message = $"Tokio id = '{id}' vizito nėra." });
            }

            var visitServices = await _visitServiceRepository.GetAllOf(id);

            var allServiceId = visitServices.Select(o => o.fk_ServiceId).ToArray();
            var allId = visitServices.Select(o => o.Id).ToArray();

            List<Visit_Services> visitservicelist = new List<Visit_Services>();
            
            foreach (var e in allServiceId)
            {
                var visitservice = await _visitServiceRepository.Get(id, e);
                visitservicelist.Add(visitservice);
            }

            foreach(var n in visitservicelist)
            {
               await _visitServiceRepository.Delete(n);
            }

            //if(visitservicelist == null)
            //{
            //     _visitRepository.Delete(visit);
            //}
            await _visitRepository.Delete(visit);
            return NoContent(); // gražinimas 204 kodas ir tusčia reikšmė
        }
    }
}
