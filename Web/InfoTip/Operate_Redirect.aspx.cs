using System;
using System.Web.UI;

public partial class InfoTip_Operate_Redirect : System.Web.UI.Page

	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["url"]) && !string.IsNullOrEmpty(base.Request.QueryString["type"]))
			{
				string text = base.Request.QueryString["url"];
				string a = base.Request.QueryString["type"];
				if (a == "1")
				{
                    //string s = string.Concat(new string[]
                    //{
                    //    "<script>if(window.parent !=null){window.parent.location='/Web/Manage/Login.aspx?ReturnUrl=",
                    //    text,
                    //    "';}else{window.location='/Web/Manage/Login.aspx?ReturnUrl=",
                    //    text,
                    //    "';}</script>"
                    //});
                    //base.Response.Write(s);

                    string s = string.Concat(new string[]
					{
						"<script>if(window.parent !=null){window.parent.location='/Manage/Login.aspx?ReturnUrl=",
						text,
						"';}else{window.location='/Manage/Login.aspx?ReturnUrl=",
						text,
						"';}</script>"
					});
                    base.Response.Write(s);





				}
				else
				{
					if (a == "2")
					{
						string s = string.Concat(new string[]
						{
							"<script>if(window.parent !=null){window.parent.location='/Web/InfoTip/Operate_Nologin.aspx?ReturnUrl=",
							text,
							"';}else{window.location='/Web/InfoTip/Operate_Nologin.aspx?ReturnUrl=",
							text,
							"';}</script>"
						});
						base.Response.Write(s);
					}
					else
					{
						if (a == "3")
						{
							string s = string.Concat(new string[]
							{
								"<script>if(window.parent !=null){window.parent.location='/Mobile/Login.aspx?ReturnUrl=",
								text,
								"';}else{window.location='/Web/Mobile/Login.aspx?ReturnUrl=",
								text,
								"';}</script>"
							});
							base.Response.Write(s);
						}
					}
				}
			}
		}
	}
