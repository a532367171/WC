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
using WC.DK ;

public partial class Manage_flow_Flow_Manage : ViewPages
{

		private int i = 1;
		private IList<Flows_Model_TypeInfo> li = new List<Flows_Model_TypeInfo>();
		protected string LoadOriginalFile = "";
		protected string doctype = "doc";
		protected string url = "";
		protected string url1 = "";
        //protected HtmlHead Head1;
        //protected Literal kind_show;
        //protected HtmlForm myform;
        //protected HtmlGenericControl wdpy;
        //protected HtmlGenericControl yjpy;
        //protected HtmlGenericControl wdsq;
        //protected HtmlGenericControl view;
        //protected DropDownList Model_Type;
        //protected DropDownList ModelFlowList;
        //protected HtmlGenericControl nts;
        //protected HtmlInputText Flow_Name;
        //protected HtmlInputText ValidTime;
        //protected HtmlTextArea FlowRemark;
        //protected Repeater rpt_steps;
        //protected HtmlInputHidden userlist;
        //protected HtmlTextArea namelist;
        //protected Panel Attachword;
        //protected HtmlTableRow tr1;
        //protected HtmlInputHidden filepath;
        //protected HtmlTextArea DocBody;
        //protected HtmlGenericControl dvReadAttach;
        //protected Button save1;
		protected void Page_Load(object sender, EventArgs e)
		{
			this.url = "http://" + base.Request.ServerVariables["HTTP_HOST"].ToString() + base.Request.ServerVariables["PATH_INFO"].ToString();
			int length = this.url.LastIndexOf("/");
			this.url = this.url.Substring(0, length) + "/";
			this.url1 = this.url;
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
			sqlParameter2.ParameterName = "@pt1";
			sqlParameter2.Size = 4;
			SqlParameter sqlParameter3 = new SqlParameter();
			sqlParameter3.Direction = ParameterDirection.Output;
			sqlParameter3.ParameterName = "@pt2";
			sqlParameter3.Size = 4;
			SqlParameter sqlParameter4 = new SqlParameter();
			sqlParameter4.Direction = ParameterDirection.Output;
			sqlParameter4.ParameterName = "@pt3";
			sqlParameter4.Size = 4;
			SqlParameter sqlParameter5 = new SqlParameter();
			sqlParameter5.Direction = ParameterDirection.Output;
			sqlParameter5.ParameterName = "@pt4";
			sqlParameter5.Size = 4;
			SqlParameter[] cmdParms = new SqlParameter[]
			{
				sqlParameter2,
				sqlParameter3,
				sqlParameter4,
				sqlParameter5,
				sqlParameter
			};
			MsSqlOperate.ExecuteNonQuery(CommandType.StoredProcedure, "Flows_GetUserFlowBoxCount", cmdParms);
			this.wdpy.InnerText = string.Concat(sqlParameter2.Value);
			this.yjpy.InnerText = string.Concat(sqlParameter3.Value);
			this.wdsq.InnerText = string.Concat(sqlParameter4.Value);
			this.view.InnerText = string.Concat(sqlParameter5.Value);
			IList all = Flows_Model.Init().GetAll("IsComplete=1 and ( ShareDeps='' or ShareDeps like '%#" + this.DepID + "#%') ", null);
			this.ModelFlowList.Items.Add(new ListItem("== 请从以下列表 选择一个流程类型", ""));
			int i;
			for (i = 0; i < all.Count; i++)
			{
				Flows_ModelInfo flows_ModelInfo = all[i] as Flows_ModelInfo;
				this.ModelFlowList.Items.Add(new ListItem(flows_ModelInfo.Flow_Name, flows_ModelInfo.id + "," + flows_ModelInfo.ModelFileID));
			}
			this.GetFirtNode();
			this.Model_Type.Items.Add(new ListItem("== 请选择一个分类", "-1"));
			i = 0;
			int count = this.li.Count;
			while (i < count)
			{
				Flows_Model_TypeInfo flows_Model_TypeInfo = this.li[i];
				this.Model_Type.Items.Add(new ListItem(flows_Model_TypeInfo.Sh, string.Concat(flows_Model_TypeInfo.id)));
				i++;
			}
			this.Model_Type.Items.Add(new ListItem("不属于任何分类", "0"));
		}
		protected void ModelType_btn(object sender, EventArgs e)
		{
			int num = Convert.ToInt32(this.Model_Type.SelectedValue);
			if (num == -1)
			{
				this.ModelFlowList.Items.Clear();
				IList all = Flows_Model.Init().GetAll("IsComplete=1 and ( ShareDeps='' or ShareDeps like '%#" + this.DepID + "#%') ", null);
				this.ModelFlowList.Items.Add(new ListItem("== 请从以下列表 选择一个流程模型", ""));
				for (int i = 0; i < all.Count; i++)
				{
					Flows_ModelInfo flows_ModelInfo = all[i] as Flows_ModelInfo;
					this.ModelFlowList.Items.Add(new ListItem(flows_ModelInfo.Flow_Name, flows_ModelInfo.id + "," + flows_ModelInfo.ModelFileID));
				}
			}
			if (num == 0)
			{
				this.ModelFlowList.Items.Clear();
				IList all = Flows_Model.Init().GetAll("comid=0 and IsComplete=1 and ( ShareDeps='' or ShareDeps like '%#" + this.DepID + "#%') ", null);
				this.ModelFlowList.Items.Add(new ListItem("== 请从以下列表 选择一个流程模型", ""));
				for (int i = 0; i < all.Count; i++)
				{
					Flows_ModelInfo flows_ModelInfo = all[i] as Flows_ModelInfo;
					this.ModelFlowList.Items.Add(new ListItem(flows_ModelInfo.Flow_Name, flows_ModelInfo.id + "," + flows_ModelInfo.ModelFileID));
				}
			}
			if (num > 0)
			{
				this.ModelFlowList.Items.Clear();
				IList all = Flows_Model.Init().GetAll(string.Concat(new object[]
				{
					"comid=",
					num,
					" and IsComplete=1 and ( ShareDeps='' or ShareDeps like '%#",
					this.DepID,
					"#%') "
				}), null);
				this.ModelFlowList.Items.Add(new ListItem("== 请从以下列表 选择一个流程模型", ""));
				for (int i = 0; i < all.Count; i++)
				{
					Flows_ModelInfo flows_ModelInfo = all[i] as Flows_ModelInfo;
					this.ModelFlowList.Items.Add(new ListItem(flows_ModelInfo.Flow_Name, flows_ModelInfo.id + "," + flows_ModelInfo.ModelFileID));
				}
			}
			this.Attachword.Visible = false;
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (this.rpt_steps.Items.Count > 0)
			{
				bool flag = true;
				for (int i = 0; i < this.rpt_steps.Items.Count; i++)
				{
					Label label = this.rpt_steps.Items[i].FindControl("stepid") as Label;
					if (string.IsNullOrEmpty(base.Request.Form["namelist" + label.Text]))
					{
						flag = false;
					}
				}
				if (flag)
				{
					FlowsInfo flowsInfo = new FlowsInfo();
					if (Convert.ToInt32(this.Model_Type.SelectedValue) > 0)
					{
						flowsInfo.ComID = Convert.ToInt32(this.Model_Type.SelectedValue);
					}
					flowsInfo.ModelName = this.ModelFlowList.Items[this.ModelFlowList.SelectedIndex].Text;
					flowsInfo.Flow_Name = this.Flow_Name.Value;
					flowsInfo.CurrentDocPath = this.filepath.Value;
					flowsInfo.DocBody = this.DocBody.Value;
					flowsInfo.ValidTime = DateTime.Now;
					flowsInfo.AddTime = DateTime.Now;
					flowsInfo.ViewUserList = this.userlist.Value;
					if (Utils.IsDate(this.ValidTime.Value))
					{
						flowsInfo.ValidTime = Convert.ToDateTime(this.ValidTime.Value);
						flowsInfo.IsValid = 1;
					}
					flowsInfo.Remark = this.FlowRemark.Value;
					flowsInfo.CreatorID = Convert.ToInt32(this.Uid);
					flowsInfo.CreatorRealName = this.RealName;
					flowsInfo.CreatorDepName = this.DepName;
					flowsInfo.HasOperatedUserList = "";
					flowsInfo.Flow_Files = this.UpdateFiles();
					Flows.Init().Add(flowsInfo);
					for (int i = 0; i < this.rpt_steps.Items.Count; i++)
					{
						Label label = this.rpt_steps.Items[i].FindControl("stepid") as Label;
						Label label2 = this.rpt_steps.Items[i].FindControl("isuseredit") as Label;
						Label label3 = this.rpt_steps.Items[i].FindControl("IsHead") as Label;
						Label label4 = this.rpt_steps.Items[i].FindControl("IsEnd") as Label;
						Label label5 = this.rpt_steps.Items[i].FindControl("MailAlert") as Label;
						Label label6 = this.rpt_steps.Items[i].FindControl("RightToFinish") as Label;
						Label label7 = this.rpt_steps.Items[i].FindControl("Step_Orders") as Label;
						Label label8 = this.rpt_steps.Items[i].FindControl("Step_Name") as Label;
						Label label9 = this.rpt_steps.Items[i].FindControl("IsUserFile") as Label;
						string text = label.Text;
						Flows_StepInfo flows_StepInfo = new Flows_StepInfo();
						flows_StepInfo.Flow_ID = flowsInfo.id;
						flows_StepInfo.IsEnd = Convert.ToInt32(label4.Text);
						flows_StepInfo.IsHead = Convert.ToInt32(label3.Text);
						flows_StepInfo.IsUserEdit = Convert.ToInt32(label2.Text);
						flows_StepInfo.IsUserFile = Convert.ToInt32(label9.Text);
						flows_StepInfo.MailAlert = Convert.ToInt32(label5.Text);
						flows_StepInfo.RightToFinish = Convert.ToInt32(label6.Text);
						flows_StepInfo.Step_Name = label8.Text;
						flows_StepInfo.Step_Orders = Convert.ToInt32(label7.Text);
						flows_StepInfo.userlist = base.Request.Form["userlist" + text];
						flows_StepInfo.namelist = base.Request.Form["namelist" + text];
						flows_StepInfo.Acts = Guid.NewGuid().ToString();
						Flows_Step.Init().Add(flows_StepInfo);
						if (i == 0)
						{
							Flows_StepInfo flows_StepInfo2 = this.MakeNewFsi(flows_StepInfo);
							flowsInfo.CurrentStepID = flows_StepInfo2.id;
							flowsInfo.CurrentStepName = flows_StepInfo2.Step_Name;
							flowsInfo.CurrentStepUserList = flows_StepInfo2.userlist;
							Help.FlowMobleSend(flows_StepInfo2.userlist, flowsInfo.Flow_Name);
						}
					}
					Flows.Init().Update(flowsInfo);
					Flows_DocInfo flows_DocInfo = new Flows_DocInfo();
					flows_DocInfo.AddTime = DateTime.Now;
					flows_DocInfo.DocPath = flowsInfo.Flow_Files;
					flows_DocInfo.DocBody = flowsInfo.DocBody;
					flows_DocInfo.Flow_ID = flowsInfo.id;
					flows_DocInfo.UserDepName = this.DepName;
					flows_DocInfo.UserID = Convert.ToInt32(this.Uid);
					flows_DocInfo.UserRealName = this.RealName;
					Flows_Doc.Init().Add(flows_DocInfo);
					string str = HttpContext.Current.Server.HtmlEncode("您好!新建工作流程成功!");
					base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
				}
				else
				{
					base.Response.Write("<script>alert('审批人员 不能为空!')</script>");
				}
			}
			else
			{
				base.Response.Write("<script>alert('工作流程没有审批步骤!');window.location='Flow_Manage.aspx'</script>");
			}
		}
		protected void Select_btn(object sender, EventArgs e)
		{
			DropDownList dropDownList = sender as DropDownList;
			this.kind_show.Visible = true;
			if (dropDownList.SelectedValue.Contains(","))
			{
				this.Attachword.Visible = true;
				string text = dropDownList.SelectedValue.Split(new char[]
				{
					','
				})[0];
				string text2 = dropDownList.SelectedValue.Split(new char[]
				{
					','
				})[1];
				if (text2 != "0")
				{
					Flows_ModelFileInfo byId = Flows_ModelFile.Init().GetById(Convert.ToInt32(text2));
					this.DocBody.Value = byId.DocBody;
					if (byId.FilePath.Contains("|"))
					{
						List<TmpInfo> list = new List<TmpInfo>();
						string formTitle = byId.FormTitle;
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
								string text3 = array[i].Substring(num, array[i].Length - num);
								string text4 = array[i].Replace("~", "");
								tmpInfo.Tmp1 = formTitle;
								tmpInfo.Tmp2 = text3;
								tmpInfo.Tmp3 = text4;
								list.Add(tmpInfo);
								if (this.LoadOriginalFile == "" && text3.Contains("."))
								{
									string[] array2 = text3.Split(new char[]
									{
										'.'
									});
									if (array2[array2.Length - 1].ToLower().Contains("doc"))
									{
										this.url = this.url.ToLower().Replace("/manage/flow", "");
										this.LoadOriginalFile = this.url + text4;
									}
								}
							}
						}
					}
				}
				IList all = Flows_ModelStep.Init().GetAll("Flow_ModelID=" + text, "order by id asc");
				Flows_ModelInfo byId2 = Flows_Model.Init().GetById(Convert.ToInt32(text));
				if (!string.IsNullOrEmpty(byId2.Remark))
				{
					this.nts.Visible = true;
					this.nts.Attributes.Add("title", byId2.Remark);
				}
				this.rpt_steps.DataSource = all;
				this.rpt_steps.DataBind();
			}
		}
		protected string GetStepNames(object userlist, object namelist, object userlist_dep, object step_type)
		{
			string text = "";
			if (step_type.ToString() == "0")
			{
				text = string.Concat(namelist);
			}
			if (step_type.ToString() == "1")
			{
				string text2 = string.Concat(userlist_dep);
				if (text2.Contains(","))
				{
					string[] array = text2.Split(new char[]
					{
						','
					});
					List<Sys_UserInfo> list = new List<Sys_UserInfo>();
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i].Trim() != "")
						{
							string str = array[i].Split(new char[]
							{
								'#'
							})[1];
							IList all = Sys_User.Init().GetAll("depid=" + str, null);
							foreach (object current in all)
							{
								Sys_UserInfo item = current as Sys_UserInfo;
								if (!list.Contains(item))
								{
									list.Add(item);
								}
							}
						}
					}
					for (int i = 0; i < list.Count; i++)
					{
						string text3 = text;
						text = string.Concat(new string[]
						{
							text3,
							list[i].RealName,
							"(",
							list[i].DepName,
							"),"
						});
					}
				}
			}
			return text;
		}
		protected string GetStepUsers(object userlist, object namelist, object userlist_dep, object step_type)
		{
			string text = "";
			if (step_type.ToString() == "0")
			{
				text = string.Concat(userlist);
			}
			if (step_type.ToString() == "1")
			{
				string text2 = string.Concat(userlist_dep);
				if (text2.Contains(","))
				{
					string[] array = text2.Split(new char[]
					{
						','
					});
					List<Sys_UserInfo> list = new List<Sys_UserInfo>();
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i].Trim() != "")
						{
							string str = array[i].Split(new char[]
							{
								'#'
							})[1];
							IList all = Sys_User.Init().GetAll("depid=" + str, null);
							foreach (object current in all)
							{
								Sys_UserInfo item = current as Sys_UserInfo;
								if (!list.Contains(item))
								{
									list.Add(item);
								}
							}
						}
					}
					for (int i = 0; i < list.Count; i++)
					{
						object obj = text;
						text = string.Concat(new object[]
						{
							obj,
							list[i].RealName,
							"#",
							list[i].id,
							"#",
							list[i].DepName,
							","
						});
					}
				}
			}
			return text;
		}
		protected void OnDataBind(object sender, RepeaterItemEventArgs e)
		{
			Label label = e.Item.FindControl("isuseredit") as Label;
			HtmlControl htmlControl = e.Item.FindControl("isedit") as HtmlControl;
			if (label.Text == "1")
			{
				htmlControl.Visible = true;
			}
		}
		private Flows_StepInfo MakeNewFsi(Flows_StepInfo fsi)
		{
			Flows_StepInfo flows_StepInfo = new Flows_StepInfo();
			flows_StepInfo.Flow_ID = fsi.Flow_ID;
			flows_StepInfo.IsAct = 1;
			flows_StepInfo.IsEnd = fsi.IsEnd;
			flows_StepInfo.IsHead = fsi.IsHead;
			flows_StepInfo.IsUserEdit = fsi.IsUserEdit;
			flows_StepInfo.IsUserFile = fsi.IsUserFile;
			flows_StepInfo.MailAlert = fsi.MailAlert;
			flows_StepInfo.namelist = fsi.namelist;
			flows_StepInfo.RightToFinish = fsi.RightToFinish;
			flows_StepInfo.Step_Name = fsi.Step_Name;
			flows_StepInfo.Step_Orders = 1;
			flows_StepInfo.Step_Remark = fsi.Step_Remark;
			flows_StepInfo.userlist = fsi.userlist;
			flows_StepInfo.Acts = fsi.Acts;
			Flows_Step.Init().Add(flows_StepInfo);
			return flows_StepInfo;
		}
		private string UpdateFiles()
		{
			string text = "";
			HttpFileCollection files = HttpContext.Current.Request.Files;
			string text2 = DateTime.Now.ToString("yyMMdd");
			string text3 = base.Server.MapPath("~/Files/FlowFiles/");
			string str = "~/Files/FlowFiles/" + text2 + "/";
			text3 += text2;
			if (!Directory.Exists(text3))
			{
				FileSystemManager.CreateFolder(text2, base.Server.MapPath("~/Files/FlowFiles"));
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
				throw;
			}
			return text;
		}
		protected string GetStepNotes(object t)
		{
			string result;
			if (!string.IsNullOrEmpty(string.Concat(t)))
			{
				result = "(<a href=# title='" + t + "' >说明</a>)";
			}
			else
			{
				result = "";
			}
			return result;
		}
		private void GetFirtNode()
		{
			DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, "select * from Flows_Model_Type", null);
			dataSet.Relations.Add("sort", dataSet.Tables[0].Columns["id"], dataSet.Tables[0].Columns["ParentID"], false);
			foreach (DataRow dataRow in dataSet.Tables[0].Rows)
			{
				if (dataRow["ParentID"].ToString() == "0")
				{
					Flows_Model_TypeInfo flows_Model_TypeInfo = this.SetPram(dataRow);
					flows_Model_TypeInfo.Ch = "";
					flows_Model_TypeInfo.Sh = flows_Model_TypeInfo.TypeName;
					this.li.Add(flows_Model_TypeInfo);
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
				Flows_Model_TypeInfo flows_Model_TypeInfo = this.SetPram(dataRow);
				if (depth == 2)
				{
					if (object.ReferenceEquals(dataRow, childRows[childRows.Length - 1]))
					{
						flows_Model_TypeInfo.Ch = "\u3000└ ";
					}
					else
					{
						flows_Model_TypeInfo.Ch = "\u3000├ ";
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
								flows_Model_TypeInfo.Ch = "\u3000│" + flows_Model_TypeInfo.Ch;
							}
							Flows_Model_TypeInfo expr_132 = flows_Model_TypeInfo;
							expr_132.Ch += "\u3000└ ";
						}
						else
						{
							for (int l = 1; l < depth - 1; l++)
							{
								flows_Model_TypeInfo.Ch = "\u3000│" + flows_Model_TypeInfo.Ch;
							}
							Flows_Model_TypeInfo expr_177 = flows_Model_TypeInfo;
							expr_177.Ch += "\u3000├ ";
						}
					}
				}
				flows_Model_TypeInfo.Sh = flows_Model_TypeInfo.Ch + flows_Model_TypeInfo.TypeName;
				this.li.Add(flows_Model_TypeInfo);
				this.PopulateSubTree(dataRow, depth);
			}
		}
		private Flows_Model_TypeInfo SetPram(DataRow dbRow)
		{
			return new Flows_Model_TypeInfo
			{
				id = Convert.ToInt32(dbRow["id"]),
				TypeName = Convert.ToString(dbRow["TypeName"]),
				ParentID = Convert.ToInt32(dbRow["ParentID"]),
				Orders = Convert.ToInt32(dbRow["Orders"])
			};
		}
	}

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                