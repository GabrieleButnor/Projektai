using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace L2_veterinarija.ViewModels
{
    public class SaskaitaViewModel
    {
        [DisplayName("Numeris")]
        public int numeris { get; set; }

        [DisplayName("Data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime data { get; set; }

        [DisplayName("Mokėjimo būdas")]
        public string mokejimobudas { get; set; }

        [DisplayName("Vizitas")]
        public int svizitas { get; set; }
    }
}