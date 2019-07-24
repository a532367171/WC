using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Mobile_Mails_SendMail : MobilePage

	{
		private int ct = 0;
		private object tobj = null;
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlInputText Subject;
        //protected HtmlInputHidden userlist;
        //protected HtmlTextArea namelist;
        //protected HtmlTextArea Bodys;
        //protected HtmlGenericControl dvReadAttach;
        protected PlaceHolder Attachwords;
        //protected Repeater rpt;
        //protected Button bt5;
        //protected Button Button1;
		protected void Page_Load(object sender, EventArgs e)
		{
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.Subject.Value) && !string.IsNullOrEmpty(this.userlist.Value))
			{
				string sendnames = "";
				string ccnames = "";
				string bccnames = "";
				int num = 0;
				string attachments = this.UpdateFiles();
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				if (!string.IsNullOrEmpty(this.userlist.Value))
				{
					string[] array = this.userlist.Value.Split(new char[]
					{
						','
					});
					int num2 = 0;
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						string text = array2[i];
						if (text.Trim() != "")
						{
							string item = text.Split(new char[]
							{
								'#'
							})[1];
							list2.Add(item);
							string item2 = text.Split(new char[]
							{
								'#'
							})[1] + "|" + num2;
							if (!list.Contains(item2))
							{
								list.Add(item2);
							}
						}
					}
					string.Join(",", list2.ToArray());
					sendnames = this.namelist.Value;
				}
				string[] array3 = list.ToArray();
				new List<string>();
				for (int j = 0; j < array3.Length; j++)
				{
					if (Utils.IsNumber(array3[j].Split(new char[]
					{
						'|'
					})[0]))
					{
						this.AddMail(0, Convert.ToInt32(array3[j].Split(new char[]
						{
							'|'
						})[1]), Convert.ToInt32(array3[j].Split(new char[]
						{
							'|'
						})[0]), this.Uid, this.RealName, this.DepName, this.userlist.Value, sendnames, "", ccnames, "", bccnames, attachments);
						num++;
					}
				}
				this.AddMail(2, 4, Convert.ToInt32(this.Uid), this.Uid, this.RealName, this.DepName, this.userlist.Value, sendnames, "", ccnames, "", bccnames, attachments);
				MessageBox.ShowAndRedirect(this, "邮件发送成功!", "SendMail.aspx");
			}
			else
			{
				MessageBox.ShowAndRedirect(this, "必填项不能为空!", "SendMail.aspx");
			}
		}
		protected void Caogao_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.Subject.Value))
			{
				string sendnames = "";
				string ccnames = "";
				string bccnames = "";
				string attachments = this.UpdateFiles();
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				if (!string.IsNullOrEmpty(this.userlist.Value))
				{
					string[] array = this.userlist.Value.Split(new char[]
					{
						','
					});
					int num = 0;
					string[] array2 = array;
					for (int i = 0; i < array2.Length; i++)
					{
						string text = array2[i];
						if (text.Trim() != "")
						{
							string item = text.Split(new char[]
							{
								'#'
							})[1];
							list2.Add(item);
							string item2 = text.Split(new char[]
							{
								'#'
							})[1] + "|" + num;
							if (!list.Contains(item2))
							{
								list.Add(item2);
							}
						}
					}
					string.Join(",", list2.ToArray());
					sendnames = this.namelist.Value;
				}
				this.AddMail(1, 1, Convert.ToInt32(this.Uid), this.Uid, this.RealName, this.DepName, this.userlist.Value, sendnames, "", ccnames, "", bccnames, attachments);
				MessageBox.ShowAndRedirect(this, "已成功保存到草稿箱!", "SendMail.aspx");
			}
			else
			{
				MessageBox.ShowAndRedirect(this, "必填项不能为空!", "SendMail.aspx");
			}
		}
		private void AddMail(int type, int sendtype, int ReceiverID, string uid, string realname, string depname, string sendids, string sendnames, string ccids, string ccnames, string bccids, string bccnames, string attachments)
		{
			if (this.ct == 0)
			{
				Mails_DetailInfo mails_DetailInfo = new Mails_DetailInfo();
				mails_DetailInfo.Attachments = attachments;
				mails_DetailInfo.Bodys = this.Bodys.Value;
				mails_DetailInfo.SendIDs = sendids;
				mails_DetailInfo.SendRealNames = sendnames;
				mails_DetailInfo.CcIDs = ccids;
				mails_DetailInfo.CcRealNames = ccnames;
				mails_DetailInfo.BccIDs = bccids;
				mails_DetailInfo.BccRealNames = bccnames;
				this.ct++;
				Mails_Detail.Init().Add(mails_DetailInfo);
				this.tobj = mails_DetailInfo;
			}
			if (this.tobj.GetType().ToString().Contains("fo"))
			{
				Mails_DetailInfo mails_DetailInfo = this.tobj as Mails_DetailInfo;
				MailsInfo mailsInfo = new MailsInfo();
				mailsInfo.ReceiverID = ReceiverID;
				mailsInfo.SenderID = Convert.ToInt32(uid);
				mailsInfo.SenderRealName = realname;
				mailsInfo.SenderDepName = depname;
				mailsInfo.SendType = sendtype;
				mailsInfo.Subject = this.Subject.Value;
				mailsInfo.FolderType = type;
				mailsInfo.SendTime = DateTime.Now;
				mailsInfo.did = mails_DetailInfo.id;
				mailsInfo.SenderGUID = "";
				Mails.Init().Add(mailsInfo);
			}
		}
		private string UpdateFiles()
		{
			string text = "";
			HttpFileCollection files = HttpContext.Current.Request.Files;
			string text2 = DateTime.Now.ToString("yyMMdd");
			string text3 = base.Server.MapPath("~/Files/MailFiles/");
			string str = "~/Files/MailFiles/" + text2 + "/";
			text3 += text2;
			if (!Directory.Exists(text3))
			{
				FileSystemManager.CreateFolder(text2, base.Server.MapPath("~/Files/MailFiles"));
			}
			try
			{
				string str2 = "";
				if (this.Attachwords.Visible)
				{
					foreach (RepeaterItem repeaterItem in this.rpt.Items)
					{
						HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
						if (htmlInputCheckBox.Checked)
						{
							str2 = str2 + htmlInputCheckBox.Value + "|";
						}
					}
				}
				for (int i = 0; i < files.Count; i++)
				{
					HttpPostedFile httpPostedFile = files[i];
					if (Config.IsValidFile(httpPostedFile))
					{
						string fileName = Path.GetFileName(httpPostedFile.FileName);
						string str3 = str + fileName;
						string text4 = text3 + "\\" + fileName;
						if (File.Exists(text4))
						{
							string text5 = string.Concat(new object[]
							{
								DateTime.Now.ToString("HHmmssfff"),
								Utils.CreateRandomStr(3),
								this.Uid,
								i
							});
							text4 = string.Concat(new string[]
							{
								text3,
								"\\",
								text5,
								"@",
								Utils.GetFileExtension(fileName)
							});
							str3 = str + text5 + "@" + Utils.GetFileExtension(fileName);
						}
						httpPostedFile.SaveAs(text4);
						text = text + str3 + "|";
					}
				}
				text = str2 + text;
			}
			catch (IOException ex)
			{
				throw ex;
			}
			return text;
		}
	}