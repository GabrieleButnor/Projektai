using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Data.Entities;

// Vizito ir paslaugų terpinės lentelės repozitoija, jos sąsaja
namespace Veterinary.Data.Repositories
{

    public interface IVisitServicesRepository
    {
        Task<List<Visit_Services>> GetAllOf(int visitId);
        Task<Visit_Services> Get(int visitId, int servceId);
        Task Create(Visit_Services visitServices);
        Task Put(Visit_Services visitServices);
        Task Delete(Visit_Services visitServices);
    }
    public class VisitServicesRepository : IVisitServicesRepository
    {
        private readonly RestContextDB _RestContext;

        public VisitServicesRepository(RestContextDB restContext)
        {
            _RestContext = restContext;
        }

        // Visi vizito paslaugų id
        public async Task<List<Visit_Services>> GetAllOf(int visitId)
        {
            return await _RestContext.vizis_services.Where(o => o.fk_VisitId == visitId).ToListAsync();
        }

        // Konkreti vizito ir pasluagos pora
        public async Task<Visit_Services> Get(int visitId, int serviceId)
        {
            return await _RestContext.vizis_services.FirstOrDefaultAsync(o => o.fk_VisitId == visitId  && o.fk_ServiceId == serviceId);
        }

        // Sukurti nauja vizito ir paslaugos sąsają
        public async Task Create(Visit_Services visitServices)
        {
            _RestContext.vizis_services.Add(visitServices);
            _RestContext.SaveChangesAsync();
        }

        // Atnaujinti vizito ir paslaugos sąsają
        public async Task Put(Visit_Services visitServices)
        {
            _RestContext.vizis_services.Update(visitServices);
             await _RestContext.SaveChangesAsync();
        }

        // Pašalinti vizito ir paslaugos sąsają
        public async Task Delete(Visit_Services visitServices)
        {
            _RestContext.vizis_services.Remove(visitServices);
            await _RestContext.SaveChangesAsync();
        }


    }
}
