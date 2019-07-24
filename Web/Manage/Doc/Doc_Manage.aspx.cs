using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Manage_Doc_Doc_Manage : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Button Button1;
        //protected HtmlInputText DocTitle;
        //protected DropDownList doctype;
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
			if (!base.IsPostBack)
			{
				IList all = Docs_DocType.Init().GetAll("uid=" + this.Uid, null);
				this.doctype.Items.Add(new ListItem("默认分类", "0"));
				foreach (object current in all)
				{
					Docs_DocTypeInfo docs_DocTypeInfo = current as Docs_DocTypeInfo;
					this.doctype.Items.Add(new ListItem(docs_DocTypeInfo.TypeName, string.Concat(docs_DocTypeInfo.id)));
				}
			}
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["did"]))
			{
				this.Show(base.Request.QueryString["did"]);
			}
		}
		private void Show(string did)
		{
			if (!string.IsNullOrEmpty(did))
			{
				Docs_DocInfo byId = Docs_Doc.Init().GetById(Convert.ToInt32(did));
				this.ViewState["di"] = byId;
				this.DocTitle.Value = byId.DocTitle;
				this.Notes.Value = byId.Notes;
				try
				{
					this.doctype.SelectedValue = string.Concat(byId.DocTypeID);
				}
				catch
				{
					this.doctype.SelectedValue = "0";
				}
				if (byId.IsShare == 1)
				{
					this.IsShare.SelectedIndex = 1;
					this.tr.Attributes["style"] = "";
					this.userlist.Value = byId.ShareUsers;
					this.namelist.Value = byId.namelist;
				}
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
			HttpFileCollection files = HttpContext.Current.Request.Files;
			int num = 1;
			for (int i = 0; i < files.Count; i++)
			{
				HttpPostedFile f = files[i];
				if (Config.IsValidFile(f))
				{
					num++;
				}
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["did"]))
			{
				Docs_DocInfo docs_DocInfo = this.ViewState["di"] as Docs_DocInfo;
				docs_DocInfo.DocTitle = this.DocTitle.Value;
				docs_DocInfo.FilePath = this.UpdateFiles();
				docs_DocInfo.Notes = this.Notes.Value;
				docs_DocInfo.DocTypeID = Convert.ToInt32(base.Request.Form["doctype"]);
				if (this.IsShare.Value == "1")
				{
					docs_DocInfo.IsShare = 1;
					docs_DocInfo.namelist = this.namelist.Value;
					docs_DocInfo.ShareUsers = this.userlist.Value;
				}
				else
				{
					docs_DocInfo.IsShare = 0;
					docs_DocInfo.namelist = "";
					docs_DocInfo.ShareUsers = "";
				}
				Docs_Doc.Init().Update(docs_DocInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!文档已保存成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
			else
			{
				if (num != 0)
				{
					Docs_DocInfo docs_DocInfo = new Docs_DocInfo();
					docs_DocInfo.AddTime = DateTime.Now;
					docs_DocInfo.CreatorDepName = this.DepName;
					docs_DocInfo.CreatorID = Convert.ToInt32(this.Uid);
					docs_DocInfo.CreatorRealName = this.RealName;
					docs_DocInfo.DocTitle = this.DocTitle.Value;
					docs_DocInfo.FilePath = this.UpdateFiles();
					docs_DocInfo.Notes = this.Notes.Value;
					docs_DocInfo.DocTypeID = Convert.ToInt32(base.Request.Form["doctype"]);
					if (this.IsShare.Value == "1")
					{
						docs_DocInfo.IsShare = 1;
						docs_DocInfo.namelist = this.namelist.Value;
						docs_DocInfo.ShareUsers = this.userlist.Value;
					}
					else
					{
						docs_DocInfo.IsShare = 0;
						docs_DocInfo.namelist = "";
						docs_DocInfo.ShareUsers = "";
					}
					Docs_Doc.Init().Add(docs_DocInfo);
					string str = HttpContext.Current.Server.HtmlEncode("您好!文档已保存成功!");
					base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
				}
				else
				{
					base.Response.Write("<script>alert('您还没上传任何文件');window.location='" + base.Request.Url.AbsoluteUri + "'</script>");
				}
			}
		}
		private string UpdateFiles()
		{
			string text = "";
			HttpFileCollection files = HttpContext.Current.Request.Files;
			string text2 = DateTime.Now.ToString("yyMMdd");
			string text3 = base.Server.MapPath("~/Files/DocsFiles/");
			string str = "~/Files/DocsFiles/" + text2 + "/";
			text3 += text2;
			if (!Directory.Exists(text3))
			{
				FileSystemManager.CreateFolder(text2, base.Server.MapPath("~/Files/DocsFiles"));
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
