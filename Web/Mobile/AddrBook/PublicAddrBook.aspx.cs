using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;

public partial class Mobile_AddrBook_PublicAddrBook : MobilePage

	{
        //protected HtmlForm form1;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page1;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["type"]))
			{
				base.Response.Redirect("PublicAddrBook.aspx?keywords=" + HttpContext.Current.Server.HtmlEncode(base.Request.Form["keywords"]));
			}
			if (!base.IsPostBack)
			{
				this.Show();
			}
		}
		private void Show()
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
			{
				string text = base.Request.QueryString["keywords"];
				string where = string.Concat(new string[]
				{
					" UserName like '%",
					text,
					"%' or RealName like '%",
					text,
					"%' or DepName like '%",
					text,
					"%'  "
				});
				IList list = Sys_User.Init().GetAll(where, "Order BY DepID asc,orders asc, Phone DESC");
				this.rpt.DataSource = list;
				this.rpt.DataBind();
			}
			else
			{
				int pageSize = 30;
				IList list = this.GetOrdersUser();
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
				this.Page1.sty("meneame", num, pagedDataSource.PageCount, "?page=");
				this.num.InnerHtml = "当前总计 - <span style='color:#ff0000; font-weight:bold;'>" + list.Count + "</span> 条 记录数据";
				this.rpt.DataSource = pagedDataSource;
				this.rpt.DataBind();
			}
		}
		private IList GetOrdersUser()
		{
			object value = MsSqlOperate.ExecuteScalar(CommandType.Text, "select min(id) from sys_dep where ParentID=0", new SqlParameter[0]);
			List<Sys_UserInfo> list = new List<Sys_UserInfo>();
			this.GetTreeItems(Convert.ToInt32(value), list);
			return list;
		}
		private void GetTreeItems(int did, IList li)
		{
			IList all = Sys_User.Init().GetAll("DepID=" + did, "order by status asc,orders asc, Phone DESC");
			foreach (object current in all)
			{
				if (!li.Contains(current))
				{
					li.Add(current);
				}
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
	}