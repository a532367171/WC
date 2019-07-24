using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;

public partial class Manage_CRM_CRM_Sup_List : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel panLogin;
        //protected Button search_bt;
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
			if (!string.IsNullOrEmpty(text))
			{
				string str = "?keywords=" + HttpContext.Current.Server.HtmlEncode(text.Trim());
				base.Response.Redirect("CRM_Sup_List.aspx" + str);
			}
		}
		protected void Del_Btn(object obj, EventArgs e)
		{
			LinkButton linkButton = obj as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
			HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
			int id = Convert.ToInt32(htmlInputCheckBox.Value);
			CRM_Sup.Init().Delete(id);
			this.Show();
		}
		private void Show()
		{
			Hashtable hashtable = (Hashtable)HttpContext.Current.Application["config_fenye"];
			int num = Convert.ToInt32(hashtable["fenye_commom"]);
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
			string text = base.Request.QueryString["keywords"];
			string text2;
			if (!string.IsNullOrEmpty(text))
			{
				text2 = string.Concat(new string[]
				{
					" CreatorID=",
					this.Uid,
					" and (Sup_Name like '%",
					text,
					"%' or MainPeople like '%",
					text,
					"%' or Addr like '%",
					text.ToUpper(),
					"%' ) "
				});
			}
			else
			{
				text2 = " CreatorID=" + this.Uid;
			}
			int num4 = Convert.ToInt32(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(*) from CRM_Sup where " + text2, null));
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + num4 + "</span> 条 记录数据";
			string sql = string.Concat(new object[]
			{
				"select top ",
				num,
				" * from CRM_Sup where ",
				text2,
				" order by id desc"
			});
			if (num2 != 1)
			{
				sql = string.Concat(new object[]
				{
					"SELECT TOP ",
					num,
					" * FROM CRM_Sup WHERE id<(SELECT MIN(id) FROM (SELECT TOP ",
					num3.ToString(),
					" id FROM CRM_Sup WHERE (",
					text2,
					" ) ORDER BY id DESC) T1) AND (",
					text2,
					" ) ORDER BY id DESC"
				});
			}
			this.Bind(sql, this.rpt);
			if (string.IsNullOrEmpty(text))
			{
				this.Page1.sty("meneame", num2, this.GetCountPage(num4, num), "?page=");
			}
			else
			{
				this.Page1.sty("meneame", num2, this.GetCountPage(num4, num), "?keywords=" + text + "&page=");
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