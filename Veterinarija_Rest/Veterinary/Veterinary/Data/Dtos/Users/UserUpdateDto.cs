using System.ComponentModel.DataAnnotations;

// Vartotojo duomenų atnaujinimui galimi laukai bei nurodomi apribojimai laukams
namespace Veterinary.Data.Dtos.Users
{
    public record UserUpdateDto( [Required] string Name, [Required] string Surname, 
        [Required] string Phone, [Required] string Address);
}
