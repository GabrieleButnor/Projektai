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
    public partial class knygos_isdavimas : System.Web.UI.Page
    {
        List<_sarasai> skaitytoju_list;
        List<_sarasai> knygu_list;
        List<_sarasai> bibliotekininku_list;
        List<_sarasai> tikrinimas;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            if (!IsPostBack)
                BindDropDownList();
        }

        private void BindDropDownList()
        { 
            // skaitytoju saraso sudarymas
            //----------------------------------------
            string json;
            string urlAddress1 = "https://carpartshop.net/Laboras/visi_skaitytojai.php";


            skaitytoju_list = new List<_sarasai>();

            using (WebClient client = new WebClient())
            {
                string pagesource = client.DownloadString(urlAddress1);
                json = pagesource;
            }

            skaitytoju_list = JsonConvert.DeserializeObject<List<_sarasai>>(json);

            ListItem listItemprad = new ListItem();
            listItemprad.Value = "0";
            listItemprad.Text = "-----------------";

            _skaitytojas.Items.Add(listItemprad);
            foreach (_sarasai pair in skaitytoju_list)
            {
                ListItem listItem = new ListItem();
                listItem.Value = pair.id;
                listItem.Text = pair.reiksme;
                _skaitytojas.Items.Add(listItem);
            }
            //----------------------------------------
            // knygu saraso sudarymas
            //----------------------------------------

            string urlAddress2 = "https://carpartshop.net/Laboras/visi_knygu.php";

            knygu_list = new List<_sarasai>();

            using (WebClient client = new WebClient())
            {
                string pagesource = client.DownloadString(urlAddress2);
                json = pagesource;
            }

            knygu_list = JsonConvert.DeserializeObject<List<_sarasai>>(json);

            _knyga.Items.Add(listItemprad);
            foreach (_sarasai pair in knygu_list)
            {
                ListItem listItem = new ListItem();
                listItem.Value = pair.id;
                listItem.Text = pair.reiksme;
                _knyga.Items.Add(listItem);
            }

            ////----------------------------------------
            //// darbuotju saraso sudarymas
            ////----------------------------------------

            string urlAddress3 = "https://carpartshop.net/Laboras/visi_bibliotek.php";


            bibliotekininku_list = new List<_sarasai>();

            using (WebClient client = new WebClient())
            {
                string pagesource = client.DownloadString(urlAddress3);
                json = pagesource;
            }

            bibliotekininku_list = JsonConvert.DeserializeObject<List<_sarasai>>(json);

            _darbuotojas.Items.Add(listItemprad);
            foreach (_sarasai pair in bibliotekininku_list)
            {
                ListItem listItem = new ListItem();
                listItem.Value = pair.id;
                listItem.Text = pair.reiksme;
                _darbuotojas.Items.Add(listItem);
            }

            ////----------------------------------------
        }

        protected void isduoti_Click(object sender, EventArgs e)
        {
            string json;
            string urlAddress = "https://carpartshop.net/Laboras/isduoti.php";

            Label1.Visible = false;
            Label2.Visible = false;
            if (isdavimo_data.Text == "" || grazinimo_data.Text == "" || filialas.Text == "" || _skaitytojas.SelectedItem.Text == "-----------------" || _knyga.SelectedItem.Text == "-----------------" || _darbuotojas.SelectedItem.Text == "-----------------")
            {
                Label1.Visible = true;
                Label1.Text = "Neužpildyti visi laukai";
            }
            else
            {
                if (isdavimo_data.Text.CompareTo(grazinimo_data.Text) == 1 || isdavimo_data.Text.CompareTo(grazinimo_data.Text) == 0)
                {
                    Label1.Visible = true;
                    Label1.Text = "Neteisingai pasirinkta data";
                }
                else
                {
                    Label1.Visible = false;
                    string urlAddressK = "https://carpartshop.net/Laboras/knygos_tikrinimas.php";


                    using (WebClient client = new WebClient())
                    {
                        var pagesource = client.UploadValues(urlAddressK, new System.Collections.Specialized.NameValueCollection() {
                            { "knygos_kodas",  _knyga.SelectedValue} });
                        json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                    }
                    tikrinimas = new List<_sarasai>();
                    tikrinimas = JsonConvert.DeserializeObject<List<_sarasai>>(json);
                    if (tikrinimas[0].reiksme.CompareTo("0") == 1)
                    {
                        Label2.Visible = true;
                    }
                    else
                    {
                        Label2.Visible = false;
                        using (WebClient client = new WebClient())
                        {
                            var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() {
                                { "isdavimo_data", isdavimo_data.Text }, { "grazinimo_data", grazinimo_data.Text }, { "filialas", filialas.Text },
                                { "fk_skaitytojo_nr", _skaitytojas.SelectedValue.ToString() }, { "fk_knyga", _knyga.SelectedValue.ToString()   }, { "fk_bibliotekininkas", _darbuotojas.SelectedValue.ToString()  } });
                            json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                        }
                        Response.Redirect("pagrindinis.aspx");
                    }
                }
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
    }
}