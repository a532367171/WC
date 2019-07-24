using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;

public partial class Manage_Common_Memo_Download : ViewPages

	{
        //protected HtmlForm form1;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["uid"]) && !string.IsNullOrEmpty(base.Request.QueryString["st"]))
			{
				this.DownLoad();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["uid"]) && !string.IsNullOrEmpty(base.Request.QueryString["tt"]))
			{
				this.DownLoads();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["uid"]) && !string.IsNullOrEmpty(base.Request.QueryString["s"]) && !string.IsNullOrEmpty(base.Request.QueryString["e"]) && base.Request.QueryString["uid"] == this.Uid)
			{
				this.MyDownLoad(base.Request.QueryString["s"], base.Request.QueryString["e"]);
			}
		}
		private void DownLoad()
		{
			string text = "";
			int num = Convert.ToInt32(base.Request.QueryString["uid"]);
			int num2 = Convert.ToInt32(base.Request.QueryString["st"]);
			Sys_UserInfo byId = Sys_User.Init().GetById(num);
			string date = this.GetDate(num2);
			string text2 = byId.RealName + " (" + byId.DepName + ")\r\n\r\n";
			string text3 = text;
			text = string.Concat(new string[]
			{
				text3,
				text2,
				" ",
				date,
				"\r\n\r\n"
			});
			if (byId.et6.Contains("#" + this.Uid + "#"))
			{
				string cmdText = string.Concat(new object[]
				{
					"select * from Calendar where uid='",
					num,
					"' and stime like '",
					num2,
					"%' order by stime asc"
				});
				using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
				{
					for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
					{
						string j = string.Concat(dataSet.Tables[0].Rows[i]["stime"]);
						string j2 = string.Concat(dataSet.Tables[0].Rows[i]["etime"]);
						DateTime datetime = this.GetDatetime(j);
						DateTime datetime2 = this.GetDatetime(j2);
						if (Utils.GetDayOf2Date(datetime, datetime2) == 1)
						{
							text = text + "时间：" + this.GetTime(j) + "\r\n";
							object obj = text;
							text = string.Concat(new object[]
							{
								obj,
								"标题：",
								dataSet.Tables[0].Rows[i]["ename"],
								"\r\n"
							});
							obj = text;
							text = string.Concat(new object[]
							{
								obj,
								"详情：",
								dataSet.Tables[0].Rows[i]["memo"],
								"\r\n\r\n"
							});
						}
						else
						{
							text3 = text;
							text = string.Concat(new string[]
							{
								text3,
								"时间：",
								this.GetTime(j),
								" 至 ",
								this.GetTime(j2),
								"\r\n"
							});
							object obj = text;
							text = string.Concat(new object[]
							{
								obj,
								"标题：",
								dataSet.Tables[0].Rows[i]["ename"],
								"\r\n"
							});
							obj = text;
							text = string.Concat(new object[]
							{
								obj,
								"详情：",
								dataSet.Tables[0].Rows[i]["memo"],
								"\r\n\r\n"
							});
						}
					}
				}
				base.Response.Clear();
				base.Response.ClearHeaders();
				base.Response.Buffer = false;
				base.Response.AppendHeader("Content-Disposition", "attachment;filename=" + num2 + ".txt");
				base.Response.ContentType = "application/vnd.txt";
				base.Response.Write(text);
				base.Response.Flush();
				base.Response.End();
			}
			else
			{
				base.Response.Write(string.Concat(new string[]
				{
					"<script>alert('您不是",
					byId.RealName,
					"(",
					byId.DepName,
					")的直接上级,无权查看他的工作日程');window.location='/manage/common/MyMemo.aspx'</script>"
				}));
			}
		}
		private void MyDownLoad(string s, string e)
		{
			string text = "";
			string text2 = " ( ";
			int num = Convert.ToInt32(base.Request.QueryString["uid"]);
			Sys_UserInfo byId = Sys_User.Init().GetById(num);
			string text3 = text;
			text = string.Concat(new string[]
			{
				text3,
				byId.RealName,
				" (",
				byId.DepName,
				")\r\n\r\n"
			});
			text3 = text2;
			text2 = string.Concat(new string[]
			{
				text3,
				" substring(STime,1,8) between '",
				s,
				"' and '",
				e,
				"' )"
			});
			this.GetCT(num, ref text, text2);
			string str;
			if (s != e)
			{
				str = string.Concat(new string[]
				{
					this.UserName,
					"_",
					s,
					"to",
					e
				});
			}
			else
			{
				str = this.UserName + "_" + s;
			}
			base.Response.Clear();
			base.Response.ClearHeaders();
			base.Response.Buffer = false;
			base.Response.AppendHeader("Content-Disposition", "attachment;filename=" + str + ".txt");
			base.Response.ContentType = "application/vnd.txt";
			base.Response.Write(text);
			base.Response.Flush();
			base.Response.End();
		}
		private void DownLoads()
		{
			string text = "";
			string text2 = " ( ";
			string text3 = base.Request.QueryString["tt"];
			int num = Convert.ToInt32(base.Request.QueryString["uid"]);
			Sys_UserInfo byId = Sys_User.Init().GetById(num);
			string text4 = text;
			text = string.Concat(new string[]
			{
				text4,
				byId.RealName,
				" (",
				byId.DepName,
				")\r\n\r\n"
			});
			if (byId.et6.Contains("#" + this.Uid + "#") && text3.Contains(";"))
			{
				string[] array = text3.Split(new char[]
				{
					';'
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (!string.IsNullOrEmpty(array[i]))
					{
						if (i != array.Length - 2)
						{
							text2 = text2 + " stime like '" + array[i] + "%' or ";
						}
						else
						{
							text2 = text2 + " stime like '" + array[i] + "%' ) ";
						}
					}
				}
				this.GetCT(num, ref text, text2);
				base.Response.Clear();
				base.Response.ClearHeaders();
				base.Response.Buffer = false;
				base.Response.AppendHeader("Content-Disposition", "attachment;filename=CalendarReports.txt");
				base.Response.ContentType = "application/vnd.txt";
				base.Response.Write(text);
				base.Response.Flush();
				base.Response.End();
			}
			else
			{
				base.Response.Write(string.Concat(new string[]
				{
					"<script>alert('您不是",
					byId.RealName,
					"(",
					byId.DepName,
					")的直接上级,无权查看他的工作日程');window.location='/manage/common/MyMemo.aspx'</script>"
				}));
			}
		}
		private void GetCT(int u, ref string ct, string where)
		{
			string cmdText = string.Concat(new object[]
			{
				"select * from Calendar where uid='",
				u,
				"' and ",
				where,
				" order by stime asc"
			});
			using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
			{
				for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
				{
					string j = string.Concat(dataSet.Tables[0].Rows[i]["stime"]);
					string j2 = string.Concat(dataSet.Tables[0].Rows[i]["etime"]);
					DateTime datetime = this.GetDatetime(j);
					DateTime datetime2 = this.GetDatetime(j2);
					if (Utils.GetDayOf2Date(datetime, datetime2) == 1)
					{
						ct = ct + "时间：" + this.GetTime(j) + "\r\n";
						object obj = ct;
						ct = string.Concat(new object[]
						{
							obj,
							"标题：",
							dataSet.Tables[0].Rows[i]["ename"],
							"\r\n"
						});
						obj = ct;
						ct = string.Concat(new object[]
						{
							obj,
							"详情：",
							dataSet.Tables[0].Rows[i]["memo"],
							"\r\n\r\n"
						});
					}
					else
					{
						string text = ct;
						ct = string.Concat(new string[]
						{
							text,
							"时间：",
							this.GetTime(j),
							" 至 ",
							this.GetTime(j2),
							"\r\n"
						});
						object obj = ct;
						ct = string.Concat(new object[]
						{
							obj,
							"标题：",
							dataSet.Tables[0].Rows[i]["ename"],
							"\r\n"
						});
						obj = ct;
						ct = string.Concat(new object[]
						{
							obj,
							"详情：",
							dataSet.Tables[0].Rows[i]["memo"],
							"\r\n\r\n"
						});
					}
				}
			}
		}
		private string GetTime(string j)
		{
			string result;
			if (j.Contains("T"))
			{
				result = string.Concat(new string[]
				{
					j.Split(new char[]
					{
						'T'
					})[0].Substring(0, 4),
					"-",
					j.Split(new char[]
					{
						'T'
					})[0].Substring(4, 2),
					"-",
					j.Split(new char[]
					{
						'T'
					})[0].Substring(6, 2),
					" ",
					j.Split(new char[]
					{
						'T'
					})[1].Substring(0, 2),
					":",
					j.Split(new char[]
					{
						'T'
					})[1].Substring(2, 2)
				});
			}
			else
			{
				result = string.Concat(new string[]
				{
					j.Substring(0, 4),
					"-",
					j.Substring(4, 2),
					"-",
					j.Substring(6, 2)
				});
			}
			return result;
		}
		private DateTime GetDatetime(string j)
		{
			if (j.Contains("T"))
			{
				j = string.Concat(new string[]
				{
					j.Split(new char[]
					{
						'T'
					})[0].Substring(0, 4),
					"-",
					j.Split(new char[]
					{
						'T'
					})[0].Substring(4, 2),
					"-",
					j.Split(new char[]
					{
						'T'
					})[0].Substring(6, 2),
					" ",
					j.Split(new char[]
					{
						'T'
					})[1].Substring(0, 2),
					":",
					j.Split(new char[]
					{
						'T'
					})[1].Substring(2, 2)
				});
			}
			else
			{
				j = string.Concat(new string[]
				{
					j.Substring(0, 4),
					"-",
					j.Substring(4, 2),
					"-",
					j.Substring(6, 2)
				});
			}
			return Convert.ToDateTime(j);
		}
		protected string GetDate(object j)
		{
			string text = string.Concat(j);
			if (text.Length == 8 && Utils.IsNumber(text))
			{
				string a = string.Concat(new string[]
				{
					text.Substring(0, 4),
					"-",
					text.Substring(4, 2),
					"-",
					text.Substring(6, 2)
				});
				text = Utils.ConvertDate4(a);
			}
			return text;
		}
	}
