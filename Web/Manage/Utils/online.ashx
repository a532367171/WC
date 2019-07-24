<%@ WebHandler Language="C#" Class="online" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using WC.Model;

public class online : IHttpHandler {
    
   public void ProcessRequest(HttpContext context)
		{
			context.Response.Charset = "UTF-8";
			context.Response.Cache.SetNoStore();
			string format = "<a onclick=addTab('在线用户','../Manage/Common/User_OnLine.aspx','icon-usergroup') href='#'>在线用户：<strong>{0}</strong> 人</a>";
			IList<Sys_UserInfo> list = HttpContext.Current.Application["user_online"] as IList<Sys_UserInfo>;
			IList<Sys_UserInfo> list2 = new List<Sys_UserInfo>();
			foreach (object current in list)
			{
				Sys_UserInfo sys_UserInfo = current as Sys_UserInfo;
				if (sys_UserInfo.LastLoginTime.AddMinutes(60.0) < DateTime.Now)
				{
					sys_UserInfo.IsOnline = 0;
				}
				if (sys_UserInfo.IsOnline == 1)
				{
					list2.Add(sys_UserInfo);
				}
			}
			context.Response.Write(string.Format(format, list2.Count));
			context.Response.End();
		}
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}