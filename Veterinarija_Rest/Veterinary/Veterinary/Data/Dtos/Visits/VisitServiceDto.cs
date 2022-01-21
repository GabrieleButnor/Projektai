using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Veterinary.Data.Dtos.Services;

// Vizito duomenų atvaizdavimo laukai
namespace Veterinary.Data.Dtos.Visits
{
    public class VisitServiceDto
    {
        public int Id { get; set; } 
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public DateTime Visit_date { get; set; }
        public string Visit_hour { get; set; }
        public string Cabinet { get; set; }
        public int fk_PetId { get; set; }
        public List<ServiceDto> Services { get; set; }
    }

}
