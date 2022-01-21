using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Auth.Model;
using Veterinary.Data.Entities;


// Augintinio repozitorija, jos sąsaja
namespace Veterinary.Data.Repositories
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetAllOf(string userId, string restUser, string role);
        Task<Pet> Get(string userId, string restUser, int id, string role);
        Task Create(Pet pet);
        Task Put(Pet pet);
        Task Delete(Pet pet);
    }
    public class PetsRepository : IPetRepository
    {

        private readonly RestContextDB _RestContext;

        public PetsRepository(RestContextDB restContext)
        {
            _RestContext = restContext;
        }


        // Visi prisijungusio vartotojo augintiniai
        public async Task<List<Pet>> GetAllOf(string userId, string restUser, string role)
        {
            // Kuomet prisijungęs vartotojas rodomi tik šio paprasto vartotojo visi augintiniai
            if (role == UserRoles.SimpleUser)
            {
                return await _RestContext.pets.Where(o => o.fk_UserId == userId && o.fk_UserId == restUser).ToListAsync();
            }
            // Kuomet prisijungęs vartotojas admino arba daktaro teisėmis rodomi visi gyvunai
            return await _RestContext.pets.Where(o => o.fk_UserId == userId).ToListAsync();
        }


        // Konkretus prisijungusio vartotojo augintinis
        public async Task<Pet> Get(string userId, string restUser, int id, string role)
        {
            // Kuomet prisijungęs vartotojas rodomi tik šio paprasto vartotojo augintinis
            if (role == UserRoles.SimpleUser)
            {
                return await _RestContext.pets.FirstOrDefaultAsync(o => o.fk_UserId == userId && o.fk_UserId == restUser && o.Id == id);
            }
            // Kuomet prisijungęs vartotojas admino arba daktaro teisėmis rodomas bet kuris gyvunas
            return await _RestContext.pets.FirstOrDefaultAsync(o => o.fk_UserId == userId && o.Id == id);
        }


        // Sukurti nauja prisijungusiam vartotojui augintinį
        public async Task Create(Pet pet)
        {
            _RestContext.pets.Add(pet);
            await _RestContext.SaveChangesAsync();
        }


        // Atnaujinti prisijungusio vartotojo augintinį
        public async Task Put(Pet pet)
        {
            _RestContext.pets.Update(pet);
            await _RestContext.SaveChangesAsync();
        }


        // Pašalinti prisijungusio vartotojo augintinį
        public async Task Delete(Pet pet)
        {
            _RestContext.pets.Remove(pet);
            await _RestContext.SaveChangesAsync();
        }

    }
}
