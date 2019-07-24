using System;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Manage_Paper_PaperView : ViewPages

	{
        //protected HtmlForm form1;
        //protected HtmlGenericControl PaperName;
        //protected HtmlGenericControl TypeName;
        //protected HtmlGenericControl PaperDate;
        //protected HtmlGenericControl SendDep;
        //protected HtmlGenericControl PaperSymbol;
        //protected HtmlGenericControl PaperGrade;
        //protected HtmlGenericControl namelist_dep;
        //protected HtmlGenericControl Notes;
		protected string pid = "";
		protected string fjs = "";
		protected string fj = "<span style='font-weight:bold;'>{1}</span> &nbsp;&nbsp;&nbsp;&nbsp;<a href='../../Manage/Paper/Download.aspx?destFileName={0}&pid={2}' ><img src='/img/mail_attachment.gif' />下载附件</a><br>";
		protected string docfj = "<span style='font-weight:bold;'>{1}</span> &nbsp;&nbsp;&nbsp;&nbsp;<a href='../../Manage/Paper/Download.aspx?destFileName={0}&pid={2}' ><img src='/img/mail_attachment.gif' />下载附件</a> &nbsp;&nbsp;";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["pid"]))
			{
				this.pid = base.Request.QueryString["pid"];
				this.Show(this.pid);
			}
		}
		private void Show(string pid)
		{
			PaperInfo byId = Paper.Init().GetById(Convert.ToInt32(pid));
			PaperTypeInfo byId2 = PaperType.Init().GetById(byId.TypeID);
			if (byId.ShareDeps.Trim() == "" || byId.ShareDeps.Contains("#" + this.DepID + "#") || byId.CreatorID == Convert.ToInt32(this.Uid) || this.Modules.Contains("53"))
			{
				this.TypeName.InnerText = "[" + byId2.TypeName + "] ";
				this.PaperName.InnerText = byId.PaperName;
				try
				{
					this.PaperDate.InnerText = byId.PaperDate + " (" + Utils.ConvertDate4(Convert.ToDateTime(string.Concat(new string[]
					{
						byId.PaperDate.Substring(0, 4),
						"-",
						byId.PaperDate.Substring(4, 2),
						"-",
						byId.PaperDate.Substring(6, 2)
					}))) + ")";
				}
				catch
				{
					this.PaperDate.InnerText = "错误的日期格式！";
				}
				this.SendDep.InnerText = byId.SendDep;
				this.PaperSymbol.InnerText = byId.PaperSymbol;
				this.PaperGrade.InnerText = byId.PaperGrade;
				this.Notes.InnerText = byId.Notes;
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
					this.namelist_dep.InnerText = text;
				}
				else
				{
					this.namelist_dep.InnerText = "全体人员";
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
							this.fjs += string.Format(this.fj, base.Server.UrlEncode(s), arg, pid);
						}
					}
				}
			}
			else
			{
				base.Response.Write("<script>alert('您没有查看权限');</script>");
			}
		}
	}
