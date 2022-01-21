using Veterinary.Auth.Model;
using Veterinary.Data.Dtos.Auth;

namespace Veterinary.Data.Entities
{
    // Paslagų duomenų bazės klasė, su autorizacijos paveldėjimu
    public class Service : IUserOwnedResource
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
        public string Duration { get; set; }
        public string fk_UserId { get; set; }
    }
}
