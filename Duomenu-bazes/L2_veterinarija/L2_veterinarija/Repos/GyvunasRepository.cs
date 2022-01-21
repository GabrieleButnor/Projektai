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
    public class GyvunasRepository
    {

        public List<GyvunasViewModel> getGyvunai()
        {
            List<GyvunasViewModel> gyvunasViewModels = new List<GyvunasViewModel>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.cipsas, m.rusis, m.tipas, m.vardas, m.gimimo_data, m.svoris, mm.pavarde AS seimininkas
                                FROM gyvunai m
                                LEFT JOIN seimininkai mm ON mm.kodas=m.fk_seimininkas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                gyvunasViewModels.Add(new GyvunasViewModel
                {
                    cipsas = Convert.ToString(item["cipsas"]),
                    rusis = Convert.ToString(item["rusis"]),
                    tipas = Convert.ToString(item["tipas"]),
                    vardas = Convert.ToString(item["vardas"]),
                    gimimodata = Convert.ToDateTime(item["gimimo_data"]),
                    svoris = Convert.ToString(item["svoris"]),
                    seimininkas = Convert.ToString(item["seimininkas"]),
                });
            }

            return gyvunasViewModels;
        }

        public GyvunasEditViewModel getGyvunas(string cipsas)
        {
            GyvunasEditViewModel gyvunas = new GyvunasEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.* 
                                FROM gyvunai m WHERE m.cipsas='" + cipsas + "'";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?cipsas", MySqlDbType.VarChar).Value = cipsas;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                gyvunas.cipsas = Convert.ToString(item["cipsas"]);
                gyvunas.rusis = Convert.ToString(item["rusis"]);
                gyvunas.tipas = Convert.ToString(item["tipas"]);
                gyvunas.vardas = Convert.ToString(item["vardas"]);
                gyvunas.gimimodata = Convert.ToDateTime(item["gimimo_data"]);
                gyvunas.svoris = Convert.ToString(item["svoris"]);
                gyvunas.fk_seimininkas = Convert.ToString(item["fk_seimininkas"]);
            }
            return gyvunas;
        }

        public bool updateGyvunas(GyvunasEditViewModel gyvunas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE gyvunai a SET a.rusis=?rusis, a.tipas=?tipas, a.vardas=?vardas, a.gimimo_data=?gimimodata, a.svoris=?svoris, a.fk_seimininkas=?seimininkas WHERE a.cipsas=?cipsas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?cipsas", MySqlDbType.VarChar).Value = gyvunas.cipsas;
            mySqlCommand.Parameters.Add("?rusis", MySqlDbType.VarChar).Value = gyvunas.rusis;
            mySqlCommand.Parameters.Add("?tipas", MySqlDbType.VarChar).Value = gyvunas.tipas;
            mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = gyvunas.vardas;
            mySqlCommand.Parameters.Add("?gimimodata", MySqlDbType.DateTime).Value = gyvunas.gimimodata;
            mySqlCommand.Parameters.Add("?svoris", MySqlDbType.VarChar).Value = gyvunas.svoris;
            mySqlCommand.Parameters.Add("?seimininkas", MySqlDbType.VarChar).Value = gyvunas.fk_seimininkas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }


        public bool addGyvunas(GyvunasEditViewModel gyvunas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO gyvunai(cipsas,rusis,tipas,vardas,gimimo_data,svoris,fk_seimininkas)VALUES(?cipsas,?rusis,?tipas,?vardas,?gimimodata,?svoris,?seimininkas)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?cipsas", MySqlDbType.VarChar).Value = gyvunas.cipsas;
            mySqlCommand.Parameters.Add("?rusis", MySqlDbType.VarChar).Value = gyvunas.rusis;
            mySqlCommand.Parameters.Add("?tipas", MySqlDbType.VarChar).Value = gyvunas.tipas;
            mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = gyvunas.vardas;
            mySqlCommand.Parameters.Add("?gimimodata", MySqlDbType.DateTime).Value = gyvunas.gimimodata;
            mySqlCommand.Parameters.Add("?svoris", MySqlDbType.VarChar).Value = gyvunas.svoris;
            mySqlCommand.Parameters.Add("?seimininkas", MySqlDbType.VarChar).Value = gyvunas.fk_seimininkas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }
        
        public int getGyvunasCount(string cipsas)
        {
            int naudota = 0;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT count(numeris) as kiekis from vizitai where fk_gyvunas='" + cipsas + "'";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                naudota = Convert.ToInt32(item["kiekis"] == DBNull.Value ? 0 : item["kiekis"]);
            }
            return naudota;
        }
        
        public void deleteGyvunas(string cipsas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM gyvunai where cipsas=?cipsas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?cipsas", MySqlDbType.VarChar).Value = cipsas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }


        public List<GyvunasViewModel> getGyvunas2(string kodas)
        {
            List<GyvunasViewModel> gyvunas = new List<GyvunasViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT k.fk_seimininkas, k.cipsas, k.rusis, k.tipas, k.vardas, k.gimimo_data, k.svoris
                                       FROM gyvunai as k where k.fk_seimininkas=" + kodas;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                gyvunas.Add(new GyvunasViewModel
                {
                    seimininkas = Convert.ToString(item["fk_seimininkas"]),
                    cipsas = Convert.ToString(item["cipsas"]),
                    rusis = Convert.ToString(item["rusis"]),
                    tipas = Convert.ToString(item["tipas"]),
                    vardas = Convert.ToString(item["vardas"]),
                    gimimodata = Convert.ToDateTime(item["gimimo_data"]),
                    svoris = Convert.ToString(item["svoris"]),

                });
            }

            return gyvunas;
        }

    }
}