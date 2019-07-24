using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;

public partial class Manage_Attend_WorkList : ModulePages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel search1;
        //protected Panel search2;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected Button dc_bt;
        //protected DropDownList AttendType;
        //protected HtmlInputText BeginTime_S;
        //protected HtmlInputText EndTime_S;
        //protected HtmlInputText keyword;
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
        //protected Panel del5;
        //protected HtmlInputText BeginTime_D;
        //protected HtmlInputText EndTime_D;
        //protected CheckBoxList DeleteType;
        //protected HtmlInputText delarea;
        //protected Button del_bt;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				if (!string.IsNullOrEmpty(base.Request.QueryString["type"]))
				{
					this.Show(base.Request.QueryString["type"]);
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["del"]))
				{
					this.del5.Visible = true;
					this.search1.Visible = false;
					this.search2.Visible = false;
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["delete"]) && !string.IsNullOrEmpty(base.Request.QueryString["wid"]) && !string.IsNullOrEmpty(base.Request.QueryString["type"]))
				{
					int id = Convert.ToInt32(base.Request.QueryString["wid"]);
					Work_Attend.Init().Delete(id);
					base.Response.Redirect("WorkList.aspx?type=" + base.Request.QueryString["type"]);
				}
			}
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			string selectedValue = this.AttendType.SelectedValue;
			string text = HttpContext.Current.Server.HtmlEncode(base.Request.Form["BeginTime_S"].Trim());
			string text2 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["EndTime_S"].Trim());
			string text3 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["keyword"].Trim());
			string str = string.Concat(new string[]
			{
				"?type=",
				selectedValue,
				"&st=",
				text,
				"&et=",
				text2,
				"&keywords=",
				text3
			});
			base.Response.Redirect("WorkList.aspx" + str);
		}
		protected void DC_Btn(object sender, EventArgs e)
		{
			string selectedValue = this.AttendType.SelectedValue;
			string text = HttpContext.Current.Server.HtmlEncode(base.Request.Form["BeginTime_S"].Trim());
			string text2 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["EndTime_S"].Trim());
			string text3 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["keyword"].Trim());
			string str = string.Concat(new string[]
			{
				"?type=",
				selectedValue,
				"&st=",
				text,
				"&et=",
				text2,
				"&keywords=",
				text3
			});
			base.Response.Redirect("DC.aspx" + str);
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
			string text2 = " AttendType=" + text + " ";
			string text3 = base.Request.QueryString["keywords"];
			if (!string.IsNullOrEmpty(text3))
			{
				string text4 = base.Request.QueryString["st"];
				string text5 = base.Request.QueryString["et"];
				string text6 = text2;
				text2 = string.Concat(new string[]
				{
					text6,
					" and (addtime between '",
					text4,
					"' and '",
					text5,
					"') and ("
				});
				text6 = text2;
				text2 = string.Concat(new string[]
				{
					text6,
					" RealName like '%",
					text3,
					"%' or DepName like '%",
					text3,
					"%' ) "
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
			if (!string.IsNullOrEmpty(text3))
			{
				this.Page1.sty("meneame", num2, this.GetCountPage(num4, num), string.Concat(new string[]
				{
					"?type=",
					text,
					"&st=",
					base.Request.QueryString["st"],
					"&et=",
					base.Request.QueryString["et"],
					"&keywords=",
					base.Request.QueryString["keywords"],
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
			string text2 = " AttendType=" + text + " ";
			string text3 = base.Request.QueryString["keywords"];
			if (!string.IsNullOrEmpty(text3))
			{
				string text4 = base.Request.QueryString["st"];
				string text5 = base.Request.QueryString["et"];
				string text6 = text2;
				text2 = string.Concat(new string[]
				{
					text6,
					" and (addtime between '",
					text4,
					"' and '",
					text5,
					"') and ("
				});
				text6 = text2;
				text2 = string.Concat(new string[]
				{
					text6,
					" RealName like '%",
					text3,
					"%' or DepName like '%",
					text3,
					"%' ) "
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
			if (!string.IsNullOrEmpty(text3))
			{
				this.Page2.sty("meneame", num2, this.GetCountPage(num4, num), string.Concat(new string[]
				{
					"?type=",
					text,
					"&st=",
					base.Request.QueryString["st"],
					"&et=",
					base.Request.QueryString["et"],
					"&keywords=",
					base.Request.QueryString["keywords"],
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
			string text2 = " AttendType=" + text + " ";
			string text3 = base.Request.QueryString["keywords"];
			if (!string.IsNullOrEmpty(text3))
			{
				string text4 = base.Request.QueryString["st"];
				string text5 = base.Request.QueryString["et"];
				string text6 = text2;
				text2 = string.Concat(new string[]
				{
					text6,
					" and (addtime between '",
					text4,
					"' and '",
					text5,
					"') and ("
				});
				text6 = text2;
				text2 = string.Concat(new string[]
				{
					text6,
					" RealName like '%",
					text3,
					"%' or DepName like '%",
					text3,
					"%' ) "
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
			if (!string.IsNullOrEmpty(text3))
			{
				this.Page3.sty("meneame", num2, this.GetCountPage(num4, num), string.Concat(new string[]
				{
					"?type=",
					text,
					"&st=",
					base.Request.QueryString["st"],
					"&et=",
					base.Request.QueryString["et"],
					"&keywords=",
					base.Request.QueryString["keywords"],
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
			string text2 = " AttendType=" + text + " ";
			string text3 = base.Request.QueryString["keywords"];
			if (!string.IsNullOrEmpty(text3))
			{
				string text4 = base.Request.QueryString["st"];
				string text5 = base.Request.QueryString["et"];
				string text6 = text2;
				text2 = string.Concat(new string[]
				{
					text6,
					" and (addtime between '",
					text4,
					"' and '",
					text5,
					"') and ("
				});
				text6 = text2;
				text2 = string.Concat(new string[]
				{
					text6,
					" RealName like '%",
					text3,
					"%' or DepName like '%",
					text3,
					"%' ) "
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
			if (!string.IsNullOrEmpty(text3))
			{
				this.Page4.sty("meneame", num2, this.GetCountPage(num4, num), string.Concat(new string[]
				{
					"?type=",
					text,
					"&st=",
					base.Request.QueryString["st"],
					"&et=",
					base.Request.QueryString["et"],
					"&keywords=",
					base.Request.QueryString["keywords"],
					"&page="
				}));
			}
			else
			{
				this.Page4.sty("meneame", num2, this.GetCountPage(num4, num), "?type=" + text + "&page=");
			}
		}
		protected void DelAll_Btn(object sender, EventArgs e)
		{
			string text = base.Request.Form["BeginTime_D"];
			string text2 = base.Request.Form["EndTime_D"];
			string text3 = base.Request.Form["delarea"];
			string text4 = string.Concat(new string[]
			{
				" (addtime between '",
				text,
				"' and '",
				text2,
				"') and ("
			});
			if (!string.IsNullOrEmpty(text3))
			{
				string str = string.Concat(new string[]
				{
					" ( RealName like '%",
					text3,
					"%' or DepName like '%",
					text3,
					"%' ) and "
				});
				text4 = str + text4;
			}
			List<string> list = new List<string>();
			for (int i = 0; i < this.DeleteType.Items.Count; i++)
			{
				if (this.DeleteType.Items[i].Selected)
				{
					list.Add(this.DeleteType.Items[i].Value);
				}
			}
			if (list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (i != list.Count - 1)
					{
						text4 = text4 + " AttendType=" + list[i] + " or ";
					}
					else
					{
						text4 = text4 + " AttendType=" + list[i] + " ) ";
					}
				}
				string cmdText = "delete from Work_Attend where " + text4;
				int num = MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
				base.Response.Write(string.Concat(new object[]
				{
					"<script>alert('共计 ",
					num,
					" 条考勤数据已成功删除!');window.location='WorkList.aspx",
					HttpContext.Current.Request.Url.Query,
					"'</script>"
				}));
			}
			else
			{
				base.Response.Write("<script>alert('没有选择任何考勤类型');window.location='WorkList.aspx" + HttpContext.Current.Request.Url.Query + "'</script>");
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                