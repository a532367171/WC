using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
public partial class Default3 : ViewPages
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //int num = Convert.ToInt32(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(*) from WM_Users where Name='" + this.UserName + "'", new SqlParameter[0]));
        //    if (num <= 0)
        //    {

        Response.Redirect("Debug.aspx?user=" + this.UserName);
    }
}