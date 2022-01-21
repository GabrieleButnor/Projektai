using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Veterinary.Data.Dtos.Auth;
using Microsoft.AspNetCore.Identity;
using Veterinary.Data.Dtos.Users;
using AutoMapper;
using Veterinary.Auth;
using Veterinary.Auth.Model;

namespace Veterinary.Controllers
{
    [ApiController]
    [AllowAnonymous] // metodą gali naudoti neprisijungęs vartotojas
    [Route("api")]
    public class AuthController : ControllerBase
    {
        // Vartotojo valdymo, mepinimo ir žetunų serviso aprašymas
        private readonly UserManager<RestUsers> _userManager;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        public AuthController(UserManager<RestUsers> userManager, IMapper mapper, ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        // Vartotojo registravimas sukuriant žetoną ir pirksiriant rolę paprasto vartotjo
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            // Tikrinima ar tokiu paštu yra jau sukurtas vartotojas
            var user = await _userManager.FindByEmailAsync(registerUserDto.E_mail);
            if(user != null)
            {
                return BadRequest(new { message = $"Netinkama užklausa." });
            }
            // Kuomet nėra tokio pašto vartotojo sukuriamas naujas
            var newUser = new RestUsers
            {
                Personal_code = registerUserDto.Personal_code,
                UserName = registerUserDto.Name,
                Surname = registerUserDto.Surname,
                Email = registerUserDto.E_mail,
                PhoneNumber = registerUserDto.Phone,
                Address = registerUserDto.Address,
                Type = 1
            };
            // Slaptžodžio sugeneravimas
            var createUserResult = await _userManager.CreateAsync(newUser, registerUserDto.Passward);
            if (!createUserResult.Succeeded)
            {
                return BadRequest(new { message = $"Nepavyko sukurti vartotojo." });
            }
            // Priskiriama paprasto vartotojo rolė
            await _userManager.AddToRoleAsync(newUser, UserRoles.SimpleUser);
            return CreatedAtAction(nameof(Register), _mapper.Map<UserDto>(newUser));

        }

        // Prisijungimas
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            // Tikrinamas pasto adresas
            var user = await _userManager.FindByEmailAsync(loginDto.E_mail);
            if (user == null)
            {
                return BadRequest(new { message = $"Netesingas vartotojas arba slaptažodis." });
            }
            // Tikrinamas slaptažodis
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if(!isPasswordValid)
            {
                return BadRequest(new { message = $"Netesingas vartotojas arba slaptažodis." });
            }
            // Sugeneruojamas žetonas
            var accessToken = await _tokenService.CreateAccessTokenAsync(user);
            var userId = user.Id;

            return Ok(new SuccessfulLoginDto(accessToken, userId));
        }


    }
}
