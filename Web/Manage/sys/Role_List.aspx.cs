﻿using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Tool;
public partial class Manage_sys_Role_List : ModulePages
	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected LinkButton LinkButton1;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page1;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Show();
			}
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			string text = base.Request.Form["keyword"];
			string str = "?keywords=" + HttpContext.Current.Server.HtmlEncode(text.Trim());
			base.Response.Redirect("Role_List.aspx" + str);
		}
		protected void Del_Btn(object obj, EventArgs e)
		{
			LinkButton linkButton = obj as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
			HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
			int num = Convert.ToInt32(htmlInputCheckBox.Value);
			string cmdText = "delete from Sys_Role_Module where RoleID=" + num;
			MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, null);
			Sys_Role.Init().Delete(num);
			this.Show();
		}
		protected void Del_All(object sender, EventArgs e)
		{
			foreach (RepeaterItem repeaterItem in this.rpt.Items)
			{
				HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
				if (htmlInputCheckBox.Checked)
				{
					int num = Convert.ToInt32(htmlInputCheckBox.Value);
					string cmdText = "delete from Sys_Role_Module where RoleID=" + num;
					MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, null);
					Sys_Role.Init().Delete(num);
				}
			}
			this.Show();
		}
		private void Show()
		{
			Hashtable hashtable = (Hashtable)HttpContext.Current.Application["config_fenye"];
			int num = Convert.ToInt32(hashtable["fenye_module"]);
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
			string text = "1=1";
			string text2 = base.Request.QueryString["keywords"];
			if (!string.IsNullOrEmpty(text2) && Utils.CheckSql(text2))
			{
				text = " RoleName like '%" + text2 + "%'";
			}
			int num4 = Convert.ToInt32(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(*) from Sys_Role where " + text, null));
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + num4 + "</span> 条 记录数据";
			string sql = string.Concat(new object[]
			{
				"select top ",
				num,
				" * from Sys_Role where ",
				text,
				" order by id asc"
			});
			if (num2 != 1)
			{
				sql = string.Concat(new object[]
				{
					"SELECT TOP ",
					num,
					" * FROM Sys_Role WHERE id<(SELECT MIN(id) FROM (SELECT TOP ",
					num3.ToString(),
					" id FROM Sys_Role WHERE (",
					text,
					" ) ORDER BY id ASC) T1) AND (",
					text,
					" ) ORDER BY id ASC"
				});
			}
			if (text == "1=1")
			{
				this.Bind(sql, this.rpt);
				this.Page1.sty("meneame", num2, this.GetCountPage(num4, num), "?page=");
			}
			else
			{
				this.Bind(sql, this.rpt);
				this.Page1.sty("meneame", num2, this.GetCountPage(num4, num), "?keywords=" + text2 + "&page=");
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
	}

