using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;

public partial class Manage_gov_Gov_Recipient : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlGenericControl wdpy;
        //protected HtmlGenericControl yjpy;
        //protected HtmlGenericControl wdsq;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page1;
		protected string flow_list = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				if (!string.IsNullOrEmpty(base.Request.QueryString["action"]))
				{
					this.Show(base.Request.QueryString["action"]);
				}
				else
				{
					base.Response.Write("<script>alert('非法的请求!');window.location='Gov_Recipient.aspx?action=archived'</script>");
				}
			}
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			string str = base.Request.Form["keyword"];
			string str2 = "?action=" + base.Request.QueryString["action"] + "&keywords=" + str;
			base.Response.Redirect("Gov_Recipient.aspx" + str2);
		}
		private void Show(string type)
		{
			SqlParameter sqlParameter = new SqlParameter();
			sqlParameter.ParameterName = "@uid";
			sqlParameter.Size = 50;
			sqlParameter.Value = this.Uid;
			SqlParameter sqlParameter2 = new SqlParameter();
			sqlParameter2.Direction = ParameterDirection.Output;
			sqlParameter2.ParameterName = "@pt1";
			sqlParameter2.Size = 4;
			SqlParameter sqlParameter3 = new SqlParameter();
			sqlParameter3.Direction = ParameterDirection.Output;
			sqlParameter3.ParameterName = "@pt2";
			sqlParameter3.Size = 4;
			SqlParameter sqlParameter4 = new SqlParameter();
			sqlParameter4.Direction = ParameterDirection.Output;
			sqlParameter4.ParameterName = "@pt3";
			sqlParameter4.Size = 4;
			SqlParameter[] cmdParms = new SqlParameter[]
			{
				sqlParameter2,
				sqlParameter3,
				sqlParameter4,
				sqlParameter
			};
			MsSqlOperate.ExecuteNonQuery(CommandType.StoredProcedure, "Gov_GetRecipientCount", cmdParms);
			this.wdpy.InnerText = string.Concat(sqlParameter2.Value);
			this.yjpy.InnerText = string.Concat(sqlParameter3.Value);
			this.wdsq.InnerText = string.Concat(sqlParameter4.Value);
			if (type == "verify")
			{
				this.flow_list = ">> 公文签收";
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
						goto IL_216;
					}
				}
				cmdText = "select a.* from Gov a,Gov_Recipient b where a.id=b.Flow_ID and a.status=1 and b.sign=0 and b.UserID=" + this.Uid + " order by a.id desc";
				using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
				{
					this.CutPage(dataSet, "verify");
				}
			}
			IL_216:
			if (type == "verified")
			{
				this.flow_list = ">> 已签收公文";
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
						goto IL_32E;
					}
				}
				cmdText = "select a.* from Gov a,Gov_Recipient b where a.id=b.Flow_ID and a.status=1 and b.sign=1 and b.UserID=" + this.Uid + " order by a.id desc";
				using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
				{
					this.CutPage(dataSet, "verified");
				}
			}
			IL_32E:
			if (type == "archived")
			{
				this.flow_list = ">> 已归档公文";
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
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + ds.Tables[0].Rows.Count + "</span> 条 记录数据";
		}
		protected string GetStatus(object obj)
		{
			int num = Convert.ToInt32(obj);
			string result;
			if (num == 0)
			{
				if (base.Request.QueryString["action"] == "verify")
				{
					result = "<span style='color:#ff0000;'>待审批</span>";
				}
				else
				{
					result = "<span style='color:#ff0000;'>审批中</span>";
				}
			}
			else
			{
				if (num == 1)
				{
					result = "<span style='color:#006600;font-weight:bold'>已签发</span>";
				}
				else
				{
					if (num == -1)
					{
						result = "<span style='color:#999999;font-weight:bold'>已锁定</span>";
					}
					else
					{
						if (num == -2)
						{
							result = "<span style='color:black;font-weight:bold'>已退回</span>";
						}
						else
						{
							if (num == 5)
							{
								result = "<span style='color:black;font-weight:bold'>已归档</span>";
							}
							else
							{
								result = "<span style='color:blue;'>已过期</span>";
							}
						}
					}
				}
			}
			return result;
		}
		protected string GetTrTitle(object t)
		{
			string result = "";
			string text = base.Request.QueryString["action"];
			if (!string.IsNullOrEmpty(text))
			{
				if (text.ToLower().Contains("verify"))
				{
					result = "您需要签收的公文：" + t;
				}
				if (text.ToLower().Contains("verified"))
				{
					result = "您已经签收的公文：" + t;
				}
				if (text.ToLower().Contains("archived"))
				{
					result = "归档的公文：" + t;
				}
			}
			return result;
		}
		protected string GetSelected(string i)
		{
			string a = base.Request.QueryString["action"] ?? "";
			string result;
			if (a == (i ?? ""))
			{
				result = "class='selected'";
			}
			else
			{
				result = "";
			}
			return result;
		}
	}

