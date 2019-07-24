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
using WC.DK;

public partial class Manage_News_News_Manage : ModulePages
{
    

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Show();
			}
		}
		private void Show()
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["nid"]))
			{
				News_ArticleInfo byId = News_Article.Init().GetById(Convert.ToInt32(base.Request.QueryString["nid"]));
				this.NewsTitle.Value = byId.NewsTitle;
				this.Bodys.Value = byId.Notes;
				this.ComID.SelectedValue = string.Concat(byId.ComID);
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
			IList all = News_Type.Init().GetAll(null, null);
			this.TypeID.DataTextField = "TypeName";
			this.TypeID.DataValueField = "id";
			this.TypeID.DataSource = all;
			this.TypeID.DataBind();
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["nid"]))
			{
				News_ArticleInfo news_ArticleInfo = News_Article.Init().GetById(Convert.ToInt32(base.Request.QueryString["nid"]));
				news_ArticleInfo.FilePath = this.UpdateFiles();
				news_ArticleInfo.NewsTitle = this.NewsTitle.Value;
				news_ArticleInfo.Notes = this.Bodys.Value;
				news_ArticleInfo.ShareDeps = this.userlist_dep.Value.Trim();
				news_ArticleInfo.namelist = this.namelist_dep.Value;
				news_ArticleInfo.TypeID = Convert.ToInt32(base.Request.Form["TypeID"]);
				news_ArticleInfo.AddTime = DateTime.Now;
				news_ArticleInfo.ComID = Convert.ToInt32(this.ComID.SelectedValue);
				News_Article.Init().Update(news_ArticleInfo);
			}
			else
			{
				News_ArticleInfo news_ArticleInfo = new News_ArticleInfo();
				news_ArticleInfo.AddTime = DateTime.Now;
				news_ArticleInfo.CreatorDepName = this.DepName;
				news_ArticleInfo.CreatorID = Convert.ToInt32(this.Uid);
				news_ArticleInfo.CreatorRealName = this.RealName;
				news_ArticleInfo.FilePath = this.UpdateFiles();
				news_ArticleInfo.NewsTitle = this.NewsTitle.Value;
				news_ArticleInfo.Notes = this.Bodys.Value;
				news_ArticleInfo.ShareDeps = this.userlist_dep.Value.Trim();
				news_ArticleInfo.namelist = this.namelist_dep.Value;
				news_ArticleInfo.TypeID = Convert.ToInt32(base.Request.Form["TypeID"]);
				news_ArticleInfo.ComID = Convert.ToInt32(this.ComID.SelectedValue);
				News_Article.Init().Add(news_ArticleInfo);
				if (this.IsSms.Checked)
				{
					if (news_ArticleInfo.ShareDeps.Contains("#") && news_ArticleInfo.ShareDeps.Contains(","))
					{
						string[] array = news_ArticleInfo.ShareDeps.Split(new char[]
						{
							','
						});
						List<string> list = new List<string>();
						for (int i = 0; i < array.Length; i++)
						{
							if (array[i].Contains("#"))
							{
								string str = array[i].Split(new char[]
								{
									'#'
								})[1];
								IList all = Sys_User.Init().GetAll("depid=" + str, "id desc");
								foreach (object current in all)
								{
									Sys_UserInfo sys_UserInfo = current as Sys_UserInfo;
									if (Help.ValidateMobile(sys_UserInfo.Phone))
									{
										list.Add(sys_UserInfo.Phone);
									}
								}
							}
						}
						if (list.Count > 0)
						{
							Help.NewsMobleSend(list, news_ArticleInfo.NewsTitle);
						}
					}
					if (news_ArticleInfo.ShareDeps.Trim() == "")
					{
						IList all = Sys_User.Init().GetAll(null, "id desc");
						List<string> list = new List<string>();
						foreach (object current in all)
						{
							Sys_UserInfo sys_UserInfo = current as Sys_UserInfo;
							if (Help.ValidateMobile(sys_UserInfo.Phone))
							{
								list.Add(sys_UserInfo.Phone);
							}
						}
						if (list.Count > 0)
						{
							Help.NewsMobleSend(list, news_ArticleInfo.NewsTitle);
						}
					}
				}
			}
			string str2 = HttpContext.Current.Server.HtmlEncode("您好!资讯已保存成功!");
            string ssss = "~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str2;
			base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str2);
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

