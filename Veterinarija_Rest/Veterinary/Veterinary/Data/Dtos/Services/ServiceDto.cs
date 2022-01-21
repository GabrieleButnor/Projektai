
// Paslaugos duomenų atvaizdavimo laukai
namespace Veterinary.Data.Dtos.Services
{
    public record ServiceDto(int Id, string Code, string Type, double Price, string Duration, string fk_UserId);
}
