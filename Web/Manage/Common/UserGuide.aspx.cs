using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Manage_Common_UserGuide : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page1;
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
			base.Response.Redirect("UserGuide.aspx" + str);
		}
		private void Show()
		{
			Hashtable hashtable = (Hashtable)HttpContext.Current.Application["config_fenye"];
			int pageSize = Convert.ToInt32(hashtable["fenye_commom"]);
			IList list = Sys_User.Init().GetAll(null, "order by status asc,depid asc,orders asc");
			string text = base.Request.QueryString["keywords"];
			if (!string.IsNullOrEmpty(text) && Utils.CheckSql(text))
			{
				string where = string.Concat(new string[]
				{
					" UserName like '%",
					text,
					"%' or RealName like '%",
					text,
					"%' or DepName like '%",
					text,
					"%' "
				});
				list = Sys_User.Init().GetAll(where, "order by status asc,depid asc,orders asc");
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["did"]))
			{
				list = new List<Sys_UserInfo>();
				this.GetTreeItems(Convert.ToInt32(base.Request.QueryString["did"]), list);
			}
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
			pagedDataSource.DataSource = list;
			pagedDataSource.AllowPaging = true;
			pagedDataSource.PageSize = pageSize;
			pagedDataSource.CurrentPageIndex = num - 1;
			this.rpt.DataSource = pagedDataSource;
			this.rpt.DataBind();
			if (string.IsNullOrEmpty(base.Request.QueryString["keywords"]) && string.IsNullOrEmpty(base.Request.QueryString["did"]))
			{
				this.Page2.sty("meneame", num, pagedDataSource.PageCount, "?page=");
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
			{
				this.Page2.sty("meneame", num, pagedDataSource.PageCount, "?keywords=" + base.Request.QueryString["keywords"] + "&page=");
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["did"]))
			{
				this.Page2.sty("meneame", num, pagedDataSource.PageCount, "?did=" + base.Request.QueryString["did"] + "&page=");
			}
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + list.Count + "</span> 条 记录数据";
		}
		private void GetTreeItems(int did, IList li)
		{
			IList all = Sys_User.Init().GetAll("DepID=" + did, "order by status asc,orders asc");
			foreach (object current in all)
			{
				li.Add(current);
			}
			IList all2 = Sys_Dep.Init().GetAll("ParentID=" + did, "order by orders asc");
			if (all2.Count != 0)
			{
				foreach (Sys_DepInfo sys_DepInfo in all2)
				{
					this.GetTreeItems(sys_DepInfo.id, li);
				}
			}
		}
		protected string GetAges(object obj)
		{
			string result = "";
			if (obj != null && !string.IsNullOrEmpty(Convert.ToString(obj)))
			{
				result = " (" + Utils.GetAgeByDatetime(obj).Split(new char[]
				{
					','
				})[0] + ")";
			}
			return result;
		}
	}
