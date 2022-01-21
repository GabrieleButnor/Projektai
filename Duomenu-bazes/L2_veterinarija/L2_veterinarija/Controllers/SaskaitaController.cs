using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L2_veterinarija.Repos;
using L2_veterinarija.ViewModels;

namespace L2_veterinarija.Controllers
{
    public class SaskaitaController : Controller
    {
        SaskaitaRepository saskaitaRepository = new SaskaitaRepository();
        VizitasRepository vizitasRepository = new VizitasRepository();

        public ActionResult Index()
        {
            return View(saskaitaRepository.getSaskaitos());
        }

        public ActionResult Create()
        {
            SaskaitaEditViewModel saskaita = new SaskaitaEditViewModel();
            PopulateSelections(saskaita);
            return View(saskaita);
        }

        [HttpPost]
        public ActionResult Create(SaskaitaEditViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    saskaitaRepository.addSaskaita(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }




        public ActionResult Edit(int numeris)
        {
            SaskaitaEditViewModel saskaita = saskaitaRepository.getSaskaita(numeris);
            PopulateSelections(saskaita);
            return View(saskaita);
        }

        [HttpPost]
        public ActionResult Edit(int numeris, SaskaitaEditViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    saskaitaRepository.updateSaskaita(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        public ActionResult Delete(int numeris)
        {
            SaskaitaEditViewModel saskaita = saskaitaRepository.getSaskaita(numeris);
            return View(saskaita);
        }

        [HttpPost]
        public ActionResult Delete(int numeris, FormCollection collection)
        {
            try
            {

                saskaitaRepository.deleteSaskaita(numeris);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void PopulateSelections(SaskaitaEditViewModel saskaita)
        {
            var vizitai = vizitasRepository.getVizitai();
            List<SelectListItem> selectListvizitai = new List<SelectListItem>();

            foreach (var item in vizitai)
            {
                selectListvizitai.Add(new SelectListItem() { Value = Convert.ToString(item.numeris), Text = item.numeris.ToString() });
            }
            saskaita.sVizitasList = selectListvizitai; 
        }
    }
}