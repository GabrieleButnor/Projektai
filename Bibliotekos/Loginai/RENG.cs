using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loginai
{
    public class RENG
    {
        public string ID { get; set; }
        public string Pavadinimas { get; set; }

        public RENG(string id,string pavadinimas)
        {
            ID = id;
            Pavadinimas = pavadinimas;
        }
    }
}