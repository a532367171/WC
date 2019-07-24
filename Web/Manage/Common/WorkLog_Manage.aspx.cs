using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Manage_Common_WorkLog_Manage : ViewPages

   {
    //    protected HtmlHead Head1;
    //    protected HtmlForm form1;
    //    protected Button Button1;
    //    protected HtmlInputText LogTitle;
    //    protected HtmlInputText addTime;
    //    protected HtmlInputHidden userlist;
    //    protected HtmlTextArea namelist;
    //    protected HtmlTextArea Bodys;
    //    protected HtmlGenericControl dvReadAttach;
    //    protected Panel Attachword;
    //    protected Repeater rpt;
    //    protected Button save_bt;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["wid"]))
			{
				this.Show(base.Request.QueryString["wid"]);
			}
			if (!base.IsPostBack && string.IsNullOrEmpty(base.Request.QueryString["wid"]))
			{
				this.Show();
			}
		}
		private void Show()
		{
			Sys_UserInfo byId = Sys_User.Init().GetById(Convert.ToInt32(this.Uid));
			this.userlist.Value = (byId.et6 ?? "");
			this.namelist.Value = (byId.et5 ?? "");
		}
		private void Show(string did)
		{
			if (!string.IsNullOrEmpty(did))
			{
				WorkLogInfo byId = WorkLog.Init().GetById(Convert.ToInt32(did));
				this.ViewState["di"] = byId;
				this.LogTitle.Value = byId.LogTitle;
				this.Bodys.Value = byId.Notes;
				this.userlist.Value = byId.ShareUsers;
				this.namelist.Value = byId.namelist;
				this.addTime.Value = byId.AddTime;
				this.addTime.Disabled = true;
				if (!string.IsNullOrEmpty(byId.FilePath) && byId.FilePath.Contains("|"))
				{
					this.Attachword.Visible = true;
					List<TmpInfo> list = new List<TmpInfo>();
					string[] array = byId.FilePath.Split(new char[]
					{
						'|'
					});
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i].Trim() != "")
						{
							TmpInfo tmpInfo = new TmpInfo();
							int num = array[i].LastIndexOf('/') + 1;
							string tmp = array[i].Substring(num, array[i].Length - num);
							string tmp2 = array[i].Replace("~", "");
							tmpInfo.Tmp1 = array[i];
							tmpInfo.Tmp2 = tmp;
							tmpInfo.Tmp3 = tmp2;
							list.Add(tmpInfo);
						}
					}
					this.rpt.DataSource = list;
					this.rpt.DataBind();
				}
			}
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			HttpFileCollection files = HttpContext.Current.Request.Files;
			int num = 1;
			for (int i = 0; i < files.Count; i++)
			{
				HttpPostedFile f = files[i];
				if (Config.IsValidFile(f))
				{
					num++;
				}
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["wid"]))
			{
				WorkLogInfo workLogInfo = this.ViewState["di"] as WorkLogInfo;
				workLogInfo.LogTitle = this.LogTitle.Value;
				workLogInfo.FilePath = this.UpdateFiles();
				workLogInfo.Notes = this.Bodys.Value;
				workLogInfo.namelist = this.namelist.Value;
				workLogInfo.ShareUsers = this.userlist.Value;
				workLogInfo.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd");
				WorkLog.Init().Update(workLogInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!工作汇报已保存成功!");
				base.Response.Redirect("/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
			else
			{
				WorkLogInfo workLogInfo = new WorkLogInfo();
				workLogInfo.AddTime = this.addTime.Value;
				workLogInfo.UpdateTime = DateTime.Now.ToString("yyyy-MM-dd");
				workLogInfo.CreatorDepName = this.DepName;
				workLogInfo.CreatorID = Convert.ToInt32(this.Uid);
				workLogInfo.CreatorRealName = this.RealName;
				workLogInfo.LogTitle = this.LogTitle.Value;
				workLogInfo.FilePath = this.UpdateFiles();
				workLogInfo.Notes = this.Bodys.Value;
				workLogInfo.namelist = this.namelist.Value;
				workLogInfo.ShareUsers = this.userlist.Value;
				WorkLog.Init().Add(workLogInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!工作汇报已保存成功!");
				base.Response.Redirect("/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
		}
		private string UpdateFiles()
		{
			string text = "";
			HttpFileCollection files = HttpContext.Current.Request.Files;
			string text2 = DateTime.Now.ToString("yyMMdd");
			string text3 = base.Server.MapPath("~/Files/DocsFiles/");
			string str = "~/Files/DocsFiles/" + text2 + "/";
			text3 += text2;
			if (!Directory.Exists(text3))
			{
				FileSystemManager.CreateFolder(text2, base.Server.MapPath("~/Files/DocsFiles"));
			}
			try
			{
				string str2 = "";
				if (this.Attachword.Visible)
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
				throw;
			}
			return text;
		}
	}
