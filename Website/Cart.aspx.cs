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
    int orderId = 0;
    string connStr = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        int cId = 0;
        try { cId = int.Parse(this.Session["cID"].ToString()); }
        catch { cId = 0; }
        if (cId == 0)
            Response.Redirect("Login.aspx");
        connStr = ConfigurationManager.ConnectionStrings["jgcon"].ConnectionString;

        decimal orderTotal = 0.00M;

        try
        {
            SqlConnection curCon = new SqlConnection(connStr);
            curCon.Open();
            SqlCommand cmd = new SqlCommand("select * from tblOrders where custId = @custId AND closed is null Order BY orderId DESC", curCon);
            cmd.Parameters.Add(new SqlParameter("@custId", cId));
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                orderId = int.Parse(reader["orderId"].ToString());
                orderTotal = decimal.Parse(reader["orderTotal"].ToString());
            }
            reader.Close();
            orderCost.Text = String.Format("{0:C2}", orderTotal);
            cmd = new SqlCommand("select * from tblOrderLine where orderId = @orderId", curCon);
            cmd.Parameters.Add(new SqlParameter("@orderId", orderId));

            List<int> productIds = new List<int>();
            List<string> quantitys = new List<string>();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productIds.Add(int.Parse(reader["productId"].ToString()));
                quantitys.Add(reader["quantity"].ToString());
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
                    Label quan = new Label();
                    prodName.Text = "Product Name: " + reader["productDesc"].ToString();
                    prodIcon.ImageUrl = reader["productIcon"].ToString();
                    prodPrice.Text = "Product Price" + String.Format("{0:C2}", reader["productPrice"]);
                    quan.Text = "Quantity: " + quantitys[i];
                    reader.Close();
                    Table tblO = new Table();
                    TableRow row1 = new TableRow();
                    TableCell cell1 = new TableCell();
                    cell1.Controls.Add(prodIcon);
                    row1.Cells.Add(cell1);
                    cell1 = new TableCell();
                    cell1.Controls.Add(prodName);
                    cell1.Controls.Add(new LiteralControl("<br/>"));
                    cell1.Controls.Add(prodPrice);
                    cell1.Controls.Add(new LiteralControl("<br/>"));
                    cell1.Controls.Add(quan);
                    row1.Cells.Add(cell1);
                    tblO.Rows.Add(row1);
                    pnlOrders.Controls.Add(tblO);
                    tblO.Style.Add("display", "inline-flex");
                    tblO.Style.Add("padding-left", "100px");
                }
            }
        }
        catch { orderId = 0; }
    }
    protected void btnChkOut_Click(object sender, EventArgs e)
    {
        if (orderId != 0)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("Update tblOrders SET closed = @closed WHERE orderId = @ord", con))
                {
                    cmd.Parameters.AddWithValue("@closed", System.DateTime.Today.ToShortDateString());
                    cmd.Parameters.AddWithValue("@ord", orderId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}