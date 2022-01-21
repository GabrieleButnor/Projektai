using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace L2_veterinarija.Models
{
    public class Priskyrimas
    {
        [Required]
        public int fk_pridetavizitui { get; set; }
        [Required]
        public string fk_preke { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int vienetai { get; set; }
        public virtual string fk_key { get; set; }

    }
}