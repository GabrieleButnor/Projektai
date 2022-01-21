using System;
using System.ComponentModel.DataAnnotations;

// Vizito duomenų atnaujinimui galimi laukai bei nurodomi apribojimai laukams
namespace Veterinary.Data.Dtos.Visits
{
    public record VisitUpdateDto([Required] DateTime Visit_data, [Required] DateTime Date,
        [Required] string Visit_hour, [Required] string Cabinet);
}
