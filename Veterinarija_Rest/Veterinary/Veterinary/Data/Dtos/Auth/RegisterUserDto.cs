using System.ComponentModel.DataAnnotations;

// Registracijai privalomi vartotojo duomenys ir apribojimai
namespace Veterinary.Data.Dtos.Auth
{
    public record RegisterUserDto([Required][MinLength(11)][MaxLength(11)] string Personal_code,
        [Required] string Name, [Required] string Surname, [Required][EmailAddress] string E_mail,
        [Required] string Phone, [Required] string Address, [Required] string Passward);
}
