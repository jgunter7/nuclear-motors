using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

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

            List<string> userIds = new List<string>();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                userIds.Add(reader["username"].ToString());
            }
            bool userTaken = false;
            if (userIds.Count() != 0)
            {
                for (int i = 0; i < userIds.Count(); i++)
                {
                    if (userIds[i] == txtUser.Text)
                    {
                        userTaken = true;
                    }
                }
            }
            if (userTaken)
                lblErrors.Text = "User already Exists - try a different user name";
            else
            {
                using (SqlConnection con1 = new SqlConnection(connStr))
                {
                    using (SqlCommand cmd2 = new SqlCommand("Insert into tblCustomers (username,password,fName) Values (@un, @up, @name)", con1))
                    {
                        cmd2.Parameters.AddWithValue("@un", txtUser.Text);
                        cmd2.Parameters.AddWithValue("@up", txtPass.Text);
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