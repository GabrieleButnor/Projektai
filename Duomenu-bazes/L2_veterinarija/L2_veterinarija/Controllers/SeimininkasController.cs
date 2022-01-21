using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L2_veterinarija.Repos;
using L2_veterinarija.Models;

namespace L2_veterinarija.Controllers
{
    public class SeimininkasController : Controller
    {
        SeimininkasRepository seimininkasRepository = new SeimininkasRepository();

        public ActionResult Index()
        {
            return View(seimininkasRepository.getSeimininkai());
        }
        public ActionResult Create()
        {
            Seimininkas seimininkas = new Seimininkas();
            return View(seimininkas);
        }

        [HttpPost]
        public ActionResult Create(Seimininkas collection)
        {
            try
            {
                Seimininkas tmpSeimininkas = seimininkasRepository.getSeimininkas(collection.kodas);
                if (tmpSeimininkas.kodas != null)
                {
                    ModelState.AddModelError("kodas", "Klientas su tokiu asmens kodu jau užregistruotas");
                    return View(collection);
                }
                //Jei nera sukuria nauja klienta
                if (ModelState.IsValid)
                {
                    seimininkasRepository.addSeiminnkas(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        public ActionResult Edit(string kodas)
        {
            return View(seimininkasRepository.getSeimininkas(kodas));
        }

        [HttpPost]
        public ActionResult Edit(string kodas, Seimininkas collection)
        {
            try
            {
                // atnajina markes informacija
                if (ModelState.IsValid)
                {
                    seimininkasRepository.updateSeiminikas(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        public ActionResult Delete(string kodas)
        {
            return View(seimininkasRepository.getSeimininkas(kodas));
        }

        [HttpPost]
        public ActionResult Delete(string kodas, FormCollection collection)
        {
            try
            {
                bool naudojama = false;
                if (seimininkasRepository.getSeimininkasCount(kodas) > 0)
                {
                    naudojama = true;
                    ViewBag.naudojama = "Negalima pašalinti yra priskirtų gyvūnų šiam šeimininkui.";
                    return View(seimininkasRepository.getSeimininkas(kodas));
                }

                if (!naudojama)
                {
                    seimininkasRepository.deleteSeimininas(kodas);
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