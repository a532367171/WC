using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;

public partial class Manage_Utils_SelectPeople_rt : ViewPages

	{
		private int i = 1;
		private IList<Sys_DepInfo> li = new List<Sys_DepInfo>();
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlInputHidden alluserlist;
        //protected HtmlInputHidden allnamelist;
        //protected HtmlInputHidden allcount;
        //protected Panel panLogin;
        //protected HtmlGenericControl number;
        //protected HtmlGenericControl total;
        //protected Button search_bt;
        //protected DropDownList DepTree;
        //protected Repeater rpt;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.InitData();
				this.Show();
			}
		}
		private void InitData()
		{
			this.GetFirtNode();
			this.DepTree.DataSource = this.li;
			this.DepTree.DataTextField = "Sh";
			this.DepTree.DataValueField = "ID";
			this.DepTree.DataBind();
			this.DepTree.SelectedValue = (this.DepID ?? "");
		}
		protected void SelectDep(object sender, EventArgs e)
		{
			DropDownList dropDownList = sender as DropDownList;
			string selectedValue = dropDownList.SelectedValue;
			List<Sys_UserInfo> list = new List<Sys_UserInfo>();
			this.GetTreeItems(Convert.ToInt32(selectedValue), list);
			this.rpt.DataSource = list;
			this.rpt.DataBind();
			this.total.InnerText = string.Concat(list.Count);
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			string text = base.Request.Form["keyword"];
			string text2 = "?keywords=" + HttpContext.Current.Server.HtmlEncode(text.Trim());
			if (!string.IsNullOrEmpty(base.Request.QueryString["v"]))
			{
				text2 = text2 + "&v=" + base.Request.QueryString["v"];
			}
			base.Response.Redirect("SelectPeople_rt.aspx" + text2);
		}
		private void Show()
		{
			IList all = Sys_User.Init().GetAll("Status=0 and IsLock=0 ", "order by orders asc");
			this.allcount.Value = string.Concat(all.Count);
			this.alluserlist.Value = "";
			this.allnamelist.Value = "";
			foreach (object current in all)
			{
				Sys_UserInfo sys_UserInfo = current as Sys_UserInfo;
				HtmlInputHidden expr_78 = this.alluserlist;
				object value = expr_78.Value;
				expr_78.Value = string.Concat(new object[]
				{
					value,
					sys_UserInfo.RealName,
					"#",
					sys_UserInfo.id,
					"#",
					sys_UserInfo.DepName,
					","
				});
				HtmlInputHidden expr_E1 = this.allnamelist;
				string text = expr_E1.Value;
				expr_E1.Value = string.Concat(new string[]
				{
					text,
					sys_UserInfo.RealName,
					"(",
					sys_UserInfo.DepName,
					"),"
				});
			}
			IList list = Sys_User.Init().GetAll("Status=0 and IsLock=0 and depid=" + this.DepID, "order by orders asc");
			string text2 = "Status=0 and IsLock=0 and ";
			string text3 = base.Request.QueryString["keywords"];
			if (!string.IsNullOrEmpty(text3) && Utils.CheckSql(text3))
			{
				string text = text2;
				text2 = string.Concat(new string[]
				{
					text,
					" (UserName like '%",
					text3,
					"%' or RealName like '%",
					text3,
					"%' or DepName like '%",
					text3,
					"%' ) "
				});
				list = Sys_User.Init().GetAll(text2, "order by depid,orders asc");
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["did"]))
			{
				list = new List<Sys_UserInfo>();
				this.GetTreeItems(Convert.ToInt32(base.Request.QueryString["did"]), list);
			}
			this.rpt.DataSource = list;
			this.rpt.DataBind();
			this.total.InnerText = string.Concat(list.Count);
		}
		private void GetTreeItems(int did, IList li)
		{
			IList all = Sys_User.Init().GetAll("Status=0 and IsLock=0 and DepID=" + did, "order by status asc,orders asc");
			foreach (object current in all)
			{
				if (!li.Contains(current))
				{
					li.Add(current);
				}
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
		private void GetFirtNode()
		{
			DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, "select * from Sys_Dep", null);
			dataSet.Relations.Add("sort", dataSet.Tables[0].Columns["id"], dataSet.Tables[0].Columns["ParentID"], false);
			foreach (DataRow dataRow in dataSet.Tables[0].Rows)
			{
				if (dataRow["ParentID"].ToString() == "0")
				{
					Sys_DepInfo sys_DepInfo = this.SetPram(dataRow);
					sys_DepInfo.Ch = "";
					sys_DepInfo.Sh = sys_DepInfo.DepName;
					this.li.Add(sys_DepInfo);
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
				Sys_DepInfo sys_DepInfo = this.SetPram(dataRow);
				if (depth == 2)
				{
					if (object.ReferenceEquals(dataRow, childRows[childRows.Length - 1]))
					{
						sys_DepInfo.Ch = "\u3000└ ";
					}
					else
					{
						sys_DepInfo.Ch = "\u3000├ ";
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
								sys_DepInfo.Ch = "\u3000│" + sys_DepInfo.Ch;
							}
							Sys_DepInfo expr_132 = sys_DepInfo;
							expr_132.Ch += "\u3000└ ";
						}
						else
						{
							for (int l = 1; l < depth - 1; l++)
							{
								sys_DepInfo.Ch = "\u3000│" + sys_DepInfo.Ch;
							}
							Sys_DepInfo expr_177 = sys_DepInfo;
							expr_177.Ch += "\u3000├ ";
						}
					}
				}
				sys_DepInfo.Sh = sys_DepInfo.Ch + sys_DepInfo.DepName;
				this.li.Add(sys_DepInfo);
				this.PopulateSubTree(dataRow, depth);
			}
		}
		private Sys_DepInfo SetPram(DataRow dbRow)
		{
			return new Sys_DepInfo
			{
				id = Convert.ToInt32(dbRow["id"]),
				DepName = Convert.ToString(dbRow["DepName"]),
				ParentID = Convert.ToInt32(dbRow["ParentID"]),
				Orders = Convert.ToInt32(dbRow["Orders"]),
				IsPosition = Convert.ToInt32(dbRow["IsPosition"])
			};
		}
	}
