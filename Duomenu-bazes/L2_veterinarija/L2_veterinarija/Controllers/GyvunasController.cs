using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L2_veterinarija.Repos;
using L2_veterinarija.ViewModels;

namespace L2_veterinarija.Controllers
{
    public class GyvunasController : Controller
    {
        GyvunasRepository gyvunasRepository = new GyvunasRepository();
        SeimininkasRepository seimininkasRepository = new SeimininkasRepository();
        public ActionResult Index()
        {
            return View(gyvunasRepository.getGyvunai());
        }

        public ActionResult Create()
        {
            GyvunasEditViewModel gyvunas = new GyvunasEditViewModel();
            PopulateSelections(gyvunas);
            return View(gyvunas);
        }

        [HttpPost]
        public ActionResult Create(GyvunasEditViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    gyvunasRepository.addGyvunas(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        public ActionResult Edit(string cipsas)
        {
            GyvunasEditViewModel gyvunas = gyvunasRepository.getGyvunas(cipsas);
            PopulateSelections(gyvunas);
            return View(gyvunas);
        }

        [HttpPost]
        public ActionResult Edit(string cipsas, GyvunasEditViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    gyvunasRepository.updateGyvunas(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        public ActionResult Delete(string cipsas)
        {
            GyvunasEditViewModel gyvunas = gyvunasRepository.getGyvunas(cipsas);
            return View(gyvunas);
        }

        [HttpPost]
        public ActionResult Delete(string cipsas, FormCollection collection)
        {
            try
            {
                GyvunasEditViewModel gyvunas = gyvunasRepository.getGyvunas(cipsas);
                bool naudojama = false;

                if (gyvunasRepository.getGyvunasCount(cipsas) > 0)
                {
                    naudojama = true;
                    ViewBag.naudojama = "Negalima pašalinti gyvūno, jam yra priskirtas vizitas.";
                    return View(gyvunas);
                }

                if (!naudojama)
                {
                    gyvunasRepository.deleteGyvunas(cipsas);
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void PopulateSelections(GyvunasEditViewModel gyvunas)
        {
            var seimininkai = seimininkasRepository.getSeimininkai();
            List<SelectListItem> selectListseimininkai = new List<SelectListItem>();

            foreach (var item in seimininkai)
            {
                selectListseimininkai.Add(new SelectListItem() { Value = Convert.ToString(item.kodas), Text = item.vardas + " " + item.pavarde });
            }

            gyvunas.SeimininkoList = selectListseimininkai;
        }

    }
}