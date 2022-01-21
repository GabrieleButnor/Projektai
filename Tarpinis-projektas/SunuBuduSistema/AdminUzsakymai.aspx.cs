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
    public partial class AdminUzsakymai : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Name"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                GetUzsakymai();                
            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            Uzsakymai.PageIndex = e.NewPageIndex;
            this.GetUzsakymai();
        }

        protected void Uzsakymai_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Uzsakymai.EditIndex = e.NewEditIndex;
            this.GetUzsakymai();

        }

        protected void Uzsakymai_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList busenos =
                              (DropDownList)e.Row.FindControl("busenos");
                    busenos.DataTextField = "Pavadinimas";
                    busenos.DataSource = Sudarymas();
                    busenos.DataBind();
                    DataRowView dr = e.Row.DataItem as DataRowView;
                }
            }
        }

        protected DataTable Sudarymas()
        {

            string connString = ConfigurationManager.ConnectionStrings["Duomenu_bazeConnectionString"].ConnectionString;
            string sql = @"Select Pavadinimas from Busenos";
            DataTable busenos = new DataTable();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(busenos);
                }
            }
            return busenos;

        }

        protected void Uzsakymai_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Uzsakymai.EditIndex = -1;
            this.GetUzsakymai();
        }


        private void GetUzsakymai()
        {
            var connString = (ConfigurationManager.ConnectionStrings["Duomenu_bazeConnectionString"].ToString());
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string name = Session["Name"].ToString();
            string query = "Select Id, CONVERT(VARCHAR(10),Data,101) as Data, Busena, Kaina, CONVERT(VARCHAR(10),Preliminari_data,101) as Preliminari_data from Uzsakymai";
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();            
            ad.Fill(data);
            Uzsakymai.DataSource = data;
            Uzsakymai.DataBind();
            if (Uzsakymai.Rows.Count == 0)
            {
                Tuscias.Visible = true;
                Label1.Visible = false;
                uzsakymo_id.Visible = false;
                Button.Visible = false;
            }
            else
            {
                Label1.Visible = true;
                uzsakymo_id.Visible = true;
                Button.Visible = true;
                Tuscias.Visible = false;
            }
            con.Close();
        }



        protected void Uzsakymai_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var connString = (ConfigurationManager.ConnectionStrings["Duomenu_bazeConnectionString"].ToString());
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            Label id = Uzsakymai.Rows[e.RowIndex].FindControl("Id") as Label;
            TextBox data = Uzsakymai.Rows[e.RowIndex].FindControl("Data") as TextBox;
            DropDownList busena = (DropDownList)Uzsakymai.Rows[e.RowIndex].FindControl("busenos");
            TextBox kaina = Uzsakymai.Rows[e.RowIndex].FindControl("Kaina") as TextBox;
            TextBox preliminari_data = Uzsakymai.Rows[e.RowIndex].FindControl("Preliminari_data") as TextBox;
            con = new SqlConnection(connString);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Uzsakymai set Busena='" + busena.SelectedValue + "' where Id=" + Convert.ToInt32(id.Text), con);
            cmd.ExecuteNonQuery();
            con.Close();
            Uzsakymai.EditIndex = -1;
            this.GetUzsakymai();
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            var numeris = uzsakymo_id.Text;
            if(numeris == "")
            {
                Klaida.Text = "Užpildykite užsakymo numerio lauką.";
                Klaida.Visible = true;
                Uzsakymas.Visible = false;
                Uzsakymai.Visible = true;
                Iranga.Visible = false;
                Atributai.Visible = false;
            }
            else if (Convert.ToInt32(numeris) <= 0)
            {
                Klaida.Text = "Netinkamai įvestas užsakymo numeris.";
                Klaida.Visible = true;
                Uzsakymas.Visible = false;
                Uzsakymai.Visible = true;
                Iranga.Visible = false;
                Atributai.Visible = false;
            }
            else
            {
                int nr = Convert.ToInt32(uzsakymo_id.Text);
                Uzsakymas.Visible = true;
                Uzsakymai.Visible = false;
                Iranga.Visible = true;
                Atributai.Visible = true;
                GetUzsakymas(nr);
                GetUzsakymasIranga(nr);
                GetUzsakymasAtributu(nr);
            }
        }

        private void GetUzsakymas(int numeris)
        {
            var connString = (ConfigurationManager.ConnectionStrings["Duomenu_bazeConnectionString"].ToString());
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string name = Session["Name"].ToString();
            string query = "Select u1.Id, CONVERT(VARCHAR(10),u1.Data,101) as Data, u1.Klientas, u1.Kaina, u1.Kiekis, u1.SpalvosPav," +
                "u1.Medis, u1.AngosForma, u1.Uzdeng, CONCAT(u1.Ilgis, ' cm ', ' x ',u1.Plotis, ' cm ') as Dydis, u2.StogoMedis, u2.StogoSpalva, " +
                "u2.Kaminas FROM UzsakymaiPilni u1 INNER JOIN UzsakymaiPilni2 u2 ON u2.Klientas = u1.Klientas AND u1.Id = u2.Id WHERE u1.Id=" + numeris;
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            ad.Fill(data);
            Uzsakymas.DataSource = data;
            Uzsakymas.DataBind();
            if (Uzsakymas.Rows.Count == 0)
            {
                Uzsakymai.Visible = true;
                Klaida.Text = "Įvesto užsakymo numerio nėra.";
                Klaida.Visible = true;
            }
            else
            {
                Klaida.Visible = false;
            }
            con.Close();
        }

        private void GetUzsakymasIranga(int numeris)
        {
            var connString = (ConfigurationManager.ConnectionStrings["Duomenu_bazeConnectionString"].ToString());
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string name = Session["Name"].ToString();
            string query = "Select u.Numeris, u.Tipas, u.Kaina, u.Kiekis FROM UzsakymaiIranga u WHERE u.Id=" + numeris;
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            ad.Fill(data);
            Iranga.DataSource = data;
            Iranga.DataBind();
            con.Close();
        }

        private void GetUzsakymasAtributu(int numeris)
        {
            var connString = (ConfigurationManager.ConnectionStrings["Duomenu_bazeConnectionString"].ToString());
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string name = Session["Name"].ToString();
            string query = "Select u.Numeris, u.Tipas, u.Kaina, u.Kiekis, u.Komentaras FROM UzsakymaiAtributai u WHERE u.Id=" + numeris;
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            ad.Fill(data);
            Atributai.DataSource = data;
            Atributai.DataBind();
            con.Close();
        }

    }
}