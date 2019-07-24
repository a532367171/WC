using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;

public partial class Mobile_Login : Page

	{
        //protected HtmlForm form1;
        //protected Button Button1;
		protected void Page_Load(object sender, EventArgs e)
		{
		}
		protected void Login_Btn(object sender, EventArgs e)
		{
			string text = base.Request.Form["UserName"].ToLower();
			string text2 = base.Request.Form["PassWord"].ToLower();
			if (text.Trim() != "" && text2.Trim() != "")
			{
				string text3 = this.CheckPass(text.ToLower(), text2);
				if (text3 == "0,0")
				{
					base.Response.Redirect("Index.aspx");
				}
				if (text3 == "n")
				{
					base.Response.Write("<script>alert('用户名/密码错误!');window.location='Login.aspx'</script>");
				}
				if (text3.Contains("1"))
				{
					if (text3.Split(new char[]
					{
						','
					})[0] == "1")
					{
						base.Response.Write("<script>alert('该员工 已离职，无法登录!');window.location='Login.aspx'</script>");
					}
					if (text3.Split(new char[]
					{
						','
					})[1] == "1")
					{
						base.Response.Write("<script>alert('该员工 已锁定，无法登录!');window.location='Login.aspx'</script>");
					}
				}
			}
		}
		private string CheckPass(string u, string p)
		{
			Hashtable hashtable = (Hashtable)HttpContext.Current.Application["stand_config"];
			double value = Convert.ToDouble(hashtable["user_cookie_delay"]);
			IList list = new List<Sys_UserInfo>();
			string cmdText = "select * from sys_user where UserName=@U and PassWord=@P";
			using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new List<SqlParameter>
			{
				new SqlParameter("@U", u ?? ""),
				new SqlParameter("@P", Encrypt.MD5_32(p.Trim().ToLower()) ?? "")
			}.ToArray()))
			{
				if (dataSet.Tables[0].Rows.Count > 0)
				{
					list = (IList)Utils.GetList<Sys_UserInfo>(dataSet);
				}
			}
			string result;
			if (list.Count == 0)
			{
				result = "n";
			}
			else
			{
				Sys_UserInfo sys_UserInfo = list[0] as Sys_UserInfo;
				sys_UserInfo.IsOnline = 1;
				sys_UserInfo.CurrentLoginTime = DateTime.Now.ToString("yyMddhhmmssfff");
				string moduleList = this.GetModuleList(sys_UserInfo.DepID, sys_UserInfo.RoleID);
				string text = string.Concat(new object[]
				{
					sys_UserInfo.id,
					"|",
					sys_UserInfo.UserName,
					"|",
					sys_UserInfo.RealName,
					"|",
					sys_UserInfo.DepID,
					"|",
					sys_UserInfo.DepName,
					"|",
					moduleList,
					"|",
					sys_UserInfo.CurrentLoginTime,
					"|",
					base.Request.Form["px"]
				});

                //string value2 = Encrypt.RC4_Encode(text, "lazy1111");

                string value2 = Encrypt.EncryptString(text, "lazy1111");

				HttpContext.Current.Session["UserCookies"] = text;
				HttpContext.Current.Session.Timeout = Convert.ToInt32(value) * 10;
				HttpCookie httpCookie = new HttpCookie("UserCookies");
				if (!string.IsNullOrEmpty(base.Request.Form["chkRemember"]))
				{
					httpCookie.Expires = DateTime.Now.AddHours(value);
				}
				httpCookie["key"] = value2;
				base.Response.Cookies.Add(httpCookie);
				sys_UserInfo.LastLoginTime = DateTime.Now;
				sys_UserInfo.LastLoginIp = RequestUtils.GetIP();
				sys_UserInfo.LoginQuantity++;
				Sys_User.Init().Update(sys_UserInfo);
				IList<Sys_UserInfo> list2 = base.Application["user_online"] as IList<Sys_UserInfo>;
				bool flag = false;
				foreach (object current in list2)
				{
					Sys_UserInfo sys_UserInfo2 = current as Sys_UserInfo;
					if (sys_UserInfo2.id == sys_UserInfo.id)
					{
						flag = true;
						sys_UserInfo2.IsOnline = 1;
						sys_UserInfo2.CurrentLoginTime = sys_UserInfo.CurrentLoginTime;
						sys_UserInfo2.LastLoginTime = sys_UserInfo.LastLoginTime;
					}
				}
				if (!flag)
				{
					list2.Add(sys_UserInfo);
				}
				Sys_UserLoginInfo sys_UserLoginInfo = new Sys_UserLoginInfo();
				sys_UserLoginInfo.UserName = sys_UserInfo.UserName;
				sys_UserLoginInfo.UserInfo = sys_UserInfo.RealName + "(" + sys_UserInfo.DepName + ")";
				sys_UserLoginInfo.LoginIP = RequestUtils.GetIP();
				sys_UserLoginInfo.LoginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
				Sys_UserLogin.Init().Add(sys_UserLoginInfo);
				result = sys_UserInfo.Status + "," + sys_UserInfo.IsLock;
			}
			return result;
		}
		private string GetModuleList(int did, int rid)
		{
			IList all = Sys_Dep_Module.Init().GetAll("DepID=" + did, null);
			IList all2 = Sys_Role_Module.Init().GetAll("RoleID=" + rid, null);
			List<string> list = new List<string>();
			foreach (object current in all)
			{
				Sys_Dep_ModuleInfo sys_Dep_ModuleInfo = current as Sys_Dep_ModuleInfo;
				if (!list.Contains(string.Concat(sys_Dep_ModuleInfo.ModuleID)))
				{
					list.Add(string.Concat(sys_Dep_ModuleInfo.ModuleID));
				}
			}
			foreach (object current in all2)
			{
				Sys_Role_ModuleInfo sys_Role_ModuleInfo = current as Sys_Role_ModuleInfo;
				if (!list.Contains(string.Concat(sys_Role_ModuleInfo.ModuleID)))
				{
					list.Add(string.Concat(sys_Role_ModuleInfo.ModuleID));
				}
			}
			string result;
			if (list.Count != 0)
			{
				result = string.Join(",", list.ToArray());
			}
			else
			{
				result = "";
			}
			return result;
		}
	}

