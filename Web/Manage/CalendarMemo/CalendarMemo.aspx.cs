using System;
using WC.BLL;

public partial class Manage_richeng_CalendarMemo : ViewPages
{
    protected string memo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        this.memo = this.Uid;
    }
}
