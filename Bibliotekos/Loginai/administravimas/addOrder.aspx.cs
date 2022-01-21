using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loginai.administravimas {
    public partial class addOrder : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected void Button2_Click(object sender, EventArgs e) {
            string json;

            string urlAddress = "https://carpartshop.net/Laboras/add_order.php";
            using(WebClient client = new WebClient()) {
                var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() {
                    { "data", data.Text },
                    { "pavadinimas", pavadinimas.Text },
                    { "autorius", autorius.Text },
                    { "leidimas", leidimas.Text },
                    { "tiekejas", tiekejas.Text },
                    { "kiekis", kiekis.Text },
                    { "vnt_kaina", vnt_kaina.Text } });
                json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            }
            Response.Redirect("~/administravimas/main.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e) {
            Response.Redirect("~/administravimas/main.aspx");
        }
    }
}