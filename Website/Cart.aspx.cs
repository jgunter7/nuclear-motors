using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class Cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int cId = 0;
        try { cId = int.Parse(this.Session["cID"].ToString()); }
        catch { cId = 0; }
        if (cId == 0)
            Response.Redirect("Login.aspx?err=timeout");
        string connStr = ConfigurationManager.ConnectionStrings["jgcon"].ConnectionString;

        int orderId = 0;
        decimal orderTotal = 0.00M;

        try
        {
            SqlConnection curCon = new SqlConnection(connStr);
            curCon.Open();
            SqlCommand cmd = new SqlCommand("select * from tblOrders where custId = @custId Order BY orderId DESC", curCon);
            cmd.Parameters.Add(new SqlParameter("@custId", cId));
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                orderId = int.Parse(reader["orderId"].ToString());
                orderTotal = decimal.Parse(reader["orderTotal"].ToString());
            }
            reader.Close();
            cmd = new SqlCommand("select * from tblOrderLine where orderId = @orderId", curCon);
            cmd.Parameters.Add(new SqlParameter("@orderId", orderId));

            List<int> productIds = new List<int>();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productIds.Add(int.Parse(reader["productId"].ToString()));
            }
            reader.Close();
            if (productIds.Count != 0)
            {
                for (int i = 0; i < productIds.Count(); i++)
                {
                    cmd = new SqlCommand("select * from tblProducts where productId = @pId", curCon);
                    cmd.Parameters.Add(new SqlParameter("@pId", productIds[i]));
                    reader = cmd.ExecuteReader();
                    reader.Read();
                    Label prodName = new Label();
                    Image prodIcon = new Image();
                    Label prodPrice = new Label();
                    prodName.Text = reader["productDesc"].ToString();
                    prodIcon.ImageUrl = reader["productIcon"].ToString();
                    prodPrice.Text = String.Format("{0:C2}", reader["productPrice"]);
                    reader.Close();
                    pnlOrders.Controls.Add(prodName);
                    pnlOrders.Controls.Add(prodPrice);
                    pnlOrders.Controls.Add(prodIcon);
                    pnlOrders.Controls.Add(new LiteralControl("<hr/>"));
                }
            }
        }
        catch { }
    }
}