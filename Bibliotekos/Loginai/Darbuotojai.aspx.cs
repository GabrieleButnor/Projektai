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
    public partial class Darbuotojai : System.Web.UI.Page
    {
        List<Preke> darb;
        protected void Page_Load(object sender, EventArgs e)
        {

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            darb = new List<Preke>();

            string urlAddress = "https://carpartshop.net/Laboras/darbuotojai.php";
            string json = null;
            using (WebClient client = new WebClient())
            {

                string pagesource = client.DownloadString(urlAddress);
                json = pagesource;
            }

            darb = JsonConvert.DeserializeObject<List<Preke>>(json);

            foreach (var item in darb)
            {
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
                //cell = new TableCell();
                //Image image = new Image();
                //image.ImageUrl = tekstas[k];
                //cell.Controls.Add(image);
                //row.Cells.Add(cell);

                //TableCell btnCell = new TableCell();

                //Button btn = new Button();
                //btn.Text = "Edit";
                //btn.Click += new EventHandler(BtnEDIT_Click);
                //btn.CommandArgument = id[k].ToString();

                //btnCell.Controls.Add(btn);

                //row.Cells.Add(btnCell);

                Table1.Rows.Add(row);
            }
            //for (int k = 0; k < darb.Count; k++)
            //{
            //    TableRow row = new TableRow();

            //    TableCell cell = new TableCell();

            //    cell.Text = name[k];
            //    row.Cells.Add(cell);

            //    cell = new TableCell();
            //    cell.Text = price[k];
            //    row.Cells.Add(cell);

            //    cell = new TableCell();
            //    cell.Text = quantity[k];
            //    row.Cells.Add(cell);

            //    cell = new TableCell();
            //    cell.Text = description[k];
            //    row.Cells.Add(cell);

            //    cell = new TableCell();
            //    Image image = new Image();
            //    image.ImageUrl = tekstas[k];
            //    cell.Controls.Add(image);
            //    row.Cells.Add(cell);

            //    TableCell btnCell = new TableCell();

            //    Button btn = new Button();
            //    btn.Text = "Edit";
            //    btn.Click += new EventHandler(BtnEDIT_Click);
            //    btn.CommandArgument = id[k].ToString();

            //    btnCell.Controls.Add(btn);

            //    row.Cells.Add(btnCell);

            //    Table1.Rows.Add(row);



            //}

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

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebForm2.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Server.Transfer("Register.aspx");
        }
    }
}