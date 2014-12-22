using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.Session["cID"] != null)
            loginText.Text = "Welcome " + this.Session["cName"].ToString() + " - <a href='Logout.aspx'>Log-Out</a>";
        else
            loginText.Text = "<a href='Login.aspx'>Log-In</a>";
    }
}
