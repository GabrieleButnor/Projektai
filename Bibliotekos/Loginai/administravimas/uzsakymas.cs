using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loginai.administravimas
{
    public class uzsakymas
    {
        public string uzsakymo_id { get; private set; }
        public string data { get; private set; }
        public string pavadinimas { get; private set; }
        public string autorius { get; private set; }
        public string leidimas { get; private set; }
        public string tiekejas { get; private set; }
        public string kiekis { get; private set; }
        public string vnt_kaina { get; private set; }

        public uzsakymas(string uzsakymo_id, string data, string pavadinimas, string autorius, string leidimas, string tiekejas, string kiekis, string vnt_kaina)
        {
            this.uzsakymo_id = uzsakymo_id;
            this.data = data;
            this.pavadinimas = pavadinimas;
            this.autorius = autorius;
            this.leidimas = leidimas;
            this.tiekejas = tiekejas;
            this.kiekis = kiekis;
            this.vnt_kaina = vnt_kaina;
        }
    }
}