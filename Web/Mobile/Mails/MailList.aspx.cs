using System;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Tool;

public partial class Mobile_Mails_MailList : MobilePage

	{
		protected string mail_tags = "";
		protected string fid = "0";
		protected string t = "";
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page1;
		protected void Page_Load(object sender, EventArgs e)
		{
			this.t = ((!string.IsNullOrEmpty(base.Request.QueryString["fid"])) ? base.Request.QueryString["fid"] : "0");
			if (!string.IsNullOrEmpty(base.Request.QueryString["fid"]))
			{
				this.fid = base.Request.QueryString["fid"];
				string text = this.fid;
				if (text != null)
				{
					if (text == "0")
					{
						this.mail_tags = "收件箱";
						goto IL_FB;
					}
					if (text == "1")
					{
						this.mail_tags = "草稿箱";
						goto IL_FB;
					}
					if (text == "2")
					{
						this.mail_tags = "发件箱";
						goto IL_FB;
					}
					if (text == "3")
					{
						this.mail_tags = "垃圾箱";
						goto IL_FB;
					}
				}
				this.mail_tags = "收件箱";
			}
			IL_FB:
			if (!string.IsNullOrEmpty(base.Request.QueryString["type"]))
			{
				base.Response.Redirect("MailList.aspx?fid=" + base.Request.QueryString["type"] + "&keywords=" + HttpContext.Current.Server.HtmlEncode(base.Request.Form["keywords"]));
			}
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["fid"]))
			{
				this.Show(base.Request.QueryString["fid"]);
			}
		}
		private void Show(string fid)
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
			string text = "FolderType=" + fid + " and ReceiverID=" + this.Uid;
			string text2 = base.Request.QueryString["keywords"];
			if (!string.IsNullOrEmpty(text2) && Utils.CheckSql(text2))
			{
				string text3 = text;
				text = string.Concat(new string[]
				{
					text3,
					" and (SenderRealName like '%",
					text2,
					"%' or SenderDepName like '%",
					text2,
					"%' or Subject like '%",
					text2,
					"%') "
				});
			}
			int num4 = Convert.ToInt32(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(*) from Mails where " + text, null));
			this.num.InnerHtml = "当前总计 - <span style='color:#ff0000; font-weight:bold;'>" + num4 + "</span> 条 记录数据";
			string sql = string.Concat(new object[]
			{
				"select top ",
				num,
				" * from Mails where ",
				text,
				" order by id desc"
			});
			if (num2 != 1)
			{
				sql = string.Concat(new object[]
				{
					"SELECT TOP ",
					num,
					" * FROM Mails WHERE id<(SELECT MIN(id) FROM (SELECT TOP ",
					num3.ToString(),
					" id FROM Mails WHERE (",
					text,
					" ) ORDER BY id DESC) T1) AND (",
					text,
					" ) ORDER BY id DESC"
				});
			}
			this.Bind(sql, this.rpt);
			if (string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
			{
				this.Page1.sty("meneame", num2, this.GetCountPage(num4, num), "?fid=" + base.Request.QueryString["fid"] + "&page=");
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
			{
				this.Page1.sty("meneame", num2, this.GetCountPage(num4, num), string.Concat(new string[]
				{
					"?fid=",
					base.Request.QueryString["fid"],
					"&keywords=",
					text2,
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