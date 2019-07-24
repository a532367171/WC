<%@ WebHandler Language="C#" Class="limagan.cal.user_prefs" %>

using System;
using System.Web;
using System.Web.Services;
namespace limagan.cal
{
	[WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class user_prefs : IHttpHandler
	{
		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/javascript";
			context.Response.Charset = "utf-8";
			context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
			context.Response.Expires = 0;
			string s = "";
			string text = context.Request.Params["eup"];
			if (text != null)
			{
				string[] array = text.Split(new char[]
				{
					':'
				});
				s = string.Concat(new string[]
				{
					"while(1);[['u',[['",
					array[0],
					"','",
					array[1],
					"']]],['_ShowMessageUndoable','点击单元格创建 新日程，双击单元格主题编辑 现有日程.']]"
				});
			}
			context.Response.Write(s);
		}
	}
}