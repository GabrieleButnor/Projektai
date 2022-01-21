using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using L2_veterinarija.ViewModels;
using MySql.Data.MySqlClient;

namespace L2_veterinarija.Repos
{
    public class SaskaitaRepository
    {
        public List<SaskaitaViewModel> getSaskaitos()
        {
            List<SaskaitaViewModel> saskaitaViewModels = new List<SaskaitaViewModel>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.numeris, m.data, m.mokejimo_budas, mm.numeris AS svizitas 
                                FROM saskaitos m
                                LEFT JOIN vizitai mm ON mm.numeris=m.fk_israsyta_vizitui";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                saskaitaViewModels.Add(new SaskaitaViewModel
                {
                    numeris = Convert.ToInt32(item["numeris"]),
                    data = Convert.ToDateTime(item["data"]),
                    mokejimobudas = Convert.ToString(item["mokejimo_budas"]),
                    svizitas = Convert.ToInt32(item["svizitas"])
                });
            }

            return saskaitaViewModels;
        }

        public SaskaitaEditViewModel getSaskaita(int numeris)
        {
            SaskaitaEditViewModel saskaita = new SaskaitaEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.* 
                                FROM saskaitos m WHERE m.numeris=" + numeris;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                saskaita.numeris = Convert.ToInt32(item["numeris"]);
                saskaita.data = Convert.ToDateTime(item["data"]);
                saskaita.mokejimobudas = Convert.ToString(item["mokejimo_budas"]);
                saskaita.svizitas = Convert.ToInt32(item["fk_israsyta_vizitui"]);
            }

            return saskaita;
        }


        public bool updateSaskaita(SaskaitaEditViewModel saskaita)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE saskaitos a SET a.data=?data, a.mokejimo_budas=?mokejimobudas, a.fk_israsyta_vizitui=?fk_israsytavizitui WHERE a.numeris=?numeris";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?numeris", MySqlDbType.Int32).Value = saskaita.numeris;
            mySqlCommand.Parameters.Add("?data", MySqlDbType.DateTime).Value = saskaita.data;
            mySqlCommand.Parameters.Add("?mokejimobudas", MySqlDbType.VarChar).Value = saskaita.mokejimobudas;
            mySqlCommand.Parameters.Add("?fk_israsytavizitui", MySqlDbType.Int32).Value = saskaita.svizitas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public bool addSaskaita(SaskaitaEditViewModel saskaita)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO saskaitos(numeris,data,mokejimo_budas,fk_israsyta_vizitui)VALUES(?numeris,?data,?mokejimobudas,?fk_israsytavizitui)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?numeris", MySqlDbType.Int32).Value = saskaita.numeris;
            mySqlCommand.Parameters.Add("?data", MySqlDbType.DateTime).Value = saskaita.data;
            mySqlCommand.Parameters.Add("?mokejimobudas", MySqlDbType.String).Value = saskaita.mokejimobudas;
            mySqlCommand.Parameters.Add("?fk_israsytavizitui", MySqlDbType.Int32).Value = saskaita.svizitas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }


        public void deleteSaskaita(int numeris)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM saskaitos where numeris=?numeris";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?numeris", MySqlDbType.Int32).Value = numeris; 
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}