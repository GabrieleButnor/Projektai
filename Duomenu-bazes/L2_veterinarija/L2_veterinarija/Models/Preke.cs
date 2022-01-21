using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace L2_veterinarija.Models
{
    public class Preke
    {
        [DisplayName("Kodas")]
        [Required]
        public string kodas { get; set; }

        [DisplayName("Pavadinimas")]
        [Required]
        public string pavadinimas { get; set; }

        [DisplayName("Kaina")]
        [Required]
        public int kaina { get; set; }


        [DisplayName("Informacija")]
        [Required]
        public string informacija { get; set; }

    }
}