using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;

namespace Loginai
{
    public partial class AtaskataAdm : System.Web.UI.Page
    {
        List<renginiai> reng;
        List<string> pasisekes;
        List<string> nepasisekes;
        List<string> planuotas;
        protected void Page_Load(object sender, EventArgs e)
        {
            reng = new List<renginiai>();
            pasisekes = new List<string>();
            nepasisekes = new List<string>();
            planuotas = new List<string>();


            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;



            string urlAddress = "https://carpartshop.net/Laboras/renginys.php";
            string json = null;
            using (WebClient client = new WebClient())
            {

                string pagesource = client.DownloadString(urlAddress);
                json = pagesource;
            }

            reng = JsonConvert.DeserializeObject<List<renginiai>>(json);

            foreach (renginiai item in reng)
            {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.Text = item.ID;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Tipas;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.SukData;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.RengData;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Vieta;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.PAvadinimas;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.DalyviuSk;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Laikas;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = item.Aprasas;
                row.Cells.Add(cell);

                cell = new TableCell();
                if(DateTime.Parse(item.RengData) < DateTime.Now)
                {
                    cell.Text = "Pasibaiges";
                    row.Cells.Add(cell);
                }
                if (DateTime.Parse(item.RengData) == DateTime.Now)
                {
                    cell.Text = "Vyksta";
                    row.Cells.Add(cell);
                }
                if (DateTime.Parse(item.RengData) > DateTime.Now)
                {
                    cell.Text = "Busimas";
                    row.Cells.Add(cell);
                }

                cell = new TableCell();
                if (int.Parse(item.DalyviuSk) <= 20)
                {
                    cell.Text = "Nepasisekes mažai dalyvių";
                    row.Cells.Add(cell);
                    nepasisekes.Add(item.PAvadinimas);
                }
                if (int.Parse(item.DalyviuSk)  > 20 && int.Parse(item.DalyviuSk) <= 50)
                {
                    cell.Text = "Kaip ir buvo planuota";
                    row.Cells.Add(cell);
                    planuotas.Add(item.PAvadinimas);
                }
                if (int.Parse(item.DalyviuSk) > 50)
                {
                    cell.Text = "Pasisekes";
                    row.Cells.Add(cell);
                    pasisekes.Add(item.PAvadinimas);
                }


                Table1.Rows.Add(row);
            }


            foreach (var item in pasisekes)
            {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.Text = item;
                row.Cells.Add(cell);
                Table2.Rows.Add(row);
            }
            foreach (var item in planuotas)
            {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.Text = item;
                row.Cells.Add(cell);
                Table3.Rows.Add(row);
            }
            foreach (var item in nepasisekes)
            {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
                cell.Text = item;
                row.Cells.Add(cell);
                Table4.Rows.Add(row);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Renginiai.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RengKur.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/RengDalReg.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Register.aspx");
        }

        protected void Button3_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm1.aspx");
        }
    }
}