using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;

public partial class Mobile_GovApp_AppList : MobilePage

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
				base.Response.Redirect("AppList.aspx?action=" + base.Request.QueryString["type"] + "&keywords=" + HttpContext.Current.Server.HtmlEncode(base.Request.Form["keywords"]));
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
				this.flow_list = "我的审批";
				string cmdText;
				if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
				{
					string text = base.Request.QueryString["keywords"];
					string text2 = string.Concat(new string[]
					{
						" (Flow_Name like '%",
						text,
						"%' or CreatorRealName like '%",
						text,
						"%' ) "
					});
					cmdText = string.Concat(new string[]
					{
						"select a.* from Gov a where a.status=0 and a.CurrentStepUserList like '%#",
						this.Uid,
						"#%' and a.CurrentStepID not in (select b.OperationStepID from Gov_StepAction b where b.UserID=",
						this.Uid,
						" and b.FlowID=a.id ) and ",
						text2
					});
					using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
					{
						this.CutPage(dataSet, "verify");
						goto IL_1D5;
					}
				}
				cmdText = string.Concat(new string[]
				{
					"select a.* from Gov a where a.status=0 and a.CurrentStepUserList like '%#",
					this.Uid,
					"#%' and a.CurrentStepID not in (select b.OperationStepID from Gov_StepAction b where b.UserID=",
					this.Uid,
					" and b.FlowID=a.id ) order by a.id desc"
				});
				if (!string.IsNullOrEmpty(base.Request.QueryString["td"]))
				{
					cmdText = string.Concat(new string[]
					{
						"select a.* from Gov a where a.comid=",
						base.Request.QueryString["td"],
						" and a.status=0 and a.CurrentStepUserList like '%#",
						this.Uid,
						"#%' and a.CurrentStepID not in (select b.OperationStepID from Gov_StepAction b where b.UserID=",
						this.Uid,
						" and b.FlowID=a.id ) order by a.id desc"
					});
				}
				using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
				{
					this.CutPage(dataSet, "verify");
				}
			}
			IL_1D5:
			if (type == "verified")
			{
				this.flow_list = "已经批阅";
				IList all;
				if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
				{
					string text = base.Request.QueryString["keywords"];
					string text2 = string.Concat(new string[]
					{
						"(Flow_Name like '%",
						text,
						"%' or CreatorRealName like '%",
						text,
						"%' ) and "
					});
					all = Gov.Init().GetAll(text2 + " HasOperatedUserList like '%#" + this.Uid + "#%'", "order by id desc");
				}
				else
				{
					if (string.IsNullOrEmpty(base.Request.QueryString["td"]))
					{
						all = Gov.Init().GetAll("HasOperatedUserList like '%#" + this.Uid + "#%'", "order by id desc");
					}
					else
					{
						all = Gov.Init().GetAll(string.Concat(new string[]
						{
							"comid=",
							base.Request.QueryString["td"],
							" and HasOperatedUserList like '%#",
							this.Uid,
							"#%'"
						}), "order by id desc");
					}
				}
				this.CutPage(all, "verified");
			}
			if (type == "apply")
			{
				this.flow_list = "我的发文";
				IList all;
				if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
				{
					string text = base.Request.QueryString["keywords"];
					string text2 = string.Concat(new string[]
					{
						"(Flow_Name like '%",
						text,
						"%' or CreatorRealName like '%",
						text,
						"%' ) and "
					});
					all = Gov.Init().GetAll(text2 + " CreatorID=" + this.Uid, "order by id desc");
				}
				else
				{
					if (string.IsNullOrEmpty(base.Request.QueryString["td"]))
					{
						all = Gov.Init().GetAll("CreatorID=" + this.Uid, "order by id desc");
					}
					else
					{
						all = Gov.Init().GetAll("comid=" + base.Request.QueryString["td"] + " and CreatorID=" + this.Uid, "order by id desc");
					}
				}
				this.CutPage(all, "apply");
			}
		}
		private void CutPage(IList list, string action)
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
			pagedDataSource.DataSource = list;
			pagedDataSource.AllowPaging = true;
			pagedDataSource.PageSize = pageSize;
			pagedDataSource.CurrentPageIndex = num - 1;
			this.rpt.DataSource = pagedDataSource;
			this.rpt.DataBind();
			if (string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
			{
				if (string.IsNullOrEmpty(base.Request.QueryString["td"]))
				{
					this.Page1.sty("meneame", num, pagedDataSource.PageCount, "?action=" + action + "&page=");
				}
				else
				{
					this.Page1.sty("meneame", num, pagedDataSource.PageCount, string.Concat(new string[]
					{
						"?action=",
						action,
						"&td=",
						base.Request.QueryString["td"],
						"&page="
					}));
				}
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
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + list.Count + "</span> 条 记录数据";
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
				if (string.IsNullOrEmpty(base.Request.QueryString["td"]))
				{
					this.Page1.sty("meneame", num, pagedDataSource.PageCount, "?action=" + action + "&page=");
				}
				else
				{
					this.Page1.sty("meneame", num, pagedDataSource.PageCount, string.Concat(new string[]
					{
						"?action=",
						action,
						"&td=",
						base.Request.QueryString["td"],
						"&page="
					}));
				}
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