using System;
using System.Collections;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Manage_News_News_View : ViewPages
{

		protected string fjs = "";
		protected string fj = "<span style='font-weight:bold;'>{1}</span> &nbsp;&nbsp;&nbsp;&nbsp;<a href='/Manage/Utils/Download.aspx?destFileName={0}' ><img src='/img/mail_attachment.gif' />下载附件</a><br>";
		protected string news_menu = "";
		private string news_tmp = "<a href='/Manage/News/News_List.aspx?tid={0}' >{1}</a>";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["nid"]))
			{
				this.Show(base.Request.QueryString["nid"]);
			}
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			string text = base.Request.Form["keyword"];
			string str = "?keywords=" + HttpContext.Current.Server.HtmlEncode(text.Trim());
			base.Response.Redirect("News_List.aspx" + str);
		}
		private void Show(string nid)
		{
			IList all = News_Type.Init().GetAll(null, " order by orders asc");
			News_ArticleInfo byId = News_Article.Init().GetById(Convert.ToInt32(nid));
			if (this.Modules.Contains("29") || byId.ShareDeps.Trim() == "" || byId.ShareDeps.Contains("#" + this.DepID + "#"))
			{
				this.NewsTitle.InnerText = byId.NewsTitle;
				this.Creator.InnerText = byId.CreatorRealName + " (" + byId.CreatorDepName + ")";
				this.addtime.InnerText = Utils.ConvertDate2(byId.AddTime);
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
					this.fjs = "<span style='font-weight:bold; color:Black;'>相关文件</span>：<br>";
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
				base.Response.Write("<script>alert('您没有查看权限');window.location='../News/News_List.aspx';</script>");
			}
			string text2 = "我的资讯：";
			for (int i = 0; i < all.Count; i++)
			{
				News_TypeInfo news_TypeInfo = all[i] as News_TypeInfo;
				this.news_menu += string.Format(this.news_tmp, news_TypeInfo.id, news_TypeInfo.TypeName);
				string text3 = "&nbsp;|&nbsp;";
				if (i == all.Count - 1)
				{
					text3 = "";
				}
				if (news_TypeInfo.id == byId.TypeID)
				{
					string text4 = text2;
					text2 = string.Concat(new string[]
					{
						text4,
						"<span style='color:#ff0000;'>",
						news_TypeInfo.TypeName,
						"</span>",
						text3
					});
				}
				else
				{
					text2 = text2 + news_TypeInfo.TypeName + text3;
				}
			}
			this.top.InnerHtml = text2;
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
