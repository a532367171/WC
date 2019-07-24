using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace WC.Controls
{
public partial class Controls_Page : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void css()
    {
        HtmlGenericControl htmlGenericControl = new HtmlGenericControl("LINK");
        htmlGenericControl.ID = this.ID;
        htmlGenericControl.Attributes["rel"] = "stylesheet";
        htmlGenericControl.Attributes["type"] = "text/css";
        htmlGenericControl.Attributes["href"] = base.ResolveUrl("/DK_Css/page_css.css");
        this.Controls.Add(htmlGenericControl);
    }
    public void sty(string sty, int page, int pageCount, string src)
    {
        this.css();
        if (pageCount > 1)
        {
            string text = "<div class='" + sty + "'>";
            if (page == 1)
            {
                text += "<span class='disabled'>< </span>";
            }
            else
            {
                text = text + "<a href='" + src + "1'>< </a>";
            }
            if (pageCount <= 9)
            {
                for (int i = 1; i <= pageCount; i++)
                {
                    if (i != page)
                    {
                        text = string.Concat(new object[]
							{
								text,
								"<a href='",
								src,
								i.ToString(),
								"'>",
								i,
								"</a>"
							});
                    }
                    else
                    {
                        text = string.Concat(new object[]
							{
								text,
								"<span class='current'>",
								i,
								"</span>"
							});
                    }
                }
            }
            else
            {
                if (page <= 4)
                {
                    for (int i = 1; i < 9; i++)
                    {
                        if (i != page)
                        {
                            text = string.Concat(new object[]
								{
									text,
									"<a href='",
									src,
									i.ToString(),
									"'>",
									i,
									"</a>"
								});
                        }
                        else
                        {
                            text = string.Concat(new object[]
								{
									text,
									"<span class='current'>",
									i,
									"</span>"
								});
                        }
                    }
                    text = string.Concat(new object[]
						{
							text,
							"...<a href='",
							src,
							pageCount.ToString(),
							"'>",
							pageCount,
							"</a>"
						});
                }
                else
                {
                    if (pageCount - page <= 4)
                    {
                        text = text + "<a href='" + src + "1'>1</a>...";
                        for (int i = pageCount - 8; i <= pageCount; i++)
                        {
                            if (i != page)
                            {
                                text = string.Concat(new object[]
									{
										text,
										"<a href='",
										src,
										i.ToString(),
										"'>",
										i,
										"</a>"
									});
                            }
                            else
                            {
                                text = string.Concat(new object[]
									{
										text,
										"<span class='current'>",
										i,
										"</span>"
									});
                            }
                        }
                    }
                    else
                    {
                        text = text + "<a href='" + src + "1'>1</a>...";
                        for (int i = page - 3; i <= page + 3; i++)
                        {
                            if (i != page)
                            {
                                text = string.Concat(new object[]
									{
										text,
										"<a href='",
										src,
										i.ToString(),
										"'>",
										i,
										"</a>"
									});
                            }
                            else
                            {
                                text = string.Concat(new object[]
									{
										text,
										"<span class='current'>",
										i,
										"</span>"
									});
                            }
                        }
                        text = string.Concat(new object[]
							{
								text,
								"...<a href='",
								src,
								pageCount.ToString(),
								"'>",
								pageCount,
								"</a>"
							});
                    }
                }
            }
            if (page == pageCount)
            {
                text += "<span class='disabled'> > </span>";
            }
            else
            {
                text = string.Concat(new object[]
					{
						text,
						"<a href='",
						src,
						pageCount,
						"'> > </a>"
					});
            }
            text += "</div>";
            this.Parent.Page.ClientScript.RegisterStartupScript(base.GetType(), "", "<script language=javascript>document.getElementById(\"page_\").innerHTML =\"" + text + "\"</script>");
        }
    }
    public void sty(int sty, int page, int pageCount, string src)
    {
        this.css();
        if (pageCount > 1)
        {
            string text;
            if (sty == 1)
            {
                text = "<div class='magics'>";
                if (page == 1)
                {
                    text += "<span class='disabled'>9</span><span class='current'>3</span>";
                }
                else
                {
                    text = string.Concat(new object[]
						{
							text,
							"<a href='",
							src,
							"1'>9</a><a href='",
							src,
							page - 1,
							"'>3</a>"
						});
                }
                if (page == pageCount)
                {
                    text += "<span class='current'>4</span><span class='disabled'>:</span>";
                }
                else
                {
                    text = string.Concat(new object[]
						{
							text,
							"<a href='",
							src,
							page + 1,
							"'>4</a><a href='",
							src,
							pageCount.ToString(),
							"'>:</a>"
						});
                }
            }
            else
            {
                text = "<div class='magics1'>";
                if (page == 1)
                {
                    text += "<span class='disabled'>首&nbsp;&nbsp;页</span><span class='current'>上一页</span>";
                }
                else
                {
                    text = string.Concat(new object[]
						{
							text,
							"<a href='",
							src,
							"1'>首&nbsp;&nbsp;页</a><a href='#?page=",
							page - 1,
							"'>上一页</a>"
						});
                }
                if (page == pageCount)
                {
                    text += "<span class='current'>下一页</span><span class='disabled'>末&nbsp;&nbsp;页</span>";
                }
                else
                {
                    text = string.Concat(new object[]
						{
							text,
							"<a href='",
							src,
							page + 1,
							"'>下一页</a><a href='",
							src,
							pageCount.ToString(),
							"'>末&nbsp;&nbsp;页</a>"
						});
                }
            }
            text = text + "<select name='topage' onchange=javascript:window.location='" + src + "'+this.options[this.selectedIndex].value; class='dropdown' id='topage'>";
            for (int i = 1; i <= pageCount; i++)
            {
                if (i != page)
                {
                    text = string.Concat(new object[]
						{
							text,
							"<option value='",
							i,
							"'>",
							i,
							"</option>"
						});
                }
                else
                {
                    text = string.Concat(new object[]
						{
							text,
							"<option value='",
							i,
							"' selected>",
							i,
							"</option>"
						});
                }
            }
            text += "</select></div>";
            this.Parent.Page.ClientScript.RegisterStartupScript(base.GetType(), "", "<script language=javascript>document.getElementById(\"page_\").innerHTML =\"" + text + "\"</script>");
        }
    }
}
}