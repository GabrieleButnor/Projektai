using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loginai.isdavimu_tvarkymas
{
    public class apdovanojimas
    {
        public string id { get; private set; }
        public string sudarymo_data { get; private set; }
        public string pavadinimas { get; private set; }
        public string komentaras { get; private set; }
        public string fk_bibliotekininkas { get; private set; }

        public apdovanojimas(string id, string sudarymo_data, string pavadinimas, string komentaras, string fk_bibliotekininkas)
        {
            this.id = id;
            this.sudarymo_data = sudarymo_data;
            this.pavadinimas = pavadinimas;
            this.komentaras = komentaras;
            this.fk_bibliotekininkas = fk_bibliotekininkas;
        }

    }
}