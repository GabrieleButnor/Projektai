using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace L2_veterinarija.ViewModels
{
    public class GyvunasEditViewModel
    {

        [DisplayName("Čipsas")]
        [MaxLength(11)]
        [Required]        
        public string cipsas { get; set; }

        [DisplayName("Rūšis")]
        [MaxLength(20)]
        [Required]        
        public string rusis { get; set; }

        [DisplayName("Tipas")]
        [MaxLength(30)]
        [Required]        
        public string tipas { get; set; }

        [DisplayName("Vardas")]
        [MaxLength(20)]
        [Required]        
        public string vardas { get; set; }

        [DisplayName("Gimimo data")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime gimimodata { get; set; }

        [DisplayName("Svoris")]
        [MaxLength(10)]
        [Required]        
        public string svoris { get; set; }

        [DisplayName("Šeimininkas")]
        [Required]
        public string fk_seimininkas { get; set; }
        public IList<SelectListItem> SeimininkoList { get; set; }
    }
}