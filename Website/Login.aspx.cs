using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Security;
using System.Text;
using System.Security.Cryptography;

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
            lblFailed.Text = "Either your session has expired, or you have not yet logged in";
        }
    }
    public static string CreateMD5(string input)
    {
        // Use input string to calculate MD5 hash
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        // Convert the byte array to hexadecimal string
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("X2"));
        }
        return sb.ToString();
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUser.Text != "" && txtUser.Text != null)
        {
            if (txtPass.Text != "" && txtPass.Text != null)
            {

                string connStr = ConfigurationManager.ConnectionStrings["jgcon"].ConnectionString;
                string passwrds = "";
                string custId = "";
                string custName = "";
                string passW = CreateMD5(txtPass.Text);
                try
                {
                    SqlConnection curCon = new SqlConnection(connStr);
                    curCon.Open();
                    SqlCommand cmd = new SqlCommand("select * from tblCustomers where username = @user", curCon);
                    cmd.Parameters.Add(new SqlParameter("@user", txtUser.Text));
                    SqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    custId = (reader["custId"].ToString());
                    passwrds = (reader["password"].ToString());
                    custName = (reader["fName"].ToString());
                }
                catch (Exception ex)
                {
                    lblFailed.Text = "Could not connect to database, or user name not found";
                }
                if (passwrds != "")
                {
                    if (passW == passwrds)
                    {
                        this.Session["cID"] = custId;
                        this.Session["cName"] = custName;
                        this.Session.Timeout = 5;
                        Response.Redirect("Cart.aspx");
                    }
                }
                if (this.Session["cID"] == null)
                    lblFailed.Text = "Incorrect password";
            }
        }
    }
}