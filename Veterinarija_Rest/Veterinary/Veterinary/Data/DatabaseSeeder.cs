using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Veterinary.Auth.Model;
using Veterinary.Data.Dtos.Auth;

namespace Veterinary.Data
{
    // Prieš kiekvieną paleidimą atliekami veiksmai
    public class DatabaseSeeder
    {
        // Varotoju ir rolių valdymo objektai
        private readonly UserManager<RestUsers> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(UserManager<RestUsers> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            // Rolių sukūrimas
            foreach( var role in UserRoles.All)
            {
                var roleExist = await _roleManager.RoleExistsAsync(role);
                if(!roleExist)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Administratoriaus vartotojo sukurimas, rolės priskyrimas
            var newAdminUser = new RestUsers
            {
                Personal_code = "11111111111",
                UserName = "admin",
                Surname = "admin",
                Email = "admmon@adimn.com",
                PhoneNumber = "861111111",
                Address = "Kaunas, Giros 13-3",
                Type = 9
            };
            var existingAdmin = await _userManager.FindByEmailAsync(newAdminUser.Email);
            if(existingAdmin == null)
            {
                var crateAdminUser = await _userManager.CreateAsync(newAdminUser, "Idomumo_delei_213!");
                if(crateAdminUser.Succeeded)
                {
                    await _userManager.AddToRolesAsync(newAdminUser, UserRoles.All);
                }
            }

            // Daktaro vartotojaus sukūrimas, rolės priskyrimas
            var newDoctor1 = new RestUsers
            {
                Personal_code = "99825367452",
                UserName = "Vilte",
                Surname = "Svogunskienė",
                Email = "VilteSvog@gmail.com",
                PhoneNumber = "869843295",
                Address = "Kaunas, Nemuno 23",
                Type = 5
            };
            var existingDoc1 = await _userManager.FindByEmailAsync(newDoctor1.Email);
            if (existingDoc1 == null)
            {
                var crateDocUser1 = await _userManager.CreateAsync(newDoctor1, "Gulbe_Balta_14");
                if (crateDocUser1.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newDoctor1, UserRoles.DoctorUser);
                }
            }

            // Daktaro vartotojaus sukūrimas, rolės priskyrimas
            var newDoctor2 = new RestUsers
            {
                Personal_code = "99825367453",
                UserName = "Rytis",
                Surname = "Raškevicius",
                Email = "R.Raškevic@gmail.com",
                PhoneNumber = "869843475",
                Address = "Kaunas, Vetrungės 44-10",
                Type = 5
            };
            var existingDoc2 = await _userManager.FindByEmailAsync(newDoctor2.Email);
            if (existingDoc2 == null)
            {
                var crateDocUser2 = await _userManager.CreateAsync(newDoctor2, "labai_Stiprus_1727");
                if (crateDocUser2.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newDoctor2, UserRoles.DoctorUser);
                }
            }

            // Daktaro vartotojaus sukūrimas, rolės priskyrimas
            var newDoctor3 = new RestUsers
            {
                Personal_code = "99825367455",
                UserName = "Egle",
                Surname = "Puodelyte",
                Email = "Puodelyte@gmail.com",
                PhoneNumber = "869843370",
                Address = "Kaunas, Vilijos 32",
                Type = 5
            };
            var existingDoc3 = await _userManager.FindByEmailAsync(newDoctor3.Email);
            if (existingDoc3 == null)
            {
                var crateDocUser3 = await _userManager.CreateAsync(newDoctor3, "Ilgos_dienos_naktys555");
                if (crateDocUser3.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newDoctor3, UserRoles.DoctorUser);
                }
            }
        }
    }
}
