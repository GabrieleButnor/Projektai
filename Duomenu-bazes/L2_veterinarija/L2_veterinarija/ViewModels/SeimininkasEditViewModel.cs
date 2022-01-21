using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using L2_veterinarija.Models;
using L2_veterinarija.ViewModels;

namespace L2_veterinarija.ViewModels
{
    public class SeimininkasEditViewModel
    {
        public Seimininkas seimininkas { get; set; }

        public List<GyvunasViewModel> gyvunas { get; set; }
    }
}