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
    public partial class knygu_paieska : System.Web.UI.Page
    {
        knygu_tvarkymas.Consts consts = new knygu_tvarkymas.Consts();
        List<knygu_tvarkymas.book> list_of_books;
        List<knygu_tvarkymas.book> list_of_books_keistas;

        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            list_of_books = new List<knygu_tvarkymas.book>();
            string urlAddress = "https://carpartshop.net/Laboras/get_list_of_books.php";

            string json = null;
            using (WebClient client = new WebClient())
            {
                var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() { { "genre", "0" } });
                json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            }
            list_of_books = JsonConvert.DeserializeObject<List<knygu_tvarkymas.book>>(json);
            if (json != "0 results[]" && !IsPostBack)
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell(); cell.Text = "ID"; row.Cells.Add(cell);                

                foreach (knygu_tvarkymas.book item in list_of_books)
                {
                    row = new TableRow();
                    cell = new TableCell(); cell.Text = item.numeris; row.Cells.Add(cell);
                    cell = new TableCell(); cell.Text = item.pavadinimas; row.Cells.Add(cell);
                    cell = new TableCell(); cell.Text = item.autorius; row.Cells.Add(cell);
                    cell = new TableCell(); cell.Text = item.isleidimo_data; row.Cells.Add(cell);
                    cell = new TableCell(); cell.Text = item.leidejas; row.Cells.Add(cell);
                    cell = new TableCell(); cell.Text = consts.genres[int.Parse(item.zanras)]; row.Cells.Add(cell);
                    cell = new TableCell(); cell.Text = consts.quality[int.Parse(item.busena)]; row.Cells.Add(cell);
                    cell = new TableCell(); cell.Text = item.puslapiu_sk; row.Cells.Add(cell);
                    cell = new TableCell(); cell.Text = item.komentaras; row.Cells.Add(cell);

                    knygos.Rows.Add(row);
                }
            }
        }

        protected void i_ieskoti_Click(object sender, EventArgs e)
        {
            if (pavadinimo_laukas.Text == "")
            {
                Response.Redirect("knygu_paieska.aspx");
            }
            else
            {
                list_of_books_keistas = new List<knygu_tvarkymas.book>();

                string urlAddress1 = "https://carpartshop.net/Laboras/knygu_atrinkimas.php";

                string json = null;

                using (WebClient client = new WebClient())
                {
                    var pagesource = client.UploadValues(urlAddress1, new System.Collections.Specialized.NameValueCollection() {
                            { "pavadinimas", pavadinimo_laukas.Text  } });
                    json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                }
                list_of_books_keistas = JsonConvert.DeserializeObject<List<knygu_tvarkymas.book>>(json);

                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                if (list_of_books_keistas[0].numeris != "")
                {
                    foreach (knygu_tvarkymas.book item in list_of_books_keistas)
                    {
                        row = new TableRow();
                        cell = new TableCell(); cell.Text = item.numeris; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = item.pavadinimas; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = item.autorius; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = item.isleidimo_data; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = item.leidejas; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = consts.genres[int.Parse(item.zanras)]; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = consts.quality[int.Parse(item.busena)]; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = item.puslapiu_sk; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = item.komentaras; row.Cells.Add(cell);
                        knygos.Rows.Add(row);
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

        protected void i_skaitytojai_Click(object sender, EventArgs e)
        {
            Response.Redirect("skaitytoju_paieska.aspx");
        }

        protected void i_apdovanojimai_Click(object sender, EventArgs e)
        {
            Response.Redirect("apdovanojimai.aspx");
        }


    }
}