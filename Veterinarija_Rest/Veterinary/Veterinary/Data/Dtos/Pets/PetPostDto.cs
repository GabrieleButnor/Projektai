using System;
using System.ComponentModel.DataAnnotations;

//Aaugintinio sukūrimo privalomi laukai bei nurodomi apribojimai laukams
namespace Veterinary.Data.Dtos.Pets
{
    public record PetPostDto([Required] string Chip, [Required] string Name, [Required] string Species, 
       [Required] string Type, [Required] DateTime Date, [Required] int fk_UserId);
}
