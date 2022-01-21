using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace L2_veterinarija.ViewModels
{
    public class GydytojasEditViewModel
    {
        [DisplayName("Darbuotojo kodas")]
        [MaxLength(6)]
        [Required]
        public string darbuotojokodas { get; set; }

        [DisplayName("Vardas")]
        [MaxLength(20)]
        [Required]
        public string vardas { get; set; }

        [DisplayName("Pavardė")]
        [MaxLength(20)]
        [Required]
        public string pavarde { get; set; }

        [DisplayName("Telefonas")]
        [MaxLength(20)]
        [Required]
        public string telefonas { get; set; }

        [DisplayName("Elektroninis paštas")]
        [EmailAddress]
        [MaxLength(20)]
        [Required]
        public string epastas { get; set; }

        [DisplayName("Stažas")]
        [MaxLength(10)]
        [Required]
        public string stazas { get; set; }

        [DisplayName("Kabinetas")]
        [MaxLength(5)]
        [Required]
        public string kabinetas { get; set; }

        [DisplayName("Klinika")]
        [Required]
        public string fk_klinika { get; set; }

        public IList<SelectListItem> KlinikosList { get; set; }

    }
}