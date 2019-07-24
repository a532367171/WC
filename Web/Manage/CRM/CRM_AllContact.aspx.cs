using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Tool;

public partial class Manage_CRM_CRM_AllContact : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected LinkButton LinkButton1;
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
		protected void Del_Btn(object obj, EventArgs e)
		{
			LinkButton linkButton = obj as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
			HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
			int id = Convert.ToInt32(htmlInputCheckBox.Value);
			CRM_Contact.Init().Delete(id);
			this.Show();
		}
		protected void Del_All(object sender, EventArgs e)
		{
			foreach (RepeaterItem repeaterItem in this.rpt.Items)
			{
				HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
				if (htmlInputCheckBox.Checked)
				{
					int id = Convert.ToInt32(htmlInputCheckBox.Value);
					CRM_Contact.Init().Delete(id);
				}
			}
			this.Show();
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			string text = base.Request.Form["keyword"];
			string str = "?keywords=" + HttpContext.Current.Server.HtmlEncode(text.Trim());
			base.Response.Redirect("CRM_AllContact.aspx" + str);
		}
		private void Show()
		{
			Hashtable hashtable = (Hashtable)HttpContext.Current.Application["config_fenye"];
			int pageSize = Convert.ToInt32(hashtable["fenye_commom"]);
			string text = "1=1";
			string text2 = base.Request.QueryString["keywords"];
			if (!string.IsNullOrEmpty(text2) && Utils.CheckSql(text2))
			{
				text = string.Concat(new string[]
				{
					" (a.CRM_Name like '%",
					text2,
					"%' or b.ContactAim like '%",
					text2,
					"%') "
				});
			}
			string cmdText = string.Concat(new string[]
			{
				"select a.id as crmid,a.CRM_Name as crm,b.id as contactid,b.ContactAim as ContactTitle,b.addtime as ContactTime from crm a,crm_contact b where a.id=b.cid and a.CreatorID=",
				this.Uid,
				" and ",
				text,
				" order by b.id desc"
			});
			DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]);
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
			pagedDataSource.DataSource = dataSet.Tables[0].DefaultView;
			pagedDataSource.AllowPaging = true;
			pagedDataSource.PageSize = pageSize;
			pagedDataSource.CurrentPageIndex = num - 1;
			this.rpt.DataSource = pagedDataSource;
			this.rpt.DataBind();
			if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
			{
				this.Page1.sty("meneame", num, pagedDataSource.PageCount, "?keywords=" + base.Request.QueryString["keywords"] + "&page=");
			}
			else
			{
				this.Page1.sty("meneame", num, pagedDataSource.PageCount, "?page=");
			}
			this.rpt.DataSource = pagedDataSource;
			this.rpt.DataBind();
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + dataSet.Tables[0].Rows.Count + "</span> 条 记录数据";
			dataSet.Dispose();
		}
	}

