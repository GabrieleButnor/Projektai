using System;
using Veterinary.Auth.Model;
using Veterinary.Data.Dtos.Auth;

namespace Veterinary.Data.Entities
{
    // Augintinio duomenų bazės klasė
    public class Pet : IUserOwnedResource
    {
        public int Id { get; set; }
        public int Chip { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string fk_UserId { get; set; }
    }
}
