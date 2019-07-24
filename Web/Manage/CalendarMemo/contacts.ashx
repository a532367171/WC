<%@ WebHandler Language="C#" Class="limagan.cal.contacts" %>

using System;
using System.Web;
using System.Web.Services;
namespace limagan.cal
{
	[WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class contacts : IHttpHandler
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
			context.Response.Charset = "UTF-8";
			context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
			context.Response.Expires = 0;
			string s = "";
			context.Response.Write(s);
		}
	}
}
