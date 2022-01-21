using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace L2_veterinarija.Models
{
    public class Saskaita
    {
        [DisplayName("Numeris")]
        public int numeris { get; set; }

        [DisplayName("Data")]
        public DateTime data { get; set; }

        [DisplayName("Mokėjimo būdas")]
        public string mokejimobudas { get; set; }

        public virtual Vizitas svizitas { get; set; }
    }
}