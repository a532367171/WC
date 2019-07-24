using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;
using WC.DK;

public partial class Manage_Tasks_Task_List : ViewPages

	{
		private int i = 1;
		private IList<Tasks_TypeInfo> li = new List<Tasks_TypeInfo>();
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlGenericControl t_all;
        //protected HtmlGenericControl t_exeute;
        //protected HtmlGenericControl t_manage;
        //protected HtmlGenericControl t_create;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected DropDownList TypeID;
        //protected HtmlInputText TaskName;
        //protected HtmlInputText StartTime;
        //protected HtmlInputText EndTime;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page2;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["type"]))
			{
				string text = base.Request.QueryString["type"];
				if (text == "all" || text == "exeute" || text == "manage" || text == "create")
				{
					this.Show(text);
				}
			}
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			string text = HttpContext.Current.Server.HtmlEncode(base.Request.Form["TypeID"].Trim());
			string text2 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["TaskName"].Trim());
			string text3 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["StartTime"].Trim());
			string text4 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["state"].Trim());
			string text5 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["EndTime"].Trim());
			string str = string.Concat(new string[]
			{
				"?TypeID=",
				text,
				"&TaskName=",
				text2,
				"&State=",
				text4,
				"&StartTime=",
				text3,
				"&EndTime=",
				text5,
				"&type=",
				base.Request.QueryString["type"]
			});
			base.Response.Redirect("Task_List.aspx" + str);
		}
		protected void Del_Btn(object obj, EventArgs e)
		{
			LinkButton linkButton = obj as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
			HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
			int id = Convert.ToInt32(htmlInputCheckBox.Value);
			TasksInfo byId = Tasks.Init().GetById(id);
			IList all = Tasks_User.Init().GetAll("TaskID=" + byId.id, null);
			if (all.Count > 0)
			{
				int i = 0;
				int count = all.Count;
				while (i < count)
				{
					Tasks_UserInfo tasks_UserInfo = all[i] as Tasks_UserInfo;
					try
					{
						Help.DeleteFiles(tasks_UserInfo.FilePath);
					}
					catch
					{
					}
					i++;
				}
				string cmdText = "delete from Tasks_User where TaskID=" + byId.id;
				MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
			}
			try
			{
				Help.DeleteFiles(byId.FilePath);
			}
			catch
			{
			}
			Tasks.Init().Delete(id);
			this.Show(base.Request.QueryString["type"]);
		}
		private void Show(string tp)
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
			IList list = null;
			if (!string.IsNullOrEmpty(base.Request.QueryString["TypeID"]) || !string.IsNullOrEmpty(base.Request.QueryString["TaskName"]) || !string.IsNullOrEmpty(base.Request.QueryString["State"]) || !string.IsNullOrEmpty(base.Request.QueryString["StartTime"]) || !string.IsNullOrEmpty(base.Request.QueryString["EndTime"]))
			{
				string text = base.Request.QueryString["TypeID"];
				string text2 = base.Request.QueryString["TaskName"];
				string text3 = base.Request.QueryString["StartTime"];
				string text4 = base.Request.QueryString["EndTime"];
				string text5 = base.Request.QueryString["State"];
				string text6 = " 1=1 ";
				if (!string.IsNullOrEmpty(text))
				{
					text6 = text6 + " and (TypeID=" + text + ") ";
				}
				if (!string.IsNullOrEmpty(text5))
				{
					text6 = text6 + " and (Status=" + text5 + ") ";
				}
				if (!string.IsNullOrEmpty(text2))
				{
					text6 = text6 + " and (TaskName like '%" + text2 + "%') ";
				}
				if (!string.IsNullOrEmpty(text3) && !string.IsNullOrEmpty(text4))
				{
					string text7 = text6;
					text6 = string.Concat(new string[]
					{
						text7,
						" and (AddTime between '",
						text3,
						"' and '",
						text4,
						"') "
					});
				}
				if (tp == "all")
				{
					string text7 = text6;
					text6 = string.Concat(new string[]
					{
						text7,
						" and ( ManageUserList like '%#",
						this.Uid,
						"#%' or ExecuteUserList like '%#",
						this.Uid,
						"#%' )"
					});
				}
				if (tp == "exeute")
				{
					text6 = text6 + " and ( ExecuteUserList like '%#" + this.Uid + "#%' )";
				}
				if (tp == "manage")
				{
					text6 = text6 + " and ( ManageUserList like '%#" + this.Uid + "#%' )";
				}
				if (tp == "create")
				{
					text6 = text6 + " and ( CreatorID=" + this.Uid + " )";
				}
				list = Tasks.Init().GetAll(text6, "order by id desc");
			}
			else
			{
				string text6 = " 1=1 and ";
				if (tp == "all")
				{
					if (!string.IsNullOrEmpty(base.Request.QueryString["td"]))
					{
						if (Utils.IsNumber(base.Request.QueryString["td"]))
						{
							string text7 = text6;
							text6 = string.Concat(new string[]
							{
								text7,
								" ( TypeID=",
								base.Request.QueryString["td"],
								" ) and ( ManageUserList like '%#",
								this.Uid,
								"#%' or ExecuteUserList like '%#",
								this.Uid,
								"#%' )"
							});
						}
					}
					else
					{
						string text7 = text6;
						text6 = string.Concat(new string[]
						{
							text7,
							" ( ManageUserList like '%#",
							this.Uid,
							"#%' or ExecuteUserList like '%#",
							this.Uid,
							"#%' )"
						});
					}
				}
				if (tp == "exeute")
				{
					text6 = text6 + " ( ExecuteUserList like '%#" + this.Uid + "#%' )";
				}
				if (tp == "manage")
				{
					text6 = text6 + " ( ManageUserList like '%#" + this.Uid + "#%' )";
				}
				if (tp == "create")
				{
					text6 = text6 + " ( CreatorID=" + this.Uid + " )";
				}
				list = Tasks.Init().GetAll(text6, "order by id desc");
			}
			Hashtable hashtable = (Hashtable)HttpContext.Current.Application["config_fenye"];
			int pageSize = Convert.ToInt32(hashtable["fenye_commom"]);
			int num = 0;
			try
			{
				if (!string.IsNullOrEmpty(base.Request.QueryString["page"]))
				{
					num = Convert.ToInt32(base.Request.QueryString["page"]);
				}
			}
			catch
			{
			}
			if (num == 0)
			{
				num = 1;
			}
			PagedDataSource pagedDataSource = new PagedDataSource();
			pagedDataSource.DataSource = list;
			pagedDataSource.AllowPaging = true;
			pagedDataSource.PageSize = pageSize;
			pagedDataSource.CurrentPageIndex = num - 1;
			this.rpt.DataSource = pagedDataSource;
			this.rpt.DataBind();
			if (base.Request.QueryString["TaskName"] == null)
			{
				this.Page2.sty("meneame", num, pagedDataSource.PageCount, "?type=" + tp + "&page=");
			}
			if (base.Request.QueryString["TaskName"] != null)
			{
				this.Page2.sty("meneame", num, pagedDataSource.PageCount, string.Concat(new string[]
				{
					"?TaskName=",
					base.Request.QueryString["TaskName"],
					"&TypeID=",
					base.Request.QueryString["TypeID"],
					"&StartTime=",
					base.Request.QueryString["StartTime"],
					"&EndTime=",
					base.Request.QueryString["EndTime"],
					"&State=",
					base.Request.QueryString["State"],
					"&type=",
					tp,
					"&page="
				}));
			}
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + list.Count + "</span> 条 记录数据";
		}
		protected void RowDataBind(object sender, RepeaterItemEventArgs e)
		{
			LinkButton linkButton = e.Item.FindControl("b1") as LinkButton;
			LinkButton linkButton2 = e.Item.FindControl("b2") as LinkButton;
			if (linkButton.CommandArgument.Contains("*" + this.Uid + "*"))
			{
				linkButton.Visible = true;
			}
			else
			{
				linkButton.Visible = false;
			}
			if (linkButton2.CommandArgument.Contains("*" + this.Uid + "*"))
			{
				linkButton2.Visible = true;
			}
			else
			{
				linkButton2.Visible = false;
			}
		}
		protected void Edit_Btn(object sender, EventArgs e)
		{
			LinkButton linkButton = sender as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
			HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
			int num = Convert.ToInt32(htmlInputCheckBox.Value);
			base.Response.Redirect("Task_Manage.aspx?tid=" + num);
		}
		protected string GetManageUserList(object obj)
		{
			string text = string.Concat(obj);
			string text2 = "";
			if (text.Contains(","))
			{
				string[] array = text.Split(new char[]
				{
					','
				});
				int i = 0;
				int num = array.Length;
				while (i < num)
				{
					if (array[i].Contains("#"))
					{
						text2 = text2 + "*" + array[i].Split(new char[]
						{
							'#'
						})[1] + "*";
					}
					i++;
				}
			}
			return text2;
		}
		protected string GetStatus(object obj)
		{
			string text = string.Concat(obj);
			string result;
			if (text != null)
			{
				if (text == "-1")
				{
					result = "<strong style='color:#000'>已停止</strong>";
					return result;
				}
				if (text == "1")
				{
					result = "<strong style='color:#ff0000'>进行中</strong>";
					return result;
				}
				if (text == "2")
				{
					result = "<strong style='color:#006600'>已完成</strong>";
					return result;
				}
			}
			result = "";
			return result;
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
