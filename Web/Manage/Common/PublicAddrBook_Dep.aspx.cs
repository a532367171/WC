using System;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;

public partial class Manage_Common_PublicAddrBook_Dep : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected LinkButton LinkButton1;
        //protected Repeater rpt_dep;
        //protected HtmlGenericControl num;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Show();
			}
		}
		private void Show()
		{
			IList all = Sys_Dep.Init().GetAll(null, "order by orders asc,phone desc");
			this.rpt_dep.DataSource = all;
			this.rpt_dep.DataBind();
			this.num.InnerHtml = "当前 总计 - <span style='color:#ff0000; font-weight:bold;'>" + all.Count + "</span> 个 记录数据";
		}
		protected void DownLoad(object sender, EventArgs e)
		{
			IList all = Sys_Dep.Init().GetAll(null, "order by orders asc,phone desc");
			string text = "组织机构通讯录\r\n\r\n";
			string str = "Organization ContactsBook";
			foreach (object current in all)
			{
				Sys_DepInfo sys_DepInfo = current as Sys_DepInfo;
				if (!string.IsNullOrEmpty(sys_DepInfo.Phone))
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						sys_DepInfo.DepName,
						"：",
						sys_DepInfo.Phone,
						"\r\n"
					});
				}
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
	}
