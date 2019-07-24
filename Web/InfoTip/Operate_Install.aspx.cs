using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using WC.Tool;

public partial class InfoTip_Operate_Install : System.Web.UI.Page

	{
        //protected HtmlForm form1;
		protected string times = "10";
		protected string return_page = "#";
		protected string tip = "您刚才的操作已成功完成";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["returnpage"]))
			{
				string absoluteUri = base.Request.Url.AbsoluteUri;
				if (absoluteUri.Contains("returnpage=") && absoluteUri.Contains("&tip="))
				{
					string strContent = Utils.SplitString(absoluteUri, "returnpage=")[1];
					this.return_page = Utils.SplitString(strContent, "&tip=")[0];
				}
				if (absoluteUri.Contains("returnpage=") && !absoluteUri.Contains("&tip="))
				{
					this.return_page = Utils.SplitString(absoluteUri, "returnpage=")[1];
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["tip"]))
				{
					this.tip = base.Request.QueryString["tip"];
				}
			}
		}
	}
