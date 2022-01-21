using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loginai.administravimas
{
    public partial class Darbuotojai : System.Web.UI.Page
    {
        List<Preke> darb;
        List<uzsakymas> uzs;
        List<DALYV> dal;
        List<isdavimu_tvarkymas.skaitytojas> skaityt;
        protected void Page_Load(object sender, EventArgs e)
        {

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            darb = new List<Preke>();

            string urlAddress = "https://carpartshop.net/Laboras/darbuotojai.php";
            string json = null;
            using (WebClient client = new WebClient())
            {
                string pagesource = client.DownloadString(urlAddress);
                json = pagesource;
            }

            darb = JsonConvert.DeserializeObject<List<Preke>>(json);

            foreach (var item in darb)
            {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.Text = item.ID;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Vardas;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Pavarde;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Data;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Pastas;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Numeris;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Ardesas;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Pareigos;
                row.Cells.Add(cell);

                cell = new TableCell();
                Button button = new Button();
                button.Text = "Atleisti";
                button.Click += new EventHandler(Button11_Click);
                button.ID = "del" + item.ID;
                button.CommandArgument = item.ID;
                cell.Controls.Add(button);
                row.Cells.Add(cell);

                cell = new TableCell();
                button = new Button();
                button.Text = "Redaguoti";
                button.Click += new EventHandler(Btn_Edit_Click);
                button.ID = "edi" + item.ID;
                button.CommandArgument = item.ID;
                cell.Controls.Add(button);
                row.Cells.Add(cell);

                cell = new TableCell();
                button = new Button();
                button.Text = "Ataskaita";
                button.Click += new EventHandler(DarbuotojoAtaskaita);
                button.ID = "atask" + item.ID;
                button.CommandArgument = item.ID;
                cell.Controls.Add(button);
                row.Cells.Add(cell);

                Table1.Rows.Add(row);
            }

            uzs = new List<uzsakymas>();
            urlAddress = "https://carpartshop.net/Laboras/get_orders.php";
            json = null;
            using(WebClient client = new WebClient()) {
                string pagesource = client.DownloadString(urlAddress);
                json = pagesource;
            }

            uzs = JsonConvert.DeserializeObject<List<uzsakymas>>(json);

            foreach(var item in uzs) {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.Text = item.uzsakymo_id;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.data;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.pavadinimas;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.autorius;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.leidimas;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.tiekejas;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.kiekis;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.vnt_kaina;
                row.Cells.Add(cell);

                cell = new TableCell();
                Button button = new Button();
                button.Text = "Atšaukti";
                button.Click += new EventHandler(Button12_Click);
                button.ID = "rem" + item.uzsakymo_id;
                button.CommandArgument = item.uzsakymo_id;
                cell.Controls.Add(button);
                row.Cells.Add(cell);

                Table2.Rows.Add(row);
            }

            dal = new List<DALYV>();
            urlAddress = "https://carpartshop.net/Laboras/get_dalyviai.php";
            json = null;
            using(WebClient client = new WebClient()) {
                string pagesource = client.DownloadString(urlAddress);
                json = pagesource;
            }
            dal = JsonConvert.DeserializeObject<List<DALYV>>(json);

            foreach(var item in dal) {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.Text = item.ID;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.RenginioID;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Vardas;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Pavarde;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.ElPastas;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.TelNr;
                row.Cells.Add(cell);

                cell = new TableCell();
                Button button = new Button();
                button.Text = "Redaguoti";
                button.Click += new EventHandler(Button13_Click);
                button.ID = "dalEdit" + item.ID;
                button.CommandArgument = item.ID;
                cell.Controls.Add(button);
                row.Cells.Add(cell);

                Table3.Rows.Add(row);
            }

            skaityt = new List<isdavimu_tvarkymas.skaitytojas>();
            urlAddress = "https://carpartshop.net/Laboras/skaitytojai.php";
            json = null;
            using(WebClient client = new WebClient()) {
                string pagesource = client.DownloadString(urlAddress);
                json = pagesource;
            }

            skaityt = JsonConvert.DeserializeObject<List<isdavimu_tvarkymas.skaitytojas>>(json);

            foreach(var item in skaityt) {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.Text = item.skaitytojo_nr;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.vardas;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.pavarde;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.el_pastas;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.telefono_nr;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.gimimo_data;
                row.Cells.Add(cell);

                cell = new TableCell();
                Button button = new Button();
                button.Text = "Redaguoti";
                button.Click += new EventHandler(Button14_Click);
                button.ID = "skaitEdit" + item.skaitytojo_nr;
                button.CommandArgument = item.skaitytojo_nr;
                cell.Controls.Add(button);
                row.Cells.Add(cell);

                Table4.Rows.Add(row);
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("~/Register.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e) {
            Response.Redirect("~/administravimas/addOrder.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e) {
            Response.Redirect("~/administravimas/finansineAtaskaita.aspx");
        }

        protected void Button11_Click(object sender, EventArgs e) {
            Preke user = null;
            foreach(var a in darb) {
                if(a.ID == ((Button) sender).CommandArgument) {
                    user = a;
                }
            }
            Session["delUser"] = user;
            Response.Redirect("~/administravimas/atleisti.aspx");
        }

        protected void Button12_Click(object sender, EventArgs e) {
            uzsakymas uzsak = null;
            foreach(var a in uzs) {
                if(a.uzsakymo_id == ((Button) sender).CommandArgument) {
                    uzsak = a;
                }
            }
            Session["cancelOrder"] = uzsak;
            Response.Redirect("~/administravimas/cancelOrder.aspx");
        }

        protected void Button13_Click(object sender, EventArgs e) {
            DALYV dalyvis = null;
            foreach(var a in dal) {
                if(a.ID == ((Button) sender).CommandArgument) {
                    dalyvis = a;
                }
            }
            Session["dalEdit"] = dalyvis;
            Response.Redirect("~/administravimas/editDalyvis.aspx");
        }

        protected void Button14_Click(object sender, EventArgs e) {
            isdavimu_tvarkymas.skaitytojas skait = null;
            foreach(var a in skaityt) {
                if(a.skaitytojo_nr == ((Button) sender).CommandArgument) {
                    skait = a;
                }
            }
            Session["skaitEdit"] = skait;
            Response.Redirect("~/administravimas/editSkaitytojas.aspx");
        }

        private void Btn_Edit_Click(object sender, EventArgs e) {
            Preke user = null;
            foreach(var a in darb) { 
                if(a.ID == ((Button)sender).CommandArgument) { 
                    user = a;
                }
            }
            Session["user"] = user;
            Response.Redirect("~/Register.aspx");
        }

        private void DarbuotojoAtaskaita(object sender, EventArgs e) {
            Preke user = null;
            foreach(var a in darb) {
                if(a.ID == ((Button) sender).CommandArgument) {
                    user = a;
                }
            }
            Session["darbAtask"] = user;
            Response.Redirect("~/administravimas/DarbuotojoAtaskaita.aspx");
        }
    }
}