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

public partial class Manage_Mail_List : ViewPages

	{
		protected string mail_tags = "";
		protected string fid = "0";
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected LinkButton lb1;
        //protected LinkButton lb2;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected LinkButton LinkButton1;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page1;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["fid"]))
			{
				this.fid = base.Request.QueryString["fid"];
				string text = this.fid;
				if (text != null)
				{
					if (text == "0")
					{
						this.mail_tags = "收件箱";
						goto IL_BD;
					}
					if (text == "1")
					{
						this.mail_tags = "草稿箱";
						goto IL_BD;
					}
					if (text == "2")
					{
						this.mail_tags = "发件箱";
						goto IL_BD;
					}
					if (text == "3")
					{
						this.mail_tags = "垃圾箱";
						goto IL_BD;
					}
				}
				this.mail_tags = "收件箱";
			}
			IL_BD:
			if (!base.IsPostBack)
			{
				if (!string.IsNullOrEmpty(base.Request.QueryString["fid"]) && !string.IsNullOrEmpty(this.Uid))
				{
					this.Show(base.Request.QueryString["fid"]);
				}
				else
				{
					base.Response.Write("<script>alert('您查找的链接不存在!');window.location='../DeskTop.aspx';</script>");
				}
			}
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			string str = base.Request.Form["keyword"];
			string str2 = "?fid=" + base.Request.QueryString["fid"] + "&keywords=" + str;
			base.Response.Redirect("Mail_List.aspx" + str2);
		}
		protected void Del_All(object sender, EventArgs e)
		{
			foreach (RepeaterItem repeaterItem in this.rpt.Items)
			{
				HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
				if (htmlInputCheckBox.Checked)
				{
					int id = Convert.ToInt32(htmlInputCheckBox.Value);
					Mails.Init().Delete(id);
				}
			}
			string str = HttpContext.Current.Server.HtmlEncode("您好!邮件已彻底删除!");
			base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
		}
		protected void MoveToLJ(object sender, EventArgs e)
		{
			if (base.Request.QueryString["fid"] != "3")
			{
				foreach (RepeaterItem repeaterItem in this.rpt.Items)
				{
					HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
					if (htmlInputCheckBox.Checked)
					{
						int num = Convert.ToInt32(htmlInputCheckBox.Value);
						string cmdText = "update mails set FolderType=3 where id=" + num;
						MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
					}
				}
				string str = HttpContext.Current.Server.HtmlEncode("您好!邮件已删除至垃圾箱!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
		}
		private void Show(string fid)
		{
			Hashtable hashtable = (Hashtable)HttpContext.Current.Application["config_fenye"];
			int num = Convert.ToInt32(hashtable["fenye_mail"]);
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
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + num4 + "</span> 条 记录数据";
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
				this.Page2.sty("meneame", num2, this.GetCountPage(num4, num), "?fid=" + base.Request.QueryString["fid"] + "&page=");
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
			{
				this.Page2.sty("meneame", num2, this.GetCountPage(num4, num), string.Concat(new string[]
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
		protected string GetSendTypeName(object obj)
		{
			string result = "";
			string a = Convert.ToString(obj);
			if (a == "1")
			{
				result = "[草稿]&nbsp;&nbsp;";
			}
			if (a == "2")
			{
				result = "[抄送]&nbsp;&nbsp;";
			}
			if (a == "3")
			{
				result = "[密送]&nbsp;&nbsp;";
			}
			if (a == "4")
			{
				result = "[已发送]&nbsp;&nbsp;";
			}
			return result;
		}
		protected string GetSelected(int i)
		{
			string a = base.Request.QueryString["fid"] ?? "";
			string result;
			if (a == string.Concat(i))
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
