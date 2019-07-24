using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;

public partial class Manage_News_Tips_Manage : ModulePages
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["tid"]))
        {
            this.Show(base.Request.QueryString["tid"]);
        }
    }
    private void Show(string id)
    {
        TipsInfo byId = WC.BLL.Tips.Init().GetById(Convert.ToInt32(id));
        this.ViewState["ni"] = byId;
        this.Tips.Value = byId.Tips;
        this.Orders.Value = string.Concat(byId.Orders);
    }
    protected void Save_Btn(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
        {
            TipsInfo tipsInfo = this.ViewState["ni"] as TipsInfo;
            tipsInfo.Tips = this.Tips.Value.Replace("\r\n", "").Replace("'", "");
            tipsInfo.Orders = Convert.ToInt32(this.Orders.Value);
            WC.BLL.Tips.Init().Update(tipsInfo);
        }
        else
        {
            TipsInfo tipsInfo = new TipsInfo();
            tipsInfo.Tips = this.Tips.Value.Replace("\r\n", "").Replace("'", "");
            tipsInfo.Orders = Convert.ToInt32(this.Orders.Value);
            WC.BLL.Tips.Init().Add(tipsInfo);
        }
        string str = HttpContext.Current.Server.HtmlEncode("您好!滚动公告保存成功!");
        base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=../Manage/News/Tips_List.aspx&tip=" + str);
    }
}