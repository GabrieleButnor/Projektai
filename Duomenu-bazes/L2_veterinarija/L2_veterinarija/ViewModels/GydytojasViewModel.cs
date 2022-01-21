using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace L2_veterinarija.ViewModels
{
    public class GydytojasViewModel
    {
        [DisplayName("Darbuotojo kodas")]
        public string darbuotojokodas { get; set; }

        [DisplayName("Vardas")]
        public string vardas { get; set; }

        [DisplayName("Pavardė")]
        public string pavarde { get; set; }

        [DisplayName("Telefonas")]
        public string telefonas { get; set; }

        [DisplayName("Elektroninis paštas")]
        public string epastas { get; set; }

        [DisplayName("Stažas")]
        public string stazas { get; set; }

        [DisplayName("Kabinetas")]
        public string kabinetas { get; set; }

        [DisplayName("Klinika")]
        public string klinika { get; set; }
    }
}