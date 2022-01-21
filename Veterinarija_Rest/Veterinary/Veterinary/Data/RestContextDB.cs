using Microsoft.EntityFrameworkCore;
using Veterinary.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Veterinary.Data.Dtos.Auth;

namespace Veterinary.Data
{
    // Duomenų bazės lentelių aprašymas ir prisijungimas
    public class RestContextDB : IdentityDbContext<RestUsers>
    {
        public DbSet<RestUsers> AspNetUsers { get; set; }
        public DbSet<Pet> pets { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Visit> visits { get; set; }
        public DbSet<Visit_Services> vizis_services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Vet1");
        }

    }
}
