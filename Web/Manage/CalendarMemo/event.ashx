<%@ WebHandler Language="C#" Class="limagan.cal._event" %>

using System;
using System.Web;
using System.Web.Services;
using WC.Model;
namespace limagan.cal
{
	[WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class _event : IHttpHandler
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
			string s = "";
			string text = context.Request.Params["action"];
			string text2 = context.Request.Params["sf"];
			if (text != null)
			{
				if (text.ToLower() == "create")
				{
					Calendars calendars = new Calendars();
					calendars.EID = this.RndNum(15);
					calendars.UID = context.Request.Params["src"];
					if (context.Request.Params["ctext"] == null && context.Request.Params["text"] == null)
					{
						calendars.EName = "";
					}
					else
					{
						if (context.Request.Params["ctext"] != null)
						{
							calendars.EName = context.Request.Params["ctext"].Replace("'", "’").Replace("\\", "＼").Replace("<", "〈").Replace(">", "〉").Replace("&", "＆");
						}
						else
						{
							calendars.EName = context.Request.Params["text"].Replace("'", "’").Replace("\\", "＼").Replace("<", "〈").Replace(">", "〉").Replace("&", "＆");
						}
					}
					string text3 = context.Request.Params["dates"];
					if (text3 != null)
					{
						string[] array = text3.Split(new char[]
						{
							'/'
						});
						calendars.STime = array[0];
						calendars.ETime = array[1];
					}
					calendars.CTime = context.Request.Params["eid"];
					string text4 = context.Request.Params["details"];
					if (text4 != null)
					{
						calendars.MEMO = text4.Replace("'", "’").Replace("\\", "＼").Replace("<", "〈").Replace(">", "〉").Replace("&", "＆");
					}
					else
					{
						calendars.MEMO = "";
					}
					calendars.LogicDelete = 0;
					calendars.MTime = DateTime.Now;
					string a = this.bgs.Insert<Calendars>(calendars);
					if (a == "1")
					{
						s = string.Concat(new string[]
						{
							"while(1);[['r','",
							calendars.CTime,
							"','",
							calendars.EID,
							"'],['a','",
							calendars.EID,
							"','",
							calendars.EName,
							"','",
							calendars.STime,
							"','",
							calendars.ETime,
							"','",
							calendars.UID,
							"',,,525573,,,0,'',null,,null,[126975,60,null,'',[],0,'DEFAULT']],['_RefreshCalendarWhenDisplayedNext'],['_Ping','500'],['_Ping','3000'],['_Ping','15000'],['_RefreshCalendarWhenDisplayedNext'],['_ShowMessageUndoable','工作日程已添加。']]"
						});
					}
				}
				else
				{
					if (text.ToLower() == "edit")
					{
						string text5 = context.Request.Params["src"];
						string eid = context.Request.Params["eid"];
						string mydates = context.Request.Params["dates"];
						string myename = context.Request.Params["text"];
						string mymemo = context.Request.Params["details"];
						Calendars my_lc01 = this.bgs.Find_Calendar_ByPara(text5, eid);
						if (my_lc01 != null)
						{
							string a = this.bgs.Update<Calendars>(my_lc01, delegate(Calendars t)
							{
								if (mydates != null)
								{
									string[] array2 = mydates.Split(new char[]
									{
										'/'
									});
									my_lc01.STime = array2[0];
									my_lc01.ETime = array2[1];
								}
								if (myename != null)
								{
									my_lc01.EName = myename.Replace("'", "’").Replace("\\", "＼").Replace("<", "〈").Replace(">", "〉").Replace("&", "＆");
								}
								if (mymemo != null)
								{
									my_lc01.MEMO = mymemo.Replace("'", "’").Replace("\\", "＼").Replace("<", "〈").Replace(">", "〉").Replace("&", "＆");
								}
								my_lc01.MTime = DateTime.Now;
							});
							if (a == "1")
							{
								s = string.Concat(new string[]
								{
									"while(1);[['a','",
									my_lc01.EID,
									"','",
									my_lc01.EName,
									"','",
									my_lc01.STime,
									"','",
									my_lc01.ETime,
									"','",
									my_lc01.UID,
									"',,,525573,,,0,'',null,,null,[126975,60,null,'',[],0,'DEFAULT']],['_RefreshCalendarWhenDisplayedNext'],['_Ping','500'],['_Ping','3000'],['_Ping','15000'],['_RefreshCalendarWhenDisplayedNext'],['_ShowMessageUndoable','您的工作日程已更新。']]"
								});
							}
							else
							{
								s = "while(1);[['_ShowMessageUndoable','更新失败1。']]";
							}
						}
						else
						{
							s = "while(1);[['_ShowMessageUndoable','更新失败2。']]";
						}
					}
				}
			}
			else
			{
				if (text2 != null)
				{
					string text6 = context.Request.Params["emid"];
					string text5 = context.Request.Params["src"];
					string eid = context.Request.Params["eid"];
					Calendars calendars = this.bgs.Find_Calendar_ByPara(text5, eid);
					if (calendars != null)
					{
						string text7 = "EDIT";
						string text8 = "editable";
						if (text6 == null)
						{
							text7 = "VIEW";
							text8 = "readonly";
						}
						string text9;
						if (calendars.STime.Length == 15)
						{
							text9 = string.Concat(new string[]
							{
								"\t<dates access=\"",
								text8,
								"\" editing=\"false\">\t\t<value>",
								calendars.STime,
								"/",
								calendars.ETime,
								"</value>\t\t<display>",
								calendars.STime.Substring(0, 4),
								"-",
								calendars.STime.Substring(4, 2),
								"-",
								calendars.STime.Substring(6, 2),
								" ",
								calendars.STime.Substring(9, 2),
								":",
								calendars.STime.Substring(11, 2),
								" - ",
								calendars.ETime.Substring(0, 4),
								"-",
								calendars.ETime.Substring(4, 2),
								"-",
								calendars.ETime.Substring(6, 2),
								" ",
								calendars.ETime.Substring(9, 2),
								":",
								calendars.ETime.Substring(11, 2),
								"</display>\t\t<start-date>",
								calendars.STime.Substring(0, 4),
								"-",
								calendars.STime.Substring(4, 2),
								"-",
								calendars.STime.Substring(6, 2),
								"</start-date>\t\t<start-time>",
								calendars.STime.Substring(9, 2),
								":",
								calendars.STime.Substring(11, 2),
								"</start-time>\t\t<end-date>",
								calendars.ETime.Substring(0, 4),
								"-",
								calendars.ETime.Substring(4, 2),
								"-",
								calendars.ETime.Substring(6, 2),
								"</end-date>\t\t<end-time>",
								calendars.ETime.Substring(9, 2),
								":",
								calendars.ETime.Substring(11, 2),
								"</end-time>\t</dates>"
							});
						}
						else
						{
							text9 = string.Concat(new string[]
							{
								"\t<dates access=\"",
								text8,
								"\" editing=\"false\">\t\t<value>",
								calendars.STime,
								"/",
								calendars.ETime,
								"</value>\t\t<display>",
								calendars.STime.Substring(0, 4),
								"-",
								calendars.STime.Substring(4, 2),
								"-",
								calendars.STime.Substring(6, 2),
								" - ",
								calendars.ETime.Substring(0, 4),
								"-",
								calendars.ETime.Substring(4, 2),
								"-",
								calendars.ETime.Substring(6, 2),
								"</display>\t\t<start-date>",
								calendars.STime.Substring(0, 4),
								"-",
								calendars.STime.Substring(4, 2),
								"-",
								calendars.STime.Substring(6, 2),
								"</start-date>\t\t<end-date>",
								calendars.ETime.Substring(0, 4),
								"-",
								calendars.ETime.Substring(4, 2),
								"-",
								calendars.ETime.Substring(6, 2),
								"</end-date>\t</dates>"
							});
						}
						s = string.Concat(new string[]
						{
							"<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\" ?><eventpage action=\"",
							text7,
							"\" simplified=\"true\" url=\"event?sf=true&amp;output=xml&amp;hl=zh_CN&amp;eid=",
							calendars.EID,
							"&amp;src=",
							calendars.UID,
							"\" access-level=\"60\" specialized=\"false\" has-overrides=\"false\" static-file-prefix=\"6a3eb8ba4a07edb76f79a18d6bdb8933\" lang=\"zh_CN\" current-action=\"VIEW\" can-respond=\"true\" can-add-self=\"false\">\t<features>\t\t<feature enabled=\"false\"/>\t\t<feature enabled=\"false\"/>\t\t<feature enabled=\"false\"/>\t\t<feature enabled=\"true\"/>\t\t<feature enabled=\"true\"/>\t\t<feature enabled=\"false\"/>\t\t<feature enabled=\"true\"/>\t\t<feature enabled=\"false\"/>\t\t<feature enabled=\"false\"/>\t\t<feature enabled=\"false\"/>\t\t<feature enabled=\"false\"/>\t\t<feature enabled=\"false\"/>\t\t<feature enabled=\"false\"/>\t\t<feature enabled=\"true\"/>\t\t<feature enabled=\"false\"/>\t\t<feature enabled=\"false\"/>\t\t<feature enabled=\"false\"/>\t\t<feature enabled=\"false\"/>\t\t<feature enabled=\"false\"/>\t</features>\t<ref-date>\t\t<value>",
							DateTime.Now.ToString("yyyyMMdd"),
							"</value>\t</ref-date>\t<eid>\t\t<value>",
							calendars.EID,
							"</value>\t</eid>\t<self is-signed-in=\"true\" allow-guest-modify-feature=\"true\" allow-invite-yourself-feature=\"false\" allow-alternate-calendar-feature=\"true\" allow-publish-dialog-feature=\"false\" has-weekends=\"true\">\t\t<principal id=\"",
							calendars.UID,
							"\" status=\"5\" type=\"0\">\t\t\t<value>1735787462@qq.com</value>\t\t\t<display>日程管理系统</display>\t\t\t<abbr>日程管理系统</abbr>\t\t</principal>\t</self>\t<secid><value>1234567890</value></secid>\t<summary access=\"",
							text8,
							"\" editing=\"false\"><html>",
							calendars.EName,
							"</html></summary>\t<attachments access=\"readonly\" editing=\"false\"></attachments>",
							text9,
							"\t<rrule access=\"readonly\" editing=\"false\" byday=\"WE\" interval=\"1\" wkst=\"MO\">\t\t<value></value>\t\t<display></display>\t</rrule>\t<timezone visible=\"false\">\t\t<value>Asia/Shanghai</value>\t\t<display>China - beijin</display>\t\t<abbr>CST</abbr>\t</timezone>\t<attendees access=\"readonly\" editing=\"false\"></attendees>\t<location access=\"readonly\" editing=\"false\"><value></value></location>\t<transparent access=\"readonly\" editing=\"false\"><value>false</value><display>busy</display></transparent>\t<class access=\"readonly\" editing=\"false\"><value>DEFAULT</value><display>default</display></class>\t<description access=\"",
							text8,
							"\" editing=\"false\"><html>",
							calendars.MEMO,
							"</html></description>\t<reminders access=\"readonly\" editing=\"true\" sms-verified=\"false\"><reminder method=\"3\" secs-lead=\"600\"></reminder></reminders>\t<creator>\t\t<principal id=\"",
							text5,
							"\" status=\"5\" type=\"0\">\t\t\t<value>1735787462@qq.com</value>\t\t</principal>\t</creator>\t<organizer>\t\t<principal id=\"",
							text5,
							"\" status=\"5\" type=\"0\">\t\t\t<value>1735787462@qq.com</value>\t\t</principal>\t</organizer>\t<source-calendar access=\"readonly\" editing=\"false\">\t\t<principal id=\"",
							text5,
							"\" status=\"5\" type=\"0\">\t\t\t<value>1735787462@qq.com</value>\t\t</principal>\t</source-calendar>\t<shared-property name=\"goo.allowInviteYourself\" access=\"readonly\" editing=\"true\"><value>false</value></shared-property>\t<shared-property name=\"goo.allowModify\" access=\"readonly\" editing=\"true\"><value>false</value></shared-property>\t<shared-property name=\"goo.allowInvitesOther\" access=\"readonly\" editing=\"true\">\t\t<value>true</value>\t</shared-property>\t<shared-property name=\"goo.allowComments\" access=\"readonly\" editing=\"true\"><value>true</value></shared-property>\t<shared-property name=\"goo.showInvitees\" access=\"readonly\" editing=\"true\"><value>true</value></shared-property>\t<calendars></calendars>\t<comments access=\"readonly\" editing=\"false\"></comments>\t<modules>\t\t<module module-id=\"4\"></module>\t\t<module module-id=\"6\"></module>\t\t<module module-id=\"8\"></module>\t</modules>\t<messages-to-user></messages-to-user></eventpage>"
						});
					}
					else
					{
						s = "while(1);[['_ShowMessageUndoable','获取信息失败，请稍候重试。']]";
					}
				}
			}
			if (context.Request.Params["output"] != null && context.Request.Params["output"].ToString().ToLower() == "xml")
			{
				context.Response.ContentType = "text/xml";
			}
			else
			{
				context.Response.ContentType = "text/javascript";
			}
			context.Response.Charset = "utf-8";
			context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
			context.Response.Expires = 0;
			context.Response.Write(s);
		}
		private string RndNum(int VcodeNum)
		{
			string text = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,h,e,l,l,o,h,i,l,l";
			string[] array = text.Split(new char[]
			{
				','
			});
			string text2 = "";
			Random random = new Random((int)DateTime.Now.Ticks);
			for (int i = 0; i < VcodeNum; i++)
			{
				text2 += array[random.Next(0, 61)];
			}
			return text2;
		}
	}
}
