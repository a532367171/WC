using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using WC.BLL;
using WC.DBUtility;
using WC.Tool;

public partial class Manage_Attend_DC : ViewPages

	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["type"]) && !string.IsNullOrEmpty(base.Request.QueryString["st"]))
			{
				string type = base.Request.QueryString["type"];
				string dateStr = base.Request.QueryString["st"];
				string dateStr2 = base.Request.QueryString["et"];
				if (Utils.IsDate(dateStr) && Utils.IsDate(dateStr2))
				{
					this.Todo(type);
				}
			}
		}
		private void Todo(string type)
		{
			if (type != null)
			{
				if (!(type == "1"))
				{
					if (!(type == "2"))
					{
						if (!(type == "3"))
						{
							if (type == "4")
							{
								this.td4();
							}
						}
						else
						{
							this.td3();
						}
					}
					else
					{
						this.td2();
					}
				}
				else
				{
					this.td1();
				}
			}
		}
		private void td1()
		{
			string str = base.Request.QueryString["type"];
			string text = " AttendType=" + str;
			string text2 = base.Request.QueryString["keywords"];
			string text3 = base.Request.QueryString["st"];
			string text4 = base.Request.QueryString["et"];
			string text5 = text;
			text = string.Concat(new string[]
			{
				text5,
				" and (addtime between '",
				text3,
				"' and '",
				text4,
				"') and ("
			});
			text5 = text;
			text = string.Concat(new string[]
			{
				text5,
				" RealName like '%",
				text2,
				"%' or DepName like '%",
				text2,
				"%' ) "
			});
			using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, "select * from Work_Attend where" + text, new SqlParameter[0]))
			{
				DataTable dataTable = dataSet.Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					try
					{
						StringWriter stringWriter = new StringWriter();
						stringWriter.WriteLine("人员姓名,考勤日期,考勤类别,考勤数据,备注 ");
						foreach (DataRow dataRow in dataTable.Rows)
						{
							StringBuilder stringBuilder = new StringBuilder();
							stringBuilder = this.AppendCSVFields(stringBuilder, string.Concat(dataRow["RealName"]));
							stringBuilder = this.AppendCSVFields(stringBuilder, Convert.ToDateTime(string.Concat(dataRow["AddTime"])).ToString("yyyy-MM-dd"));
                            //stringBuilder = this.AppendCSVFields(stringBuilder, dataRow["StandardNames"] + dataRow["StandardTimes"]);
                          //stringBuilder = this.AppendCSVFields(stringBuilder, dataRow["StandardNames"] & dataRow["StandardTimes"]);
                            stringBuilder = this.AppendCSVFields(stringBuilder, string.Concat(new object[]
							{
								dataRow["SignTimes"],
								" (",
								dataRow["SignJudge"],
								")"
							}));
							stringBuilder = this.AppendCSVFields(stringBuilder, string.Concat(dataRow["Notes"]));
							stringBuilder.Remove(stringBuilder.Length - 1, 1);
							stringWriter.WriteLine(stringBuilder.ToString());
						}
						DownloadFile(base.Response, stringWriter.GetStringBuilder(), "考勤" + text3 + ".csv");
						stringWriter.Close();
						base.Response.End();
						goto IL_2CE;
					}
					catch (Exception ex)
					{
						throw;
					}
				}
				base.Response.Write("<script>alert('没有任何数据');window.location='WorkList.aspx?type=1';</script>");
				IL_2CE:;
			}
		}
		private void td2()
		{
			string str = base.Request.QueryString["type"];
			string text = " AttendType=" + str;
			string text2 = base.Request.QueryString["keywords"];
			string text3 = base.Request.QueryString["st"];
			string text4 = base.Request.QueryString["et"];
			string text5 = text;
			text = string.Concat(new string[]
			{
				text5,
				" and (addtime between '",
				text3,
				"' and '",
				text4,
				"') and ("
			});
			text5 = text;
			text = string.Concat(new string[]
			{
				text5,
				" RealName like '%",
				text2,
				"%' or DepName like '%",
				text2,
				"%' ) "
			});
			using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, "select * from Work_Attend where" + text, new SqlParameter[0]))
			{
				DataTable dataTable = dataSet.Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					try
					{
						StringWriter stringWriter = new StringWriter();
						stringWriter.WriteLine("外出人,登记日期,开始时间,结束时间,备注 ");
						foreach (DataRow dataRow in dataTable.Rows)
						{
							StringBuilder stringBuilder = new StringBuilder();
							stringBuilder = this.AppendCSVFields(stringBuilder, string.Concat(dataRow["RealName"]));
							stringBuilder = this.AppendCSVFields(stringBuilder, Convert.ToDateTime(string.Concat(dataRow["AddTime"])).ToString("yyyy-MM-dd"));
							stringBuilder = this.AppendCSVFields(stringBuilder, string.Concat(new object[]
							{
								dataRow["BeginTime"],
								" ",
								dataRow["B1"],
								":",
								dataRow["B2"]
							}));
							stringBuilder = this.AppendCSVFields(stringBuilder, string.Concat(new object[]
							{
								dataRow["EndTime"],
								" ",
								dataRow["E1"],
								":",
								dataRow["E2"]
							}));
							stringBuilder = this.AppendCSVFields(stringBuilder, string.Concat(dataRow["Notes"]));
							stringBuilder.Remove(stringBuilder.Length - 1, 1);
							stringWriter.WriteLine(stringBuilder.ToString());
						}
						DownloadFile(base.Response, stringWriter.GetStringBuilder(), "外出" + text3 + ".csv");
						stringWriter.Close();
						base.Response.End();
						goto IL_312;
					}
					catch (Exception ex)
					{
						throw;
					}
				}
				base.Response.Write("<script>alert('没有任何数据');window.location='WorkList.aspx?type=1';</script>");
				IL_312:;
			}
		}
		private void td3()
		{
			string str = base.Request.QueryString["type"];
			string text = " AttendType=" + str;
			string text2 = base.Request.QueryString["keywords"];
			string text3 = base.Request.QueryString["st"];
			string text4 = base.Request.QueryString["et"];
			string text5 = text;
			text = string.Concat(new string[]
			{
				text5,
				" and (addtime between '",
				text3,
				"' and '",
				text4,
				"') and ("
			});
			text5 = text;
			text = string.Concat(new string[]
			{
				text5,
				" RealName like '%",
				text2,
				"%' or DepName like '%",
				text2,
				"%' ) "
			});
			using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, "select * from Work_Attend where" + text, new SqlParameter[0]))
			{
				DataTable dataTable = dataSet.Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					try
					{
						StringWriter stringWriter = new StringWriter();
						stringWriter.WriteLine("请假人,登记日期,开始时间,结束时间,备注 ");
						foreach (DataRow dataRow in dataTable.Rows)
						{
							StringBuilder stringBuilder = new StringBuilder();
							stringBuilder = this.AppendCSVFields(stringBuilder, string.Concat(dataRow["RealName"]));
							stringBuilder = this.AppendCSVFields(stringBuilder, Convert.ToDateTime(string.Concat(dataRow["AddTime"])).ToString("yyyy-MM-dd"));
							stringBuilder = this.AppendCSVFields(stringBuilder, string.Concat(new object[]
							{
								dataRow["BeginTime"],
								" ",
								dataRow["B1"],
								":",
								dataRow["B2"]
							}));
							stringBuilder = this.AppendCSVFields(stringBuilder, string.Concat(new object[]
							{
								dataRow["EndTime"],
								" ",
								dataRow["E1"],
								":",
								dataRow["E2"]
							}));
							stringBuilder = this.AppendCSVFields(stringBuilder, string.Concat(dataRow["Notes"]));
							stringBuilder.Remove(stringBuilder.Length - 1, 1);
							stringWriter.WriteLine(stringBuilder.ToString());
						}
						DownloadFile(base.Response, stringWriter.GetStringBuilder(), "请假" + text3 + ".csv");
						stringWriter.Close();
						base.Response.End();
						goto IL_312;
					}
					catch (Exception ex)
					{
						throw;
					}
				}
				base.Response.Write("<script>alert('没有任何数据');window.location='WorkList.aspx?type=1';</script>");
				IL_312:;
			}
		}
		private void td4()
		{
			string str = base.Request.QueryString["type"];
			string text = " AttendType=" + str;
			string text2 = base.Request.QueryString["keywords"];
			string text3 = base.Request.QueryString["st"];
			string text4 = base.Request.QueryString["et"];
			string text5 = text;
			text = string.Concat(new string[]
			{
				text5,
				" and (addtime between '",
				text3,
				"' and '",
				text4,
				"') and ("
			});
			text5 = text;
			text = string.Concat(new string[]
			{
				text5,
				" RealName like '%",
				text2,
				"%' or DepName like '%",
				text2,
				"%' ) "
			});
			using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, "select * from Work_Attend where" + text, new SqlParameter[0]))
			{
				DataTable dataTable = dataSet.Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					try
					{
						StringWriter stringWriter = new StringWriter();
						stringWriter.WriteLine("出差人,登记日期,出差地点,开始时间,结束时间,备注 ");
						foreach (DataRow dataRow in dataTable.Rows)
						{
							StringBuilder stringBuilder = new StringBuilder();
							stringBuilder = this.AppendCSVFields(stringBuilder, string.Concat(dataRow["RealName"]));
							stringBuilder = this.AppendCSVFields(stringBuilder, Convert.ToDateTime(string.Concat(dataRow["AddTime"])).ToString("yyyy-MM-dd"));
							stringBuilder = this.AppendCSVFields(stringBuilder, string.Concat(dataRow["TravelAddress"]));
							stringBuilder = this.AppendCSVFields(stringBuilder, string.Concat(new object[]
							{
								dataRow["BeginTime"],
								" ",
								dataRow["B1"],
								":",
								dataRow["B2"]
							}));
							stringBuilder = this.AppendCSVFields(stringBuilder, string.Concat(new object[]
							{
								dataRow["EndTime"],
								" ",
								dataRow["E1"],
								":",
								dataRow["E2"]
							}));
							stringBuilder = this.AppendCSVFields(stringBuilder, string.Concat(dataRow["Notes"]));
							stringBuilder.Remove(stringBuilder.Length - 1, 1);
							stringWriter.WriteLine(stringBuilder.ToString());
						}
						DownloadFile(base.Response, stringWriter.GetStringBuilder(), "出差" + text3 + ".csv");
						stringWriter.Close();
						base.Response.End();
						goto IL_32D;
					}
					catch (Exception ex)
					{
						throw;
					}
				}
				base.Response.Write("<script>alert('没有任何数据');window.location='WorkList.aspx?type=1';</script>");
				IL_32D:;
			}
		}
		private StringBuilder AppendCSVFields(StringBuilder argSource, string argFields)
		{
			return argSource.Append(argFields.Replace(",", " ").Trim()).Append(",");
		}
		public static void DownloadFile(HttpResponse argResp, StringBuilder argFileStream, string strFileName)
		{
			try
			{
				string value = "attachment; filename=" + Guid.NewGuid().ToString() + ".csv";
				if (!string.IsNullOrEmpty(strFileName))
				{
					value = "inline; filename=" + strFileName;
				}
				argResp.AppendHeader("Content-Disposition", value);
				argResp.ContentType = "application/ms-excel";
				argResp.ContentEncoding = Encoding.GetEncoding("GB2312");
				argResp.Write(argFileStream);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
