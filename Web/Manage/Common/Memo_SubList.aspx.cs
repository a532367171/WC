using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;

public partial class Manage_Common_Memo_SubList : ViewPages

	{
		protected string uname = "";
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected HtmlInputText StartTime;
        //protected HtmlInputText EndTime;
        //protected LinkButton LinkButton1;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page1;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["uid"]))
			{
				this.Show(Convert.ToInt32(base.Request.QueryString["uid"]));
			}
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["uid"]))
			{
				string text = HttpContext.Current.Server.HtmlEncode(base.Request.Form["StartTime"].Trim());
				string text2 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["EndTime"].Trim());
				string str = string.Concat(new string[]
				{
					"?uid=",
					base.Request.QueryString["uid"],
					"&st=",
					text,
					"&et=",
					text2
				});
				base.Response.Redirect("Memo_SubList.aspx" + str);
			}
		}
		private void Show(int uid)
		{
			Sys_UserInfo byId = Sys_User.Init().GetById(uid);
			if (!byId.et6.Contains("#" + this.Uid + "#"))
			{
				base.Response.Write(string.Concat(new string[]
				{
					"<script>alert('您不是",
					byId.RealName,
					"(",
					byId.DepName,
					")的直接上级,无权查看他的工作日程');window.location='/manage/common/MyMemo.aspx'</script>"
				}));
			}
			this.uname = byId.RealName + " (" + byId.DepName + ")";
			int pageSize = 30;
			string text = " and 1=1 ";
			string text2 = base.Request.QueryString["st"];
			string text3 = base.Request.QueryString["et"];
			if (!string.IsNullOrEmpty(text2) && !string.IsNullOrEmpty(text3))
			{
				text2 = text2.Replace("-", "");
				text3 = text3.Replace("-", "");
				string text4 = text;
				text = string.Concat(new string[]
				{
					text4,
					" and (SUBSTRING(STime, 1, 8) between ",
					text2,
					" and ",
					text3,
					")"
				});
			}
			if (!string.IsNullOrEmpty(text2) && string.IsNullOrEmpty(text3))
			{
				text2 = text2.Replace("-", "");
				text = text + " and (SUBSTRING(STime, 1, 8) between " + text2 + " and CONVERT(varchar(50), GETDATE(), 112))";
			}
			if (string.IsNullOrEmpty(text2) && !string.IsNullOrEmpty(text3))
			{
				text3 = text3.Replace("-", "");
				text = text + " and (SUBSTRING(STime, 1, 8) between CONVERT(varchar(50), GETDATE(), 112) and " + text3 + ")";
			}
			string cmdText = string.Concat(new object[]
			{
				"SELECT DISTINCT SUBSTRING(STime, 1, 8) AS s FROM  Calendar where uid='",
				uid,
				"' ",
				text,
				" ORDER BY s DESC"
			});
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
			using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
			{
				this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + dataSet.Tables[0].Rows.Count + "</span> 条 记录数据 每页30条";
				pagedDataSource.DataSource = dataSet.Tables[0].DefaultView;
				pagedDataSource.AllowPaging = true;
				pagedDataSource.PageSize = pageSize;
				pagedDataSource.CurrentPageIndex = num - 1;
				this.rpt.DataSource = pagedDataSource;
				this.rpt.DataBind();
				if (!string.IsNullOrEmpty(base.Request.QueryString["st"]) && !string.IsNullOrEmpty(base.Request.QueryString["et"]))
				{
					this.Page1.sty("meneame", num, pagedDataSource.PageCount, string.Concat(new string[]
					{
						"?uid=",
						base.Request.QueryString["uid"],
						"&st=",
						base.Request.QueryString["st"],
						"&et=",
						base.Request.QueryString["et"],
						"&page="
					}));
				}
				else
				{
					this.Page1.sty("meneame", num, pagedDataSource.PageCount, "?uid=" + base.Request.QueryString["uid"] + "&page=");
				}
			}
		}
		protected string GetDate(object j)
		{
			string text = string.Concat(j);
			if (text.Length == 8 && Utils.IsNumber(text))
			{
				string a = string.Concat(new string[]
				{
					text.Substring(0, 4),
					"-",
					text.Substring(4, 2),
					"-",
					text.Substring(6, 2)
				});
				text = Utils.ConvertDate4(a);
			}
			return text;
		}
		protected void DownLoad(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["uid"]))
			{
				string text = "";
				string text2 = "Memo_Download.aspx?uid=" + base.Request.QueryString["uid"] + "&tt={0}";
				foreach (RepeaterItem repeaterItem in this.rpt.Items)
				{
					HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
					if (htmlInputCheckBox.Checked)
					{
						text = text + htmlInputCheckBox.Value + ";";
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					text2 = string.Format(text2, text);
					base.Response.Redirect(text2);
				}
			}
		}
	}
