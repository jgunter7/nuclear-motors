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
        string connStr = ConfigurationManager.ConnectionStrings["jgcon"].ConnectionString;
        string ip = "";
        int occ = 0;
        try
        {
            using (SqlConnection con1 = new SqlConnection(connStr))
            {
                con1.Open();
                using (SqlCommand cmd1 = new SqlCommand("select * from tblTracking where ipaddr = @ip",con1))
                {
                    cmd1.Parameters.AddWithValue("@ip", GlobalFunctions.GetIP4Address());
                    SqlDataReader reader;
                    reader = cmd1.ExecuteReader();
                    if (reader.Read() == false)
                    {
                        ip = "";
                        occ = 0;
                    }
                    else
                    {
                        ip = reader["ipaddr"].ToString();
                        occ = int.Parse(reader["hits"].ToString());
                    }
                    reader.Close();
                    occ++;
                    string cmdStr = "";
                    if (ip != "")
                        cmdStr = "Update tblTracking SET hits = @occ WHERE ipaddr = @ip";
                    else
                    {
                        cmdStr = "Insert into tblTracking (ipaddr,hits) Values (@ip, @occ)";
                        ip = GlobalFunctions.GetIP4Address();
                    }
                    using (SqlCommand cmd2 = new SqlCommand(cmdStr, con1))
                    {
                        cmd2.Parameters.AddWithValue("@occ", occ);
                        cmd2.Parameters.AddWithValue("@ip", ip);
                        cmd2.ExecuteNonQuery();
                    }
                }
            }
        }
        catch { Response.Redirect("Login.aspx"); }
    }
}