<%@ WebHandler Language="C#" Class="limagan.cal.deleteevent" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using WC.Model;
using WC.BLL;
namespace limagan.cal
{
	[WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class deleteevent : IHttpHandler
	{
		private limaganDataDALs111 bgs = new limaganDataDALs111();
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
			context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
			context.Response.Expires = 0;
			string s = "";
			string text = context.Request.Params["src"];
			string text2 = context.Request.Params["eid"];
			string text3 = context.Request.Params["droi"];
			if (text != null && text2 != null && text3 != null)
			{
				try
				{
					text3.Split(new char[]
					{
						'/'
					});
					List<Calendars> list = this.bgs.Find_Calendar_ByPara_list(text, text2);
					if (list != null && list.Count > 0)
					{
						for (int i = 0; i < list.Count; i++)
						{
							string a = this.bgs.Delete<Calendars>(list[i]);
							if (a == "1")
							{
								s = "while(1);[['d','" + text2 + "'],['_ShowMessageUndoable','工作日程已删除'],['_RefreshCalendarWhenDisplayedNext'],['_Ping','500'],['_Ping','3000'],['_Ping','15000']]";
							}
						}
					}
					else
					{
						s = "while(1);[['d','" + text2 + "'],['_ShowMessageUndoable','工作日程已删除'],['_RefreshCalendarWhenDisplayedNext'],['_Ping','500'],['_Ping','3000'],['_Ping','15000']]";
					}
				}
				catch
				{
					s = "";
				}
			}
			context.Response.Write(s);
		}
	}
}
