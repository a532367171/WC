using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;

public partial class Manage_Common_Memo_SubView : ViewPages

	{
        //protected HtmlForm form1;
        //protected Button Button1;
        //protected HtmlTextArea Bodys;
		protected string ct = "";
		protected string t = "";
		protected string uname = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["uid"]) && !string.IsNullOrEmpty(base.Request.QueryString["st"]))
			{
				this.Show(base.Request.QueryString["uid"], base.Request.QueryString["st"]);
			}
		}
		private void Show(string uid, string st)
		{
			Sys_UserInfo byId = Sys_User.Init().GetById(Convert.ToInt32(uid));
			this.t = this.GetDate(st);
			this.uname = byId.RealName + " (" + byId.DepName + ")";
			string text = this.ct;
			this.ct = string.Concat(new string[]
			{
				text,
				this.uname,
				" ",
				this.t,
				"\r\n\r\n"
			});
			if (byId.et6.Contains("#" + this.Uid + "#"))
			{
				int num = Convert.ToInt32(uid);
				Convert.ToInt32(st);
				string cmdText = string.Concat(new object[]
				{
					"select * from Calendar where uid='",
					num,
					"' and stime like '",
					st,
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
							this.ct = this.ct + "时间：" + this.GetTime(j) + "\r\n";
							object obj = this.ct;
							this.ct = string.Concat(new object[]
							{
								obj,
								"标题：",
								dataSet.Tables[0].Rows[i]["ename"],
								"\r\n"
							});
							obj = this.ct;
							this.ct = string.Concat(new object[]
							{
								obj,
								"详情：",
								dataSet.Tables[0].Rows[i]["memo"],
								"\r\n\r\n"
							});
						}
						else
						{
							text = this.ct;
							this.ct = string.Concat(new string[]
							{
								text,
								"时间：",
								this.GetTime(j),
								" 至 ",
								this.GetTime(j2),
								"\r\n"
							});
							object obj = this.ct;
							this.ct = string.Concat(new object[]
							{
								obj,
								"标题：",
								dataSet.Tables[0].Rows[i]["ename"],
								"\r\n"
							});
							obj = this.ct;
							this.ct = string.Concat(new object[]
							{
								obj,
								"详情：",
								dataSet.Tables[0].Rows[i]["memo"],
								"\r\n\r\n"
							});
						}
					}
					this.Bodys.Value = this.ct;
					return;
				}
			}
			base.Response.Write(string.Concat(new string[]
			{
				"<script>alert('您不是",
				byId.RealName,
				"(",
				byId.DepName,
				")的直接上级,无权查看他的工作日程');window.location='/manage/common/MyMemo.aspx'</script>"
			}));
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
		protected void Totxt_Btn(object sender, EventArgs e)
		{
			base.Response.Redirect("Memo_Download.aspx?uid=" + base.Request.QueryString["uid"] + "&st=" + base.Request.QueryString["st"]);
		}
	}
