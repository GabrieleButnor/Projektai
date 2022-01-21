using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Veterinary.Auth.Model;
using Veterinary.Data.Dtos.Auth;

// Taukenu JWT, žetonų vartotojui sugeneravimas ir valdymas
namespace Veterinary.Auth
{
    public interface ITokenService
    {
        Task<string> CreateAccessTokenAsync(RestUsers user);
    }

    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _authSigningKey;
        private readonly UserManager<RestUsers> _userManager;
        private readonly string _issuer;
        private readonly string _audience;

        public TokenService(Microsoft.Extensions.Configuration.IConfiguration configuration, UserManager<RestUsers> userManager)
        {
            _userManager = userManager;
            // Reikalingu elementų reikšmių priskyrimas iš configuracijos aprašo
            _authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            _issuer = configuration["JWT:ValidIssues"];
            _audience = configuration["JWT:ValidAudience"];
        }

        // Žetono sukūrimas
        public async Task<string> CreateAccessTokenAsync(RestUsers user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(CustomClaims.UserId, user.Id.ToString()),
            };
            authClaims.AddRange(userRoles.Select(userRoles => new Claim(ClaimTypes.Role, userRoles)));

            var accessSecurityToken = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddMinutes(30),
                issuer: _issuer,
                audience: _audience,
                claims: authClaims,
                signingCredentials : new SigningCredentials(_authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(accessSecurityToken);
        }
    }
}
