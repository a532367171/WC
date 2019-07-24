using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using WC.Model;
public partial class Mobile_LoginOut : System.Web.UI.Page

	{
		protected void Page_Load(object sender, EventArgs e)
		{
			HttpCookie httpCookie = new HttpCookie("UserCookies");
			httpCookie.Expires = DateTime.Now.AddDays(-10.0);
			HttpContext.Current.Response.Cookies.Add(httpCookie);
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
			base.Response.Redirect("Login.aspx");
		}
	}

