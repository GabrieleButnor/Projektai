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
    public class PriskyrimasRepository
    {
        public List<Priskyrimas> getPriskyrimai(int vizitas)
        {
            List<Priskyrimas> prekes = new List<Priskyrimas>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = "select * from priskyrimai WHERE fk_prideta_vizitui=" + vizitas;
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();

            foreach (DataRow item in dt.Rows)
            {
                prekes.Add(new Priskyrimas
                {
                    fk_pridetavizitui = Convert.ToInt32(item["fk_prideta_vizitui"]),
                    fk_preke = Convert.ToString(item["fk_preke"]),
                    vienetai = Convert.ToInt32(item["vienetai"]),
                });
            }

            return prekes;
        }

        public bool deletePryskyrimas(int vizitas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"DELETE FROM a USING priskyrimai as a
                                where a.fk_prideta_vizitui =?fkid";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?fkid", MySqlDbType.Int32).Value = vizitas;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return true;
        }

        public bool insertPriskyrimas(Priskyrimas priskyrimas)
        {
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @"INSERT INTO priskyrimai(
                                        fk_prideta_vizitui,
                                        fk_preke,
                                        vienetai)
                                        VALUES(
                                        ?fk_prideta_vizitui,
                                        ?fk_preke,
                                        ?vienetai
                                        )";
            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?fk_prideta_vizitui", MySqlDbType.Int32).Value = priskyrimas.fk_pridetavizitui;
            mySqlCommand.Parameters.Add("?fk_preke", MySqlDbType.String).Value = priskyrimas.fk_preke;
            mySqlCommand.Parameters.Add("?vienetai", MySqlDbType.Int32).Value = priskyrimas.vienetai;
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();

            return true;
        }
    }
}