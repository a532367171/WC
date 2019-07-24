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

public partial class Manage_flow_Flow_View : ViewPages

	{
		protected string fj = "<a href='/Manage/Utils/Download.aspx?destFileName={0}' ><img src='/img/mail_attachment.gif' />{1}</a>&nbsp;&nbsp;";
		protected string yjs = "";
		protected string LoadOriginalFile = "";
		protected string doctype = "doc";
		protected string url = "";
		protected string url1 = "";
		protected string ke_isread = "";
        //protected HtmlHead Head1;
        //protected HtmlForm myform;
        //protected HtmlGenericControl wdpy;
        //protected HtmlGenericControl yjpy;
        //protected HtmlGenericControl wdsq;
        //protected HtmlGenericControl view;
        //protected HtmlGenericControl Flow_Name1;
        //protected HtmlGenericControl status;
        //protected HtmlGenericControl creator;
        //protected HtmlGenericControl tuli;
        //protected HtmlGenericControl flowNo;
        //protected HtmlGenericControl ModelType;
        //protected HtmlGenericControl addtime;
        //protected HtmlGenericControl vlidtime;
        //protected HtmlGenericControl viewuserlist;
        //protected HtmlGenericControl currentstepname;
        //protected HtmlGenericControl currentuserlist;
        //protected HtmlTableRow tr1;
        //protected HtmlInputHidden filepath;
        //protected HtmlTextArea DocBody;
        //protected HtmlGenericControl bodys;
        //protected Repeater rpt;
        //protected Panel display;
        //protected HtmlTableRow seal;
        //protected DropDownList seallist;
        //protected HtmlGenericControl dvReadAttach;
        //protected Button b1;
        //protected Button b2;
        //protected Button b3;
		protected void Page_Load(object sender, EventArgs e)
		{
			this.url = "http://" + base.Request.ServerVariables["HTTP_HOST"].ToString() + base.Request.ServerVariables["PATH_INFO"].ToString();
			int length = this.url.LastIndexOf("/");
			this.url = this.url.Substring(0, length) + "/";
			this.url1 = this.url;
			if (!base.IsPostBack)
			{
				if (!string.IsNullOrEmpty(base.Request.QueryString["fl"]))
				{
					this.Show(base.Request.QueryString["fl"]);
				}
				else
				{
					base.Response.Write("<script>alert('非法的请求!');window.location='Flow_Manage.aspx'</script>");
				}
			}
		}
		protected void VerifyStep_Btn(object sender, EventArgs e)
		{
			FlowsInfo byId = Flows.Init().GetById(Convert.ToInt32(base.Request.QueryString["fl"]));
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
				Flows_StepInfo flows_StepInfo = this.ViewState["CurrentStep"] as Flows_StepInfo;
				Flows_StepActionInfo flows_StepActionInfo = new Flows_StepActionInfo();
				flows_StepActionInfo.AddTime = DateTime.Now;
				flows_StepActionInfo.FlowID = Convert.ToInt32(base.Request.QueryString["fl"]);
				flows_StepActionInfo.Operation = 1;
				flows_StepActionInfo.OperationStepID = flows_StepInfo.id;
				flows_StepActionInfo.OperationWord = "(同意) ：" + base.Request.Form["FlowRemark"];
				flows_StepActionInfo.UserDepName = this.DepName;
				flows_StepActionInfo.UserID = Convert.ToInt32(this.Uid);
				flows_StepActionInfo.UserRealName = this.RealName;
				flows_StepActionInfo.OperationStepName = flows_StepInfo.Step_Name;
				if (flows_StepInfo.IsEnd == 1)
				{
					Flows_StepAction.Init().Add(flows_StepActionInfo);
					FlowsInfo flowsInfo = byId;
					this.AddDoc(flowsInfo.id, flows_StepActionInfo.id);
					flowsInfo.CurrentDocPath = this.filepath.Value;
					flowsInfo.DocBody = this.DocBody.Value;
					if (!this.IsAllVerifid())
					{
						FlowsInfo expr_22B = flowsInfo;
						string hasOperatedUserList = expr_22B.HasOperatedUserList;
						expr_22B.HasOperatedUserList = string.Concat(new string[]
						{
							hasOperatedUserList,
							this.RealName,
							"#",
							this.Uid,
							"#",
							this.DepName,
							","
						});
						Flows.Init().Update(flowsInfo);
						string str = HttpContext.Current.Server.HtmlEncode("您好!已成功审批!");
						base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
					}
					else
					{
						FlowsInfo expr_2DB = flowsInfo;
						string hasOperatedUserList = expr_2DB.HasOperatedUserList;
						expr_2DB.HasOperatedUserList = string.Concat(new string[]
						{
							hasOperatedUserList,
							this.RealName,
							"#",
							this.Uid,
							"#",
							this.DepName,
							","
						});
						Flows.Init().Update(flowsInfo);
						this.FinishFlow();
						string str = HttpContext.Current.Server.HtmlEncode("您好!成功审批,流程已完成!");
						base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
					}
				}
				else
				{
					IList all = Flows_Step.Init().GetAll("isact=0 and flow_id=" + base.Request.QueryString["fl"], "order by id asc");
					if (all != null)
					{
						int num = 0;
						foreach (object current in all)
						{
							Flows_StepInfo flows_StepInfo2 = current as Flows_StepInfo;
							if (flows_StepInfo2.Acts == flows_StepInfo.Acts)
							{
								num = all.IndexOf(current) + 1;
							}
						}
						if (num != 0)
						{
							Flows_StepAction.Init().Add(flows_StepActionInfo);
							FlowsInfo flowsInfo = byId;
							this.AddDoc(flowsInfo.id, flows_StepActionInfo.id);
							flowsInfo.CurrentDocPath = this.filepath.Value;
							flowsInfo.DocBody = this.DocBody.Value;
							if (this.IsAllVerifid())
							{
								Flows_StepInfo flows_StepInfo3 = this.MakeNewFsi((Flows_StepInfo)all[num]);
								flowsInfo.CurrentStepID = flows_StepInfo3.id;
								flowsInfo.CurrentStepName = flows_StepInfo3.Step_Name;
								flowsInfo.CurrentStepUserList = flows_StepInfo3.userlist;
								Help.FlowMobleSend(flows_StepInfo3.userlist, flowsInfo.Flow_Name);
							}
							FlowsInfo expr_4E3 = flowsInfo;
							string hasOperatedUserList = expr_4E3.HasOperatedUserList;
							expr_4E3.HasOperatedUserList = string.Concat(new string[]
							{
								hasOperatedUserList,
								this.RealName,
								"#",
								this.Uid,
								"#",
								this.DepName,
								","
							});
							Flows.Init().Update(flowsInfo);
							string str = HttpContext.Current.Server.HtmlEncode("您好!已成功审批!");
							base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
						}
					}
				}
			}
		}
		protected void RefuseStep_Btn(object sender, EventArgs e)
		{
			FlowsInfo byId = Flows.Init().GetById(Convert.ToInt32(base.Request.QueryString["fl"]));
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
				Flows_StepInfo flows_StepInfo = this.ViewState["CurrentStep"] as Flows_StepInfo;
				Flows_StepActionInfo flows_StepActionInfo = new Flows_StepActionInfo();
				flows_StepActionInfo.AddTime = DateTime.Now;
				flows_StepActionInfo.FlowID = Convert.ToInt32(base.Request.QueryString["fl"]);
				flows_StepActionInfo.Operation = -1;
				flows_StepActionInfo.OperationStepID = flows_StepInfo.id;
				flows_StepActionInfo.OperationWord = "(不同意) ：" + base.Request.Form["FlowRemark"];
				flows_StepActionInfo.UserDepName = this.DepName;
				flows_StepActionInfo.UserID = Convert.ToInt32(this.Uid);
				flows_StepActionInfo.UserRealName = this.RealName;
				flows_StepActionInfo.OperationStepName = flows_StepInfo.Step_Name;
				if (flows_StepInfo.IsHead == 1)
				{
					Flows_StepAction.Init().Add(flows_StepActionInfo);
					this.AddDoc(flows_StepActionInfo.FlowID, flows_StepActionInfo.id);
					byId.CurrentDocPath = this.filepath.Value;
					byId.DocBody = this.DocBody.Value;
					Flows.Init().Update(byId);
					this.BackFlow();
					string str = HttpContext.Current.Server.HtmlEncode("您好!操作成功,流程已退回!");
					base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
				}
				else
				{
					IList all = Flows_Step.Init().GetAll("isact=0 and flow_id=" + base.Request.QueryString["fl"], "order by id asc");
					if (all != null)
					{
						int num = -1;
						foreach (object current in all)
						{
							Flows_StepInfo flows_StepInfo2 = current as Flows_StepInfo;
							if (flows_StepInfo2.Acts == flows_StepInfo.Acts)
							{
								num = all.IndexOf(current) - 1;
							}
						}
						if (num >= 0)
						{
							Flows_StepInfo flows_StepInfo3 = this.MakeNewFsi((Flows_StepInfo)all[num]);
							Flows_StepAction.Init().Add(flows_StepActionInfo);
							FlowsInfo flowsInfo = byId;
							this.AddDoc(flows_StepActionInfo.FlowID, flows_StepActionInfo.id);
							flowsInfo.CurrentDocPath = this.filepath.Value;
							flowsInfo.DocBody = this.DocBody.Value;
							flowsInfo.CurrentStepID = flows_StepInfo3.id;
							flowsInfo.CurrentStepName = flows_StepInfo3.Step_Name;
							flowsInfo.CurrentStepUserList = flows_StepInfo3.userlist;
							FlowsInfo expr_3A7 = flowsInfo;
							string hasOperatedUserList = expr_3A7.HasOperatedUserList;
							expr_3A7.HasOperatedUserList = string.Concat(new string[]
							{
								hasOperatedUserList,
								this.RealName,
								"#",
								this.Uid,
								"#",
								this.DepName,
								","
							});
							Flows.Init().Update(flowsInfo);
							Help.FlowMobleSend(flows_StepInfo3.userlist, flowsInfo.Flow_Name);
							string str = HttpContext.Current.Server.HtmlEncode("您好!操作成功,流程已返回!");
							base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
						}
					}
				}
			}
		}
		protected void CompleteStep_Btn(object sender, EventArgs e)
		{
			FlowsInfo byId = Flows.Init().GetById(Convert.ToInt32(base.Request.QueryString["fl"]));
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
				Flows_StepInfo flows_StepInfo = this.ViewState["CurrentStep"] as Flows_StepInfo;
				Flows_StepActionInfo flows_StepActionInfo = new Flows_StepActionInfo();
				flows_StepActionInfo.AddTime = DateTime.Now;
				flows_StepActionInfo.FlowID = Convert.ToInt32(base.Request.QueryString["fl"]);
				flows_StepActionInfo.Operation = 1;
				flows_StepActionInfo.OperationStepID = flows_StepInfo.id;
				flows_StepActionInfo.OperationWord = "(同意 并完成结束整个流程) ：" + base.Request.Form["FlowRemark"];
				flows_StepActionInfo.UserDepName = this.DepName;
				flows_StepActionInfo.UserID = Convert.ToInt32(this.Uid);
				flows_StepActionInfo.UserRealName = this.RealName;
				flows_StepActionInfo.OperationStepName = flows_StepInfo.Step_Name;
				Flows_StepAction.Init().Add(flows_StepActionInfo);
				this.AddDoc(flows_StepActionInfo.FlowID, flows_StepActionInfo.id);
				byId.CurrentDocPath = this.filepath.Value;
				byId.DocBody = this.DocBody.Value;
				Flows.Init().Update(byId);
				this.FinishFlow();
				string str = HttpContext.Current.Server.HtmlEncode("您好!工作流程已审批完成!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
		}
		private void FinishFlow()
		{
			FlowsInfo flowsInfo = this.ViewState["Flow"] as FlowsInfo;
			string str = string.Concat(new string[]
			{
				flowsInfo.HasOperatedUserList,
				this.RealName,
				"#",
				this.Uid,
				"#",
				this.DepName,
				","
			});
			string cmdText = "update Flows set Status=1,HasOperatedUserList='" + str + "' where status=0 and id=" + base.Request.QueryString["fl"];
			MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
			string title = "[系统通知] : 您申请的工作流程(" + flowsInfo.Flow_Name + ") 已成功审批完成!";
			string content = "恭喜您! 审批流程成功完成!";
			int creatorID = flowsInfo.CreatorID;
			string userlist = string.Concat(new object[]
			{
				flowsInfo.CreatorRealName,
				"#",
				flowsInfo.CreatorID,
				"#",
				flowsInfo.CreatorDepName,
				","
			});
			string namelist = flowsInfo.CreatorRealName + "(" + flowsInfo.CreatorDepName + "),";
			Help.AdminSendMail(title, content, creatorID, userlist, namelist);
		}
		private void BackFlow()
		{
			FlowsInfo flowsInfo = this.ViewState["Flow"] as FlowsInfo;
			string str = string.Concat(new string[]
			{
				flowsInfo.HasOperatedUserList,
				this.RealName,
				"#",
				this.Uid,
				"#",
				this.DepName,
				","
			});
			string cmdText = "update Flows set Status=-2,HasOperatedUserList='" + str + "' where status=0 and id=" + base.Request.QueryString["fl"];
			MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
			string title = "[系统通知] : 您申请的工作流程(" + flowsInfo.Flow_Name + ") 已被退回!";
			string content = "您的审批流程 没有被通过!";
			int creatorID = flowsInfo.CreatorID;
			string userlist = string.Concat(new object[]
			{
				flowsInfo.CreatorRealName,
				"#",
				flowsInfo.CreatorID,
				"#",
				flowsInfo.CreatorDepName,
				","
			});
			string namelist = flowsInfo.CreatorRealName + "(" + flowsInfo.CreatorDepName + "),";
			Help.AdminSendMail(title, content, creatorID, userlist, namelist);
		}
		private bool IsAllVerifid()
		{
			bool flag = true;
			FlowsInfo flowsInfo = this.ViewState["Flow"] as FlowsInfo;
			IList all = Flows_StepAction.Init().GetAll(string.Concat(new object[]
			{
				"OperationStepID=",
				flowsInfo.CurrentStepID,
				" and FlowID=",
				flowsInfo.id
			}), null);
			string[] array = flowsInfo.CurrentStepUserList.Split(new char[]
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
				Flows_StepActionInfo flows_StepActionInfo = current as Flows_StepActionInfo;
				list2.Add(flows_StepActionInfo.UserID.ToString());
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
			FlowsInfo byId = Flows.Init().GetById(Convert.ToInt32(fid));
			if (byId.CurrentStepUserList.Contains("#" + this.Uid + "#") || byId.HasOperatedUserList.Contains("#" + this.Uid + "#") || byId.ViewUserList.Contains("#" + this.Uid + "#") || byId.CreatorID == Convert.ToInt32(this.Uid) || this.Modules.Contains("28"))
			{
				this.ViewState["Flow"] = byId;
				this.filepath.Value = byId.CurrentDocPath;
				this.DocBody.Value = byId.DocBody;
				this.Flow_Name1.InnerText = byId.Flow_Name;
				this.ModelType.InnerText = this.GetModelType(byId.ComID);
				this.ke_isread = ", afterCreate : function(id) { KE.toolbar.disable(id, []); KE.readonly(id); KE.g[id].newTextarea.disabled = true; } ";
				this.url = this.url.ToLower().Replace("/manage/flow", "");
				this.LoadOriginalFile = this.url + byId.CurrentDocPath.Replace("~", "");
				this.tuli.InnerHtml = " <a href='Flow_Graph.aspx?fl=" + byId.id + "' target=_blank>[点击查看]</a>";
				this.flowNo.InnerText = byId.AddTime.Year + "-" + (100000 + byId.id);
				this.status.InnerText = this.GetStatus(byId.Status);
				this.creator.InnerText = byId.CreatorRealName + "(" + byId.CreatorDepName + ")";
				this.addtime.InnerText = Utils.ConvertDate2(byId.AddTime);
				this.vlidtime.InnerText = "永不过期";
				if (byId.IsValid == 1)
				{
					this.vlidtime.InnerText = byId.ValidTime.ToString("yyyy-MM-dd") + " 之前";
				}
				this.currentstepname.InnerText = byId.CurrentStepName;
				if (!string.IsNullOrEmpty(byId.Remark))
				{
					this.bodys.InnerHtml = byId.Remark.Replace("\n", "<br>");
				}
				IList all = Flows_Doc.Init().GetAll("flow_id=" + byId.id, "order by id asc");
				List<TmpInfo> list = new List<TmpInfo>();
				List<TmpInfo> list2 = new List<TmpInfo>();
				List<TmpInfo> list3 = new List<TmpInfo>();
				Flows_DocInfo flows_DocInfo = null;
				int j;
				for (int i = 0; i < all.Count; i++)
				{
					Flows_DocInfo flows_DocInfo2 = all[i] as Flows_DocInfo;
					if (i == all.Count - 1)
					{
						flows_DocInfo = flows_DocInfo2;
					}
					if (flows_DocInfo2.DocPath.Contains("|"))
					{
						string[] array = flows_DocInfo2.DocPath.Split(new char[]
						{
							'|'
						});
						for (j = 0; j < array.Length; j++)
						{
							if (array[j].Trim() != "")
							{
								TmpInfo tmpInfo = new TmpInfo();
								int num = array[j].LastIndexOf('/') + 1;
								string tmp = array[j].Substring(num, array[j].Length - num);
								string s = array[j].Replace("~", "");
								tmpInfo.Tmp1 = array[j];
								tmpInfo.Tmp2 = tmp;
								tmpInfo.Tmp3 = base.Server.UrlEncode(s);
								tmpInfo.Tmp4 = string.Concat(new string[]
								{
									" &nbsp;&nbsp; <span style='color:#999'> &nbsp; - (",
									flows_DocInfo2.UserRealName,
									"&nbsp;",
									Utils.ConvertDate1(flows_DocInfo2.AddTime),
									")</span>"
								});
								list.Add(tmpInfo);
							}
						}
					}
				}
				if (flows_DocInfo != null && flows_DocInfo.DocPath.Contains("|"))
				{
					string[] array = flows_DocInfo.DocPath.Split(new char[]
					{
						'|'
					});
					for (j = 0; j < array.Length; j++)
					{
						if (array[j].Trim() != "")
						{
							TmpInfo tmpInfo = new TmpInfo();
							int num = array[j].LastIndexOf('/') + 1;
							string tmp = array[j].Substring(num, array[j].Length - num);
							string s = array[j].Replace("~", "");
							tmpInfo.Tmp1 = array[j];
							tmpInfo.Tmp2 = tmp;
							tmpInfo.Tmp3 = base.Server.UrlEncode(s);
							tmpInfo.Tmp4 = string.Concat(new string[]
							{
								" &nbsp;&nbsp; <span style='color:#999'> &nbsp; - (",
								flows_DocInfo.UserRealName,
								"&nbsp;",
								Utils.ConvertDate1(flows_DocInfo.AddTime),
								")</span>"
							});
							list2.Add(tmpInfo);
						}
					}
				}
				j = 0;
				IL_74B:
				while (j < list2.Count)
				{
					TmpInfo tmpInfo2 = list2[j];
					for (int i = 0; i < list.Count; i++)
					{
						TmpInfo tmpInfo3 = list[i];
						if (tmpInfo2.Tmp1 == tmpInfo3.Tmp1)
						{
							tmpInfo2.Tmp4 = tmpInfo3.Tmp4;
                            //IL_73C:
							list3.Add(tmpInfo2);
							j++;
							goto IL_74B;
						}
					}
                    //goto IL_73C;
				}
				if (list3.Count > 0)
				{
					this.rpt.DataSource = list3;
					this.rpt.DataBind();
				}
				Flows_StepInfo byId2 = Flows_Step.Init().GetById(byId.CurrentStepID);
				this.ViewState["CurrentStep"] = byId2;
				string text = "";
				IList all2 = Flows_StepAction.Init().GetAll(string.Concat(new object[]
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
				List<string> list4 = new List<string>();
				for (j = 0; j < array2.Length; j++)
				{
					if (array2[j].Contains("#"))
					{
						list4.Add(array2[j].Split(new char[]
						{
							'#'
						})[0].Trim());
					}
				}
				foreach (object current in all2)
				{
					Flows_StepActionInfo flows_StepActionInfo = current as Flows_StepActionInfo;
					if (flows_StepActionInfo.Operation == 1)
					{
						text = text + flows_StepActionInfo.UserRealName + "[已签/同意], ";
						if (list4.Contains(flows_StepActionInfo.UserRealName.Trim()))
						{
							list4.Remove(flows_StepActionInfo.UserRealName.Trim());
						}
					}
					if (flows_StepActionInfo.Operation == -1)
					{
						text = text + flows_StepActionInfo.UserRealName + "[已签/不同意], ";
						if (list4.Contains(flows_StepActionInfo.UserRealName.Trim()))
						{
							list4.Remove(flows_StepActionInfo.UserRealName.Trim());
						}
					}
				}
				foreach (string current2 in list4)
				{
					text = text + current2 + "[未审批], ";
				}
				this.currentuserlist.InnerHtml = text;
				IList all3 = Flows_StepAction.Init().GetAll("FlowID=" + byId.id, "order by id asc");
				IList all4 = Flows_Doc.Init().GetAll("StepAction_ID=0 and flow_id=" + byId.id, null);
				Flows_DocInfo flows_DocInfo3 = all4[0] as Flows_DocInfo;
				base.Server.UrlEncode(flows_DocInfo3.DocPath.Replace("~", ""));
				object obj = this.yjs;
				this.yjs = string.Concat(new object[]
				{
					obj,
					"0、<u>流程申请</u> &nbsp;&nbsp; ",
					byId.CreatorRealName,
					" 在 ",
					Utils.ConvertDate2(byId.AddTime),
					" 发起流程(申请人) &nbsp;&nbsp; <a href='../../Manage/Flow/DocBodyView.aspx?gid=",
					flows_DocInfo3.id,
					"' target='_blank' ><strong>查看申请人原件</strong></a> <br>"
				});
				foreach (object current in all3)
				{
					Flows_StepActionInfo flows_StepActionInfo = current as Flows_StepActionInfo;
					IList all5 = Flows_Doc.Init().GetAll("StepAction_ID=" + flows_StepActionInfo.id, null);
					if (all5.Count == 0)
					{
						obj = this.yjs;
						this.yjs = string.Concat(new object[]
						{
							obj,
							all3.IndexOf(current) + 1,
							"、<u>",
							flows_StepActionInfo.OperationStepName,
							"</u> &nbsp;&nbsp; ",
							flows_StepActionInfo.UserRealName,
							" 在 ",
							Utils.ConvertDate2(flows_StepActionInfo.AddTime),
							" 已审  &nbsp;&nbsp;<strong style='color:#ff0000'>",
							flows_StepActionInfo.OperationWord,
							"</strong><br>"
						});
					}
					else
					{
						Flows_DocInfo flows_DocInfo4 = all5[0] as Flows_DocInfo;
						base.Server.UrlEncode(flows_DocInfo4.DocPath.Replace("~", ""));
						obj = this.yjs;
						this.yjs = string.Concat(new object[]
						{
							obj,
							all3.IndexOf(current) + 1,
							"、<u>",
							flows_StepActionInfo.OperationStepName,
							"</u> &nbsp;&nbsp; ",
							flows_StepActionInfo.UserRealName,
							" 在 ",
							Utils.ConvertDate2(flows_StepActionInfo.AddTime),
							" 已审 ",
							flows_StepActionInfo.OperationWord,
							" &nbsp;&nbsp; <a href='../../Manage/Flow/DocBodyView.aspx?gid=",
							flows_DocInfo4.id,
							"' target='_blank' ><strong>查看文件变动</strong></a> <br>"
						});
					}
				}
				if (byId.ViewUserList.Contains(","))
				{
					string[] array3 = byId.ViewUserList.Split(new char[]
					{
						','
					});
					for (j = 0; j < array3.Length; j++)
					{
						if (array3[j].Contains("#"))
						{
							HtmlGenericControl expr_CF1 = this.viewuserlist;
							expr_CF1.InnerText = expr_CF1.InnerText + array3[j].Split(new char[]
							{
								'#'
							})[0] + ",";
						}
					}
				}
				if (list4.Contains(this.RealName.Trim()) && byId.Status == 0)
				{
					this.ke_isread = "";
					this.display.Visible = true;
					this.b1.Enabled = true;
					this.b2.Enabled = true;
					IList all6 = Sys_Seal.Init().GetAll("uid=" + this.Uid + " and status=1", null);
					if (all6.Count > 0)
					{
						this.seal.Visible = true;
						this.seallist.DataSource = all6;
						this.seallist.DataTextField = "SealName";
						this.seallist.DataValueField = "id";
						this.seallist.DataBind();
					}
					if (byId2.RightToFinish == 1)
					{
						this.b3.Enabled = true;
					}
					if (byId2.IsUserFile == 1)
					{
						for (j = 0; j < this.rpt.Items.Count; j++)
						{
							HtmlInputCheckBox htmlInputCheckBox = this.rpt.Items[j].FindControl("chk") as HtmlInputCheckBox;
							htmlInputCheckBox.Disabled = false;
						}
					}
				}
			}
			else
			{
				base.Response.Write("<script>alert('您没有查看权限');window.location='Flow_List.aspx?action=verify';</script>");
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
			flows_StepInfo.Step_Orders = fsi.Step_Orders;
			flows_StepInfo.Step_Remark = fsi.Step_Remark;
			flows_StepInfo.userlist = fsi.userlist;
			flows_StepInfo.Acts = fsi.Acts;
			Flows_Step.Init().Add(flows_StepInfo);
			return flows_StepInfo;
		}
		private string GetStatus(int t)
		{
			string result;
			if (t == 0)
			{
				result = "流程审批中";
			}
			else
			{
				if (t == 1)
				{
					result = "流程已完成";
				}
				else
				{
					if (t == -1)
					{
						result = "流程已锁定";
					}
					else
					{
						if (t == -2)
						{
							result = "流程已退回";
						}
						else
						{
							result = "已过期";
						}
					}
				}
			}
			return result;
		}
		private void AddDoc(int fid, int stepid)
		{
			Flows_DocInfo flows_DocInfo = new Flows_DocInfo();
			flows_DocInfo.AddTime = DateTime.Now;
			flows_DocInfo.DocPath = this.UpdateFiles();
			flows_DocInfo.DocBody = this.DocBody.Value;
			flows_DocInfo.Flow_ID = fid;
			flows_DocInfo.StepAction_ID = stepid;
			flows_DocInfo.UserDepName = this.DepName;
			flows_DocInfo.UserRealName = this.RealName;
			flows_DocInfo.UserID = Convert.ToInt32(this.Uid);
			Flows_Doc.Init().Add(flows_DocInfo);
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
				foreach (RepeaterItem repeaterItem in this.rpt.Items)
				{
					HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
					if (htmlInputCheckBox.Checked)
					{
						str2 = str2 + htmlInputCheckBox.Value + "|";
					}
				}
				if (this.display.Visible)
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
				throw;
			}
			return text;
		}
		protected bool IsOfficeFile(string filename)
		{
			bool result = false;
			if (filename.Contains("."))
			{
				string text = filename.Split(new char[]
				{
					'.'
				})[1].ToLower();
				if (text.Contains("doc") || text.Contains("xls"))
				{
					result = true;
				}
			}
			return result;
		}
		private string GetModelType(int comid)
		{
			string result = "暂无分类";
			if (comid > 0)
			{
				IList all = Flows_Model_Type.Init().GetAll("id=" + comid, null);
				if (all.Count > 0)
				{
					Flows_Model_TypeInfo flows_Model_TypeInfo = all[0] as Flows_Model_TypeInfo;
					result = flows_Model_TypeInfo.TypeName;
				}
			}
			return result;
		}
	}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       