using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loginai.knygu_tvarkymas
{
    public partial class main : System.Web.UI.Page
    {
        Consts consts = new Consts();
        List<book> list_of_books;
        protected void Page_Init(object sender, EventArgs e)
        {
            foreach (KeyValuePair<int, string> pair in consts.genres)
            {
                ListItem listItem = new ListItem();
                listItem.Value = pair.Key.ToString();
                listItem.Text = pair.Value;
                filtrai.Items.Add(listItem);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            refresh_list_of_books(int.Parse(filtrai.SelectedValue));
        }
        protected void m_add_Click(object sender, EventArgs e)
        {
            Session["book"] = null;
            Response.Redirect("add.aspx");
        }
        protected void filter_Click(object sender, EventArgs e)
        {
        }

        private void refresh_list_of_books(int filter)
        {
            list_of_books = new List<book>();
            string urlAddress = "https://carpartshop.net/Laboras/get_list_of_books.php";
            string json = null;
            using (WebClient client = new WebClient())
            {
                var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection(){{ "genre", filter.ToString() }});
                json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            }
            books.Rows.Clear();
            if (json != "0 results[]")
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell(); cell.Text = "ID"; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = "Pavadinimas"; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = "Autorius"; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = "Isleidimo data"; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = "Leidejas"; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = "Zanras"; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = "Busena"; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = "Puslapiu sk"; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = "Komentaras"; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = "Istrinti?"; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = "Keisti?"; row.Cells.Add(cell);
                books.Rows.Add(row);

                list_of_books = JsonConvert.DeserializeObject<List<book>>(json);
                foreach (book item in list_of_books)
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

                    cell = new TableCell(); Button button = new Button();
                    button.Text = "Salinti";
                    button.Click += new EventHandler(Btn_Remove_Click);
                    button.ID = "del" + item.numeris;
                    button.CommandArgument = item.numeris;
                    cell.Controls.Add(button);
                    row.Cells.Add(cell);

                    cell = new TableCell(); button = new Button();
                    button.Text = "Keisti";
                    button.Click += new EventHandler(Btn_Edit_Click);
                    button.ID = "edi" + item.numeris;
                    button.CommandArgument = item.numeris;
                    cell.Controls.Add(button);
                    row.Cells.Add(cell);

                    books.Rows.Add(row);
                }
            }
        }

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            //id = ((Button)sender).CommandArgument;
            string urlAddress = "https://carpartshop.net/Laboras/del_book.php";
            using (WebClient client = new WebClient())
            {
                var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() { { "ID", ((Button)sender).CommandArgument }, });
                string json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            }
            refresh_list_of_books(int.Parse(filtrai.SelectedValue));
            //Response.Redirect("main.aspx");
            //Response.Redirect("add.aspx");
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            book bo = null;
            foreach (book b in list_of_books)
            {
                if(b.numeris == ((Button)sender).CommandArgument) bo = b;
            }
            Session["book"] = bo;
            Response.Redirect("add.aspx");
        }

        protected void m_report_a_Click(object sender, EventArgs e)
        {
            Response.Redirect("Report_A.aspx");
        }

        protected void m_report_b_Click(object sender, EventArgs e)
        {
            Response.Redirect("Report_B.aspx");
        }
    }
}