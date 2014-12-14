using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;

public partial class NewUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["cID"] != null)
        {
            this.Session.Timeout = 5;
            Response.Redirect("Cart.aspx");
        }
    }
    protected void btnCreateUser_Click(object sender, EventArgs e)
    {
        if (txtUser.Text != "")
        {            
            string connStr = ConfigurationManager.ConnectionStrings["jgcon"].ConnectionString;
            SqlConnection curCon = new SqlConnection(connStr);
            curCon.Open();
            SqlCommand cmd = new SqlCommand("select * from tblCustomers where username = @userID", curCon);
            cmd.Parameters.Add(new SqlParameter("@userID", txtUser.Text));
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                lblErrors.Text = "User already Exists - try a different user name";
            }
            else
            {
                using (SqlConnection con1 = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd2 = new SqlCommand("Insert into tblCustomers (username,password,fName) Values (@un, @up, @name)", con1))
                    {
                        string passW = GlobalFunctions.CreateMD5(txtPass.Text);
                        cmd2.Parameters.AddWithValue("@un", txtUser.Text);
                        cmd2.Parameters.AddWithValue("@up", passW);
                        cmd2.Parameters.AddWithValue("@name", txtName.Text);
                        con1.Open();
                        cmd2.ExecuteNonQuery();
                    }
                }
                lblErrors.Text = "User created successfully";
            }
            reader.Close();
            curCon.Close();
        }
        else
            lblErrors.Text = "No user name was entered";
    }
}