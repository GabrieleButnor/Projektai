using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using L2_veterinarija.ViewModels;
using L2_veterinarija.Models;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace L2_veterinarija.Repos
{
    public class VizitasRepository
    {
        public List<VizitasListViewModel> getVizitai()
        {
            List<VizitasListViewModel> vizitai = new List<VizitasListViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT v.numeris, v.sudarymo_data as data, CONCAT(g.vardas,' ', g.pavarde) as gydytojas, CONCAT(n.rusis,' ',n.vardas) as gyvunas, v.busena as busena 
                                FROM vizitai v, gydytojai g, gyvunai n
                                WHERE v.fk_gydytojas=g.darbuotojo_kodas and v.fk_gyvunas=n.cipsas
                                ORDER BY 1";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                vizitai.Add(new VizitasListViewModel
                {
                    numeris = Convert.ToInt32(item["numeris"]),
                    sudarymodata = Convert.ToDateTime(item["data"]),
                    gydytojas = Convert.ToString(item["gydytojas"]),
                    gyvunas = Convert.ToString(item["gyvunas"]),
                    busena = Convert.ToString(item["busena"])
                });
            }
            return vizitai;
        }


        public VizitasEditViewModel getVizitas(int numeris)
        {
            VizitasEditViewModel vizitas = new VizitasEditViewModel();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * FROM vizitai where numeris=" + numeris;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                vizitas.numeris = Convert.ToInt32(item["numeris"]);
                vizitas.sudarymodata = Convert.ToDateTime(item["sudarymo_data"]);
                vizitas.vizitodata = Convert.ToDateTime(item["vizito_data"]);
                vizitas.vizitovalanda = Convert.ToString(item["vizito_valanda"]);
                vizitas.busena = Convert.ToString(item["busena"]);
                vizitas.fk_gyvunas = Convert.ToString(item["fk_gyvunas"]);
                vizitas.fk_gydytojas = Convert.ToString(item["fk_gydytojas"]);
            }


            return vizitas;
        }


        public bool updateVizitas(VizitasEditViewModel vizitas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE `vizitai` SET
                                    `sudarymo_data` = ?sudarymodata,
                                    `vizito_data` = ?vizitodata,
                                    `vizito_valanda` = ?vizitovalanda,      
                                    `busena` = ?busena,
                                    `fk_gyvunas` = ?gyvunas,
                                    `fk_gydytojas` = ?gydytojas
                                    WHERE numeris=" + vizitas.numeris;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?sudarymodata", MySqlDbType.DateTime).Value = vizitas.sudarymodata;
            mySqlCommand.Parameters.Add("?vizitodata", MySqlDbType.DateTime).Value = vizitas.vizitodata;
            mySqlCommand.Parameters.Add("?vizitovalanda", MySqlDbType.VarChar).Value = vizitas.vizitovalanda;
            mySqlCommand.Parameters.Add("?busena", MySqlDbType.VarChar).Value = vizitas.busena;
            mySqlCommand.Parameters.Add("?gyvunas", MySqlDbType.VarChar).Value = vizitas.fk_gyvunas;
            mySqlCommand.Parameters.Add("?gydytojas", MySqlDbType.VarChar).Value = vizitas.fk_gydytojas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }


        public bool addVizitas(VizitasEditViewModel vizitas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO `vizitai`(`numeris`,`sudarymo_data`,`vizito_data`,`vizito_valanda`,`busena`,`fk_gyvunas`,`fk_gydytojas`)
                                    VALUES(?numeris,?sudarymodata,?vizitodata,?vizitovalanda,?busena,?gyvunas,?gydytojas)";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?numeris", MySqlDbType.Int32).Value = vizitas.numeris;
            mySqlCommand.Parameters.Add("?sudarymodata", MySqlDbType.DateTime).Value = vizitas.sudarymodata;
            mySqlCommand.Parameters.Add("?vizitodata", MySqlDbType.DateTime).Value = vizitas.vizitodata;
            mySqlCommand.Parameters.Add("?vizitovalanda", MySqlDbType.VarChar).Value = vizitas.vizitovalanda;
            mySqlCommand.Parameters.Add("?busena", MySqlDbType.VarChar).Value = vizitas.busena;
            mySqlCommand.Parameters.Add("?gyvunas", MySqlDbType.VarChar).Value = vizitas.fk_gyvunas;
            mySqlCommand.Parameters.Add("?gydytojas", MySqlDbType.VarChar).Value = vizitas.fk_gydytojas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }

        public void deleteSutartis(int numeris)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM vizitai where numeris=?numeris";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?numeris", MySqlDbType.Int32).Value = numeris;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

    }
}