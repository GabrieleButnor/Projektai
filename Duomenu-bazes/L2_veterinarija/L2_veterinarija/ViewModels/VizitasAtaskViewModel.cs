using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using L2_veterinarija.ViewModels;

namespace L2_veterinarija.ViewModels
{
    public class VizitasAtaskViewModel
    {
        public List<VAtaskaitaViewModel> vizitai { get; set; }
        public decimal visoSumaVaistu { get; set; }
        public decimal visoSumaPrekiu{ get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? nuo { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? iki { get; set; }

        public string busena { get; set; }
    }
}