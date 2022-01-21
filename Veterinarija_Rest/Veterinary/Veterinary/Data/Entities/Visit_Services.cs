
namespace Veterinary.Data.Entities
{
    // Vizitų paslaugų duomenų bazės klasė
    public class Visit_Services
    {
        public int Id { get; set; }
        public int fk_VisitId { get; set; }
        public int fk_ServiceId { get; set; }

    }
}
