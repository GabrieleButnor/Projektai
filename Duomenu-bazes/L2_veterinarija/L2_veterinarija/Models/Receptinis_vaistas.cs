using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace L2_veterinarija.Models
{
    public class Receptinis_vaistas
    {
        [DisplayName("Kodas")]
        public string kodas { get; set; }

        [DisplayName("Pavadinimas")]
        public string pavadinimasis { get; set; }

        [DisplayName("Paskirtis")]
        public string paskirtis { get; set; }

        [DisplayName("Kaina")]
        public decimal kaina { get; set; }

        [DisplayName("Galiojimo pabaiga")]
        public DateTime galiojimopabaiga { get; set; }

        [DisplayName("Kiekis")]
        public string kiekis { get; set; }

        [DisplayName("Dozė")]
        public string doze { get; set; }

        public virtual Vizitas rvizitas { get; set; }
    }
}