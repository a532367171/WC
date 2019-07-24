//using System;
//using System.Data.SqlClient;
//using System.IO;
//using System.Text;
//using System.Xml;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using WC.BLL ;
//using WC.Tool;
//using WC.DK;

//public partial class install_Install : System.Web.UI.Page
//{
//    protected void Page_Load(object sender, EventArgs e)
//    {
//     //   if (Config.CheckInstall())
//        if (false )
//        {
//            base.Response.Write("<script>window.location='../Default.aspx'</script>");
//        }
//        //if (!string.IsNullOrEmpty(base.Request.QueryString["sf"]))
//        //{
//        //    string a = base.Request.QueryString["sf"];
//        //    if (a == "2005")
//        //    {
//        //        this.lt.Text = "准备工作：请使用SqlServer2005（或以上版本）新建一个空数据库<br>提示信息：如果数据库服务器为本机安装,请填写(local)";
//        //    }
//        //    if (a == "2000")
//        //    {
//        //        this.lt.Text = "准备工作：请使用SqlServer2000新建一个空数据库<br>提示信息：如果数据库服务器为本机安装,请填写(local)";
//        //    }
//        //}
//        //else
//        //{
//        //    base.Response.Write("<script>alert('您还没选择数据库版本!');window.location='Prepare.aspx'</script>");
//        //}
//                this.lt.Text = "准备工作：请使用SqlServer2005（或以上版本）新建一个空数据库<br>提示信息：如果数据库服务器为本机安装,请填写(local)";


//    }
//    protected void bt_Click(object sender, EventArgs e)
//    {
//        string conn = this.GetConn();
//        SqlConnection sqlConnection = new SqlConnection(conn);
//        try
//        {
//            sqlConnection.Open();
//            string commandText = File.ReadAllText(base.Server.MapPath("script/table_2005.sql"), Encoding.Default);
//            ;
//            //if (!string.IsNullOrEmpty(base.Request.QueryString["sf"]))
//            //{
//            //    string a = base.Request.QueryString["sf"];
//            //    if (a == "2005")
//            //    {
//                commandText = File.ReadAllText(base.Server.MapPath("script/table_2005.sql"), Encoding.Default);
//            //    }
//            //    if (a == "2000")
//            //    {
//            //        commandText = File.ReadAllText(base.Server.MapPath("script/table_2000.sql"), Encoding.Default);
//            //    }
//            //}
//            commandText = File.ReadAllText(base.Server.MapPath("script/table_2005.sql"), Encoding.Default);

//            //string commandText2 = File.ReadAllText(base.Server.MapPath("script/Procedure0.sql"), Encoding.Default);
//            //string commandText3 = File.ReadAllText(base.Server.MapPath("script/Procedure1.sql"), Encoding.Default);
//            //string commandText4 = File.ReadAllText(base.Server.MapPath("script/Procedure2.sql"), Encoding.Default);
//            //string commandText5 = File.ReadAllText(base.Server.MapPath("script/Procedure3.sql"), Encoding.Default);
//            //string commandText6 = File.ReadAllText(base.Server.MapPath("script/Procedure4.sql"), Encoding.Default);
//            //string commandText7 = File.ReadAllText(base.Server.MapPath("script/Procedure5.sql"), Encoding.Default);
//            //string commandText8 = File.ReadAllText(base.Server.MapPath("script/Procedure6.sql"), Encoding.Default);
//            //SqlCommand sqlCommand = new SqlCommand();
//            //sqlCommand.Connection = sqlConnection;
//            //sqlCommand.CommandText = commandText;
//            //sqlCommand.ExecuteNonQuery();
//            //sqlCommand.CommandText = commandText2;
//            //sqlCommand.ExecuteNonQuery();
//            //sqlCommand.CommandText = commandText3;
//            //sqlCommand.ExecuteNonQuery();
//            //sqlCommand.CommandText = commandText4;
//            //sqlCommand.ExecuteNonQuery();
//            //sqlCommand.CommandText = commandText5;
//            //sqlCommand.ExecuteNonQuery();
//            //sqlCommand.CommandText = commandText6;
//            //sqlCommand.ExecuteNonQuery();
//            //sqlCommand.CommandText = commandText7;
//            //sqlCommand.ExecuteNonQuery();
//            //sqlCommand.CommandText = commandText8;
//            //sqlCommand.ExecuteNonQuery();


