﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;

public partial class Manage_Tasks_TypeList_ForView : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Repeater rpt;
		private int i = 1;
		private List<Tasks_TypeInfo> li = new List<Tasks_TypeInfo>();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Show();
			}
		}
		private void Show()
		{
			this.GetFirtNode();
			this.rpt.DataSource = this.li;
			this.rpt.DataBind();
		}
		private void GetFirtNode()
		{
			DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, "select * from Tasks_Type order by orders asc", null);
			dataSet.Relations.Add("sort", dataSet.Tables[0].Columns["id"], dataSet.Tables[0].Columns["ParentID"], false);
			foreach (DataRow dataRow in dataSet.Tables[0].Rows)
			{
				if (dataRow["ParentID"].ToString() == "0")
				{
					Tasks_TypeInfo tasks_TypeInfo = this.SetPram(dataRow);
					tasks_TypeInfo.Ch = "<img src=../images/ico_browsefolder.gif />";
					this.li.Add(tasks_TypeInfo);
					this.PopulateSubTree(dataRow, this.i);
				}
			}
			dataSet.Dispose();
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
					if (Convert.ToInt32(childRows[num]["orders"]) > Convert.ToInt32(childRows[j]["orders"]))
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
				string text = "<img src=../images/ico_intro.gif />";
				if (depth == 2)
				{
					if (object.ReferenceEquals(dataRow, childRows[childRows.Length - 1]))
					{
						tasks_TypeInfo.Ch = "\u3000└ " + text;
					}
					else
					{
						tasks_TypeInfo.Ch = "\u3000├ " + text;
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
							Tasks_TypeInfo expr_14E = tasks_TypeInfo;
							expr_14E.Ch = expr_14E.Ch + "\u3000└ " + text;
						}
						else
						{
							for (int l = 1; l < depth - 1; l++)
							{
								tasks_TypeInfo.Ch = "\u3000│" + tasks_TypeInfo.Ch;
							}
							Tasks_TypeInfo expr_195 = tasks_TypeInfo;
							expr_195.Ch = expr_195.Ch + "\u3000├ " + text;
						}
					}
				}
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
