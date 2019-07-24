using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.DK;

public partial class Manage_News_NewsType_List : ModulePages
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.Show();
        }
    }
    private void Show()
    {
        IList all = News_Type.Init().GetAll(null, " order by orders asc");
        this.rpt.DataSource = all;
        this.rpt.DataBind();
        this.num.InnerHtml = "当前 总计 - <span style='color:#ff0000; font-weight:bold;'>" + all.Count + "</span> 个 记录数据";
    }
    protected void Del_Btn(object obj, EventArgs e)
    {
        LinkButton linkButton = obj as LinkButton;
        RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
        HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
        int num = Convert.ToInt32(htmlInputCheckBox.Value);
        try
        {
            IList all = News_Article.Init().GetAll("typeid=" + num, null);
            if (all != null && all.Count > 0)
            {
                foreach (object current in all)
                {
                    News_ArticleInfo news_ArticleInfo = current as News_ArticleInfo;
                    Help.DeleteFiles(news_ArticleInfo.FilePath);
                }
            }
        }
        catch
        {
        }
        string cmdText = "delete from News_Article where typeid=" + num;
        MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
        News_Type.Init().Delete(num);
        this.Show();
    }
}