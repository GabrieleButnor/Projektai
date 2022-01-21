using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L2_veterinarija.Repos;
using L2_veterinarija.Models;


namespace L2_veterinarija.Controllers
{
    public class PaslaugaController : Controller
    {
        PaslaugaRepository paslaugaRepository = new PaslaugaRepository();

        public ActionResult Index()
        {
            return View(paslaugaRepository.getPaslaugos());
        }

        public ActionResult Create()
        {
            Paslauga paslauga = new Paslauga();
            return View(paslauga);
        }

        [HttpPost]
        public ActionResult Create(Paslauga collection)
        {
            try
            {
                // išsaugo nauja markę duomenų bazėje
                if (ModelState.IsValid)
                {
                    paslaugaRepository.addPaslauga(collection);
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
            return View(paslaugaRepository.getPaslauga(kodas));
        }

        [HttpPost]
        public ActionResult Edit(string kodas, Paslauga collection)
        {
            try
            {
                // atnajina markes informacija
                if (ModelState.IsValid)
                {
                    paslaugaRepository.updatePaslauga(collection);
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
            return View(paslaugaRepository.getPaslauga(kodas));
        }

        [HttpPost]
        public ActionResult Delete(string kodas, FormCollection collection)
        {
            try
            {
                bool naudojama = false;
                if (paslaugaRepository.getPaslaugaCount(kodas) > 0)
                {
                    naudojama = true;
                    ViewBag.naudojama = "Negalima pašalinti paslaugos, kadangi ji priskirta vizitams.";
                    return View(paslaugaRepository.getPaslauga(kodas));
                }

                if (!naudojama)
                {
                    paslaugaRepository.deletePaslauga(kodas);
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