﻿using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace WC.Tool
{
    public class MessageBox
    {
        public static void Show(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
        }
        public static void ShowConfirm(WebControl Control, string msg)
        {
            Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
        }
        public static void ShowAndRedirect(Page page, string msg, string url)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<script language='javascript' defer>");
            stringBuilder.AppendFormat("alert('{0}');", msg);
            stringBuilder.AppendFormat("window.location.href='{0}'", url);
            stringBuilder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", stringBuilder.ToString());
        }
        public static void ResponseScript(Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
        }
    }
}
