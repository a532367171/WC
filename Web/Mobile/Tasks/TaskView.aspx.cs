using System;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Mobile_Tasks_TaskView : MobilePage

	{
		private TasksInfo ti = null;
		protected string fjs = "";
		protected string fj = "<span style='font-weight:bold;'>{1}</span> &nbsp;&nbsp;&nbsp;&nbsp;<a href='/Manage/Utils/Download.aspx?destFileName={0}' ><img src='/img/mail_attachment.gif' />下载附件</a><br>";
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlGenericControl Subject;
        //protected HtmlGenericControl status;
        //protected HtmlGenericControl Creator;
        //protected HtmlGenericControl AddTime;
        //protected HtmlGenericControl UpdateTime;
        //protected HtmlGenericControl ManageNameList;
        //protected HtmlGenericControl bodys1;
        //protected Repeater rpt;
        //protected HtmlGenericControl TypeName;
        //protected HtmlGenericControl Important;
        //protected HtmlGenericControl ExpectTime;
        protected PlaceHolder displays;
        protected PlaceHolder exetables;
        //protected HtmlTextArea Bodys;
        //protected HtmlGenericControl dvReadAttach;
        //protected Button s1;
        //protected Button s2;
        //protected Button b3;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["tid"]))
			{
				string tid = base.Request.QueryString["tid"];
				this.Show(tid);
			}
		}
		private void Show(string tid)
		{
			this.ti = Tasks.Init().GetById(Convert.ToInt32(tid));
			if (this.Uid == string.Concat(this.ti.CreatorID) || this.ti.ManageUserList.Contains("#" + this.Uid + "#") || this.ti.ExecuteUserList.Contains("#" + this.Uid + "#") || this.Modules.Contains("51"))
			{
				this.DetailShow();
				this.RptShow();
				this.displays.Visible = false;
				this.exetables.Visible = false;
				this.s1.Visible = false;
				this.s2.Visible = false;
				this.b3.Visible = false;
				if (this.ti.ManageUserList.Contains("#" + this.Uid + "#"))
				{
					this.displays.Visible = true;
					if (this.ti.Status == 1)
					{
						this.b3.Visible = true;
					}
				}
				if (this.ti.ExecuteUserList.Contains("#" + this.Uid + "#"))
				{
					IList all = Tasks_User.Init().GetAll(string.Concat(new object[]
					{
						"TaskID=",
						this.ti.id,
						" and UserID=",
						this.Uid
					}), null);
					if (all.Count > 0 && this.ti.Status == 1)
					{
						Hashtable tasks_UserHash = this.GetTasks_UserHash(all);
						string a = string.Concat(tasks_UserHash["noaccept"]);
						string a2 = string.Concat(tasks_UserHash["accept"]);
						string text = string.Concat(tasks_UserHash["submit"]);
						if (a == "1" && a2 == "0" && text == "0")
						{
							this.displays.Visible = true;
							this.exetables.Visible = false;
							this.s1.Visible = false;
							this.s2.Visible = true;
						}
						if (a2 == "1" && a == "0" && text == "0")
						{
							this.displays.Visible = true;
							this.exetables.Visible = true;
							this.s1.Visible = true;
							this.s2.Visible = false;
						}
						if (Convert.ToInt32(text) > 0 && a == "0" && a2 == "0" && this.ti.OnceSubmit == 1)
						{
							this.displays.Visible = true;
							this.exetables.Visible = true;
							this.s1.Visible = true;
							this.s2.Visible = false;
						}
					}
				}
			}
		}
		private Hashtable GetTasks_UserHash(IList list)
		{
			Hashtable hashtable = new Hashtable();
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			foreach (object current in list)
			{
				Tasks_UserInfo tasks_UserInfo = current as Tasks_UserInfo;
				if (tasks_UserInfo.WorkTag == -1)
				{
					num = 1;
				}
				if (tasks_UserInfo.WorkTag == 1)
				{
					num2 = 1;
				}
				if (tasks_UserInfo.WorkTag == 2)
				{
					num3++;
				}
			}
			hashtable.Add("noaccept", string.Concat(num));
			hashtable.Add("accept", string.Concat(num2));
			hashtable.Add("submit", string.Concat(num3));
			return hashtable;
		}
		private void DetailShow()
		{
			this.Subject.InnerText = this.ti.TaskName;
			this.status.InnerText = this.GetStatus(this.ti.Status);
			this.Creator.InnerText = this.ti.CreatorRealName + "(" + this.ti.CreatorDepName + ")";
			this.TypeName.InnerText = this.ti.TypeName;
			this.AddTime.InnerText = this.ti.AddTime;
			this.UpdateTime.InnerText = this.ti.UpdateTime;
			this.ExpectTime.InnerText = this.ti.ExpectTime;
			this.Important.InnerText = this.ti.Important;
			this.ManageNameList.InnerText = this.ti.ManageNameList;
			this.ti.Notes = (this.ti.Notes ?? "");
			if (this.ti.Notes.ToLower().Contains("script"))
			{
				this.bodys1.InnerHtml = this.ti.Notes.ToLower().Replace("script", "scrript");
			}
			else
			{
				this.bodys1.InnerHtml = this.ti.Notes;
			}
			if (!string.IsNullOrEmpty(this.ti.FilePath))
			{
				this.fjs = "<span style='color:#006600;'>任务附件</span>：<br>";
				string[] array = this.ti.FilePath.Split(new char[]
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
		private void RptShow()
		{
			IList all = Tasks_User.Init().GetAll("TaskID=" + this.ti.id, "order by WorkTag desc,id desc");
			this.rpt.DataSource = all;
			this.rpt.DataBind();
		}
		protected void RowDataBind(object sender, RepeaterItemEventArgs e)
		{
			LinkButton linkButton = e.Item.FindControl("lb") as LinkButton;
			Panel panel = e.Item.FindControl("pa") as Panel;
			Panel panel2 = e.Item.FindControl("pa1") as Panel;
			Label label = e.Item.FindControl("lab1") as Label;
			linkButton.Visible = false;
			panel.Visible = false;
			string a = linkButton.CommandArgument.Split(new char[]
			{
				','
			})[0];
			string b = linkButton.CommandArgument.Split(new char[]
			{
				','
			})[1];
			if (a == "2")
			{
				label.Text = "<span style='color:#999'>(无权限查看!)</span>";
				if (this.ti.IsOtherSee == 1 || this.ti.ManageUserList.Contains("#" + this.Uid + "#") || this.Uid == b)
				{
					panel.Visible = true;
					panel2.Visible = true;
					label.Visible = false;
				}
			}
			else
			{
				label.Text = "<span style='color:#999'>执行者没接收(提交)</span>";
			}
		}
		protected void Accept_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
			{
				string value = base.Request.QueryString["tid"];
				TasksInfo byId = Tasks.Init().GetById(Convert.ToInt32(value));
				IList all = Tasks_User.Init().GetAll(string.Concat(new object[]
				{
					"TaskID=",
					byId.id,
					" and UserID=",
					this.Uid,
					" and WorkTag=-1"
				}), null);
				if (all.Count == 1)
				{
					Tasks_UserInfo tasks_UserInfo = all[0] as Tasks_UserInfo;
					tasks_UserInfo.WorkTag = 1;
					tasks_UserInfo.AddTime = DateTime.Now.ToString("yy-M-dd HH:mm");
					Tasks_User.Init().Update(tasks_UserInfo);
					byId.UpdateTime = DateTime.Now.ToString("yy-M-dd HH:mm");
					TasksInfo expr_FE = byId;
					string records = expr_FE.Records;
					expr_FE.Records = string.Concat(new string[]
					{
						records,
						"<font color='#2828ff'>[执行者]</font> <strong>",
						this.RealName,
						"(",
						this.DepName,
						")</strong> 在 ",
						Utils.ConvertDate3(DateTime.Now),
						" 操作：<font color='#2828ff'>接收了任务!</font> <br><br>"
					});
					Tasks.Init().Update(byId);
					MessageBox.ShowAndRedirect(this, "操作成功,任务已接收!", "TaskMenu.aspx");
				}
			}
		}
		protected void Submit_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
			{
				string value = base.Request.QueryString["tid"];
				TasksInfo byId = Tasks.Init().GetById(Convert.ToInt32(value));
				IList all = Tasks_User.Init().GetAll(string.Concat(new object[]
				{
					"TaskID=",
					byId.id,
					" and UserID=",
					this.Uid,
					" and WorkTag=1"
				}), null);
				if (all.Count == 1)
				{
					Tasks_UserInfo tasks_UserInfo = all[0] as Tasks_UserInfo;
					tasks_UserInfo.WorkTag = 2;
					tasks_UserInfo.AddTime = DateTime.Now.ToString("yy-M-dd HH:mm");
					tasks_UserInfo.TaskID = byId.id;
					tasks_UserInfo.RealName = this.RealName;
					tasks_UserInfo.UserID = Convert.ToInt32(this.Uid);
					tasks_UserInfo.DepName = this.DepName;
					tasks_UserInfo.FilePath = this.UpdateFiles();
					tasks_UserInfo.WorkTitle = "从手机提交的执行情况..";
					tasks_UserInfo.WorkNotes = base.Request.Form["Bodys"];
					tasks_UserInfo.WorkNotes = "";
					tasks_UserInfo.Instruction = "";
					Tasks_User.Init().Update(tasks_UserInfo);
					byId.UpdateTime = DateTime.Now.ToString("yy-M-dd HH:mm");
					TasksInfo expr_184 = byId;
					string records = expr_184.Records;
					expr_184.Records = string.Concat(new string[]
					{
						records,
						"<font color='#2828ff'>[执行者]</font> <strong>",
						this.RealName,
						"(",
						this.DepName,
						")</strong> 在 ",
						Utils.ConvertDate3(DateTime.Now),
						" 操作：<font color='#006600'>首次提交了执行情况!</font> <br><br>"
					});
					Tasks.Init().Update(byId);
					MessageBox.ShowAndRedirect(this, "操作成功,任务已提交!", "TaskMenu.aspx");
				}
				else
				{
					Tasks_UserInfo tasks_UserInfo = new Tasks_UserInfo();
					tasks_UserInfo.WorkTag = 2;
					tasks_UserInfo.AddTime = DateTime.Now.ToString("yy-M-dd HH:mm");
					tasks_UserInfo.TaskID = byId.id;
					tasks_UserInfo.RealName = this.RealName;
					tasks_UserInfo.UserID = Convert.ToInt32(this.Uid);
					tasks_UserInfo.DepName = this.DepName;
					tasks_UserInfo.FilePath = this.UpdateFiles();
					tasks_UserInfo.WorkTitle = "从手机提交的执行情况..";
					tasks_UserInfo.WorkNotes = this.Bodys.Value;
					tasks_UserInfo.Instruction = "";
					Tasks_User.Init().Add(tasks_UserInfo);
					byId.UpdateTime = DateTime.Now.ToString("yy-M-dd HH:mm");
					TasksInfo expr_2D0 = byId;
					string records = expr_2D0.Records;
					expr_2D0.Records = string.Concat(new string[]
					{
						records,
						"<font color='#2828ff'>[执行者]</font> <strong>",
						this.RealName,
						"(",
						this.DepName,
						")</strong> 在 ",
						Utils.ConvertDate3(DateTime.Now),
						" 操作：<font color='#006600'>提交了执行情况!</font> <br><br>"
					});
					Tasks.Init().Update(byId);
					MessageBox.ShowAndRedirect(this, "操作成功,任务已提交!", "TaskMenu.aspx");
				}
			}
		}
		protected void Complete_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
			{
				string value = base.Request.QueryString["tid"];
				TasksInfo byId = Tasks.Init().GetById(Convert.ToInt32(value));
				byId.Status = 2;
				byId.UpdateTime = DateTime.Now.ToString("yy-M-dd HH:mm");
				TasksInfo expr_6C = byId;
				string records = expr_6C.Records;
				expr_6C.Records = string.Concat(new string[]
				{
					records,
					"<font color='#ff0000'>[管理者]</font> <strong>",
					this.RealName,
					"(",
					this.DepName,
					")</strong> 在 ",
					Utils.ConvertDate3(DateTime.Now),
					" 操作：<strong style='color:#006600'>任务完成!</strong> <br><br>"
				});
				Tasks.Init().Update(byId);
				MessageBox.ShowAndRedirect(this, "操作成功,任务已完成!", "TaskMenu.aspx");
			}
		}
		protected string GetWorkTag(object obj)
		{
			string text = string.Concat(obj);
			string result;
			if (text != null)
			{
				if (text == "-1")
				{
					result = "<strong style='color:#0055ff'>× 未接收</strong>";
					return result;
				}
				if (text == "1")
				{
					result = "<strong style='color:#006600'>√ 已接收</strong>";
					return result;
				}
				if (text == "2")
				{
					result = "<strong style='color:#ff0000'>√ 已提交</strong>";
					return result;
				}
			}
			result = "";
			return result;
		}
		protected string GetStatus(object obj)
		{
			string text = string.Concat(obj);
			string result;
			if (text != null)
			{
				if (text == "-1")
				{
					result = "已停止";
					return result;
				}
				if (text == "1")
				{
					result = "进行中";
					return result;
				}
				if (text == "2")
				{
					result = "已完成";
					return result;
				}
			}
			result = "";
			return result;
		}
		private string UpdateFiles()
		{
			string text = "";
			HttpFileCollection files = HttpContext.Current.Request.Files;
			string text2 = DateTime.Now.ToString("yyMMdd");
			string text3 = base.Server.MapPath("~/Files/OfficeFiles/");
			string str = "~/Files/OfficeFiles/" + text2 + "/";
			text3 += text2;
			if (!Directory.Exists(text3))
			{
				FileSystemManager.CreateFolder(text2, base.Server.MapPath("~/Files/OfficeFiles"));
			}
			try
			{
				string str2 = "";
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