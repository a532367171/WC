using System;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;

public partial class Manage_News_Tips_List : ModulePages
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
        IList all = Tips.Init().GetAll(null, " order by orders asc");
        this.rpt.DataSource = all;
        this.rpt.DataBind();
        this.num.InnerHtml = "当前 总计 - <span style='color:#ff0000; font-weight:bold;'>" + all.Count + "</span> 个 记录数据";
    }
    protected void Del_Btn(object obj, EventArgs e)
    {
        LinkButton linkButton = obj as LinkButton;
        RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
        HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
        int id = Convert.ToInt32(htmlInputCheckBox.Value);
        Tips.Init().Delete(id);
        this.Show();
    }
}