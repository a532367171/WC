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
using WC.DK;

public partial class Manage_CRM_CRM_List : ViewPages

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
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["action"]))
			{
				this.Show();
			}
		}
		protected void RowDataBind(object sender, RepeaterItemEventArgs e)
		{
			Panel panel = e.Item.FindControl("d") as Panel;
			if (base.Request.QueryString["action"] == "mycrm")
			{
				panel.Visible = true;
			}
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			string text = base.Request.Form["keyword"];
			string text2 = base.Request.QueryString["action"];
			if (!string.IsNullOrEmpty(text2) && !string.IsNullOrEmpty(text))
			{
				string str = "?action=" + text2 + "&keywords=" + HttpContext.Current.Server.HtmlEncode(text.Trim());
				base.Response.Redirect("CRM_List.aspx" + str);
			}
		}
		protected void Del_Btn(object obj, EventArgs e)
		{
			LinkButton linkButton = obj as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent.Parent as RepeaterItem;
			HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
			int num = Convert.ToInt32(htmlInputCheckBox.Value);
			CRMInfo byId = CRM.Init().GetById(num);
			Help.DeleteFiles(byId.FilePath);
			string cmdText = "delete from CRM_Contact where cid=" + num;
			MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
			CRM.Init().Delete(num);
			this.Show();
		}
		private void Show()
		{
			Hashtable hashtable = (Hashtable)HttpContext.Current.Application["config_fenye"];
			int num = Convert.ToInt32(hashtable["fenye_commom"]);
			int num2 = 0;
			try
			{
				if (!string.IsNullOrEmpty(base.Request.QueryString["page"]))
				{
					num2 = Convert.ToInt32(base.Request.QueryString["page"]);
				}
			}
			catch
			{
			}
			if (num2 == 0)
			{
				num2 = 1;
			}
			int num3 = num * (num2 - 1);
			string text = base.Request.QueryString["keywords"];
			string text2 = base.Request.QueryString["action"];
			string text3 = "";
			if (text2 == "mycrm")
			{
				if (!string.IsNullOrEmpty(text))
				{
					text3 = string.Concat(new string[]
					{
						" CreatorID=",
						this.Uid,
						" and (CRM_Name like '%",
						text,
						"%' or MainPeople like '%",
						text,
						"%' or grade like '%",
						text.ToUpper(),
						"%' ) "
					});
				}
				else
				{
					text3 = " CreatorID=" + this.Uid;
					if (!string.IsNullOrEmpty(base.Request.QueryString["g"]))
					{
						text3 = string.Concat(new string[]
						{
							" CreatorID=",
							this.Uid,
							" and Grade='",
							base.Request.QueryString["g"],
							"'"
						});
					}
				}
			}
			if (text2 == "shared")
			{
				if (!string.IsNullOrEmpty(text))
				{
					text3 = string.Concat(new string[]
					{
						" CreatorID<>",
						this.Uid,
						" and IsShare=1 and ShareUsers like '%#",
						this.Uid,
						"#%'  and (CRM_Name like '%",
						text,
						"%' or MainPeople like '%",
						text,
						"%' or grade like '%",
						text.ToUpper(),
						"%' ) "
					});
				}
				else
				{
					text3 = string.Concat(new string[]
					{
						" CreatorID<>",
						this.Uid,
						" and IsShare=1 and ShareUsers like '%#",
						this.Uid,
						"#%' "
					});
				}
			}
			int num4 = Convert.ToInt32(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(*) from CRM where " + text3, null));
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + num4 + "</span> 条 记录数据";
			string sql = string.Concat(new object[]
			{
				"select top ",
				num,
				" * from CRM where ",
				text3,
				" order by id desc"
			});
			if (num2 != 1)
			{
				sql = string.Concat(new object[]
				{
					"SELECT TOP ",
					num,
					" * FROM CRM WHERE id<(SELECT MIN(id) FROM (SELECT TOP ",
					num3.ToString(),
					" id FROM CRM WHERE (",
					text3,
					" ) ORDER BY id DESC) T1) AND (",
					text3,
					" ) ORDER BY id DESC"
				});
			}
			this.Bind(sql, this.rpt);
			if (string.IsNullOrEmpty(text))
			{
				this.Page1.sty("meneame", num2, this.GetCountPage(num4, num), "?action=" + text2 + "&page=");
			}
			else
			{
				this.Page1.sty("meneame", num2, this.GetCountPage(num4, num), string.Concat(new string[]
				{
					"?action=",
					text2,
					"&keywords=",
					text,
					"&page="
				}));
			}
		}
		private int GetCountPage(int count, int pageSize)
		{
			int result;
			if (count <= pageSize)
			{
				result = 1;
			}
			else
			{
				if (count % pageSize == 0)
				{
					result = count / pageSize;
				}
				else
				{
					result = count / pageSize + 1;
				}
			}
			return result;
		}
		private void Bind(string sql, Repeater r)
		{
			using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, sql, null))
			{
				r.DataSource = dataSet.Tables[0].DefaultView;
				r.DataBind();
			}
		}
		protected string GetGrade(object obj)
		{
			string text = string.Concat(obj);
			text = text.ToUpper();
			string result = "";
			if (text == "A")
			{
				result = "暂无需求，潜在培养的客户";
			}
			if (text == "B")
			{
				result = "有需求，正在跟进客户";
			}
			if (text == "C")
			{
				result = "短期可签入的客户";
			}
			if (text == "D")
			{
				result = "已签约客户/老客户";
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