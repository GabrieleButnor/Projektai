using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Loginai
{
    public class DALYV
    {
        public string ID { get; set; }
        public string RenginioID { get; set; }
        public string Vardas     { get; set; }
        public string Pavarde { get; set; }
        public string ElPastas { get; set; }
        public string TelNr { get; set; }
        public DALYV(string id,string rengid,string vardas, string pavarde,string elpastas,string telnr)
        {
            ID = id;
            RenginioID = rengid;
            Vardas = vardas;
            Pavarde = pavarde;
            ElPastas = elpastas;
            TelNr = telnr;
        }
    }
}