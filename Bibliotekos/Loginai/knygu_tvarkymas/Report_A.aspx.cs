using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Loginai.knygu_tvarkymas
{
    public partial class Report_A : System.Web.UI.Page
    {
        List<Del_stat> del_stats;
        Consts consts;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            del_stats = new List<Del_stat>();
            consts = new Consts();
            string url = "https://carpartshop.net/Laboras/get_list_of_del_stats.php";
            string json = null;
            using (WebClient client = new WebClient())
            {
                var pagesource = client.UploadValues(url, new System.Collections.Specialized.NameValueCollection(){});
                json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            }
            del_stats = JsonConvert.DeserializeObject<List<Del_stat>>(json);

            TableRow row;
            TableCell cell;
            foreach (Del_stat d in del_stats)
            {
                row = new TableRow();
                cell = new TableCell(); cell.Text = consts.genres[d.state]; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = d.count.ToString(); row.Cells.Add(cell);
                del_stats_table.Rows.Add(row);
            }
            row = new TableRow();
            cell = new TableCell(); cell.Text = "Isviso pasalinta"; row.Cells.Add(cell);
            cell = new TableCell(); cell.Text = del_stats.Sum(x => x.count).ToString(); row.Cells.Add(cell);
            del_stats_table.Rows.Add(row);
        }

        protected void m_books_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }

        protected void m_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("add.aspx");
        }

        protected void m_report_b_Click(object sender, EventArgs e)
        {
            Response.Redirect("Report_B.aspx");
        }
    }
}