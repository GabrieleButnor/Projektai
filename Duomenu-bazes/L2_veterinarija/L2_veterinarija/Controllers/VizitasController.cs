using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L2_veterinarija.Repos;
using L2_veterinarija.ViewModels;
using L2_veterinarija.Models;

namespace L2_veterinarija.Controllers
{
    public class VizitasController : Controller
    {
        VizitasRepository vizitasRepository = new VizitasRepository();
        SeimininkasRepository seiminikasRepository = new SeimininkasRepository();
        GyvunasRepository gyvunasRepository = new GyvunasRepository();
        GydytojasRepository gydytojasRepository = new GydytojasRepository();
        ItraukimasRepository itraukimasRepository = new ItraukimasRepository();
        PaslaugaRepository paslaugaRepository = new PaslaugaRepository();
        PriskyrimasRepository priskyrimasRepository = new PriskyrimasRepository();
        PrekeRepository prekeRepository = new PrekeRepository();


        public ActionResult Index()
        {
            return View(vizitasRepository.getVizitai());
        }

        public ActionResult Create()
        {
            VizitasEditViewModel vizitas = new VizitasEditViewModel();
            PopulateSelections(vizitas);
            return View(vizitas);
        }


        [HttpPost]
        public ActionResult Create(VizitasEditViewModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vizitasRepository.addVizitas(collection);

                    if (collection.paslaugos != null)
                    {
                        foreach (var item in collection.paslaugos)
                        {
                            if (item.fk_priskirtavizitui == 0)
                            {
                                item.fk_paslauga = Convert.ToString(item.fk_paslauga);
                                item.fk_priskirtavizitui = collection.numeris;
                            }
                        }

                        foreach (var item in collection.paslaugos)
                        {
                            itraukimasRepository.insertItraukimai(item);
                        }
                    }

                    if (collection.prekes != null)
                    {
                        foreach (var item in collection.prekes)
                        {
                            if (item.fk_pridetavizitui == 0)
                            {
                                item.fk_preke = Convert.ToString(item.fk_preke); // fk_key elemente išsaugotas paslaugos id iki _ simbolio
                               // var ticks = item.fk_key.Substring(item.fk_key.IndexOf('_') + 1, item.fk_key.Length - (item.fk_key.IndexOf('_') + 1));
                                item.vienetai = Convert.ToInt32(item.vienetai);
                                item.fk_pridetavizitui = collection.numeris; // nustatomas sutarties nr
                            }
                        }

                        //kiekviena uzsakyta paslauga isaugojama duomenu bazeje
                        foreach (var item in collection.prekes)
                        {
                            priskyrimasRepository.insertPriskyrimas(item);
                        }
                    }
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
            VizitasEditViewModel vizitas = vizitasRepository.getVizitas(numeris);
            PopulateSelections(vizitas);
            List<Itraukimas> paslaugos = new List<Itraukimas>();
            List<Priskyrimas> prekes = new List<Priskyrimas>();
            paslaugos.Add(new Itraukimas());
            prekes.Add(new Priskyrimas());
            ViewBag.paslaugos = paslaugos;
            ViewBag.prekes = prekes;

            return View(vizitas);
        }


        [HttpPost]
        public ActionResult Edit(int numeris, VizitasEditViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    vizitasRepository.updateVizitas(collection);

                    if (collection.paslaugos != null)
                    {

                        foreach (var item in collection.paslaugos)
                        {
                            if (item.fk_priskirtavizitui == 0)
                            {
                                item.fk_paslauga = Convert.ToString(item.fk_paslauga);
                                item.fk_priskirtavizitui = collection.numeris;
                            }
                        }


                        itraukimasRepository.deleteItraukimas(collection.numeris);

                        foreach (var item in collection.paslaugos)
                        {
                            itraukimasRepository.insertItraukimai(item);
                        }
                    }
                    else
                    {
                        itraukimasRepository.deleteItraukimas(collection.numeris);
                    }

                    if (collection.prekes != null)
                    {

                        foreach (var item in collection.prekes)
                        {
                            if (item.fk_pridetavizitui == 0)
                            {
                                item.fk_preke = Convert.ToString(item.fk_preke);
                                item.vienetai = Convert.ToInt32(item.vienetai);
                                item.fk_pridetavizitui = collection.numeris;
                            }
                        }

                        priskyrimasRepository.deletePryskyrimas(collection.numeris);

                        foreach (var item in collection.prekes)
                        {
                            priskyrimasRepository.insertPriskyrimas(item);
                        }
                    }
                    else
                    {
                        priskyrimasRepository.deletePryskyrimas(collection.numeris);
                    }

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
            VizitasEditViewModel vizitas = vizitasRepository.getVizitas(numeris);
            return View(vizitas);
        }

