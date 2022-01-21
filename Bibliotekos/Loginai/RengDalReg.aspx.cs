using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loginai
{
    public partial class RengDalReg : System.Web.UI.Page
    {
        List<RENG> RENG;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string json = null;

            string urlAddress = "https://carpartshop.net/Laboras/GetReng.php";
            using (WebClient client = new WebClient())
            {

                string pagesource = client.DownloadString(urlAddress);
                json = pagesource;
            }

            RENG = JsonConvert.DeserializeObject<List<RENG>>(json);
            int i = 0;
            foreach (var z in RENG)
            {
                
                DropDownList1.Items.Insert(i,z.Pavadinimas);

                i++;
            }
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Server.Transfer("Renginiai.aspx");
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            string z;
            int i = 0;
            foreach (var item in RENG)
            {
                if (DropDownList1.SelectedIndex == i)
                    z = item.ID;
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("RengKur.aspx");
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            Server.Transfer("WebForm1.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Server.Transfer("RengDalReg.aspx");
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {
            string z="";
            int i = 0;
            foreach (var item in RENG)
            {
                if(item.Pavadinimas.Contains(DropDownList1.SelectedItem.Text))
                z = item.ID;
            }

            string json = null;

            string urlAddress = "https://carpartshop.net/Laboras/RengRegDal.php";
            using (WebClient client = new WebClient())
            {
                var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() { { "rid", z }, { "var", TextBox2.Text }, { "pav", TextBox3.Text }, { "elp", TextBox4.Text }, { "tel", TextBox1.Text }, });
                json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            }
        }
    }
}