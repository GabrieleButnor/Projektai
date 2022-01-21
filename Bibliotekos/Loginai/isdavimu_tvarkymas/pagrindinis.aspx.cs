using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loginai.isdavimu_tvarkymas
{
    public partial class pagrindinis : System.Web.UI.Page
    {
        List<isdavimas> isdavimai_list;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            isdavimai_list = new List<isdavimas>();

            string urlAddress = "https://carpartshop.net/Laboras/isdavimu_sarasas.php";

            string json = null;

            using (WebClient client = new WebClient())
            {
                string pagesource = client.DownloadString(urlAddress);
                json = pagesource;
            }
            isdavimai_list = JsonConvert.DeserializeObject<List<isdavimas>>(json);

            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            foreach (isdavimas item in isdavimai_list)
            {
                row = new TableRow();
                cell = new TableCell(); cell.Text = item.id; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = item.isdavimo_data; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = item.grazinimo_data; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = item.filialas; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = item.busena; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = item.fk_skaitytojas; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = item.fk_knyga; row.Cells.Add(cell);

                cell = new TableCell();
                Button button1 = new Button();
                button1.Text = "Pratęsti";
                button1.Click += new EventHandler(Btn_Extend_Click);
                button1.CommandArgument = item.id;
                cell.Controls.Add(button1);
                row.Cells.Add(cell);

                Button button2 = new Button();
                button2.Text = "Atidavimas";
                button2.Click += new EventHandler(Btn_Return_Click);
                button2.CommandArgument = item.id;
                cell.Controls.Add(button2);
                row.Cells.Add(cell);

                isdavimai.Rows.Add(row);
            }
        }

        private void Btn_Extend_Click(object sender, EventArgs e)
        {
            Session["isdavimas_id"] = (((Button)sender).CommandArgument);
            Response.Redirect("knygos_pratesimas.aspx");
        }

        private void Btn_Return_Click(object sender, EventArgs e)
        {
            string urlAddress = "https://carpartshop.net/Laboras/atiduoti_knyga.php";


            using (WebClient client = new WebClient())
            {
                var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() { { "id", ((Button)sender).CommandArgument }, });
                string json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            }
            Response.Redirect("pagrindinis.aspx");
        }

        protected void i_isdavimas_Click(object sender, EventArgs e)
        {
            Response.Redirect("knygos_isdavimas.aspx");
        }

        protected void i_skaitytojai_Click(object sender, EventArgs e)
        {
            Response.Redirect("skaitytoju_paieska.aspx");
        }

        protected void i_knygos_Click(object sender, EventArgs e)
        {
            Response.Redirect("knygu_paieska.aspx");
        }

        protected void i_apdovanojimai_Click(object sender, EventArgs e)
        {
            Response.Redirect("apdovanojimai.aspx");
        }
    }
}