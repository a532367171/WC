using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;

public partial class Manage_Common_PublicAddrBook : ViewPages


	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected LinkButton LinkButton1;
        //protected Repeater rpt_person;
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
			string str = base.Request.Form["keyword"];
			string str2 = "?keywords=" + str;
			base.Response.Redirect("PublicAddrBook.aspx" + str2);
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
				this.rpt_person.DataSource = list;
				this.rpt_person.DataBind();
			}
			else
			{
				int pageSize = 50;
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
				this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + list.Count + "</span> 条 记录数据";
				this.rpt_person.DataSource = pagedDataSource;
				this.rpt_person.DataBind();
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
		protected void DownLoad(object sender, EventArgs e)
		{
			IList all = Sys_User.Init().GetAll(" phone <>'' or tel <>'' ", "Order BY DepID asc,orders asc, Phone DESC");
			string text = "人员通讯录\r\n\r\n";
			string str = "People ContactsBook";
			foreach (object current in all)
			{
				Sys_UserInfo sys_UserInfo = current as Sys_UserInfo;
				if (!string.IsNullOrEmpty(sys_UserInfo.Tel) && !string.IsNullOrEmpty(sys_UserInfo.Phone))
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						sys_UserInfo.RealName,
						" (",
						sys_UserInfo.DepName,
						")：移动电话:",
						sys_UserInfo.Phone,
						" 固定电话:",
						sys_UserInfo.Tel,
						"\r\n"
					});
				}
				if (string.IsNullOrEmpty(sys_UserInfo.Tel) && !string.IsNullOrEmpty(sys_UserInfo.Phone))
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						sys_UserInfo.RealName,
						" (",
						sys_UserInfo.DepName,
						")：移动电话:",
						sys_UserInfo.Phone,
						"\r\n"
					});
				}
				if (!string.IsNullOrEmpty(sys_UserInfo.Tel) && string.IsNullOrEmpty(sys_UserInfo.Phone))
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						sys_UserInfo.RealName,
						" (",
						sys_UserInfo.DepName,
						")：固定电话:",
						sys_UserInfo.Tel,
						"\r\n"
					});
				}
			}
			base.Response.Clear();
			base.Response.ClearHeaders();
			base.Response.Buffer = false;
			base.Response.AppendHeader("Content-Disposition", "attachment;filename=" + str + ".txt");
			base.Response.ContentType = "application/vnd.txt";
			base.Response.Write(text);
			base.Response.Flush();
			base.Response.End();
		}
	}
