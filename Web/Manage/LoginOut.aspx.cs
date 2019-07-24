using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using WC.Model;

public partial class Manage_LoginOut : Page
{


		protected void Page_Load(object sender, EventArgs e)
		{
			HttpCookie cookie = new HttpCookie("UserCookies");
			HttpContext.Current.Response.AppendCookie(cookie);
			HttpCookie cookie2 = new HttpCookie("DXBBS");
			HttpContext.Current.Response.AppendCookie(cookie2);
			if (!string.IsNullOrEmpty(string.Concat(HttpContext.Current.Session["UserCookies"])))
			{
				string text = string.Concat(HttpContext.Current.Session["UserCookies"]);
				if (text.Contains("|"))
				{
					string Uid = text.Split(new char[]
					{
						'|'
					})[0];
					List<Sys_UserInfo> list = base.Application["user_online"] as List<Sys_UserInfo>;
					list.Find(delegate(Sys_UserInfo s)
					{
						bool result;
						if (s.id.ToString() == Uid)
						{
							s.IsOnline = 0;
							result = true;
						}
						else
						{
							result = false;
						}
						return result;
					});
				}
			}
			HttpContext.Current.Session.Abandon();
			HttpCookie httpCookie = new HttpCookie("Lesktop", "");
			httpCookie.Expires = DateTime.Now.AddDays(-7.0);
			HttpContext.Current.Response.Cookies.Add(httpCookie);
			if (!string.IsNullOrEmpty(base.Request.QueryString["action"]))
			{
				base.Response.Write("<script>if(window.parent !=null){ alert('您已安全注销，退出本系统！'); window.parent.location='Login.aspx';  } </script>");
			}
			else
			{
				base.Response.Redirect("Login.aspx");
			}
		}
	}

