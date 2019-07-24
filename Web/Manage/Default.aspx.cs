using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
public partial class Manage_Default : ViewPages
{

   
        //protected HtmlHead Head1;
        //protected Literal message_div;
        //protected Literal sys_div3;
        //protected Literal sys_div4;
        //protected HtmlInputHidden uid;
        //protected HtmlInputHidden stay_time;
        //protected HtmlInputHidden notice_time;
        //protected Panel dxbbs_div;
		protected string logo = "";
		protected string comname = "";
		protected string weburl = "";
		protected string power_menu = "";
		protected string mail_sjx = "";
		protected string mail_cgx = "";
		protected string mail_fjx = "";
		protected string mail_ljx = "";
		protected string news_type = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			this.power_menu = this.GetUserPowerMenu(this.Modules);
			if (!string.IsNullOrEmpty(this.Uid))
			{
				this.uid.Value = this.Uid;
				Bas_ComInfo bas_ComInfo = HttpContext.Current.Application["cominfo"] as Bas_ComInfo;
				this.comname = bas_ComInfo.ComName;
				this.weburl = bas_ComInfo.WebUrl;
				this.logo = bas_ComInfo.Logo;
				if (bas_ComInfo.MsgState != 1)
				{
					this.message_div.Visible = false;
				}
				else
				{
					try
					{
						Sys_UserInfo byId = Sys_User.Init().GetById(Convert.ToInt32(this.Uid));
						int num = byId.MsgTime;
						if (num == -1)
						{
							this.message_div.Visible = false;
						}
						if (num > -1)
						{
							num = num * 60 * 1000;
							this.notice_time.Value = string.Concat(num);
							this.stay_time.Value = "30000";
						}
					}
					catch
					{
					}
				}
				if (bas_ComInfo.BBSState == 1)
				{
					this.dxbbs_div.Visible = true;
					this.sys_div3.Visible = true;
					this.sys_div4.Visible = true;
				}
				else
				{
					this.dxbbs_div.Visible = false;
					this.sys_div3.Visible = false;
					this.sys_div4.Visible = false;
				}
				SqlParameter sqlParameter = new SqlParameter();
				sqlParameter.ParameterName = "@uid";
				sqlParameter.Size = 4;
				sqlParameter.Value = Convert.ToInt32(this.Uid);
				SqlParameter sqlParameter2 = new SqlParameter();
				sqlParameter2.Direction = ParameterDirection.Output;
				sqlParameter2.ParameterName = "@pt0";
				sqlParameter2.Size = 4;
				SqlParameter sqlParameter3 = new SqlParameter();
				sqlParameter3.Direction = ParameterDirection.Output;
				sqlParameter3.ParameterName = "@pt1";
				sqlParameter3.Size = 4;
				SqlParameter sqlParameter4 = new SqlParameter();
				sqlParameter4.Direction = ParameterDirection.Output;
				sqlParameter4.ParameterName = "@pt2";
				sqlParameter4.Size = 4;
				SqlParameter sqlParameter5 = new SqlParameter();
				sqlParameter5.Direction = ParameterDirection.Output;
				sqlParameter5.ParameterName = "@pt3";
				sqlParameter5.Size = 4;
				SqlParameter sqlParameter6 = new SqlParameter();
				sqlParameter6.Direction = ParameterDirection.Output;
				sqlParameter6.ParameterName = "@pt4";
				sqlParameter6.Size = 4;
				SqlParameter[] cmdParms = new SqlParameter[]
				{
					sqlParameter2,
					sqlParameter3,
					sqlParameter4,
					sqlParameter5,
					sqlParameter6,
					sqlParameter
				};
				MsSqlOperate.ExecuteNonQuery(CommandType.StoredProcedure, "Mails_GetAllMailBoxCount", cmdParms);
				this.mail_sjx = sqlParameter2.Value + "/" + sqlParameter6.Value;
				this.mail_cgx = string.Concat(sqlParameter3.Value);
				this.mail_fjx = string.Concat(sqlParameter4.Value);
				this.mail_ljx = string.Concat(sqlParameter5.Value);
				IList all = News_Type.Init().GetAll(null, " order by orders asc");
				for (int i = 0; i < all.Count; i++)
				{
					News_TypeInfo news_TypeInfo = all[i] as News_TypeInfo;
					this.news_type += ",\n";
					this.news_type += "{\n";
					object obj = this.news_type;
					this.news_type = string.Concat(new object[]
					{
						obj,
						"'menuid': '",
						220 + i,
						"',\n"
					});
					this.news_type = this.news_type + "'menuname': '" + news_TypeInfo.TypeName + "',\n";
					this.news_type += "'icon': 'icon-jingpin',\n";
					obj = this.news_type;
					this.news_type = string.Concat(new object[]
					{
						obj,
						"'url': '/Manage/News/News_List.aspx?tid=",
						news_TypeInfo.id,
						"'\n"
					});
					this.news_type += "}\n";
				}
			}
		}
		private string GetUserPowerMenu(string m)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string result;
			if (string.IsNullOrEmpty(m))
			{
				result = "";
			}
			else
			{
				stringBuilder.Append(",\n");
				stringBuilder.Append("{\n");
				stringBuilder.Append("'menuid': '1000',\n");
				stringBuilder.Append("'icon': 'icon-usergrade',\n");
				stringBuilder.Append("'menuname': '系统管理',\n");
				stringBuilder.Append("'menus': [\n\n");
				if (this.GetValidPower(m, "14|43") != "")
				{
					stringBuilder.Append("{\n");
					stringBuilder.Append("'menuid': '10001',\n");
					stringBuilder.Append("'menuname': '系统设置',\n");
					stringBuilder.Append("'icon': 'icon-settings',\n");
					stringBuilder.Append("'child': [\n");
					string validPower = this.GetValidPower(m, "14|43");
					if (validPower.Contains(":"))
					{
						string[] array = validPower.Split(new char[]
						{
							':'
						});
						for (int i = 0; i < array.Length; i++)
						{
							string a = array[i];
							if (i != array.Length - 1)
							{
								if (a == "14")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100011',\n");
									stringBuilder.Append("'menuname': '基本信息',\n");
									stringBuilder.Append("'icon': 'icon-log',\n");
									stringBuilder.Append("'url': '/Manage/sys/Com_Basic.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "43")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100012',\n");
									stringBuilder.Append("'menuname': '数据库备份',\n");
									stringBuilder.Append("'icon': 'icon-db',\n");
									stringBuilder.Append("'url': '/Manage/sys/DbBackup.aspx'\n");
									stringBuilder.Append("},\n");
								}
							}
							else
							{
								if (a == "14")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100011',\n");
									stringBuilder.Append("'menuname': '基本信息',\n");
									stringBuilder.Append("'icon': 'icon-log',\n");
									stringBuilder.Append("'url': '/Manage/sys/Com_Basic.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "43")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100012',\n");
									stringBuilder.Append("'menuname': '数据库备份',\n");
									stringBuilder.Append("'icon': 'icon-db',\n");
									stringBuilder.Append("'url': '/Manage/sys/DbBackup.aspx'\n");
									stringBuilder.Append("}\n");
								}
							}
						}
					}
					else
					{
						if (validPower == "14")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100011',\n");
							stringBuilder.Append("'menuname': '基本信息',\n");
							stringBuilder.Append("'icon': 'icon-log',\n");
							stringBuilder.Append("'url': '/Manage/sys/Com_Basic.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "43")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100012',\n");
							stringBuilder.Append("'menuname': '数据库备份',\n");
							stringBuilder.Append("'icon': 'icon-db',\n");
							stringBuilder.Append("'url': '/Manage/sys/DbBackup.aspx'\n");
							stringBuilder.Append("}\n");
						}
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("},\n\n");
				}
				if (this.GetValidPower(m, "22|21") != "")
				{
					stringBuilder.Append("{\n");
					stringBuilder.Append("'menuid': '10002',\n");
					stringBuilder.Append("'menuname': '组织机构管理',\n");
					stringBuilder.Append("'icon': 'icon-exam',\n");
					stringBuilder.Append("'child': [\n");
					string validPower = this.GetValidPower(m, "22|21");
					if (validPower.Contains(":"))
					{
						string[] array = validPower.Split(new char[]
						{
							':'
						});
						for (int i = 0; i < array.Length; i++)
						{
							string a = array[i];
							if (i != array.Length - 1)
							{
								if (a == "22")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100021',\n");
									stringBuilder.Append("'menuname': '组织机构列表',\n");
									stringBuilder.Append("'icon': 'icon-template',\n");
									stringBuilder.Append("'url': '/Manage/sys/Dep_List.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "21")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100022',\n");
									stringBuilder.Append("'menuname': '新增组织机构',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/sys/Dep_Manage.aspx'\n");
									stringBuilder.Append("},\n");
								}
							}
							else
							{
								if (a == "22")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100021',\n");
									stringBuilder.Append("'menuname': '组织机构列表',\n");
									stringBuilder.Append("'icon': 'icon-template',\n");
									stringBuilder.Append("'url': '/Manage/sys/Dep_List.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "21")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100022',\n");
									stringBuilder.Append("'menuname': '新增组织机构',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/sys/Dep_Manage.aspx'\n");
									stringBuilder.Append("}\n");
								}
							}
						}
					}
					else
					{
						if (validPower == "22")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100021',\n");
							stringBuilder.Append("'menuname': '组织机构列表',\n");
							stringBuilder.Append("'icon': 'icon-template',\n");
							stringBuilder.Append("'url': '/Manage/sys/Dep_List.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "21")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100022',\n");
							stringBuilder.Append("'menuname': '新增组织机构',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/Manage/sys/Dep_Manage.aspx'\n");
							stringBuilder.Append("}\n");
						}
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("},\n\n");
				}
				if (this.GetValidPower(m, "20|19|18|17|46|47") != "")
				{
					stringBuilder.Append("{\n");
					stringBuilder.Append("'menuid': '10003',\n");
					stringBuilder.Append("'menuname': '人事管理',\n");
					stringBuilder.Append("'icon': 'icon-user',\n");
					stringBuilder.Append("'child': [\n");
					string validPower = this.GetValidPower(m, "20|19|18|17|46|47");
					if (validPower.Contains(":"))
					{
						string[] array = validPower.Split(new char[]
						{
							':'
						});
						for (int i = 0; i < array.Length; i++)
						{
							string a = array[i];
							if (i != array.Length - 1)
							{
								if (a == "20")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100031',\n");
									stringBuilder.Append("'menuname': '用户列表',\n");
									stringBuilder.Append("'icon': 'icon-usergroup',\n");
									stringBuilder.Append("'url': '/Manage/sys/User_List.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "19")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100032',\n");
									stringBuilder.Append("'menuname': '新增用户',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/sys/User_Manage.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "18")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100033',\n");
									stringBuilder.Append("'menuname': '角色列表',\n");
									stringBuilder.Append("'icon': 'icon-userclass',\n");
									stringBuilder.Append("'url': '/Manage/sys/Role_List.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "17")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100034',\n");
									stringBuilder.Append("'menuname': '新增角色',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/sys/Role_Manage.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "46")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100035',\n");
									stringBuilder.Append("'menuname': '设置考勤时间',\n");
									stringBuilder.Append("'icon': 'icon-calendar1',\n");
									stringBuilder.Append("'url': '/Manage/Attend/WorkSet.aspx?type=edit'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "47")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100036',\n");
									stringBuilder.Append("'menuname': '考勤统计',\n");
									stringBuilder.Append("'icon': 'icon-template',\n");
									stringBuilder.Append("'url': '/Manage/Attend/WorkList.aspx?type=1'\n");
									stringBuilder.Append("},\n");
								}
							}
							else
							{
								if (a == "20")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100031',\n");
									stringBuilder.Append("'menuname': '用户列表',\n");
									stringBuilder.Append("'icon': 'icon-usergroup',\n");
									stringBuilder.Append("'url': '/Manage/sys/User_List.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "19")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100032',\n");
									stringBuilder.Append("'menuname': '新增用户',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/sys/User_Manage.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "18")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100033',\n");
									stringBuilder.Append("'menuname': '角色列表',\n");
									stringBuilder.Append("'icon': 'icon-userclass',\n");
									stringBuilder.Append("'url': '/Manage/sys/Role_List.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "17")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100034',\n");
									stringBuilder.Append("'menuname': '新增角色',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/sys/Role_Manage.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "46")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100035',\n");
									stringBuilder.Append("'menuname': '设置考勤时间',\n");
									stringBuilder.Append("'icon': 'icon-calendar1',\n");
									stringBuilder.Append("'url': '/Manage/Attend/WorkSet.aspx?type=edit'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "47")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100036',\n");
									stringBuilder.Append("'menuname': '考勤统计',\n");
									stringBuilder.Append("'icon': 'icon-template',\n");
									stringBuilder.Append("'url': '/Manage/Attend/WorkList.aspx?type=1'\n");
									stringBuilder.Append("}\n");
								}
							}
						}
					}
					else
					{
						if (validPower == "20")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100031',\n");
							stringBuilder.Append("'menuname': '用户列表',\n");
							stringBuilder.Append("'icon': 'icon-usergroup',\n");
							stringBuilder.Append("'url': '/Manage/sys/User_List.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "19")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100032',\n");
							stringBuilder.Append("'menuname': '新增用户',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/Manage/sys/User_Manage.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "18")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100033',\n");
							stringBuilder.Append("'menuname': '角色列表',\n");
							stringBuilder.Append("'icon': 'icon-userclass',\n");
							stringBuilder.Append("'url': '/Manage/sys/Role_List.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "17")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100034',\n");
							stringBuilder.Append("'menuname': '新增角色',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/Manage/sys/Role_Manage.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "46")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100035',\n");
							stringBuilder.Append("'menuname': '设置考勤时间',\n");
							stringBuilder.Append("'icon': 'icon-calendar1',\n");
							stringBuilder.Append("'url': '/Manage/Attend/WorkSet.aspx?type=edit'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "47")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100036',\n");
							stringBuilder.Append("'menuname': '考勤统计',\n");
							stringBuilder.Append("'icon': 'icon-template',\n");
							stringBuilder.Append("'url': '/Manage/Attend/WorkList.aspx?type=1'\n");
							stringBuilder.Append("}\n");
						}
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("},\n\n");
				}
				if (this.GetValidPower(m, "29|30|31|32|42|41") != "")
				{
					stringBuilder.Append("{\n");
					stringBuilder.Append("'menuid': '10005',\n");
					stringBuilder.Append("'menuname': '资讯管理',\n");
					stringBuilder.Append("'icon': 'icon-paste',\n");
					stringBuilder.Append("'child': [\n");
					string validPower = this.GetValidPower(m, "29|30|31|32|42|41");
					if (validPower.Contains(":"))
					{
						string[] array = validPower.Split(new char[]
						{
							':'
						});
						for (int i = 0; i < array.Length; i++)
						{
							string a = array[i];
							if (i != array.Length - 1)
							{
								if (a == "29")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100051',\n");
									stringBuilder.Append("'menuname': '所有资讯列表',\n");
									stringBuilder.Append("'icon': 'icon-guestbook',\n");

                                    stringBuilder.Append("'url': '/manage/news/news_alllist.aspx'\n");

                                    //stringBuilder.Append("'url': '/manage/news/News_List.aspx'\n");

									stringBuilder.Append("},\n");
								}
								if (a == "30")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100052',\n");
									stringBuilder.Append("'menuname': '发布资讯',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");

									stringBuilder.Append("'url': '/manage/news/News_Manage.aspx'\n");

									stringBuilder.Append("},\n");
								}
								if (a == "31")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100053',\n");
									stringBuilder.Append("'menuname': '资讯分类列表',\n");
									stringBuilder.Append("'icon': 'icon-jingpin',\n");
									stringBuilder.Append("'url': '/manage/news/NewsType_List.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "32")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100054',\n");
									stringBuilder.Append("'menuname': '添加资讯分类',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/manage/news/NewsType_Manage.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "42")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100055',\n");
									stringBuilder.Append("'menuname': '滚动公告列表',\n");
									stringBuilder.Append("'icon': 'icon-other',\n");
									stringBuilder.Append("'url': '/manage/news/Tips_List.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "41")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100056',\n");
									stringBuilder.Append("'menuname': '添加滚动公告',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/manage/news/Tips_Manage.aspx'\n");
									stringBuilder.Append("},\n");
								}
							}
							else
							{
								if (a == "29")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100051',\n");
									stringBuilder.Append("'menuname': '所有资讯列表',\n");
									stringBuilder.Append("'icon': 'icon-guestbook',\n");
									stringBuilder.Append("'url': '/manage/news/News_AllList.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "30")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100052',\n");
									stringBuilder.Append("'menuname': '发布资讯',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/manage/news/News_Manage.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "31")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100053',\n");
									stringBuilder.Append("'menuname': '资讯分类列表',\n");
									stringBuilder.Append("'icon': 'icon-jingpin',\n");
									stringBuilder.Append("'url': '/manage/news/NewsType_List.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "32")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100054',\n");
									stringBuilder.Append("'menuname': '添加资讯分类',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/manage/news/NewsType_Manage.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "42")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100055',\n");
									stringBuilder.Append("'menuname': '滚动公告列表',\n");
									stringBuilder.Append("'icon': 'icon-other',\n");
									stringBuilder.Append("'url': '/manage/news/Tips_List.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "41")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100056',\n");
									stringBuilder.Append("'menuname': '添加滚动公告',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/manage/news/Tips_Manage.aspx'\n");
									stringBuilder.Append("}\n");
								}
							}
						}
					}
					else
					{
						if (validPower == "29")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100051',\n");
							stringBuilder.Append("'menuname': '所有资讯列表',\n");
							stringBuilder.Append("'icon': 'icon-guestbook',\n");
							stringBuilder.Append("'url': '/manage/news/News_AllList.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "30")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100052',\n");
							stringBuilder.Append("'menuname': '发布资讯',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/manage/news/News_Manage.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "31")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100053',\n");
							stringBuilder.Append("'menuname': '资讯分类列表',\n");
							stringBuilder.Append("'icon': 'icon-jingpin',\n");
							stringBuilder.Append("'url': '/manage/news/NewsType_List.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "32")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100054',\n");
							stringBuilder.Append("'menuname': '添加资讯分类',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/manage/news/NewsType_Manage.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "42")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100055',\n");
							stringBuilder.Append("'menuname': '滚动公告列表',\n");
							stringBuilder.Append("'icon': 'icon-other',\n");
							stringBuilder.Append("'url': '/manage/news/Tips_List.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "41")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100056',\n");
							stringBuilder.Append("'menuname': '添加滚动公告',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/manage/news/Tips_Manage.aspx'\n");
							stringBuilder.Append("}\n");
						}
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("},\n\n");
				}
				if (this.GetValidPower(m, "49|50|51") != "")
				{
					stringBuilder.Append("{\n");
					stringBuilder.Append("'menuid': '300001',\n");
					stringBuilder.Append("'menuname': '工作任务管理',\n");
					stringBuilder.Append("'icon': 'icon-task',\n");
					stringBuilder.Append("'child': [\n");
					string validPower = this.GetValidPower(m, "49|50|51");
					if (validPower.Contains(":"))
					{
						string[] array = validPower.Split(new char[]
						{
							':'
						});
						for (int i = 0; i < array.Length; i++)
						{
							string a = array[i];
							if (i != array.Length - 1)
							{
								if (a == "49")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '300002',\n");
									stringBuilder.Append("'menuname': '任务分类列表',\n");
									stringBuilder.Append("'icon': 'icon-theme',\n");
									stringBuilder.Append("'url': '/Manage/Tasks/TaskType_List.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "50")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '300003',\n");
									stringBuilder.Append("'menuname': '新增任务分类',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/Tasks/TaskType_Manage.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "51")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '300006',\n");
									stringBuilder.Append("'menuname': '所有任务列表',\n");
									stringBuilder.Append("'icon': 'icon-folder',\n");
									stringBuilder.Append("'url': '/Manage/Tasks/Task_AllList.aspx'\n");
									stringBuilder.Append("},\n");
								}
							}
							else
							{
								if (a == "49")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '300002',\n");
									stringBuilder.Append("'menuname': '任务分类列表',\n");
									stringBuilder.Append("'icon': 'icon-theme',\n");
									stringBuilder.Append("'url': '/Manage/Tasks/TaskType_List.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "50")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '300003',\n");
									stringBuilder.Append("'menuname': '新增任务分类',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/Tasks/TaskType_Manage.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "51")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '300006',\n");
									stringBuilder.Append("'menuname': '所有任务列表',\n");
									stringBuilder.Append("'icon': 'icon-folder',\n");
									stringBuilder.Append("'url': '/Manage/Tasks/Task_AllList.aspx'\n");
									stringBuilder.Append("}\n");
								}
							}
						}
					}
					else
					{
						if (validPower == "49")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '300002',\n");
							stringBuilder.Append("'menuname': '任务分类列表',\n");
							stringBuilder.Append("'icon': 'icon-theme',\n");
							stringBuilder.Append("'url': '/Manage/Tasks/TaskType_List.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "50")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '300003',\n");
							stringBuilder.Append("'menuname': '新增任务分类',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/Manage/Tasks/TaskType_Manage.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "51")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '300006',\n");
							stringBuilder.Append("'menuname': '所有任务列表',\n");
							stringBuilder.Append("'icon': 'icon-folder',\n");
							stringBuilder.Append("'url': '/Manage/Tasks/Task_AllList.aspx'\n");
							stringBuilder.Append("}\n");
						}
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("},\n\n");
				}
				if (this.GetValidPower(m, "24|25|26|27|28|57|58") != "")
				{
					stringBuilder.Append("{\n");
					stringBuilder.Append("'menuid': '10006',\n");
					stringBuilder.Append("'menuname': '流程管理',\n");
					stringBuilder.Append("'icon': 'icon-html',\n");
					stringBuilder.Append("'child': [\n");
					string validPower = this.GetValidPower(m, "24|25|26|27|28|57|58");
					if (validPower.Contains(":"))
					{
						string[] array = validPower.Split(new char[]
						{
							':'
						});
						for (int i = 0; i < array.Length; i++)
						{
							string a = array[i];
							if (i != array.Length - 1)
							{
								if (a == "24")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100061',\n");
									stringBuilder.Append("'menuname': '流程模型列表',\n");
									stringBuilder.Append("'icon': 'icon-mdb',\n");
									stringBuilder.Append("'url': '/Manage/Flow/Flow_ModelList.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "25")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100062',\n");
									stringBuilder.Append("'menuname': '新增流程模型',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/Flow/Flow_ModelManage.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "26")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100063',\n");
									stringBuilder.Append("'menuname': '模板表单列表',\n");
									stringBuilder.Append("'icon': 'icon-mde',\n");
									stringBuilder.Append("'url': '/Manage/Flow/Flow_ModelFileList.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "27")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100064',\n");
									stringBuilder.Append("'menuname': '新增模板表单',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/Flow/Flow_ModelFileManage.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "28")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100065',\n");
									stringBuilder.Append("'menuname': '所有流程监控',\n");
									stringBuilder.Append("'icon': 'icon-new2',\n");
									stringBuilder.Append("'url': '/Manage/flow/Flow_ListAll.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "57")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100066',\n");
									stringBuilder.Append("'menuname': '添加模型分类',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/Flow/FlowType_Manage.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "58")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100067',\n");
									stringBuilder.Append("'menuname': '流程模型分类',\n");
									stringBuilder.Append("'icon': 'icon-jingpin',\n");
									stringBuilder.Append("'url': '/Manage/Flow/FlowType_List.aspx'\n");
									stringBuilder.Append("},\n");
								}
							}
							else
							{
								if (a == "24")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100061',\n");
									stringBuilder.Append("'menuname': '流程模型列表',\n");
									stringBuilder.Append("'icon': 'icon-mdb',\n");
									stringBuilder.Append("'url': '/Manage/Flow/Flow_ModelList.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "25")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100062',\n");
									stringBuilder.Append("'menuname': '新增流程模型',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/Flow/Flow_ModelManage.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "26")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100063',\n");
									stringBuilder.Append("'menuname': '模板表单列表',\n");
									stringBuilder.Append("'icon': 'icon-mde',\n");
									stringBuilder.Append("'url': '/Manage/Flow/Flow_ModelFileList.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "27")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100064',\n");
									stringBuilder.Append("'menuname': '新增模板表单',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/Flow/Flow_ModelFileManage.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "28")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100065',\n");
									stringBuilder.Append("'menuname': '所有流程监控',\n");
									stringBuilder.Append("'icon': 'icon-new2',\n");
									stringBuilder.Append("'url': '/Manage/flow/Flow_ListAll.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "57")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100066',\n");
									stringBuilder.Append("'menuname': '添加模型分类',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/Flow/FlowType_Manage.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "58")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100067',\n");
									stringBuilder.Append("'menuname': '流程模型分类',\n");
									stringBuilder.Append("'icon': 'icon-jingpin',\n");
									stringBuilder.Append("'url': '/Manage/Flow/FlowType_List.aspx'\n");
									stringBuilder.Append("}\n");
								}
							}
						}
					}
					else
					{
						if (validPower == "24")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100061',\n");
							stringBuilder.Append("'menuname': '流程模型列表',\n");
							stringBuilder.Append("'icon': 'icon-mdb',\n");
							stringBuilder.Append("'url': '/Manage/Flow/Flow_ModelList.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "25")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100062',\n");
							stringBuilder.Append("'menuname': '新增流程模型',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/Manage/Flow/Flow_ModelManage.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "26")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100063',\n");
							stringBuilder.Append("'menuname': '模板表单列表',\n");
							stringBuilder.Append("'icon': 'icon-mde',\n");
							stringBuilder.Append("'url': '/Manage/Flow/Flow_ModelFileList.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "27")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100064',\n");
							stringBuilder.Append("'menuname': '新增模板表单',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/Manage/Flow/Flow_ModelFileManage.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "28")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100065',\n");
							stringBuilder.Append("'menuname': '所有流程监控',\n");
							stringBuilder.Append("'icon': 'icon-new2',\n");
							stringBuilder.Append("'url': '/Manage/flow/Flow_ListAll.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "57")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100066',\n");
							stringBuilder.Append("'menuname': '添加模型分类',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/Manage/Flow/FlowType_Manage.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "58")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100067',\n");
							stringBuilder.Append("'menuname': '流程模型分类',\n");
							stringBuilder.Append("'icon': 'icon-jingpin',\n");
							stringBuilder.Append("'url': '/Manage/Flow/FlowType_List.aspx'\n");
							stringBuilder.Append("}\n");
						}
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("},\n\n");
				}
				if (this.GetValidPower(m, "44|34|35|36|37|38|59|60") != "")
				{
					stringBuilder.Append("{\n");
					stringBuilder.Append("'menuid': '10007',\n");
					stringBuilder.Append("'menuname': '公文管理',\n");
					stringBuilder.Append("'icon': 'icon-ett',\n");
					stringBuilder.Append("'child': [\n");
					string validPower = this.GetValidPower(m, "44|34|35|36|37|38|59|60");
					if (validPower.Contains(":"))
					{
						string[] array = validPower.Split(new char[]
						{
							':'
						});
						for (int i = 0; i < array.Length; i++)
						{
							string a = array[i];
							if (i != array.Length - 1)
							{
								if (a == "44")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100071',\n");
									stringBuilder.Append("'menuname': '发文拟稿',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/manage/gov/Gov_Manage.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "34")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100072',\n");
									stringBuilder.Append("'menuname': '公文模型列表',\n");
									stringBuilder.Append("'icon': 'icon-pub',\n");
									stringBuilder.Append("'url': '/manage/gov/gov_ModelList.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "35")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100073',\n");
									stringBuilder.Append("'menuname': '新增公文模型',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/manage/gov/gov_ModelManage.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "36")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100074',\n");
									stringBuilder.Append("'menuname': '公文表单列表',\n");
									stringBuilder.Append("'icon': 'icon-txt',\n");
									stringBuilder.Append("'url': '/manage/gov/gov_ModelFileList.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "37")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100075',\n");
									stringBuilder.Append("'menuname': '新增公文表单',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/manage/gov/gov_ModelFileManage.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "38")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100076',\n");
									stringBuilder.Append("'menuname': '所有公文监控',\n");
									stringBuilder.Append("'icon': 'icon-new2',\n");
									stringBuilder.Append("'url': '/manage/gov/gov_ListAll.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "59")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100077',\n");
									stringBuilder.Append("'menuname': '新增模型分类',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/Gov/GovType_Manage.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "60")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100078',\n");
									stringBuilder.Append("'menuname': '公文模型分类',\n");
									stringBuilder.Append("'icon': 'icon-folder',\n");
									stringBuilder.Append("'url': '/Manage/Gov/GovType_List.aspx'\n");
									stringBuilder.Append("},\n");
								}
							}
							else
							{
								if (a == "44")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100071',\n");
									stringBuilder.Append("'menuname': '发文拟稿',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/manage/gov/Gov_Manage.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "34")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100072',\n");
									stringBuilder.Append("'menuname': '公文模型列表',\n");
									stringBuilder.Append("'icon': 'icon-pub',\n");
									stringBuilder.Append("'url': '/manage/gov/gov_ModelList.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "35")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100073',\n");
									stringBuilder.Append("'menuname': '新增公文模型',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/manage/gov/gov_ModelManage.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "36")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100074',\n");
									stringBuilder.Append("'menuname': '公文表单列表',\n");
									stringBuilder.Append("'icon': 'icon-txt',\n");
									stringBuilder.Append("'url': '/manage/gov/gov_ModelFileList.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "37")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100075',\n");
									stringBuilder.Append("'menuname': '新增公文表单',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/manage/gov/gov_ModelFileManage.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "38")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100076',\n");
									stringBuilder.Append("'menuname': '所有公文监控',\n");
									stringBuilder.Append("'icon': 'icon-new2',\n");
									stringBuilder.Append("'url': '/manage/gov/gov_ListAll.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "59")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100077',\n");
									stringBuilder.Append("'menuname': '新增模型分类',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/Gov/GovType_Manage.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "60")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100078',\n");
									stringBuilder.Append("'menuname': '公文模型分类',\n");
									stringBuilder.Append("'icon': 'icon-folder',\n");
									stringBuilder.Append("'url': '/Manage/Gov/GovType_List.aspx'\n");
									stringBuilder.Append("}\n");
								}
							}
						}
					}
					else
					{
						if (validPower == "44")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100071',\n");
							stringBuilder.Append("'menuname': '发文拟稿',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/manage/gov/Gov_Manage.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "34")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100072',\n");
							stringBuilder.Append("'menuname': '公文模型列表',\n");
							stringBuilder.Append("'icon': 'icon-pub',\n");
							stringBuilder.Append("'url': '/manage/gov/gov_ModelList.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "35")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100073',\n");
							stringBuilder.Append("'menuname': '新增公文模型',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/manage/gov/gov_ModelManage.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "36")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100074',\n");
							stringBuilder.Append("'menuname': '公文表单列表',\n");
							stringBuilder.Append("'icon': 'icon-txt',\n");
							stringBuilder.Append("'url': '/manage/gov/gov_ModelFileList.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "37")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100075',\n");
							stringBuilder.Append("'menuname': '新增公文表单',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/manage/gov/gov_ModelFileManage.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "38")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100076',\n");
							stringBuilder.Append("'menuname': '所有公文监控',\n");
							stringBuilder.Append("'icon': 'icon-new2',\n");
							stringBuilder.Append("'url': '/manage/gov/gov_ListAll.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "59")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100077',\n");
							stringBuilder.Append("'menuname': '新增模型分类',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/Manage/Gov/GovType_Manage.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "60")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100078',\n");
							stringBuilder.Append("'menuname': '公文模型分类',\n");
							stringBuilder.Append("'icon': 'icon-folder',\n");
							stringBuilder.Append("'url': '/Manage/Gov/GovType_List.aspx'\n");
							stringBuilder.Append("}\n");
						}
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("},\n\n");
				}
				if (this.GetValidPower(m, "52|53|54|55|56") != "")
				{
					stringBuilder.Append("{\n");
					stringBuilder.Append("'menuid': '600001',\n");
					stringBuilder.Append("'menuname': '电子档案管理',\n");
					stringBuilder.Append("'icon': 'icon-ppt',\n");
					stringBuilder.Append("'child': [\n");
					string validPower = this.GetValidPower(m, "52|53|54|55|56");
					if (validPower.Contains(":"))
					{
						string[] array = validPower.Split(new char[]
						{
							':'
						});
						for (int i = 0; i < array.Length; i++)
						{
							string a = array[i];
							if (i != array.Length - 1)
							{
								if (a == "52")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '600002',\n");
									stringBuilder.Append("'menuname': '新增电子档案',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/Paper/PaperManage.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "53")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '600003',\n");
									stringBuilder.Append("'menuname': '所有电子档案',\n");
									stringBuilder.Append("'icon': 'icon-guestbook',\n");
									stringBuilder.Append("'url': '/Manage/Paper/PaperAllList.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "56")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '600004',\n");
									stringBuilder.Append("'menuname': '档案下载记录',\n");
									stringBuilder.Append("'icon': 'icon-all',\n");
									stringBuilder.Append("'url': '/Manage/Paper/DownLoadList.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "54")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '600005',\n");
									stringBuilder.Append("'menuname': '新增档案分类',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/Paper/PaperType_Manage.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "55")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '600006',\n");
									stringBuilder.Append("'menuname': '档案分类列表',\n");
									stringBuilder.Append("'icon': 'icon-jingpin',\n");
									stringBuilder.Append("'url': '/Manage/Paper/PaperType_List.aspx'\n");
									stringBuilder.Append("},\n");
								}
							}
							else
							{
								if (a == "52")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '600002',\n");
									stringBuilder.Append("'menuname': '新增电子档案',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/Paper/PaperManage.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "53")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '600003',\n");
									stringBuilder.Append("'menuname': '所有电子档案',\n");
									stringBuilder.Append("'icon': 'icon-guestbook',\n");
									stringBuilder.Append("'url': '/Manage/Paper/PaperAllList.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "56")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '600004',\n");
									stringBuilder.Append("'menuname': '档案下载记录',\n");
									stringBuilder.Append("'icon': 'icon-all',\n");
									stringBuilder.Append("'url': '/Manage/Paper/DownLoadList.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "54")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '600005',\n");
									stringBuilder.Append("'menuname': '新增档案分类',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/Manage/Paper/PaperType_Manage.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "55")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '600006',\n");
									stringBuilder.Append("'menuname': '档案分类列表',\n");
									stringBuilder.Append("'icon': 'icon-jingpin',\n");
									stringBuilder.Append("'url': '/Manage/Paper/PaperType_List.aspx'\n");
									stringBuilder.Append("}\n");
								}
							}
						}
					}
					else
					{
						if (validPower == "52")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '600002',\n");
							stringBuilder.Append("'menuname': '新增电子档案',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/Manage/Paper/PaperManage.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "53")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '600003',\n");
							stringBuilder.Append("'menuname': '所有电子档案',\n");
							stringBuilder.Append("'icon': 'icon-guestbook',\n");
							stringBuilder.Append("'url': '/Manage/Paper/PaperAllList.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "56")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '600004',\n");
							stringBuilder.Append("'menuname': '档案下载记录',\n");
							stringBuilder.Append("'icon': 'icon-all',\n");
							stringBuilder.Append("'url': '/Manage/Paper/DownLoadList.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "54")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '600005',\n");
							stringBuilder.Append("'menuname': '新增档案分类',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/Manage/Paper/PaperType_Manage.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "55")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '600006',\n");
							stringBuilder.Append("'menuname': '档案分类列表',\n");
							stringBuilder.Append("'icon': 'icon-jingpin',\n");
							stringBuilder.Append("'url': '/Manage/Paper/PaperType_List.aspx'\n");
							stringBuilder.Append("}\n");
						}
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("},\n\n");
				}
				if (this.GetValidPower(m, "63|64|65") != "")
				{
					stringBuilder.Append("{\n");
					stringBuilder.Append("'menuid': '400001',\n");
					stringBuilder.Append("'menuname': '手机短信管理',\n");
					stringBuilder.Append("'icon': 'icon-phone',\n");
					stringBuilder.Append("'child': [\n");
					string validPower = this.GetValidPower(m, "63|64|65");
					if (validPower.Contains(":"))
					{
						string[] array = validPower.Split(new char[]
						{
							':'
						});
						for (int i = 0; i < array.Length; i++)
						{
							string a = array[i];
							if (i != array.Length - 1)
							{
								if (a == "63")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '400002',\n");
									stringBuilder.Append("'menuname': '短信发送记录',\n");
									stringBuilder.Append("'icon': 'icon-theme',\n");
									stringBuilder.Append("'url': '/Manage/sms/SMS_AllList.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "64")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '400003',\n");
									stringBuilder.Append("'menuname': '短信设置',\n");
									stringBuilder.Append("'icon': 'icon-settings',\n");
									stringBuilder.Append("'url': '/Manage/sms/SMS_SetUp.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "65")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '400006',\n");
									stringBuilder.Append("'menuname': '发送手机短信',\n");
									stringBuilder.Append("'icon': 'icon-phone',\n");
									stringBuilder.Append("'url': '/Manage/sms/SMS_Send.aspx'\n");
									stringBuilder.Append("},\n");
								}
							}
							else
							{
								if (a == "63")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '400002',\n");
									stringBuilder.Append("'menuname': '短信发送记录',\n");
									stringBuilder.Append("'icon': 'icon-theme',\n");
									stringBuilder.Append("'url': '/Manage/sms/SMS_AllList.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "64")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '400003',\n");
									stringBuilder.Append("'menuname': '短信设置',\n");
									stringBuilder.Append("'icon': 'icon-settings',\n");
									stringBuilder.Append("'url': '/Manage/sms/SMS_SetUp.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "65")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '400006',\n");
									stringBuilder.Append("'menuname': '发送手机短信',\n");
									stringBuilder.Append("'icon': 'icon-phone',\n");
									stringBuilder.Append("'url': '/Manage/sms/SMS_Send.aspx'\n");
									stringBuilder.Append("}\n");
								}
							}
						}
					}
					else
					{
						if (validPower == "63")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '400002',\n");
							stringBuilder.Append("'menuname': '短信发送记录',\n");
							stringBuilder.Append("'icon': 'icon-theme',\n");
							stringBuilder.Append("'url': '/Manage/sms/SMS_AllList.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "64")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '400003',\n");
							stringBuilder.Append("'menuname': '短信设置',\n");
							stringBuilder.Append("'icon': 'icon-settings',\n");
							stringBuilder.Append("'url': '/Manage/sms/SMS_SetUp.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "65")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '400006',\n");
							stringBuilder.Append("'menuname': '发送手机短信',\n");
							stringBuilder.Append("'icon': 'icon-phone',\n");
							stringBuilder.Append("'url': '/Manage/sms/SMS_Send.aspx'\n");
							stringBuilder.Append("}\n");
						}
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("},\n\n");
				}
				if (this.GetValidPower(m, "39|40") != "")
				{
					stringBuilder.Append("{\n");
					stringBuilder.Append("'menuid': '10008',\n");
					stringBuilder.Append("'menuname': '印章/签名管理',\n");
					stringBuilder.Append("'icon': 'icon-sitemap',\n");
					stringBuilder.Append("'child': [\n");
					string validPower = this.GetValidPower(m, "39|40");
					if (validPower.Contains(":"))
					{
						string[] array = validPower.Split(new char[]
						{
							':'
						});
						for (int i = 0; i < array.Length; i++)
						{
							string a = array[i];
							if (i != array.Length - 1)
							{
								if (a == "39")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100081',\n");
									stringBuilder.Append("'menuname': '印章/签名列表',\n");
									stringBuilder.Append("'icon': 'icon-img',\n");
									stringBuilder.Append("'url': '/Manage/Sys/Seal_List.aspx'\n");
									stringBuilder.Append("},\n");
								}
								if (a == "40")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100082',\n");
									stringBuilder.Append("'menuname': '新增印章/签名',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/manage/sys/Seal_Manage.aspx'\n");
									stringBuilder.Append("},\n");
								}
							}
							else
							{
								if (a == "39")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100081',\n");
									stringBuilder.Append("'menuname': '印章/签名列表',\n");
									stringBuilder.Append("'icon': 'icon-img',\n");
									stringBuilder.Append("'url': '/Manage/Sys/Seal_List.aspx'\n");
									stringBuilder.Append("}\n");
								}
								if (a == "40")
								{
									stringBuilder.Append("{\n");
									stringBuilder.Append("'menuid': '100082',\n");
									stringBuilder.Append("'menuname': '新增印章/签名',\n");
									stringBuilder.Append("'icon': 'icon-addnew',\n");
									stringBuilder.Append("'url': '/manage/sys/Seal_Manage.aspx'\n");
									stringBuilder.Append("}\n");
								}
							}
						}
					}
					else
					{
						if (validPower == "39")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100081',\n");
							stringBuilder.Append("'menuname': '印章/签名列表',\n");
							stringBuilder.Append("'icon': 'icon-img',\n");
							stringBuilder.Append("'url': '/Manage/Sys/Seal_List.aspx'\n");
							stringBuilder.Append("}\n");
						}
						if (validPower == "40")
						{
							stringBuilder.Append("{\n");
							stringBuilder.Append("'menuid': '100082',\n");
							stringBuilder.Append("'menuname': '新增印章/签名',\n");
							stringBuilder.Append("'icon': 'icon-addnew',\n");
							stringBuilder.Append("'url': '/manage/sys/Seal_Manage.aspx'\n");
							stringBuilder.Append("}\n");
						}
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("},\n\n");
				}
				if (m.Contains("45"))
				{
					stringBuilder.Append("{\n");
					stringBuilder.Append("'menuid': '11000',\n");
					stringBuilder.Append("'menuname': '投票管理',\n");
					stringBuilder.Append("'icon': 'icon-app',\n");
					stringBuilder.Append("'url': '/Manage/Common/Vote_AllList.aspx'\n");
					stringBuilder.Append("}\n");
					stringBuilder.Append(",\n\n");
				}
				if (m.Contains("48"))
				{
					stringBuilder.Append("{\n");
					stringBuilder.Append("'menuid': '11100',\n");
					stringBuilder.Append("'menuname': '系统登录记录',\n");
					stringBuilder.Append("'icon': 'icon-com',\n");
					stringBuilder.Append("'url': '/Manage/sys/User_LoginList.aspx'\n");
					stringBuilder.Append("}\n");
					stringBuilder.Append(",\n\n");
				}
				stringBuilder.Append("{\n");
				stringBuilder.Append("'menuid': '10009',\n");
				stringBuilder.Append("'menuname': '个人登陆记录',\n");
				stringBuilder.Append("'icon': 'icon-user1',\n");
				stringBuilder.Append("'url': '/manage/Common/User_LoginList.aspx'\n");
				stringBuilder.Append("}]\n");
				stringBuilder.Append("}\n");
				result = stringBuilder.ToString();
			}
			return result;
		}
		private string GetValidPower(string s, string arr)
		{
			string[] array = arr.Split(new char[]
			{
				'|'
			});
			List<string> list = new List<string>();
			for (int i = 0; i < array.Length; i++)
			{
				if (s.IndexOf(array[i]) != -1)
				{
					list.Add(array[i]);
				}
			}
			return string.Join(":", list.ToArray());
		}
	
}