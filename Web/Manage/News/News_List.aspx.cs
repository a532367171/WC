using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;
using WC.Controls;
using WC.DK;



public partial class Manage_News_News_List : ViewPages 
{
    

    protected string news_menu = "";
    protected string news_list = ">> 所有资讯";
    private string news_tmp = "<a href='../../Manage/News/News_List.aspx?tid={0}' {1}>{2}</a>";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.Show();
        }
    }
    protected void Search_Btn(object sender, EventArgs e)
    {
        string text = base.Request.Form["keyword"];
        string str = "?keywords=" + HttpContext.Current.Server.HtmlEncode(text.Trim());
        base.Response.Redirect("News_List.aspx" + str);
    }
    protected void RowDataBind(object sender, RepeaterItemEventArgs e)
    {
        Label label = e.Item.FindControl("c") as Label;
        Panel panel = e.Item.FindControl("d") as Panel;
        if (label.Text == this.Uid)
        {
            panel.Visible = true;
        }
    }
    protected void Del_Btn(object obj, EventArgs e)
    {
        LinkButton linkButton = obj as LinkButton;
        RepeaterItem repeaterItem = linkButton.Parent.Parent as RepeaterItem;
        Panel panel = repeaterItem.FindControl("d") as Panel;
        if (panel.Visible)
        {
            HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
            int id = Convert.ToInt32(htmlInputCheckBox.Value);
            News_ArticleInfo byId = News_Article.Init().GetById(id);
            Help.DeleteFiles(byId.FilePath);
            News_Article.Init().Delete(id);
            this.Show();
        }
    }
    private void Show()
    {
        IList all = News_Type.Init().GetAll(null, " order by orders asc");
        for (int i = 0; i < all.Count; i++)
        {
            News_TypeInfo news_TypeInfo = all[i] as News_TypeInfo;
            if (string.Concat(news_TypeInfo.id) == (base.Request.QueryString["tid"] ?? ""))
            {
                this.news_menu += string.Format(this.news_tmp, news_TypeInfo.id, "", news_TypeInfo.TypeName);
                this.news_list = ">> " + news_TypeInfo.TypeName;
            }
            else
            {
                this.news_menu += string.Format(this.news_tmp, news_TypeInfo.id, "", news_TypeInfo.TypeName);
            }
        }
        Hashtable hashtable = (Hashtable)HttpContext.Current.Application["config_fenye"];
        int pageSize = Convert.ToInt32(hashtable["fenye_commom"]);
        int num = 0;
        try
        {
            if (!string.IsNullOrEmpty(base.Request.QueryString["page"]))
            {
                num = Convert.ToInt32(base.Request.QueryString["page"]);
            }
        }
        catch
        {
        }
        if (num == 0)
        {
            num = 1;
        }
        PagedDataSource pagedDataSource = new PagedDataSource();
        string text = " a.TypeID = b.id and ( a.ShareDeps='' or a.ShareDeps like '%#" + this.DepID + "#%') ";
        string text2 = base.Request.QueryString["keywords"];
        if (!string.IsNullOrEmpty(text2) && Utils.CheckSql(text2))
        {
            text = " a.TypeID = b.id and ( a.ShareDeps='' or a.ShareDeps like '%#" + this.DepID + "#%') ";
            text = text + " and (a.NewsTitle like '%" + text2 + "%'  ) ";
        }
        if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
        {
            string text3 = base.Request.QueryString["tid"];
            text = string.Concat(new string[]
				{
					" a.TypeID=",
					text3,
					" and a.TypeID = b.id and ( a.ShareDeps='' or a.ShareDeps like '%#",
					this.DepID,
					"#%') "
				});
        }
        string cmdText = "select a.*,b.TypeName from News_Article as a,News_Type as b where " + text + " order by a.id desc";
        using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
        {
            this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + dataSet.Tables[0].Rows.Count + "</span> 条 记录数据";
            pagedDataSource.DataSource = dataSet.Tables[0].DefaultView;
            pagedDataSource.AllowPaging = true;
            pagedDataSource.PageSize = pageSize;
            pagedDataSource.CurrentPageIndex = num - 1;
            this.rpt.DataSource = pagedDataSource;
            this.rpt.DataBind();
            if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
            {
                this.Page2.sty("meneame", num, pagedDataSource.PageCount, "?keywords=" + text2 + "&page=");
            }
            if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
            {
                this.Page2.sty("meneame", num, pagedDataSource.PageCount, "?tid=" + base.Request.QueryString["tid"] + "&page=");
            }
            this.Page2.sty("meneame", num, pagedDataSource.PageCount, "?page=");
        }
    }
}