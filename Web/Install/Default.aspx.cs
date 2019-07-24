using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class install_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
    protected void Refuse_btn(object sender, EventArgs e)
    {

    }
    protected void Accept_btn(object sender, EventArgs e)
    {
        base.Response.Redirect("Prepare.aspx");
    }
}