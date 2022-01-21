using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace L2_veterinarija.ViewModels
{
    public class ReceptinisVaistasEditViewModel
    {
        [DisplayName("Kodas")]
        [MaxLength(11)]
        [Required]
        public string kodas { get; set; }

        [DisplayName("Pavadinimas")]
        [MaxLength(30)]
        [Required]
        public string pavadinimasis { get; set; }

        [DisplayName("Paskirtis")]
        [MaxLength(100)]
        [Required]
        public string paskirtis { get; set; }

        [DisplayName("Kaina")]
        [Required]
        public decimal kaina { get; set; }

        [DisplayName("Galiojimo pabaiga")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime galiojimopabaiga { get; set; }

        [DisplayName("Kiekis")]
        [MaxLength(10)]
        [Required]
        public string kiekis { get; set; }

        [DisplayName("Dozė")]
        [MaxLength(10)]
        [Required]
        public string doze { get; set; }

        [DisplayName("Vizitas")]
        [Required]
        public int rvizitas { get; set; }

        public IList<SelectListItem> VizitasList { get; set; }
    }

}