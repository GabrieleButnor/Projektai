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
    public partial class knygos_pratesimas : System.Web.UI.Page
    {
        List<isdavimas> redaguojamas_isdavimas;
        List<_sarasai> bibliotekininku_list;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            if (!IsPostBack)
                BindDropDownList();

          
            Label1.Visible = false;

            redaguojamas_isdavimas = new List<isdavimas>();
            string urlAddress = "https://carpartshop.net/Laboras/gauti_isdavima.php";
            string json;

            using (WebClient client = new WebClient())
            {
                var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() {
                            { "isdavimas_id",  Session["isdavimas_id"].ToString()} });
                json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            }

            redaguojamas_isdavimas = JsonConvert.DeserializeObject<List<isdavimas>>(json);

            if (redaguojamas_isdavimas[0] != null && !IsPostBack)
            {                
                isdavimo_data.Text = redaguojamas_isdavimas[0].isdavimo_data;
                grazinimo_data.Text = redaguojamas_isdavimas[0].grazinimo_data;
                filialas.Text = redaguojamas_isdavimas[0].filialas;
                busena.Text = redaguojamas_isdavimas[0].busena;
                _skaitytojas.Text = redaguojamas_isdavimas[0].fk_skaitytojas;
                _knyga.Text = redaguojamas_isdavimas[0].fk_knyga;
                _darbuotojas.SelectedValue = redaguojamas_isdavimas[0].fk_bibliotekininkas;
            }
            else
            {
                Label1.Text = "Klaida gaunant išdavimą.";
                Label1.Visible = true;
            }

        }

        private void BindDropDownList()
        {
            string urlAddress3 = "https://carpartshop.net/Laboras/visi_bibliotek.php";

            string json = null;

            bibliotekininku_list = new List<_sarasai>();

            using (WebClient client = new WebClient())
            {
                string pagesource = client.DownloadString(urlAddress3);
                json = pagesource;
            }

            bibliotekininku_list = JsonConvert.DeserializeObject<List<_sarasai>>(json);

            foreach (_sarasai pair in bibliotekininku_list)
            {
                ListItem listItem = new ListItem();
                listItem.Value = pair.id;
                listItem.Text = pair.reiksme;
                _darbuotojas.Items.Add(listItem);
            }

        }

        protected void pratesti_Click(object sender, EventArgs e)
        {
            string json;
            string urlAddress = "https://carpartshop.net/Laboras/pratesti.php";


            if (isdavimo_data.Text.CompareTo(grazinimo_data.Text) == 1 || isdavimo_data.Text.CompareTo(grazinimo_data.Text) == 0)
            {
                Label1.Visible = true;
                Label1.Text = "Neteisingai pasirinkta data";
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = grazinimo_data.Text;
                using (WebClient client = new WebClient())
                {
                    var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() {
                                { "isdavimas_id", Session["isdavimas_id"].ToString() }, {"grazinimo_data", grazinimo_data.Text }, {"fk_bibliotekininkas", _darbuotojas.SelectedValue.ToString()  } });
                    json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                }
                Response.Redirect("pagrindinis.aspx");
            }
        }

        protected void i_pagrindinis_Click(object sender, EventArgs e)
        {
            Response.Redirect("pagrindinis.aspx");
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

        protected void i_isdavimas_Click(object sender, EventArgs e)
        {
            Response.Redirect("knygos_isdavimas.aspx");
        }
    }
}