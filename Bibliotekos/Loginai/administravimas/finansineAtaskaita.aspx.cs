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
    class FinansineAtaskaita { 
        public string darbuotoju_islaidos;
        public string administratoriams_islaidos;
        public string reng_organizatoriu_islaidos;
        public string bibliotekininkams_islaidos;
        public string uzsakymu_islaidos;
        public string darbuotoju_ir_uzsakymu_islaidos;

        public FinansineAtaskaita(string darbuotoju_islaidos, string administratoriams_islaidos, string reng_organizatoriu_islaidos, string bibliotekininkams_islaidos, string uzsakymu_islaidos, string darbuotoju_ir_uzsakymu_islaidos) {
            this.darbuotoju_islaidos = darbuotoju_islaidos;
            this.administratoriams_islaidos = administratoriams_islaidos;
            this.reng_organizatoriu_islaidos = reng_organizatoriu_islaidos;
            this.bibliotekininkams_islaidos = bibliotekininkams_islaidos;
            this.uzsakymu_islaidos = uzsakymu_islaidos;
            this.darbuotoju_ir_uzsakymu_islaidos = darbuotoju_ir_uzsakymu_islaidos;
        }
    }

    public partial class finansineAtaskaita : System.Web.UI.Page {

        List<FinansineAtaskaita> fin;
        protected void Page_Load(object sender, EventArgs e) {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string urlAddress = "https://carpartshop.net/Laboras/finansineAtaskaita.php";
            string json = null;
            using(WebClient client = new WebClient()) {
                string pagesource = client.DownloadString(urlAddress);
                json = pagesource;
            }
            fin = JsonConvert.DeserializeObject<List<FinansineAtaskaita>>(json);
            foreach(var item in fin) {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.Text = item.darbuotoju_islaidos;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.administratoriams_islaidos;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.reng_organizatoriu_islaidos;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.bibliotekininkams_islaidos;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.uzsakymu_islaidos;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.darbuotoju_ir_uzsakymu_islaidos;
                row.Cells.Add(cell);

                Table1.Rows.Add(row);
            }
        }

        protected void Button1_Click(object sender, EventArgs e) {
            Response.Redirect("~/administravimas/main.aspx");
        }
    }
}