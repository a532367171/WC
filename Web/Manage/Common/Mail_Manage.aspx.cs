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

public partial class Manage_Common_Mail_Manage : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlGenericControl sjx;
        //protected HtmlGenericControl cgx;
        //protected HtmlGenericControl fjx;
        //protected HtmlGenericControl ljx;
        //protected Button Button2;
        //protected Button Button3;
        //protected HtmlInputCheckBox IsSave;
        //protected HtmlInputCheckBox ReadBack;
        //protected HtmlInputText Subject;
        //protected HtmlInputHidden userlist;
        //protected HtmlTextArea namelist;
        //protected HtmlInputHidden userlist_cc;
        //protected HtmlInputText namelist_cc;
        //protected HtmlInputHidden userlist_bcc;
        //protected HtmlInputText namelist_bcc;
        //protected HtmlTextArea Bodys;
        //protected CheckBox IsSms;
        //protected HtmlGenericControl dvReadAttach;
        //protected Panel Attachword;
        //protected Repeater rpt;
        //protected Button save_bt;
        //protected Button Button1;
		private int ct = 0;
		private object tobj = null;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Show();
				if (!string.IsNullOrEmpty(base.Request.QueryString["userlist"]))
				{
					string text = base.Request.QueryString["userlist"];
					if (Utils.IsNumber(text))
					{
						Sys_UserInfo sys_UserInfo = Sys_User.Init().GetById(Convert.ToInt32(text));
						this.userlist.Value = string.Concat(new object[]
						{
							sys_UserInfo.RealName.Trim(),
							"#",
							sys_UserInfo.id,
							"#",
							sys_UserInfo.DepName.Trim(),
							","
						});
						this.namelist.Value = sys_UserInfo.RealName.Trim() + "(" + sys_UserInfo.DepName.Trim() + "),";
					}
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["deplist"]))
				{
					string text2 = base.Request.QueryString["deplist"];
					if (Utils.IsNumber(text2))
					{
						IList list = new List<Sys_UserInfo>();
						this.GetTreeItems(Convert.ToInt32(text2), list);
						string text3 = "";
						string text4 = "";
						foreach (object current in list)
						{
							Sys_UserInfo sys_UserInfo = current as Sys_UserInfo;
							object obj = text3;
							text3 = string.Concat(new object[]
							{
								obj,
								sys_UserInfo.RealName.Trim(),
								"#",
								sys_UserInfo.id,
								"#",
								sys_UserInfo.DepName.Trim(),
								","
							});
							string text5 = text4;
							text4 = string.Concat(new string[]
							{
								text5,
								sys_UserInfo.RealName.Trim(),
								"(",
								sys_UserInfo.DepName.Trim(),
								"),"
							});
							this.userlist.Value = text3;
							this.namelist.Value = text4;
						}
					}
				}
			}
		}
		private void GetTreeItems(int did, IList li)
		{
			IList all = Sys_User.Init().GetAll("DepID=" + did, "order by status asc,orders asc");
			foreach (object current in all)
			{
				li.Add(current);
			}
			IList all2 = Sys_Dep.Init().GetAll("ParentID=" + did, "order by orders asc");
			if (all2.Count != 0)
			{
				foreach (Sys_DepInfo sys_DepInfo in all2)
				{
					this.GetTreeItems(sys_DepInfo.id, li);
				}
			}
		}
		private void Show()
		{
			if (!string.IsNullOrEmpty(this.Uid))
			{
				SqlParameter sqlParameter = new SqlParameter();
				sqlParameter.ParameterName = "@uid";
				sqlParameter.Size = 4;
				sqlParameter.Value = Convert.ToInt32(this.Uid);
				SqlParameter sqlParameter2 = new SqlParameter();
				sqlParameter2.Direction = ParameterDirection.Output;
				sqlParameter2.ParameterName = "@pt0";
				sqlParameter2.Size = 4;
				SqlParameter sqlParameter3 = new SqlParameter();
				sqlParameter3.Direction = ParameterDirection.Output;
				sqlParameter3.ParameterName = "@pt1";
				sqlParameter3.Size = 4;
				SqlParameter sqlParameter4 = new SqlParameter();
				sqlParameter4.Direction = ParameterDirection.Output;
				sqlParameter4.ParameterName = "@pt2";
				sqlParameter4.Size = 4;
				SqlParameter sqlParameter5 = new SqlParameter();
				sqlParameter5.Direction = ParameterDirection.Output;
				sqlParameter5.ParameterName = "@pt3";
				sqlParameter5.Size = 4;
				SqlParameter sqlParameter6 = new SqlParameter();
				sqlParameter6.Direction = ParameterDirection.Output;
				sqlParameter6.ParameterName = "@pt4";
				sqlParameter6.Size = 4;
				SqlParameter[] cmdParms = new SqlParameter[]
				{
					sqlParameter2,
					sqlParameter3,
					sqlParameter4,
					sqlParameter5,
					sqlParameter6,
					sqlParameter
				};
				MsSqlOperate.ExecuteNonQuery(CommandType.StoredProcedure, "Mails_GetAllMailBoxCount", cmdParms);
				this.sjx.InnerText = sqlParameter2.Value + "/" + sqlParameter6.Value;
				this.cgx.InnerText = string.Concat(sqlParameter3.Value);
				this.fjx.InnerText = string.Concat(sqlParameter4.Value);
				this.ljx.InnerText = string.Concat(sqlParameter5.Value);
				if (!string.IsNullOrEmpty(base.Request.QueryString["mid"]))
				{
					string value = base.Request.QueryString["mid"];
					MailsInfo byId = Mails.Init().GetById(Convert.ToInt32(value));
					if (byId.ReceiverID == Convert.ToInt32(this.Uid) || byId.SenderID == Convert.ToInt32(this.Uid))
					{
						Mails_DetailInfo byId2 = Mails_Detail.Init().GetById(byId.did);
						this.Subject.Value = "回复：" + byId.Subject;
						this.userlist.Value = string.Concat(new object[]
						{
							byId.SenderRealName,
							"#",
							byId.SenderID,
							"#",
							byId.SenderDepName,
							","
						});
						this.namelist.Value = byId.SenderRealName + "(" + byId.SenderDepName + "),";
						this.Bodys.Value = string.Concat(new string[]
						{
							"<br><br><br><span style='font-weight:bold;color:#999999'>",
							byId.SenderRealName,
							" (",
							byId.SenderDepName,
							") 在 ",
							Utils.ConvertDate2(byId.SendTime),
							" 写道: </span><br>",
							byId2.Bodys
						});
						if (!string.IsNullOrEmpty(byId2.Attachments) && byId2.Attachments.Contains("|"))
						{
							this.Attachword.Visible = true;
							List<TmpInfo> list = new List<TmpInfo>();
							string[] array = byId2.Attachments.Split(new char[]
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
				if (!string.IsNullOrEmpty(base.Request.QueryString["cid"]))
				{
					string value2 = base.Request.QueryString["cid"];
					MailsInfo byId = Mails.Init().GetById(Convert.ToInt32(value2));
					if (byId.ReceiverID == Convert.ToInt32(this.Uid) || byId.SenderID == Convert.ToInt32(this.Uid))
					{
						Mails_DetailInfo byId2 = Mails_Detail.Init().GetById(byId.did);
						this.Subject.Value = byId.Subject;
						if (!string.IsNullOrEmpty(byId2.SendIDs) && !string.IsNullOrEmpty(byId2.SendRealNames))
						{
							this.userlist.Value = byId2.SendIDs;
							this.namelist.Value = byId2.SendRealNames;
						}
						if (!string.IsNullOrEmpty(byId2.CcIDs) && !string.IsNullOrEmpty(byId2.CcRealNames))
						{
							this.userlist_cc.Value = byId2.CcIDs;
							this.namelist_cc.Value = byId2.CcRealNames;
						}
						if (!string.IsNullOrEmpty(byId2.BccIDs) && !string.IsNullOrEmpty(byId2.BccRealNames))
						{
							this.userlist_bcc.Value = byId2.BccIDs;
							this.namelist_bcc.Value = byId2.BccRealNames;
						}
						this.Bodys.Value = byId2.Bodys;
						if (!string.IsNullOrEmpty(byId2.Attachments) && byId2.Attachments.Contains("|"))
						{
							this.Attachword.Visible = true;
							List<TmpInfo> list = new List<TmpInfo>();
							string[] array = byId2.Attachments.Split(new char[]
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
				if (!string.IsNullOrEmpty(base.Request.QueryString["zid"]))
				{
					string value2 = base.Request.QueryString["zid"];
					MailsInfo byId = Mails.Init().GetById(Convert.ToInt32(value2));
					if (byId.ReceiverID == Convert.ToInt32(this.Uid) || byId.SenderID == Convert.ToInt32(this.Uid))
					{
						Mails_DetailInfo byId2 = Mails_Detail.Init().GetById(byId.did);
						this.Subject.Value = "转发：" + byId.Subject;
						this.Bodys.Value = "<br><br>" + byId2.Bodys;
						if (!string.IsNullOrEmpty(byId2.Attachments) && byId2.Attachments.Contains("|"))
						{
							this.Attachword.Visible = true;
							List<TmpInfo> list = new List<TmpInfo>();
							string[] array = byId2.Attachments.Split(new char[]
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
				if (!string.IsNullOrEmpty(base.Request.QueryString["meeting"]))
				{
					MeetingInfo byId3 = Meeting.Init().GetById(Convert.ToInt32(base.Request.QueryString["meeting"]));
					string format = "<br><br><table style='width:95%;' border='1' cellspacing='0' bordercolor='#c0bdbd' cellpadding='2'><tbody><tr><td style='width:95px;color:#222;font-weight:bold;'>&nbsp;会议主题：</td><td>{0}</td></tr><tr><td style='color:#222;font-weight:bold;'>&nbsp;时间/地点：</td><td>{1}</td></tr><tr><td style='color:#222;font-weight:bold;'>&nbsp;会议主持：</td><td>{2}</td></tr><tr><td style='color:#222;font-weight:bold;'>&nbsp;记录人员：</td><td>{3}</td></tr><tr><td style='color:#222;font-weight:bold;'>会议参加者：</td><td>{4}</td></tr><tr><td style='color:#222;font-weight:bold;'>会议缺席者：</td><td>{5}</td></tr><tr><td style='color:#222;font-weight:bold;'>&nbsp;会议纪要：</td><td>{6}</td></tr><tr><td style='color:#222;font-weight:bold;'>&nbsp;备注：</td><td>{7}</td></tr></tbody></table><br>";
					this.Bodys.Value = string.Format(format, new object[]
					{
						byId3.MainTopics,
						byId3.CTime + " &nbsp; &nbsp; &nbsp; " + byId3.Address,
						byId3.Chaired,
						byId3.Recorder,
						byId3.ListPerson,
						byId3.AbsencePerson,
						byId3.Bodys,
						byId3.Remarks
					});
					if (!string.IsNullOrEmpty(byId3.FilePath) && byId3.FilePath.Contains("|"))
					{
						this.Attachword.Visible = true;
						List<TmpInfo> list = new List<TmpInfo>();
						string[] array = byId3.FilePath.Split(new char[]
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
				if (!string.IsNullOrEmpty(base.Request.QueryString["notebook"]))
				{
					NoteBookInfo byId4 = NoteBook.Init().GetById(Convert.ToInt32(base.Request.QueryString["notebook"]));
					string format2 = "<br><br><table style='width:95%;' border='1' cellspacing='0' bordercolor='#c0bdbd' cellpadding='2'><tbody><tr><td style='width:95px;color:#222;font-weight:bold;'>&nbsp;记事主题：</td><td>{0}</td></tr><tr><td style='width:95px;color:#222;font-weight:bold;'>&nbsp;记事时间：</td><td>{1}</td></tr><tr><td style='color:#222;font-weight:bold;'>&nbsp;记事内容：</td><td>{2}</td></tr><tr></tr></tbody></table><br>";
					this.Bodys.Value = string.Format(format2, byId4.Subject, Utils.ConvertDate3(byId4.AddTime), byId4.Bodys.Replace("\r\n", "<br>"));
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["privateaddr"]))
				{
					PhoneBookInfo byId5 = PhoneBook.Init().GetById(Convert.ToInt32(base.Request.QueryString["privateaddr"]));
					string format3 = "<br><br><table style='width:95%;' border='1' cellspacing='0' bordercolor='#c0bdbd' cellpadding='2'><tbody><tr><td style='width:95px;color:#222;font-weight:bold;'>&nbsp;姓名：</td><td>{0}</td></tr><tr><td style='color:#222;font-weight:bold;'>&nbsp;标签：</td><td>{1}</td></tr><tr></tr><tr><td style='color:#222;font-weight:bold;'>&nbsp;电话：</td><td>{2}</td></tr><tr></tr><tr><td style='color:#222;font-weight:bold;'>&nbsp;备注：</td><td>{3}</td></tr><tr></tr></tbody></table><br>";
					this.Bodys.Value = string.Format(format3, new object[]
					{
						byId5.Person,
						byId5.TagName,
						byId5.Phone,
						byId5.Notes.Replace("\r\n", "<br>")
					});
				}
			}
			else
			{
				base.Response.Write("<script>alert('会话已过期,请重新登录!');window.location='/InfoTip/Operate_Nologin.aspx?ReturnUrl=" + base.Request.Url.AbsoluteUri + "'</script>");
			}
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.Uid) && !string.IsNullOrEmpty(this.RealName) && !string.IsNullOrEmpty(this.DepName))
			{
				string sendnames = "";
				string ccnames = "";
				string bccnames = "";
				int num = 0;
				string attachments = this.UpdateFiles();
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				List<string> list4 = new List<string>();
				if (!string.IsNullOrEmpty(this.userlist_bcc.Value))
				{
					string[] array = this.userlist_bcc.Value.Split(new char[]
					{
						','
					});
					int num2 = 3;
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
							list4.Add(item);
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
					string.Join(",", list4.ToArray());
					bccnames = this.namelist_bcc.Value;
				}
				if (!string.IsNullOrEmpty(this.userlist_cc.Value))
				{
					string[] array3 = this.userlist_cc.Value.Split(new char[]
					{
						','
					});
					int num2 = 2;
					string[] array2 = array3;
					for (int i = 0; i < array2.Length; i++)
					{
						string text = array2[i];
						if (text.Trim() != "")
						{
							string item = text.Split(new char[]
							{
								'#'
							})[1];
							list3.Add(item);
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
					string.Join(",", list3.ToArray());
					ccnames = this.namelist_cc.Value;
				}
				if (!string.IsNullOrEmpty(this.userlist.Value))
				{
					string[] array4 = this.userlist.Value.Split(new char[]
					{
						','
					});
					int num2 = 0;
					string[] array2 = array4;
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
				string[] array5 = list.ToArray();
				List<string> list5 = new List<string>();
				for (int j = 0; j < array5.Length; j++)
				{
					if (Utils.IsNumber(array5[j].Split(new char[]
					{
						'|'
					})[0]))
					{
						this.AddMail(0, Convert.ToInt32(array5[j].Split(new char[]
						{
							'|'
						})[1]), Convert.ToInt32(array5[j].Split(new char[]
						{
							'|'
						})[0]), this.Uid, this.RealName, this.DepName, this.userlist.Value, sendnames, this.userlist_cc.Value, ccnames, this.userlist_bcc.Value, bccnames, attachments);
						num++;
					}
				}
				if (this.IsSave.Checked)
				{
					this.AddMail(2, 4, Convert.ToInt32(this.Uid), this.Uid, this.RealName, this.DepName, this.userlist.Value, sendnames, this.userlist_cc.Value, ccnames, this.userlist_bcc.Value, bccnames, attachments);
				}
				if (list5.Count > 0 && this.IsSms.Checked)
				{
					Help.MailMobleSend(list5, this.Subject.Value);
				}
				string str = HttpContext.Current.Server.HtmlEncode("您好!邮件发送成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
			else
			{
				base.Response.Write("<script>alert('会话已过期,请重新登录!');window.location='/InfoTip/Operate_Nologin.aspx?ReturnUrl=" + base.Request.Url.AbsoluteUri + "'</script>");
			}
		}
		protected void Caogao_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.Uid) && !string.IsNullOrEmpty(this.RealName) && !string.IsNullOrEmpty(this.DepName))
			{
				string sendnames = "";
				string ccnames = "";
				string bccnames = "";
				string attachments = this.UpdateFiles();
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				List<string> list4 = new List<string>();
				if (!string.IsNullOrEmpty(this.userlist_bcc.Value))
				{
					string[] array = this.userlist_bcc.Value.Split(new char[]
					{
						','
					});
					int num = 3;
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
							list4.Add(item);
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
					string.Join(",", list4.ToArray());
					bccnames = this.namelist_bcc.Value;
				}
				if (!string.IsNullOrEmpty(this.userlist_cc.Value))
				{
					string[] array3 = this.userlist_cc.Value.Split(new char[]
					{
						','
					});
					int num = 2;
					string[] array2 = array3;
					for (int i = 0; i < array2.Length; i++)
					{
						string text = array2[i];
						if (text.Trim() != "")
						{
							string item = text.Split(new char[]
							{
								'#'
							})[1];
							list3.Add(item);
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
					string.Join(",", list3.ToArray());
					ccnames = this.namelist_cc.Value;
				}
				if (!string.IsNullOrEmpty(this.userlist.Value))
				{
					string[] array4 = this.userlist.Value.Split(new char[]
					{
						','
					});
					int num = 0;
					string[] array2 = array4;
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
				this.AddMail(1, 1, Convert.ToInt32(this.Uid), this.Uid, this.RealName, this.DepName, this.userlist.Value, sendnames, this.userlist_cc.Value, ccnames, this.userlist_bcc.Value, bccnames, attachments);
				string str = HttpContext.Current.Server.HtmlEncode("您好!邮件已成功保存到草稿箱!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
			else
			{
				base.Response.Write("<script>alert('会话已过期,请重新登录!');window.location='/InfoTip/Operate_Nologin.aspx?ReturnUrl=" + base.Request.Url.AbsoluteUri + "'</script>");
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
				if (this.ReadBack.Checked)
				{
					mailsInfo.SenderGUID = "1";
				}
				else
				{
					mailsInfo.SenderGUID = "";
				}
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    