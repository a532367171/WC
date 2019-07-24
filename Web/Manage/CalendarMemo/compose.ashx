<%@ WebHandler Language="C#" Class="limagan.cal.compose" %>

using System;
using System.Web;
using System.Web.Services;
namespace limagan.cal
{
	[WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class compose : IHttpHandler
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
			context.Response.Write("");
		}
	}
}
