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
    public partial class Dalyviai : System.Web.UI.Page
    {
        List<DALYV> DALYVs;
        string id;
        string json = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            DALYVs = new List<DALYV>();


            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                id = Session["id"].ToString();
            }
            catch
            {
                id = null;
            }
            
            if (id != null)
            {
                string urlAddress = "https://carpartshop.net/Laboras/dalyviai.php";
               
                using (WebClient client = new WebClient())
                {
                    var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() { { "rengID", id } });
                    json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
                }
            }
            if(!string.IsNullOrEmpty(json) && !json.Contains("0 results"))
            {
                DALYVs = JsonConvert.DeserializeObject<List<DALYV>>(json);

                foreach (DALYV item in DALYVs)
                {
                    TableRow row = new TableRow();

                    TableCell cell = new TableCell();
                    cell.Text = item.ID;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = item.RenginioID;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = item.Vardas;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = item.Pavarde;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = item.ElPastas;
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = item.TelNr;
                    row.Cells.Add(cell);


                    TableCell btnCell = new TableCell();

                    Button btn = new Button();
                    btn.Text = "Remove";
                    btn.Click += new EventHandler(BtnEDIT_Click);
                    btn.CommandArgument = item.ID.ToString();

                    btnCell.Controls.Add(btn);

                    row.Cells.Add(btnCell);

                    //cell = new TableCell();
                    //Image image = new Image();
                    //image.ImageUrl = tekstas[k];
                    //cell.Controls.Add(image);
                    //row.Cells.Add(cell);

                    Table1.Rows.Add(row);
                }
            }
            else
            {
                Response.Redirect("~/Renginiai.aspx");
            }
          
        }

        private void BtnEDIT_Click(object sender, EventArgs e)
        {
            
            string urlAddress = "https://carpartshop.net/Laboras/DalDel.php";
            using (WebClient client = new WebClient())
            {
                var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() { { "ID", ((Button)sender).CommandArgument }, });
                string json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
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

        protected void Button3_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm1.aspx");
        }
    }
}