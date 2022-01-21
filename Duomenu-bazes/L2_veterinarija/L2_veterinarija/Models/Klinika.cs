using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace L2_veterinarija.Models
{
    public class Klinika
    {
        [DisplayName("Imones kodas")]
        [Required]
        public string imoneskodas { get; set; }

        [DisplayName("Pavadinimas")]
        [Required]
        public string pavadinimas { get; set; }

        [DisplayName("Adresas")]
        [Required]
        public string adresas { get; set; }

        [DisplayName("Telefonas")]
        [Required]
        public string telefonas { get; set; }

        [DisplayName("Elektroninis paštas")]
        [Required]
        public string epastas { get; set; }

        [DisplayName("Darbuotojų skaičius")]
        [Required]
        public int darbuotojusk { get; set; }
        
        public int fk_miestas { get; set; }

    }
}