//            string commandText2 = File.ReadAllText(base.Server.MapPath("script/Procedure0.sql"), Encoding.UTF8);
//            string commandText3 = File.ReadAllText(base.Server.MapPath("script/Procedure1.sql"), Encoding.UTF8);
//            string commandText4 = File.ReadAllText(base.Server.MapPath("script/Procedure2.sql"), Encoding.UTF8);
//            string commandText5 = File.ReadAllText(base.Server.MapPath("script/Procedure3.sql"), Encoding.UTF8);
//            string commandText6 = File.ReadAllText(base.Server.MapPath("script/Procedure4.sql"), Encoding.UTF8);
//            string commandText7 = File.ReadAllText(base.Server.MapPath("script/Procedure5.sql"), Encoding.UTF8);
//            string commandText8 = File.ReadAllText(base.Server.MapPath("script/Procedure6.sql"), Encoding.UTF8);
//            string commandText9 = File.ReadAllText(base.Server.MapPath("script/Procedure7.sql"), Encoding.UTF8);
//            string commandText10 = File.ReadAllText(base.Server.MapPath("script/pros/p001.sql"), Encoding.UTF8);
//            string commandText11 = File.ReadAllText(base.Server.MapPath("script/pros/p002.sql"), Encoding.UTF8);
//            string commandText12 = File.ReadAllText(base.Server.MapPath("script/pros/p003.sql"), Encoding.UTF8);
//            string commandText13 = File.ReadAllText(base.Server.MapPath("script/pros/p004.sql"), Encoding.UTF8);
//            string commandText14 = File.ReadAllText(base.Server.MapPath("script/pros/p005.sql"), Encoding.UTF8);
//            string commandText15 = File.ReadAllText(base.Server.MapPath("script/pros/p006.sql"), Encoding.UTF8);
//            string commandText16 = File.ReadAllText(base.Server.MapPath("script/pros/p007.sql"), Encoding.UTF8);
//            string commandText17 = File.ReadAllText(base.Server.MapPath("script/pros/p008.sql"), Encoding.UTF8);
//            string commandText18 = File.ReadAllText(base.Server.MapPath("script/pros/p009.sql"), Encoding.UTF8);
//            string commandText19 = File.ReadAllText(base.Server.MapPath("script/pros/p010.sql"), Encoding.UTF8);
//            string commandText20 = File.ReadAllText(base.Server.MapPath("script/pros/p011.sql"), Encoding.UTF8);
//            string commandText21 = File.ReadAllText(base.Server.MapPath("script/pros/p012.sql"), Encoding.UTF8);
//            string commandText22 = File.ReadAllText(base.Server.MapPath("script/pros/p013.sql"), Encoding.UTF8);
//            string commandText23 = File.ReadAllText(base.Server.MapPath("script/pros/p014.sql"), Encoding.UTF8);
//            string commandText24 = File.ReadAllText(base.Server.MapPath("script/pros/p015.sql"), Encoding.UTF8);
//            string commandText25 = File.ReadAllText(base.Server.MapPath("script/pros/p016.sql"), Encoding.UTF8);
//            string commandText26 = File.ReadAllText(base.Server.MapPath("script/pros/p017.sql"), Encoding.UTF8);
//            string commandText27 = File.ReadAllText(base.Server.MapPath("script/pros/p018.sql"), Encoding.UTF8);
//            string commandText28 = File.ReadAllText(base.Server.MapPath("script/pros/p019.sql"), Encoding.UTF8);
//            string commandText29 = File.ReadAllText(base.Server.MapPath("script/pros/p020.sql"), Encoding.UTF8);
//            string commandText30 = File.ReadAllText(base.Server.MapPath("script/pros/p021.sql"), Encoding.UTF8);
//            string commandText31 = File.ReadAllText(base.Server.MapPath("script/pros/f001.sql"), Encoding.UTF8);
//            string commandText32 = File.ReadAllText(base.Server.MapPath("script/pros/f002.sql"), Encoding.UTF8);
//            SqlCommand sqlCommand = new SqlCommand();
//            sqlCommand.Connection = sqlConnection;
//            sqlCommand.CommandText = commandText;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText2;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText3;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText4;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText5;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText6;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText7;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText8;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText9;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText10;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText11;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText12;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText13;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText14;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText15;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText16;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText17;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText18;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText19;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText20;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText21;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText22;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText23;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText24;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText25;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText26;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText27;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText28;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText29;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText30;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText31;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.CommandText = commandText32;
//            sqlCommand.ExecuteNonQuery();
//            sqlCommand.Dispose();
//            sqlConnection.Close();

