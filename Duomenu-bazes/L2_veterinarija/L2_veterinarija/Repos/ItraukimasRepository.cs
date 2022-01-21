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
    public class ItraukimasRepository
    {

        public List<Itraukimas> getItraukimus(int vizitas)
        {
            List<Itraukimas> paslaugos = new List<Itraukimas>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from itraukimai WHERE 	fk_priskirta_vizitui=" + vizitas;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                paslaugos.Add(new Itraukimas
                {
                    fk_priskirtavizitui = Convert.ToInt32(item["fk_priskirta_vizitui"]),
                    fk_paslauga = Convert.ToString(item["fk_paslauga"]),
                });
            }

            return paslaugos;
        }

        public bool deleteItraukimas(int vizitas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM a USING itraukimai as a
                                where a.fk_priskirta_vizitui=?fkid";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?fkid", MySqlDbType.Int32).Value = vizitas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public bool insertItraukimai(Itraukimas itraukimai)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO itraukimai(
                                        fk_priskirta_vizitui,
                                        fk_paslauga)
                                        VALUES(
                                        ?fk_priskirta_vizitui,
                                        ?fk_paslauga
                                        )";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?fk_priskirta_vizitui", MySqlDbType.Int32).Value = itraukimai.fk_priskirtavizitui;
            mySqlCommand.Parameters.Add("?fk_paslauga", MySqlDbType.String).Value = itraukimai.fk_paslauga;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }
    }
}