using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loginai
{
    public class renginiai
    {
        public string ID { get; private set; }
        public string Tipas { get; private set; }
        public string SukData { get; private set; }
        public string RengData { get; private set; }
        public string DalyviuSk { get; private set; }
        public string Vieta { get; private set; }
        public string PAvadinimas { get; private set; }
        public string Laikas { get; private set; }
        public string Aprasas { get; private set; }


        public renginiai(string id, string tipas, string sukurimodata, string renginiodata, string dalyviusk, string vieta, string pavadinimas, string laikas,string aprasas)
        {
            ID = id;
            Tipas = tipas;
            SukData = sukurimodata;
            RengData = renginiodata;
            DalyviuSk = dalyviusk;
            Vieta = vieta;
            PAvadinimas = pavadinimas;
            Laikas = laikas;
            Aprasas = aprasas;
        }
    }
}