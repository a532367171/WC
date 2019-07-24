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
using WC.Tool;
using WC.DK;

public partial class Manage_sys_User_List : ModulePages


	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected LinkButton LinkButton1;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page2;
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
			base.Response.Redirect("User_List.aspx" + str);
		}
		protected void Del_Btn(object obj, EventArgs e)
		{
			LinkButton linkButton = obj as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
			HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
			int num = Convert.ToInt32(htmlInputCheckBox.Value);
			//Help.DeleteIMUser(num);
			Sys_User.Init().Delete(num);
			this.DelUserDetail(string.Concat(num));
			this.Show();
		}
		protected void Del_All(object sender, EventArgs e)
		{
			foreach (RepeaterItem repeaterItem in this.rpt.Items)
			{
				HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
				if (htmlInputCheckBox.Checked)
				{
					int num = Convert.ToInt32(htmlInputCheckBox.Value);
					//Help.DeleteIMUser(num);
					Sys_User.Init().Delete(num);
					this.DelUserDetail(string.Concat(num));
				}
			}
			this.Show();
		}
		private void DelUserDetail(string u)
		{
			string text = "delete from Calendar where uid='" + u + "';";
			string text2 = "delete from Docs_Office where CreatorID=" + u + ";";
			string text3 = "delete from NoteBook where UserID=" + u + ";";
			string text4 = "delete from PhoneBook where UserID=" + u + ";";
			string text5 = "delete from Mails where ReceiverID=" + u + ";";
			string text6 = "delete from Docs_Doc where CreatorID=" + u + ";";
			string text7 = "delete from Docs_DocType where Uid=" + u + ";";
			MsSqlOperate.ExecuteNonQuery(CommandType.Text, string.Concat(new string[]
			{
				text,
				text2,
				text3,
				text4,
				text5,
				text6,
				text7
			}), new SqlParameter[0]);
			List<Sys_UserInfo> list = base.Application["user_online"] as List<Sys_UserInfo>;
			list.Find(delegate(Sys_UserInfo s)
			{
				bool result;
				if (s.id.ToString() == u)
				{
					s.IsOnline = 9;
					result = true;
				}
				else
				{
					result = false;
				}
				return result;
			});
		}
		private void Show()
		{
			Hashtable hashtable = (Hashtable)HttpContext.Current.Application["config_fenye"];
			int pageSize = Convert.ToInt32(hashtable["fenye_commom"]);
			IList list = Sys_User.Init().GetAll(null, "order by status asc,orders asc,id asc");
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
				list = Sys_User.Init().GetAll(where, "order by status asc,orders asc,id asc");
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

