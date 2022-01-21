using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Loginai.administravimas {
    class Ataskaita { 
        public string suma;
        public string etato_suma;
        public string neto_etato_suma;

        public Ataskaita(string suma, string etato_suma, string neto_etato_suma) {
            this.suma = suma;
            this.etato_suma = etato_suma;
            this.neto_etato_suma = neto_etato_suma;
        }
    }

    public partial class darbuotojoAtaskaita : System.Web.UI.Page {

        List<Ataskaita> ataskaita;
        protected void Page_Load(object sender, EventArgs e) {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Table2.Visible = false;
            Preke b = (Preke) (Session["darbAtask"]);
            
            TableRow row = new TableRow();

            TableCell cell = new TableCell();
            cell.Text = b.ID;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = b.Vardas;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = b.Pavarde;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = b.Data;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = b.Pastas;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = b.Numeris;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = b.Ardesas;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = b.Pareigos;
            row.Cells.Add(cell);
            Table1.Rows.Add(row);
        }

        protected void Button2_Click(object sender, EventArgs e) {
            string json;

            string urlAddress = "https://carpartshop.net/Laboras/darbuotojoAtaskaita.php";
            Preke b = (Preke) (Session["darbAtask"]);
            var id = b.ID;
            using(WebClient client = new WebClient()) {
                var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() {
                    { "id", id},
                    { "etatas", etatas.Text } });
                json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            }
            ataskaita = JsonConvert.DeserializeObject<List<Ataskaita>>(json);
            foreach(var item in ataskaita) {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.Text = item.suma;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.etato_suma;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.neto_etato_suma;
                row.Cells.Add(cell);

                Table2.Rows.Add(row);
            }
            Table2.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e) {
            Response.Redirect("~/administravimas/main.aspx");
        }
    }
}