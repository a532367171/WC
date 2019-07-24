using System;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;

public partial class Mobile_AddrBook_PublicAddrBook_Dep : MobilePage

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Repeater rpt;
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
			this.rpt.DataSource = all;
			this.rpt.DataBind();
			this.num.InnerHtml = "当前总计 - <span style='color:#ff0000; font-weight:bold;'>" + all.Count + "</span> 个 记录数据";
		}
	}