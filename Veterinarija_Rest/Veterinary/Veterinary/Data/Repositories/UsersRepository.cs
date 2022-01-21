using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Auth.Model;
using Veterinary.Data.Dtos.Auth;


// Vartotojo repozitorija, jos sąsaja
namespace Veterinary.Data.Repositories
{
    public interface IUserRepository
    {
        Task<List<RestUsers>> GetAll(string role);
        Task<RestUsers> Get(string id, string role);
        Task Put(RestUsers user);
        Task Delete(RestUsers user);
    }

    public class UsersRepository : IUserRepository
    {

        private readonly RestContextDB _RestContext;

        public UsersRepository(RestContextDB restContext)
        {
            _RestContext = restContext;
        }


        // Visi vartotojai (pagal prisijungusi)
        public async Task<List<RestUsers>> GetAll(string role)
        {
            // Kuomet prisijungęs vartotojas daktaro teisėmis rodomi tik visi paprasti vartotojai
            if ( role == UserRoles.DoctorUser)
            {
                return await _RestContext.AspNetUsers.Where(o => o.Type == 1).ToListAsync();
            }
            // Kuomet prisijungęs vartotojas admino teisėmis rodomi visi
            return await _RestContext.AspNetUsers.ToListAsync();
        }


        // Konkretus vartotojas (pagal prisijungusi)
        public async Task<RestUsers> Get(string id, string role)
        {
            // Kuomet prisijungęs vartotojas daktaro teisėmis rodomas tik paprastas vartotojas
            if (role == UserRoles.DoctorUser)
            {
                return await _RestContext.AspNetUsers.FirstOrDefaultAsync(o => o.Id == id && o.Type == 1);
            }
            // Kuomet prisijungęs vartotojas admino teisėmis rodomas bet kuris varttojas
            return await _RestContext.AspNetUsers.FirstOrDefaultAsync(o => o.Id == id); 
        }


        // Atnaujinti vartotoją
        public async Task Put(RestUsers user)
        {
            _RestContext.AspNetUsers.Update(user);
            await _RestContext.SaveChangesAsync();

        }


        // Pašalinti vartotoją
        public async Task Delete(RestUsers user)
        {
            _RestContext.AspNetUsers.Remove(user);
            await _RestContext.SaveChangesAsync();
        }


    }
}
