using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;

public partial class Manage_flow_Flow_ModelList : ModulePages

{
	
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected LinkButton LinkButton1;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected HtmlGenericControl Span1;
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
			base.Response.Redirect("Flow_ModelList.aspx" + str);
		}
		protected void Del_Btn(object obj, EventArgs e)
		{
			LinkButton linkButton = obj as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
			HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
			int num = Convert.ToInt32(htmlInputCheckBox.Value);
			string cmdText = "delete from Flows_Model where id=" + num;
			string cmdText2 = "delete from Flows_ModelStep where Flow_ModelID=" + num;
			MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
			MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText2, new SqlParameter[0]);
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
					string cmdText = "delete from Flows_Model where id=" + num;
					string cmdText2 = "delete from Flows_ModelStep where Flow_ModelID=" + num;
					MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
					MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText2, new SqlParameter[0]);
				}
			}
			this.Show();
		}
		private void Show()
		{
			string text = "1=1";
			if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
			{
				text = text + " and (Flow_Name like '%" + base.Request.QueryString["keywords"] + "%' )";
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["td"]))
			{
				text = text + " and (comid =" + base.Request.QueryString["td"] + " )";
			}
			IList all = Flows_Model.Init().GetAll(text, "order by id desc");
			int pageSize = 50;
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
			pagedDataSource.DataSource = all;
			pagedDataSource.AllowPaging = true;
			pagedDataSource.PageSize = pageSize;
			pagedDataSource.CurrentPageIndex = num - 1;
			this.rpt.DataSource = pagedDataSource;
			this.rpt.DataBind();
			if (string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
			{
				this.Page2.sty("meneame", num, pagedDataSource.PageCount, "?page=");
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
			{
				this.Page2.sty("meneame", num, pagedDataSource.PageCount, "?keywords=" + base.Request.QueryString["keywords"] + "&page=");
			}
			this.rpt.DataSource = pagedDataSource;
			this.rpt.DataBind();
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + all.Count + "</span> 条 记录数据";
		}
	}

