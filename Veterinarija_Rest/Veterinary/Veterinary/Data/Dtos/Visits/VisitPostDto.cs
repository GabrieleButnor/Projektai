using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Vizito sukūrimo privalomi laukai bei nurodomi apribojimai laukams
namespace Veterinary.Data.Dtos.Visits
{
    public record VisitPostDto([Required] int Number, [Required] DateTime Visit_data, [Required] DateTime Date,
        [Required] string Visit_hour, [Required] string Cabinet, List<VisitServicePostDtocs> ServicesId);
}
