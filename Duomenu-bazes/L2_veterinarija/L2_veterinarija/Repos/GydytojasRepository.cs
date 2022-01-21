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
    public class GydytojasRepository
    {
        public List<GydytojasViewModel> getGydytojai()
        {
            List<GydytojasViewModel> gydytojasViewModels = new List<GydytojasViewModel>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.darbuotojo_kodas, m.vardas, m.pavarde, m.telefonas, m.e_pastas, m.stazas, m.kabinetas, mm.pavadinimas AS klinika 
                                FROM gydytojai m
                                LEFT JOIN klinikos mm ON mm.imones_kodas=m.fk_klinika";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                gydytojasViewModels.Add(new GydytojasViewModel
                {
                    darbuotojokodas = Convert.ToString(item["darbuotojo_kodas"]),
                    vardas = Convert.ToString(item["vardas"]),
                    pavarde = Convert.ToString(item["pavarde"]),
                    telefonas = Convert.ToString(item["telefonas"]),
                    epastas = Convert.ToString(item["e_pastas"]),
                    stazas = Convert.ToString(item["stazas"]),
                    kabinetas = Convert.ToString(item["kabinetas"]),
                    klinika = Convert.ToString(item["klinika"]),
                });
            }

            return gydytojasViewModels;
        }

        public GydytojasEditViewModel getGydytojas(string kodas)
        {
            GydytojasEditViewModel gydytojas = new GydytojasEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.* FROM gydytojai m WHERE m.darbuotojo_kodas='" + kodas +"'";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                gydytojas.darbuotojokodas = Convert.ToString(item["darbuotojo_kodas"]);
                gydytojas.vardas = Convert.ToString(item["vardas"]);
                gydytojas.pavarde = Convert.ToString(item["pavarde"]);
                gydytojas.telefonas = Convert.ToString(item["telefonas"]);
                gydytojas.epastas = Convert.ToString(item["e_pastas"]);
                gydytojas.stazas = Convert.ToString(item["stazas"]);
                gydytojas.kabinetas = Convert.ToString(item["kabinetas"]);
                gydytojas.fk_klinika = Convert.ToString(item["fk_klinika"]);
            }

            return gydytojas;
        }

        public bool updateGydytojas(GydytojasEditViewModel gydytojas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE gydytojai a SET a.vardas=?vardas, a.pavarde=?pavarde, a.telefonas=?telefonas, a.e_pastas=?epastas, a.stazas=?stazas, a.kabinetas=?kabinetas, a.fk_klinika=?klinika WHERE a.darbuotojo_kodas=?darbuotojokodas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?darbuotojokodas", MySqlDbType.VarChar).Value = gydytojas.darbuotojokodas;
            mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = gydytojas.vardas;
            mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = gydytojas.pavarde;
            mySqlCommand.Parameters.Add("?telefonas", MySqlDbType.VarChar).Value = gydytojas.telefonas;
            mySqlCommand.Parameters.Add("?epastas", MySqlDbType.VarChar).Value = gydytojas.epastas;
            mySqlCommand.Parameters.Add("?stazas", MySqlDbType.VarChar).Value = gydytojas.stazas;
            mySqlCommand.Parameters.Add("?kabinetas", MySqlDbType.VarChar).Value = gydytojas.kabinetas;
            mySqlCommand.Parameters.Add("?klinika", MySqlDbType.VarChar).Value = gydytojas.fk_klinika;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public bool addGydytojas(GydytojasEditViewModel gydytojas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO gydytojai(darbuotojo_kodas,vardas,pavarde,telefonas,e_pastas,stazas,kabinetas,fk_klinika)VALUES(?darbuotojokodas,?vardas,?pavarde,?telefonas,?epastas,?stazas,?kabinetas,?klinika)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?darbuotojokodas", MySqlDbType.VarChar).Value = gydytojas.darbuotojokodas;
            mySqlCommand.Parameters.Add("?vardas", MySqlDbType.VarChar).Value = gydytojas.vardas;
            mySqlCommand.Parameters.Add("?pavarde", MySqlDbType.VarChar).Value = gydytojas.pavarde;
            mySqlCommand.Parameters.Add("?telefonas", MySqlDbType.VarChar).Value = gydytojas.telefonas;
            mySqlCommand.Parameters.Add("?epastas", MySqlDbType.VarChar).Value = gydytojas.epastas;
            mySqlCommand.Parameters.Add("?stazas", MySqlDbType.VarChar).Value = gydytojas.stazas;
            mySqlCommand.Parameters.Add("?kabinetas", MySqlDbType.VarChar).Value = gydytojas.kabinetas;
            mySqlCommand.Parameters.Add("?klinika", MySqlDbType.VarChar).Value = gydytojas.fk_klinika;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public int getGydytojasCount(string kodas)
        {
            int naudota = 0;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT count(numeris) as kiekis from vizitai where fk_gydytojas='" + kodas + "'";
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

        public void deleteGydytojas(string kodas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM gydytojai where darbuotojo_kodas=?kodas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?kodas", MySqlDbType.VarChar).Value = kodas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}