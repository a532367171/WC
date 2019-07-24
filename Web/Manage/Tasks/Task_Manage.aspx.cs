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

public partial class Manage_Tasks_Task_Manage : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlGenericControl t_all;
        //protected HtmlGenericControl t_exeute;
        //protected HtmlGenericControl t_manage;
        //protected HtmlGenericControl t_create;
        //protected Button Button2;
        //protected HtmlInputText TaskName;
        //protected DropDownList TypeID;
        //protected HtmlInputText ExpectTime;
        //protected HtmlInputHidden userlist;
        //protected HtmlInputText namelist;
        //protected HtmlInputButton user_manager;
        //protected HtmlInputHidden userlist_cc;
        //protected HtmlTextArea namelist_cc;
        //protected HtmlTextArea Bodys;
        //protected HtmlSelect Important;
        //protected HtmlInputCheckBox IsOtherSee;
        //protected HtmlInputCheckBox OnceSubmit;
        //protected HtmlGenericControl dvReadAttach;
        //protected Panel Attachword;
        //protected Repeater rpt;
        //protected Button save_bt;
		private int i = 1;
		private IList<Tasks_TypeInfo> li = new List<Tasks_TypeInfo>();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Show();
			}
		}
		private void Show()
		{
			SqlParameter sqlParameter = new SqlParameter();
			sqlParameter.ParameterName = "@uid";
			sqlParameter.Size = 50;
			sqlParameter.Value = this.Uid;
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
			SqlParameter[] cmdParms = new SqlParameter[]
			{
				sqlParameter2,
				sqlParameter3,
				sqlParameter4,
				sqlParameter5,
				sqlParameter
			};
			MsSqlOperate.ExecuteNonQuery(CommandType.StoredProcedure, "Tasks_GetTaskCount", cmdParms);
			this.t_all.InnerText = string.Concat(sqlParameter2.Value);
			this.t_exeute.InnerText = string.Concat(sqlParameter3.Value);
			this.t_manage.InnerText = string.Concat(sqlParameter4.Value);
			this.t_create.InnerText = string.Concat(sqlParameter5.Value);
			this.GetFirtNode();
			this.TypeID.DataSource = this.li;
			this.TypeID.DataTextField = "Sh";
			this.TypeID.DataValueField = "ID";
			this.TypeID.DataBind();
			if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
			{
				this.user_manager.Disabled = true;
				TasksInfo byId = Tasks.Init().GetById(Convert.ToInt32(base.Request.QueryString["tid"]));
				if (byId.ManageUserList.Contains("#" + this.Uid + "#"))
				{
					this.ViewState["ti"] = byId;
					this.TaskName.Value = byId.TaskName;
					this.TypeID.SelectedValue = string.Concat(byId.TypeID);
					this.userlist.Value = byId.ManageUserList;
					this.namelist.Value = byId.ManageNameList;
					this.userlist_cc.Value = byId.ExecuteUserList;
					this.namelist_cc.Value = byId.ExecuteNameList;
					this.Bodys.Value = byId.Notes;
					this.ExpectTime.Value = byId.ExpectTime;
					this.Important.Value = byId.Important;
					this.IsOtherSee.Checked = Convert.ToBoolean(byId.IsOtherSee);
					this.OnceSubmit.Checked = Convert.ToBoolean(byId.OnceSubmit);
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
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(base.Request.QueryString["tid"]))
			{
				TasksInfo tasksInfo = new TasksInfo();
				tasksInfo.TaskName = this.TaskName.Value;
				tasksInfo.TypeID = Convert.ToInt32(base.Request.Form["TypeID"]);
				tasksInfo.TypeName = this.ClearLeaf(this.TypeID.Items[this.TypeID.SelectedIndex].Text);
				tasksInfo.Important = base.Request.Form["Important"];
				tasksInfo.Status = 1;
				tasksInfo.IsOtherSee = Convert.ToInt32(this.IsOtherSee.Checked);
				tasksInfo.OnceSubmit = Convert.ToInt32(this.OnceSubmit.Checked);
				tasksInfo.CreatorID = Convert.ToInt32(this.Uid);
				tasksInfo.CreatorRealName = this.RealName;
				tasksInfo.CreatorDepName = this.DepName;
				tasksInfo.AddTime = DateTime.Now.ToString("yyyy-MM-dd");
				tasksInfo.UpdateTime = DateTime.Now.ToString("yy-M-dd HH:mm");
				tasksInfo.ExpectTime = this.ExpectTime.Value;
				tasksInfo.Notes = this.Bodys.Value;
				tasksInfo.FilePath = this.UpdateFiles();
				TasksInfo expr_161 = tasksInfo;
				string records = expr_161.Records;
				expr_161.Records = string.Concat(new string[]
				{
					records,
					"<font color='#006600'>[创建人]</font> <strong>",
					this.RealName,
					"(",
					this.DepName,
					")</strong> 在 ",
					Utils.ConvertDate3(DateTime.Now),
					" <strong style='color:#ff0000'>创建了任务</strong> <br><br>"
				});
				tasksInfo.ManageUserList = this.userlist.Value;
				tasksInfo.ManageNameList = this.namelist.Value;
				tasksInfo.ExecuteUserList = this.userlist_cc.Value;
				tasksInfo.ExecuteNameList = this.namelist_cc.Value;
				Tasks.Init().Add(tasksInfo);
				this.SendManageMail(true, tasksInfo.ManageUserList, tasksInfo.ManageUserList, tasksInfo);
				this.AddTasksUser(tasksInfo.ExecuteUserList, tasksInfo.id, tasksInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!工作任务已新建成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
			else
			{
				TasksInfo tasksInfo = this.ViewState["ti"] as TasksInfo;
				if (tasksInfo.ManageUserList.Contains("#" + this.Uid + "#"))
				{
					tasksInfo.TaskName = this.TaskName.Value;
					tasksInfo.TypeID = Convert.ToInt32(this.TypeID.SelectedValue);
					tasksInfo.TypeName = this.ClearLeaf(this.TypeID.Items[this.TypeID.SelectedIndex].Text);
					tasksInfo.Important = base.Request.Form["Important"];
					tasksInfo.Status = 1;
					tasksInfo.IsOtherSee = Convert.ToInt32(this.IsOtherSee.Checked);
					tasksInfo.OnceSubmit = Convert.ToInt32(this.OnceSubmit.Checked);
					tasksInfo.UpdateTime = DateTime.Now.ToString("yy-M-dd HH:mm");
					tasksInfo.ExpectTime = this.ExpectTime.Value;
					tasksInfo.Notes = this.Bodys.Value;
					tasksInfo.FilePath = this.UpdateFiles();
					TasksInfo expr_3AF = tasksInfo;
					string records = expr_3AF.Records;
					expr_3AF.Records = string.Concat(new string[]
					{
						records,
						"<font color='#006600'>[管理者]</font> <strong>",
						this.RealName,
						"(",
						this.DepName,
						")</strong> 在 ",
						Utils.ConvertDate3(DateTime.Now),
						" <strong style='color:#ff0000'>重新编辑了任务</strong> <br><br>"
					});
					string executeUserList = tasksInfo.ExecuteUserList;
					string manageUserList = tasksInfo.ManageUserList;
					tasksInfo.ManageUserList = this.userlist.Value;
					tasksInfo.ManageNameList = this.namelist.Value;
					tasksInfo.ExecuteUserList = this.userlist_cc.Value;
					tasksInfo.ExecuteNameList = this.namelist_cc.Value;
					Tasks.Init().Update(tasksInfo);
					this.SendManageMail(false, manageUserList, tasksInfo.ManageUserList, tasksInfo);
					this.UpdateTasksUser(executeUserList, this.userlist_cc.Value, tasksInfo);
					string str = HttpContext.Current.Server.HtmlEncode("您好!工作任务已重新编辑!");
					base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
				}
			}
		}
		private void AddTasksUser(string ulist, int tid, TasksInfo tk)
		{
			if (ulist.Contains(","))
			{
				string[] array = ulist.Split(new char[]
				{
					','
				});
				int i = 0;
				int num = array.Length;
				while (i < num)
				{
					if (array[i].Contains("#"))
					{
						Tasks_UserInfo tasks_UserInfo = new Tasks_UserInfo();
						tasks_UserInfo.TaskID = tid;
						tasks_UserInfo.RealName = array[i].Split(new char[]
						{
							'#'
						})[0];
						tasks_UserInfo.UserID = Convert.ToInt32(array[i].Split(new char[]
						{
							'#'
						})[1]);
						tasks_UserInfo.DepName = array[i].Split(new char[]
						{
							'#'
						})[2];
						tasks_UserInfo.AddTime = "";
						tasks_UserInfo.WorkTag = -1;
						tasks_UserInfo.Instruction = "";
						Tasks_User.Init().Add(tasks_UserInfo);
						string title = "[系统通知] : " + tasks_UserInfo.RealName + ", 您好! 您有新工作任务需要执行!";
						string content = string.Concat(new string[]
						{
							"任务名称：<strong>",
							tk.TaskName,
							"</strong><br>任务分类：",
							tk.TypeName,
							" <br>任务级别：",
							tk.Important,
							"<br>任务管理者：",
							tk.ManageNameList,
							"<br>"
						});
						int userID = tasks_UserInfo.UserID;
						string text = string.Concat(new object[]
						{
							tasks_UserInfo.RealName,
							"#",
							tasks_UserInfo.id,
							"#",
							tasks_UserInfo.DepName,
							","
						});
						string text2 = tasks_UserInfo.RealName + "(" + tasks_UserInfo.DepName + "),";
						Help.AdminSendMail(title, content, userID, text, text2);
					}
					i++;
				}
			}
		}
		private void SendManageMail(bool isadd, string old_str, string new_str, TasksInfo tk)
		{
			if (isadd)
			{
				if (old_str.Contains(","))
				{
					string[] array = old_str.Split(new char[]
					{
						','
					});
					int i = 0;
					int num = array.Length;
					while (i < num)
					{
						if (array[i].Contains("#"))
						{
							string title = "[系统通知] : " + array[i].Split(new char[]
							{
								'#'
							})[0] + ", 您好! 您有新工作任务需要管理!";
							string content = string.Concat(new string[]
							{
								"任务名称：<strong>",
								tk.TaskName,
								"</strong><br>任务分类：",
								tk.TypeName,
								" <br>任务级别：",
								tk.Important,
								"<br>任务管理者：",
								tk.ManageNameList,
								"<br>"
							});
							int receiverid = Convert.ToInt32(array[i].Split(new char[]
							{
								'#'
							})[1]);
							string text = string.Concat(new string[]
							{
								array[i].Split(new char[]
								{
									'#'
								})[0],
								"#",
								array[i].Split(new char[]
								{
									'#'
								})[1],
								"#",
								array[i].Split(new char[]
								{
									'#'
								})[2],
								","
							});
							string text2 = array[i].Split(new char[]
							{
								'#'
							})[0] + "(" + array[i].Split(new char[]
							{
								'#'
							})[2] + "),";
							Help.AdminSendMail(title, content, receiverid, text, text2);
						}
						i++;
					}
				}
			}
			else
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				if (old_str.Contains(","))
				{
					string[] array = old_str.Split(new char[]
					{
						','
					});
					int i = 0;
					int num = array.Length;
					while (i < num)
					{
						if (array[i].Contains("#"))
						{
							list.Add(array[i]);
						}
						i++;
					}
				}
				if (new_str.Contains(","))
				{
					string[] array = new_str.Split(new char[]
					{
						','
					});
					int i = 0;
					int num = array.Length;
					while (i < num)
					{
						if (array[i].Contains("#"))
						{
							list2.Add(array[i]);
						}
						i++;
					}
				}
				string text3 = string.Join("!", list.ToArray());
				string.Join("!", list2.ToArray());
				string[] array2 = list2.ToArray();
				for (int i = 0; i < array2.Length; i++)
				{
					if (text3.IndexOf(array2[i]) == -1)
					{
						list3.Add(array2[i]);
					}
				}
				foreach (string current in list3)
				{
					if (current.Contains("#"))
					{
						string title = "[系统通知] : " + current.Split(new char[]
						{
							'#'
						})[0] + ", 您好! 您有新工作任务需要管理!";
						string content = string.Concat(new string[]
						{
							"任务名称：<strong>",
							tk.TaskName,
							"</strong><br>任务分类：",
							tk.TypeName,
							" <br>任务级别：",
							tk.Important,
							"<br>任务管理者：",
							tk.ManageNameList,
							"<br>"
						});
						int receiverid = Convert.ToInt32(current.Split(new char[]
						{
							'#'
						})[1]);
						string text = string.Concat(new string[]
						{
							current.Split(new char[]
							{
								'#'
							})[0],
							"#",
							current.Split(new char[]
							{
								'#'
							})[1],
							"#",
							current.Split(new char[]
							{
								'#'
							})[2],
							","
						});
						string text2 = current.Split(new char[]
						{
							'#'
						})[0] + "(" + current.Split(new char[]
						{
							'#'
						})[2] + "),";
						Help.AdminSendMail(title, content, receiverid, text, text2);
					}
				}
			}
		}
		private void UpdateTasksUser(string old_str, string new_str, TasksInfo tk)
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			List<string> list4 = new List<string>();
			if (old_str.Contains(","))
			{
				string[] array = old_str.Split(new char[]
				{
					','
				});
				int i = 0;
				int num = array.Length;
				while (i < num)
				{
					if (array[i].Contains("#"))
					{
						list.Add(array[i]);
					}
					i++;
				}
			}
			if (new_str.Contains(","))
			{
				string[] array = new_str.Split(new char[]
				{
					','
				});
				int i = 0;
				int num = array.Length;
				while (i < num)
				{
					if (array[i].Contains("#"))
					{
						list2.Add(array[i]);
					}
					i++;
				}
			}
			string text = string.Join("!", list.ToArray());
			string text2 = string.Join("!", list2.ToArray());
			string[] array2 = list.ToArray();
			string[] array3 = list2.ToArray();
			for (int i = 0; i < array2.Length; i++)
			{
				if (text2.IndexOf(array2[i]) == -1)
				{
					list4.Add(array2[i]);
				}
			}
			for (int i = 0; i < array3.Length; i++)
			{
				if (text.IndexOf(array3[i]) == -1)
				{
					list3.Add(array3[i]);
				}
			}
			foreach (string current in list3)
			{
				if (current.Contains("#"))
				{
					Tasks_UserInfo tasks_UserInfo = new Tasks_UserInfo();
					tasks_UserInfo.TaskID = tk.id;
					tasks_UserInfo.RealName = current.Split(new char[]
					{
						'#'
					})[0];
					tasks_UserInfo.UserID = Convert.ToInt32(current.Split(new char[]
					{
						'#'
					})[1]);
					tasks_UserInfo.DepName = current.Split(new char[]
					{
						'#'
					})[2];
					tasks_UserInfo.AddTime = "";
					tasks_UserInfo.WorkTag = -1;
					tasks_UserInfo.Instruction = "";
					Tasks_User.Init().Add(tasks_UserInfo);
					string title = "[系统通知] : " + tasks_UserInfo.RealName + ", 您好! 您有新工作任务需要执行!";
					string content = string.Concat(new string[]
					{
						"任务名称：<strong>",
						tk.TaskName,
						"</strong><br>任务分类：",
						tk.TypeName,
						" <br>任务级别：",
						tk.Important,
						"<br>任务管理者：",
						tk.ManageNameList,
						"<br>"
					});
					int userID = tasks_UserInfo.UserID;
					string text3 = string.Concat(new object[]
					{
						tasks_UserInfo.RealName,
						"#",
						tasks_UserInfo.id,
						"#",
						tasks_UserInfo.DepName,
						","
					});
					string text4 = tasks_UserInfo.RealName + "(" + tasks_UserInfo.DepName + "),";
					Help.AdminSendMail(title, content, userID, text3, text4);
				}
			}
			foreach (string current in list4)
			{
				if (current.Contains("#"))
				{
					IList all = Tasks_User.Init().GetAll("UserID=" + current.Split(new char[]
					{
						'#'
					})[1], null);
					foreach (object current2 in all)
					{
						Tasks_UserInfo tasks_UserInfo = current2 as Tasks_UserInfo;
						try
						{
							Help.DeleteFiles(tasks_UserInfo.FilePath);
						}
						catch
						{
						}
						Tasks_User.Init().Delete(tasks_UserInfo.id);
					}
				}
			}
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
		private string ClearLeaf(string text)
		{
			string[] array = new string[]
			{
				"\u3000",
				"└",
				"├",
				"│",
				"└"
			};
			for (int i = 0; i < array.Length; i++)
			{
				if (text.Contains(array[i]))
				{
					text = text.Replace(array[i], "");
				}
			}
			return text.Trim();
		}
		private void GetFirtNode()
		{
			DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, "select * from Tasks_Type", null);
			dataSet.Relations.Add("sort", dataSet.Tables[0].Columns["id"], dataSet.Tables[0].Columns["ParentID"], false);
			foreach (DataRow dataRow in dataSet.Tables[0].Rows)
			{
				if (dataRow["ParentID"].ToString() == "0")
				{
					Tasks_TypeInfo tasks_TypeInfo = this.SetPram(dataRow);
					tasks_TypeInfo.Ch = "";
					tasks_TypeInfo.Sh = tasks_TypeInfo.TypeName;
					this.li.Add(tasks_TypeInfo);
					this.PopulateSubTree(dataRow, this.i);
				}
			}
		}
		private void PopulateSubTree(DataRow dbRow, int depth)
		{
			depth++;
			DataRow[] childRows = dbRow.GetChildRows("sort");
			for (int i = 0; i < childRows.Length - 1; i++)
			{
				int num = i;
				for (int j = i + 1; j < childRows.Length; j++)
				{
					if (Convert.ToInt32(childRows[num]["Orders"]) > Convert.ToInt32(childRows[j]["Orders"]))
					{
						num = j;
					}
				}
				if (num != i)
				{
					object obj = childRows[i];
					childRows[i] = childRows[num];
					childRows[num] = (DataRow)obj;
				}
			}
			DataRow[] array = childRows;
			for (int k = 0; k < array.Length; k++)
			{
				DataRow dataRow = array[k];
				Tasks_TypeInfo tasks_TypeInfo = this.SetPram(dataRow);
				if (depth == 2)
				{
					if (object.ReferenceEquals(dataRow, childRows[childRows.Length - 1]))
					{
						tasks_TypeInfo.Ch = "\u3000└ ";
					}
					else
					{
						tasks_TypeInfo.Ch = "\u3000├ ";
					}
				}
				else
				{
					if (depth > 2)
					{
						if (object.ReferenceEquals(dataRow, childRows[childRows.Length - 1]))
						{
							for (int l = 1; l < depth - 1; l++)
							{
								tasks_TypeInfo.Ch = "\u3000│" + tasks_TypeInfo.Ch;
							}
							Tasks_TypeInfo expr_132 = tasks_TypeInfo;
							expr_132.Ch += "\u3000└ ";
						}
						else
						{
							for (int l = 1; l < depth - 1; l++)
							{
								tasks_TypeInfo.Ch = "\u3000│" + tasks_TypeInfo.Ch;
							}
							Tasks_TypeInfo expr_177 = tasks_TypeInfo;
							expr_177.Ch += "\u3000├ ";
						}
					}
				}
				tasks_TypeInfo.Sh = tasks_TypeInfo.Ch + tasks_TypeInfo.TypeName;
				this.li.Add(tasks_TypeInfo);
				this.PopulateSubTree(dataRow, depth);
			}
		}
		private Tasks_TypeInfo SetPram(DataRow dbRow)
		{
			return new Tasks_TypeInfo
			{
				id = Convert.ToInt32(dbRow["id"]),
				TypeName = Convert.ToString(dbRow["TypeName"]),
				ParentID = Convert.ToInt32(dbRow["ParentID"]),
				Orders = Convert.ToInt32(dbRow["Orders"])
			};
		}
	}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       