using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loginai.isdavimu_tvarkymas
{
    public class skaitytojas
    {
        public string skaitytojo_nr { get; private set; }
        public string vardas { get; private set; }
        public string pavarde { get; private set; }
        public string el_pastas { get; private set; }
        public string telefono_nr { get; private set; }
        public string gimimo_data { get; private set; }

        public skaitytojas(string skaitytojo_nr, string vardas, string pavarde, string el_pastas, string telefono_nr, string gimimo_data)
        {
            this.skaitytojo_nr = skaitytojo_nr;
            this.vardas = vardas;
            this.pavarde = pavarde;
            this.el_pastas = el_pastas;
            this.telefono_nr = telefono_nr;
            this.gimimo_data = gimimo_data;
        }

    }
}