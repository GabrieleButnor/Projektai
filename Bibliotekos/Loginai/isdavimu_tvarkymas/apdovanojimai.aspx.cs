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
    public partial class apdovanojimai : System.Web.UI.Page
    {
        List<skaitytojas> skaitytoju_list;
        List<string> pastu_list;
        List<apdovanojimas> apdovanojimu_list;
        List<_sarasai> bibliotekininku_list;
        List<_sarasai> atrinkti_skaitytojai;

        DateTime data_dabar = DateTime.Today;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindDropDownList();

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            DateTime data_dabar = DateTime.Today;
            Label1.Text = data_dabar.ToString("yyyy") +" " + data_dabar.ToString("MMMM") +". " + "Mėnesio apdovanojimas.";

            apdovanojimu_list = new List<apdovanojimas>();

            string urlAddress = "https://carpartshop.net/Laboras/apdovanojimai.php";

            string json = null;

            using (WebClient client = new WebClient())
            {
                var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() {
                            { "dabar_data", data_dabar.ToString()  } });
                json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            }
            apdovanojimu_list = JsonConvert.DeserializeObject<List<apdovanojimas>>(json);
            Label3.Visible = false;
            if (apdovanojimu_list[0].id == "")
            {
                Label2.Text = "Šį mėnesį apdovanojimas skaitytojmas dar NĖRA suteiktas.";
                sudarymo_data.Enabled = true;
                pavadinimas.Enabled = true;
                komentaras.Enabled = true;
                _darbuotojas.Enabled = true;
                apdovanoti_skaitytojai.Visible = false;
                generavimas.Visible = true;
                siuntimas.Visible = false;
            }
            else
            {
                Label2.Text = "Šį mėnesį apdovanojimas skaitytojmas YRA suteiktas.";
                apdovanoti_skaitytojai.Visible = true;

                string urlAddress1 = "https://carpartshop.net/Laboras/rezultatai.php";
                

                using (WebClient client = new WebClient())
                {
                    var pagesource = client.UploadValues(urlAddress1, new System.Collections.Specialized.NameValueCollection() {
                            { "id", apdovanojimu_list[0].id  } });
                    json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                }
                skaitytoju_list = JsonConvert.DeserializeObject<List<skaitytojas>>(json);
                foreach (skaitytojas pair in skaitytoju_list)
                {
                    if (skaitytoju_list[0].skaitytojo_nr != "")
                    {
                        TableRow row = new TableRow();
                        TableCell cell = new TableCell();
                        row = new TableRow();
                        cell = new TableCell(); cell.Text = skaitytoju_list[0].skaitytojo_nr; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = skaitytoju_list[0].vardas; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = skaitytoju_list[0].pavarde; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = skaitytoju_list[0].el_pastas; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = skaitytoju_list[0].telefono_nr; row.Cells.Add(cell);
                        cell = new TableCell(); cell.Text = skaitytoju_list[0].gimimo_data; row.Cells.Add(cell);
                        apdovanoti_skaitytojai.Rows.Add(row);
                    }
                }
                if (apdovanojimu_list[0].id != "" && !IsPostBack)
                {
                    sudarymo_data.Text = apdovanojimu_list[0].sudarymo_data;
                    pavadinimas.Text = apdovanojimu_list[0].pavadinimas;
                    komentaras.Text = apdovanojimu_list[0].komentaras;
                    _darbuotojas.SelectedValue = apdovanojimu_list[0].fk_bibliotekininkas;
                }

                siuntimas.Visible = false;
                generavimas.Visible = false;
                sudarymo_data.Enabled = false;
                pavadinimas.Enabled = false;
                komentaras.Enabled = false;
                _darbuotojas.Enabled = false;
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
            ListItem listItemprad = new ListItem();
            listItemprad.Value = "0";
            listItemprad.Text = "-----------------";
            _darbuotojas.Items.Add(listItemprad);
            foreach (_sarasai pair in bibliotekininku_list)
            {
                ListItem listItem = new ListItem();
                listItem.Value = pair.id;
                listItem.Text = pair.reiksme;
                _darbuotojas.Items.Add(listItem);
            }

        }
        protected void generuoti_Click(object sender, EventArgs e)
        {
            string json;
            string urlAddress = "https://carpartshop.net/Laboras/generuoti.php";
            
            Label2.Visible = false;
            if (sudarymo_data.Text == "" || pavadinimas.Text == "" || komentaras.Text == "" || _darbuotojas.SelectedItem.Text == "-----------------")
            {
                Label3.Visible = true;
                Label3.Text = "Neužpildyti visi laukai";
            }
            else
            {
                string part = sudarymo_data.Text.Split('-')[1];
                if (part.CompareTo(data_dabar.ToString("MM")) != 0)
                {
                    Label3.Visible = true;
                    Label3.Text = "Neteisingai pasirinkta apdovanojimo sudarymo datos mėnesis";
                }
                else
                {
                    Label3.Visible = false;
                    skaitytoju_list = new List<skaitytojas>();
                    using (WebClient client = new WebClient())
                    {
                        var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() {
                            { "dabar_data", data_dabar.ToString()  } }); 
                        json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                    }
                    atrinkti_skaitytojai = JsonConvert.DeserializeObject<List<_sarasai>>(json);

                    string urlAddress1 = "https://carpartshop.net/Laboras/atrinkti.php";
                    
                    int kartai = 0;
                    foreach (_sarasai item in atrinkti_skaitytojai)
                    {
                        if(item.reiksme.CompareTo("3") > -1)
                        {
                            using (WebClient client = new WebClient())
                            {
                                var pagesource = client.UploadValues(urlAddress1, new System.Collections.Specialized.NameValueCollection() {
                                 { "kodas",  item.id } });
                                json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                            }
                            skaitytoju_list = JsonConvert.DeserializeObject<List<skaitytojas>>(json);
                            if (skaitytoju_list[0].skaitytojo_nr != "")
                            {
                                TableRow row = new TableRow();
                                TableCell cell = new TableCell();
                                row = new TableRow();
                                cell = new TableCell(); cell.Text = skaitytoju_list[0].skaitytojo_nr; row.Cells.Add(cell);
                                cell = new TableCell(); cell.Text = skaitytoju_list[0].vardas; row.Cells.Add(cell);
                                cell = new TableCell(); cell.Text = skaitytoju_list[0].pavarde; row.Cells.Add(cell);
                                cell = new TableCell(); cell.Text = skaitytoju_list[0].el_pastas; row.Cells.Add(cell);
                                cell = new TableCell(); cell.Text = skaitytoju_list[0].telefono_nr; row.Cells.Add(cell);
                                cell = new TableCell(); cell.Text = skaitytoju_list[0].gimimo_data; row.Cells.Add(cell);
                                apdovanoti_skaitytojai.Rows.Add(row);
                                kartai++;
                            }
                        }
                    }
                    apdovanoti_skaitytojai.Visible = true;
                    if(kartai == 0)
                    {
                        Label3.Visible = true;
                        Label3.Text = "Šį mėnesyį NĖRA skaitytojų gavusių apdovanojimą.";
                        apdovanoti_skaitytojai.Visible = false;
                    }
                    else
                    {
                        siuntimas.Visible = true;
                    }
                }
            }

        }

        protected void siuntimas_Click(object sender, EventArgs e)
        {
            string json;
            string urlAddress = "https://carpartshop.net/Laboras/generuoti.php";
            

            string urlAddress1 = "https://carpartshop.net/Laboras/atrinkti.php";
            

            string urlAddress2 = "https://carpartshop.net/Laboras/issaugoti_apdovanojima.php";
            

            string urlAddress3 = "https://carpartshop.net/Laboras/apdov_skaitytojai.php";
           

            List<string> pastu_list = new List<string>();

            using (WebClient client = new WebClient())
            {
                var pagesource = client.UploadValues(urlAddress2, new System.Collections.Specialized.NameValueCollection() {
                                 { "sudarymo_data",  sudarymo_data.Text}, { "pavadinimas", pavadinimas.Text}, {"komentaras", komentaras.Text}, { "fk_bibliotekininkas", _darbuotojas.SelectedValue.ToString()} });
                json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            }
            apdovanojimu_list = new List<apdovanojimas>();
            apdovanojimu_list = JsonConvert.DeserializeObject<List<apdovanojimas>>(json);

            using (WebClient client = new WebClient())
            {
                var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() {
                            { "dabar_data", data_dabar.ToString()  } });
                json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            }
            atrinkti_skaitytojai = JsonConvert.DeserializeObject<List<_sarasai>>(json);
            foreach (_sarasai item in atrinkti_skaitytojai)
            {
                if (item.reiksme.CompareTo("3") > -1)
                {
                    using (WebClient client = new WebClient())
                    {
                        var pagesource = client.UploadValues(urlAddress1, new System.Collections.Specialized.NameValueCollection() {
                                 { "kodas",  item.id } });
                        json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                    }
                    skaitytoju_list = JsonConvert.DeserializeObject<List<skaitytojas>>(json);
                    if (skaitytoju_list[0].skaitytojo_nr != "")
                    {
                        pastu_list.Add(skaitytoju_list[0].el_pastas);
                        using (WebClient client = new WebClient())
                        {
                            var pagesource = client.UploadValues(urlAddress3, new System.Collections.Specialized.NameValueCollection() {
                                { "apdovanojimo_id", apdovanojimu_list[0].id }, {"skaitytojo_nr", skaitytoju_list[0].skaitytojo_nr  } });
                            json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                        }
                    }
                }
            }
            if(pastu_list.Count() != 0)
            {
                Label4.Visible = true;
                Label4.Text = "Laiškai sėkmingai išsiusti.";
                generavimas.Visible = false;
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

        protected void i_knygos_Click(object sender, EventArgs e)
        {
            Response.Redirect("knygu_paieska.aspx");
        }


    }
}