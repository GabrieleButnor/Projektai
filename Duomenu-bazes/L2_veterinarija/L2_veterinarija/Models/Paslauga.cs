using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace L2_veterinarija.Models
{
    public class Paslauga
    {
        [DisplayName("Paslaugos kodas")]
        [Required]
        public string paslaugoskodas { get; set; }

        [DisplayName("Tipas")]
        [Required]
        public string tipas { get; set; }

        [DisplayName("Kaina")]
        [Required]
        public int kaina { get; set; }

        [DisplayName("Trukmė")]
        [Required]
        public string trukme { get; set; }

    }
}
