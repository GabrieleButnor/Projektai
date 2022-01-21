using System;

namespace Veterinary.Data.Entities
{
    // Vizitų duomenų bazės klasė
    public class Visit
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public DateTime Visit_date { get; set; }
        public string Visit_hour { get; set; }
        public string Cabinet { get; set; }
        public int fk_PetId { get; set; }

    }
}
