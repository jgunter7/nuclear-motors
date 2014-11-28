using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connStr = ConfigurationManager.ConnectionStrings["jgcon"].ConnectionString;
        
        SqlConnection me = new SqlConnection(connStr);
        me.Open();
        SqlCommand getEm = new SqlCommand("select * from tblProducts where productId = 11", me);
        SqlDataReader reader;
        reader = getEm.ExecuteReader();
        reader.Read();
        string productD = reader["productDesc"].ToString();
        reader.Close();
        me.Close();
        getStuff.Text = productD;
    }
}