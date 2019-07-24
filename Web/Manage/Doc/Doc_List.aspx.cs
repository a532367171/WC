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
public partial class Manage_Doc_Doc_List : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page2;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["action"]))
			{
				this.Show();
			}
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			string text = base.Request.Form["keyword"];
			string text2 = base.Request.QueryString["action"];
			if (!string.IsNullOrEmpty(text2) && !string.IsNullOrEmpty(text))
			{
				string str = "?action=" + text2 + "&keywords=" + HttpContext.Current.Server.HtmlEncode(text.Trim());
				base.Response.Redirect("Doc_List.aspx" + str);
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
				Docs_DocInfo byId = Docs_Doc.Init().GetById(id);
				Help.DeleteFiles(byId.FilePath);
				Docs_Doc.Init().Delete(id);
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
			string text3 = "";
			if (text2 == "mydoc")
			{
				if (!string.IsNullOrEmpty(text))
				{
					text3 = string.Concat(new string[]
					{
						" CreatorID=",
						this.Uid,
						" and (DocTitle like '%",
						text,
						"%' or CreatorRealName like '%",
						text,
						"%' ) "
					});
				}
				else
				{
					text3 = " CreatorID=" + this.Uid;
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["type"]))
				{
					text3 = " CreatorID=" + this.Uid + " and DocTypeID=" + base.Request.QueryString["type"];
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
						"#%'  and (DocTitle like '%",
						text,
						"%' or CreatorRealName like '%",
						text,
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
			int num4 = Convert.ToInt32(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(*) from Docs_Doc where " + text3, null));
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + num4 + "</span> 条 记录数据";
			string sql = string.Concat(new object[]
			{
				"select top ",
				num,
				" * from Docs_Doc where ",
				text3,
				" order by id desc"
			});
			if (num2 != 1)
			{
				sql = string.Concat(new object[]
				{
					"SELECT TOP ",
					num,
					" * FROM Docs_Doc WHERE id<(SELECT MIN(id) FROM (SELECT TOP ",
					num3.ToString(),
					" id FROM Docs_Doc WHERE (",
					text3,
					" ) ORDER BY id DESC) T1) AND (",
					text3,
					" ) ORDER BY id DESC"
				});
			}
			this.Bind(sql, this.rpt);
			if (string.IsNullOrEmpty(text))
			{
				this.Page2.sty("meneame", num2, this.GetCountPage(num4, num), "?action=" + text2 + "&page=");
			}
			else
			{
				this.Page2.sty("meneame", num2, this.GetCountPage(num4, num), string.Concat(new string[]
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
		protected string GetDocType(object DocTypeID)
		{
			string result;
			try
			{
				int num = Convert.ToInt32(DocTypeID);
				if (num == 0)
				{
					result = "默认分类";
				}
				else
				{
					IList all = Docs_DocType.Init().GetAll("id=" + num, null);
					if (all != null)
					{
						Docs_DocTypeInfo docs_DocTypeInfo = all[0] as Docs_DocTypeInfo;
						result = docs_DocTypeInfo.TypeName;
					}
					else
					{
						result = "";
					}
				}
			}
			catch
			{
				result = "默认分类";
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
