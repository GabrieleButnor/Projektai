using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L2_veterinarija.Repos;
using L2_veterinarija.Models;

namespace L2_veterinarija.Controllers
{
    public class PrekeController : Controller
    {
        PrekeRepository prekeRepository = new PrekeRepository();
        public ActionResult Index()
        {
            //grazinamas markiu sarašas
            return View(prekeRepository.getPrekes());
        }

        public ActionResult Create()
        {
            Preke preke = new Preke();
            return View(preke);
        }

        [HttpPost]
        public ActionResult Create(Preke collection)
        {
            try
            {
                // išsaugo nauja markę duomenų bazėje
                if (ModelState.IsValid)
                {
                    prekeRepository.addPreke(collection);
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
            return View(prekeRepository.getPreke(kodas));
        }

        [HttpPost]
        public ActionResult Edit(string kodas, Preke collection)
        {
            try
            {
                // atnajina markes informacija
                if (ModelState.IsValid)
                {
                    prekeRepository.updatePreke(collection);
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
            return View(prekeRepository.getPreke(kodas));
        }

        [HttpPost]
        public ActionResult Delete(string kodas, FormCollection collection)
        {
            try
            {
                bool naudojama = false;
                if (prekeRepository.getPrekesCount(kodas) > 0)
                {
                    naudojama = true;
                    ViewBag.naudojama = "Negalima pašalinti prekės ji yra priskirta vizitui.";
                    return View(prekeRepository.getPreke(kodas));
                }

                if (!naudojama)
                {
                    prekeRepository.deletePreke(kodas);
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