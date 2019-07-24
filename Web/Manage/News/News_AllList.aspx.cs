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
using WC.DK;



public partial class Manage_News_News_AllList : System.Web.UI.Page
{
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
        base.Response.Redirect("News_AllList.aspx" + str);
    }
    protected void Del_Btn(object obj, EventArgs e)
    {
        LinkButton linkButton = obj as LinkButton;
        RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
        HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
        int id = Convert.ToInt32(htmlInputCheckBox.Value);
        News_ArticleInfo byId = News_Article.Init().GetById(id);
        Help.DeleteFiles(byId.FilePath);
        News_Article.Init().Delete(id);
        this.Show();
    }
    protected void Del_All(object sender, EventArgs e)
    {
        foreach (RepeaterItem repeaterItem in this.rpt.Items)
        {
            HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
            if (htmlInputCheckBox.Checked)
            {
                int id = Convert.ToInt32(htmlInputCheckBox.Value);
                News_ArticleInfo byId = News_Article.Init().GetById(id);
                Help.DeleteFiles(byId.FilePath);
                News_Article.Init().Delete(id);
            }
        }
        this.Show();
    }
    private void Show()
    {
        Hashtable hashtable = (Hashtable)HttpContext.Current.Application["config_fenye"];
        //int pageSize = Convert.ToInt32(hashtable["fenye_commom"]);
        int pageSize = 20;
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
        string text = " a.TypeID = b.id ";
        string text2 = base.Request.QueryString["keywords"];
        if (!string.IsNullOrEmpty(text2) && Utils.CheckSql(text2))
        {
            text = " a.TypeID = b.id ";
            text = text + " and (a.NewsTitle like '%" + text2 + "%'  ) ";
        }
        if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
        {
            string str = base.Request.QueryString["tid"];
            text = " a.TypeID=" + str + " and a.TypeID = b.id ";
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

