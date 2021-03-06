﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.DK;

public partial class Manage_Paper_PaperType_List : ModulePages

	{
		private int i = 1;
		private List<PaperTypeInfo> li = new List<PaperTypeInfo>();
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Repeater rpt;
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
		protected void Del_Btn(object sender, EventArgs e)
		{
			LinkButton linkButton = sender as LinkButton;
			string commandArgument = linkButton.CommandArgument;
			PaperTypeInfo byId = PaperType.Init().GetById(Convert.ToInt32(commandArgument));
			this.DeleteDep(byId);
			this.Show();
		}
		private void DeleteDep(PaperTypeInfo sdi)
		{
			IList all = PaperType.Init().GetAll("ParentID=" + sdi.id, null);
			for (int i = 0; i < all.Count; i++)
			{
				PaperTypeInfo sdi2 = all[i] as PaperTypeInfo;
				this.DeleteDep(sdi2);
			}
			this.DeletePaper(sdi.id);
			PaperType.Init().Delete(sdi.id);
		}
		private void DeletePaper(int rid)
		{
			try
			{
				IList all = Paper.Init().GetAll("TypeID=" + rid, null);
				if (all != null && all.Count > 0)
				{
					foreach (object current in all)
					{
						PaperInfo paperInfo = current as PaperInfo;
						Help.DeleteFiles(paperInfo.FilePath);
					}
				}
			}
			catch
			{
			}
			string cmdText = "delete from Paper where typeid=" + rid;
			MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
		}
		private void GetFirtNode()
		{
			DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, "select * from PaperType order by orders asc", null);
			dataSet.Relations.Add("sort", dataSet.Tables[0].Columns["id"], dataSet.Tables[0].Columns["ParentID"], false);
			foreach (DataRow dataRow in dataSet.Tables[0].Rows)
			{
				if (dataRow["ParentID"].ToString() == "0")
				{
					PaperTypeInfo paperTypeInfo = this.SetPram(dataRow);
					paperTypeInfo.Ch = "<img src=../images/ico_browsefolder.gif />";
					this.li.Add(paperTypeInfo);
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
				PaperTypeInfo paperTypeInfo = this.SetPram(dataRow);
				string text = "<img src=../images/ico_intro.gif />";
				if (depth == 2)
				{
					if (object.ReferenceEquals(dataRow, childRows[childRows.Length - 1]))
					{
						paperTypeInfo.Ch = "\u3000└ " + text;
					}
					else
					{
						paperTypeInfo.Ch = "\u3000├ " + text;
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
								paperTypeInfo.Ch = "\u3000│" + paperTypeInfo.Ch;
							}
							PaperTypeInfo expr_14E = paperTypeInfo;
							expr_14E.Ch = expr_14E.Ch + "\u3000└ " + text;
						}
						else
						{
							for (int l = 1; l < depth - 1; l++)
							{
								paperTypeInfo.Ch = "\u3000│" + paperTypeInfo.Ch;
							}
							PaperTypeInfo expr_195 = paperTypeInfo;
							expr_195.Ch = expr_195.Ch + "\u3000├ " + text;
						}
					}
				}
				this.li.Add(paperTypeInfo);
				this.PopulateSubTree(dataRow, depth);
			}
		}
		private PaperTypeInfo SetPram(DataRow dbRow)
		{
			return new PaperTypeInfo
			{
				id = Convert.ToInt32(dbRow["id"]),
				TypeName = Convert.ToString(dbRow["TypeName"]),
				ParentID = Convert.ToInt32(dbRow["ParentID"]),
				Orders = Convert.ToInt32(dbRow["Orders"])
			};
		}
	}
