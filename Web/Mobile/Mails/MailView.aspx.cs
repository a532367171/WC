using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;
using WC.DK;

public partial class Mobile_Mails_MailView : MobilePage

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlGenericControl Subject;
        //protected HtmlGenericControl Sender;
        //protected HtmlGenericControl Sendtime;
        //protected HtmlGenericControl bodys;
        //protected HtmlGenericControl sjr;
        //protected HtmlTextArea replay;
        //protected Button bt5;
		protected string mid = "";
		protected string bet = "";
		protected string fjs = "";
		protected string fj = "<span>{1}</span> &nbsp;&nbsp;&nbsp;&nbsp;<a href='/Manage/Utils/Download.aspx?destFileName={0}' ><img src='/img/mail_attachment.gif' />下载</a><br>";
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
				this.Sendtime.InnerText = Utils.ConvertDate5(byId.SendTime);
				this.sjr.InnerText = Utils.GetSubString2(byId2.SendRealNames, 300, "...");
				if (!string.IsNullOrEmpty(byId2.CcRealNames))
				{
					this.csr = "<br><span style='font-weight:bold; color:#006600;'>抄送人</span>：" + Utils.GetSubString2(byId2.CcRealNames, 250, "...");
				}
				if (!string.IsNullOrEmpty(byId2.Attachments))
				{
					this.fjs = "";
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
				MessageBox.ShowAndRedirect(this, "您没有查看权限!", "MailList.aspx?fid=0");
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
				MessageBox.ShowAndRedirect(this, "已经成功回复!", "MailList.aspx?fid=0");
			}
			else
			{
				MessageBox.ShowAndRedirect(this, "快捷回复没有任何内容!", "MailList.aspx?fid=0");
			}
		}
	}