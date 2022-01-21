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
    public class PaslaugaRepository
    {

        public List<Paslauga> getPaslaugos()
        {
            List<Paslauga> paslaugos = new List<Paslauga>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.paslaugos_kodas, m.tipas, m.kaina, m.trukme
                                FROM paslaugos m";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                paslaugos.Add(new Paslauga
                {
                    paslaugoskodas = Convert.ToString(item["paslaugos_kodas"]),
                    tipas = Convert.ToString(item["tipas"]),
                    kaina = Convert.ToInt32(item["kaina"]),
                    trukme = Convert.ToString(item["trukme"]),
                });
            }

            return paslaugos;
        }


        public Paslauga getPaslauga(string kodas)
        {
            Paslauga paslauga = new Paslauga();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.paslaugos_kodas, m.tipas, m.kaina, m.trukme 
                                FROM paslaugos m WHERE m.paslaugos_kodas='" + kodas + "'";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                paslauga.paslaugoskodas = Convert.ToString(item["paslaugos_kodas"]);
                paslauga.tipas = Convert.ToString(item["tipas"]);
                paslauga.kaina = Convert.ToInt32(item["kaina"]);
                paslauga.trukme = Convert.ToString(item["trukme"]);
            }

            return paslauga;
        }

        public bool updatePaslauga(Paslauga paslauga)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE paslaugos a SET a.tipas=?tipas, a.kaina=?kaina, a.trukme=?trukme WHERE a.paslaugos_kodas=?paslaugos_kodas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?paslaugos_kodas", MySqlDbType.VarChar).Value = paslauga.paslaugoskodas;
            mySqlCommand.Parameters.Add("?tipas", MySqlDbType.VarChar).Value = paslauga.tipas;
            mySqlCommand.Parameters.Add("?kaina", MySqlDbType.Int32).Value = paslauga.kaina;
            mySqlCommand.Parameters.Add("?trukme", MySqlDbType.VarChar).Value = paslauga.trukme;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public bool addPaslauga(Paslauga paslauga)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO paslaugos(paslaugos_kodas,tipas,kaina,trukme)VALUES(?paslaugos_kodas,?tipas,?kaina,?trukme)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?paslaugos_kodas", MySqlDbType.VarChar).Value = paslauga.paslaugoskodas;
            mySqlCommand.Parameters.Add("?tipas", MySqlDbType.VarChar).Value = paslauga.tipas;
            mySqlCommand.Parameters.Add("?kaina", MySqlDbType.Int32).Value = paslauga.kaina;
            mySqlCommand.Parameters.Add("?trukme", MySqlDbType.VarChar).Value = paslauga.trukme;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }


        public int getPaslaugaCount(string kodas)
        {
            int naudota = 0;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT count(fk_priskirta_vizitui) as kiekis from itraukimai where fk_paslauga='" + kodas + "'";
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

        public void deletePaslauga(string kodas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM paslaugos where paslaugos_kodas=?paslaugos_kodas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?paslaugos_kodas", MySqlDbType.VarChar).Value = kodas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

    }
}