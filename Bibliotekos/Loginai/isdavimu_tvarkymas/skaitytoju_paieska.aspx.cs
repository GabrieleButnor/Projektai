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
    public partial class skaitytoju_paieska : System.Web.UI.Page
    {
        List<skaitytojas> skaitytojai_list;
        List<skaitytojas> skaitytojai_list_keistas;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            skaitytojai_list = new List<skaitytojas>();

            string urlAddress = "https://carpartshop.net/Laboras/skaitytojai.php";
            string json = null;

            using (WebClient client = new WebClient())
            {
                string pagesource = client.DownloadString(urlAddress);
                json = pagesource;
            }
            skaitytojai_list = JsonConvert.DeserializeObject<List<skaitytojas>>(json);

            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            if (!IsPostBack)
            {
                foreach (skaitytojas item in skaitytojai_list)
                {
                    row = new TableRow();
                    cell = new TableCell(); cell.Text = item.skaitytojo_nr; row.Cells.Add(cell);
                    cell = new TableCell(); cell.Text = item.vardas; row.Cells.Add(cell);
                    cell = new TableCell(); cell.Text = item.pavarde; row.Cells.Add(cell);
                    cell = new TableCell(); cell.Text = item.el_pastas; row.Cells.Add(cell);
                    cell = new TableCell(); cell.Text = item.telefono_nr; row.Cells.Add(cell);
                    cell = new TableCell(); cell.Text = item.gimimo_data; row.Cells.Add(cell);

                    skaitytojai.Rows.Add(row);
                }
            }
        }

        protected void i_ieskoti_Click(object sender, EventArgs e)
        {
            if (vardo_laukas.Text == "" && pavardes_laukas.Text == "")
            {
                Response.Redirect("skaitytoju_paieska.aspx");
            }
            else
            {
                skaitytojai_list_keistas = new List<skaitytojas>();

                string urlAddress1 = "https://carpartshop.net/Laboras/skaitytojai_atrinkimas.php";

                string json = null;

                using (WebClient client = new WebClient())
                {
                    var pagesource = client.UploadValues(urlAddress1, new System.Collections.Specialized.NameValueCollection() {
                            { "vardas", vardo_laukas.Text  }, { "pavarde", pavardes_laukas.Text } });
                    json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                }
                skaitytojai_list_keistas = JsonConvert.DeserializeObject<List<skaitytojas>>(json);

                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                if (skaitytojai_list_keistas[0].skaitytojo_nr != "")
                {
                    foreach (skaitytojas item in skaitytojai_list_keistas)
                    {
                        row = new TableRow();
                        cell = new TableCell(); cell.Text = item.skaitytojo_nr; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = item.vardas; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = item.pavarde; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = item.el_pastas; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = item.telefono_nr; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = item.gimimo_data; row.Cells.Add(cell);

                        skaitytojai.Rows.Add(row);
                    }
                }
            }
        }

        protected void i_pagrindinis_Click(object sender, EventArgs e)
        {
            Response.Redirect("pagrindinis.aspx");
        }

        protected void i_isdavimas_Click(object sender, EventArgs e)
        {
            Response.Redirect("knygos_isdavimas.aspx");
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