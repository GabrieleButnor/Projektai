using System;

// Augintinio duomenų atvaizdavimo laukai
namespace Veterinary.Data.Dtos.Pets
{
    public record PetDto(int Id, int Chip, string Name, string Species, string Type, DateTime Date);
}
