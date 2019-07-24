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
using WC.DK;

public partial class Manage_Common_Mail_View : ViewPages

	{
        //protected HtmlForm form1;
        //protected LinkButton lb1;
        //protected LinkButton lb2;
        //protected HtmlGenericControl Subject;
        //protected HtmlGenericControl Sender;
        //protected HtmlGenericControl Sendtime;
        //protected HtmlGenericControl sjr;
        //protected HtmlGenericControl bodys;
        //protected Button bt;
		protected string mid = "";
		protected string bet = "";
		protected string fjs = "";
		protected string fj = "<span style='font-weight:bold;'>{1}</span> &nbsp;&nbsp;&nbsp;&nbsp;<a href='/Manage/Utils/Download.aspx?destFileName={0}' ><img src='/img/mail_attachment.gif' />下载附件</a><br>";
		protected string csr = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (base.Request.QueryString["fid"] == "1")
			{
				base.Response.Write("<script>window.location='Mail_Manage.aspx?cid=" + base.Request.QueryString["mid"] + "'</script>");
			}
			else
			{
				if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["mid"]))
				{
					this.Show(base.Request.QueryString["mid"]);
				}
			}
		}
		private void Show(string id)
		{
			this.mid = id;
			MailsInfo byId = Mails.Init().GetById(Convert.ToInt32(this.mid));
			if (byId.ReceiverID == Convert.ToInt32(this.Uid) || byId.SenderID == Convert.ToInt32(this.Uid))
			{
				Mails_DetailInfo byId2 = Mails_Detail.Init().GetById(byId.did);
				this.Subject.InnerText = byId.Subject;
				this.Sender.InnerText = byId.SenderRealName + " (" + byId.SenderDepName + ")";
				this.bet = byId.ReceiverID + ";" + byId.SenderID;
				this.Sendtime.InnerText = Utils.ConvertDate2(byId.SendTime) + " (" + Utils.GetDayOfWeek(byId.SendTime) + ")";
				this.sjr.InnerText = Utils.GetSubString2(byId2.SendRealNames, 250, "...");
				if (!string.IsNullOrEmpty(byId2.CcRealNames))
				{
					this.csr = "<br><span style='font-weight:bold; color:#006600;'>抄送人</span>：" + Utils.GetSubString2(byId2.CcRealNames, 250, "...");
				}
				if (!string.IsNullOrEmpty(byId2.Attachments))
				{
					this.fjs = "<br><span style='font-weight:bold; color:#006600;'>附 &nbsp;&nbsp;&nbsp;件</span>：";
					string[] array = byId2.Attachments.Split(new char[]
					{
						'|'
					});
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i].Trim() != "")
						{
							int num = array[i].LastIndexOf('/') + 1;
							string arg = array[i].Substring(num, array[i].Length - num);
							string s = array[i].Replace("~", "");
							this.fjs += string.Format(this.fj, base.Server.UrlEncode(s), arg);
						}
					}
				}
				byId2.Bodys = (byId2.Bodys ?? "");
				if (byId2.Bodys.ToLower().Contains("script"))
				{
					this.bodys.InnerHtml = byId2.Bodys.ToLower().Replace("script", "scrript");
				}
				else
				{
					this.bodys.InnerHtml = byId2.Bodys;
				}
				if (byId.IsRead == 0)
				{
					byId.IsRead = 1;
					Mails.Init().Update(byId);
					if (byId.SenderGUID == "1" && byId.ReceiverID == Convert.ToInt32(this.Uid) && byId.FolderType == 0)
					{
						string title = "[系统通知] : 收件人(" + this.RealName + ")已查看您发送的邮件!";
						string content = string.Concat(new string[]
						{
							"您好! 您撰写发送的的邮件<br>“<strong>",
							byId.Subject,
							"</strong>” (发送于 ",
							Utils.ConvertDate3(byId.SendTime),
							") <br><br>收件人<strong>(",
							this.RealName,
							")</strong>已于 ",
							Utils.ConvertDate3(DateTime.Now),
							" 拆启查阅。<br>"
						});
						int senderID = byId.SenderID;
						string userlist = string.Concat(new object[]
						{
							byId.SenderRealName,
							"#",
							byId.SenderID,
							"#",
							byId.SenderDepName,
							","
						});
						string namelist = byId.SenderRealName + "(" + byId.SenderDepName + "),";
						Help.AdminSendMail(title, content, senderID, userlist, namelist);
					}
				}
				this.ViewState["retitle"] = byId.Subject;
				this.ViewState["sid"] = byId.SenderID;
				this.ViewState["snames"] = byId.SenderRealName;
				this.ViewState["sdep"] = byId.SenderDepName;
			}
			else
			{
				base.Response.Write("<script>alert('您没有查看权限');window.location='Mail_List.aspx?fid=0';</script>");
			}
		}
		protected void MoveToLJ(object sender, EventArgs e)
		{
			string value = base.Request.QueryString["mid"];
			if (!string.IsNullOrEmpty(value))
			{
				string cmdText = "update mails set foldertype=3 where id=" + Convert.ToInt32(value);
				MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
				string str = HttpContext.Current.Server.HtmlEncode("您好!邮件已删除至垃圾箱!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
		}
		protected void Del_Mail(object sender, EventArgs e)
		{
			string value = base.Request.QueryString["mid"];
			if (!string.IsNullOrEmpty(value))
			{
				string cmdText = "delete from mails where id=" + Convert.ToInt32(value);
				MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
				string str = HttpContext.Current.Server.HtmlEncode("您好!邮件已彻底删除!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=../Manage/Common/Mail_List.aspx?fid=0&tip=" + str);
			}
		}
		protected void Replay_Btn(object sender, EventArgs e)
		{
			string text = base.Request.Form["replay"];
			if (!string.IsNullOrEmpty(text.Trim()) && text.Trim() != "在这里输入快捷回复")
			{
				MailsInfo mailsInfo = new MailsInfo();
				Mails_DetailInfo mails_DetailInfo = new Mails_DetailInfo();
				mailsInfo.Subject = "快捷回复：" + this.ViewState["retitle"];
				mailsInfo.ReceiverID = Convert.ToInt32(this.ViewState["sid"]);
				mails_DetailInfo.Bodys = text;
				mailsInfo.SenderID = Convert.ToInt32(this.Uid);
				mailsInfo.SenderRealName = this.RealName;
				mailsInfo.SenderDepName = this.DepName;
				mailsInfo.SendType = 5;
				mailsInfo.SendTime = DateTime.Now;
				mails_DetailInfo.SendIDs = string.Concat(mailsInfo.ReceiverID);
				mails_DetailInfo.SendRealNames = string.Concat(new object[]
				{
					this.ViewState["snames"],
					" (",
					this.ViewState["sdep"],
					")"
				});
				Mails_Detail.Init().Add(mails_DetailInfo);
				mailsInfo.did = mails_DetailInfo.id;
				Mails.Init().Add(mailsInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!邮件已成功回复!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
			else
			{
				base.Response.Write("<script>alert('您还没输入任何内容');window.location='" + base.Request.Url.AbsoluteUri + "'</script>");
			}
		}
	}
