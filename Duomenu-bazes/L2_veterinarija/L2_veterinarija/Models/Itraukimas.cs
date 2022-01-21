using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace L2_veterinarija.Models
{
    public class Itraukimas
    {
        [Required]
        public int fk_priskirtavizitui { get; set; }

        [Required]
        public string fk_paslauga { get; set; }
        public virtual string fk_key { get; set; }
    }
}