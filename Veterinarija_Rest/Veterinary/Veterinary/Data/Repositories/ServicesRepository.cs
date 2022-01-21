using System.Collections.Generic;
using System.Threading.Tasks;
using Veterinary.Data.Entities;
using Microsoft.EntityFrameworkCore;


// Paslaugos repozitorija, jos sąsaja
namespace Veterinary.Data.Repositories
{
    public interface IServiceRepository
    {
        Task<List<Service>> GetAll();
        Task<Service> Get(int id);
        Task Create(Service service); 
        Task Put(Service service);
        Task Delete(Service service);
    }
    public class ServicesRepository : IServiceRepository
    {

        private readonly RestContextDB _RestContext;

        public ServicesRepository(RestContextDB restContext)
        {
            _RestContext = restContext;
        }


        // Visos palsaugos (nepriklausomai nuo prisijungusio vartotojo).
        public async Task<List<Service>> GetAll()
        {
            return await _RestContext.services.ToListAsync();
        }

        // Konkreti paslauga (nepriklausomai nuo prisijungusio vartotojo).
        public async Task<Service> Get(int id)
        {
            return await _RestContext.services.FirstOrDefaultAsync(o => o.Id == id); 
        }

        // Sukurti naują paslaugą
        public async Task Create(Service service)
        {
            _RestContext.services.Add(service);
            await _RestContext.SaveChangesAsync();
        }

        // Atnaujinti paslaugą
        public async Task Put(Service service)
        {
            _RestContext.services.Update(service);
            await _RestContext.SaveChangesAsync();
        }

        // Pašalinti paslaugą
        public async Task Delete(Service service)
        {
            _RestContext.services.Remove(service);
            await _RestContext.SaveChangesAsync();
        }

    }
}
