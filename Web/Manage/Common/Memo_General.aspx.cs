using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;

public partial class Manage_Common_Memo_General : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Button b1;
		protected void Page_Load(object sender, EventArgs e)
		{
		}
		protected void Todo_Btn(object sender, EventArgs ea)
		{
			if (!string.IsNullOrEmpty(base.Request.Form["StartTime"]) && !string.IsNullOrEmpty(base.Request.Form["EndTime"]))
			{
				string value = base.Request.Form["StartTime"].Replace("-", "");
				string value2 = base.Request.Form["EndTime"].Replace("-", "");
				int num = Convert.ToInt32(value);
				int num2 = Convert.ToInt32(value2);
				int num3;
				int num4;
				if (num >= num2)
				{
					num3 = num;
					num4 = num2;
				}
				else
				{
					num3 = num2;
					num4 = num;
				}
				base.Response.Redirect(string.Concat(new object[]
				{
					"Memo_Download.aspx?uid=",
					this.Uid,
					"&s=",
					num4,
					"&e=",
					num3
				}));
			}
		}
	}
