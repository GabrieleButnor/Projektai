using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L2_veterinarija.Repos;
using L2_veterinarija.ViewModels;

namespace L2_veterinarija.Controllers
{
    public class GydytojasController : Controller
    {
        GydytojasRepository gydutojasRepository = new GydytojasRepository();
        KlinikaRepository klinikaRepository = new KlinikaRepository();
        MiestasRepository miestasRepository = new MiestasRepository();

        public ActionResult Index()
        {
            return View(gydutojasRepository.getGydytojai());
        }

        public ActionResult Create()
        {
            GydytojasEditViewModel gydytojas = new GydytojasEditViewModel();
            PopulateSelections(gydytojas);
            return View(gydytojas);
        }

        [HttpPost]
        public ActionResult Create(GydytojasEditViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    gydutojasRepository.addGydytojas(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        public ActionResult Edit(string kodas)
        {
            GydytojasEditViewModel gydytojas = gydutojasRepository.getGydytojas(kodas);
            PopulateSelections(gydytojas);
            return View(gydytojas);
        }

        [HttpPost]
        public ActionResult Edit(string kodas, GydytojasEditViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    gydutojasRepository.updateGydytojas(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        public ActionResult Delete(string kodas)
        {
            GydytojasEditViewModel gydytojas = gydutojasRepository.getGydytojas(kodas);
            return View(gydytojas);
        }

        [HttpPost]
        public ActionResult Delete(string kodas, FormCollection collection)
        {
            try
            {
                GydytojasEditViewModel gydytojas = gydutojasRepository.getGydytojas(kodas);
                bool naudojama = false;

                if (gydutojasRepository.getGydytojasCount(kodas) > 0)
                {
                    naudojama = true;
                    ViewBag.naudojama = "Negalima pašalinti gydytojo, nes jam yra priskirtų vizitų.";
                    return View(gydytojas);
                }

                if (!naudojama)
                {
                    gydutojasRepository.deleteGydytojas(kodas);
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public void PopulateSelections(GydytojasEditViewModel gydytojas)
        {

            List<SelectListItem> selectListItems = new List<SelectListItem>();
            List<SelectListGroup> groups = new List<SelectListGroup>();

            var miestas = miestasRepository.getMiestai();

            List<MiestasEditViewModel> miestasViewModel = new List<MiestasEditViewModel>();


            foreach (var item in miestas)
            {
                miestasViewModel.Add(new MiestasEditViewModel { miestas = item, klinikos = klinikaRepository.getKlinikos2(item.id) });
            }

            bool yra = false;
            //sukuriamos paslaugu kainu grupes
            foreach (var item in miestasViewModel)
            {
                yra = false;
                foreach (var i in groups)
                {
                    if (i.Name.Equals(item.miestas.pavadinimas))
                    {
                        yra = true;
                    }
                }
                if (!yra)
                {
                    groups.Add(new SelectListGroup() { Name = item.miestas.pavadinimas });
                }
            }

            foreach (var x in miestasViewModel)
            {
                foreach (var item in x.klinikos)
                {
                    var optGroup = new SelectListGroup() { Name = "--------" };
                    foreach (var i in groups)
                    {
                        if (i.Name.Equals(x.miestas.pavadinimas))
                        {
                            optGroup = i;
                        }
                    }

                    selectListItems.Add(
                        new SelectListItem()
                        {
                            Value = Convert.ToString(item.imoneskodas),
                            Text = item.pavadinimas + "   " + item.adresas,
                            Group = optGroup
                        }
                        );
                }
            }

            gydytojas.KlinikosList = selectListItems;
        }
    }
}