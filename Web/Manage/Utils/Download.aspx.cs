using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using WC.BLL;

public partial class Manage_Utils_Download : ViewPages

	{
        //protected HtmlForm form1;
		protected void Page_Load(object sender, EventArgs e)
		{
			string text = (base.Request.QueryString["destFileName"] != null) ? base.Request.QueryString["destFileName"] : "";
			if (text.Trim().IndexOf("~") == 0)
			{
				text = base.Server.MapPath(base.Server.UrlDecode(text));
			}
			else
			{
				text = "~" + text;
				text = base.Server.MapPath(base.Server.UrlDecode(text));
			}
			if (File.Exists(text))
			{
				FileInfo fileInfo = new FileInfo(text);
				if (fileInfo.FullName.ToLower().Contains("files"))
				{
					base.Response.Clear();
					base.Response.ClearHeaders();
					base.Response.Buffer = false;
					base.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(Path.GetFileName(text), Encoding.UTF8));
					base.Response.AppendHeader("Content-Length", fileInfo.Length.ToString());
					base.Response.ContentType = "application/octet-stream";
					base.Response.WriteFile(text);
					base.Response.Flush();
					base.Response.End();
				}
			}
			else
			{
				base.Response.Write("<script langauge=javascript>alert('文件不存在!');history.go(-1);</script>");
				base.Response.End();
			}
		}
	}

