using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;

public partial class Mobile_GovRec_RecList : MobilePage

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page1;
		protected string flow_list = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["type"]))
			{
				base.Response.Redirect("RecList.aspx?action=" + base.Request.QueryString["type"] + "&keywords=" + HttpContext.Current.Server.HtmlEncode(base.Request.Form["keywords"]));
			}
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["action"]))
			{
				this.Show(base.Request.QueryString["action"]);
			}
		}
		private void Show(string type)
		{
			if (type == "verify")
			{
				this.flow_list = "公文签收";
				string cmdText;
				if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
				{
					string text = base.Request.QueryString["keywords"];
					string str = string.Concat(new string[]
					{
						" and (a.Flow_Name like '%",
						text,
						"%' or a.CreatorRealName like '%",
						text,
						"%' ) "
					});
					cmdText = "select a.* from Gov a,Gov_Recipient b where a.id=b.Flow_ID and a.status=1 and b.sign=0 and b.UserID=" + this.Uid + str + " order by a.id desc";
					using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
					{
						this.CutPage(dataSet, "verify");
						goto IL_112;
					}
				}
				cmdText = "select a.* from Gov a,Gov_Recipient b where a.id=b.Flow_ID and a.status=1 and b.sign=0 and b.UserID=" + this.Uid + " order by a.id desc";
				using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
				{
					this.CutPage(dataSet, "verify");
				}
			}
			IL_112:
			if (type == "verified")
			{
				this.flow_list = "已签收公文";
				string cmdText;
				if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
				{
					string text = base.Request.QueryString["keywords"];
					string str = string.Concat(new string[]
					{
						" and (a.Flow_Name like '%",
						text,
						"%' or a.CreatorRealName like '%",
						text,
						"%' ) "
					});
					cmdText = "select a.* from Gov a,Gov_Recipient b where a.id=b.Flow_ID and a.status=1 and b.sign=1 and b.UserID=" + this.Uid + str + " order by a.id desc";
					using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
					{
						this.CutPage(dataSet, "verified");
						goto IL_21E;
					}
				}
				cmdText = "select a.* from Gov a,Gov_Recipient b where a.id=b.Flow_ID and a.status=1 and b.sign=1 and b.UserID=" + this.Uid + " order by a.id desc";
				using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
				{
					this.CutPage(dataSet, "verified");
				}
			}
			IL_21E:
			if (type == "archived")
			{
				this.flow_list = "已归档公文";
				string cmdText;
				if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
				{
					string text = base.Request.QueryString["keywords"];
					string str = string.Concat(new string[]
					{
						" and (a.Flow_Name like '%",
						text,
						"%' or a.CreatorRealName like '%",
						text,
						"%' ) "
					});
					cmdText = "select a.* from Gov a,Gov_Recipient b where a.id=b.Flow_ID and a.status=5 and b.UserID=" + this.Uid + str + " order by a.id desc";
					using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
					{
						this.CutPage(dataSet, "verified");
						return;
					}
				}
				cmdText = "select a.* from Gov a,Gov_Recipient b where a.id=b.Flow_ID and a.status=5 and b.UserID=" + this.Uid + " order by a.id desc";
				using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
				{
					this.CutPage(dataSet, "archived");
				}
			}
		}
		private void CutPage(DataSet ds, string action)
		{
			int pageSize = 30;
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
			pagedDataSource.DataSource = ds.Tables[0].DefaultView;
			pagedDataSource.AllowPaging = true;
			pagedDataSource.PageSize = pageSize;
			pagedDataSource.CurrentPageIndex = num - 1;
			this.rpt.DataSource = pagedDataSource;
			this.rpt.DataBind();
			if (string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
			{
				this.Page1.sty("meneame", num, pagedDataSource.PageCount, "?action=" + action + "&page=");
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
			{
				this.Page1.sty("meneame", num, pagedDataSource.PageCount, string.Concat(new string[]
				{
					"?action=",
					action,
					"&keywords=",
					base.Request.QueryString["keywords"],
					"&page="
				}));
			}
			this.rpt.DataSource = pagedDataSource;
			this.rpt.DataBind();
			this.num.InnerHtml = "当前总计 - <span style='color:#ff0000; font-weight:bold;'>" + ds.Tables[0].Rows.Count + "</span> 条 记录数据";
		}
	}