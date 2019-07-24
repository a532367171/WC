using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Manage_Common_Meeting_Manage : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Button Button1;
        //protected HtmlInputText MainTopics;
        //protected HtmlInputText CTime;
        //protected HtmlInputText Address;
        //protected HtmlInputText Chaired;
        //protected HtmlInputText Recorder;
        //protected HtmlTextArea ListPerson;
        //protected HtmlInputText AbsencePerson;
        //protected HtmlTextArea Bodys;
        //protected HtmlTextArea Remarks;
        //protected HtmlGenericControl dvReadAttach;
        //protected Panel Attachword;
        //protected Repeater rpt;
        //protected Button save_bt;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["mid"]))
			{
				this.Show(base.Request.QueryString["mid"]);
			}
		}
		private void Show(string mid)
		{
			MeetingInfo byId = Meeting.Init().GetById(Convert.ToInt32(mid));
			this.ViewState["mi"] = byId;
			this.Bodys.Value = byId.Bodys;
			this.CTime.Value = byId.CTime;
			this.Address.Value = byId.Address;
			this.Recorder.Value = byId.Recorder;
			this.ListPerson.Value = byId.ListPerson;
			this.AbsencePerson.Value = byId.AbsencePerson;
			this.Chaired.Value = byId.Chaired;
			this.MainTopics.Value = byId.MainTopics;
			this.Remarks.Value = byId.Remarks;
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
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["mid"]))
			{
				MeetingInfo meetingInfo = this.ViewState["mi"] as MeetingInfo;
				meetingInfo.AbsencePerson = this.AbsencePerson.Value;
				meetingInfo.Address = this.Address.Value;
				meetingInfo.Bodys = this.Bodys.Value;
				meetingInfo.Chaired = this.Chaired.Value;
				meetingInfo.CTime = this.CTime.Value;
				meetingInfo.FilePath = this.UpdateFiles();
				meetingInfo.ListPerson = this.ListPerson.Value;
				meetingInfo.MainTopics = this.MainTopics.Value;
				meetingInfo.Recorder = this.Recorder.Value;
				meetingInfo.Remarks = this.Remarks.Value;
				meetingInfo.UserID = Convert.ToInt32(this.Uid);
				Meeting.Init().Update(meetingInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!会议已保存成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=../Manage/common/Meeting_List.aspx&tip=" + str);
			}
			else
			{
				MeetingInfo meetingInfo = new MeetingInfo();
				meetingInfo.AbsencePerson = this.AbsencePerson.Value;
				meetingInfo.Address = this.Address.Value;
				meetingInfo.Bodys = this.Bodys.Value;
				meetingInfo.Chaired = this.Chaired.Value;
				meetingInfo.CTime = this.CTime.Value;
				meetingInfo.FilePath = this.UpdateFiles();
				meetingInfo.ListPerson = this.ListPerson.Value;
				meetingInfo.MainTopics = this.MainTopics.Value;
				meetingInfo.Recorder = this.Recorder.Value;
				meetingInfo.Remarks = this.Remarks.Value;
				meetingInfo.UserID = Convert.ToInt32(this.Uid);
				Meeting.Init().Add(meetingInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!会议已保存成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=../Manage/common/Meeting_List.aspx&tip=" + str);
			}
		}
		private string UpdateFiles()
		{
			string text = "";
			HttpFileCollection files = HttpContext.Current.Request.Files;
			string text2 = DateTime.Now.ToString("yyMMdd");
			string text3 = base.Server.MapPath("~/Files/Common/");
			string str = "~/Files/Common/" + text2 + "/";
			text3 += text2;
			if (!Directory.Exists(text3))
			{
				FileSystemManager.CreateFolder(text2, base.Server.MapPath("~/Files/Common"));
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
