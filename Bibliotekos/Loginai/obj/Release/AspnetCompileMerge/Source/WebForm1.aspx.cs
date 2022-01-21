using System;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Loginai
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Image image = new Image();
            image.ImageUrl = "https://skelbiu.b-cdn.net/1_18_1775159631/automobiliu-dalys-pigiau-auto-dalimis-autodalys.jpg";

            TableRow row = new TableRow();
            TableCell cell = new TableCell();

            cell.Controls.Add(image);
            row.Cells.Add(cell);
            Table1.Rows.Add(row);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ConnectToDataBase(TextBox1.Text, TextBox2.Text);
        }

        void ConnectToDataBase(string name, string pass)
        {
            string ci = "server=carpartshop.net;port=3306;database=retailer;username=carpartshop;password=SomintiKniostaAtgrasinti112";
            MySqlConnection connection = new MySqlConnection(ci);
            connection.Open();

           

            string sqr = "SELECT `uid` FROM `users` WHERE `username`='" + name + "' AND `password`='" + pass + "'";

            MySqlCommand conPer = new MySqlCommand(sqr, connection);

            MySqlDataReader reader = conPer.ExecuteReader();

            reader.Read();

            string data = null;

            try
            {
                data = reader.GetString(0);
                Session["privateKey"] = data;
            }

            catch
            {
                Label3.Visible = true;
            }

            connection.Close();


            if (data != null)
                JumpToProductsPage();

        }

        void JumpToProductsPage()
        {
            TextBox1.Text = "Jums pavyko prisijungti prie duomenu bazes";
            Server.Transfer("WebForm2.aspx");
        }
    }
}