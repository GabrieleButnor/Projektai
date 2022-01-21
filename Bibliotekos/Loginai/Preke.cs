using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loginai
{
    public class Preke
    {
        public string ID { get; private set; }
        public string Vardas { get; private set; }
        public string Pavarde { get; private set; }
        public string Data { get; private set; }
        public string Pastas { get; private set; }
        public string Numeris { get; private set; }
        public string Ardesas { get; private set; }
        public string Pareigos { get; private set; }
       
  
        public Preke(string id, string vardas, string pavarde, string gd, string pastas, string telnr, string adr,string pareigos)
        {
            ID = id;
            Vardas = vardas;
            Pavarde = pavarde;
            Data = gd;
            Pastas = pastas;
            Numeris = telnr;
            Ardesas = adr;
            Pareigos = pareigos;
        }


    }
}