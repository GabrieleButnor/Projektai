using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loginai.knygu_tvarkymas
{
    public partial class add : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
                Consts consts = new Consts();
                foreach (KeyValuePair<int, string> pair in consts.genres)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = pair.Key.ToString();
                    listItem.Text = pair.Value;
                    _zanras.Items.Add(listItem);
                }

                foreach (KeyValuePair<int, string> pair in consts.quality)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = pair.Key.ToString();
                    listItem.Text = pair.Value;
                    _busena.Items.Add(listItem);
                }
            if(Session["book"] != null)
            {
                book b = (book)(Session["book"]);
                _zanras.SelectedValue = b.zanras;
                _busena.SelectedValue = b.busena;
                pavadinimas.Text = b.pavadinimas;
                autorius.Text = b.autorius;
                isleidimo_data.Text = b.isleidimo_data;
                leidejas.Text = b.leidejas;
                puslapiu_sk.Text = b.puslapiu_sk;
                komentaras.Text = b.komentaras;
                add_book.Text = "Atnaujinti";
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected void add_book_Click(object sender, EventArgs e)
        {
            string json;
            string urlAddress = "https://carpartshop.net/Laboras/add_book.php";
            string number = "-1";
            if (Session["book"] != null)
            {
                urlAddress = "https://carpartshop.net/Laboras/upd_book.php";
                book b = (book)(Session["book"]);
                number = b.numeris;
            }
            using (WebClient client = new WebClient())
            {
                var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() {
                    { "numeris", number }, { "pavadinimas", pavadinimas.Text }, { "autorius", autorius.Text }, { "isleidimo_data", isleidimo_data.Text },
                    { "leidejas", leidejas.Text }, { "zanras", _zanras.Text }, { "busena", _busena.Text },
                    { "puslapiu_sk", puslapiu_sk.Text }, { "komentaras", komentaras.Text } });
                json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            }
            Response.Redirect("main.aspx");
        }

        protected void m_books_Click1(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
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