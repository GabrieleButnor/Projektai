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
    public partial class cancelOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            uzsakymas item = (uzsakymas) (Session["cancelOrder"]);
            TableRow row = new TableRow();

            TableCell cell = new TableCell();
            cell.Text = item.uzsakymo_id;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = item.data;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = item.pavadinimas;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = item.autorius;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = item.leidimas;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = item.tiekejas;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = item.kiekis;
            row.Cells.Add(cell);

            cell = new TableCell();
            cell.Text = item.vnt_kaina;
            row.Cells.Add(cell);

            Table1.Rows.Add(row);
        }

        protected void Button1_Click(object sender, EventArgs e) {
            if (Session["cancelOrder"] != null) {
                string urlAddress = "https://carpartshop.net/Laboras/cancel_order.php";
                uzsakymas b = (uzsakymas) (Session["cancelOrder"]);
                var id = b.uzsakymo_id;
                using(WebClient client = new WebClient()) {
                    var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() { { "uzsakymo_id", id } });
                    var json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                }
            }
            Response.Redirect("~/administravimas/main.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e) {
            Session["cancelOrder"] = null;
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