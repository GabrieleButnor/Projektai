using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using L2_veterinarija.Models;
using L2_veterinarija.ViewModels;


namespace L2_veterinarija.ViewModels
{
    public class MiestasEditViewModel
    {
        public Miestas miestas { get; set; }

        public List<KlinikaViewModel> klinikos { get; set; }
    }
}