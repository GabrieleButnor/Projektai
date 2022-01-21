using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loginai
{
    public class Preke
    {
        public string Pavadinimas { get; private set; }
        public double Kaina { get; private set; }
        public int Kiekis { get; private set; }
        public string Apibudinimas { get; private set; }

        public Preke(string pavadinimas, double kaina, int kiekis, string apibudinimas)
        {
            Pavadinimas = pavadinimas;
            Kaina = kaina;
            Kiekis = kiekis;
            Apibudinimas = apibudinimas;
        }


    }
}