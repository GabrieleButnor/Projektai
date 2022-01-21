using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace L2_veterinarija.Models
{
    public class Seimininkas
    {
        [DisplayName("Asmens kodas")]
        [Required]
        public string kodas { get; set; }

        [DisplayName("Vardas")]
        [Required]
        public string vardas { get; set; }

        [DisplayName("Pavardė")]
        [Required]
        public string pavarde { get; set; }

        [DisplayName("Elektroninis paštas")]
        [EmailAddress]
        [Required]
        public string epastas { get; set; }

        [DisplayName("Telefonas")]
        [Required]
        public string telefonas { get; set; }

        [DisplayName("Adresas")]
        [Required]
        public string adresas { get; set; }

    }
}