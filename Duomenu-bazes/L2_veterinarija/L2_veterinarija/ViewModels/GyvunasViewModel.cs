using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace L2_veterinarija.ViewModels
{
    public class GyvunasViewModel
    {
        [DisplayName("Čipsas")]
        public string cipsas { get; set; }

        [DisplayName("Rūšis")]
        public string rusis { get; set; }

        [DisplayName("Tipas")]
        public string tipas { get; set; }

        [DisplayName("Vardas")]
        public string vardas { get; set; }

        [DisplayName("Gimimo data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime gimimodata { get; set; }

        [DisplayName("Svoris")]
        public string svoris { get; set; }

        [DisplayName("Šeimininkas")]
        public string seimininkas { get; set; }

    }
}