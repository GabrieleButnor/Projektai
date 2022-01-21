using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace L2_veterinarija.ViewModels
{
    public class SaskaitaEditViewModel
    {
        [DisplayName("Numeris")]
        [Required]
        public int numeris { get; set; }

        [DisplayName("Data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime data { get; set; }

        [DisplayName("Mokėjimo būdas")]
        [MaxLength(25)]
        [Required]
        public string mokejimobudas { get; set; }

        [DisplayName("Vizitas")]
        [Required]
        public int svizitas { get; set; }

        public IList<SelectListItem> sVizitasList { get; set; }
    }
}