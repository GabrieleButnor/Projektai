using MySql.Data.MySqlClient;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

namespace Loginai
{

    public partial class WebForm3 : System.Web.UI.Page
    {
        List<sub> a = new List<sub>();
        List<sub> b = new List<sub>();
        List<sub> c = new List<sub>();
        List<sub> d = new List<sub>();
        List<sub> ee = new List<sub>();
        List<sub> f = new List<sub>();
        List<sub> g = new List<sub>();
        List<sub> h = new List<sub>();
        List<sub> i = new List<sub>();
        List<sub> j = new List<sub>();
        List<sub> k = new List<sub>();
        List<sub> l = new List<sub>();

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    string privateKey = null;
        //    try
        //    {
        //        privateKey = Session["privateKey"].ToString();
        //    }
        //    catch
        //    {
        //        Server.Transfer("WebForm1.aspx");
        //    }

        //    if (privateKey == null)
        //    {
        //        Server.Transfer("WebForm1.aspx");
        //    }
        //}


        

        protected void Button1_Click(object sender, EventArgs e)
        {

            DateTime vakarData = new DateTime();
            string pavadinimas = TextBox1.Text;
            string kaina = TextBox2.Text;
            string quantity = TextBox3.Text;
            string deskriptionas = TextBox4.Text;
            vakarData = DateTime.Today.AddDays(-1);
            string databelaiko = vakarData.Year + "-" + vakarData.Month + "-" + vakarData.Day;
            string datasulaiku = databelaiko + " 00:00:00";
            string ci = "server=carpartshop.net;port=3306;database=retailer;username=carpartshop;password=SomintiKniostaAtgrasinti112";
            MySqlConnection connection = new MySqlConnection(ci);
            connection.Open();

            string sup_id = "1";

            

            string sqr = "INSERT INTO `ps_product` (`id_product`, `id_supplier`, `id_manufacturer`, `id_category_default`, `id_shop_default`, `id_tax_rules_group`, `on_sale`, `online_only`, `ean13`, `isbn`, `upc`, `ecotax`, `quantity`, `minimal_quantity`, `low_stock_threshold`, `low_stock_alert`, `price`, `wholesale_price`, `unity`, `unit_price_ratio`, `additional_shipping_cost`, `reference`, `supplier_reference`, `location`,  `width`, `height`, `depth`, `weight`, `out_of_stock`, `additional_delivery_times`, `quantity_discount`, `customizable`, `uploadable_files`,  `text_fields`, `active`, `redirect_type`, `id_type_redirected`, `available_for_order`, `available_date`, `show_condition`, `condition`,  `show_price`, `indexed`, `visibility`, `cache_is_pack`, `cache_has_attachments`, `is_virtual`, `cache_default_attribute`, `date_add`,  `date_upd`, `advanced_stock_management`, `pack_stock_type`, `state`)" +
                         " VALUES(NULL, '" + sup_id + "', NULL, NULL, '1', '0', '0', '1', NULL, '123456789', NULL, '0.000000', '" + quantity + "', '1', NULL, '0', '" + kaina + "', '0', NULL, '0.000000', '0', NULL, NULL, NULL, '7', '8', '9', '10', '0', '1', '0', '0','0', '0', '1', '', '0', '1', '" + databelaiko + "', '1', 'refurbished', '1', '1', 'both', '0', '0', '0', NULL, '" + datasulaiku + "', '" + datasulaiku + "', '0', '3', '1'); SELECT LAST_INSERT_ID();";
            
            MySqlCommand conPer = new MySqlCommand(sqr, connection);

            MySqlDataReader reader = conPer.ExecuteReader();
            reader.Read();
            string idofproduct = reader.GetString(0);

            TextBox1.Text = idofproduct;


            connection.Close();
            string pilnaeilute = "";
            sqr = "INSERT INTO `ps_product_lang` (`id_product`, `id_shop`, `id_lang`, `description`, `description_short`, `link_rewrite`, `meta_description`, `meta_keywords`, `meta_title`, `name`, `available_now`, `available_later`, `delivery_in_stock`, `delivery_out_stock`) VALUES('" + idofproduct + "', '1','1', '" + deskriptionas + "', '" + deskriptionas + "', '', NULL, NULL, NULL, '" + pavadinimas + "', NULL, NULL, NULL, NULL);";            
            pilnaeilute +=  " " +sqr;
            sqr = "INSERT INTO `ps_category_product` (`id_category`, `id_product`, `position`) VALUES('0', '" + idofproduct + "', '0');";
            pilnaeilute += " " + sqr;
            sqr = "INSERT INTO `ps_product_shop` (`id_product`, `id_shop`, `id_category_default`, `id_tax_rules_group`, `on_sale`, `online_only`, `ecotax`, `minimal_quantity`, `low_stock_threshold`, `low_stock_alert`, `price`, `wholesale_price`, `unity`, `unit_price_ratio`, `additional_shipping_cost`, `customizable`, `uploadable_files`, `text_fields`, `active`, `redirect_type`, `id_type_redirected`, `available_for_order`, `available_date`, `show_condition`, `condition`, `show_price`, `indexed`, `visibility`, `cache_default_attribute`, `advanced_stock_management`, `date_add`, `date_upd`, `pack_stock_type`)" +
                "VALUES('" + idofproduct + "', '1', NULL, '0', '0', '0', '0.000000', '1', NULL, '0', '" + kaina + "', '0', NULL, '0.000000', '0', '0', '0', '0', '1', '', '0', '1', '" + databelaiko + "', '1', 'refurbished', '1', '1', 'both', NULL, '0', '" + datasulaiku + "', '" + datasulaiku + "', '3');";
            pilnaeilute += " " + sqr;
            sqr = "INSERT INTO `ps_stock_available` (`id_stock_available`, `id_product`, `id_product_attribute`, `id_shop`, `id_shop_group`, `quantity`, `physical_quantity`, `reserved_quantity`, `depends_on_stock`, `out_of_stock`, `location`) VALUES(NULL, '" + idofproduct + "', '0', '1', '0', '" + quantity + "', '0','0', '0', '0', '');";
            pilnaeilute += " " + sqr;
            sqr = "INSERT INTO `ps_product_supplier` (`id_product_supplier`,`id_product`, `id_product_attribute`,`id_supplier`,`product_supplier_reference`,`product_supplier_price_te`,`id_currency`) VALUES(NULL,'" + idofproduct + "',0,'" + sup_id + "',NULL,0.000000,'1')";
            pilnaeilute += " " + sqr;
            conPer = new MySqlCommand(pilnaeilute, connection);
            connection.Open();
            reader = conPer.ExecuteReader();
            reader.Read();
            connection.Close();
            string pathas = FileUpload1.PostedFile.FileName;
            connection.Open();
            uploadImage(pathas, idofproduct);
            Server.Transfer("WebForm2.aspx");
        }
        public static string uploadImage(string path, string id_product)
        {
            var client = new RestClient("http://carpartshop.net/api");
            byte[] file = System.IO.File.ReadAllBytes(path);

            var request = new RestRequest("images/products/" + id_product + "?ws_key=" + "2YULME37Q1QFKRISJ7WNPKPSQVS59XPM", Method.POST);
            request.AddFileBytes("image", file, Path.GetFileName(path));

            IRestResponse response = client.Execute(request);
            string content = response.Content;

            return content;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
         

            a.Add(new sub("13", "Aušinimo žarnos"));
            a.Add(new sub("15", "Ventiliatoriai"));
            a.Add(new sub("17", "Radiatoriai"));
            a.Add(new sub("18", "Termomovos"));
            a.Add(new sub("20", "Termostatai"));
            a.Add(new sub("21", "Vandens pompos"));
            a.Add(new sub("16", "Kita"));

            b.Add(new sub("19", "Paskirstytojas ir jo komponentai"));
            b.Add(new sub("22", "Paskirstytojo dangtelis"));
            b.Add(new sub("23", "Skriejikai"));
            b.Add(new sub("25", "Uždegimo žvakės"));
            b.Add(new sub("27", "Pakaitinimo žvakės"));
            b.Add(new sub("28", "Uždegimo ritės"));
            b.Add(new sub("32", "Kita"));

            d.Add(new sub("29", "Generatorius ir jo dalys"));
            d.Add(new sub("30", "Lemputės"));
            d.Add(new sub("31", "Salono apšvietimo sistema"));
            d.Add(new sub("33", "Centrinio užrakto sistema"));
            d.Add(new sub("34", "Komforto sistemų dalys"));
            d.Add(new sub("35", "Kištukai"));
            d.Add(new sub("37", "Valdymo moduliai"));
            d.Add(new sub("39", "Vidaus oro sistema"));
            d.Add(new sub("40", "Signalas"));
            d.Add(new sub("42", "Parkavimo sistema"));
            d.Add(new sub("43", "Rėlės"));
            d.Add(new sub("44", "Rozetės"));
            d.Add(new sub("46", "Sensoriai"));
            d.Add(new sub("48", "Starteris"));
            d.Add(new sub("49", "Kita"));

            ee.Add(new sub("38", "Saugumo sistemos"));
            ee.Add(new sub("41", "Antenos"));
            ee.Add(new sub("45", "Prietaisų skydeliai"));
            ee.Add(new sub("47", "Langų valdymo dalys"));
            ee.Add(new sub("50", "Apiplovimo dalys"));
            ee.Add(new sub("52", "Tempimo kabliai ir dalys"));
            ee.Add(new sub("53", "Žarnos"));
            ee.Add(new sub("55", "Peleninės"));
            ee.Add(new sub("57", "Pridegėjai"));
            ee.Add(new sub("59", "Rankenėlės ir spynos"));
            ee.Add(new sub("61", "Veidrodėliai"));
            ee.Add(new sub("63", "Pedalai"));
            ee.Add(new sub("65", "Kita"));

            f.Add(new sub("54", "Kompresorius ir jo dalys"));
            f.Add(new sub("56", "Kondensatoriai"));
            f.Add(new sub("58", "Aušinimo žarnos"));
            f.Add(new sub("60", "Sausintojas, vėsintojas"));
            f.Add(new sub("52", "Vožtuvai"));
            f.Add(new sub("66", "Radiatoriai"));
            f.Add(new sub("64", "Kita"));

            g.Add(new sub("70", "Pompos"));
            g.Add(new sub("71", "Apsauginės dalys"));
            g.Add(new sub("72", "Vairo kolonėlė"));
            g.Add(new sub("75", "Amortizacijos sistema"));
            g.Add(new sub("77", "Traukės ir šarnyrai"));
            g.Add(new sub("79", "Kita"));

            h.Add(new sub("69", "Šakės"));
            h.Add(new sub("73", "Jungtys ir guoliai"));
            h.Add(new sub("74", "Pmeumatinės amortizacijos dalys"));
            h.Add(new sub("76", "Amortizatoriai"));
            h.Add(new sub("78", "Spyruoklės"));
            h.Add(new sub("80", "Stabilizatoriai"));
            h.Add(new sub("82", "Žarnos"));
            h.Add(new sub("84", "Varžtai"));
            h.Add(new sub("85", "Kita"));

            i.Add(new sub("86", "Sankabos apsaugos"));
            i.Add(new sub("88", "Sankabos diskai"));
            i.Add(new sub("90", "Cilindrai"));
            i.Add(new sub("91", "Smagratis"));
            i.Add(new sub("93", "Kita"));

            j.Add(new sub("89", "ABS"));
            j.Add(new sub("92", "Stabdžių cilindrai"));
            j.Add(new sub("94", "Stabdžių diskai"));
            j.Add(new sub("95", "Stabdžių žarnos"));
            j.Add(new sub("97", "stabdžių kaladėles"));
            j.Add(new sub("99", "Suportai"));
            j.Add(new sub("102", "Apasaugos"));
            j.Add(new sub("103", "Slėgio reguliatoriai"));
            j.Add(new sub("105", "Vakumo pompos"));
            j.Add(new sub("106", "Sensoriai"));
            j.Add(new sub("107", "Kita"));

            k.Add(new sub("98", "Akseleratoriaus trosai"));
            k.Add(new sub("100", "Stadžių sistemos trosai"));
            k.Add(new sub("101", "Sankabos trosai"));
            k.Add(new sub("104", "Kapoto trosai"));
            k.Add(new sub("108", "Kita"));

            l.Add(new sub("112", "Velenėliai"));
            l.Add(new sub("113", "Karteriai"));
            l.Add(new sub("115", "Variklio galvos ir detalės"));
            l.Add(new sub("116", "Kolektoriai"));
            l.Add(new sub("114", "Variklio tviritinimai"));
            l.Add(new sub("111", "Variklio blokai"));
            l.Add(new sub("117", "Tepimo sistemos dalys"));
            l.Add(new sub("118", "Guoliai"));
            l.Add(new sub("120", "Apsauginės dalys"));
            l.Add(new sub("121", "Stumokliai ir vožtuvai"));
            l.Add(new sub("122", "Tepalo pompos"));
            l.Add(new sub("123", "Variklio apsaugos"));
            l.Add(new sub("124", "Turbinos"));
            l.Add(new sub("125", "Diržiniai kompresoriai"));
            l.Add(new sub("126", "Kita"));
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string indexas = DropDownList1.SelectedValue;
            List<sub> kkk = new List<sub>();
            if (indexas == "11")
            {
                kkk = a;
            }
            foreach(sub z in kkk)
            {


                DropDownList2.Items.Add(new ListItem(z.name, z.id));
                
            }
        }
    }
}