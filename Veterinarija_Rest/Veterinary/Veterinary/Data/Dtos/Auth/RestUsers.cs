using Microsoft.AspNetCore.Identity;

namespace Veterinary.Data.Dtos.Auth
{
    // Saugaus vartojo klasė 
    public class RestUsers : IdentityUser
    {
        [PersonalData]
        public string Personal_code { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public int Type { get; set; }
    }
}
