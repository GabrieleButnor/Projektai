using System;
using System.Net;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Loginai
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
           

            //TableRow row = new TableRow();
            //TableCell cell = new TableCell();

            //cell.Controls.Add(image);
            //row.Cells.Add(cell);
            //Table1.Rows.Add(row);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ConnectToDataBase(TextBox1.Text, TextBox2.Text);
        }

        void ConnectToDataBase(string name, string pass)
        {

            string url = "https://carpartshop.net/Laboras/Priminimas.php";
            using (WebClient client = new WebClient())
            {

                string pagesource = client.DownloadString(url);
            }

            string urlAddress = "https://carpartshop.net/Laboras/login.php?usr=" + name+"&pwd="+pass;
            string json = null;
            using (WebClient client = new WebClient())
            {

                string pagesource = client.DownloadString(urlAddress);
                json = pagesource;
            }
            string[] info = json.Split(';');
            if(info[1] == "Administrator")
            {
                JumpToProductsPage();
            }
            if (info[1] == "Renginiu org")
            {
                JumpToProductsPage1();
            }
            if (info[1] == "Bibliotekininkas")
            {
                JumpToProductsPage2();
            }
            if (info[1] == "Padejejas")
            {
                JumpToProductsPage3();
            }
        }

        void JumpToProductsPage()
        {
            TextBox1.Text = "Jums pavyko prisijungti prie duomenu bazes";
            Server.Transfer("administravimas/main.aspx");
        }
        void JumpToProductsPage1()
        {
            TextBox1.Text = "Jums pavyko prisijungti prie duomenu bazes";
            Server.Transfer("Renginiai.aspx");
        }
        void JumpToProductsPage2()
        {
            TextBox1.Text = "Jums pavyko prisijungti prie duomenu bazes";
            Server.Transfer("isdavimu_tvarkymas/pagrindinis.aspx");
        }
        void JumpToProductsPage3()
        {
            TextBox1.Text = "Jums pavyko prisijungti prie duomenu bazes";
            Server.Transfer("knygu_tvarkymas/main.aspx");
        }
    }
}