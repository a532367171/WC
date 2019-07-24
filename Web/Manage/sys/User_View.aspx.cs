using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Manage_sys_User_View : ViewPages
{

		protected string fjs = "";
		protected string fj = "<span style='font-weight:bold;'>{1}</span> &nbsp;&nbsp;&nbsp;&nbsp;<a href='/Manage/Utils/Download.aspx?destFileName={0}' ><img src='/img/mail_attachment.gif' />下载档案</a><br>";
        //protected HtmlGenericControl UUserName5;
        //protected HtmlGenericControl URealName5;
        //protected HtmlGenericControl UDepName5;
        //protected Image PerPic;
        //protected HtmlGenericControl PositionName5;
        //protected HtmlGenericControl DirectSupervisor5;
        //protected HtmlGenericControl JoinTime5;
        //protected HtmlGenericControl Sex5;
        //protected HtmlGenericControl Birthday5;
        //protected HtmlGenericControl Phone5;
        //protected HtmlGenericControl Tel5;
        //protected HtmlGenericControl Email5;
        //protected HtmlGenericControl QQ5;
        //protected HtmlGenericControl HomeAddress5;
        //protected HtmlGenericControl Status5;
        //protected HtmlGenericControl MemoShare5;
        //protected HtmlGenericControl Notes5;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["uid"]))
			{
				this.Show(base.Request.QueryString["uid"]);
			}
			else
			{
				base.Response.Write("<script>alert('信息不存在!');window.close();</script>");
			}
		}
		private void Show(string uid)
		{
			Sys_UserInfo byId = Sys_User.Init().GetById(Convert.ToInt32(uid));
			this.URealName5.InnerText = byId.RealName;
			this.UDepName5.InnerText = byId.DepName;
			this.Sex5.InnerText = ((byId.Sex == 0) ? "男" : "女");
			this.Birthday5.InnerText = this.GetAges(byId.Birthday);
			this.Phone5.InnerText = byId.Phone;
			this.Tel5.InnerText = byId.Tel;
			this.Notes5.InnerText = byId.Notes;
			this.Status5.InnerText = ((byId.Status == 0) ? "在职" : "离职");
			this.MemoShare5.InnerText = ((byId.MemoShare == 0) ? "未启用 日程汇报" : "已启用 日程汇报");
			this.JoinTime5.InnerText = byId.JoinTime;
			this.DirectSupervisor5.InnerText = byId.et5;
			this.HomeAddress5.InnerText = byId.HomeAddress;
			this.PositionName5.InnerText = byId.PositionName;
			this.Email5.InnerText = byId.Email;
			this.QQ5.InnerText = byId.QQ;
			if (!string.IsNullOrEmpty(byId.PerPic) && Utils.FileExists(base.Server.MapPath("~/Files/common/" + byId.PerPic)))
			{
				this.PerPic.ImageUrl = "~/Files/common/" + byId.PerPic;
				this.PerPic.Attributes.Add("onclick", "window.open('" + this.PerPic.ImageUrl.Replace("~", "") + "','_blank')");
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["type"]) && !string.IsNullOrEmpty(byId.et4) && (this.Modules.Contains("19") || this.Modules.Contains("20")) && byId.et4.Contains("|"))
			{
				string[] array = byId.et4.Split(new char[]
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
		private string GetAges(object obj)
		{
			string result = "";
			if (obj != null && !string.IsNullOrEmpty(Convert.ToString(obj)))
			{
				result = " (" + Utils.GetAgeByDatetime(obj) + ")";
			}
			return result;
		}
	}
