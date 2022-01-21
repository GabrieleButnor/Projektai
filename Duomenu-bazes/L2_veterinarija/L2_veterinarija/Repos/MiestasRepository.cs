using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using L2_veterinarija.Models;
using System.Configuration;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace L2_veterinarija.Repos
{
    public class MiestasRepository
    {

        public List<Miestas> getMiestai()
        {
            List<Miestas> miestai = new List<Miestas>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT * from miestai";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                miestai.Add(new Miestas
                {
                    id = Convert.ToInt32(item["id"]),
                    salis = Convert.ToString(item["salis"]),
                    apskritiespavadinimas = Convert.ToString(item["apskrities_pavadinimas"]),
                    pavadinimas = Convert.ToString(item["pavadinimas"])
                });
            }

            return miestai;
        }

        public Miestas getMiestas(int id)
        {
            Miestas miestas = new Miestas();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"SELECT a.id,
                                       a.salis,
                                       a.apskrities_pavadinimas,
                                       a.pavadinimas
                                       FROM " +  @"miestai a
                                       WHERE a.id= " + id;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                miestas.id = Convert.ToInt32(item["id"]);
                miestas.salis = Convert.ToString(item["salis"]);
                miestas.apskritiespavadinimas = Convert.ToString(item["apskrities_pavadinimas"]);
                miestas.pavadinimas = Convert.ToString(item["pavadinimas"]);
            }

            return miestas;
        }


        public bool updateMiestas(Miestas miestas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"UPDATE " + "miestai a SET a.salis=?salis, a.apskrities_pavadinimas=?apskritiespavadinimas, a.pavadinimas=?pavadinimas WHERE a.id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.VarChar).Value = miestas.id;
            mySqlCommand.Parameters.Add("?salis", MySqlDbType.VarChar).Value = miestas.salis;
            mySqlCommand.Parameters.Add("?apskritiespavadinimas", MySqlDbType.VarChar).Value = miestas.apskritiespavadinimas;
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = miestas.pavadinimas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }


        public int insertMiestas(Miestas miestas)
        {
            int insertedId = -1;
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO " + "miestai(id,salis,apskrities_pavadinimas,pavadinimas)VALUES(?id,?salis,?apskritiespavadinimas,?pavadinimas);";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = miestas.id;
            mySqlCommand.Parameters.Add("?salis", MySqlDbType.VarChar).Value = miestas.salis;
            mySqlCommand.Parameters.Add("?apskritiespavadinimas", MySqlDbType.VarChar).Value = miestas.apskritiespavadinimas;
            mySqlCommand.Parameters.Add("?pavadinimas", MySqlDbType.VarChar).Value = miestas.pavadinimas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            insertedId = miestas.id;
            return insertedId;
        }

        public void deleteMiestas(int id)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM " +  "miestai where id=?id";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }

    }
}