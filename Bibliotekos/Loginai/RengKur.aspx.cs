using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loginai
{
    public partial class RengKur : System.Web.UI.Page
    {
        string id;
        renginiai item;
        protected void Page_Init(object sender, EventArgs e)
        {
            item = (renginiai)(Session["rengItem"]);
            if (item != null)
            {
                id = item.ID;
                TextBox1.Text = item.Tipas;
                TextBox2.Text = item.RengData;
                TextBox3.Text = item.Vieta;
                TextBox4.Text = item.PAvadinimas;
                TextBox5.Text = item.Laikas;
                TextBox6.Text = item.Aprasas;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;         
            //try
            //{
            //    upd = "t";
            //    //string tipas = Session["tipas"].ToString();
            //    //string data = Session["data"].ToString();
            //    //string vieta = Session["vieta"].ToString();
            //    //string pavadinimas = Session["pavadinimas"].ToString();
            //    //string laikas = Session["laikas"].ToString();
            //    //string aprasas = Session["aprasas"].ToString();
            //    //string id = Session["id"].ToString();

                
               
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Server.Transfer("Renginiai.aspx");
            Response.Redirect("~/Renginiai.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Server.Transfer("RengKur.aspx");
            Response.Redirect("~/RengKur.aspx");
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            //Server.Transfer("WebForm1.aspx");
            Response.Redirect("~/WebForm1.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //Server.Transfer("RengDalReg.aspx");
            Response.Redirect("~/RengDalReg.aspx");
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {
            if (item == null)
            {
                string json = null;

                string urlAddress = "https://carpartshop.net/Laboras/RengReg.php";
                using (WebClient client = new WebClient())
                {
                    var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() { { "type", TextBox1.Text }, { "data", TextBox2.Text }, { "vieta", TextBox3.Text }, { "pav", TextBox4.Text }, { "time", TextBox5.Text }, { "info", TextBox6.Text } });
                    json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                }
            }
            else
            {
                string json = null;

                string urlAddress = "https://carpartshop.net/Laboras/RengEdit.php";
                using (WebClient client = new WebClient())
                {
                    var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() { { "type", TextBox1.Text }, { "data", TextBox2.Text }, { "vieta", TextBox3.Text }, { "pav", TextBox4.Text }, { "time", TextBox5.Text }, { "info", TextBox6.Text }, { "id", id } });
                    json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                }
            }
            Response.Redirect("~/Renginiai.aspx");
        }
    }
}