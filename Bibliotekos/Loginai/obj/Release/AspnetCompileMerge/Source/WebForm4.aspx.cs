using MySql.Data.MySqlClient;
using System;

namespace Loginai
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        string tekstas = "";
        string id = "";
        bool wasLoaded = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!wasLoaded)
            {
                string ci = "server=carpartshop.net;port=3306;database=retailer;username=carpartshop;password=SomintiKniostaAtgrasinti112";
                MySqlConnection connection = new MySqlConnection(ci);
            connection.Open();

            // string sup_id = "1";

            id = Session["idproduct"].ToString();
            Label1.Text = id;
          //  getImageLink(id);
            string sqr = "SELECT * FROM `ps_product` WHERE `id_product`=" + id;  
            MySqlCommand conPer = new MySqlCommand(sqr, connection);

            MySqlDataReader reader = conPer.ExecuteReader();
            reader.Read();
            string kiekis = reader.GetString(12);
            string kaina = reader.GetString(16);
            connection.Close();
            connection.Open();

            sqr = "SELECT * FROM `ps_product_lang` WHERE `id_product`=" + id;
            conPer = new MySqlCommand(sqr, connection);
            reader = conPer.ExecuteReader();
            reader.Read();
            string pavadinimas = reader.GetString(9);
            string deskriptionas = reader.GetString(3);
            TextBox1.Text = pavadinimas;
            TextBox2.Text = kaina;
            TextBox3.Text = kiekis;
            TextBox4.Text = deskriptionas;
            connection.Close();
            //Image image = new Image();
            //image.ImageUrl = tekstas;
            connection.Open();
             sqr = "SELECT id_image FROM ps_image WHERE id_product = '" + id + "'";
            conPer = new MySqlCommand(sqr, connection);
             reader = conPer.ExecuteReader();
            reader.Read();
            string a = reader.GetString(0);
            char[] yra = a.ToCharArray();
            tekstas = "http://carpartshop.net/img/p/";
            for (int j = 0; j < yra.Length; j++)
            {
                tekstas += yra[j] + "/";
            }
            tekstas += a + "-medium_default.jpg";
            Image1.ImageUrl = tekstas;
            }
            wasLoaded = true;
        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ci = "server=carpartshop.net;port=3306;database=retailer;username=carpartshop;password=SomintiKniostaAtgrasinti112";
            MySqlConnection connection = new MySqlConnection(ci);
            connection.Open();

            



            string sqr = "UPDATE `ps_product` SET  `quantity`='"+TextBox3.Text+"', `price`='"+TextBox2.Text+"' WHERE `id_product`='"+id+"';";
            MySqlCommand conPer = new MySqlCommand(sqr, connection);

            MySqlDataReader reader = conPer.ExecuteReader();
            reader.Read();

            connection.Close();
            string pilnaeilute = "";
            sqr = "UPDATE `ps_product_lang` SET  `description`='" + TextBox4.Text + "', `description_short`='" + TextBox4.Text + "' ,`name`='" + TextBox1.Text + "' WHERE `id_product`='" + id + "';";
            pilnaeilute += " " + sqr;
            sqr = "UPDATE `ps_product_shop` SET  `price`='"+TextBox2.Text+ "' WHERE `id_product`='" + id + "';";
            pilnaeilute += " " + sqr;
            sqr = "UPDATE `ps_stock_available` SET  `quantity`='" + TextBox3.Text + "' WHERE `id_product`='" + id + "';";
            pilnaeilute += " " + sqr;
            conPer = new MySqlCommand(pilnaeilute, connection);
            connection.Open();
            reader = conPer.ExecuteReader();
            reader.Read();
            connection.Close();
            Server.Transfer("WebForm2.aspx");
        }
    }
}