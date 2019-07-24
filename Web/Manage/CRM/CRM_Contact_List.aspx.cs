using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;

public partial class Manage_CRM_CRM_Contact_List : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected LinkButton LinkButton1;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page1;
		protected string c = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["cid"]))
			{
				this.Show(base.Request.QueryString["cid"]);
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["cid"]))
			{
				this.c = base.Request.QueryString["cid"];
			}
		}
		protected void Del_Btn(object obj, EventArgs e)
		{
			LinkButton linkButton = obj as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
			HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
			int id = Convert.ToInt32(htmlInputCheckBox.Value);
			CRM_Contact.Init().Delete(id);
			this.Show(base.Request.QueryString["cid"]);
		}
		protected void Del_All(object sender, EventArgs e)
		{
			foreach (RepeaterItem repeaterItem in this.rpt.Items)
			{
				HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
				if (htmlInputCheckBox.Checked)
				{
					int id = Convert.ToInt32(htmlInputCheckBox.Value);
					CRM_Contact.Init().Delete(id);
				}
			}
			this.Show(base.Request.QueryString["cid"]);
		}
		private void Show(string cid)
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
			string text = string.Concat(new string[]
			{
				" cid=",
				cid,
				" and CreatorID=",
				this.Uid,
				" "
			});
			int num4 = Convert.ToInt32(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(*) from CRM_Contact where " + text, null));
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + num4 + "</span> 条 记录数据";
			string sql = string.Concat(new object[]
			{
				"select top ",
				num,
				" * from CRM_Contact where ",
				text,
				" order by id desc"
			});
			if (num2 != 1)
			{
				sql = string.Concat(new object[]
				{
					"SELECT TOP ",
					num,
					" * FROM CRM_Contact WHERE id<(SELECT MIN(id) FROM (SELECT TOP ",
					num3.ToString(),
					" id FROM CRM_Contact WHERE (",
					text,
					" ) ORDER BY id DESC) T1) AND (",
					text,
					" ) ORDER BY id DESC"
				});
			}
			this.Bind(sql, this.rpt);
			this.Page1.sty("meneame", num2, this.GetCountPage(num4, num), "?cid=" + cid + "&page=");
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

