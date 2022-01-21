using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace L2_veterinarija.Models
{
    public class Gyvunas
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
        public DateTime gimimodata { get; set; }

        [DisplayName("Svoris")]
        public string svoris { get; set; }

        public virtual Seimininkas seimininkas { get; set; }
    }
}