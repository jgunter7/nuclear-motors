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
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Start();
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
                    addCart.Text = "Add to Cart!";
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
                    main.Style.Add("width", "380px");
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
        }
        catch (Exception ex) { System.IO.File.AppendAllText(@"c:\web\log.txt", "Product - Page_Load :: " + ex.Message + Environment.NewLine); }
        sw.Stop();
        System.IO.File.AppendAllText(@"c:\web\log.txt", "Product - Page_Load :: Total Time= " + sw.ElapsedMilliseconds + "ms" + Environment.NewLine);
    }

    private void addCart_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string prodId = btn.ID;

    }
}