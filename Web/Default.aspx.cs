using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class _Default : System.Web.UI.Page

	{
        //protected HtmlForm form1;
		private Bas_ComInfo bi = HttpContext.Current.Application["cominfo"] as Bas_ComInfo;
		protected string et = "1";
		protected void Page_Load(object sender, EventArgs e)
		{

            if (!Config.CheckInstall())
            {
                Config.IsInstall();
              
            }

            //Config.IsInstall();
			Admin_Help.UpdateApp();
			this.bi = (HttpContext.Current.Application["cominfo"] as Bas_ComInfo);
			if (this.bi != null && this.bi.et3 == 0)
			{
                //this.et = "0";
                this.et = "0";

			}
		}
	}
