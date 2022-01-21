using System.ComponentModel.DataAnnotations;

// Paslaugų duomenų atnaujinimui galimi laukai bei nurodomi apribojimai laukams
namespace Veterinary.Data.Dtos.Services
{
    public record ServiceUpdateDto( [Required] string Type,
        [Required][Range(1,1000)] double Price, [Required] string Duration);
}
