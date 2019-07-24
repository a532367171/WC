using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.DK;

public partial class Manage_Common_WorkLog_List : ViewPages


	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected HtmlInputText TaskName;
        //protected HtmlInputText StartTime;
        //protected HtmlInputText EndTime;
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
		protected void Search_Btn(object sender, EventArgs e)
		{
			string text = HttpContext.Current.Server.HtmlEncode(base.Request.Form["TaskName"].Trim());
			string text2 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["StartTime"].Trim());
			string text3 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["EndTime"].Trim());
			string text4 = base.Request.QueryString["action"];
			if (!string.IsNullOrEmpty(text4))
			{
				string str = string.Concat(new string[]
				{
					"?action=",
					text4,
					"&keywords=",
					HttpContext.Current.Server.HtmlEncode(text.Trim()),
					"&StartTime=",
					text2,
					"&EndTime=",
					text3
				});
				base.Response.Redirect("WorkLog_List.aspx" + str);
			}
		}
		protected void RowDataBind(object sender, RepeaterItemEventArgs e)
		{
			Label label = e.Item.FindControl("c") as Label;
			Panel panel = e.Item.FindControl("d") as Panel;
			if (label.Text == this.Uid)
			{
				panel.Visible = true;
			}
		}
		protected void Del_Btn(object obj, EventArgs e)
		{
			LinkButton linkButton = obj as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent.Parent as RepeaterItem;
			Panel panel = repeaterItem.FindControl("d") as Panel;
			if (panel.Visible)
			{
				HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
				int id = Convert.ToInt32(htmlInputCheckBox.Value);
				WorkLogInfo byId = WorkLog.Init().GetById(id);
				Help.DeleteFiles(byId.FilePath);
				WorkLog.Init().Delete(id);
				this.Show();
			}
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
			string text3 = base.Request.QueryString["StartTime"];
			string text4 = base.Request.QueryString["EndTime"];
			string text5 = "";
			if (text2 == "mydoc")
			{
				text5 = " CreatorID=" + this.Uid;
				if (!string.IsNullOrEmpty(text))
				{
					string text6 = text5;
					text5 = string.Concat(new string[]
					{
						text6,
						" and (LogTitle like '%",
						text,
						"%' or CreatorRealName like '%",
						text,
						"%') "
					});
				}
				if (!string.IsNullOrEmpty(text3) && !string.IsNullOrEmpty(text4))
				{
					string text6 = text5;
					text5 = string.Concat(new string[]
					{
						text6,
						" and (AddTime between '",
						text3,
						"' and '",
						text4,
						"') "
					});
				}
			}
			if (text2 == "shared")
			{
				text5 = string.Concat(new string[]
				{
					" (CreatorID<>",
					this.Uid,
					" and ShareUsers like '%#",
					this.Uid,
					"#%') "
				});
				if (!string.IsNullOrEmpty(text))
				{
					string text6 = text5;
					text5 = string.Concat(new string[]
					{
						text6,
						" and (LogTitle like '%",
						text,
						"%' or CreatorRealName like '%",
						text,
						"%') "
					});
				}
				if (!string.IsNullOrEmpty(text3) && !string.IsNullOrEmpty(text4))
				{
					string text6 = text5;
					text5 = string.Concat(new string[]
					{
						text6,
						" and (AddTime between '",
						text3,
						"' and '",
						text4,
						"') "
					});
				}
			}
			int num4 = Convert.ToInt32(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(id) from WorkLog where " + text5, null));
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + num4 + "</span> 条 记录数据";
			string sql = string.Concat(new object[]
			{
				"select top ",
				num,
				" * from WorkLog where ",
				text5,
				" order by id desc"
			});
			if (num2 != 1)
			{
				sql = string.Concat(new object[]
				{
					"SELECT TOP ",
					num,
					" * FROM WorkLog WHERE id<(SELECT MIN(id) FROM (SELECT TOP ",
					num3.ToString(),
					" id FROM WorkLog WHERE (",
					text5,
					" ) ORDER BY id DESC) T1) AND (",
					text5,
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
	}
