using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Tool;

public partial class Manage_sys_DbBackup : ModulePages
{
    //protected HtmlHead Head1;
    //protected HtmlForm form1;
    //protected Label l1;
    //protected Button Sub;
    //protected Button Button1;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Submit(object sender, EventArgs e)
    {
        Hashtable hashtable = base.Application["hbm"] as Hashtable;
        string str = string.Concat(hashtable["hibernate.connection.connection_string"]);
        string str2 = Utils.GetMulti(str, "initial catalog=", ";")[0];
        string text = base.Server.MapPath("~/Files");
        string text2 = DateTime.Now.ToString("yyMddHHmmss") + ".rar";
        string str3 = string.Concat(new string[]
			{
				"'",
				text,
				"\\",
				text2,
				"'"
			});
        string cmdText = "BACKUP DATABASE " + str2 + " TO DISK=" + str3;
        MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, null);
        if (File.Exists(text + "\\" + text2))
        {
            base.Response.Write("<script>window.alert('数据库备份成功！')</script>");
            this.l1.Visible = true;
            this.l1.Text = "<a href='/Files/" + text2 + "' target='_blank'><b>点击下载</b></a>";
        }
    }
    protected void ClearIMData(object sender, EventArgs e)
    {
        string cmdText = "delete from WM_Message where datediff(d,CreatedTime,getdate())>90";
        MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, null);
        base.Response.Write("<script>alert('3个月以前的IM数据已成功清理！');window.location='DbBackup.aspx';</script>");
    }
}