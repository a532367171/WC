using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Mobile_Tasks_FeedBack_View : MobilePage

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlGenericControl TaskName;
        //protected HtmlGenericControl TaskUser;
        //protected HtmlGenericControl WorkTitle;
        //protected HtmlGenericControl AddTime;
        //protected HtmlGenericControl Notes;
        //protected HtmlGenericControl Instruction;
    protected PlaceHolder pizhu1s;
        //protected HtmlTextArea pz;
        //protected Button pizhu3;
		protected string fjs = "";
		protected string fj = "<span style='font-weight:bold;'>{1}</span> &nbsp;&nbsp;&nbsp;&nbsp;<a href='/Manage/Utils/Download.aspx?destFileName={0}' ><img src='/img/mail_attachment.gif' />下载附件</a><br>";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["tuid"]))
			{
				string tid = base.Request.QueryString["tuid"];
				this.Show(tid);
			}
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["tuid"]))
			{
				string text = base.Request.QueryString["tuid"];
				Tasks_UserInfo byId = Tasks_User.Init().GetById(Convert.ToInt32(text));
				Tasks_UserInfo expr_4D = byId;
				string instruction = expr_4D.Instruction;
				expr_4D.Instruction = string.Concat(new string[]
				{
					instruction,
					"<font color='#0055ff'>",
					base.Request.Form["pz"],
					"</font> -- ",
					this.RealName,
					" (",
					DateTime.Now.ToString("yy-M-dd HH:mm"),
					")<br><hr />"
				});
				Tasks_User.Init().Update(byId);
				this.Show(text);
			}
		}
		private void Show(string tid)
		{
			Tasks_UserInfo byId = Tasks_User.Init().GetById(Convert.ToInt32(tid));
			TasksInfo byId2 = Tasks.Init().GetById(byId.TaskID);
			if (this.Uid == string.Concat(byId.UserID) || (byId2.IsOtherSee == 1 && byId2.ExecuteUserList.Contains("#" + this.Uid + "#")) || byId2.ManageUserList.Contains("#" + this.Uid + "#") || this.Modules.Contains("51"))
			{
				this.pizhu1s.Visible = false;
				this.pizhu3.Visible = false;
				if (byId2.ManageUserList.Contains("#" + this.Uid + "#") && byId2.Status == 1)
				{
					this.pizhu1s.Visible = true;
					this.pizhu3.Visible = true;
				}
				this.TaskUser.InnerText = byId.RealName + "(" + byId.DepName + ")";
				this.TaskName.InnerText = byId2.TaskName;
				this.WorkTitle.InnerText = byId.WorkTitle;
				this.AddTime.InnerText = byId.AddTime;
				byId.WorkNotes = (byId.WorkNotes ?? "");
				if (byId.WorkNotes.ToLower().Contains("script"))
				{
					this.Notes.InnerHtml = byId.WorkNotes.ToLower().Replace("script", "scrript");
				}
				else
				{
					this.Notes.InnerHtml = byId.WorkNotes;
				}
				if (!string.IsNullOrEmpty(byId.FilePath))
				{
					string[] array = byId.FilePath.Split(new char[]
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
				byId.Instruction = (byId.Instruction ?? "");
				if (byId.Instruction.ToLower().Contains("script"))
				{
					this.Instruction.InnerHtml = byId.Instruction.ToLower().Replace("script", "scrript").Replace("\r\n", "<br>");
				}
				else
				{
					this.Instruction.InnerHtml = byId.Instruction.Replace("\r\n", "<br>");
				}
			}
			else
			{
				MessageBox.ShowAndRedirect(this, "您没有权限查看!", "TaskMenu.aspx");
			}
		}
	}