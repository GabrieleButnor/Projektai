using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace Loginai
{
    public partial class WebForm2 : System.Web.UI.Page
    {

               



        protected void Page_Load(object sender, EventArgs e)
        {


        }
        void BtnEDIT_Click(object sender, EventArgs e)
        {
            var ar = ((Button)sender).CommandArgument;
            Session["idproduct"] = ar.ToString();
            Server.Transfer("WebForm4.aspx");

        }
        protected void Button1_Click(object sender, EventArgs e)
        {


            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("KnyguReg.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("Darbuotojai.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Server.Transfer("WebForm2.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Server.Transfer("AtaskataAdm.aspx");
        }
    }
}