using System.ComponentModel.DataAnnotations;

// Augintinio duomenų atnaujinimui galimi laukai bei nurodomi apribojimai laukams
namespace Veterinary.Data.Dtos.Pets
{
    public record PetUpdateDto([Required] string Name);
}
