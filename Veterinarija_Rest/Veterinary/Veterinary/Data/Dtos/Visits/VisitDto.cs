using System;

// Vizito duomenų atvaizdavimo laukai
namespace Veterinary.Data.Dtos.Visits
{
    public record VisitDto(int Id, int Number, DateTime Date, DateTime Visit_date, 
        string Visit_hour, string Cabinet, int fk_PetId);
}
