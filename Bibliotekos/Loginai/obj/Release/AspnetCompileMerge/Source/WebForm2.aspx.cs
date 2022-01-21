using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace Loginai
{
    public partial class WebForm2 : System.Web.UI.Page
    {


        List<Preke> Prekes = new List<Preke>();






        protected void Page_Load(object sender, EventArgs e)
        {
           
            //string privateKey = null;
            //try
            //{
            //    privateKey = Session["privateKey"].ToString();
            //}
            //catch
            //{
            //    Server.Transfer("WebForm1.aspx");
            //}

            //if (privateKey==null)
            //{
            //    Server.Transfer("WebForm1.aspx");
            //}
            string[] quantity = new string[100];
            string[] price = new string[100];
            string[] id = new string[100];
            string[] description = new string[100];
            string[] name = new string[100];
            string[] tekstas = new string[100];
            int i = 0;

            string ci = "server=carpartshop.net;port=3306;database=retailer;username=carpartshop;password=SomintiKniostaAtgrasinti112; convert zero datetime=True";
            MySqlConnection connection = new MySqlConnection(ci);
            connection.Open();



            string sqr = "SELECT* FROM ps_product WHERE id_supplier = 1 ";
            //string sqr1 = "SELECT * FROM ps_product_lang WHERE id_product = 28";

            MySqlCommand conPer = new MySqlCommand(sqr, connection);

            MySqlDataReader reader = conPer.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);

            connection.Close();
            Console.WriteLine(dt.Rows.Count);
            foreach (DataRow dr in dt.Rows)
            {
                var x = dr["id_product"];
                id[i] = x.ToString();
                x = dr["price"];
                price[i] = x.ToString();
                connection.Open();
                string sqr1 = "SELECT * FROM ps_product_lang WHERE id_product = '" + id[i] + "'";
                conPer = new MySqlCommand(sqr1, connection);

                reader = conPer.ExecuteReader();
                reader.Read();
                description[i] = reader.GetString(4);
                name[i] = reader.GetString(9);
                connection.Close();
                connection.Open();
                sqr1 = "SELECT quantity FROM ps_stock_available WHERE id_product = '" + id[i] + "'";
                conPer = new MySqlCommand(sqr1, connection);

                reader = conPer.ExecuteReader();
                reader.Read();
                quantity[i] = reader.GetString(0);
                connection.Close();
                connection.Open();
                sqr1 = "SELECT id_image FROM ps_image WHERE id_product = '" + id[i] + "'";
                conPer = new MySqlCommand(sqr1, connection);

                reader = conPer.ExecuteReader();
                reader.Read();
                string a = reader.GetString(0);
                char[] yra = a.ToCharArray();
                tekstas[i] = "http://carpartshop.net/img/p/";
                for (int j = 0; j < yra.Length; j++)
                {
                    tekstas[i] += yra[j] + "/";
                }
                tekstas[i] += a + "-small_default.jpg";
                connection.Close();
                i++;
            }


            for (int k = 0;  k < i; k++)
            {
                TableRow row = new TableRow();
                
                TableCell cell = new TableCell();

                cell.Text = name[k];
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = price[k];
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = quantity[k];
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = description[k];
                row.Cells.Add(cell);

                cell = new TableCell();
                Image image = new Image();
                image.ImageUrl = tekstas[k];
                cell.Controls.Add(image);
                row.Cells.Add(cell);

                TableCell btnCell = new TableCell();

                Button btn = new Button();
                btn.Text = "Edit";
                btn.Click += new EventHandler(BtnEDIT_Click);
                btn.CommandArgument = id[k].ToString();
                
                btnCell.Controls.Add(btn);

                row.Cells.Add(btnCell);

                Table1.Rows.Add(row);



            }

        }
        void BtnEDIT_Click(object sender, EventArgs e)
        {
            var ar = ((Button)sender).CommandArgument;
            Session["idproduct"] = ar.ToString();
            Server.Transfer("WebForm4.aspx");

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            //string pavadinimas = TextBox5.Text;
            //string kaina = TextBox1.Text;
            //string kiekis = TextBox2.Text;
            //string apibudinimas = TextBox3.Text;

            //Image image = new Image();
            //image.ImageUrl = "http://carpartshop.net/img/p/2/9/29.jpg";
           

            //TableRow row = new TableRow();

            //TableCell cell = new TableCell();

            //cell.Text = pavadinimas;
            //row.Cells.Add(cell);

            //cell = new TableCell();
            //cell.Text = kaina;
            //row.Cells.Add(cell);

            //cell = new TableCell();
            //cell.Text = kiekis;
            //row.Cells.Add(cell);

            //cell = new TableCell();
            //cell.Text = apibudinimas;
            //row.Cells.Add(cell);

            //cell = new TableCell();
            //cell.Controls.Add(image);
            //row.Cells.Add(cell);

            //Table1.Rows.Add(row);
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebForm3.aspx");
        }


    }
}