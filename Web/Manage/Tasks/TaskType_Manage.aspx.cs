using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;

public partial class Manage_Tasks_TaskType_Manage : ModulePages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Button Button1;
        //protected HtmlInputText TypeName;
        //protected DropDownList parentID;
        //protected HtmlInputText Orders;
        //protected HtmlTextArea Notes;
        //protected Button save_bt;
		private int i = 1;
		private IList<Tasks_TypeInfo> li = new List<Tasks_TypeInfo>();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.GetFirtNode();
				this.parentID.Items.Add(new ListItem("作为根分类", "0"));
				int i = 0;
				int count = this.li.Count;
				while (i < count)
				{
					Tasks_TypeInfo tasks_TypeInfo = this.li[i];
					this.parentID.Items.Add(new ListItem(tasks_TypeInfo.Sh, string.Concat(tasks_TypeInfo.id)));
					i++;
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
				{
					this.Show(base.Request.QueryString["tid"]);
				}
			}
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
			{
				Convert.ToInt32(base.Request.QueryString["tid"]);
				Tasks_TypeInfo tasks_TypeInfo = this.ViewState["sd"] as Tasks_TypeInfo;
				tasks_TypeInfo.TypeName = this.TypeName.Value.Replace("#", "").Replace(",", "");
				tasks_TypeInfo.Orders = Convert.ToInt32(this.Orders.Value);
				tasks_TypeInfo.Notes = this.Notes.Value;
				if (Convert.ToInt32(this.parentID.SelectedValue) != tasks_TypeInfo.id)
				{
					tasks_TypeInfo.ParentID = Convert.ToInt32(this.parentID.SelectedValue);
				}
				Tasks_Type.Init().Update(tasks_TypeInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!工作任务分类已编辑成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=../Manage/Tasks/TaskType_List.aspx&tip=" + str);
			}
			else
			{
				Tasks_TypeInfo tasks_TypeInfo = new Tasks_TypeInfo();
				tasks_TypeInfo.TypeName = this.TypeName.Value.Replace("#", "").Replace(",", "");
				tasks_TypeInfo.Orders = Convert.ToInt32(this.Orders.Value);
				tasks_TypeInfo.Notes = this.Notes.Value;
				tasks_TypeInfo.ParentID = Convert.ToInt32(this.parentID.SelectedValue);
				Tasks_Type.Init().Add(tasks_TypeInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!工作任务分类已添加成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=../Manage/Tasks/TaskType_List.aspx&tip=" + str);
			}
		}
		private void Show(string did)
		{
			Tasks_TypeInfo byId = Tasks_Type.Init().GetById(Convert.ToInt32(did));
			this.ViewState["sd"] = byId;
			this.parentID.SelectedValue = string.Concat(byId.ParentID);
			this.TypeName.Value = byId.TypeName;
			this.Notes.Value = byId.Notes;
			this.Orders.Value = string.Concat(byId.Orders);
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
