using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loginai.isdavimu_tvarkymas
{
    public class _sarasai
    {
        public string id { get; private set; }
        public string reiksme { get; private set; }


        public _sarasai(string id, string reiksme)
        {
            this.id = id;
            this.reiksme = reiksme;
        }
    }
}