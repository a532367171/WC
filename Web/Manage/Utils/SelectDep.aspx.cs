using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;

public partial class Manage_Utils_SelectDep : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlGenericControl number;
        //protected HtmlGenericControl total;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected Repeater rpt;
		private int i = 1;
		private List<Sys_DepInfo> li = new List<Sys_DepInfo>();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Show();
			}
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			string text = base.Request.Form["keyword"];
			string text2 = "?keywords=" + HttpContext.Current.Server.HtmlEncode(text.Trim());
			if (!string.IsNullOrEmpty(base.Request.QueryString["v"]))
			{
				text2 = text2 + "&v=" + base.Request.QueryString["v"];
			}
			base.Response.Redirect("SelectDeps.aspx" + text2);
		}
		private void Show()
		{
			this.GetFirtNode();
			this.rpt.DataSource = this.li;
			this.rpt.DataBind();
			int num = 0;
			if (!string.IsNullOrEmpty(base.Request.QueryString["v"]))
			{
				string[] array = base.Request.QueryString["v"].Split(new char[]
				{
					';'
				});
				List<string> list = new List<string>();
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].Trim() != "")
					{
						list.Add(array[i]);
					}
				}
				foreach (RepeaterItem repeaterItem in this.rpt.Items)
				{
					HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
					if (list.Contains(htmlInputCheckBox.Value.Split(new char[]
					{
						'#'
					})[1]))
					{
						htmlInputCheckBox.Checked = true;
						num++;
					}
				}
			}
			this.number.InnerText = string.Concat(num);
			this.total.InnerText = string.Concat(this.li.Count);
		}
		private void GetFirtNode()
		{
			DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, "select * from Sys_Dep order by orders asc", null);
			dataSet.Relations.Add("sort", dataSet.Tables[0].Columns["id"], dataSet.Tables[0].Columns["ParentID"], false);
			foreach (DataRow dataRow in dataSet.Tables[0].Rows)
			{
				if (dataRow["ParentID"].ToString() == "0")
				{
					Sys_DepInfo sys_DepInfo = this.SetPram(dataRow);
					sys_DepInfo.Ch = "<img src=../images/ico_system.gif />";
					this.li.Add(sys_DepInfo);
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
				Sys_DepInfo sys_DepInfo = this.SetPram(dataRow);
				string text;
				if (sys_DepInfo.IsPosition == 0)
				{
					text = "<img src=../images/ico_jingpin.gif />";
				}
				else
				{
					text = "<img src=../images/group.gif />";
				}
				if (depth == 2)
				{
					if (object.ReferenceEquals(dataRow, childRows[childRows.Length - 1]))
					{
						sys_DepInfo.Ch = "\u3000└ " + text;
					}
					else
					{
						sys_DepInfo.Ch = "\u3000├ " + text;
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
							Sys_DepInfo expr_166 = sys_DepInfo;
							expr_166.Ch = expr_166.Ch + "\u3000└ " + text;
						}
						else
						{
							for (int l = 1; l < depth - 1; l++)
							{
								sys_DepInfo.Ch = "\u3000│" + sys_DepInfo.Ch;
							}
							Sys_DepInfo expr_1AD = sys_DepInfo;
							expr_1AD.Ch = expr_1AD.Ch + "\u3000├ " + text;
						}
					}
				}
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
				IsPosition = Convert.ToInt32(dbRow["IsPosition"]),
				Phone = Convert.ToString(dbRow["Phone"])
			};
		}
		protected string getstr(object a, object b)
		{
			return Convert.ToString(a) + "<strong>" + Convert.ToString(b) + "</strong>";
		}
		protected string gettype(object a, object b)
		{
			string result;
			if (string.Concat(b) == "0")
			{
				result = "";
			}
			else
			{
				if (string.Concat(a) == "0")
				{
					result = "<span style='color:blue;'>职位</span>";
				}
				else
				{
					result = "部门";
				}
			}
			return result;
		}
	}