//            //sqlConnection.Dispose();
//            //保存 数据库链接
//            this.SetJob18(conn);
//            //保存 已安装凭证
//            this.SetInstallValue();
//            Admin_Help.UpdateApp();
//            Help.SetDXBBSConn();
//            Help.GlobalOperateSql();
//            HttpContext.Current.Application["isinstall"] = "1";
//            string str = HttpContext.Current.Server.HtmlEncode("系统已安装成功!谢谢您的使用!");
//            base.Response.Redirect("~/InfoTip/Operate_Install.aspx?returnpage=../Default.aspx&tip=" + str);
//        }
//        catch (Exception ex)
//        {
//            this.lt.Text = "<font color=#ff0000>失败：1 请检查 您填写的资料是否正确. <br>2 数据库是否为 混合验证模式(默认用户sa)<br>3 数据库服务器如果为IP地址,请开启SqlServer远程连接功能<br>4 程序主目录是否配置IIS操作文件夹权限(参考系统安装手册)</font><br>错误信息：" + ex.Message;
//        }
//        finally
//        {
//            if (sqlConnection != null)
//                sqlConnection.Dispose();
//        }




//    }
//    private string GetConn()
//    {
//        string format = "Server={0};initial catalog={1};uid={2};pwd={3};Max Pool Size=10000;Min Pool Size=13;";
//        string text = base.Request.Form["addr"];
//        string text2 = base.Request.Form["name"];
//        string text3 = base.Request.Form["sa"];
//        string text4 = base.Request.Form["pwd"];
//        return string.Format(format, new object[]
//    {
//        text,
//        text2,
//        text3,
//        text4
//    });
//    }
//    private void SetJob18(string cn)
//    {
//        XmlDocument xmlDocument = new XmlDocument();
//        xmlDocument.Load(HttpContext.Current.Server.MapPath("~/Job18.xml"));
//        xmlDocument.SelectSingleNode("Job18/hibernate.connection.connection_string").Attributes["Value"].Value = cn;
//        xmlDocument.Save(HttpContext.Current.Server.MapPath("~/Job18.xml"));
//    }
//    private void SetInstallValue()
//    {
//        XmlDocument xmlDocument = new XmlDocument();
//        xmlDocument.Load(HttpContext.Current.Server.MapPath("~/img/snap/ins.gif"));
//        xmlDocument.SelectSingleNode("ins/install").Attributes["Value"].Value = "9C+EB60=";
//        xmlDocument.Save(HttpContext.Current.Server.MapPath("~/img/snap/ins.gif"));
//    }


//}

using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Tool;
using WC.DK;


