using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loginai.administravimas {
    public partial class editSkaitytojas : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            if(Session["skaitEdit"] != null) {
                isdavimu_tvarkymas.skaitytojas b = (isdavimu_tvarkymas.skaitytojas) Session["skaitEdit"];
                vardas.Text = b.vardas;
                pavarde.Text = b.pavarde;
                el_pastas.Text = b.el_pastas;
                telefono_nr.Text = b.telefono_nr;
                gimimo_data.Text = b.gimimo_data;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        protected void Button2_Click(object sender, EventArgs e) {
            string json;

            string urlAddress = "https://carpartshop.net/Laboras/update_reader.php";
            isdavimu_tvarkymas.skaitytojas b = (isdavimu_tvarkymas.skaitytojas) (Session["skaitEdit"]);
            var id = b.skaitytojo_nr;
            using(WebClient client = new WebClient()) {
                var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() {
                    { "skaitytojo_nr", id},
                    { "vardas", vardas.Text },
                    { "pavarde", pavarde.Text },
                    { "el_pastas", el_pastas.Text },
                    { "telefono_nr", telefono_nr.Text },
                    { "gimimo_data", gimimo_data.Text } });
                json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            }
            Response.Redirect("~/administravimas/main.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e) {
            Response.Redirect("~/administravimas/main.aspx");
        }
    }
}