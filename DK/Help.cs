using DXBBS.Business;
using DXBBS.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;
using Core;


/// <summary>
/// Help 的摘要说明
/// </summary>

namespace WC.DK
{
    public class Help
    {
        public Help()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public static string GetMemoConn()
        {
            Hashtable hashtable = HttpContext.Current.Application["hbm"] as Hashtable;
            return string.Concat(hashtable["hibernate.connection.connection_string"]);
        }
        public static void GlobalOperateSql()
        {
            string cmdText = "delete from Mails_Detail where id not in (select distinct did from Mails) ";
            MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
        }
        public static void SetDXBBSConn()
        {
            if (!Config.CheckInstall())
            {
            }
            else
            {
                string memoConn = Help.GetMemoConn();
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(HttpContext.Current.Server.MapPath("~/bbs/config/Forum.config"));
                string value = xmlDocument.SelectSingleNode("ForumConfig/DataBase").Attributes["Value"].Value;
                if (value != memoConn)
                {
                    xmlDocument.SelectSingleNode("ForumConfig/DataBase").Attributes["Value"].Value = memoConn;
                    xmlDocument.Save(HttpContext.Current.Server.MapPath("~/bbs/config/Forum.config"));
                }
            }
        }
        public static void DeleteFiles(string f)
        {
            try
            {
                if (!string.IsNullOrEmpty(f))
                {
                    if (f.Contains("|"))
                    {
                        string[] array = f.Split(new char[]
				{
					'|'
				});
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (array[i].Contains("~/"))
                            {
                                FileSystemManager.DeleteFile(HttpContext.Current.Server.MapPath(array[i]));
                            }
                        }
                    }
                    if (f.Contains("~/") && !f.Contains("|"))
                    {
                        FileSystemManager.DeleteFile(HttpContext.Current.Server.MapPath(f));
                    }
                }
            }
            catch
            {
            }
        }
        public static bool ValidateMobile(string mobile)
        {
            return !string.IsNullOrEmpty(mobile) && Regex.IsMatch(mobile, "^(11|12|13|14|15|16|17|18|19)\\d{9}$");
        }
        public static void NewsMobleSend(List<string> list, string news_title)
        {
            Bas_ComInfo bas_ComInfo = HttpContext.Current.Application["cominfo"] as Bas_ComInfo;
            if (bas_ComInfo.et2 == 1)
            {
                Hashtable hashtable = (Hashtable)HttpContext.Current.Application["sms"];
                string text = string.Concat(hashtable["sms_url"]);
                string text2 = string.Concat(hashtable["sms_user"]);
                string text3 = string.Concat(hashtable["sms_pwd"]);
                string.Concat(hashtable["cont_f"]);
                string.Concat(hashtable["cont_g"]);
                string text4 = string.Concat(hashtable["cont_n"]);
                string.Concat(hashtable["cont_m"]);
                string.Concat(hashtable["cont_f_e"]);
                string.Concat(hashtable["cont_g_e"]);
                string a = string.Concat(hashtable["cont_n_e"]);
                string.Concat(hashtable["cont_m_e"]);
                string[] ary = list.ToArray();
                object[] array = Help.SplitAry(ary, 40);
                object[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    object obj = array2[i];
                    string[] value = (string[])obj;
                    string text5 = string.Join(",", value);
                    string text6 = text;
                    string text7 = text4;
                    string text8 = text2;
                    string text9 = text3;
                    text7 = text7.Replace("t", news_title);
                    if (a == "1")
                    {
                        try
                        {
                            string text10 = string.Concat(new string[]
					{
						text6,
						"/?Uid=",
						text8,
						"&Key=",
						text9,
						"&smsMob=",
						text5,
						"&smsText=",
						HttpUtility.UrlEncode(text7, Encoding.GetEncoding("GBK"))
					});
                            string requestUriString = text10.Trim().ToString();
                            WebRequest webRequest = WebRequest.Create(requestUriString);
                            WebResponse response = webRequest.GetResponse();
                            Stream responseStream = response.GetResponseStream();
                            using (StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("GBK")))
                            {
                                streamReader.ReadToEnd();
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
        private static object[] SplitAry(string[] ary, int subSize)
        {
            int num = (ary.Length % subSize == 0) ? (ary.Length / subSize) : (ary.Length / subSize + 1);
            List<List<string>> list = new List<List<string>>();
            for (int i = 0; i < num; i++)
            {
                int num2 = i * subSize;
                List<string> list2 = new List<string>();
                int j = 0;
                while (j < subSize && num2 < ary.Length)
                {
                    list2.Add(ary[num2++]);
                    j++;
                }
                list.Add(list2);
            }
            object[] array = new object[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                List<string> list3 = list[i];
                string[] array2 = new string[list3.Count];
                for (int j = 0; j < list3.Count; j++)
                {
                    array2[j] = list3[j];
                }
                array[i] = array2;
            }
            return array;
        }
        //public static void DeleteIMUser(int uid)
        //{
        //    try
        //    {
        //        IList all = Sys_User.Init().GetAll("id=" + uid, null);
        //        if (all.Count > 0)
        //        {
        //            Sys_UserInfo sys_UserInfo = all[0] as Sys_UserInfo;
        //            string cmdText = "select [Key] from WM_Users where Name='" + sys_UserInfo.UserName + "'";
        //            string text = string.Concat(MsSqlOperate.ExecuteScalar(CommandType.Text, cmdText, new SqlParameter[0]));
        //            if (Utils.IsNumber(text))
        //            {
        //                long num = Convert.ToInt64(text);
        //                AccountInfo userInfo = AccountImpl.get_Instance().GetUserInfo(num);
        //                if (userInfo.get_Name().ToLower() != "manager")
        //                {
        //                    AccountImpl.get_Instance().DeleteUser(userInfo.get_Name());
        //                    string[] friends = userInfo.get_Friends();
        //                    string[] array = friends;
        //                    for (int i = 0; i < array.Length; i++)
        //                    {
        //                        string text2 = array[i];
        //                        if (AccountImpl.get_Instance().GetUserInfo(text2).get_Type() == 0L)
        //                        {
        //                            SessionManagement.get_Instance().Send(text2, "GLOBAL:REFRESH_FIRENDS", null);
        //                        }
        //                    }
        //                    MsSqlOperate.ExecuteNonQuery(CommandType.Text, "delete from WM_UDD where uid=" + text, new SqlParameter[0]);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public static void FlowMobleSend(string userlist, string flow_title)
        {
            Bas_ComInfo bas_ComInfo = HttpContext.Current.Application["cominfo"] as Bas_ComInfo;
            if (bas_ComInfo.et2 == 1 && userlist.Contains(","))
            {
                string[] array = userlist.Split(new char[]
		{
			','
		});
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Contains("#"))
                    {
                        Sys_UserInfo byId = Sys_User.Init().GetById(Convert.ToInt32(array[i].Split(new char[]
				{
					'#'
				})[1]));
                        Help.SMS_Send_Flow(byId, flow_title);
                    }
                }
            }
        }
        private static void SMS_Send_Flow(Sys_UserInfo ui, string flow_title)
        {
            Hashtable hashtable = (Hashtable)HttpContext.Current.Application["sms"];
            string text = string.Concat(hashtable["sms_url"]);
            string text2 = string.Concat(hashtable["sms_user"]);
            string text3 = string.Concat(hashtable["sms_pwd"]);
            string text4 = string.Concat(hashtable["cont_f"]);
            string.Concat(hashtable["cont_g"]);
            string.Concat(hashtable["cont_n"]);
            string.Concat(hashtable["cont_m"]);
            string a = string.Concat(hashtable["cont_f_e"]);
            string.Concat(hashtable["cont_g_e"]);
            string.Concat(hashtable["cont_n_e"]);
            string.Concat(hashtable["cont_m_e"]);
            if (Help.ValidateMobile(ui.Phone))
            {
                string text5 = text;
                string text6 = text4;
                string text7 = text2;
                string text8 = text3;
                text6 = text6.Replace("x", ui.RealName).Replace("t", flow_title).Replace("p", ui.PositionName);
                if (a == "1")
                {
                    try
                    {
                        string text9 = string.Concat(new string[]
				{
					text5,
					"/?Uid=",
					text7,
					"&Key=",
					text8,
					"&smsMob=",
					ui.Phone,
					"&smsText=",
					HttpUtility.UrlEncode(text6, Encoding.GetEncoding("GBK"))
				});
                        string requestUriString = text9.Trim().ToString();
                        WebRequest webRequest = WebRequest.Create(requestUriString);
                        WebResponse response = webRequest.GetResponse();
                        Stream responseStream = response.GetResponseStream();
                        using (StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("GBK")))
                        {
                            streamReader.ReadToEnd();
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
        public static void AdminSendMail(string title, string content, int receiverid, string userlist, string namelist)
        {
            MailsInfo mailsInfo = new MailsInfo();
            Mails_DetailInfo mails_DetailInfo = new Mails_DetailInfo();
            mails_DetailInfo.Bodys = content;
            mails_DetailInfo.SendIDs = userlist;
            mails_DetailInfo.SendRealNames = namelist;
            Mails_Detail.Init().Add(mails_DetailInfo);
            mailsInfo.ReceiverID = receiverid;
            mailsInfo.SenderDepName = "系统通知";
            mailsInfo.SenderID = 31;
            mailsInfo.SenderRealName = "系统管理员";
            mailsInfo.SendTime = DateTime.Now;
            mailsInfo.SendType = -1;
            mailsInfo.Subject = title;
            mailsInfo.did = mails_DetailInfo.id;
            Mails.Init().Add(mailsInfo);
        }
        public static void MailMobleSend(List<string> uidlist, string mail_title)
        {
            Bas_ComInfo bas_ComInfo = HttpContext.Current.Application["cominfo"] as Bas_ComInfo;
            if (bas_ComInfo.et2 == 1)
            {
                Hashtable hashtable = (Hashtable)HttpContext.Current.Application["sms"];
                string text = string.Concat(hashtable["sms_url"]);
                string text2 = string.Concat(hashtable["sms_user"]);
                string text3 = string.Concat(hashtable["sms_pwd"]);
                string.Concat(hashtable["cont_f"]);
                string.Concat(hashtable["cont_g"]);
                string.Concat(hashtable["cont_n"]);
                string text4 = string.Concat(hashtable["cont_m"]);
                string.Concat(hashtable["cont_f_e"]);
                string.Concat(hashtable["cont_g_e"]);
                string.Concat(hashtable["cont_n_e"]);
                string a = string.Concat(hashtable["cont_m_e"]);
                List<string> list = new List<string>();
                foreach (string current in uidlist)
                {
                    Sys_UserInfo byId = Sys_User.Init().GetById(Convert.ToInt32(current));
                    if (Help.ValidateMobile(byId.Phone))
                    {
                        list.Add(byId.Phone);
                    }
                }
                string[] ary = list.ToArray();
                object[] array = Help.SplitAry(ary, 40);
                object[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    object obj = array2[i];
                    string[] value = (string[])obj;
                    string text5 = string.Join(",", value);
                    string text6 = text;
                    string text7 = text4;
                    string text8 = text2;
                    string text9 = text3;
                    text7 = text7.Replace("t", mail_title);
                    if (a == "1")
                    {
                        try
                        {
                            string text10 = string.Concat(new string[]
					{
						text6,
						"/?Uid=",
						text8,
						"&Key=",
						text9,
						"&smsMob=",
						text5,
						"&smsText=",
						HttpUtility.UrlEncode(text7, Encoding.GetEncoding("GBK"))
					});
                            string requestUriString = text10.Trim().ToString();
                            WebRequest webRequest = WebRequest.Create(requestUriString);
                            WebResponse response = webRequest.GetResponse();
                            Stream responseStream = response.GetResponseStream();
                            using (StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("GBK")))
                            {
                                streamReader.ReadToEnd();
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        //public static void UpdateIMUser(Sys_UserInfo ui)
        //{
        //    try
        //    {
        //        string cmdText = "select [Key] from WM_Users where Name='" + ui.UserName + "'";
        //        string text = string.Concat(MsSqlOperate.ExecuteScalar(CommandType.Text, cmdText, new SqlParameter[0]));
        //        if (Utils.IsNumber(text))
        //        {
        //            string str = string.Concat(new string[]
        //    {
        //        "update WM_Users set Nickname='",
        //        ui.RealName,
        //        "',Password='",
        //        ui.PassWord,
        //        "',EMail='",
        //        ui.Email,
        //        "',Phone='",
        //        ui.Phone,
        //        "',TelPhone='",
        //        ui.Tel,
        //        "' where Name='",
        //        ui.UserName,
        //        "';"
        //    });
        //            string text2 = string.Format("DELETE FROM WM_UDD WHERE uid={1} ; INSERT INTO WM_UDD(did,uid,tid)VALUES({0},{1},0) ", ui.DepID, text);
        //            text2 = str + text2;
        //            MsSqlOperate.ExecuteNonQuery(CommandType.Text, text2, new SqlParameter[0]);
        //            AccountImpl.Instance._RefreshUserInfo(Convert.ToInt64(text));
        //        }
        //        else
        //        {
        //            AccountImpl.Instance.AddUser(ui.UserName, ui.RealName, ui.PassWord, ui.Email, ui.Phone, ui.Tel);
        //            string cmdText2 = "select [Key] from WM_Users where Name='" + ui.UserName + "'";
        //            string text3 = string.Concat(MsSqlOperate.ExecuteScalar(CommandType.Text, cmdText2, new SqlParameter[0]));
        //            if (Utils.IsNumber(text3))
        //            {
        //                string text2 = string.Format("DELETE FROM WM_UDD WHERE uid={1} ; INSERT INTO WM_UDD(did,uid,tid)VALUES({0},{1},0) ", ui.DepID, text3);
        //                MsSqlOperate.ExecuteNonQuery(CommandType.Text, text2, new SqlParameter[0]);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static void UpdateIMUser(Sys_UserInfo ui)
        {
            try
            {
                string cmdText = "select ID from Users where Name='" + ui.UserName + "'";
                string text = string.Concat(MsSqlOperate.ExecuteScalar(CommandType.Text, cmdText, new SqlParameter[0]));
                if (Utils.IsNumber(text))
                {
                    string str = string.Concat(new string[]
			{
				"update Users set Nickname='",
				ui.RealName,
				"',Password='",
				ui.PassWord,
				"',EMail='",
				ui.Email,
				"',Tel='",
				ui.Phone,
				"',Mobile='",
				ui.Tel,
				"' where Name='",
				ui.UserName,
				"';"
			});

                    //MsSqlOperate.ExecuteNonQuery(CommandType.Text, str, new SqlParameter[0]);
                }
                else
                {

                    int id = AccountImpl.Instance.CreateUser(
                ui.UserName.ToString(),
                ui.RealName.ToString(),
                ui.PassWord.ToString(),
                ui.Email.ToString(),
                -1, 0
            );
                    AccountInfo newUser = AccountImpl.Instance.GetUserInfo(id);

                   


                    //AccountImpl.Instance.AddUser(ui.UserName, ui.RealName, ui.PassWord, ui.Email, ui.Phone, ui.Tel);
                    string cmdText2 = "select ID from Users where Name='" + ui.UserName + "'";
                    string text3 = string.Concat(MsSqlOperate.ExecuteScalar(CommandType.Text, cmdText2, new SqlParameter[0]));
                    if (Utils.IsNumber(text3))
                    {
                        string text2 = string.Format("DELETE FROM WM_UDD WHERE uid={1} ; INSERT INTO WM_UDD(did,uid,tid)VALUES({0},{1},0) ", ui.DepID, text3);
                        //MsSqlOperate.ExecuteNonQuery(CommandType.Text, text2, new SqlParameter[0]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }








        public static void BBS_Check(string u)
        {
            IList all = Sys_User.Init().GetAll("id=" + Convert.ToInt32(u), null);
            if (all.Count > 0)
            {
                Sys_UserInfo sys_UserInfo = all[0] as Sys_UserInfo;
                Help.BBS_Update(sys_UserInfo.UserName, sys_UserInfo.PassWord, sys_UserInfo);
                Help.BBS_Login(sys_UserInfo.UserName, sys_UserInfo.PassWord);
            }
        }

        private static void BBS_Login(string u, string p)
        {
            string text = p.Substring(8, 16).ToLower();
            HttpCookie httpCookie = new HttpCookie("DXBBS");
            httpCookie["UserName"] = Filter.Encode(u, ForumConfig.ReadConfigInfo().SecureKey);
            httpCookie["UserPass"] = Filter.Encode(text, ForumConfig.ReadConfigInfo().SecureKey);
            httpCookie["Key"] = Filter.Encode(Clients.CookiesKey, ForumConfig.ReadConfigInfo().SecureKey);
            httpCookie.Expires = DateTime.Now.AddDays((double)2);
            httpCookie["IsHide"] = "false";
            HttpContext.Current.Response.Cookies.Add(httpCookie);
            string cmdText = "select a.*,b.LevelName from WC_Forum_User a,WC_Forum_Level b where username=@u and a.LevelID=b.id";
            DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[]
	{
		new SqlParameter("@u", u)
	});
            int num = 0;
            int.TryParse(dataSet.Tables[0].Rows[0]["ID"].ToString(), out num);
            if (num > 0)
            {
                Sessions.UserID = num;
                Sessions.UserName = u;
                Sessions.LevelID = Convert.ToInt32(dataSet.Tables[0].Rows[0]["LevelID"]);
                Sessions.LevelName = string.Concat(dataSet.Tables[0].Rows[0]["LevelName"]);
            }
            dataSet.Dispose();
        }

        private static void BBS_Update(string u, string p, Sys_UserInfo dxbbs_ui)
        {
            if (dxbbs_ui != null)
            {
                string text = p.Substring(8, 16).ToLower();
                string cmdText = "select * from WC_Forum_User where username=@u";
                DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[]
		{
			new SqlParameter("@u", u)
		});
                string text2 = text;
                int num = Math.Abs(dxbbs_ui.Sex - 1);
                string text3;
                if (num != 1)
                {
                    text3 = "userface/girl.jpg";
                }
                else
                {
                    text3 = "userface/boy.jpg";
                }
                string realName = dxbbs_ui.RealName;
                string iP = RequestUtils.GetIP();
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    string cmdText2;
                    if (dxbbs_ui.RoleID != 4)
                    {
                        cmdText2 = string.Concat(new object[]
				{
					"update WC_Forum_User set UserPass='",
					text2,
					"',sex=",
					num,
					",NickName='",
					realName,
					"',LoginIP='",
					iP,
					"',LoginTime=getdate() where username='",
					u.Trim(),
					"';"
				});
                    }
                    else
                    {
                        cmdText2 = string.Concat(new object[]
				{
					"update WC_Forum_User set UserPass='",
					text2,
					"',sex=",
					num,
					",NickName='",
					realName,
					"',LoginIP='",
					iP,
					"',LevelID=1,LoginTime=getdate() where username='",
					u.Trim(),
					"';"
				});
                    }
                    MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText2, new SqlParameter[0]);
                }
                else
                {
                    string cmdText3;
                    if (dxbbs_ui.RoleID != 4)
                    {
                        cmdText3 = string.Concat(new object[]
				{
					"insert into WC_Forum_User(UserName,UserPass,PasswordType,Question,Answer,Email,Sex,Photo,PhotoWidth,PhotoHeight,NickName,LevelID,RegTime,UploadTime,LoginTime,LevelType,ip) values('",
					u,
					"','",
					text2,
					"',1,'123','456','123@123.com',",
					num,
					",'",
					text3,
					"',100,100,'",
					realName,
					"',7,getdate(),getdate(),getdate(),5,'",
					iP,
					"');"
				});
                    }
                    else
                    {
                        cmdText3 = string.Concat(new object[]
				{
					"insert into WC_Forum_User(UserName,UserPass,PasswordType,Question,Answer,Email,Sex,Photo,PhotoWidth,PhotoHeight,NickName,LevelID,RegTime,UploadTime,LoginTime,LevelType,ip) values('",
					u,
					"','",
					text2,
					"',1,'123','456','123@123.com',",
					num,
					",'",
					text3,
					"',100,100,'",
					realName,
					"',1,getdate(),getdate(),getdate(),1,'",
					iP,
					"');"
				});
                    }
                    MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText3, new SqlParameter[0]);
                }
                dataSet.Dispose();
            }
        }

        // WC.WebUI.Dk.Help
        public static void CommonMobleSend(List<string> list, string common_title, bool islongsms)
        {
            Bas_ComInfo bas_ComInfo = HttpContext.Current.Application["cominfo"] as Bas_ComInfo;
            if (bas_ComInfo.et2 == 1)
            {
                Hashtable hashtable = (Hashtable)HttpContext.Current.Application["sms"];
                string text = string.Concat(hashtable["sms_url"]);
                string text2 = string.Concat(hashtable["sms_user"]);
                string text3 = string.Concat(hashtable["sms_pwd"]);
                string.Concat(hashtable["cont_f"]);
                string.Concat(hashtable["cont_g"]);
                string.Concat(hashtable["cont_n"]);
                string.Concat(hashtable["cont_m"]);
                string.Concat(hashtable["cont_f_e"]);
                string.Concat(hashtable["cont_g_e"]);
                string.Concat(hashtable["cont_n_e"]);
                string.Concat(hashtable["cont_m_e"]);
                string[] ary = list.ToArray();
                object[] array = Help.SplitAry(ary, 40);
                object[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    object obj = array2[i];
                    string[] value = (string[])obj;
                    string text4 = string.Join(",", value);
                    string text5 = text;
                    string text6 = text2;
                    string text7 = text3;
                    try
                    {
                        string text8 = string.Concat(new string[]
				{
					text5,
					"/?Uid=",
					text6,
					"&Key=",
					text7,
					"&smsMob=",
					text4,
					"&smsText=",
					HttpUtility.UrlEncode(common_title, Encoding.GetEncoding("GBK"))
				});
                        string requestUriString = text8.Trim().ToString();
                        WebRequest webRequest = WebRequest.Create(requestUriString);
                        WebResponse response = webRequest.GetResponse();
                        Stream responseStream = response.GetResponseStream();
                        using (StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("GBK")))
                        {
                            streamReader.ReadToEnd();
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }



    }
}

