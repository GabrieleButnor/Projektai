using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace L2_veterinarija.ViewModels
{
    public class VizitasListViewModel
    {
        [DisplayName("Numeris")]
        public int numeris { get; set; }

        [DisplayName("Sudarymo data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime sudarymodata { get; set; }

        [DisplayName("Gydytojas")]
        public string gydytojas { get; set; }

        [DisplayName("Gyvūnas")]
        public string gyvunas { get; set; }

        [DisplayName("Būsena")]
        public string busena { get; set; }
        
        
    }
}