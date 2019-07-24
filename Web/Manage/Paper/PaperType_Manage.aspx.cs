using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;

public partial class Manage_Paper_PaperType_Manage : ModulePages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlInputText TypeName;
        //protected DropDownList parentID;
        //protected HtmlInputText Orders;
        //protected HtmlTextArea Notes;
        //protected Button save_bt;
		private int i = 1;
		private IList<PaperTypeInfo> li = new List<PaperTypeInfo>();
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
					PaperTypeInfo paperTypeInfo = this.li[i];
					this.parentID.Items.Add(new ListItem(paperTypeInfo.Sh, string.Concat(paperTypeInfo.id)));
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
			PaperTypeInfo byId = PaperType.Init().GetById(Convert.ToInt32(did));
			this.ViewState["sd"] = byId;
			this.parentID.SelectedValue = string.Concat(byId.ParentID);
			this.TypeName.Value = byId.TypeName;
			this.Notes.Value = byId.Notes;
			this.Orders.Value = string.Concat(byId.Orders);
		}
		private void GetFirtNode()
		{
			DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, "select * from PaperType", null);
			dataSet.Relations.Add("sort", dataSet.Tables[0].Columns["id"], dataSet.Tables[0].Columns["ParentID"], false);
			foreach (DataRow dataRow in dataSet.Tables[0].Rows)
			{
				if (dataRow["ParentID"].ToString() == "0")
				{
					PaperTypeInfo paperTypeInfo = this.SetPram(dataRow);
					paperTypeInfo.Ch = "";
					paperTypeInfo.Sh = paperTypeInfo.TypeName;
					this.li.Add(paperTypeInfo);
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
				PaperTypeInfo paperTypeInfo = this.SetPram(dataRow);
				if (depth == 2)
				{
					if (object.ReferenceEquals(dataRow, childRows[childRows.Length - 1]))
					{
						paperTypeInfo.Ch = "\u3000└ ";
					}
					else
					{
						paperTypeInfo.Ch = "\u3000├ ";
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
							PaperTypeInfo expr_132 = paperTypeInfo;
							expr_132.Ch += "\u3000└ ";
						}
						else
						{
							for (int l = 1; l < depth - 1; l++)
							{
								paperTypeInfo.Ch = "\u3000│" + paperTypeInfo.Ch;
							}
							PaperTypeInfo expr_177 = paperTypeInfo;
							expr_177.Ch += "\u3000├ ";
						}
					}
				}
				paperTypeInfo.Sh = paperTypeInfo.Ch + paperTypeInfo.TypeName;
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
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
			{
				PaperTypeInfo paperTypeInfo = this.ViewState["sd"] as PaperTypeInfo;
				paperTypeInfo.Notes = this.Notes.Value;
				paperTypeInfo.TypeName = this.TypeName.Value.Replace("#", "").Replace(",", "");
				paperTypeInfo.Orders = Convert.ToInt32(this.Orders.Value);
				if (Convert.ToInt32(this.parentID.SelectedValue) != paperTypeInfo.id)
				{
					paperTypeInfo.ParentID = Convert.ToInt32(this.parentID.SelectedValue);
				}
				PaperType.Init().Update(paperTypeInfo);
			}
			else
			{
				PaperTypeInfo paperTypeInfo = new PaperTypeInfo();
				paperTypeInfo.TypeName = this.TypeName.Value.Replace("#", "").Replace(",", "");
				paperTypeInfo.Notes = this.Notes.Value;
				paperTypeInfo.Orders = Convert.ToInt32(this.Orders.Value);
				paperTypeInfo.ParentID = Convert.ToInt32(this.parentID.SelectedValue);
				PaperType.Init().Add(paperTypeInfo);
			}
			string str = HttpContext.Current.Server.HtmlEncode("您好!档案分类保存成功!");
			base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=../Manage/Paper/PaperType_List.aspx&tip=" + str);
		}
	}
