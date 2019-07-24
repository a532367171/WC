using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;

public partial class Manage_CRM_CRM_Manage : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Button Button1;
        //protected HtmlInputText CRM_Name;
        //protected HtmlInputText Tel;
        //protected HtmlInputText Fax;
        //protected HtmlInputText Zip;
        //protected new HtmlInputText Site;
        //protected HtmlInputText QQ;
        //protected HtmlInputText Email;
        //protected HtmlInputText Address;
        //protected HtmlInputText MainPeople;
        //protected HtmlInputText Position;
        //protected HtmlInputText Product;
        //protected DropDownList TypeName;
        //protected RadioButtonList Grade;
        //protected HtmlSelect IsShare;
        //protected HtmlTableRow tr;
        //protected HtmlInputHidden userlist;
        //protected HtmlTextArea namelist;
        //protected HtmlTextArea Notes;
        //protected HtmlGenericControl dvReadAttach;
        //protected Panel Attachword;
        //protected Repeater rpt;
        //protected Button save_bt;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["cid"]))
			{
				this.Show(base.Request.QueryString["cid"]);
			}
		}
		private void Show(string cid)
		{
			if (!string.IsNullOrEmpty(cid))
			{
				CRMInfo byId = CRM.Init().GetById(Convert.ToInt32(cid));
				if (byId != null)
				{
					this.ViewState["ci"] = byId;
					this.CRM_Name.Value = byId.CRM_Name;
					this.Tel.Value = byId.Tel;
					this.Fax.Value = byId.Fax;
					this.Zip.Value = byId.Zip;
					this.Address.Value = byId.Address;
					this.MainPeople.Value = byId.MainPeople;
					this.Position.Value = byId.Position;
					this.Product.Value = byId.Product;
					this.TypeName.SelectedValue = byId.TypeName;
					this.Grade.SelectedValue = byId.Grade;
					this.QQ.Value = byId.QQ;
					this.Site.Value = byId.Site;
					this.Email.Value = byId.Email;
					if (byId.IsShare == 1)
					{
						this.IsShare.SelectedIndex = 1;
						this.tr.Attributes["style"] = "";
						this.userlist.Value = byId.ShareUsers;
						this.namelist.Value = byId.namelist;
					}
					this.Notes.Value = byId.Notes;
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
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["cid"]))
			{
				CRMInfo cRMInfo = this.ViewState["ci"] as CRMInfo;
				if (cRMInfo != null && cRMInfo.CreatorID == Convert.ToInt32(this.Uid))
				{
					cRMInfo.UpdateTime = DateTime.Now;
					cRMInfo.Address = this.Address.Value;
					cRMInfo.CRM_Name = this.CRM_Name.Value;
					cRMInfo.Fax = this.Fax.Value;
					cRMInfo.FilePath = this.UpdateFiles();
					cRMInfo.Grade = this.Grade.SelectedValue;
					cRMInfo.MainPeople = this.MainPeople.Value;
					cRMInfo.Notes = this.Notes.Value;
					cRMInfo.Position = this.Position.Value;
					cRMInfo.Product = this.Product.Value;
					cRMInfo.Tel = this.Tel.Value;
					cRMInfo.TypeName = this.TypeName.SelectedValue;
					cRMInfo.Zip = this.Zip.Value;
					cRMInfo.QQ = this.QQ.Value;
					cRMInfo.Site = this.Site.Value;
					cRMInfo.Email = this.Email.Value;
					if (this.IsShare.Value == "1")
					{
						cRMInfo.IsShare = 1;
						cRMInfo.namelist = this.namelist.Value;
						cRMInfo.ShareUsers = this.userlist.Value;
					}
					else
					{
						cRMInfo.IsShare = 0;
						cRMInfo.namelist = "";
						cRMInfo.ShareUsers = "";
					}
					CRM.Init().Update(cRMInfo);
					string cmdText = string.Concat(new object[]
					{
						"update CRM_Contact set CRM_Name='",
						cRMInfo.CRM_Name,
						"' where cid=",
						cRMInfo.id
					});
					MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
					string str = HttpContext.Current.Server.HtmlEncode("您好!客户信息已保存成功!");
					base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
				}
			}
			else
			{
				CRMInfo cRMInfo = new CRMInfo();
				cRMInfo.CreatorDepName = this.DepName;
				cRMInfo.CreatorRealName = this.RealName;
				cRMInfo.CreatorID = Convert.ToInt32(this.Uid);
				cRMInfo.AddTime = DateTime.Now;
				cRMInfo.UpdateTime = DateTime.Now;
				cRMInfo.Address = this.Address.Value;
				cRMInfo.CRM_Name = this.CRM_Name.Value;
				cRMInfo.Fax = this.Fax.Value;
				cRMInfo.FilePath = this.UpdateFiles();
				cRMInfo.Grade = this.Grade.SelectedValue;
				cRMInfo.MainPeople = this.MainPeople.Value;
				cRMInfo.Notes = this.Notes.Value;
				cRMInfo.Position = this.Position.Value;
				cRMInfo.Product = this.Product.Value;
				cRMInfo.Tel = this.Tel.Value;
				cRMInfo.TypeName = this.TypeName.SelectedValue;
				cRMInfo.Zip = this.Zip.Value;
				cRMInfo.QQ = this.QQ.Value;
				cRMInfo.Site = this.Site.Value;
				cRMInfo.Email = this.Email.Value;
				if (this.IsShare.Value == "1")
				{
					cRMInfo.IsShare = 1;
					cRMInfo.namelist = this.namelist.Value;
					cRMInfo.ShareUsers = this.userlist.Value;
				}
				else
				{
					cRMInfo.IsShare = 0;
					cRMInfo.namelist = "";
					cRMInfo.ShareUsers = "";
				}
				CRM.Init().Add(cRMInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!客户信息已添加成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
		}
		private string UpdateFiles()
		{
			string text = "";
			HttpFileCollection files = HttpContext.Current.Request.Files;
			string text2 = DateTime.Now.ToString("yyMMdd");
			string text3 = base.Server.MapPath("~/Files/CRMFiles/");
			string str = "~/Files/CRMFiles/" + text2 + "/";
			text3 += text2;
			if (!Directory.Exists(text3))
			{
				FileSystemManager.CreateFolder(text2, base.Server.MapPath("~/Files/CRMFiles"));
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
								Utils.CreateRandomStr(3),
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
	}
