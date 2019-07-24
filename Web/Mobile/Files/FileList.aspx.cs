using System;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;

public partial class Mobile_Files_FileList : MobilePage

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page1;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["type"]))
			{
				base.Response.Redirect("FileList.aspx?action=" + base.Request.QueryString["type"] + "&keywords=" + HttpContext.Current.Server.HtmlEncode(base.Request.Form["keywords"]));
			}
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["action"]))
			{
				this.Show();
			}
		}
		private void Show()
		{
			int num = 30;
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
		protected string GetPrestr()
		{
			string a = base.Request.QueryString["action"];
			string result;
			if (a == "mydoc")
			{
				result = "我的文件";
			}
			else
			{
				if (a == "shared")
				{
					result = "同事共享";
				}
				else
				{
					result = "";
				}
			}
			return result;
		}
	}