using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using L2_veterinarija.Models;
using MySql.Data.MySqlClient;
using L2_veterinarija.ViewModels;

namespace L2_veterinarija.Repos
{
    public class KlinikaRepository
    {

        public List<Klinika> getKlinikos(int id)
        {
            List<Klinika> klinikos = new List<Klinika>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * from klinikos WHERE fk_miestas=" + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                klinikos.Add(new Klinika
                {
                    fk_miestas = Convert.ToInt32(item["fk_miestas"]),
                    imoneskodas = Convert.ToString(item["imones_kodas"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    adresas = Convert.ToString(item["adresas"]),
                    telefonas = Convert.ToString(item["telefonas"]),
                    epastas = Convert.ToString(item["e_pastas"]),
                    darbuotojusk = Convert.ToInt32(item["darbuotoju_sk"]),
                });
            }

            return klinikos;
        }

        public List<KlinikaViewModel> getKlinikos2(int id)
        {
            List<KlinikaViewModel> klinikos = new List<KlinikaViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT k.fk_miestas, k.imones_kodas, k.pavadinimas, k.adresas, k.telefonas, k.e_pastas, k.darbuotoju_sk, count(gydytojai.fk_klinika) as kiekis
                                       FROM klinikos as k left join gydytojai on gydytojai.fk_klinika=k.imones_kodas
	                                   where k.fk_miestas=" + id + " group by k.fk_miestas, k.imones_kodas, k.pavadinimas, k.adresas, k.telefonas, k.e_pastas, k.darbuotoju_sk";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                klinikos.Add(new KlinikaViewModel
                {
                    fk_miestas = Convert.ToInt32(item["fk_miestas"]),
                    imoneskodas = Convert.ToString(item["imones_kodas"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    adresas = Convert.ToString(item["adresas"]),
                    telefonas = Convert.ToString(item["telefonas"]),
                    epastas = Convert.ToString(item["e_pastas"]),
                    darbuotojusk = Convert.ToInt32(item["darbuotoju_sk"]),
                    kiekis = Convert.ToInt32(item["kiekis"])

                });
            }

            return klinikos;
        }

        public bool deleteKlinikos(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM a USING " + @"klinikos as a
                                where a.fk_miestas=?fkid 
                                    and not exists (select 1 from " +  @"gydytojai psl where psl.fk_klinika=a.imones_kodas)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?fkid", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();


            return true;
        }

        public bool insertKlinikos(KlinikaViewModel klinikaViewModel)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO " + @"klinikos(
                                        fk_miestas,
                                        imones_kodas,
                                        pavadinimas,
                                        adresas,
                                        telefonas,
                                        e_pastas,
                                        darbuotoju_sk)VALUES(
                                        ?fk_miestas,
                                        ?imoneskodas,
                                        ?pavadinimas,
                                        ?adresas,
                                        ?telefonas,
                                        ?epastas,
                                        ?darbuotojusk
                                        )";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?fk_miestas", MySqlDbType.Int32).Value = klinikaViewModel.fk_miestas;
            mySqlCommand.Parameters.Add("?imoneskodas", MySqlDbType.VarChar).Value = klinikaViewModel.imoneskodas;
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = klinikaViewModel.pavadinimas;
            mySqlCommand.Parameters.Add("?adresas", MySqlDbType.Text).Value = klinikaViewModel.adresas;
            mySqlCommand.Parameters.Add("?telefonas", MySqlDbType.VarChar).Value = klinikaViewModel.telefonas;
            mySqlCommand.Parameters.Add("?epastas", MySqlDbType.VarChar).Value = klinikaViewModel.epastas;
            mySqlCommand.Parameters.Add("?darbuotojusk", MySqlDbType.Int32).Value = klinikaViewModel.darbuotojusk;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public List<Klinika> getKlinikos()
        {
            List<Klinika> klinikos = new List<Klinika>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * from klinikos";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                klinikos.Add(new Klinika
                {
                    fk_miestas = Convert.ToInt32(item["fk_miestas"]),
                    imoneskodas = Convert.ToString(item["imones_kodas"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"]),
                    adresas = Convert.ToString(item["adresas"]),
                    telefonas = Convert.ToString(item["telefonas"]),
                    epastas = Convert.ToString(item["e_pastas"]),
                    darbuotojusk = Convert.ToInt32(item["darbuotoju_sk"]),
                });
            }

            return klinikos;
        }

    }
}