using System;
using System.Collections;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Tool;

public partial class InfoTip_Operate_Reg : ViewPages

	{
		protected string times = "3";
        protected string url = "<a href=http://www.1job18.net target=_blank style='font-weight:bold;'>http://www.1job18.net</a>";
        //protected HtmlForm form1;
        //protected Panel pa;
        //protected HtmlGenericControl tip;
        //protected HtmlGenericControl lic;
        //protected HtmlGenericControl u;
        //protected HtmlGenericControl nt;
        //protected LinkButton lb;
		protected void Page_Load(object sender, EventArgs e)
		{
			Hashtable hashtable = (Hashtable)HttpContext.Current.Application["stand_config"];
			this.times = Convert.ToString(hashtable["infotip_refresh"]);
			this.u.InnerHtml = this.url;
			if (Utils.IsNumber(base.Request.QueryString["ns"] ?? ""))
			{
				this.pa.Visible = true;
				this.nt.InnerText = "4T-" + Config.Get111();
				int num = Convert.ToInt32(base.Request.QueryString["ns"]);
				this.tip.InnerText = "当前版本最大使用人数：" + num + "人";
				this.lic.InnerText = "当前系统的用户数已超过许可数量上限!";
			}
			else
			{
				if (!Config.Get333())
				{
					this.pa.Visible = true;
					this.nt.InnerText = "4T-" + Config.Get111();
					this.tip.InnerText = "永久免费版最大使用人数：30人";
					this.lic.InnerText = "您可以升级成更高级的软件版本!";
				}
				else
				{
					this.pa.Visible = false;
					base.Response.Write("<script>alert('您的系统已注册!授权永久无限制使用!感谢您的支持!');window.close();</script>");
				}
			}
		}
		protected void Reg_Click(object sender, EventArgs e)
		{
			string m = base.Request.Form["sn"];
			if (Config.Get222(m))
			{
				base.Response.Write("<script>alert('注册成功!授权永久无限制使用!感谢您的支持!');window.location='/default.aspx'</script>");
			}
			else
			{
				base.Response.Write("<script>alert('注册码错误!请重新输入注册码!');window.close();</script>");
			}
		}
	}
