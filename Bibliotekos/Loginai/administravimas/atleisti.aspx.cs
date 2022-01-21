using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loginai.administravimas
{
    public partial class atleisti : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Preke item = (Preke) (Session["delUser"]);
            TableRow row = new TableRow();

            TableCell cell = new TableCell();
            cell.Text = item.ID;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = item.Vardas;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = item.Pavarde;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = item.Data;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = item.Pastas;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = item.Numeris;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = item.Ardesas;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = item.Pareigos;
            row.Cells.Add(cell);

            Table1.Rows.Add(row);
        }

        protected void Button1_Click(object sender, EventArgs e) {
            if (Session["delUser"] != null) {
                string urlAddress = "https://carpartshop.net/Laboras/delete_user.php";
                Preke b = (Preke) (Session["delUser"]);
                var id = b.ID;
                using(WebClient client = new WebClient()) {
                    var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() { { "id", id } });
                    var json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                }
            }
            Response.Redirect("~/administravimas/main.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e) {
            Session["delUser"] = null;
            Response.Redirect("~/administravimas/main.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("~/Register.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e) {
            Server.Transfer("~/Register.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e) {
            Server.Transfer("~/Register.aspx");
        }

        protected void Button9_Click(object sender, EventArgs e) {
            Server.Transfer("~/Register.aspx");
        }

        protected void Button10_Click(object sender, EventArgs e) {
            Server.Transfer("~/Register.aspx");
        }

        protected void Button11_Click(object sender, EventArgs e) {
            Server.Transfer("~/Register.aspx");
        }

        protected void Button12_Click(object sender, EventArgs e) {
            Server.Transfer("~/Register.aspx");
        }

        protected void Button13_Click(object sender, EventArgs e) {
            Server.Transfer("~/Register.aspx");
        }
    }
}