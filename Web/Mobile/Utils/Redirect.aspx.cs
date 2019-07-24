using System;
using System.Web.UI.HtmlControls;
using WC.BLL;

public partial class Mobile_Utils_Redirect : MobilePage


	{
		protected string return_page = "";
		protected string tip = "";
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["p"]))
			{
				this.return_page = base.Request.QueryString["p"];
				this.tip = base.Request.QueryString["t"];
			}
		}
	}