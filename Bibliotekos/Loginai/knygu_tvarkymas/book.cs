using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loginai.knygu_tvarkymas
{
    public class book
    {
        public string numeris { get; private set; }
        public string pavadinimas { get; private set; }
        public string autorius { get; private set; }
        public string isleidimo_data { get; private set; }
        public string leidejas { get; private set; }
        public string zanras { get; private set; }
        public string busena { get; private set; }
        public string puslapiu_sk { get; private set; }
        public string komentaras { get; private set; }


        public book(string numeris, string pavadinimas, string autorius, string isleidimo_data, string leidejas, string zanras, string busena, string puslapiu_sk, string komentaras)
        {
            this.numeris = numeris;
            this.pavadinimas = pavadinimas;
            this.autorius = autorius;
            this.isleidimo_data = isleidimo_data;
            this.leidejas = leidejas;
            this.zanras = zanras;
            this.busena = busena;
            this.puslapiu_sk = puslapiu_sk;
            this.komentaras = komentaras;
        }
    }
}