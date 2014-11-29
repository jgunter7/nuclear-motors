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
       // try
        //{
            SqlConnection curCon = new SqlConnection(connStr);
            curCon.Open();
            if (pId == 0)
            {
                SqlCommand cmd = new SqlCommand("select * from tblProducts", curCon);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                int ids = 1;
                while (reader.Read())
                {
                    Label curID = new Label();
                    curID.Text = reader["productId"].ToString();
                    Label curName = new Label();
                    curName.Text = reader["productDesc"].ToString();
                    HyperLink curImg = new HyperLink();
                    curImg.NavigateUrl = "Product.aspx?pId=" + ids++;
                    curImg.ImageUrl = reader["productImg"].ToString();
                    Label curPrice = new Label();                 
                    curPrice.Text = String.Format("{0:C2}", reader["productPrice"]);
                    Table lTab = new Table();
                    lTab.Style.Add("display", "inline-flex");
                    lTab.Style.Add("width", "380px");
                    TableRow lRow = new TableRow();
                    TableCell lCell = new TableCell();
                    TableCell lCell2 = new TableCell();
                    lCell.Controls.Add(curImg);
                    lRow.Controls.Add(lCell);
                    Table rTab = new Table();
                    TableRow rRow = new TableRow();
                    TableCell rCell = new TableCell();
                    rCell.Controls.Add(curName);
                    rRow.Cells.Add(rCell);
                    rTab.Rows.Add(rRow);                    
                    rRow = new TableRow();
                    rCell = new TableCell();
                    rCell.Controls.Add(curPrice);
                    rRow.Cells.Add(rCell);
                    rTab.Rows.Add(rRow);
                    lCell2.Controls.Add(rTab);
                    lRow.Cells.Add(lCell2);
                    lTab.Rows.Add(lRow);
                    pnlAllProd.Controls.Add(lTab);
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
        //}
        //catch (Exception ex) { System.IO.File.AppendAllText(@"c:\web\log.txt", "Product - Page_Load :: " + ex.Message + Environment.NewLine); }
        sw.Stop();
        System.IO.File.AppendAllText(@"c:\web\log.txt", "Product - Page_Load :: Total Time= " + sw.ElapsedMilliseconds + "ms" + Environment.NewLine);
    }
}