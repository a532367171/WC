using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;

public partial class Manage_flow_FlowType_Manage : ModulePages
{
   
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlInputText TypeName;
        //protected DropDownList parentID;
        //protected HtmlInputText Orders;
        //protected HtmlTextArea Notes;
        //protected Button save_bt;
		private int i = 1;
		private IList<Flows_Model_TypeInfo> li = new List<Flows_Model_TypeInfo>();
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
					Flows_Model_TypeInfo flows_Model_TypeInfo = this.li[i];
					this.parentID.Items.Add(new ListItem(flows_Model_TypeInfo.Sh, string.Concat(flows_Model_TypeInfo.id)));
					i++;
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
				{
					this.Show(base.Request.QueryString["tid"]);
				}
			}
		}
		private void Show(string did)
		{
			Flows_Model_TypeInfo byId = Flows_Model_Type.Init().GetById(Convert.ToInt32(did));
			this.ViewState["sd"] = byId;
			this.parentID.SelectedValue = string.Concat(byId.ParentID);
			this.TypeName.Value = byId.TypeName;
			this.Notes.Value = byId.Notes;
			this.Orders.Value = string.Concat(byId.Orders);
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
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
			{
				Flows_Model_TypeInfo flows_Model_TypeInfo = this.ViewState["sd"] as Flows_Model_TypeInfo;
				flows_Model_TypeInfo.Notes = this.Notes.Value;
				flows_Model_TypeInfo.TypeName = this.TypeName.Value.Replace("#", "").Replace(",", "");
				flows_Model_TypeInfo.Orders = Convert.ToInt32(this.Orders.Value);
				if (Convert.ToInt32(this.parentID.SelectedValue) != flows_Model_TypeInfo.id)
				{
					flows_Model_TypeInfo.ParentID = Convert.ToInt32(this.parentID.SelectedValue);
				}
				Flows_Model_Type.Init().Update(flows_Model_TypeInfo);
			}
			else
			{
				Flows_Model_TypeInfo flows_Model_TypeInfo = new Flows_Model_TypeInfo();
				flows_Model_TypeInfo.TypeName = this.TypeName.Value.Replace("#", "").Replace(",", "");
				flows_Model_TypeInfo.Notes = this.Notes.Value;
				flows_Model_TypeInfo.Orders = Convert.ToInt32(this.Orders.Value);
				flows_Model_TypeInfo.ParentID = Convert.ToInt32(this.parentID.SelectedValue);
				Flows_Model_Type.Init().Add(flows_Model_TypeInfo);
			}
			string str = HttpContext.Current.Server.HtmlEncode("您好!流程模型分类保存成功!");
			base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=../Manage/Flow/FlowType_List.aspx&tip=" + str);
		}
	}
