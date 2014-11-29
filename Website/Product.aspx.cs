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
        int pId = 0;
        try { pId = int.Parse(Request.QueryString["pId"]); }
        catch { pId = 0; }
        string connStr = ConfigurationManager.ConnectionStrings["jgcon"].ConnectionString;
        try
        {
            SqlConnection curCon = new SqlConnection(connStr);
            curCon.Open();
            if (pId == 0)
            {
                SqlCommand cmd = new SqlCommand("select * from tblProducts", curCon);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Label curID = new Label();
                    curID.Text = reader["productId"].ToString();
                    pnlAllProd.Controls.Add(curID);
                    Label curName = new Label();
                    curName.Text = reader["productDesc"].ToString();
                    pnlAllProd.Controls.Add(curName);
                    Image curImg = new Image();
                    curImg.ImageUrl = reader["productImg"].ToString();
                    pnlAllProd.Controls.Add(curImg);
                    Label curPrice = new Label();                 
                    curPrice.Text = String.Format("{0:C2}", reader["productPrice"]);
                    pnlAllProd.Controls.Add(curPrice);
                }
                reader.Close();
            }
            else if (pId != 0)
            {
                SqlCommand cmd = new SqlCommand("select * from tblProducts where productId = @pId", curCon);
                cmd.Parameters.Add(new SqlParameter("@pId", pId));
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                reader.Read();
                prodId.Text = reader["productId"].ToString();
                prodName.Text = reader["productDesc"].ToString();
                prodImg.ImageUrl = reader["productImg"].ToString();
                prodPrice.Text = String.Format("{0:C2}", reader["productPrice"]);
                reader.Close();
            }            
            curCon.Close();
        }
        catch { System.IO.File.AppendAllText(@"c:\web\log.txt", "\nProduct - Page_Load :: Could not connect to database"); }
    }
}