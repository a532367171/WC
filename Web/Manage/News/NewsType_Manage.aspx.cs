using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;

public partial class Manage_News_NewsType_Manage : ModulePages
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
        News_TypeInfo byId = News_Type.Init().GetById(Convert.ToInt32(id));
        this.ViewState["ni"] = byId;
        this.TypeName.Value = byId.TypeName;
        this.Orders.Value = string.Concat(byId.Orders);
        this.Notes.Value = byId.Notes;
    }
    protected void Save_Btn(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
        {
            News_TypeInfo news_TypeInfo = this.ViewState["ni"] as News_TypeInfo;
            news_TypeInfo.Notes = this.Notes.Value;
            news_TypeInfo.TypeName = this.TypeName.Value;
            news_TypeInfo.Orders = Convert.ToInt32(this.Orders.Value);
            News_Type.Init().Update(news_TypeInfo);
        }
        else
        {
            News_TypeInfo news_TypeInfo = new News_TypeInfo();
            news_TypeInfo.TypeName = this.TypeName.Value;
            news_TypeInfo.Notes = this.Notes.Value;
            news_TypeInfo.Orders = Convert.ToInt32(this.Orders.Value);
            News_Type.Init().Add(news_TypeInfo);
        }
        string str = HttpContext.Current.Server.HtmlEncode("您好!分类保存成功!");
        base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=../../Manage/News/NewsType_List.aspx&tip=" + str);
    }
}