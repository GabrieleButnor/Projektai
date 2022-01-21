using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunuBuduSistema
{
    public partial class AdminPridejimas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            bool tikrinimas = Tikrinimas1();
            Klaida2.Visible = false;
            Klaida3.Visible = false;
            Klaida4.Visible = false;
            if(tikrinimas == false)
            {
                Klaida1.Text = "Ne visi laukai užpildyti!";
                Klaida1.ForeColor = System.Drawing.Color.Red;
                Klaida1.Visible = true;
            }
            else
            {
                var spalvaAdapter = new DataSetTableAdapters.SpalvosTableAdapter();
                var spalvos = spalvaAdapter.GetData();

                Klaida1.Visible = false;

                var random = new Random();
                int numeris = 0;
                numeris = random.Next(10000, 99999);
                string pavadinimas = spalva_pavadinimas_box.Text;
                double kaina = 0;
                double zmogvalandes = 0;
                bool klaida = false;
                try
                {
                    kaina = Convert.ToDouble(spalva_kaina_box.Text);
                    zmogvalandes = Convert.ToDouble(spalva_zmogvalandes_box.Text);
                }
                catch(Exception ex)
                {
                    Klaida1.Text = "Ne visų laukų duomenų formatai teisingi!";
                    Klaida1.ForeColor = System.Drawing.Color.Red;
                    Klaida1.Visible = true;
                    klaida = true;
                }
                if(klaida == false)
                {
                    bool duplicate = false;
                    foreach(var item in spalvos)
                    {
                        if(item.Pavadinimas == pavadinimas)
                        {
                            duplicate = true;
                        }
                    }
                    if(duplicate == false)
                    {
                        spalvaAdapter.Insert(numeris.ToString(), pavadinimas, kaina, zmogvalandes);
                        Klaida1.Visible = true;
                        Klaida1.ForeColor = System.Drawing.Color.Green;
                        Klaida1.Text = "Duomenų pridėjimas sėkmingas.";
                        spalva_pavadinimas_box.Text = "";
                        spalva_kaina_box.Text = "";
                        spalva_zmogvalandes_box.Text = "";
                    }
                    else
                    {
                        Klaida1.Visible = true;
                        Klaida1.ForeColor = System.Drawing.Color.Red;
                        Klaida1.Text = "Spalva tokiu pavadinimu jau egzistuoja!";
                    }
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            bool tikrinimas = Tikrinimas2();
            Klaida1.Visible = false;
            Klaida3.Visible = false;
            Klaida4.Visible = false;
            if (tikrinimas == false)
            {
                Klaida2.Text = "Ne visi laukai užpildyti!";
                Klaida2.ForeColor = System.Drawing.Color.Red;
                Klaida2.Visible = true;
            }
            else
            {
                var medisAdapter = new DataSetTableAdapters.MedziaiTableAdapter();
                var medziai = medisAdapter.GetData();

                Klaida2.Visible = false;

                var random = new Random();
                int numeris = 0;
                numeris = random.Next(100, 999);
                string pavadinimas = medis_pavadinimas_box.Text;
                double kaina = 0;
                double zmogvalandes = 0;
                bool klaida = false;
                try
                {
                    kaina = Convert.ToDouble(medis_kaina_box.Text);
                    zmogvalandes = Convert.ToDouble(medis_zmogvalandes_box.Text);
                }
                catch (Exception ex)
                {
                    Klaida2.Text = "Ne visų laukų duomenų formatai teisingi!";
                    Klaida2.ForeColor = System.Drawing.Color.Red;
                    Klaida2.Visible = true;
                    klaida = true;
                }
                if (klaida == false)
                {
                    bool duplicate = false;
                    foreach (var item in medziai)
                    {
                        if (item.Tipas == pavadinimas)
                        {
                            duplicate = true;
                        }
                    }
                    if(duplicate == false)
                    {
                        medisAdapter.Insert(numeris.ToString(), pavadinimas, kaina, zmogvalandes);
                        Klaida2.Visible = true;
                        Klaida2.ForeColor = System.Drawing.Color.Green;
                        Klaida2.Text = "Duomenų pridėjimas sėkmingas.";
                        medis_pavadinimas_box.Text = "";
                        medis_kaina_box.Text = "";
                        medis_zmogvalandes_box.Text = "";
                    }
                    else
                    {
                        Klaida2.Visible = true;
                        Klaida2.ForeColor = System.Drawing.Color.Red;
                        Klaida2.Text = "Medžio tipas tokiu pavadinimu jau egzistuoja!";
                    }
                }
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            bool tikrinimas = Tikrinimas3();
            Klaida1.Visible = false;
            Klaida2.Visible = false;
            Klaida4.Visible = false;
            if (tikrinimas == false)
            {
                Klaida3.Text = "Ne visi laukai užpildyti!";
                Klaida3.ForeColor = System.Drawing.Color.Red;
                Klaida3.Visible = true;
            }
            else
            {
                var angosAdapter = new DataSetTableAdapters.AngosTableAdapter();
                var angos = angosAdapter.GetData();

                Klaida3.Visible = false;

                var random = new Random();
                int numeris = 0;
                numeris = random.Next(1000, 1099);
                string pavadinimas = angos_pavadinimas_box.Text;
                double kaina = 0;
                double zmogvalandes = 0;
                bool klaida = false;
                try
                {
                    kaina = Convert.ToDouble(angos_kaina_box.Text);
                    zmogvalandes = Convert.ToDouble(angos_zmogvalandes_box.Text);
                }
                catch (Exception ex)
                {
                    Klaida3.Text = "Ne visų laukų duomenų formatai teisingi!";
                    Klaida3.ForeColor = System.Drawing.Color.Red;
                    Klaida3.Visible = true;
                    klaida = true;
                }
                if (klaida == false)
                {
                    bool duplicate = false;
                    foreach (var item in angos)
                    {
                        if (item.Forma == pavadinimas)
                        {
                            duplicate = true;
                        }
                    }
                    if(duplicate == false)
                    {
                        angosAdapter.Insert(numeris.ToString(), pavadinimas, kaina, zmogvalandes);
                        Klaida3.Visible = true;
                        Klaida3.ForeColor = System.Drawing.Color.Green;
                        Klaida3.Text = "Duomenų pridėjimas sėkmingas.";
                        angos_pavadinimas_box.Text = "";
                        angos_kaina_box.Text = "";
                        angos_zmogvalandes_box.Text = "";
                    }
                    else
                    {
                        Klaida3.Visible = true;
                        Klaida3.ForeColor = System.Drawing.Color.Red;
                        Klaida3.Text = "Angos forma tokiu pavadinimu jau egzistuoja!";
                    }
                }
            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            bool tikrinimas = Tikrinimas4();
            Klaida1.Visible = false;
            Klaida2.Visible = false;
            Klaida3.Visible = false;
            if (tikrinimas == false)
            {
                Klaida4.Text = "Ne visi laukai užpildyti!";
                Klaida4.ForeColor = System.Drawing.Color.Red;
                Klaida4.Visible = true;
            }
            else
            {
                var dydziaiAdapter = new DataSetTableAdapters.DydziaiTableAdapter();
                var dydziai = dydziaiAdapter.GetData();

                Klaida4.Visible = false;

                var random = new Random();
                int numeris = 0;
                numeris = random.Next(100, 399);
                string pavadinimas = dydziai_pavadinimas_box.Text;
                double ilgis = 0;
                double plotis = 0;
                double kaina = 0;
                double zmogvalandes = 0;
                bool klaida = false;
                try
                {
                    ilgis = Convert.ToDouble(dydziai_ilgis_box.Text);
                    plotis = Convert.ToDouble(dydziai_plotis_box.Text);
                    kaina = Convert.ToDouble(dydziai_kaina_box.Text);
                    zmogvalandes = Convert.ToDouble(dydziai_zmogvalandes_box.Text);
                }
                catch (Exception ex)
                {
                    Klaida4.Text = "Ne visų laukų duomenų formatai teisingi!";
                    Klaida4.ForeColor = System.Drawing.Color.Red;
                    Klaida4.Visible = true;
                    klaida = true;
                }
                if (klaida == false)
                {
                    bool duplicate = false;
                    foreach (var item in dydziai)
                    {
                        if (item.Pavadinimas == pavadinimas)
                        {
                            duplicate = true;
                        }
                    }
                    if(duplicate == false)
                    {
                        dydziaiAdapter.Insert(numeris.ToString(), pavadinimas, ilgis, plotis, kaina, zmogvalandes);
                        Klaida4.Visible = true;
                        Klaida4.ForeColor = System.Drawing.Color.Green;
                        Klaida4.Text = "Duomenų pridėjimas sėkmingas.";
                        dydziai_pavadinimas_box.Text = "";
                        dydziai_ilgis_box.Text = "";
                        dydziai_plotis_box.Text = "";
                        dydziai_kaina_box.Text = "";
                        dydziai_zmogvalandes_box.Text = "";
                    }
                    else
                    {
                        Klaida4.Visible = true;
                        Klaida4.ForeColor = System.Drawing.Color.Red;
                        Klaida4.Text = "Būdos dydis tokiu pavadinimu jau egzistuoja!";
                    }
                }
            }
        }
        private bool Tikrinimas1()
        {
            bool tikrinimas = true;
            if (spalva_pavadinimas_box.Text == "" ||
                spalva_kaina_box.Text == "" ||
                spalva_zmogvalandes_box.Text == ""
                )
            {
                tikrinimas = false;
            }
            return tikrinimas;
        }
        private bool Tikrinimas2()
        {
            bool tikrinimas = true;
            if (medis_pavadinimas_box.Text == "" ||
                medis_kaina_box.Text == "" ||
                medis_zmogvalandes_box.Text == ""
                )
            {
                tikrinimas = false;
            }
            return tikrinimas;
        }
        private bool Tikrinimas3()
        {
            bool tikrinimas = true;
            if (angos_pavadinimas_box.Text == "" ||
                angos_kaina_box.Text == "" ||
                angos_zmogvalandes_box.Text == ""
                )
            {
                tikrinimas = false;
            }
            return tikrinimas;
        }
        private bool Tikrinimas4()
        {
            bool tikrinimas = true;
            if (dydziai_pavadinimas_box.Text == "" ||
                dydziai_ilgis_box.Text == "" ||
                dydziai_plotis_box.Text == "" ||
                dydziai_kaina_box.Text == "" ||
                dydziai_zmogvalandes_box.Text == ""
                )
            {
                tikrinimas = false;
            }
            return tikrinimas;
        }
    }
}