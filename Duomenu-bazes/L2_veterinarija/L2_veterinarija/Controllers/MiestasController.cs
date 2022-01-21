using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L2_veterinarija.Repos;
using L2_veterinarija.ViewModels;

namespace L2_veterinarija.Controllers
{
    public class MiestasController : Controller
    {
        MiestasRepository miestasRepository = new MiestasRepository();
        KlinikaRepository klinikaRepository = new KlinikaRepository();

        public ActionResult Index()
        {

            return View(miestasRepository.getMiestai());
        }

        public ActionResult Create()
        {
            var miestas = new MiestasEditViewModel();
            return View(miestas);
        }

        [HttpPost]
        public ActionResult Create(MiestasEditViewModel collection)
        {
            try
            {
                // Patikrina ar pavyko iterpti paslauga
                int miestas_id = miestasRepository.insertMiestas(collection.miestas);

                if (miestas_id < 0)
                {
                    ViewBag.failed = "Nepavyko iterpti miesto";
                    return View(collection);
                }
                if (collection.klinikos != null)
                {
                    foreach (var item in collection.klinikos)
                    {
                        item.fk_miestas = miestas_id;
                        klinikaRepository.insertKlinikos(item);
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.klaida = "Ivyko nenumatyta klaida";
                return View(collection);
            }
        }


        public ActionResult Edit(int id)
        {
            MiestasEditViewModel editViewModel = new MiestasEditViewModel();

            editViewModel.miestas = miestasRepository.getMiestas(id);
            editViewModel.klinikos = klinikaRepository.getKlinikos2(id);
            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, MiestasEditViewModel collection)
        {
            try
            {
                // Atnaujina paslaugos informacija

                miestasRepository.updateMiestas(collection.miestas);

                klinikaRepository.deleteKlinikos(id);

                if (collection.klinikos != null)
                {
                    foreach (var item in collection.klinikos)
                    {
                        if (item.kiekis == 0)
                        {
                            //Pridant naujas paslaugas html element nėra nustatytas paslaugos id todėl reikia nustatyti cia
                            if (item.fk_miestas == 0)
                            {
                                item.fk_miestas = id;
                            }
                            klinikaRepository.insertKlinikos(item);
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        public ActionResult Delete(int id)
        {
            MiestasEditViewModel editViewModel = new MiestasEditViewModel();

            editViewModel.miestas = miestasRepository.getMiestas(id);
            editViewModel.klinikos = klinikaRepository.getKlinikos2(id);
            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                MiestasEditViewModel editViewModel = new MiestasEditViewModel();

                editViewModel.miestas = miestasRepository.getMiestas(id);
                editViewModel.klinikos = klinikaRepository.getKlinikos2(id);
                bool naudojama = false;

                foreach (var item in editViewModel.klinikos)
                {
                    if (item.kiekis > 0)
                    {
                        naudojama = true;
                    }
                }

                if (!naudojama)
                {
                    klinikaRepository.deleteKlinikos(id);
                    miestasRepository.deleteMiestas(id);
                }

                if (naudojama)
                {
                    ViewBag.naudojama = "Mieste esanti klinika turi priskirtu gydytoju, pašalinti negalima";
                    return View(editViewModel);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}