        [HttpPost]
        public ActionResult Delete(int numeris, FormCollection collection)
        {
            try
            {
                VizitasEditViewModel vizitas = vizitasRepository.getVizitas(numeris);
                if (vizitas.busena == "užregistruota" || vizitas.busena == "įvygdyta")
                {
                    ViewBag.naudojama = "Vizitas yra užregistruotas arba įvygdytas, pašalinti negalima.";
                    return View(vizitas);
                }
                else
                {
                    itraukimasRepository.deleteItraukimas(numeris);
                    priskyrimasRepository.deletePryskyrimas(numeris);
                    vizitasRepository.deleteSutartis(numeris);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public void PopulateSelections(VizitasEditViewModel vizitas)
        {
            var gyvunai = gyvunasRepository.getGyvunai();
            var seimininkai = seiminikasRepository.getSeimininkai();
            var gydytojai = gydytojasRepository.getGydytojai();


            List<SelectListItem> selectListGyvunai = new List<SelectListItem>();
            List<SelectListItem> selectListGydytojai = new List<SelectListItem>();



            foreach (var item in gydytojai)
            {
                selectListGydytojai.Add(new SelectListItem { Value = Convert.ToString(item.darbuotojokodas), Text = item.vardas + "  " + item.pavarde  });
            }

            vizitas.GydytojaiList = selectListGydytojai;


            vizitas.prekes = priskyrimasRepository.getPriskyrimai(vizitas.numeris);



            for (int i = 0; i < vizitas.prekes.Count; i++)
            {
                vizitas.prekes[i].fk_key = vizitas.prekes[i].fk_preke;
            }

            List<SelectListItem> selectListItems1 = new List<SelectListItem>();

            var prekes = prekeRepository.getPrekes();

            List<PrekeEditViewModel> prekesViewModel = new List<PrekeEditViewModel>();

            foreach (var item in prekes)
            {
                prekesViewModel.Add(new PrekeEditViewModel { preke = item });
            }


            foreach (var item in prekesViewModel)
            {
                selectListItems1.Add(new SelectListItem { Value = Convert.ToString(item.preke.kodas), Text = item.preke.pavadinimas + "  " + item.preke.kaina + "  Eur" });
            }

            vizitas.PrekesList = selectListItems1;


            //******************************************************************************************


            vizitas.paslaugos = itraukimasRepository.getItraukimus(vizitas.numeris);


            for (int i = 0; i < vizitas.paslaugos.Count; i++)
            {
                vizitas.paslaugos[i].fk_key = vizitas.paslaugos[i].fk_paslauga;
            }

            List<SelectListItem> selectListItems2 = new List<SelectListItem>();

            var paslaugos = paslaugaRepository.getPaslaugos();

            List<PaslaugaEditViewModel> paslaugosViewModel = new List<PaslaugaEditViewModel>();

            foreach (var item in paslaugos)
            {
                paslaugosViewModel.Add(new PaslaugaEditViewModel { paslauga = item });
            }


            foreach (var item in paslaugosViewModel)
            {
                selectListItems2.Add(new SelectListItem { Value = Convert.ToString(item.paslauga.paslaugoskodas), Text = item.paslauga.tipas + "  " + item.paslauga.kaina + "  Eur" });
            }

            vizitas.PaslaugosList = selectListItems2;



            //******************************************************************************************


            List<SelectListItem> selectListItems = new List<SelectListItem>();
            List<SelectListGroup> groups = new List<SelectListGroup>();

            var seimininkas = seiminikasRepository.getSeimininkai();

            List<SeimininkasEditViewModel> seimininkasViewModel = new List<SeimininkasEditViewModel>();


            foreach (var item in seimininkas)
            {
                seimininkasViewModel.Add(new SeimininkasEditViewModel { seimininkas = item, gyvunas = gyvunasRepository.getGyvunas2(item.kodas) });
            }

            foreach (var item in seimininkasViewModel)
            {
                bool yra = false;
                foreach (var i in groups)
                {
                    if (i.Name.Equals(item.seimininkas.pavarde + " " + item.seimininkas.vardas))
                    {
                        yra = true;
                    }
                }
                if (!yra)
                {
                    groups.Add(new SelectListGroup() { Name = item.seimininkas.pavarde + " " + item.seimininkas.vardas });
                }
            }

            foreach (var x in seimininkasViewModel)
            {
                foreach (var item in x.gyvunas)
                {
                    var optGroup = new SelectListGroup() { Name = "--------" };
                    foreach (var i in groups)
                    {
                        if (i.Name.Equals(x.seimininkas.pavarde + " " + x.seimininkas.vardas))
                        {
                            optGroup = i;
                        }
                    }

                    selectListItems.Add(
                        new SelectListItem()
                        {
                            Value = Convert.ToString(item.cipsas),
                            Text = item.vardas + "     " + item.rusis,
                            Group = optGroup
                        }
                        );
                }
            }

            vizitas.GyvunaiList = selectListItems;


        }


    }
}