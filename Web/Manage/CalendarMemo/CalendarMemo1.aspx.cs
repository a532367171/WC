using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WC.BLL;


public partial class Manage_richeng_CalendarMemo1 : ViewPages
{
    protected string memo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.memo = this.Uid;
    }
}