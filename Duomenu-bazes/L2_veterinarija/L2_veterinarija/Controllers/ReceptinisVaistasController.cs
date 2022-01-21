using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L2_veterinarija.Repos;
using L2_veterinarija.ViewModels;

namespace L2_veterinarija.Controllers 
{
    public class ReceptinisVaistasController : Controller
    {
        ReceptinisVaistasRepository vaistasRepository = new ReceptinisVaistasRepository();
        VizitasRepository vizitasRepository = new VizitasRepository();

        public ActionResult Index()
        {
            return View(vaistasRepository.getVaistai());
        }

        public ActionResult Create()
        {
            ReceptinisVaistasEditViewModel vaistas = new ReceptinisVaistasEditViewModel();
            PopulateSelections(vaistas);
            return View(vaistas);
        }

        [HttpPost]
        public ActionResult Create(ReceptinisVaistasEditViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    vaistasRepository.addVaistas(collection);
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
            ReceptinisVaistasEditViewModel vaistas = vaistasRepository.getVaistas(kodas);
            PopulateSelections(vaistas);
            return View(vaistas);
        }


        [HttpPost]
        public ActionResult Edit(string kodas, ReceptinisVaistasEditViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    vaistasRepository.updateVaistas(collection);
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
            ReceptinisVaistasEditViewModel vaistas = vaistasRepository.getVaistas(kodas);
            return View(vaistas);
        }

        [HttpPost]
        public ActionResult Delete(string kodas, FormCollection collection)
        {
            try
            {
                vaistasRepository.deleteVaistas(kodas);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void PopulateSelections(ReceptinisVaistasEditViewModel vaistas)
        {
            var vizitai = vizitasRepository.getVizitai();
            List<SelectListItem> selectListvizitai = new List<SelectListItem>();

            foreach (var item in vizitai)
            {
                selectListvizitai.Add(new SelectListItem() { Value = Convert.ToString(item.numeris), Text = item.numeris.ToString() });
            }

            vaistas.VizitasList = selectListvizitai;

        }
    }
}