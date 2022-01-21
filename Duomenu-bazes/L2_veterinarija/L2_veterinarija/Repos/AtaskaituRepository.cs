using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using L2_veterinarija.Models;
using L2_veterinarija.ViewModels;
using MySql.Data.MySqlClient;

namespace L2_veterinarija.Repos
{
    public class AtaskaituRepository
    {
        public List<VAtaskaitaViewModel> getAtaskaitaVizitu(DateTime? nuo, DateTime? iki, string busena)
        {
            List<VAtaskaitaViewModel> vizitai = new List<VAtaskaitaViewModel>();
            string conn = ConfigurationManager.ConnectionStrings["MysqlConnection"].ConnectionString;
            MySqlConnection mySqlConnection = new MySqlConnection(conn);
            string sqlquery = @" SELECT a.numeris, a.sudarymo_data, a.busena, k.vardas, k.pavarde, k.darbuotojo_kodas, CONCAT(g.rusis,' ', g.vardas) as gyvunas, IFNULL(sum(ps.kaina), 0) paslaugu_kaina, IFNULL(sum(pk.kaina*p.vienetai), 0) prekiu_kaina, 
                                t.bendra_suma bendra_suma_paslaugu, s.bendra_suma bendra_suma_prekiu FROM vizitai a INNER JOIN gydytojai k ON k.darbuotojo_kodas=a.fk_gydytojas INNER JOIN gyvunai g ON g.cipsas=a.fk_gyvunas

                                LEFT JOIN priskyrimai p INNER JOIN prekes pk ON p.fk_preke=pk.kodas ON p.fk_prideta_vizitui=a.numeris
                                LEFT JOIN itraukimai i INNER JOIN paslaugos ps ON i.fk_paslauga=ps.paslaugos_kodas ON i.fk_priskirta_vizitui=a.numeris 
                                   
                                            

                                LEFT JOIN ( SELECT kk.darbuotojo_kodas, IFNULL(SUM(pss.kaina), 0) as bendra_suma FROM vizitai aa 
                                INNER JOIN gydytojai kk ON kk.darbuotojo_kodas=aa.fk_gydytojas 
                                LEFT JOIN itraukimai ii INNER JOIN paslaugos pss ON ii.fk_paslauga=pss.paslaugos_kodas ON ii.fk_priskirta_vizitui=aa.numeris
                                WHERE aa.sudarymo_data>=IFNULL(?nuo, aa.sudarymo_data) AND aa.sudarymo_data<=IFNULL(?iki, aa.sudarymo_data) AND aa.busena=IFNULL(busena, aa.busena)
                                GROUP BY kk.darbuotojo_kodas ) AS t ON t.darbuotojo_kodas = k.darbuotojo_kodas

                                LEFT JOIN (SELECT kkk.darbuotojo_kodas, IFNULL(SUM(pkk.kaina*pp.vienetai), 0) as bendra_suma FROM vizitai aaa 
                                INNER JOIN gydytojai kkk ON kkk.darbuotojo_kodas=aaa.fk_gydytojas 
                                LEFT JOIN priskyrimai pp INNER JOIN prekes pkk ON pp.fk_preke=pkk.kodas ON pp.fk_prideta_vizitui=aaa.numeris
                                WHERE aaa.sudarymo_data>=IFNULL(?nuo, aaa.sudarymo_data) AND aaa.sudarymo_data<=IFNULL(?iki, aaa.sudarymo_data) AND aaa.busena=IFNULL(busena, aaa.busena)
                                GROUP BY kkk.darbuotojo_kodas) AS s ON s.darbuotojo_kodas = k.darbuotojo_kodas

                                WHERE a.sudarymo_data>=IFNULL(?nuo, a.sudarymo_data) AND a.sudarymo_data<=IFNULL(?iki, a.sudarymo_data) AND a.busena=IFNULL(?busena, a.busena)
                                GROUP BY a.numeris, k.pavarde
                                ORDER BY k.pavarde ASC";

            MySqlCommand mySqlCommand = new MySqlCommand(sqlquery, mySqlConnection);
            mySqlCommand.Parameters.Add("?nuo", MySqlDbType.DateTime).Value = nuo;
            mySqlCommand.Parameters.Add("?iki", MySqlDbType.DateTime).Value = iki;
            if(busena == "")
            {
                busena = null;
            }
            mySqlCommand.Parameters.Add("?busena", MySqlDbType.String).Value = busena;

            mySqlConnection.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(mySqlCommand);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mySqlConnection.Close();
            foreach (DataRow item in dt.Rows)
            {
                vizitai.Add(new VAtaskaitaViewModel
                {
                    numeris = Convert.ToInt32(item["numeris"]),
                    sudarymo_data = Convert.ToDateTime(item["sudarymo_data"]),
                    busena = Convert.ToString(item["busena"]),
                    asmensKodas = Convert.ToString(item["darbuotojo_kodas"]),
                    vardas = Convert.ToString(item["vardas"]),
                    pavarde = Convert.ToString(item["pavarde"]),
                    gyvunas = Convert.ToString(item["gyvunas"]),
                    paslauguKaina = Convert.ToDecimal(item["paslaugu_kaina"]),
                    prekeKaina = Convert.ToDecimal(item["prekiu_kaina"]),
                    bendraSumaPaslaugu = Convert.ToDecimal(item["bendra_suma_paslaugu"]),
                    bendraSumaPrekiu = Convert.ToDecimal(item["bendra_suma_prekiu"])
                });
            }

            return vizitai;
        }

    }
}