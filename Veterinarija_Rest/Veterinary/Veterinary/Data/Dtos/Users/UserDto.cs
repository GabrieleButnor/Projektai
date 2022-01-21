
// Vartotjo duomenų atvaizdavimo laukai
namespace Veterinary.Data.Dtos.Users
{
    public record UserDto(string Id, string Personal_code, string UserName, 
        string Surname, string Email, string PhoneNumber, string Address, int Type);
}
