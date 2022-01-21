using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loginai
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e) {
            if(Session["user"] != null) {
                Preke b = (Preke) Session["user"];
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox4.Text = b.Vardas;
                TextBox5.Text = b.Pavarde;
                TextBox6.Text = b.Data;
                TextBox7.Text = b.Pastas;
                TextBox8.Text = b.Numeris;
                TextBox9.Text = b.Ardesas;
                DropDownList1.SelectedValue = b.Pareigos;
                Button6.Text = "Atnaujinti";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Server.Transfer("Renginiai.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("Darbuotojai.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("KnyguReg.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Server.Transfer("AtaskaitaAdm.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string json = null;
            string urlAddress;
            if(Session["user"] != null) {
                urlAddress = "https://carpartshop.net/Laboras/update_user.php";
                Preke b = (Preke) (Session["user"]);
                var id = b.ID;
                using(WebClient client = new WebClient()) {
                    var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() { { "id", id }, { "usr", TextBox1.Text }, { "pwd", TextBox2.Text }, { "vard", TextBox4.Text }, { "pav", TextBox5.Text }, { "data", TextBox6.Text }, { "elp", TextBox7.Text }, { "tel", TextBox8.Text }, { "add", TextBox9.Text }, { "type", DropDownList1.SelectedValue.ToString() } });
                    json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                }
            } else {
                urlAddress = "https://carpartshop.net/Laboras/Register.php";
                using(WebClient client = new WebClient()) {
                    var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() { { "usr", TextBox1.Text }, { "pwd", TextBox2.Text }, { "vard", TextBox4.Text }, { "pav", TextBox5.Text }, { "data", TextBox6.Text }, { "elp", TextBox7.Text }, { "tel", TextBox8.Text }, { "add", TextBox9.Text }, { "type", DropDownList1.SelectedValue.ToString() } });
                    json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                }
            }
            Response.Redirect("~/administravimas/main.aspx");
        }
    }
}