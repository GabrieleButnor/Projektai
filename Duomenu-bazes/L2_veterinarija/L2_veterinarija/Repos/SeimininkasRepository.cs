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
    public class SeimininkasRepository
    {
        public List<Seimininkas> getSeimininkai()
        {
            List<Seimininkas> seimininkai = new List<Seimininkas>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);

            string sqlquery = @"SELECT * FROM seimininkai";

            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                seimininkai.Add(new Seimininkas
                {
                    kodas = Convert.ToString(item["kodas"]),
                    vardas = Convert.ToString(item["vardas"]),
                    pavarde = Convert.ToString(item["pavarde"]),
                    epastas = Convert.ToString(item["e_pastas"]),
                    telefonas = Convert.ToString(item["telefonas"]),
                    adresas = Convert.ToString(item["adresas"]),

                });
            }

            return seimininkai;
        }


        public bool addSeiminnkas(Seimininkas seimininkas)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"INSERT INTO seimininkai(kodas,vardas,pavarde,e_pastas,telefonas,adresas)VALUES(?kodas,?vardas,?pavarde,?epastas,?telefonas,?adresas);";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?kodas", MySqlDbType.VarChar).Value = seimininkas.kodas;
                mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = seimininkas.vardas;
                mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = seimininkas.pavarde;
                mySqlCommand.Parameters.Add("?epastas", MySqlDbType.VarChar).Value = seimininkas.epastas;
                mySqlCommand.Parameters.Add("?telefonas", MySqlDbType.VarChar).Value = seimininkas.telefonas;
                mySqlCommand.Parameters.Add("?adresas", MySqlDbType.Text).Value = seimininkas.adresas;
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool updateSeiminikas(Seimininkas seimininkas)
        {
            try
            {
                string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
                MySqlConnection mySqlConnection = new MySqlConnection(conn);
                string sqlquery = @"UPDATE seimininkai a SET a.vardas=?vardas, a.pavarde=?pavarde, a.e_pastas=?epastas, a.telefonas=?telefonas, a.adresas=?adresas WHERE a.kodas=?kodas";
                MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
                mySqlCommand.Parameters.Add("?kodas", MySqlDbType.VarChar).Value = seimininkas.kodas;
                mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = seimininkas.vardas;
                mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = seimininkas.pavarde;
                mySqlCommand.Parameters.Add("?epastas", MySqlDbType.VarChar).Value = seimininkas.epastas;
                mySqlCommand.Parameters.Add("?telefonas", MySqlDbType.VarChar).Value = seimininkas.telefonas;
                mySqlCommand.Parameters.Add("?adresas", MySqlDbType.Text).Value = seimininkas.adresas;
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Seimininkas getSeimininkas(string kodasa)
        {
            Seimininkas seimininkas = new Seimininkas();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM seimininkai WHERE kodas=?kodas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?kodas", MySqlDbType.VarChar).Value = kodasa;
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {

                seimininkas.kodas = Convert.ToString(item["kodas"]);
                seimininkas.vardas = Convert.ToString(item["vardas"]);
                seimininkas.pavarde = Convert.ToString(item["pavarde"]);
                seimininkas.epastas = Convert.ToString(item["e_pastas"]);
                seimininkas.telefonas = Convert.ToString(item["telefonas"]);
                seimininkas.adresas = Convert.ToString(item["adresas"]);
            }

            return seimininkas;
        }
                     

        public int getSeimininkasCount(string kodas)
        {
            int naudota = 0;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT count(cipsas) as kiekis from gyvunai where fk_seimininkas='" + kodas + "'";
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



        public void deleteSeimininas(string kodasa)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM seimininkai where kodas=?kodas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?kodas", MySqlDbType.VarChar).Value = kodasa;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

    }
}