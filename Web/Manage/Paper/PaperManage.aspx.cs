using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;

public partial class Manage_Paper_PaperManage : ModulePages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Button Button1;
        //protected HtmlInputText PaperName;
        //protected DropDownList TypeID;
        //protected HtmlInputText SendDep;
        //protected HtmlInputText PaperSymbol;
        //protected HtmlInputText PaperGrade;
        //protected HtmlInputText PaperDate;
        //protected HtmlSelect sel;
        //protected HtmlTableRow tr;
        //protected HtmlInputHidden userlist_dep;
        //protected HtmlInputText namelist_dep;
        //protected HtmlTextArea Notes;
        //protected HtmlGenericControl dvReadAttach;
        //protected Panel Attachword;
        //protected Repeater rpt;
		private int i = 1;
		private IList<PaperTypeInfo> li = new List<PaperTypeInfo>();
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
			this.TypeID.DataSource = this.li;
			this.TypeID.DataTextField = "Sh";
			this.TypeID.DataValueField = "ID";
			this.TypeID.DataBind();
			if (!string.IsNullOrEmpty(base.Request.QueryString["pid"]))
			{
				PaperInfo byId = Paper.Init().GetById(Convert.ToInt32(base.Request.QueryString["pid"]));
				this.TypeID.SelectedValue = string.Concat(byId.TypeID);
				this.PaperName.Value = byId.PaperName;
				this.Notes.Value = byId.Notes;
				this.SendDep.Value = byId.SendDep;
				this.PaperSymbol.Value = byId.PaperSymbol;
				this.PaperGrade.Value = byId.PaperGrade;
				this.PaperDate.Value = byId.PaperDate;
				if (byId.ShareDeps != "")
				{
					this.sel.SelectedIndex = 1;
					this.tr.Attributes["style"] = "";
					this.userlist_dep.Value = byId.ShareDeps;
					this.namelist_dep.Value = byId.namelist;
				}
				this.TypeID.SelectedValue = string.Concat(byId.TypeID);
				if (!string.IsNullOrEmpty(byId.FilePath) && byId.FilePath.Contains("|"))
				{
					this.Attachword.Visible = true;
					List<TmpInfo> list = new List<TmpInfo>();
					string[] array = byId.FilePath.Split(new char[]
					{
						'|'
					});
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i].Trim() != "")
						{
							TmpInfo tmpInfo = new TmpInfo();
							int num = array[i].LastIndexOf('/') + 1;
							string tmp = array[i].Substring(num, array[i].Length - num);
							string tmp2 = array[i].Replace("~", "");
							tmpInfo.Tmp1 = array[i];
							tmpInfo.Tmp2 = tmp;
							tmpInfo.Tmp3 = tmp2;
							list.Add(tmpInfo);
						}
					}
					this.rpt.DataSource = list;
					this.rpt.DataBind();
				}
			}
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["pid"]))
			{
				PaperInfo paperInfo = Paper.Init().GetById(Convert.ToInt32(base.Request.QueryString["pid"]));
				paperInfo.FilePath = this.UpdateFiles();
				paperInfo.PaperName = this.PaperName.Value;
				paperInfo.Notes = this.Notes.Value;
				paperInfo.SendDep = this.SendDep.Value;
				paperInfo.PaperSymbol = this.PaperSymbol.Value;
				paperInfo.PaperGrade = this.PaperGrade.Value;
				paperInfo.PaperDate = this.PaperDate.Value;
				paperInfo.ShareDeps = this.userlist_dep.Value.Trim();
				paperInfo.namelist = this.namelist_dep.Value;
				paperInfo.TypeID = Convert.ToInt32(base.Request.Form["TypeID"]);
				paperInfo.AddTime = DateTime.Now.ToString("yyyy-MM-dd");
				paperInfo.CreatorID = Convert.ToInt32(this.Uid);
				paperInfo.CreatorRealName = this.RealName;
				paperInfo.CreatorDepName = this.DepName;
				Paper.Init().Update(paperInfo);
			}
			else
			{
				PaperInfo paperInfo = new PaperInfo();
				paperInfo.FilePath = this.UpdateFiles();
				paperInfo.PaperName = this.PaperName.Value;
				paperInfo.Notes = this.Notes.Value;
				paperInfo.SendDep = this.SendDep.Value;
				paperInfo.PaperSymbol = this.PaperSymbol.Value;
				paperInfo.PaperGrade = this.PaperGrade.Value;
				paperInfo.PaperDate = this.PaperDate.Value;
				paperInfo.ShareDeps = this.userlist_dep.Value.Trim();
				paperInfo.namelist = this.namelist_dep.Value;
				paperInfo.TypeID = Convert.ToInt32(base.Request.Form["TypeID"]);
				paperInfo.AddTime = DateTime.Now.ToString("yyyy-MM-dd");
				paperInfo.CreatorID = Convert.ToInt32(this.Uid);
				paperInfo.CreatorRealName = this.RealName;
				paperInfo.CreatorDepName = this.DepName;
				Paper.Init().Add(paperInfo);
			}
			string str = HttpContext.Current.Server.HtmlEncode("您好!电子档案已编辑成功!");
			base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
		}
		private string UpdateFiles()
		{
			string text = "";
			HttpFileCollection files = HttpContext.Current.Request.Files;
			string text2 = DateTime.Now.ToString("yyMMdd");
			string text3 = base.Server.MapPath("~/Files/NewsFiles/");
			string str = "~/Files/NewsFiles/" + text2 + "/";
			text3 += text2;
			if (!Directory.Exists(text3))
			{
				FileSystemManager.CreateFolder(text2, base.Server.MapPath("~/Files/NewsFiles"));
			}
			try
			{
				string str2 = "";
				if (this.Attachword.Visible)
				{
					foreach (RepeaterItem repeaterItem in this.rpt.Items)
					{
						HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
						if (htmlInputCheckBox.Checked)
						{
							str2 = str2 + htmlInputCheckBox.Value + "|";
						}
					}
				}
				for (int i = 0; i < files.Count; i++)
				{
					HttpPostedFile httpPostedFile = files[i];
					if (Config.IsValidFile(httpPostedFile))
					{
						string fileName = Path.GetFileName(httpPostedFile.FileName);
						string str3 = str + fileName;
						string text4 = text3 + "\\" + fileName;
						if (File.Exists(text4))
						{
							string text5 = string.Concat(new object[]
							{
								DateTime.Now.ToString("HHmmssfff"),
								Utils.CreateRandomStr(5),
								this.Uid,
								i
							});
							text4 = string.Concat(new string[]
							{
								text3,
								"\\",
								text5,
								"@",
								Utils.GetFileExtension(fileName)
							});
							str3 = str + text5 + "@" + Utils.GetFileExtension(fileName);
						}
						httpPostedFile.SaveAs(text4);
						text = text + str3 + "|";
					}
				}
				text = str2 + text;
			}
			catch (IOException ex)
			{
				throw;
			}
			return text;
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
	}
