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
    public class ReceptinisVaistasRepository
    {

        public List<ReceptinisVaistasViewModel> getVaistai()
        {
            List<ReceptinisVaistasViewModel> vaistaiViewModels = new List<ReceptinisVaistasViewModel>();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.kodas, m.pavadinimas, m.paskirtis, m.kaina, m.galiojimo_pabaiga, m.kiekis, m.doze, mm.numeris AS vizitas 
                                FROM receptiniai_vaistai m
                                LEFT JOIN vizitai mm ON mm.numeris=m.fk_isduotas_vizitui";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                vaistaiViewModels.Add(new ReceptinisVaistasViewModel
                {
                    kodas = Convert.ToString(item["kodas"]),
                    pavadinimasis = Convert.ToString(item["pavadinimas"]),
                    paskirtis = Convert.ToString(item["paskirtis"]),
                    kaina = Convert.ToDecimal(item["kaina"]),
                    galiojimopabaiga = Convert.ToDateTime(item["galiojimo_pabaiga"]),
                    kiekis = Convert.ToString(item["kiekis"]),
                    doze = Convert.ToString(item["doze"]),
                    rvizitas = Convert.ToInt32(item["vizitas"])
                });
            }

            return vaistaiViewModels;
        }


        public ReceptinisVaistasEditViewModel getVaistas(string kodas)
        {
            ReceptinisVaistasEditViewModel vaistas = new ReceptinisVaistasEditViewModel();

            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT m.* 
                                FROM receptiniai_vaistai m WHERE m.kodas='" + kodas + "'";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                vaistas.kodas = Convert.ToString(item["kodas"]);
                vaistas.pavadinimasis = Convert.ToString(item["pavadinimas"]);
                vaistas.paskirtis = Convert.ToString(item["paskirtis"]);
                vaistas.kaina = Convert.ToDecimal(item["kaina"]);
                vaistas.galiojimopabaiga = Convert.ToDateTime(item["galiojimo_pabaiga"]);
                vaistas.kiekis = Convert.ToString(item["kiekis"]);
                vaistas.doze = Convert.ToString(item["doze"]);
                vaistas.rvizitas = Convert.ToInt32(item["fk_isduotas_vizitui"]);
            }

            return vaistas;
        }

        public bool updateVaistas(ReceptinisVaistasEditViewModel vaistas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE receptiniai_vaistai a SET a.pavadinimas=?pavadinimas, a.paskirtis=?paskirtis, a.kaina=?kaina, a.galiojimo_pabaiga=?galiojimopabaiga, a.kiekis=?kiekis, a.doze=?doze, a.fk_isduotas_vizitui=?fk_isduotasvizitui WHERE a.kodas=?kodas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?kodas", MySqlDbType.VarChar).Value = vaistas.kodas;
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = vaistas.pavadinimasis;
            mySqlCommand.Parameters.Add("?paskirtis", MySqlDbType.VarChar).Value = vaistas.paskirtis;
            mySqlCommand.Parameters.Add("?kaina", MySqlDbType.Decimal).Value = vaistas.kaina;
            mySqlCommand.Parameters.Add("?galiojimopabaiga", MySqlDbType.DateTime).Value = vaistas.galiojimopabaiga;
            mySqlCommand.Parameters.Add("?kiekis", MySqlDbType.VarChar).Value = vaistas.kiekis;
            mySqlCommand.Parameters.Add("?doze", MySqlDbType.VarChar).Value = vaistas.doze;
            mySqlCommand.Parameters.Add("?fk_isduotasvizitui", MySqlDbType.Int32).Value = vaistas.rvizitas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public bool addVaistas(ReceptinisVaistasEditViewModel vaistas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO receptiniai_vaistai(kodas,pavadinimas,paskirtis,kaina,galiojimo_pabaiga,kiekis,doze,fk_isduotas_vizitui)VALUES(?kodas,?pavadinimas,?paskirtis,?kaina,?galiojimopabaiga,?kiekis,?doze,?fk_isduotasvizitui)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?kodas", MySqlDbType.VarChar).Value = vaistas.kodas;
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = vaistas.pavadinimasis;
            mySqlCommand.Parameters.Add("?paskirtis", MySqlDbType.VarChar).Value = vaistas.paskirtis;
            mySqlCommand.Parameters.Add("?kaina", MySqlDbType.Decimal).Value = vaistas.kaina;
            mySqlCommand.Parameters.Add("?galiojimopabaiga", MySqlDbType.DateTime).Value = vaistas.galiojimopabaiga;
            mySqlCommand.Parameters.Add("?kiekis", MySqlDbType.VarChar).Value = vaistas.kiekis;
            mySqlCommand.Parameters.Add("?doze", MySqlDbType.VarChar).Value = vaistas.doze;
            mySqlCommand.Parameters.Add("?fk_isduotasvizitui", MySqlDbType.Int32).Value = vaistas.rvizitas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public void deleteVaistas(string kodas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM receptiniai_vaistai where kodas=?kodas";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?kodas", MySqlDbType.Int32).Value = kodas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

    }
}