using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunuBuduSistema
{
    public partial class KlientuUzsakymai : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] == null )
            {
                Response.Redirect("Default.aspx");
            }
            GetUzsakymai();
        }

        private void GetUzsakymai()
        {
            var connString = (ConfigurationManager.ConnectionStrings["Duomenu_bazeConnectionString"].ToString());
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string name = Session["Name"].ToString();
            string query = "Select u1.Id, CONVERT(VARCHAR(10),u1.Data,101) as Data, u1.Busena, u1.Kaina, CONVERT(VARCHAR(10),u1.Preliminari_data,101) as Preliminari_data, u1.Kiekis, u1.Medis, u1.SienosMedzioKaina, u1.SpalvosPav, u1.SienosSpalvosKaina, u1.AngosForma, u1.Uzdeng, CONCAT(u1.Ilgis, ' cm ', ' x ',u1.Plotis, ' cm ') as Dydis, u2.Id, u2.StogoMedis, u2.StogoSpalva, u2.StogoMedzioKaina, u2.StogoSpalvosKaina, u2.Kaminas FROM UzsakymaiPilni u1 INNER JOIN UzsakymaiPilni2 u2 ON u2.Klientas = u1.Klientas AND u1.Id = u2.Id where u1.Klientas='" + name + "'";
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            ad.Fill(data);
            Uzsakymai.DataSource = data;
            Uzsakymai.DataBind();
            if (Uzsakymai.Rows.Count == 0)
            {
                Label1.Visible = false;
                Tuscias.Visible = true;
            }
            else
            {
                Label1.Visible = true;
                Tuscias.Visible = false;
            }
            con.Close();
        }
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            Uzsakymai.PageIndex = e.NewPageIndex;
            this.GetUzsakymai();
        }
    }
}