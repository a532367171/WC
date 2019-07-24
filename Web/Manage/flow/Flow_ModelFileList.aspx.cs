using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;

public partial class Manage_flow_Flow_ModelFileList : ModulePages

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
			base.Response.Redirect("Flow_ModelFileList.aspx" + str);
		}
		protected void Del_Btn(object obj, EventArgs e)
		{
			LinkButton linkButton = obj as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
			HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
			int num = Convert.ToInt32(htmlInputCheckBox.Value);
			Flows_ModelFile.Init().Delete(num);
			string cmdText = "update Flows_Model set ModelFileID='0' where ModelFileID='" + num + "'";
			MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, null);
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
					Flows_ModelFile.Init().Delete(num);
					string cmdText = "update Flows_Model set ModelFileID='0' where ModelFileID='" + num + "'";
					MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, null);
				}
			}
			this.Show();
		}
		private void Show()
		{
			string text = "1=1";
			if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (FormTitle like '%",
					base.Request.QueryString["keywords"],
					"%' or FilePath like '%",
					base.Request.QueryString["keywords"],
					"%')"
				});
			}
			IList all = Flows_ModelFile.Init().GetAll(text, "order by id desc");
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
