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
    public partial class Renginiai : System.Web.UI.Page
    {
        List<renginiai> reng;
        protected void Page_Load(object sender, EventArgs e)
        {
            reng = new List<renginiai>();


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


                //cell = new TableCell();
                //Image image = new Image();
                //image.ImageUrl = tekstas[k];
                //cell.Controls.Add(image);
                //row.Cells.Add(cell);

                TableCell btnCell = new TableCell();

                Button btn = new Button();
                btn.Text = "Remove";
                btn.Click += new EventHandler(BtnEDIT_Click);
                btn.ID = "edi" + item.ID;
                btn.CommandArgument = item.ID.ToString();
                btnCell.Controls.Add(btn);
                row.Cells.Add(btnCell);




                TableCell btnCell1 = new TableCell();

                Button btn1 = new Button();
                btn1.Text = "Edit";
                btn1.Click += new EventHandler(Btnedit_Click);
                btn1.CommandArgument = item.ID.ToString();

                btnCell1.Controls.Add(btn1);

                TableCell btnCell2 = new TableCell();

                Button btn2 = new Button();
                btn2.Text = "Dalyviai";
                btn2.Click += new EventHandler(Btndalyviai_Click);
                btn2.CommandArgument = item.ID.ToString();

                btnCell2.Controls.Add(btn2);

                row.Cells.Add(btnCell);
                row.Cells.Add(btnCell1);
                row.Cells.Add(btnCell2);

                Table1.Rows.Add(row);
            }
        }

        private void Btndalyviai_Click(object sender, EventArgs e)
        {
            Session["id"] = ((Button)sender).CommandArgument;
            Server.Transfer("Dalyviai.aspx");
            //string urlAddress = "https://carpartshop.net/Laboras/RengDel.php";
            //using (WebClient client = new WebClient())
            //{
            //    var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() { { "ID", ((Button)sender).CommandArgument }, });
            //    string json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            //}
        }

        private void Btnedit_Click(object sender, EventArgs e)
        {
            foreach (var item in reng)
            {
                if(((Button)sender).CommandArgument == item.ID)
                {
                    //Session["tipas"] = item.Tipas.ToString();
                    //Session["data"] = item.RengData.ToString();
                    //Session["vieta"] = item.Vieta.ToString();
                    //Session["pavadinimas"] = item.PAvadinimas.ToString();
                    //Session["laikas"] = item.Laikas.ToString();
                    //Session["aprasas"] = item.Aprasas.ToString();
                    //Session["id"] = item.ID.ToString();

                    Session["rengItem"] = item;
                    Response.Redirect("~/RengKur.aspx");
                }
            }
            
            
            
        }

        private void BtnEDIT_Click(object sender, EventArgs e)//remove
        {
            string urlAddress = "https://carpartshop.net/Laboras/RengDel.php";
            
            foreach (var a in reng)
            {
                if (a.ID == ((Button)sender).CommandArgument)
                {
                    using (WebClient client = new WebClient())
                    {
                        var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() { { "ID", a.ID }, });
                    }
                }
            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Server.Transfer("Renginiai.aspx");
            Response.Redirect("~/Renginiai.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Server.Transfer("RengKur.aspx");
            Session["rengItem"] = null;
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

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AtaskataAdm.aspx");
        }
    }
}