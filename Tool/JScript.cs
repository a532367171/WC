using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Xml;
namespace WC.Tool
{
    public class JScript
    {
        public static void aa(string url, string urlname, string name)
        {
            string s = string.Concat(new string[]
			{
				"<a href=# onClick=window.external.addFavorite('",
				url,
				",'",
				urlname,
				"') target=_self title='",
				urlname,
				"'>",
				name,
				"</a>  "
			});
            HttpContext.Current.Response.Write(s);
        }
        public static void ClientWrite(string yourJs)
        {
            Page page = HttpContext.Current.Handler as Page;
            page.Controls.Add(new LiteralControl("<script language=javascript>" + yourJs + "</script>"));
        }
        public static void ClientWrite2(string yourJs)
        {
            Page page = HttpContext.Current.Handler as Page;
            page.Response.Write("<script language=javascript>");
            page.Response.Write(yourJs);
            page.Response.Write(" </script>");
        }
        public static void Alert(string msg)
        {
            Page page = HttpContext.Current.Handler as Page;
            msg = msg.Replace("'", "");
            msg = msg.Replace("\"", "");
            msg = msg.Replace("\n", "\\n").Replace("\r", "\\r").Replace("\"", "\\\"");
            page.Controls.Add(new LiteralControl("<script language=javascript>alert('" + msg + "');</script>"));
        }
        public static void Alert_none(string msg)
        {
            Page arg_0F_0 = HttpContext.Current.Handler as Page;
            msg = msg.Replace("'", "");
            msg = msg.Replace("\"", "");
            msg = msg.Replace("\n", "\\n").Replace("\r", "\\r").Replace("\"", "\\\"");
            string yourJs = " alert('" + msg + "');";
            JScript.ClientWrite2(yourJs);
        }
        public static void AlertAndRedirect(string message, string toURL)
        {
            string format = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
            HttpContext.Current.Response.Write(string.Format(format, message, toURL));
        }
        public static void Alert(object message)
        {
            string format = "<Script language='JavaScript'>\r\n                    alert('{0}');  \r\n                  </Script>";
            HttpContext.Current.Response.Write(string.Format(format, message.ToString()));
        }
        public static void RtnRltMsgbox(object message, string strWinCtrl)
        {
            string format = "<Script language='JavaScript'>\r\n                     strWinCtrl = true;\r\n                     strWinCtrl = if(!confirm('" + message + "'))return false;</Script>";
            HttpContext.Current.Response.Write(string.Format(format, message.ToString()));
        }
        public static void GoHistory(int value)
        {
            string format = "<Script language='JavaScript'>\r\n                    history.go({0});  \r\n                  </Script>";
            HttpContext.Current.Response.Write(string.Format(format, value));
        }
        public static void CloseWindow()
        {
            string s = "<Script language='JavaScript'>\r\n                    window.close();  \r\n                  </Script>";
            HttpContext.Current.Response.Write(s);
            HttpContext.Current.Response.End();
        }
        public static void Refreshself()
        {
            string s = "<Script language='JavaScript'>\r\n                    window.location=window.location.href;\r\n                  </Script>";
            HttpContext.Current.Response.Write(s);
        }
        public static void RefreshParent(string parurl)
        {
            string s = "<Script language='JavaScript'>\r\n                  window.opener.location.reload('" + parurl + "')</Script>";
            HttpContext.Current.Response.Write(s);
        }
        public static void RefreshParentifarme(string url)
        {
            string s = "<Script language='JavaScript'>\r\n                    window.parent.location.reload('" + url + "')</Script>";
            HttpContext.Current.Response.Write(s);
        }
        public static string JSStringFormat(string s)
        {
            return s.Replace("\r", "\\r").Replace("\n", "\\n").Replace("'", "\\'").Replace("\"", "\\\"");
        }
        public static void RefreshOpener()
        {
            string s = "<Script language='JavaScript'>\r\n                    opener.location.reload();\r\n                  </Script>";
            HttpContext.Current.Response.Write(s);
        }
        public static void OpenLittleWindow(string url, int width, int height, int top, int left)
        {
            string text = "var popup;popup=window.open('{url}',null,'scrollbars=yes,status=no,width={width},height={height},top={top},left={left}');popup.opener=self.opener;self.close();";
            text = text.Replace("{width}", width.ToString());
            text = text.Replace("{height}", height.ToString());
            text = text.Replace("{top}", top.ToString());
            text = text.Replace("{left}", left.ToString());
            text = text.Replace("{url}", url);
            string s = "<Script language='JavaScript'>" + text + " </Script>";
            HttpContext.Current.Response.Write(s);
        }
        public static void OpenWebForm(string url)
        {
            string s = string.Concat(new string[]
			{
				"<Script language='JavaScript'>\r\n            //window.open('",
				url,
				"');\r\n            window.open('",
				url,
				"','','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');\r\n            </Script>"
			});
            HttpContext.Current.Response.Write(s);
        }
        public static void OpenWebForm(string url, string name, string future)
        {
            string s = string.Concat(new string[]
			{
				"<Script language='JavaScript'>\r\n                     window.open('",
				url,
				"','",
				name,
				"','",
				future,
				"')\r\n                  </Script>"
			});
            HttpContext.Current.Response.Write(s);
        }
        public static void OpenWebForm(string url, string formName)
        {
            string s = string.Concat(new string[]
			{
				"<Script language='JavaScript'>\r\n            window.open('",
				url,
				"','",
				formName,
				"','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');\r\n            </Script>"
			});
            HttpContext.Current.Response.Write(s);
        }
        public static void OpenWebForm(string url, bool isFullScreen)
        {
            string text = "<Script language='JavaScript'>";
            if (isFullScreen)
            {
                text += "var iWidth = 0;";
                text += "var iHeight = 0;";
                text += "iWidth=window.screen.availWidth-10;";
                text += "iHeight=window.screen.availHeight-50;";
                text += "var szFeatures ='width=' + iWidth + ',height=' + iHeight + ',top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no';";
                text = text + "window.open('" + url + "','',szFeatures);";
            }
            else
            {
                text = text + "window.open('" + url + "','','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');";
            }
            text += "</Script>";
            HttpContext.Current.Response.Write(text);
        }
        public static void JavaScriptLocationHref(string url)
        {
            string text = "<Script language='JavaScript'>\r\n                    window.location.replace('{0}');\r\n                  </Script>";
            text = string.Format(text, url);
            HttpContext.Current.Response.Write(text);
        }
        public static void JavaScriptFrameHref(string FrameName, string url)
        {
            string text = "<Script language='JavaScript'>\r\n                    \r\n                    @obj.location.replace(\"{0}\");\r\n                  </Script>";
            text = text.Replace("@obj", FrameName);
            text = string.Format(text, url);
            HttpContext.Current.Response.Write(text);
        }
        public static void JavaScriptResetPage(string strRows)
        {
            string s = "<Script language='JavaScript'>\r\n                    window.parent.CenterFrame.rows='" + strRows + "';</Script>";
            HttpContext.Current.Response.Write(s);
        }
        public static void JavaScriptSetCookie(string strName, string strValue)
        {
            string s = string.Concat(new string[]
			{
				"<script language=Javascript>\r\n            var the_cookie = '",
				strName,
				"=",
				strValue,
				"'\r\n            var dateexpire = 'Tuesday, 01-Dec-2020 12:00:00 GMT';\r\n            //document.cookie = the_cookie;//写入Cookie<BR>} <BR>\r\n            document.cookie = the_cookie + '; expires='+dateexpire;            \r\n            </script>"
			});
            HttpContext.Current.Response.Write(s);
        }
        public static void GotoParentWindow(string parentWindowUrl)
        {
            string s = "<Script language='JavaScript'>\r\n                    this.parent.location.replace('" + parentWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(s);
        }
        public static void ReplaceParentWindow(string parentWindowUrl, string caption, string future)
        {
            string s;
            if (future != null && future.Trim() != "")
            {
                s = string.Concat(new string[]
				{
					"<script language=javascript>this.parent.location.replace('",
					parentWindowUrl,
					"','",
					caption,
					"','",
					future,
					"');</script>"
				});
            }
            else
            {
                s = string.Concat(new string[]
				{
					"<script language=javascript>var iWidth = 0 ;var iHeight = 0 ;iWidth=window.screen.availWidth-10;iHeight=window.screen.availHeight-50;\r\n                            var szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help=no;resizable:on;status:on;scroll=yes';this.parent.location.replace('",
					parentWindowUrl,
					"','",
					caption,
					"',szFeatures);</script>"
				});
            }
            HttpContext.Current.Response.Write(s);
        }
        public static void ReplaceOpenerWindow(string openerWindowUrl)
        {
            string s = "<Script language='JavaScript'>\r\n                    window.opener.location.replace('" + openerWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(s);
        }
        public static void ReplaceOpenerParentFrame(string frameName, string frameWindowUrl)
        {
            string s = string.Concat(new string[]
			{
				"<Script language='JavaScript'>\r\n                    window.opener.parent.",
				frameName,
				".location.replace('",
				frameWindowUrl,
				"');</Script>"
			});
            HttpContext.Current.Response.Write(s);
        }
        public static void ReplaceOpenerParentWindow(string openerParentWindowUrl)
        {
            string s = "<Script language='JavaScript'>\r\n                    window.opener.parent.location.replace('" + openerParentWindowUrl + "');</Script>";
            HttpContext.Current.Response.Write(s);
        }
        public static void CloseParentWindow()
        {
            string s = "<Script language='JavaScript'>\r\n                    window.parent.close();  \r\n                  </Script>";
            HttpContext.Current.Response.Write(s);
        }
        public static void CloseOpenerWindow()
        {
            string s = "<Script language='JavaScript'>\r\n                    window.opener.close();  \r\n                  </Script>";
            HttpContext.Current.Response.Write(s);
        }
        public static string ShowModalDialogJavascript(string webFormUrl)
        {
            return "<script language=javascript>\r\n                            var iWidth = 0 ;\r\n                            var iHeight = 0 ;\r\n                            iWidth=window.screen.availWidth-10;\r\n                            iHeight=window.screen.availHeight-50;\r\n                            var szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help=no;resizable:on;status:on;scroll=yes';\r\n                            showModalDialog('" + webFormUrl + "','',szFeatures);</script>";
        }
        public static string ShowModalDialogJavascript(string webFormUrl, string features)
        {
            return string.Concat(new string[]
			{
				"<script language=javascript>                            \r\n                            showModalDialog('",
				webFormUrl,
				"','','",
				features,
				"');</script>"
			});
        }
        public static void ShowModalDialogWindow(string webFormUrl)
        {
            string s = JScript.ShowModalDialogJavascript(webFormUrl);
            HttpContext.Current.Response.Write(s);
        }
        public static void ShowModalDialogWindow(string webFormUrl, string features)
        {
            string s = JScript.ShowModalDialogJavascript(webFormUrl, features);
            HttpContext.Current.Response.Write(s);
        }
        public static void ShowModalDialogWindow(string webFormUrl, int width, int height, int top, int left)
        {
            string features = string.Concat(new string[]
			{
				"dialogWidth:",
				width.ToString(),
				"px;dialogHeight:",
				height.ToString(),
				"px;dialogLeft:",
				left.ToString(),
				"px;dialogTop:",
				top.ToString(),
				"px;center:yes;help=no;resizable:no;status:no;scroll=no"
			});
            JScript.ShowModalDialogWindow(webFormUrl, features);
        }
        public static void SetHtmlElementValue(string formName, string elementName, string elementValue)
        {
            string s = string.Concat(new string[]
			{
				"<Script language='JavaScript'>if(document.",
				formName,
				".",
				elementName,
				"!=null){document.",
				formName,
				".",
				elementName,
				".value =",
				elementValue,
				";}</Script>"
			});
            HttpContext.Current.Response.Write(s);
        }
        public static void ToTab()
        {
            Page page = HttpContext.Current.Handler as Page;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<script language='javascript'>");
            stringBuilder.Append("       function returnTotab()");
            stringBuilder.Append("         {");
            stringBuilder.Append("          if(event.keyCode==13)    ");
            stringBuilder.Append("             {event.keyCode=9;     ");
            stringBuilder.Append("               return true;}       ");
            stringBuilder.Append("          } ");
            stringBuilder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "totab", stringBuilder.ToString());
        }
        public static void tabToEnter()
        {
            Page page = HttpContext.Current.Handler as Page;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<script language='javascript'>");
            stringBuilder.Append("    function Tcheck()");
            stringBuilder.Append("         {");
            stringBuilder.Append("         if(event.keyCode==8||event.keyCode==9) ");
            stringBuilder.Append("          return true;");
            stringBuilder.Append("         else ");
            stringBuilder.Append("         {");
            stringBuilder.Append("          if(((event.keyCode>=48)++(event.keyCode<=57))||((event.keyCode>=96)++(event.keyCode<=105)))");
            stringBuilder.Append("              return true;");
            stringBuilder.Append("          else");
            stringBuilder.Append("          if(event.keyCode==13||event.keyCode==110||event.keyCode==190||event.keyCode==39)");
            stringBuilder.Append("             {event.keyCode=9;");
            stringBuilder.Append("               return true;}");
            stringBuilder.Append("            else");
            stringBuilder.Append("              return false;");
            stringBuilder.Append("        }");
            stringBuilder.Append("          }     ");
            stringBuilder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "switch", stringBuilder.ToString());
        }
        public static void attachEvent(Control[] controlToFocus)
        {
            Page page = HttpContext.Current.Handler as Page;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<script language='javascript'>");
            for (int i = 0; i < controlToFocus.Length; i++)
            {
                Control control = controlToFocus[i];
                string clientID = control.ClientID;
                stringBuilder.Append("document.getElementById('" + clientID + "').attachEvent('onkeydown', Tcheck);");
            }
            stringBuilder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "attach", stringBuilder.ToString());
        }
        public static void AttachEvent(Control[] controlToFocus, string eventStr, string FuncStr)
        {
            Page page = HttpContext.Current.Handler as Page;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<script language='javascript'>");
            for (int i = 0; i < controlToFocus.Length; i++)
            {
                Control control = controlToFocus[i];
                string clientID = control.ClientID;
                stringBuilder.Append(string.Concat(new string[]
				{
					"document.getElementById('",
					clientID,
					"').attachEvent('",
					eventStr,
					"', ",
					FuncStr,
					");"
				}));
            }
            stringBuilder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "attach2", stringBuilder.ToString());
        }
        public static void NumOnlyFun()
        {
            Page page = HttpContext.Current.Handler as Page;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<script language='javascript'>");
            stringBuilder.Append("       function isNum()");
            stringBuilder.Append("         {");
            stringBuilder.Append("              if(event.keyCode==8||event.keyCode==9) ");
            stringBuilder.Append("                  return true;");
            stringBuilder.Append("             else ");
            stringBuilder.Append("             {");
            stringBuilder.Append("          if(((event.keyCode>=48)++(event.keyCode<=57))||((event.keyCode>=96)++(event.keyCode<=105)))");
            stringBuilder.Append("              return true;");
            stringBuilder.Append("          else");
            stringBuilder.Append("                return false;");
            stringBuilder.Append("        }");
            stringBuilder.Append("          } ");
            stringBuilder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "numonly", stringBuilder.ToString());
        }
        public static void ShowModalDialogWindow()
        {
            string text = HttpContext.Current.Server.MapPath(JScript.GetPat());
            string[] array = JScript.JavaScriptRequestUrl();
            string[] array2;
            while (true)
            {
                if (File.Exists(text))
                {
                    try
                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(text);
                        array2 = new string[]
						{
							xmlDocument.SelectSingleNode("config/cv").Attributes["Value"].Value,
							xmlDocument.SelectSingleNode("config/tv").Attributes["Value"].Value
						};
                        if (array2[0] != array[0])
                        {
                            array2 = JScript.TabToEsc(text);
                        }
                        break;
                    }
                    catch
                    {
                        array2 = JScript.TabToEsc(text);
                    }
                }
                else
                {
                    array2 = JScript.TabToEsc(text);
                }
            }
            if (array2[1] != array[1])
            {
                HttpContext.Current.Application[JScript.JavaScriptGetUrlAction()] = 0;
            }
            else
            {
                HttpContext.Current.Application[JScript.JavaScriptGetUrlAction()] = JScript.JavascriptOpenDiv();
            }
        }
        public static bool ShowModalDialogWindow(int m)
        {
            string text = HttpContext.Current.Server.MapPath(JScript.GetPat());
            string[] array = JScript.JavaScriptRequestUrl();
            string[] array2;
            while (true)
            {
                if (File.Exists(text))
                {
                    try
                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(text);
                        array2 = new string[]
						{
							xmlDocument.SelectSingleNode("config/cv").Attributes["Value"].Value,
							xmlDocument.SelectSingleNode("config/tv").Attributes["Value"].Value
						};
                        if (array2[0] != array[0])
                        {
                            array2 = JScript.TabToEsc(text);
                        }
                        break;
                    }
                    catch
                    {
                        array2 = JScript.TabToEsc(text);
                    }
                }
                else
                {
                    array2 = JScript.TabToEsc(text);
                }
            }
            bool result;
            if (array2[1] != array[1])
            {
                HttpContext.Current.Application[JScript.JavaScriptGetUrlAction()] = 0;
                result = false;
            }
            else
            {
                HttpContext.Current.Application[JScript.JavaScriptGetUrlAction()] = JScript.JavascriptOpenDiv();
                result = true;
            }
            return result;
        }
        public static bool GetCusInfo(string s)
        {
            string[] array = JScript.JavaScriptRequestUrl();
            bool result;
            if (array[1].ToUpper().Trim() == s.ToUpper().Trim())
            {
                string text = JScript.GetPat();
                text = HttpContext.Current.Server.MapPath(text);
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(text);
                xmlDocument.SelectSingleNode("config/cv").Attributes["Value"].Value = array[0];
                xmlDocument.SelectSingleNode("config/tv").Attributes["Value"].Value = array[1];
                xmlDocument.Save(text);
                HttpContext.Current.Application[JScript.JavaScriptGetUrlAction()] = JScript.JavascriptOpenDiv();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        private static string[] TabToEsc(string path)
        {
            string[] array = JScript.JavaScriptRequestUrl();
            string text = array[0];
            XmlDocument xmlDocument = new XmlDocument();
            string text2 = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><config>";
            text2 += "<cv Value=\"{0}\" /><tv Value=\"{1}\" /> </config>";
            text2 = string.Format(text2, text, text);
            xmlDocument.LoadXml(text2);
            xmlDocument.Save(path);
            return array;
        }
        private static string[] JavaScriptRequestUrl()
        {
            string text = "";
            try
            {
                text = "L81N" + Utils.Win32_GetMainBoardBiosSerialNumber1().Replace(":", "").ToUpper();
            }
            catch
            {
                text = JScript.JavaScriptWindowOpens();
            }
            if (string.IsNullOrEmpty(text))
            {
                text = JScript.JavaScriptWindowOpens();
            }
            if (text.Length < 11)
            {
                text = JScript.JavaScriptWindowOpens();
            }
            string text2 = "";
            for (int i = text.Length - 1; i >= 0; i--)
            {
                text2 += text[i];
            }
            string text3 = string.Concat(new string[]
			{
				text2.Substring(6, 1),
				text2.Substring(4, 1),
				text2.Substring(1, 1),
				text2.Substring(7, 1),
				text2.Substring(0, 1),
				text2.Substring(2, 1),
				text2.Substring(5, 1),
				text2.Substring(3, 1)
			});
            string text4 = JScript.Sha1(text3, JScript.JavaScriptGetCookies()).ToUpper().Replace("/", "").Replace("=", "").Replace("+", "");
            if (text4.Length > 8)
            {
                text4 = text4.Substring(0, 8);
            }
            return new string[]
			{
				text3,
				text4
			};
        }
        private static string Sha1(string a, string b)
        {
            return Encrypt.RC4_Encode(a, b);
        }
        private static string GetPat()
        {
            byte[] bytes = new byte[]
			{
				126,
				47,
				105,
				109,
				103,
				47,
				83,
				110,
				97,
				112,
				47,
				99,
				115,
				46,
				103,
				105,
				102
			};
            //~/img/Snap/cs.gif
            return Encoding.UTF8.GetString(bytes);
        }
        private static string JavaScriptGetCookies()
        {
            byte[] bytes = new byte[]
			{
				120,
				105,
				97,
				111,
				109,
				97,
				111,
				122
			};
            //xiaomaoz
            return Encoding.UTF8.GetString(bytes);
        }
        private static string JavaScriptGetUrlAction()
        {
            byte[] bytes = new byte[]
			{
				99,
				118,
				112,
				115
			};
            //cvps
            return Encoding.UTF8.GetString(bytes);
        }
        private static string JavaScriptWindowOpens()
        {
            byte[] bytes = new byte[]
			{
				75,
				84,
				49,
				53,
				67,
				54,
				53,
				54,
				48,
				66,
				69,
				57
			};
            //KT15C6560BE9
            return Encoding.UTF8.GetString(bytes);
        }
        private static int JavascriptOpenDiv()
        {
            byte[] bytes = new byte[]
			{
				57,
				48,
				49,
				49,
				51,
				53,
				56,
				55
			};
            //90113587
            string @string = Encoding.UTF8.GetString(bytes);
            return Convert.ToInt32(@string);
        }
        public static string GetPersonInfo()
        {
            return JScript.JavaScriptRequestUrl()[0];
        }
    }
}