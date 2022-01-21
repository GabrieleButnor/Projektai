using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Veterinary.Auth.Model;

namespace Veterinary.Auth
{
    // Autorizacija, tik tas kas sukūrė resursą gali jį redaguoti ar naikinti arba administratorius
    public class SameUserAuthHandler : AuthorizationHandler<SameUserRequirement, IUserOwnedResource>
    {
        // Nesvarbu kas iš klasių ateis galime panaudot koda patikrinimui
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SameUserRequirement requirement,
            IUserOwnedResource resource)
        {
            if(context.User.IsInRole(UserRoles.Admin) || context.User.FindFirst(CustomClaims.UserId).Value == resource.fk_UserId)
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

    public record SameUserRequirement : IAuthorizationRequirement;
}
