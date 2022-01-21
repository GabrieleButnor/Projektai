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
    public partial class Report_B : System.Web.UI.Page
    {
        List<book> list_of_books;
        Consts consts;
        protected void Page_Load(object sender, EventArgs e)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            list_of_books = new List<book>();
            consts = new Consts();
            string urlAddress = "https://carpartshop.net/Laboras/get_list_of_books.php";
            string json = null;
            using (WebClient client = new WebClient())
            {
                var pagesource = client.UploadValues(urlAddress, new System.Collections.Specialized.NameValueCollection() {{"genre", "0"}});
                json = System.Text.Encoding.UTF8.GetString(pagesource, 0, pagesource.Length);
            }
            if (json != "0 results[]") list_of_books = JsonConvert.DeserializeObject<List<book>>(json);
            int count = list_of_books.Count();
            var t1 = list_of_books.OrderBy(x => x.zanras).GroupBy(x => x.zanras).Select(x => new { zanras = int.Parse(x.Key), count1 = x.Count(), count2 = (double)x.Count()/ count});
            var t2 = list_of_books.OrderBy(x => x.busena).GroupBy(x => x.busena).Select(x => new { busena = int.Parse(x.Key), count1 = x.Count(), count2 = (double)x.Count() / count });
            var best = list_of_books.OrderBy(x => x.zanras).ThenBy(x => x.busena).GroupBy(x => new { x.zanras, x.busena }).Select(
                x => new { zanras = int.Parse(x.Key.zanras), count2 = x.Count(), count1 = int.Parse(x.Key.busena) }).GroupBy(x => x.zanras).Select(
                x => new { zanras = x.Key, count1 = (double)x.Sum(y => y.count1 * y.count2) / x.Sum(y => y.count2) }).Aggregate((i1, i2) => i1.count1 > i2.count1 ? i1 : i2);
            var t4 = list_of_books.OrderBy(x => x.zanras).Where(x => int.Parse(x.zanras) == best.zanras);
            int count2 = t4.Count();
            var t3 = t4.OrderBy(x => x.busena).GroupBy(x => x.busena).Select(x => new { busena = int.Parse(x.Key), count1 = x.Count(), count2 = (double)x.Count() / count2 });
            TableRow row;
            TableCell cell;
            foreach (var d in t1)
            {
                row = new TableRow();
                cell = new TableCell(); cell.Text = consts.genres[d.zanras]; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = d.count1.ToString(); row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = Math.Round(d.count2 * 100).ToString()+"%"; row.Cells.Add(cell);
                genre_stats_table.Rows.Add(row);
            }
            foreach (var d in t2)
            {
                row = new TableRow();
                cell = new TableCell(); cell.Text = consts.quality[d.busena]; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = d.count1.ToString(); row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = Math.Round(d.count2 * 100).ToString() + "%"; row.Cells.Add(cell);
                quality_stats_table.Rows.Add(row);
            }
            best_genre.Text = consts.genres[best.zanras];
            best_genre1.Text = consts.quality[(int)Math.Round(best.count1)];
            foreach (var d in t3)
            {
                row = new TableRow();
                cell = new TableCell(); cell.Text = consts.quality[d.busena]; row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = d.count1.ToString(); row.Cells.Add(cell);
                cell = new TableCell(); cell.Text = Math.Round(d.count2 * 100).ToString() + "%"; row.Cells.Add(cell);
                best_genre3.Rows.Add(row);
            }
        }

        protected void m_books_Click(object sender, EventArgs e)
        {
            Response.Redirect("main.aspx");
        }

        protected void m_add_Click(object sender, EventArgs e)
        {
            Response.Redirect("add.aspx");
        }

        protected void m_report_a_Click(object sender, EventArgs e)
        {
            Response.Redirect("Report_A.aspx");
        }
    }
}