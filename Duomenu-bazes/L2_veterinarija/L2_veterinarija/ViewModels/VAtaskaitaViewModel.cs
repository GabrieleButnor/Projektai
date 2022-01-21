using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace L2_veterinarija.ViewModels
{
    public class VAtaskaitaViewModel
    {
        [DisplayName("Vizitas")]
        public int numeris { get; set; }

        [DisplayName("Data")]
        public DateTime sudarymo_data { get; set; }

        [DisplayName("Būsena")]
        public string busena { get; set; }
        public string vardas { get; set; }
        public string pavarde { get; set; }
        public string asmensKodas { get; set; }

        [DisplayName("Gyvūnas")]
        public string gyvunas { get; set; }

        [DisplayName("Paslaugų vertė")]
        public decimal paslauguKaina { get; set; }

        [DisplayName("Prekių vertė")]
        public decimal prekeKaina { get; set; }
        public decimal bendraSumaPaslaugu { get; set; }
        public decimal bendraSumaPrekiu { get; set; }
    }
}