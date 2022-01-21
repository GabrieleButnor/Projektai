using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using L2_veterinarija.Models;
using MySql.Data.MySqlClient;


namespace L2_veterinarija.Repos
{
    public class PrekeRepository
    {
        public List<Preke> getPrekes()
        {
            List<Preke> prekes = new List<Preke>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.kodas, m.pavadinimas, m.kaina, m.informacija
                                FROM prekes m";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                prekes.Add(new Preke
                {
                    kodas = Convert.ToString(item["kodas"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    kaina = Convert.ToInt32(item["kaina"]),
                    informacija = Convert.ToString(item["informacija"]),
                });
            }

            return prekes;
        }

        public Preke getPreke(string kodas)
        {
            Preke preke = new Preke();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.kodas, m.pavadinimas, m.kaina, m.informacija 
                                FROM prekes m WHERE m.kodas='" + kodas + "'";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                preke.kodas = Convert.ToString(item["kodas"]);
                preke.pavadinimas = Convert.ToString(item["pavadinimas"]);
                preke.kaina = Convert.ToInt32(item["kaina"]);
                preke.informacija = Convert.ToString(item["informacija"]);
            }

            return preke;
        }

        public bool updatePreke(Preke preke)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE prekes a SET a.pavadinimas=?pavadinimas, a.kaina=?kaina, a.informacija=?informacija WHERE a.kodas=?kodas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?kodas", MySqlDbType.VarChar).Value = preke.kodas;
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = preke.pavadinimas;
            mySqlCommand.Parameters.Add("?kaina", MySqlDbType.Int32).Value = preke.kaina;
            mySqlCommand.Parameters.Add("?informacija", MySqlDbType.VarChar).Value = preke.informacija;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public bool addPreke(Preke preke)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO prekes(kodas,pavadinimas,kaina,informacija)VALUES(?kodas,?pavadinimas,?kaina,?informacija)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?kodas", MySqlDbType.VarChar).Value = preke.kodas;
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = preke.pavadinimas;
            mySqlCommand.Parameters.Add("?kaina", MySqlDbType.Int32).Value = preke.kaina;
            mySqlCommand.Parameters.Add("?informacija", MySqlDbType.VarChar).Value = preke.informacija;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public int getPrekesCount(string kodas)
        {
            int naudota = 0;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT count(fk_prideta_vizitui) as kiekis from priskyrimai where fk_preke='" + kodas + "'";
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

        public void deletePreke(string kodas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM prekes where kodas=?kodas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?kodas", MySqlDbType.VarChar).Value = kodas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}