using System;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;

public partial class Manage_Attend_WorkAttendList : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected DropDownList AttendType;
        //protected HtmlInputText BeginTime_S;
        //protected HtmlInputText EndTime_S;
        //protected Panel list1;
        //protected Repeater rpt1;
        //protected HtmlGenericControl num1;
        //protected Page Page1;
        //protected Panel list2;
        //protected Repeater rpt2;
        //protected HtmlGenericControl num2;
        //protected Page Page2;
        //protected Panel list3;
        //protected Repeater rpt3;
        //protected HtmlGenericControl num3;
        //protected Page Page3;
        //protected Panel list4;
        //protected Repeater rpt4;
        //protected HtmlGenericControl num4;
        //protected Page Page4;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["type"]))
			{
				this.Show(base.Request.QueryString["type"]);
			}
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			string selectedValue = this.AttendType.SelectedValue;
			string text = HttpContext.Current.Server.HtmlEncode(base.Request.Form["BeginTime_S"].Trim());
			string text2 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["EndTime_S"].Trim());
			string str = string.Concat(new string[]
			{
				"?type=",
				selectedValue,
				"&st=",
				text,
				"&et=",
				text2
			});
			base.Response.Redirect("WorkAttendList.aspx" + str);
		}
		private void Show(string t)
		{
			if (t != null)
			{
				if (!(t == "1"))
				{
					if (!(t == "2"))
					{
						if (!(t == "3"))
						{
							if (t == "4")
							{
								this.Show4();
							}
						}
						else
						{
							this.Show3();
						}
					}
					else
					{
						this.Show2();
					}
				}
				else
				{
					this.Show1();
				}
			}
		}
		private void Show1()
		{
			this.list1.Visible = true;
			string text = base.Request.QueryString["type"];
			int num = 60;
			int num2 = 0;
			try
			{
				if (!string.IsNullOrEmpty(base.Request.QueryString["page"]))
				{
					num2 = Convert.ToInt32(base.Request.QueryString["page"]);
				}
			}
			catch
			{
			}
			if (num2 == 0)
			{
				num2 = 1;
			}
			int num3 = num * (num2 - 1);
			string text2 = string.Concat(new string[]
			{
				" AttendType=",
				text,
				" and UID=",
				this.Uid,
				" "
			});
			string value = base.Request.QueryString["st"];
			if (!string.IsNullOrEmpty(value))
			{
				string text3 = base.Request.QueryString["st"];
				string text4 = base.Request.QueryString["et"];
				string text5 = text2;
				text2 = string.Concat(new string[]
				{
					text5,
					" and (addtime between '",
					text3,
					"' and '",
					text4,
					"') "
				});
			}
			else
			{
				text2 += " and datediff(d,addtime,getdate())<180 ";
			}
			int num4 = Convert.ToInt32(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(id) from Work_Attend where " + text2, null));
			this.num1.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + num4 + "</span> 条 记录数据";
			string sql = string.Concat(new object[]
			{
				"select top ",
				num,
				" * from Work_Attend where ",
				text2,
				" order by id desc"
			});
			if (num2 != 1)
			{
				sql = string.Concat(new object[]
				{
					"SELECT TOP ",
					num,
					" * FROM Work_Attend WHERE id<(SELECT MIN(id) FROM (SELECT TOP ",
					num3.ToString(),
					" id FROM Work_Attend WHERE (",
					text2,
					" ) ORDER BY id DESC) T1) AND (",
					text2,
					" ) ORDER BY id DESC"
				});
			}
			this.Bind(sql, this.rpt1);
			if (!string.IsNullOrEmpty(value))
			{
				this.Page1.sty("meneame", num2, this.GetCountPage(num4, num), string.Concat(new string[]
				{
					"?type=",
					text,
					"&st=",
					base.Request.QueryString["st"],
					"&et=",
					base.Request.QueryString["et"],
					"&page="
				}));
			}
			else
			{
				this.Page1.sty("meneame", num2, this.GetCountPage(num4, num), "?type=" + text + "&page=");
			}
		}
		private void Show2()
		{
			this.list2.Visible = true;
			string text = base.Request.QueryString["type"];
			int num = 60;
			int num2 = 0;
			try
			{
				if (!string.IsNullOrEmpty(base.Request.QueryString["page"]))
				{
					num2 = Convert.ToInt32(base.Request.QueryString["page"]);
				}
			}
			catch
			{
			}
			if (num2 == 0)
			{
				num2 = 1;
			}
			int num3 = num * (num2 - 1);
			string text2 = string.Concat(new string[]
			{
				" AttendType=",
				text,
				" and UID=",
				this.Uid,
				" "
			});
			string value = base.Request.QueryString["st"];
			if (!string.IsNullOrEmpty(value))
			{
				string text3 = base.Request.QueryString["st"];
				string text4 = base.Request.QueryString["et"];
				string text5 = text2;
				text2 = string.Concat(new string[]
				{
					text5,
					" and (addtime between '",
					text3,
					"' and '",
					text4,
					"') "
				});
			}
			else
			{
				text2 += " and datediff(d,addtime,getdate())<180 ";
			}
			int num4 = Convert.ToInt32(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(id) from Work_Attend where " + text2, null));
			this.num2.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + num4 + "</span> 条 记录数据";
			string sql = string.Concat(new object[]
			{
				"select top ",
				num,
				" * from Work_Attend where ",
				text2,
				" order by id desc"
			});
			if (num2 != 1)
			{
				sql = string.Concat(new object[]
				{
					"SELECT TOP ",
					num,
					" * FROM Work_Attend WHERE id<(SELECT MIN(id) FROM (SELECT TOP ",
					num3.ToString(),
					" id FROM Work_Attend WHERE (",
					text2,
					" ) ORDER BY id DESC) T1) AND (",
					text2,
					" ) ORDER BY id DESC"
				});
			}
			this.Bind(sql, this.rpt2);
			if (!string.IsNullOrEmpty(value))
			{
				this.Page2.sty("meneame", num2, this.GetCountPage(num4, num), string.Concat(new string[]
				{
					"?type=",
					text,
					"&st=",
					base.Request.QueryString["st"],
					"&et=",
					base.Request.QueryString["et"],
					"&page="
				}));
			}
			else
			{
				this.Page2.sty("meneame", num2, this.GetCountPage(num4, num), "?type=" + text + "&page=");
			}
		}
		private void Show3()
		{
			this.list3.Visible = true;
			string text = base.Request.QueryString["type"];
			int num = 60;
			int num2 = 0;
			try
			{
				if (!string.IsNullOrEmpty(base.Request.QueryString["page"]))
				{
					num2 = Convert.ToInt32(base.Request.QueryString["page"]);
				}
			}
			catch
			{
			}
			if (num2 == 0)
			{
				num2 = 1;
			}
			int num3 = num * (num2 - 1);
			string text2 = string.Concat(new string[]
			{
				" AttendType=",
				text,
				" and UID=",
				this.Uid,
				" "
			});
			string value = base.Request.QueryString["st"];
			if (!string.IsNullOrEmpty(value))
			{
				string text3 = base.Request.QueryString["st"];
				string text4 = base.Request.QueryString["et"];
				string text5 = text2;
				text2 = string.Concat(new string[]
				{
					text5,
					" and (addtime between '",
					text3,
					"' and '",
					text4,
					"') "
				});
			}
			else
			{
				text2 += " and datediff(d,addtime,getdate())<180 ";
			}
			int num4 = Convert.ToInt32(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(id) from Work_Attend where " + text2, null));
			this.num3.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + num4 + "</span> 条 记录数据";
			string sql = string.Concat(new object[]
			{
				"select top ",
				num,
				" * from Work_Attend where ",
				text2,
				" order by id desc"
			});
			if (num2 != 1)
			{
				sql = string.Concat(new object[]
				{
					"SELECT TOP ",
					num,
					" * FROM Work_Attend WHERE id<(SELECT MIN(id) FROM (SELECT TOP ",
					num3.ToString(),
					" id FROM Work_Attend WHERE (",
					text2,
					" ) ORDER BY id DESC) T1) AND (",
					text2,
					" ) ORDER BY id DESC"
				});
			}
			this.Bind(sql, this.rpt3);
			if (!string.IsNullOrEmpty(value))
			{
				this.Page3.sty("meneame", num2, this.GetCountPage(num4, num), string.Concat(new string[]
				{
					"?type=",
					text,
					"&st=",
					base.Request.QueryString["st"],
					"&et=",
					base.Request.QueryString["et"],
					"&page="
				}));
			}
			else
			{
				this.Page3.sty("meneame", num2, this.GetCountPage(num4, num), "?type=" + text + "&page=");
			}
		}
		private void Show4()
		{
			this.list4.Visible = true;
			string text = base.Request.QueryString["type"];
			int num = 60;
			int num2 = 0;
			try
			{
				if (!string.IsNullOrEmpty(base.Request.QueryString["page"]))
				{
					num2 = Convert.ToInt32(base.Request.QueryString["page"]);
				}
			}
			catch
			{
			}
			if (num2 == 0)
			{
				num2 = 1;
			}
			int num3 = num * (num2 - 1);
			string text2 = string.Concat(new string[]
			{
				" AttendType=",
				text,
				" and UID=",
				this.Uid,
				" "
			});
			string value = base.Request.QueryString["st"];
			if (!string.IsNullOrEmpty(value))
			{
				string text3 = base.Request.QueryString["st"];
				string text4 = base.Request.QueryString["et"];
				string text5 = text2;
				text2 = string.Concat(new string[]
				{
					text5,
					" and (addtime between '",
					text3,
					"' and '",
					text4,
					"') "
				});
			}
			else
			{
				text2 += " and datediff(d,addtime,getdate())<180 ";
			}
			int num4 = Convert.ToInt32(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(id) from Work_Attend where " + text2, null));
			this.num4.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + num4 + "</span> 条 记录数据";
			string sql = string.Concat(new object[]
			{
				"select top ",
				num,
				" * from Work_Attend where ",
				text2,
				" order by id desc"
			});
			if (num2 != 1)
			{
				sql = string.Concat(new object[]
				{
					"SELECT TOP ",
					num,
					" * FROM Work_Attend WHERE id<(SELECT MIN(id) FROM (SELECT TOP ",
					num3.ToString(),
					" id FROM Work_Attend WHERE (",
					text2,
					" ) ORDER BY id DESC) T1) AND (",
					text2,
					" ) ORDER BY id DESC"
				});
			}
			this.Bind(sql, this.rpt4);
			if (!string.IsNullOrEmpty(value))
			{
				this.Page4.sty("meneame", num2, this.GetCountPage(num4, num), string.Concat(new string[]
				{
					"?type=",
					text,
					"&st=",
					base.Request.QueryString["st"],
					"&et=",
					base.Request.QueryString["et"],
					"&page="
				}));
			}
			else
			{
				this.Page4.sty("meneame", num2, this.GetCountPage(num4, num), "?type=" + text + "&page=");
			}
		}
		private int GetCountPage(int count, int pageSize)
		{
			int result;
			if (count <= pageSize)
			{
				result = 1;
			}
			else
			{
				if (count % pageSize == 0)
				{
					result = count / pageSize;
				}
				else
				{
					result = count / pageSize + 1;
				}
			}
			return result;
		}
		private void Bind(string sql, Repeater r)
		{
			using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, sql, null))
			{
				r.DataSource = dataSet.Tables[0].DefaultView;
				r.DataBind();
			}
		}
		protected string SignJudge(object b)
		{
			string result;
			if (b.ToString().Contains("正常"))
			{
				result = "<span style='color:#006600'>" + b + "</span>";
			}
			else
			{
				result = "<span style='color:#ff0000'>" + b + "</span>";
			}
			return result;
		}
		protected string TypeStr()
		{
			string result = "";
			string text = base.Request.QueryString["type"];
			string text2 = text;
			if (text2 != null)
			{
				if (!(text2 == "1"))
				{
					if (!(text2 == "2"))
					{
						if (!(text2 == "3"))
						{
							if (text2 == "4")
							{
								result = " >> 出差";
							}
						}
						else
						{
							result = " >> 请假";
						}
					}
					else
					{
						result = " >> 外出";
					}
				}
				else
				{
					result = " >> 上下班";
				}
			}
			return result;
		}
	}
