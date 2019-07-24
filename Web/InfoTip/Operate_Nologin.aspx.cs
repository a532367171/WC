using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class InfoTip_Operate_Nologin : System.Web.UI.Page

	{
		protected string times = "3";
        //protected HtmlForm form1;
		protected void Page_Load(object sender, EventArgs e)
		{
			Hashtable hashtable = (Hashtable)HttpContext.Current.Application["stand_config"];
			this.times = Convert.ToString(hashtable["infotip_refresh"]);
		}
	}
