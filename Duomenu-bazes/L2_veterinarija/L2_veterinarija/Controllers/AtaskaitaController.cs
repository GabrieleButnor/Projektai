using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L2_veterinarija.Repos;
using L2_veterinarija.ViewModels;

namespace L2_veterinarija.Controllers
{
    public class AtaskaitaController : Controller
    {
        AtaskaituRepository ataskaituRepository = new AtaskaituRepository();

        public ActionResult Vizitai(DateTime? nuo, DateTime? iki, string busena)
        {
            VizitasAtaskViewModel ataskaita = new VizitasAtaskViewModel();
            ataskaita.nuo = nuo == null ? null : nuo;
            ataskaita.iki = iki == null ? null : iki;
            ataskaita.busena = busena == null ? null : busena;
            ataskaita.vizitai = ataskaituRepository.getAtaskaitaVizitu(ataskaita.nuo, ataskaita.iki, ataskaita.busena);      
            foreach (var item in ataskaita.vizitai)
            {
                ataskaita.visoSumaVaistu += item.paslauguKaina;
                ataskaita.visoSumaPrekiu += item.prekeKaina;
            }

            return View(ataskaita);
        }
    }
}