using System.ComponentModel.DataAnnotations;

// Paslaugos sukūrimo privalomi laukai bei nurodomi apribojimai laukams
namespace Veterinary.Data.Dtos.Services
{
    public record ServicePostDto([Required] string Code, [Required] string Type,
        [Required] double Price, [Required] string Duration);
}
