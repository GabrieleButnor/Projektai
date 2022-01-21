using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Data.Entities;


// Vizito repozitorija, jos sąsaja
namespace Veterinary.Data.Repositories
{
    public interface IVisitRepository
    {
        Task<List<Visit>> GetAllOf(string userId, int petId);
        Task<Visit> Get(string userId, int petId, int id);
        Task Create(Visit visit);
        Task Put(Visit visit);
        Task Delete(Visit visit);
    }

    public class VisitsRepository : IVisitRepository
    {

        private readonly RestContextDB _RestContext;

        public VisitsRepository(RestContextDB restContext)
        {
            _RestContext = restContext;
        }

        // Visi vartotojo augintinio vizitai
        public async Task<List<Visit>> GetAllOf(string userId, int petId)
        {
            return await _RestContext.visits.Where(o => o.fk_PetId == petId).ToListAsync();
        }


        // Konkretus vartotojo augintinio vizitas
        public async Task<Visit> Get(string userId, int petId, int id)
        {
            return await _RestContext.visits.FirstOrDefaultAsync(o => o.fk_PetId == petId && o.Id == id);
        }

        // Sukurti naują vartotojo augintinio vizitą
        public async Task Create(Visit visit)
        {
            _RestContext.visits.Add(visit);
            await _RestContext.SaveChangesAsync();
        }

        // Atnaujinti vartotojo augintinio viztą
        public async Task Put(Visit visits)
        {
            _RestContext.visits.Update(visits);
            await _RestContext.SaveChangesAsync();
        }

        // Pašalinti vartotojo augintino vizitą
        public async Task Delete(Visit visit)
        {
            _RestContext.visits.Remove(visit);
            await _RestContext.SaveChangesAsync();
        }


    }
}
