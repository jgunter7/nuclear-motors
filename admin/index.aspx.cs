using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            string conStr = ConfigurationManager.ConnectionStrings["jgcon"].ConnectionString;
            string cpu1 = CPU.getCurrentCpuUsage();
            string ram1 = CPU.getAvailableRAM();
            string tsf = CPU.GetUpTime();
            int hits = 0;
            SqlDataReader reader;
            try
            {
                using (SqlConnection con1 = new SqlConnection(conStr))
                {
                    con1.Open();
                    using (SqlCommand cmd1 = new SqlCommand("select hits from tblTracking", con1))
                    {
                        reader = cmd1.ExecuteReader();
                        while (reader.Read())
                        {
                            hits += int.Parse(reader["hits"].ToString());
                        }
                    }
                }
            }
            catch
            {
                hits = -1;
            }
            lblCPU.Text = "Current CPU Usage: <span class='crim'>" + cpu1 + "</span>";
            lblRam.Text = "Current RAM Available: <span class='crim'>" + ram1 + "</span>";
            lblNuke.Text = "Total /nuke/ Hits: <span class='crim'>" + hits + "</span>";
            lblUp.Text = "Server Uptime: <span class='crim'>" + tsf + "</span>";
            lblEST.Text = "Server Time(EST): <span class='crim'>" + DateTime.Now.ToString("F") + "</span>";
            lblUTC.Text = "Server Time(UTC): <span class='crim'>" + DateTime.UtcNow.ToString("F") + "</span>";
            lblUser.Text = "Current User: " + Session["user"].ToString();
        }
        else Response.Redirect("Login.aspx?reason=expired/login");
    }
}