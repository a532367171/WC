using System;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
public partial class Manage_Common_MyMemo : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Show();
			}
		}
		private void Show()
		{
			IList all = Sys_User.Init().GetAll(" et6 like '%#" + this.Uid + "#%' ", "order by MemoShare desc,depid asc,orders asc");
			this.rpt.DataSource = all;
			this.rpt.DataBind();
			this.num.InnerHtml = "您当前拥有 总计 - <span style='color:#ff0000; font-weight:bold;'>" + all.Count + "</span> 个 下属信息";
		}
		protected string GetStatus(object j)
		{
			string format = "<span style='color:{0};font-weight:bold'>{1}</span>";
			string result = "";
			if (Convert.ToInt32(j) == 0)
			{
				result = string.Format(format, "#0066ff", "未启用 日程汇报");
			}
			if (Convert.ToInt32(j) == 1)
			{
				result = string.Format(format, "#ff0000", "已启用 日程汇报");
			}
			return result;
		}
		protected string GetView(object b, object j)
		{
			string format = "<a href=Memo_SubList.aspx?uid={0} class='show'>查看下属日程</a>";
			string result = "";
			if (Convert.ToInt32(j) == 1)
			{
				result = string.Format(format, b);
			}
			return result;
		}
	}
