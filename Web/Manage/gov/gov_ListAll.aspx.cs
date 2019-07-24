using MagicAjax.UI.Controls;
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
using WC.DK;

public partial class Manage_gov_gov_ListAll : ModulePages

{

		private int i = 1;
		private IList<Gov_Model_TypeInfo> li = new List<Gov_Model_TypeInfo>();
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected AjaxPanel Ajaxpanel1;
        //protected DropDownList Model_Type;
        //protected DropDownList Model;
        //protected HtmlInputText keyword;
        //protected HtmlInputText StartTime;
        //protected HtmlInputText EndTime;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page2;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Show();
			}
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			string text = HttpContext.Current.Server.HtmlEncode(base.Request.Form["keyword"].Trim());
			string text2 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["Model"]);
			string text3 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["StartTime"].Trim());
			string text4 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["EndTime"].Trim());
			string text5 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["state"].Trim());
			string str = string.Concat(new string[]
			{
				"?keywords=",
				text,
				"&stt=",
				text5,
				"&md=",
				text2,
				"&st=",
				text3,
				"&et=",
				text4
			});
			base.Response.Redirect("Gov_ListAll.aspx" + str);
		}
		protected void ModelType_btn(object sender, EventArgs e)
		{
			int num = Convert.ToInt32(this.Model_Type.SelectedValue);
			this.Model.Items.Clear();
			if (num == -1)
			{
				IList all = Gov_Model.Init().GetAll("IsComplete=1 and ( ShareDeps='' or ShareDeps like '%#" + this.DepID + "#%') ", null);
				this.Model.Items.Add(new ListItem("所有公文模型", ""));
				for (int i = 0; i < all.Count; i++)
				{
					Gov_ModelInfo gov_ModelInfo = all[i] as Gov_ModelInfo;
					this.Model.Items.Add(new ListItem(gov_ModelInfo.Flow_Name, gov_ModelInfo.Flow_Name));
				}
			}
			if (num == 0)
			{
				IList all = Gov_Model.Init().GetAll("comid=0 and IsComplete=1 and ( ShareDeps='' or ShareDeps like '%#" + this.DepID + "#%') ", null);
				this.Model.Items.Add(new ListItem("所有公文模型", ""));
				for (int i = 0; i < all.Count; i++)
				{
					Gov_ModelInfo gov_ModelInfo = all[i] as Gov_ModelInfo;
					this.Model.Items.Add(new ListItem(gov_ModelInfo.Flow_Name, gov_ModelInfo.Flow_Name));
				}
			}
			if (num > 0)
			{
				IList all = Gov_Model.Init().GetAll(string.Concat(new object[]
				{
					"comid=",
					num,
					" and IsComplete=1 and ( ShareDeps='' or ShareDeps like '%#",
					this.DepID,
					"#%') "
				}), null);
				this.Model.Items.Add(new ListItem("所有公文模型", ""));
				for (int i = 0; i < all.Count; i++)
				{
					Gov_ModelInfo gov_ModelInfo = all[i] as Gov_ModelInfo;
					this.Model.Items.Add(new ListItem(gov_ModelInfo.Flow_Name, gov_ModelInfo.Flow_Name));
				}
			}
		}
		protected void Del(object sender, EventArgs e)
		{
			LinkButton linkButton = sender as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
			HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
			string value = htmlInputCheckBox.Value;
			try
			{
				int num = Convert.ToInt32(value);
				GovInfo byId = Gov.Init().GetById(num);
				if (byId != null)
				{
					Help.DeleteFiles(byId.Flow_Files);
					Help.DeleteFiles(byId.CurrentDocPath);
				}
				IList all = Gov_Doc.Init().GetAll("flow_id=" + num, null);
				if (all != null && all.Count > 0)
				{
					foreach (object current in all)
					{
						Gov_DocInfo gov_DocInfo = current as Gov_DocInfo;
						Help.DeleteFiles(gov_DocInfo.DocPath);
					}
				}
			}
			catch
			{
			}
			string text = "delete from Gov where id=" + value + ";";
			string text2 = "delete from Gov_Step where Flow_ID=" + value + ";";
			string text3 = "delete from Gov_StepAction where FlowID=" + value + ";";
			string text4 = "delete from Gov_Doc where Flow_ID=" + value + ";";
			string text5 = "delete from Gov_Recipient where Flow_ID=" + value + ";";
			MsSqlOperate.ExecuteNonQuery(CommandType.Text, string.Concat(new string[]
			{
				text,
				text2,
				text3,
				text4,
				text5
			}), new SqlParameter[0]);
			this.Show();
		}
		protected void Lock(object sender, EventArgs e)
		{
			LinkButton linkButton = sender as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
			HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
			string value = htmlInputCheckBox.Value;
			string commandArgument = linkButton.CommandArgument;
			if (commandArgument == "-1" || commandArgument == "0")
			{
				string str = "";
				if (commandArgument == "-1")
				{
					str = "0";
				}
				if (commandArgument == "0")
				{
					str = "-1";
				}
				string cmdText = "update Gov set status=" + str + " where id=" + value;
				MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
			}
			this.Show();
		}
		private void Show()
		{
			this.GetFirtNode();
			this.Model_Type.Items.Add(new ListItem("== 列出所有公文模型分类", "-1"));
			int i = 0;
			int count = this.li.Count;
			while (i < count)
			{
				Gov_Model_TypeInfo gov_Model_TypeInfo = this.li[i];
				this.Model_Type.Items.Add(new ListItem(gov_Model_TypeInfo.Sh, string.Concat(gov_Model_TypeInfo.id)));
				i++;
			}
			this.Model_Type.Items.Add(new ListItem("不属于任何分类", "0"));
			IList all = Gov_Model.Init().GetAll(null, null);
			this.Model.Items.Clear();
			this.Model.Items.Add(new ListItem("所有公文模型", ""));
			foreach (object current in all)
			{
				Gov_ModelInfo gov_ModelInfo = current as Gov_ModelInfo;
				this.Model.Items.Add(new ListItem(gov_ModelInfo.Flow_Name, gov_ModelInfo.Flow_Name));
			}
			IList list = null;
			if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]) || !string.IsNullOrEmpty(base.Request.QueryString["md"]) || !string.IsNullOrEmpty(base.Request.QueryString["st"]) || !string.IsNullOrEmpty(base.Request.QueryString["et"]) || !string.IsNullOrEmpty(base.Request.QueryString["stt"]))
			{
				string text = base.Request.QueryString["keywords"];
				string text2 = string.Concat(new string[]
				{
					" (flow_name like '%",
					text,
					"%' or CurrentStepName like '%",
					text,
					"%' or CreatorRealName like '%",
					text,
					"%' ) "
				});
				string text3 = base.Request.QueryString["md"];
				string text4 = base.Request.QueryString["st"];
				string text5 = base.Request.QueryString["et"];
				string text6 = base.Request.QueryString["stt"];
				if (string.IsNullOrEmpty(text))
				{
					text2 = " 1=1 ";
				}
				if (!string.IsNullOrEmpty(text6))
				{
					text2 = text2 + " and (status=" + text6 + ") ";
				}
				if (!string.IsNullOrEmpty(text3))
				{
					text2 = text2 + " and (ModelName='" + text3 + "') ";
				}
				if (!string.IsNullOrEmpty(text4) && !string.IsNullOrEmpty(text5))
				{
					string text7 = text2;
					text2 = string.Concat(new string[]
					{
						text7,
						" and (addtime between '",
						text4,
						"' and '",
						text5,
						"')"
					});
				}
				if (!string.IsNullOrEmpty(text4) && string.IsNullOrEmpty(text5))
				{
					text2 = text2 + " and (addtime between '" + text4 + "' and getdate())";
				}
				if (string.IsNullOrEmpty(text4) && !string.IsNullOrEmpty(text5))
				{
					text2 = text2 + " and (addtime between getdate() and '" + text5 + "')";
				}
				list = Gov.Init().GetAll(text2, "order by id desc");
			}
			else
			{
				list = Gov.Init().GetAll(null, "order by id desc");
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
			if (base.Request.QueryString["keywords"] == null)
			{
				this.Page2.sty("meneame", num, pagedDataSource.PageCount, "?page=");
			}
			if (base.Request.QueryString["keywords"] != null)
			{
				this.Page2.sty("meneame", num, pagedDataSource.PageCount, string.Concat(new string[]
				{
					"?keywords=",
					base.Request.QueryString["keywords"],
					"&stt=",
					base.Request.QueryString["stt"],
					"&md=",
					base.Request.QueryString["md"],
					"&st=",
					base.Request.QueryString["st"],
					"&et=",
					base.Request.QueryString["et"],
					"&page="
				}));
			}
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + list.Count + "</span> 条 记录数据";
		}
		protected string GetStatus(object obj)
		{
			int num = Convert.ToInt32(obj);
			string result;
			if (num == 0)
			{
				if (base.Request.QueryString["action"] == "verify")
				{
					result = "<span style='color:#ff0000;'>待审批</span>";
				}
				else
				{
					result = "<span style='color:#ff0000;'>审批中</span>";
				}
			}
			else
			{
				if (num == 1)
				{
					result = "<span style='color:#006600;font-weight:bold'>已签发</span>";
				}
				else
				{
					if (num == -1)
					{
						result = "<span style='color:#999999;font-weight:bold'>已锁定</span>";
					}
					else
					{
						if (num == -2)
						{
							result = "<span style='color:black;font-weight:bold'>已退回</span>";
						}
						else
						{
							if (num == 5)
							{
								result = "<span style='color:black;font-weight:bold'>已归档</span>";
							}
							else
							{
								result = "<span style='color:blue;'>已过期</span>";
							}
						}
					}
				}
			}
			return result;
		}
		private void GetFirtNode()
		{
			DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, "select * from Gov_Model_Type", null);
			dataSet.Relations.Add("sort", dataSet.Tables[0].Columns["id"], dataSet.Tables[0].Columns["ParentID"], false);
			foreach (DataRow dataRow in dataSet.Tables[0].Rows)
			{
				if (dataRow["ParentID"].ToString() == "0")
				{
					Gov_Model_TypeInfo gov_Model_TypeInfo = this.SetPram(dataRow);
					gov_Model_TypeInfo.Ch = "";
					gov_Model_TypeInfo.Sh = gov_Model_TypeInfo.TypeName;
					this.li.Add(gov_Model_TypeInfo);
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
				Gov_Model_TypeInfo gov_Model_TypeInfo = this.SetPram(dataRow);
				if (depth == 2)
				{
					if (object.ReferenceEquals(dataRow, childRows[childRows.Length - 1]))
					{
						gov_Model_TypeInfo.Ch = "\u3000└ ";
					}
					else
					{
						gov_Model_TypeInfo.Ch = "\u3000├ ";
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
								gov_Model_TypeInfo.Ch = "\u3000│" + gov_Model_TypeInfo.Ch;
							}
							Gov_Model_TypeInfo expr_132 = gov_Model_TypeInfo;
							expr_132.Ch += "\u3000└ ";
						}
						else
						{
							for (int l = 1; l < depth - 1; l++)
							{
								gov_Model_TypeInfo.Ch = "\u3000│" + gov_Model_TypeInfo.Ch;
							}
							Gov_Model_TypeInfo expr_177 = gov_Model_TypeInfo;
							expr_177.Ch += "\u3000├ ";
						}
					}
				}
				gov_Model_TypeInfo.Sh = gov_Model_TypeInfo.Ch + gov_Model_TypeInfo.TypeName;
				this.li.Add(gov_Model_TypeInfo);
				this.PopulateSubTree(dataRow, depth);
			}
		}
		private Gov_Model_TypeInfo SetPram(DataRow dbRow)
		{
			return new Gov_Model_TypeInfo
			{
				id = Convert.ToInt32(dbRow["id"]),
				TypeName = Convert.ToString(dbRow["TypeName"]),
				ParentID = Convert.ToInt32(dbRow["ParentID"]),
				Orders = Convert.ToInt32(dbRow["Orders"])
			};
		}
	}

