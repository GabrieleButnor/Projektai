using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace L2_veterinarija.Models
{
    public class Miestas
    {
        [DisplayName("ID")]
        [Required]
        public int id { get; set; }

        [DisplayName("Šalis")]
        [Required]
        public string salis { get; set; }

        [DisplayName("Apskrities pav.")]
        [Required]
        public string apskritiespavadinimas { get; set; }

        [DisplayName("Pavadinimas")]
        [Required]
        public string pavadinimas { get; set; }

        public virtual IEnumerable<Klinika> klinikos { get; set; }
    }
}