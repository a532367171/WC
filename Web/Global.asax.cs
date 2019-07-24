using System;
using System.Collections.Generic;
using System.Web;
using WC.BLL;
using WC.Model;
using WC.DK;


public partial class Global : HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
            Admin_Help.UpdateApp();
            Help.SetDXBBSConn();
		}
		protected void Session_Start(object sender, EventArgs e)
		{
		}
		protected void Application_BeginRequest(object sender, EventArgs e)
		{
			if (base.Request.Url.AbsolutePath.ToLower().Contains(".config"))
			{
				base.Response.Redirect("Default.aspx");
			}
		}
		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{
		}
		protected void Application_Error(object sender, EventArgs e)
		{
			Exception lastError = base.Server.GetLastError();
			if (lastError is UnauthorizedAccessException)
			{
				base.Response.Redirect("~/Install/qx.htm");
			}
		}
		protected void Session_End(object sender, EventArgs e)
		{
			List<Sys_UserInfo> list = base.Application["user_online"] as List<Sys_UserInfo>;
			foreach (Sys_UserInfo current in list)
			{
				if (current.LastLoginTime.AddMinutes(60.0) < DateTime.Now)
				{
					current.IsOnline = 0;
				}
			}
		}
		protected void Application_End(object sender, EventArgs e)
		{
		}
	}
