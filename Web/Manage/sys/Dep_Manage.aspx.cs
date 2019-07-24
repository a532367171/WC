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

public partial class Manage_sys_Dep_Manage : ModulePages
{

		private int i = 1;
		private IList<Sys_DepInfo> li = new List<Sys_DepInfo>();
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Button Button1;
        //protected HtmlInputText UDepName;
        //protected HtmlInputText Phone;
        //protected DropDownList IsPosition;
        //protected DropDownList parentID;
        //protected HtmlInputText Orders;
        //protected HtmlTextArea Notes;
        //protected CheckBoxList powerList;
        //protected Button save_bt;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				IList all = Sys_Module.Init().GetAll(null, "order by TypeName,Orders");
				for (int i = 0; i < all.Count; i++)
				{
					Sys_ModuleInfo sys_ModuleInfo = all[i] as Sys_ModuleInfo;
					this.powerList.Items.Add(new ListItem("【" + sys_ModuleInfo.TypeName + "】 - " + sys_ModuleInfo.ModuleName, string.Concat(sys_ModuleInfo.id)));
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["did"]))
				{
					this.GetFirtNode();
					this.parentID.DataSource = this.li;
					this.parentID.DataTextField = "Sh";
					this.parentID.DataValueField = "ID";
					this.parentID.DataBind();
					this.Show(base.Request.QueryString["did"]);
				}
				else
				{
					this.GetFirtNode();
					this.parentID.DataSource = this.li;
					this.parentID.DataTextField = "Sh";
					this.parentID.DataValueField = "ID";
					this.parentID.DataBind();
				}
			}
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["did"]))
			{
				int num = Convert.ToInt32(base.Request.QueryString["did"]);
				Sys_DepInfo sys_DepInfo = this.ViewState["sd"] as Sys_DepInfo;
				sys_DepInfo.DepName = this.UDepName.Value.Replace("#", "").Replace(",", "");
				sys_DepInfo.IsPosition = Convert.ToInt32(this.IsPosition.SelectedValue);
				sys_DepInfo.Orders = Convert.ToInt32(this.Orders.Value);
				sys_DepInfo.Notes = this.Notes.Value;
				sys_DepInfo.Phone = this.Phone.Value;
				if (sys_DepInfo.ParentID != 0)
				{
					sys_DepInfo.ParentID = Convert.ToInt32(this.parentID.SelectedValue);
				}
				Sys_Dep.Init().Update(sys_DepInfo);
				string cmdText = string.Concat(new object[]
				{
					"update Sys_User set DepName='",
					sys_DepInfo.DepName,
					"' where DepID=",
					sys_DepInfo.id
				});
				MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, null);
				List<string> list = this.ViewState["old_module"] as List<string>;
				List<string> list2 = new List<string>();
				for (int i = 0; i < this.powerList.Items.Count; i++)
				{
					if (this.powerList.Items[i].Selected)
					{
						list2.Add(this.powerList.Items[i].Value);
					}
				}
				for (int i = 0; i < list.Count; i++)
				{
					if (!list2.Contains(list[i]))
					{
						string cmdText2 = string.Concat(new object[]
						{
							"delete from Sys_Dep_Module where DepID=",
							num,
							" and ModuleID=",
							list[i]
						});
						MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText2, null);
					}
				}
				for (int i = 0; i < list2.Count; i++)
				{
					if (!list.Contains(list2[i]))
					{
						Sys_Dep_ModuleInfo sys_Dep_ModuleInfo = new Sys_Dep_ModuleInfo();
						sys_Dep_ModuleInfo.ModuleID = Convert.ToInt32(list2[i]);
						sys_Dep_ModuleInfo.DepID = num;
						Sys_Dep_Module.Init().Add(sys_Dep_ModuleInfo);
					}
				}
				string str = HttpContext.Current.Server.HtmlEncode("您好!部门/职位已编辑成功!");
                base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
			else
			{
				Sys_DepInfo sys_DepInfo = new Sys_DepInfo();
				sys_DepInfo.DepName = this.UDepName.Value.Replace("#", "").Replace(",", "");
				sys_DepInfo.IsPosition = Convert.ToInt32(this.IsPosition.SelectedValue);
				sys_DepInfo.Orders = Convert.ToInt32(this.Orders.Value);
				sys_DepInfo.Notes = this.Notes.Value;
				sys_DepInfo.Phone = this.Phone.Value;
				sys_DepInfo.ParentID = Convert.ToInt32(this.parentID.SelectedValue);
				Sys_Dep.Init().Add(sys_DepInfo);
				for (int i = 0; i < this.powerList.Items.Count; i++)
				{
					if (this.powerList.Items[i].Selected)
					{
						Sys_Dep_ModuleInfo sys_Dep_ModuleInfo = new Sys_Dep_ModuleInfo();
						sys_Dep_ModuleInfo.ModuleID = Convert.ToInt32(this.powerList.Items[i].Value);
						sys_Dep_ModuleInfo.DepID = sys_DepInfo.id;
						Sys_Dep_Module.Init().Add(sys_Dep_ModuleInfo);
					}
				}
				string str = HttpContext.Current.Server.HtmlEncode("您好!部门/职位已添加成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
		}
		private void Show(string did)
		{
			Sys_DepInfo byId = Sys_Dep.Init().GetById(Convert.ToInt32(did));
			this.ViewState["sd"] = byId;
			this.parentID.SelectedValue = string.Concat(byId.ParentID);
			this.UDepName.Value = byId.DepName;
			this.Notes.Value = byId.Notes;
			this.IsPosition.SelectedValue = string.Concat(byId.IsPosition);
			this.Orders.Value = string.Concat(byId.Orders);
			this.Phone.Value = byId.Phone;
			IList all = Sys_Dep_Module.Init().GetAll("DepID=" + did, null);
			List<string> list = new List<string>();
			for (int i = 0; i < all.Count; i++)
			{
				Sys_Dep_ModuleInfo sys_Dep_ModuleInfo = all[i] as Sys_Dep_ModuleInfo;
				list.Add(string.Concat(sys_Dep_ModuleInfo.ModuleID));
			}
			this.ViewState["old_module"] = list;
			this.powerListBind(all, this.powerList);
		}
		private void powerListBind(IList list, CheckBoxList cbList)
		{
			for (int i = 0; i < cbList.Items.Count; i++)
			{
				for (int j = 0; j < list.Count; j++)
				{
					Sys_Dep_ModuleInfo sys_Dep_ModuleInfo = list[j] as Sys_Dep_ModuleInfo;
					if (cbList.Items[i].Value == string.Concat(sys_Dep_ModuleInfo.ModuleID))
					{
						cbList.Items[i].Selected = true;
					}
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


