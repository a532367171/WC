using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;

public partial class Manage_sys_User_LoginList : ModulePages

{

        //protected HtmlHead Head1;
        //protected HtmlForm form1;
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
		protected void Del_Btn(object obj, EventArgs e)
		{
			LinkButton linkButton = obj as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
			HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
			int id = Convert.ToInt32(htmlInputCheckBox.Value);
			Sys_UserLogin.Init().Delete(id);
			this.Show();
		}
		protected void Del_All(object sender, EventArgs e)
		{
			foreach (RepeaterItem repeaterItem in this.rpt.Items)
			{
				HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
				if (htmlInputCheckBox.Checked)
				{
					int id = Convert.ToInt32(htmlInputCheckBox.Value);
					Sys_UserLogin.Init().Delete(id);
				}
			}
			this.Show();
		}
		private void Show()
		{
			int num = 50;
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
			int num4 = Convert.ToInt32(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(*) from Sys_UserLogin ", null));
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + num4 + "</span> 条 记录数据";
			string sql = "select top " + num + " * from Sys_UserLogin  order by id desc";
			if (num2 != 1)
			{
				sql = string.Concat(new object[]
				{
					"SELECT TOP ",
					num,
					" * FROM Sys_UserLogin WHERE id<(SELECT MIN(id) FROM (SELECT TOP ",
					num3.ToString(),
					" id FROM Sys_UserLogin ORDER BY id DESC) T1) ORDER BY id DESC"
				});
			}
			this.Bind(sql, this.rpt);
			this.Page2.sty("meneame", num2, this.GetCountPage(num4, num), "?page=");
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
