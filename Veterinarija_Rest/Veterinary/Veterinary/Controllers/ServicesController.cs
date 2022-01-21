using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Data.Repositories;
using Veterinary.Data.Entities;
using AutoMapper;
using Veterinary.Data.Dtos.Services;
using Veterinary.Auth.Model;
using Microsoft.AspNetCore.Authorization;


// Paslaugų kontroleris
namespace Veterinary.Controllers
{
    [ApiController]
    [Route("api/services")]        // Pagrindinis kelias per prisijungusi vartotoją

    public class ServicesController : ControllerBase
    {
        // Repozitorijos apsirašymas 
        private readonly IServiceRepository _serviceRepository;
        // Formatų keitimo kintamasis
        private readonly IMapper _mapper;
        // Autorizacija
        private readonly IAuthorizationService _authorizationService;

        // Per konstruktorių sukuriama repozitorija ir mapinimas, autorizacija
        public ServicesController(IServiceRepository serviceRepository, IMapper mapper, IAuthorizationService authorizationService)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
            _authorizationService = authorizationService;
        }


        // GET ALL - visų paslaugų paėmimas (nepriklausomai nuo prisijungusio vartotojo)
        [HttpGet]
        // Pasiekti veiksmus su paslaugom gali tik gydytojų rolės vartotojai ir administratorius, kuris gali viską
        [Authorize(Roles = UserRoles.DoctorOrAdmin)]
        public async Task<IEnumerable<ServiceDto>> GetAll()
        {
            // Duomenys iš bazės formato pakeičiami į atvaizdavimo formatą
            var services = await _serviceRepository.GetAll();
            return services.Select(o => _mapper.Map<ServiceDto>(o));
        }


        // GET - konkrečios paslaugos paėmimas (nepriklausomai nuo prisijungusio vartotojo)
        [HttpGet("{id}")]
        // Pasiekti veiksmus su paslaugom gali tik gydytojų rolės vartotojai ir administratorius, kuris gali viską
        [Authorize(Roles = UserRoles.SimpleDocAdmin)]
        public async Task<ActionResult<ServiceDto>> Get(int id)
        {       
            var service = await _serviceRepository.Get(id);
            // Tikrinama ar yra tokia paslauga
            if (service == null)
            {
                return NotFound(new { message = $"Tokio id = '{id}' paslaugos nėra." });
            }
            return Ok(_mapper.Map<ServiceDto>(service));
        }


        // POST - naujos paslaugos sukūrimas
        [HttpPost]
        // Pasiekti veiksmus su paslaugom gali tik gydytojų rolės vartotojai ir administratorius, kuris gali viską
        [Authorize(Roles = UserRoles.DoctorOrAdmin)]
        public async Task<ActionResult<ServiceDto>> Post(ServicePostDto servicedto)
        {
            // Duomenį iš gaunamo formato pekeičiame į bazės formatą
            var service = _mapper.Map<Service>(servicedto);

            // Prisijungusio vartotojo id priskyrimas kai resurso savininko
            var logedIn = User;
            service.fk_UserId = logedIn.FindFirst(CustomClaims.UserId).Value;
            await _serviceRepository.Create(service);
            // Grąžinamas 201 kodas ir sukurta paslauga
            return Created($"api/services/{service.Id}", _mapper.Map<ServiceDto>(service));            
        }


        // PUT - konkrečios paslaugos duomenų atnaujinimas (tik sukūręs ar admin  gali keisti)
        [HttpPut("{id}")]
        // Pasiekti veiksmus su paslaugom gali tik gydytojų rolės vartotojai ir administratorius, kuris gali viską
        [Authorize(Roles = UserRoles.DoctorOrAdmin)]
        public async Task<ActionResult<ServiceDto>> Put(int id, ServiceUpdateDto servicedto)
        {
            // Tikrinama ar yra tokia paslauga
            var oldService = await _serviceRepository.Get(id);
            if (oldService == null)
            {
                return NotFound(new { message = $"Tokio id = '{id}' paslaugos nėra." });
            }

            // Tikriname ar prisijungias vartotojas yra resurso kūrėjas
            var auth = await _authorizationService.AuthorizeAsync(User, oldService, PolicyNames.SameUser);
            if (!auth.Succeeded)
            {
                return Forbid(); // Grąžinamas 403 kodas, kad neturi teisės keisti
            }

            _mapper.Map(servicedto, oldService);
            await _serviceRepository.Put(oldService);
            return Ok(_mapper.Map<ServiceDto>(oldService));
        }


        // DELETE - konkrečios paslaugos panaikinimas (tik sukūręs ar admin gali naikinti)
        [HttpDelete("{id}")]
        // Pasiekti veiksmus su paslaugom gali tik gydytojų rolės vartotojai ir administratorius, kuris gali viską
        [Authorize(Roles = UserRoles.DoctorOrAdmin)]
        public async Task<ActionResult<ServiceDto>> Delete(int id)
        {
            // Tikriname ar egzistuoja tokia paslauga
            var service = await _serviceRepository.Get(id);            
            if (service == null)
            {
                return NotFound(new { message = $"Tokio id = '{id}' paslaugos nėra." });
            }

            // Tikriname ar prisijungias vartotojas yra resurso kūrėjas
            var auth = await _authorizationService.AuthorizeAsync(User, service, PolicyNames.SameUser);
            if (!auth.Succeeded)
            {
                return Forbid(); // Grąžinamas 403 kodas, kad neturi teisės keisti
            }

            await _serviceRepository.Delete(service);
            return NoContent();  // Grąžinimas 204 kodas ir tusčia reikšmė
        }


    }
}
