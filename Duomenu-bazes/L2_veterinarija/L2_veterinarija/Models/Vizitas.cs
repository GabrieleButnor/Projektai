using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace L2_veterinarija.Models
{
    public class Vizitas
    {
        [DisplayName("Numeris")]
        public int numeris { get; set; }

        [DisplayName("Sudarymo data")]
        public DateTime sudarymodata { get; set; }

        public DateTime vizitodata { get; set; }
        public string vizitovalanda { get; set; }
        public string busena { get; set; }
        public string fk_gydytojas { get; set; }
        public string fk_gyvunas { get; set; }
        
    }
}