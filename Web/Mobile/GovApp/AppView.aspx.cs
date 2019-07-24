using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;
using WC.DK;

public partial class Mobile_GovApp_AppView : MobilePage

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlGenericControl Flow_Name1;
        //protected HtmlGenericControl status;
        //protected HtmlGenericControl creator;
        //protected HtmlGenericControl addtime;
        //protected HtmlGenericControl currentstepname;
        //protected HtmlGenericControl currentuserlist;
        //protected HtmlInputHidden filepath;
        //protected HtmlGenericControl DocBody;
        //protected HtmlGenericControl bodys;
        //protected Repeater rpt;
        //protected HtmlGenericControl vlidtime;
        //protected HtmlGenericControl secret;
        //protected HtmlGenericControl DocNo;
        //protected HtmlGenericControl ModelType;
    protected PlaceHolder displays;
        //protected HtmlTextArea FlowRemark;
        //protected Button b1;
        //protected Button b2;
        //protected Button b3;
		protected string fj = "<a href='/Manage/Utils/Download.aspx?destFileName={0}' ><img src='/img/mail_attachment.gif' />{1}</a>&nbsp;&nbsp;";
		protected string yjs = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["fl"]))
			{
				this.Show(base.Request.QueryString["fl"]);
			}
		}
		protected void VerifyStep_Btn(object sender, EventArgs e)
		{
			GovInfo byId = Gov.Init().GetById(Convert.ToInt32(base.Request.QueryString["fl"]));
			string a = "";
			List<string> list = new List<string>();
			if (byId.CurrentStepUserList.Contains(",") && byId.CurrentStepUserList.Contains("#") && byId.Status == 0)
			{
				string[] array = byId.CurrentStepUserList.Split(new char[]
				{
					','
				});
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text = array2[i];
					if (text.Contains("#"))
					{
						list.Add(text.Split(new char[]
						{
							'#'
						})[1]);
					}
				}
			}
			if (list.Contains(this.Uid))
			{
				a = this.Uid;
			}
			if (a != "")
			{
				Gov_StepInfo gov_StepInfo = this.ViewState["CurrentStep"] as Gov_StepInfo;
				Gov_StepActionInfo gov_StepActionInfo = new Gov_StepActionInfo();
				gov_StepActionInfo.AddTime = DateTime.Now;
				gov_StepActionInfo.FlowID = Convert.ToInt32(base.Request.QueryString["fl"]);
				gov_StepActionInfo.Operation = 1;
				gov_StepActionInfo.OperationStepID = gov_StepInfo.id;
				gov_StepActionInfo.OperationWord = "(同意) ：" + base.Request.Form["FlowRemark"];
				gov_StepActionInfo.UserDepName = this.DepName;
				gov_StepActionInfo.UserID = Convert.ToInt32(this.Uid);
				gov_StepActionInfo.UserRealName = this.RealName;
				gov_StepActionInfo.OperationStepName = gov_StepInfo.Step_Name;
				if (gov_StepInfo.IsEnd == 1)
				{
					Gov_StepAction.Init().Add(gov_StepActionInfo);
					GovInfo govInfo = byId;
					this.AddDoc(govInfo.id, gov_StepActionInfo.id);
					govInfo.CurrentDocPath = this.filepath.Value;
					if (!this.IsAllVerifid())
					{
						GovInfo expr_219 = govInfo;
						string hasOperatedUserList = expr_219.HasOperatedUserList;
						expr_219.HasOperatedUserList = string.Concat(new string[]
						{
							hasOperatedUserList,
							this.RealName,
							"#",
							this.Uid,
							"#",
							this.DepName,
							","
						});
						govInfo.Flow_Files = this.UpdateFiles();
						Gov.Init().Update(govInfo);
						MessageBox.ShowAndRedirect(this, "公文成功审批!", "AppMenu.aspx");
					}
					else
					{
						GovInfo expr_2A4 = govInfo;
						string hasOperatedUserList = expr_2A4.HasOperatedUserList;
						expr_2A4.HasOperatedUserList = string.Concat(new string[]
						{
							hasOperatedUserList,
							this.RealName,
							"#",
							this.Uid,
							"#",
							this.DepName,
							","
						});
						govInfo.Flow_Files = this.UpdateFiles();
						Gov.Init().Update(govInfo);
						this.FinishFlow();
						MessageBox.ShowAndRedirect(this, "成功操作,公文已签发!", "AppMenu.aspx");
					}
				}
				else
				{
					IList all = Gov_Step.Init().GetAll("isact=0 and flow_id=" + base.Request.QueryString["fl"], "order by id asc");
					if (all != null)
					{
						int num = 0;
						foreach (object current in all)
						{
							Gov_StepInfo gov_StepInfo2 = current as Gov_StepInfo;
							if (gov_StepInfo2.Acts == gov_StepInfo.Acts)
							{
								num = all.IndexOf(current) + 1;
							}
						}
						if (num != 0)
						{
							Gov_StepAction.Init().Add(gov_StepActionInfo);
							GovInfo govInfo = byId;
							this.AddDoc(govInfo.id, gov_StepActionInfo.id);
							govInfo.CurrentDocPath = this.filepath.Value;
							if (this.IsAllVerifid())
							{
								Gov_StepInfo gov_StepInfo3 = this.MakeNewFsi((Gov_StepInfo)all[num]);
								govInfo.CurrentStepID = gov_StepInfo3.id;
								govInfo.CurrentStepName = gov_StepInfo3.Step_Name;
								govInfo.CurrentStepUserList = gov_StepInfo3.userlist;
							}
							GovInfo expr_462 = govInfo;
							string hasOperatedUserList = expr_462.HasOperatedUserList;
							expr_462.HasOperatedUserList = string.Concat(new string[]
							{
								hasOperatedUserList,
								this.RealName,
								"#",
								this.Uid,
								"#",
								this.DepName,
								","
							});
							govInfo.Flow_Files = this.UpdateFiles();
							Gov.Init().Update(govInfo);
							MessageBox.ShowAndRedirect(this, "已成功操作!", "AppMenu.aspx");
						}
					}
				}
			}
		}
		protected void RefuseStep_Btn(object sender, EventArgs e)
		{
			GovInfo byId = Gov.Init().GetById(Convert.ToInt32(base.Request.QueryString["fl"]));
			string a = "";
			List<string> list = new List<string>();
			if (byId.CurrentStepUserList.Contains(",") && byId.CurrentStepUserList.Contains("#") && byId.Status == 0)
			{
				string[] array = byId.CurrentStepUserList.Split(new char[]
				{
					','
				});
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text = array2[i];
					if (text.Contains("#"))
					{
						list.Add(text.Split(new char[]
						{
							'#'
						})[1]);
					}
				}
			}
			if (list.Contains(this.Uid))
			{
				a = this.Uid;
			}
			if (a != "")
			{
				Gov_StepInfo gov_StepInfo = this.ViewState["CurrentStep"] as Gov_StepInfo;
				Gov_StepActionInfo gov_StepActionInfo = new Gov_StepActionInfo();
				gov_StepActionInfo.AddTime = DateTime.Now;
				gov_StepActionInfo.FlowID = Convert.ToInt32(base.Request.QueryString["fl"]);
				gov_StepActionInfo.Operation = -1;
				gov_StepActionInfo.OperationStepID = gov_StepInfo.id;
				gov_StepActionInfo.OperationWord = "(不同意) ：" + base.Request.Form["FlowRemark"];
				gov_StepActionInfo.UserDepName = this.DepName;
				gov_StepActionInfo.UserID = Convert.ToInt32(this.Uid);
				gov_StepActionInfo.UserRealName = this.RealName;
				gov_StepActionInfo.OperationStepName = gov_StepInfo.Step_Name;
				if (gov_StepInfo.IsHead == 1)
				{
					Gov_StepAction.Init().Add(gov_StepActionInfo);
					this.AddDoc(gov_StepActionInfo.FlowID, gov_StepActionInfo.id);
					byId.CurrentDocPath = this.filepath.Value;
					Gov.Init().Update(byId);
					this.BackFlow();
					MessageBox.ShowAndRedirect(this, "成功操作,公文已退回拟稿人!", "AppMenu.aspx");
				}
				else
				{
					IList all = Gov_Step.Init().GetAll("isact=0 and flow_id=" + base.Request.QueryString["fl"], "order by id asc");
					if (all != null)
					{
						int num = -1;
						foreach (object current in all)
						{
							Gov_StepInfo gov_StepInfo2 = current as Gov_StepInfo;
							if (gov_StepInfo2.Acts == gov_StepInfo.Acts)
							{
								num = all.IndexOf(current) - 1;
							}
						}
						if (num >= 0)
						{
							Gov_StepInfo gov_StepInfo3 = this.MakeNewFsi((Gov_StepInfo)all[num]);
							Gov_StepAction.Init().Add(gov_StepActionInfo);
							GovInfo govInfo = byId;
							this.AddDoc(gov_StepActionInfo.FlowID, gov_StepActionInfo.id);
							govInfo.CurrentDocPath = this.filepath.Value;
							govInfo.CurrentStepID = gov_StepInfo3.id;
							govInfo.CurrentStepName = gov_StepInfo3.Step_Name;
							govInfo.CurrentStepUserList = gov_StepInfo3.userlist;
							GovInfo expr_34F = govInfo;
							string hasOperatedUserList = expr_34F.HasOperatedUserList;
							expr_34F.HasOperatedUserList = string.Concat(new string[]
							{
								hasOperatedUserList,
								this.RealName,
								"#",
								this.Uid,
								"#",
								this.DepName,
								","
							});
							govInfo.Flow_Files = this.UpdateFiles();
							Gov.Init().Update(govInfo);
							MessageBox.ShowAndRedirect(this, "成功操作,公文已返回!", "AppMenu.aspx");
						}
					}
				}
			}
		}
		protected void CompleteStep_Btn(object sender, EventArgs e)
		{
			GovInfo byId = Gov.Init().GetById(Convert.ToInt32(base.Request.QueryString["fl"]));
			string a = "";
			List<string> list = new List<string>();
			if (byId.CurrentStepUserList.Contains(",") && byId.CurrentStepUserList.Contains("#") && byId.Status == 0)
			{
				string[] array = byId.CurrentStepUserList.Split(new char[]
				{
					','
				});
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string text = array2[i];
					if (text.Contains("#"))
					{
						list.Add(text.Split(new char[]
						{
							'#'
						})[1]);
					}
				}
			}
			if (list.Contains(this.Uid))
			{
				a = this.Uid;
			}
			if (a != "")
			{
				Gov_StepInfo gov_StepInfo = this.ViewState["CurrentStep"] as Gov_StepInfo;
				Gov_StepActionInfo gov_StepActionInfo = new Gov_StepActionInfo();
				gov_StepActionInfo.AddTime = DateTime.Now;
				gov_StepActionInfo.FlowID = Convert.ToInt32(base.Request.QueryString["fl"]);
				gov_StepActionInfo.Operation = 1;
				gov_StepActionInfo.OperationStepID = gov_StepInfo.id;
				gov_StepActionInfo.OperationWord = "(同意 并签发公文) ：" + base.Request.Form["FlowRemark"];
				gov_StepActionInfo.UserDepName = this.DepName;
				gov_StepActionInfo.UserID = Convert.ToInt32(this.Uid);
				gov_StepActionInfo.UserRealName = this.RealName;
				gov_StepActionInfo.OperationStepName = gov_StepInfo.Step_Name;
				Gov_StepAction.Init().Add(gov_StepActionInfo);
				this.AddDoc(gov_StepActionInfo.FlowID, gov_StepActionInfo.id);
				byId.CurrentDocPath = this.filepath.Value;
				Gov.Init().Update(byId);
				this.FinishFlow();
				MessageBox.ShowAndRedirect(this, "公文已操作签发!", "AppMenu.aspx");
			}
		}
		private void FinishFlow()
		{
			GovInfo govInfo = this.ViewState["Flow"] as GovInfo;
			string str = string.Concat(new string[]
			{
				govInfo.HasOperatedUserList,
				this.RealName,
				"#",
				this.Uid,
				"#",
				this.DepName,
				","
			});
			string cmdText = "update Gov set Status=1,HasOperatedUserList='" + str + "' where status=0 and id=" + base.Request.QueryString["fl"];
			MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
			string title = "[系统通知] : 您拟稿的公文(" + govInfo.Flow_Name + ") 已通过审批正式签发!";
			string content = "恭喜您! 公文通过所有审核审批步骤 已成功签发!";
			int creatorID = govInfo.CreatorID;
			string userlist = string.Concat(new object[]
			{
				govInfo.CreatorRealName,
				"#",
				govInfo.CreatorID,
				"#",
				govInfo.CreatorDepName,
				","
			});
			string namelist = govInfo.CreatorRealName + "(" + govInfo.CreatorDepName + "),";
			Help.AdminSendMail(title, content, creatorID, userlist, namelist);
		}
		private void BackFlow()
		{
			GovInfo govInfo = this.ViewState["Flow"] as GovInfo;
			string str = string.Concat(new string[]
			{
				govInfo.HasOperatedUserList,
				this.RealName,
				"#",
				this.Uid,
				"#",
				this.DepName,
				","
			});
			string cmdText = "update Gov set Status=-2,HasOperatedUserList='" + str + "' where status=0 and id=" + base.Request.QueryString["fl"];
			MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
			string title = "[系统通知] : 您拟稿的公文(" + govInfo.Flow_Name + ") 已被退回!";
			string content = "您拟稿的公文 没有被审核通过!";
			int creatorID = govInfo.CreatorID;
			string userlist = string.Concat(new object[]
			{
				govInfo.CreatorRealName,
				"#",
				govInfo.CreatorID,
				"#",
				govInfo.CreatorDepName,
				","
			});
			string namelist = govInfo.CreatorRealName + "(" + govInfo.CreatorDepName + "),";
			Help.AdminSendMail(title, content, creatorID, userlist, namelist);
		}
		private bool IsAllVerifid()
		{
			bool flag = true;
			GovInfo govInfo = this.ViewState["Flow"] as GovInfo;
			IList all = Gov_StepAction.Init().GetAll(string.Concat(new object[]
			{
				"OperationStepID=",
				govInfo.CurrentStepID,
				" and FlowID=",
				govInfo.id
			}), null);
			string[] array = govInfo.CurrentStepUserList.Split(new char[]
			{
				','
			});
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].Contains("#"))
				{
					list.Add(array[i].Split(new char[]
					{
						'#'
					})[1]);
				}
			}
			foreach (object current in all)
			{
				Gov_StepActionInfo gov_StepActionInfo = current as Gov_StepActionInfo;
				list2.Add(gov_StepActionInfo.UserID.ToString());
			}
			bool result;
			if (list2.Count != list.Count)
			{
				result = false;
			}
			else
			{
				foreach (string current2 in list)
				{
					if (!list2.Contains(current2))
					{
						result = false;
						return result;
					}
				}
				result = flag;
			}
			return result;
		}
		private void Show(string fid)
		{
			GovInfo byId = Gov.Init().GetById(Convert.ToInt32(fid));
			if (byId.CurrentStepUserList.Contains("#" + this.Uid + "#") || byId.HasOperatedUserList.Contains("#" + this.Uid + "#") || byId.CreatorID == Convert.ToInt32(this.Uid) || this.Modules.Contains("38"))
			{
				this.ViewState["Flow"] = byId;
				this.filepath.Value = byId.CurrentDocPath;
				this.DocBody.InnerHtml = byId.DocBody;
				this.Flow_Name1.InnerText = byId.Flow_Name;
				this.ModelType.InnerText = this.GetModelType(byId.ComID);
				this.secret.InnerText = byId.Secret;
				this.status.InnerText = this.GetStatus(byId.Status);
				this.creator.InnerText = byId.CreatorRealName + "(" + byId.CreatorDepName + ")";
				this.addtime.InnerText = Utils.ConvertDate2(byId.AddTime);
				this.DocNo.InnerText = byId.DocNo;
				this.vlidtime.InnerText = "自动归档";
				if (byId.IsValid == 1)
				{
					this.vlidtime.InnerText = byId.ValidTime.ToString("yyyy-MM-dd") + " 之前归档";
				}
				this.currentstepname.InnerText = byId.CurrentStepName;
				if (!string.IsNullOrEmpty(byId.Remark))
				{
					this.bodys.InnerHtml = byId.Remark.Replace("\n", "<br>");
				}
				if (!string.IsNullOrEmpty(byId.Flow_Files) && byId.Flow_Files.Contains("|"))
				{
					List<TmpInfo> list = new List<TmpInfo>();
					string[] array = byId.Flow_Files.Split(new char[]
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
							string s = array[i].Replace("~", "");
							tmpInfo.Tmp1 = array[i];
							tmpInfo.Tmp2 = tmp;
							tmpInfo.Tmp3 = base.Server.UrlEncode(s);
							list.Add(tmpInfo);
						}
					}
					this.rpt.DataSource = list;
					this.rpt.DataBind();
				}
				Gov_StepInfo byId2 = Gov_Step.Init().GetById(byId.CurrentStepID);
				this.ViewState["CurrentStep"] = byId2;
				string text = "";
				IList all = Gov_StepAction.Init().GetAll(string.Concat(new object[]
				{
					"OperationStepID=",
					byId.CurrentStepID,
					" and FlowID=",
					byId.id
				}), "order by id asc");
				string[] array2 = byId.CurrentStepUserList.Split(new char[]
				{
					','
				});
				List<string> list2 = new List<string>();
				for (int i = 0; i < array2.Length; i++)
				{
					if (array2[i].Contains("#"))
					{
						list2.Add(array2[i].Split(new char[]
						{
							'#'
						})[0].Trim());
					}
				}
				foreach (object current in all)
				{
					Gov_StepActionInfo gov_StepActionInfo = current as Gov_StepActionInfo;
					if (gov_StepActionInfo.Operation == 1)
					{
						text = text + gov_StepActionInfo.UserRealName + "[已审/同意], ";
						if (list2.Contains(gov_StepActionInfo.UserRealName.Trim()))
						{
							list2.Remove(gov_StepActionInfo.UserRealName.Trim());
						}
					}
					if (gov_StepActionInfo.Operation == -1)
					{
						text = text + gov_StepActionInfo.UserRealName + "[已阅/不同意], ";
						if (list2.Contains(gov_StepActionInfo.UserRealName.Trim()))
						{
							list2.Remove(gov_StepActionInfo.UserRealName.Trim());
						}
					}
				}
				foreach (string current2 in list2)
				{
					text = text + current2 + "[未操作], ";
				}
				this.currentuserlist.InnerHtml = text;
				IList all2 = Gov_StepAction.Init().GetAll("FlowID=" + byId.id, "order by id asc");
				IList all3 = Gov_Doc.Init().GetAll("StepAction_ID=0 and flow_id=" + byId.id, null);
				Gov_DocInfo gov_DocInfo = all3[0] as Gov_DocInfo;
				base.Server.UrlEncode(gov_DocInfo.DocPath.Replace("~", ""));
				string text2 = this.yjs;
				this.yjs = string.Concat(new string[]
				{
					text2,
					"0、<u>发文拟稿</u> &nbsp;",
					byId.CreatorRealName,
					" 在 ",
					Utils.ConvertDate2(byId.AddTime),
					" 发起公文(初稿) &nbsp;<br>"
				});
				foreach (object current in all2)
				{
					Gov_StepActionInfo gov_StepActionInfo = current as Gov_StepActionInfo;
					IList all4 = Gov_Doc.Init().GetAll("StepAction_ID=" + gov_StepActionInfo.id, null);
					if (all4.Count == 0)
					{
						object obj = this.yjs;
						this.yjs = string.Concat(new object[]
						{
							obj,
							all2.IndexOf(current) + 1,
							"、<u>",
							gov_StepActionInfo.OperationStepName,
							"</u> &nbsp;",
							gov_StepActionInfo.UserRealName,
							" 在 ",
							Utils.ConvertDate2(gov_StepActionInfo.AddTime),
							" 已阅 &nbsp;<strong style='color:#ff0000'>",
							gov_StepActionInfo.OperationWord,
							"</strong><br>"
						});
					}
					else
					{
						Gov_DocInfo gov_DocInfo2 = all4[0] as Gov_DocInfo;
						base.Server.UrlEncode(gov_DocInfo2.DocPath.Replace("~", ""));
						object obj = this.yjs;
						this.yjs = string.Concat(new object[]
						{
							obj,
							all2.IndexOf(current) + 1,
							"、<u>",
							gov_StepActionInfo.OperationStepName,
							"</u> &nbsp;&nbsp; ",
							gov_StepActionInfo.UserRealName,
							" 在 ",
							Utils.ConvertDate2(gov_StepActionInfo.AddTime),
							" 已阅 &nbsp;<strong style='color:#ff0000'>",
							gov_StepActionInfo.OperationWord,
							"</strong><br>"
						});
					}
				}
				if (list2.Contains(this.RealName.Trim()) && byId.Status == 0)
				{
					this.displays.Visible = true;
					this.b1.Enabled = true;
					this.b2.Enabled = true;
					if (byId2.RightToFinish == 1)
					{
						this.b3.Visible = true;
						this.b3.Enabled = true;
					}
				}
			}
			else
			{
				base.Response.Write("<script>alert('您没有查看权限');window.location='AppList.aspx?action=verify';</script>");
			}
		}
		private Gov_StepInfo MakeNewFsi(Gov_StepInfo fsi)
		{
			Gov_StepInfo gov_StepInfo = new Gov_StepInfo();
			gov_StepInfo.Flow_ID = fsi.Flow_ID;
			gov_StepInfo.IsAct = 1;
			gov_StepInfo.IsEnd = fsi.IsEnd;
			gov_StepInfo.IsHead = fsi.IsHead;
			gov_StepInfo.IsUserEdit = fsi.IsUserEdit;
			gov_StepInfo.IsUserFile = fsi.IsUserFile;
			gov_StepInfo.MailAlert = fsi.MailAlert;
			gov_StepInfo.namelist = fsi.namelist;
			gov_StepInfo.RightToFinish = fsi.RightToFinish;
			gov_StepInfo.Step_Name = fsi.Step_Name;
			gov_StepInfo.Step_Orders = fsi.Step_Orders;
			gov_StepInfo.Step_Remark = fsi.Step_Remark;
			gov_StepInfo.userlist = fsi.userlist;
			gov_StepInfo.Acts = fsi.Acts;
			Gov_Step.Init().Add(gov_StepInfo);
			return gov_StepInfo;
		}
		private string GetStatus(int t)
		{
			string result;
			if (t == 0)
			{
				result = "公文审批中";
			}
			else
			{
				if (t == 1)
				{
					result = "公文已签发";
				}
				else
				{
					if (t == -1)
					{
						result = "公文已锁定";
					}
					else
					{
						if (t == -2)
						{
							result = "公文已退回";
						}
						else
						{
							if (t == 5)
							{
								result = "公文已归档";
							}
							else
							{
								result = "已过期";
							}
						}
					}
				}
			}
			return result;
		}
		private void AddDoc(int fid, int stepid)
		{
			GovInfo govInfo = this.ViewState["Flow"] as GovInfo;
			Gov_DocInfo gov_DocInfo = new Gov_DocInfo();
			gov_DocInfo.AddTime = DateTime.Now;
			gov_DocInfo.DocPath = this.filepath.Value;
			gov_DocInfo.DocBody = govInfo.DocBody;
			gov_DocInfo.Flow_ID = fid;
			gov_DocInfo.StepAction_ID = stepid;
			gov_DocInfo.UserDepName = this.DepName;
			gov_DocInfo.UserRealName = this.RealName;
			gov_DocInfo.UserID = Convert.ToInt32(this.Uid);
			Gov_Doc.Init().Add(gov_DocInfo);
		}
		private string UpdateFiles()
		{
			string text = "";
			HttpFileCollection files = HttpContext.Current.Request.Files;
			string text2 = DateTime.Now.ToString("yyMMdd");
			string text3 = base.Server.MapPath("~/Files/GovFiles/");
			string str = "~/Files/GovFiles/" + text2 + "/";
			text3 += text2;
			if (!Directory.Exists(text3))
			{
				FileSystemManager.CreateFolder(text2, base.Server.MapPath("~/Files/GovFiles"));
			}
			try
			{
				string str2 = "";
				foreach (RepeaterItem repeaterItem in this.rpt.Items)
				{
					HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
					if (htmlInputCheckBox.Checked)
					{
						str2 = str2 + htmlInputCheckBox.Value + "|";
					}
				}
				if (this.displays.Visible)
				{
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
			}
			catch (IOException ex)
			{
				throw ex;
			}
			return text;
		}
		private string GetModelType(int comid)
		{
			string result = "暂无分类";
			if (comid > 0)
			{
				IList all = Gov_Model_Type.Init().GetAll("id=" + comid, null);
				if (all.Count > 0)
				{
					Gov_Model_TypeInfo gov_Model_TypeInfo = all[0] as Gov_Model_TypeInfo;
					result = gov_Model_TypeInfo.TypeName;
				}
			}
			return result;
		}
	}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             