using System;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.Model;

public partial class Mobile_WorkLog_WorkLogView : MobilePage

	{
		protected string fjs = "";
		protected string fj = "<span style='font-weight:bold;'>{1}</span> &nbsp;&nbsp;&nbsp;&nbsp;<a href='/Manage/Utils/Download.aspx?destFileName={0}' ><img src='/img/mail_attachment.gif' />下载附件</a><br>";
        //protected HtmlForm form1;
        //protected HtmlGenericControl WorkTitle;
        //protected HtmlGenericControl TaskUser;
        //protected HtmlGenericControl AddTime;
        //protected HtmlGenericControl UpdateTime;
        //protected HtmlGenericControl Notes;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["wid"]))
			{
				string wid = base.Request.QueryString["wid"];
				this.Show(wid);
			}
		}
		private void Show(string wid)
		{
			WorkLogInfo byId = WorkLog.Init().GetById(Convert.ToInt32(wid));
			if (this.Uid == string.Concat(byId.CreatorID) || byId.ShareUsers.Contains("#" + this.Uid + "#"))
			{
				this.TaskUser.InnerText = byId.CreatorRealName + "(" + byId.CreatorDepName + ")";
				this.WorkTitle.InnerText = byId.LogTitle;
				this.AddTime.InnerText = byId.AddTime;
				this.UpdateTime.InnerText = byId.UpdateTime;
				if (this.Notes.InnerHtml.ToLower().Contains("script"))
				{
					this.Notes.InnerHtml = byId.Notes.ToLower().Replace("script", "scrript").Replace("\r\n", "<br>");
				}
				else
				{
					this.Notes.InnerHtml = byId.Notes.ToLower().Replace("\r\n", "<br>");
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
			}
		}
	}