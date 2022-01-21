using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace L2_veterinarija.ViewModels
{
    public class ReceptinisVaistasViewModel
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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime galiojimopabaiga { get; set; }

        [DisplayName("Kiekis")]
        public string kiekis { get; set; }

        [DisplayName("Dozė")]
        public string doze { get; set; }

        [DisplayName("Vizitas")]
        public int rvizitas { get; set; }
    }
}