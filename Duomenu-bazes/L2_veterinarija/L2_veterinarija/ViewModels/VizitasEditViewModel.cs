using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L2_veterinarija.Models;

namespace L2_veterinarija.ViewModels
{
    public class VizitasEditViewModel
    {
        [DisplayName("Numeris")]
        [Required]
        public int numeris { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        [DisplayName("Sudarymo data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime sudarymodata { get; set; }

        [DataType(DataType.DateTime)]
        [Required]
        [DisplayName("Vizito data")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime vizitodata { get; set; }

        [DisplayName("Vizito valanda")]
        [Required]
        public string vizitovalanda { get; set; }

        [DisplayName("Būsena")]
        [Required]
        public string busena { get; set; }

        [DisplayName("Gydytojas")]
        [Required]

        public string fk_gydytojas { get; set; }

        [DisplayName("Gyvūnas")]
        [Required]
        public string fk_gyvunas { get; set; }


        public virtual List<Itraukimas> paslaugos { get; set; }

        public virtual List<Priskyrimas> prekes { get; set; }

        public IList<SelectListItem> GydytojaiList { get; set; }

        public IList<SelectListItem> GyvunaiList { get; set; }

        public IList<SelectListItem> PaslaugosList { get; set; }

        public IList<SelectListItem> PrekesList { get; set; }

    }
}