<%@ WebHandler Language="C#" Class="limagan.cal.load" %>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using WC.Model;
using WC.BLL;

namespace limagan.cal
{
	[WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	public class load : IHttpHandler
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
			context.Response.Charset = "utf-8";
			context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
			context.Response.Expires = 0;
			string text = "";
			string text2 = context.Request.Params["emf"];
			string[] array = text2.Split(new char[]
			{
				'\n'
			});
			int num = 0;
			string text3 = context.Request.Params["lef"];
			if (text3 == null)
			{
				num = 1;
			}
			Hashtable hashtable = new Hashtable();
			string text4 = "";
			string text5 = "";
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					' '
				});
				string[] array3 = array2[1].Split(new char[]
				{
					'/'
				});
				if (text4 == "")
				{
					text4 = array3[0];
				}
				if (text5 == "")
				{
					text5 = array3[1];
				}
				if (Convert.ToDateTime(string.Format("{0:0000-00-00}", Convert.ToInt32(array3[0]))) < Convert.ToDateTime(string.Format("{0:0000-00-00}", Convert.ToInt32(text4))))
				{
					text4 = array3[0];
				}
				if (Convert.ToDateTime(string.Format("{0:0000-00-00}", Convert.ToInt32(array3[1]))) > Convert.ToDateTime(string.Format("{0:0000-00-00}", Convert.ToInt32(text5))))
				{
					text5 = array3[1];
				}
				if (array2[2] == "0")
				{
					string[] value = new string[]
					{
						array2[0],
						array3[0],
						array3[1]
					};
					arrayList.Add(value);
				}
				else
				{
					if (num == 1)
					{
						string[] value = new string[]
						{
							array2[0],
							array2[2]
						};
						arrayList2.Add(value);
					}
				}
				if (!hashtable.Contains(array2[0]))
				{
					hashtable.Add(array2[0], array2[0]);
				}
			}
			ArrayList arrayList3 = new ArrayList(hashtable.Keys);
			if (arrayList3.Count > 0)
			{
				string text6 = "";
				string text7 = "";
				string[] array4 = new string[arrayList3.Count];
				for (int j = 0; j < arrayList3.Count; j++)
				{
					array4[j] = arrayList3[j].ToString();
					string text8 = text7;
					text7 = string.Concat(new string[]
					{
						text8,
						"b",
						j.ToString(),
						"='",
						arrayList3[j].ToString(),
						"',"
					});
				}
				text7 += "bf='',n=525573";
				text = "while(1);(function(){var a = 'a',d = 'd', " + text7 + ";return [";
				if (arrayList.Count > 0)
				{
					string[] array5 = new string[arrayList.Count];
					string[] array6 = new string[arrayList.Count];
					string[] array7 = new string[arrayList.Count];
					for (int j = 0; j < arrayList.Count; j++)
					{
						array5[j] = ((string[])arrayList[j])[0];
						array6[j] = ((string[])arrayList[j])[1];
						array7[j] = ((string[])arrayList[j])[2];
					}
					List<Calendars> list = new List<Calendars>();
					list = this.bgs.Find_Calendar_List_ByUID_and_TIME(array5, array6, array7, 0, 1189);
					if (list != null && list.Count > 0)
					{
						string text9 = "a";
						string text10 = "bf";
                        //int i = 0;
                        //IL_519:
                        //while (i < list.Count)
                        //{
                        //    for (int k = 0; k < array4.Length; k++)
                        //    {
                        //        if (array4[k] == list[i].UID)
                        //        {
                        //            text10 = "b" + k;
                        //        IL_45A:
                        //            string text8 = text;
                        //            text = string.Concat(new string[]
                        //            {
                        //                text8,
                        //                "[",
                        //                text9,
                        //                ",'",
                        //                list[i].EID,
                        //                "','",
                        //                list[i].EName,
                        //                "','",
                        //                list[i].STime,
                        //                "','",
                        //                list[i].ETime,
                        //                "',",
                        //                text10,
                        //                ",,,n],"
                        //            });
                        //            text10 = "bf";
                        //            i++;
                        //            goto IL_519;
                        //        }
                        //    }
                        //    goto IL_45A;
                        //}

                        for (int N = 0; N < list.Count; N++)
                        {
                            for (int k = 0; k < array4.Length; k++)
                            {
                                if (array4[k] == list[N].UID)
                                {
                                    text10 = "b" + k;
                                    string text8 = text;
                                    text = string.Concat(new string[]
									{
										text8,
										"[",
										text9,
										",'",
										list[N].EID,
										"','",
										list[N].EName,
										"','",
										list[N].STime,
										"','",
										list[N].ETime,
										"',",
										text10,
										",,,n],"
									});
                                    text10 = "bf";
                                }
                            }

                        }
                        
                        
                        
                        
                        
                        
                    }
				}
				else
				{
					if (arrayList2.Count > 0)
					{
						string[] array5 = new string[arrayList2.Count];
						string[] array8 = new string[arrayList2.Count];
						for (int j = 0; j < arrayList2.Count; j++)
						{
							array5[j] = ((string[])arrayList2[j])[0];
							array8[j] = ((string[])arrayList2[j])[1];
						}
						List<Calendars> list = new List<Calendars>();
						list = this.bgs.Find_Calendar_List_ByUID_and_TIME(array5, array8, 0, 500);
						if (list != null && list.Count > 0)
						{
							string text9 = "a";
							string text10 = "bf";
                            //IL_72D:
                            //while (i < list.Count)
                            //{
                            //    for (int k = 0; k < array4.Length; k++)
                            //    {
                            //        if (array4[k] == list[i].UID)
                            //        {
                            //            text10 = "b" + k;
                            //            IL_632:
                            //            if (list[i].LogicDelete == 0)
                            //            {
                            //                text9 = "a";
                            //            }
                            //            else
                            //            {
                            //                if (list[i].LogicDelete == -1)
                            //                {
                            //                    text9 = "d";
                            //                }
                            //            }
                            //            string text8 = text;
                            //            text = string.Concat(new string[]
                            //            {
                            //                text8,
                            //                "[",
                            //                text9,
                            //                ",'",
                            //                list[i].EID,
                            //                "','",
                            //                list[i].EName,
                            //                "','",
                            //                list[i].STime,
                            //                "','",
                            //                list[i].ETime,
                            //                "',",
                            //                text10,
                            //                ",,,n],"
                            //            });
                            //            text10 = "bf";
                            //            i++;
                            //            goto IL_72D;
                            //        }
                            //    }
                            //    goto IL_632;
                            //}
                            for (int i1 = 0; i1 < list.Count; i1++)
                            {
                                for (int k = 0; k < array4.Length; k++)
                                {
                                    if (array4[k] == list[i1].UID)
                                    {
                                        text10 = "b" + k;
                                        if (list[i1].LogicDelete == 0)
                                        {
                                            text9 = "a";
                                        }
                                        else
                                        {
                                            if (list[i1].LogicDelete == -1)
                                            {
                                                text9 = "d";
                                            }
                                        }
                                        string text8 = text;
                                        text = string.Concat(new string[]
										{
											text8,
											"[",
											text9,
											",'",
											list[i1].EID,
											"','",
											list[i1].EName,
											"','",
											list[i1].STime,
											"','",
											list[i1].ETime,
											"',",
											text10,
											",,,n],"
										});
                                        text10 = "bf";

                                    }
                                }
                            }
                            
                            
                            
                            
                            
						}
					}
				}
				for (int j = 0; j < arrayList3.Count; j++)
				{
					string text11 = Convert.ToInt64(DateTime.Now.Subtract(new DateTime(1, 1, 1, 0, 0, 0)).TotalSeconds).ToString();
					if (j + 1 == arrayList3.Count)
					{
						text6 = string.Concat(new string[]
						{
							text6,
							arrayList3[j].ToString(),
							" ",
							text4,
							"/",
							text5,
							" ",
							text11
						});
					}
					else
					{
						text6 = string.Concat(new string[]
						{
							text6,
							arrayList3[j].ToString(),
							" ",
							text4,
							"/",
							text5,
							" ",
							text11,
							"\\n"
						});
					}
				}
				text6 = text6.Substring(0, text6.Length);
				text = text + "['us','" + text6 + "'],['_RefreshCalendarWhenDisplayedNext']]})()";
			}
			context.Response.Write(text);
		}
	}
}