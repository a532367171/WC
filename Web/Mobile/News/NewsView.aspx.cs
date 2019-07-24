using System;
using System.Collections;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Mobile_News_NewsView : MobilePage

	{
		protected string fjs = "";
		protected string fj = "<span>{1}</span> &nbsp;&nbsp;&nbsp;&nbsp;<a href='/Manage/Utils/Download.aspx?destFileName={0}' ><img src='/img/mail_attachment.gif' />下载</a><br>";
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlGenericControl NewsTitle;
        //protected HtmlGenericControl Creator;
        //protected HtmlGenericControl addtime;
        //protected HtmlGenericControl Notes;
        //protected HtmlGenericControl Deps;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["nid"]))
			{
				this.Show(base.Request.QueryString["nid"]);
			}
		}
		private void Show(string nid)
		{
			News_ArticleInfo byId = News_Article.Init().GetById(Convert.ToInt32(nid));
			if (this.Modules.Contains("29") || byId.ShareDeps.Trim() == "" || byId.ShareDeps.Contains("#" + this.DepID + "#"))
			{
				this.NewsTitle.InnerText = byId.NewsTitle;
				this.Creator.InnerText = byId.CreatorRealName;
				this.addtime.InnerText = Utils.ConvertDate5(byId.AddTime);
				byId.Notes = (byId.Notes ?? "");
				if (byId.Notes.ToLower().Contains("script"))
				{
					this.Notes.InnerHtml = byId.Notes.ToLower().Replace("script", "scrript");
				}
				else
				{
					this.Notes.InnerHtml = byId.Notes;
				}
				this.Page.Title = "标题：" + byId.NewsTitle;
				this.AddReadRecord(nid);
				if (byId.ShareDeps.Contains(","))
				{
					string text = "";
					string[] array = byId.ShareDeps.Split(new char[]
					{
						','
					});
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i].Contains("#"))
						{
							text = text + array[i].Split(new char[]
							{
								'#'
							})[0] + " ";
						}
					}
					this.Deps.InnerText = text;
				}
				else
				{
					this.Deps.InnerText = "全体人员";
				}
				if (!string.IsNullOrEmpty(byId.FilePath))
				{
					this.fjs = "";
					string[] array = byId.FilePath.Split(new char[]
					{
						'|'
					});
					for (int i = 0; i < array.Length; i++)
					{
						if (array[i].Trim() != "")
						{
							int num = array[i].LastIndexOf('/') + 1;
							string arg = array[i].Substring(num, array[i].Length - num);
							string s = array[i].Replace("~", "");
							this.fjs += string.Format(this.fj, base.Server.UrlEncode(s), arg);
						}
					}
				}
			}
			else
			{
				base.Response.Write("<script>alert('您没有查看权限');window.location='NewsList.aspx';</script>");
			}
		}
		private void AddReadRecord(string nid)
		{
			IList all = ZEX2.Init().GetAll("e1=" + nid + " and e2=" + this.Uid, null);
			if (all.Count == 0)
			{
				ZEX2Info zEX2Info = new ZEX2Info();
				zEX2Info.e1 = Convert.ToInt32(nid);
				zEX2Info.e2 = Convert.ToInt32(this.Uid);
				zEX2Info.e10 = DateTime.Now;
				zEX2Info.e5 = this.RealName;
				zEX2Info.e6 = this.DepName;
				ZEX2.Init().Add(zEX2Info);
			}
		}
	}