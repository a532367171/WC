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

public partial class Manage_Common_Vote_AllList : ModulePages

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
			base.Response.Redirect("Vote_AllList.aspx" + str);
		}
		protected void RowDataBind(object sender, RepeaterItemEventArgs e)
		{
			Label arg_15_0 = e.Item.FindControl("c") as Label;
			Panel panel = e.Item.FindControl("d") as Panel;
			panel.Visible = true;
		}
		protected void Del_Btn(object obj, EventArgs e)
		{
			LinkButton linkButton = obj as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent.Parent as RepeaterItem;
			Panel panel = repeaterItem.FindControl("d") as Panel;
			if (panel.Visible)
			{
				HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
				int num = Convert.ToInt32(htmlInputCheckBox.Value);
				string cmdText = "delete from VoteDetail where VoteID=" + num;
				MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
				Vote.Init().Delete(num);
				base.Response.Redirect("Vote_AllList.aspx");
			}
		}
		protected void Valide_Btn(object sender, EventArgs e)
		{
			LinkButton linkButton = sender as LinkButton;
			string value = linkButton.CommandArgument.ToString();
			VoteInfo byId = Vote.Init().GetById(Convert.ToInt32(value));
			byId.IsValide = Math.Abs(byId.IsValide - 1);
			Vote.Init().Update(byId);
			base.Response.Redirect("Vote_AllList.aspx");
		}
		private void Show()
		{
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
			string text = base.Request.QueryString["keywords"];
			string where = "1=1";
			if (!string.IsNullOrEmpty(text))
			{
				where = "VoteTitle like '%" + text + "%' ";
			}
			IList all = Vote.Init().GetAll(where, "order by id desc");
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + all.Count + "</span> 条 记录数据";
			pagedDataSource.DataSource = all;
			pagedDataSource.AllowPaging = true;
			pagedDataSource.PageSize = pageSize;
			pagedDataSource.CurrentPageIndex = num - 1;
			this.rpt.DataSource = pagedDataSource;
			this.rpt.DataBind();
			if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
			{
				this.Page1.sty("meneame", num, pagedDataSource.PageCount, "?keywords=" + text + "&page=");
			}
			else
			{
				this.Page1.sty("meneame", num, pagedDataSource.PageCount, "?page=");
			}
		}
	}