public partial class install_Install : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.lt.Text = "准备工作：请使用SqlServer2005（或以上版本）新建一个空数据库<br>提示信息：如果数据库服务器为本机安装,请填写(local)";
    }
    protected void bt_Click(object sender, EventArgs e)
    {
        string conn = this.GetConn();
        CreateDatabase1(conn);
        SqlConnection sqlConnection = new SqlConnection(conn);
        try
        {

            sqlConnection.Open();
            string commandText = File.ReadAllText(base.Server.MapPath("script/table_2005-1.sql"), Encoding.Default);

            //string commandText2 = File.ReadAllText(base.Server.MapPath("script/Db-1.sql"), Encoding.Default);
            string commandText3 = File.ReadAllText(base.Server.MapPath("script/Procedure1.sql"), Encoding.UTF8);
            string commandText4 = File.ReadAllText(base.Server.MapPath("script/Procedure2.sql"), Encoding.UTF8);
            string commandText5 = File.ReadAllText(base.Server.MapPath("script/Procedure3.sql"), Encoding.UTF8);
            string commandText6 = File.ReadAllText(base.Server.MapPath("script/Procedure4.sql"), Encoding.UTF8);
            string commandText7 = File.ReadAllText(base.Server.MapPath("script/Procedure5.sql"), Encoding.UTF8);
            string commandText8 = File.ReadAllText(base.Server.MapPath("script/Procedure6.sql"), Encoding.UTF8);
            string commandText9 = File.ReadAllText(base.Server.MapPath("script/Procedure7.sql"), Encoding.UTF8);
            //string commandText10 = File.ReadAllText(base.Server.MapPath("script/pros/p001.sql"), Encoding.UTF8);
            //string commandText11 = File.ReadAllText(base.Server.MapPath("script/pros/p002.sql"), Encoding.UTF8);
            //string commandText12 = File.ReadAllText(base.Server.MapPath("script/pros/p003.sql"), Encoding.UTF8);
            //string commandText13 = File.ReadAllText(base.Server.MapPath("script/pros/p004.sql"), Encoding.UTF8);
            //string commandText14 = File.ReadAllText(base.Server.MapPath("script/pros/p005.sql"), Encoding.UTF8);
            //string commandText15 = File.ReadAllText(base.Server.MapPath("script/pros/p006.sql"), Encoding.UTF8);
            //string commandText16 = File.ReadAllText(base.Server.MapPath("script/pros/p007.sql"), Encoding.UTF8);
            //string commandText17 = File.ReadAllText(base.Server.MapPath("script/pros/p008.sql"), Encoding.UTF8);
            //string commandText18 = File.ReadAllText(base.Server.MapPath("script/pros/p009.sql"), Encoding.UTF8);
            //string commandText19 = File.ReadAllText(base.Server.MapPath("script/pros/p010.sql"), Encoding.UTF8);
            //string commandText20 = File.ReadAllText(base.Server.MapPath("script/pros/p011.sql"), Encoding.UTF8);
            //string commandText21 = File.ReadAllText(base.Server.MapPath("script/pros/p012.sql"), Encoding.UTF8);
            //string commandText22 = File.ReadAllText(base.Server.MapPath("script/pros/p013.sql"), Encoding.UTF8);
            //string commandText23 = File.ReadAllText(base.Server.MapPath("script/pros/p014.sql"), Encoding.UTF8);
            //string commandText24 = File.ReadAllText(base.Server.MapPath("script/pros/p015.sql"), Encoding.UTF8);
            //string commandText25 = File.ReadAllText(base.Server.MapPath("script/pros/p016.sql"), Encoding.UTF8);
            //string commandText26 = File.ReadAllText(base.Server.MapPath("script/pros/p017.sql"), Encoding.UTF8);
            //string commandText27 = File.ReadAllText(base.Server.MapPath("script/pros/p018.sql"), Encoding.UTF8);
            //string commandText28 = File.ReadAllText(base.Server.MapPath("script/pros/p019.sql"), Encoding.UTF8);
            //string commandText29 = File.ReadAllText(base.Server.MapPath("script/pros/p020.sql"), Encoding.UTF8);
            //string commandText30 = File.ReadAllText(base.Server.MapPath("script/pros/p021.sql"), Encoding.UTF8);
            string commandText31 = File.ReadAllText(base.Server.MapPath("script/pros/f001.sql"), Encoding.UTF8);
            string commandText32 = File.ReadAllText(base.Server.MapPath("script/pros/f002.sql"), Encoding.UTF8);
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = commandText;
            sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText2;
            //sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = commandText3;
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = commandText4;
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = commandText5;
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = commandText6;
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = commandText7;
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = commandText8;
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = commandText9;
            sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText10;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText11;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText12;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText13;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText14;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText15;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText16;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText17;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText18;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText19;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText20;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText21;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText22;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText23;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText24;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText25;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText26;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText27;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText28;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText29;
            //sqlCommand.ExecuteNonQuery();
            //sqlCommand.CommandText = commandText30;
            //sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = commandText31;
            sqlCommand.ExecuteNonQuery();
            sqlCommand.CommandText = commandText32;
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            sqlConnection.Close();


            this.SetJob18(conn);
            //保存 已安装凭证
            this.SetInstallValue();
            Admin_Help.UpdateApp();
            Help.SetDXBBSConn();
            Help.GlobalOperateSql();
            HttpContext.Current.Application["isinstall"] = "1";
            string str = HttpContext.Current.Server.HtmlEncode("系统已安装成功!谢谢您的使用!");
            base.Response.Redirect("~/InfoTip/Operate_Install.aspx?returnpage=../Default.aspx&tip=" + str);
        }
        catch (Exception ex)
        {
            this.lt.Text = "<font color=#ff0000>失败：1 请检查 您填写的资料是否正确. <br>2 数据库是否为 混合验证模式(默认用户sa)<br>3 数据库服务器如果为IP地址,请开启SqlServer远程连接功能<br>4 程序主目录是否配置IIS操作文件夹权限(参考系统安装手册)</font><br>错误信息：" + ex.Message;
        }
        finally
        {
            if (sqlConnection != null)
                sqlConnection.Dispose();
        }




    }
    private string GetConn()
    {
        string format = "Server={0};initial catalog={1};uid={2};pwd={3};Max Pool Size=10000;Min Pool Size=13;";
        string text = base.Request.Form["addr"];
        string text2 = base.Request.Form["name"];
        string text3 = base.Request.Form["sa"];
        string text4 = base.Request.Form["pwd"];
        return string.Format(format, new object[]
	{
		text,
		text2,
		text3,
		text4
	});
    }


    void CreateDatabase1(string connectionString)
    {

        SqlConnection conn = new SqlConnection(connectionString);
        conn.Open();
        try
        {
            SqlTransaction tran = conn.BeginTransaction();
            try
            {
                string text = File.ReadAllText(base.Server.MapPath("script/Db-1.sql"), Encoding.GetEncoding(936));
                string[] sqls = text.Split(new string[] { "GO\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string sql in sqls)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.Transaction = tran;
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
            }
            catch
            {
                tran.Rollback();
                throw;
                this.lt.Text ="<font color=#ff0000>失败：1 请检查 您填写的资料是否正确. <br>2 数据库是否为 混合验证模式(默认用户sa)<br>3 数据库服务器如果为IP地址,请开启SqlServer远程连接功能<br>4 程序主目录是否配置IIS操作文件夹权限(参考系统安装手册)</font><br>错误信息：";

            }
        }
        finally
        {
            conn.Close();
        }
        String configPath = Server.MapPath("../") + @"\Web.config"; ;  

        XmlDocument webConfigXml = new XmlDocument();
        webConfigXml.Load(configPath);
        XmlElement connectionStringsElem = webConfigXml.DocumentElement.GetElementsByTagName("connectionStrings")[0] as XmlElement;
        foreach (XmlElement addElem in connectionStringsElem.GetElementsByTagName("add"))
        {
            if (addElem.GetAttribute("name") == "IMDB")
            {
                addElem.SetAttribute("connectionString", connectionString);
            }
        }
        webConfigXml.Save(configPath);




    }

    private void SetJob18(string cn)
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(HttpContext.Current.Server.MapPath("~/Job18.xml"));
        xmlDocument.SelectSingleNode("Job18/hibernate.connection.connection_string").Attributes["Value"].Value = cn;
        xmlDocument.Save(HttpContext.Current.Server.MapPath("~/Job18.xml"));
    }
    private void SetInstallValue()
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(HttpContext.Current.Server.MapPath("~/img/snap/ins.gif"));
        xmlDocument.SelectSingleNode("ins/install").Attributes["Value"].Value = "9C+EB60=";
        xmlDocument.Save(HttpContext.Current.Server.MapPath("~/img/snap/ins.gif"));
    }


}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                