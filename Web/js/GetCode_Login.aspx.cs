using System;
using System.IO;
using System.Web;
using System.Web.UI;
using WC.Tool;

public partial class js_GetCode_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        string text = FileSystemManager.CreateRandomStr(4);
        base.Response.Cookies.Add(new HttpCookie("FeedBackCode_Login", Encrypt.RC4_Encode(text, "lazylog")));
        MemoryStream memoryStream = FileSystemManager.DrawRandomStr(text);
        base.Response.ClearContent();
        base.Response.BinaryWrite(memoryStream.ToArray());
    }
}