using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loginai.administravimas {
    public partial class editDalyvis : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            if(Session["dalEdit"] != null) {
                DALYV b = (DALYV) Session["dalEdit"];
                Vardas.Text = b.Vardas;
                Pavarde.Text = b.Pavarde;
                ElPastas.Text = b.ElPastas;
                TelNr.Text = b.TelNr;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected void Button2_Click(object sender, EventArgs e) {
            string json;

            string urlAddress = "https://carpartshop.net/Laboras/update_dalyvis.php";
            DALYV b = (DALYV) (Session["dalEdit"]);
            var id = b.ID;
            using(WebClient client = new WebClient()) {
                var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() {
                    { "ID", id},
                    { "Vardas", Vardas.Text },
                    { "Pavarde", Pavarde.Text },
                    { "ElPastas", ElPastas.Text },
                    { "TelNr", TelNr.Text } });
                json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            }
            Response.Redirect("~/administravimas/main.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e) {
            Response.Redirect("~/administravimas/main.aspx");
        }
    }
}