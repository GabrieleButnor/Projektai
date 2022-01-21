using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loginai.isdavimu_tvarkymas
{
    public class isdavimas
    {
        public string id { get; private set; }
        public string isdavimo_data { get; private set; }
        public string grazinimo_data { get; private set; }
        public string filialas { get; private set; }
        public string busena { get; private set; }
        public string fk_skaitytojas { get; private set; }
        public string fk_knyga { get; private set; }
        public string fk_bibliotekininkas { get; private set; }

        public isdavimas(string id, string isdavimo_data, string grazinimo_data, string filialas, string busena, string fk_skaitytojas, string fk_knyga, string fk_bibliotekininkas)
        {
            this.id = id;
            this.isdavimo_data = isdavimo_data;
            this.grazinimo_data = grazinimo_data;
            this.filialas = filialas;
            this.busena = busena;
            this.fk_skaitytojas = fk_skaitytojas;
            this.fk_knyga = fk_knyga;
            this.fk_bibliotekininkas = fk_bibliotekininkas;
        }

    }
}