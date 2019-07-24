using System;
using System.Collections;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Mobile_Files_FileView : MobilePage

	{
		protected string fjs = "";
		protected string fj = "<span>{1}</span> &nbsp;&nbsp;&nbsp;&nbsp;<a href='/Manage/Utils/Download.aspx?destFileName={0}' ><img src='/img/mail_attachment.gif' />下载附件</a><br>";
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlGenericControl DocTitle5;
        //protected HtmlGenericControl Creator5;
        //protected HtmlGenericControl doctype5;
        //protected HtmlGenericControl AddTime5;
        //protected HtmlGenericControl IsShare5;
        //protected HtmlGenericControl Notes5;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["did"]))
			{
				this.Show(base.Request.QueryString["did"]);
			}
		}
		private void Show(string did)
		{
			Docs_DocInfo byId = Docs_Doc.Init().GetById(Convert.ToInt32(did));
			this.ViewState["di"] = byId;
			this.DocTitle5.InnerText = byId.DocTitle;
			this.Creator5.InnerText = byId.CreatorRealName + " (" + byId.CreatorDepName + ")";
			this.AddTime5.InnerText = Utils.ConvertDate2(byId.AddTime);
			this.Notes5.InnerText = byId.Notes;
			this.doctype5.InnerText = this.GetDocType(byId.DocTypeID);
			if (byId.IsShare == 0)
			{
				this.IsShare5.InnerText = "不共享";
			}
			else
			{
				this.IsShare5.InnerText = "已经共享";
			}
			if (!string.IsNullOrEmpty(byId.FilePath))
			{
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
		protected void SaveToMe(object sender, EventArgs e)
		{
			Docs_DocInfo docs_DocInfo = this.ViewState["di"] as Docs_DocInfo;
			Docs_DocInfo docs_DocInfo2 = new Docs_DocInfo();
			docs_DocInfo2.AddTime = DateTime.Now;
			docs_DocInfo2.CreatorDepName = this.DepName;
			docs_DocInfo2.CreatorID = Convert.ToInt32(this.Uid);
			docs_DocInfo2.CreatorRealName = this.RealName;
			docs_DocInfo2.DocTitle = "来自：[" + docs_DocInfo.CreatorRealName + "] " + docs_DocInfo.DocTitle;
			docs_DocInfo2.FilePath = docs_DocInfo.FilePath;
			docs_DocInfo2.Notes = docs_DocInfo.Notes;
			docs_DocInfo2.ShareUsers = "";
			docs_DocInfo2.IsShare = 0;
			Docs_Doc.Init().Add(docs_DocInfo2);
			base.Response.Write("<script>alert('您好!文档已保存成功!');window.location='" + base.Request.Url.AbsoluteUri + "'</script>");
		}
		protected string GetDocType(object DocTypeID)
		{
			string result;
			try
			{
				int num = Convert.ToInt32(DocTypeID);
				if (num == 0)
				{
					result = "默认分类";
				}
				else
				{
					IList all = Docs_DocType.Init().GetAll("id=" + num, null);
					if (all != null)
					{
						Docs_DocTypeInfo docs_DocTypeInfo = all[0] as Docs_DocTypeInfo;
						result = docs_DocTypeInfo.TypeName;
					}
					else
					{
						result = "";
					}
				}
			}
			catch
			{
				result = "默认分类";
			}
			return result;
		}
	}