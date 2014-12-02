using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["cID"] != null)
        {
            this.Session.Timeout = 5;
            Response.Redirect("Cart.aspx");
            
        }
        else
        {
            string err = "";
            try { err = Request.QueryString["err"]; }
            catch { err = ""; }
            if (err != "")
            {
                if (err == "timeout")
                    lblFailed.Text = "The Session Timed Out, Please Log In Again";
            }
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Start();
        if (txtUser.Text != "" && txtUser.Text != null)
        {
            if (txtPass.Text != "" && txtPass.Text != null)
            {
                string connStr = ConfigurationManager.ConnectionStrings["jgcon"].ConnectionString;
                List<string> passwrds = new List<string>();
                List<string> custId = new List<string>();
                try
                {
                    SqlConnection curCon = new SqlConnection(connStr);
                    curCon.Open();
                    SqlCommand cmd = new SqlCommand("select * from tblCustomers where username = @user", curCon);
                    cmd.Parameters.Add(new SqlParameter("@user", txtUser.Text));
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        custId.Add(reader["custId"].ToString());
                        passwrds.Add(reader["password"].ToString());
                    }
                }
                catch (Exception ex)
                { 
                    lblFailed.Text = "Could not connect to database, or user name not found";
                    System.IO.File.AppendAllText(@"c:\web\log.txt", "Login - btnLogin :: " + ex.Message + Environment.NewLine);
                }
                if (passwrds.Count > 0)
                {
                    for (int i = 0; i < passwrds.Count; i++)
                    {
                        if (txtPass.Text == passwrds[i])
                        {
                            sw.Stop();
                            System.IO.File.AppendAllText(@"c:\web\log.txt", "Login - btnLogin :: Total Time= " + sw.ElapsedMilliseconds + "ms" + Environment.NewLine);
                            this.Session["cID"] = custId[i];
                            this.Session.Timeout = 5;
                            Response.Redirect("Cart.aspx");
                        }
                    }
                }
                sw.Stop();
                System.IO.File.AppendAllText(@"c:\web\log.txt", "Login - btnLogin :: Total Time= " + sw.ElapsedMilliseconds + "ms" + Environment.NewLine);
            }
        }
    }
}