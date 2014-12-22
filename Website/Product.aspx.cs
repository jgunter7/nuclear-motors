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
    string connStr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        int pId = 0;
        try { pId = int.Parse(Request.QueryString["pId"]); }
        catch { pId = 0; }
        connStr = ConfigurationManager.ConnectionStrings["jgcon"].ConnectionString;
        try
        {
            SqlConnection curCon = new SqlConnection(connStr);
            curCon.Open();
            if (pId == 0)
            {
                SqlCommand cmd;
                if (sorting.SelectedValue == "Price: High - Low")
                    cmd = new SqlCommand("select * from tblProducts Order By productPrice DESC", curCon);
                else if (sorting.SelectedValue == "Price: Low - High")
                    cmd = new SqlCommand("select * from tblProducts Order By productPrice ASC", curCon);
                else
                    cmd = new SqlCommand("select * from tblProducts", curCon);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Button addCart = new Button();
                    //addCart.Text = "Add to Cart!";
                    addCart.CssClass = "Cart";
                    addCart.ID = reader["productId"].ToString();
                    addCart.Click += addCart_Click;
                    Label curName = new Label();
                    curName.Text = reader["productDesc"].ToString();
                    HyperLink curImg = new HyperLink();
                    curImg.NavigateUrl = "Product.aspx?pId=" + reader["productId"].ToString();
                    curImg.ImageUrl = reader["productIcon"].ToString();
                    Label curPrice = new Label();
                    curPrice.Text = String.Format("{0:C2}", reader["productPrice"]);
                    Table main = new Table();
                    TableRow tRow = new TableRow();
                    TableCell tCell = new TableCell();
                    tCell.Controls.Add(curImg);
                    tCell.ColumnSpan = 2;
                    tRow.Cells.Add(tCell);
                    main.Rows.Add(tRow);
                    tRow = new TableRow();
                    tCell = new TableCell();
                    tCell.Controls.Add(curName);
                    tCell.Height = 50;
                    tCell.ColumnSpan = 2;
                    tRow.Cells.Add(tCell);
                    main.Rows.Add(tRow);
                    tRow = new TableRow();
                    tCell = new TableCell();
                    tCell.Controls.Add(curPrice);
                    tRow.Cells.Add(tCell);
                    tCell = new TableCell();
                    tCell.Controls.Add(addCart);
                    tRow.Cells.Add(tCell);
                    main.Rows.Add(tRow);
                    main.Style.Add("display", "inline-flex");
                    main.Style.Add("width", "300px");
                    main.Style.Add("height", "300px");
                    main.Style.Add("text-align", "center");
                    pnlAllProd.Controls.Add(main);
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
                prodName.Text = reader["productDesc"].ToString();
                prodImg.ImageUrl = reader["productImg"].ToString();
                prodPrice.Text = String.Format("{0:C2}", reader["productPrice"]);
                reader.Close();
            }
            curCon.Close();
            Button addC = new Button();
            addC.ID = pId.ToString();
            //addC.Text = "Add to Cart";
            addC.CssClass = "Cart";
            addC.Click += addCart_Click;
            buttonHere.Controls.Add(addC);
        }
        catch (Exception ex) { //Add error to text field
        }
    }

    public void addCart_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string prodId = btn.ID;
        int cId = 0;
        try { cId = int.Parse(this.Session["cID"].ToString()); }
        catch { cId = 0; }
        if (cId == 0)
            Response.Redirect("Login.aspx");
        AddToCart(prodId, cId);

    }

    private void AddToCart(string prodId, int cId)
    {
        SqlConnection curCon = new SqlConnection(connStr);
        curCon.Open();
        SqlCommand cmd = new SqlCommand("select * from tblOrders where custId = @custId AND closed is null Order BY orderId DESC", curCon);
        cmd.Parameters.Add(new SqlParameter("@custId", cId));
        SqlDataReader reader;
        reader = cmd.ExecuteReader();
        if (reader.Read() == false)
        {
            using (SqlConnection con1 = new SqlConnection(connStr))
            {
                using (SqlCommand cmd4 = new SqlCommand("Insert into tblOrders (created,closed,orderTotal,custId) Values (@create, @close, @total, @cus)", con1))
                {
                    cmd4.Parameters.AddWithValue("@create", System.DateTime.Now);
                    cmd4.Parameters.AddWithValue("@close", DBNull.Value);
                    cmd4.Parameters.AddWithValue("@total", 0.00M);
                    cmd4.Parameters.AddWithValue("@cus", cId);
                    con1.Open();
                    cmd4.ExecuteNonQuery();
                }
            }
            AddToCart(prodId, cId);
        }
        int orderId = int.Parse(reader["orderId"].ToString());
        decimal orderTotal = decimal.Parse(reader["orderTotal"].ToString());
        reader.Close();
        cmd = new SqlCommand("select productPrice from tblProducts where productId = @pId", curCon);
        cmd.Parameters.Add(new SqlParameter("@pId", prodId));
        reader = cmd.ExecuteReader();
        reader.Read();
        orderTotal += decimal.Parse(reader["productPrice"].ToString());
        reader.Close();
        cmd = new SqlCommand("select quantity from tblOrderLine where productId = @pId AND orderId = @ord", curCon);
        cmd.Parameters.Add(new SqlParameter("@pId",prodId));
        cmd.Parameters.Add(new SqlParameter("@ord", orderId));
        reader = cmd.ExecuteReader();
        int quantity = 0;
        if (reader.Read())  
            quantity = int.Parse(reader["quantity"].ToString());
        reader.Close();
        curCon.Close();
        if (quantity > 0)
        {
            quantity++;
            using (SqlConnection con3 = new SqlConnection(connStr))
            {
                using (SqlCommand cmd4 = new SqlCommand("Update tblOrderLine SET quantity = @quan WHERE productId = @pId AND orderId = @ord", con3))
                {
                    cmd4.Parameters.AddWithValue("@quan", quantity);
                    cmd4.Parameters.AddWithValue("@pId", prodId);
                    cmd4.Parameters.AddWithValue("@ord", orderId);
                    con3.Open();
                    cmd4.ExecuteNonQuery();
                }
            }
        }
        else
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd2 = new SqlCommand("Insert into tblOrderLine (orderId, productId,quantity) Values (@ord, @prod, 1)", con))
                {
                    cmd2.Parameters.AddWithValue("@ord", orderId);
                    cmd2.Parameters.AddWithValue("@prod", prodId);
                    con.Open();
                    cmd2.ExecuteNonQuery();
                }
            }
        }
        using (SqlConnection con2 = new SqlConnection(connStr))
        {
            using (SqlCommand cmd3 = new SqlCommand("Update tblOrders SET orderTotal = @total WHERE orderId = @ord", con2))
            {
                cmd3.Parameters.AddWithValue("@total", orderTotal);
                cmd3.Parameters.AddWithValue("@ord", orderId);
                con2.Open();
                cmd3.ExecuteNonQuery();
            }
        }
        Response.Redirect("Cart.aspx");
    }
}