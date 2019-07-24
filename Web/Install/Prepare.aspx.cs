using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class install_Prepare : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Environment.Version.Major >= 2)
        {
            this.nf.Value = "当前.NET Frameworks版本可正确运行本系统!";
        }
    }
    protected void bt_Click(object sender, EventArgs e)
    {
        base.Response.Redirect("Install.aspx?sf=" + base.Request.Form["sf"]);
    }
    protected void bt_Click1(object sender, EventArgs e)
    {
        string sss;
        sss = "Install.aspx?sf=" + base.Request.Form["sf"];
        base.Response.Redirect("Install.aspx?sf=" + base.Request.Form["sf"]);

    }
}