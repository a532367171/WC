using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
public partial class Manage_Default1 : ViewPages

	{
        //protected HtmlHead Head1;
        //protected Literal message_div;
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
		protected string news_type1 = "";
        protected string wallpaper = "myLib.desktop.wallpaper.init('../Manage/themes/default/images/wallpaper.jpg');";
		private string ft = "'{0}': {{'WindowTitle': '{1}','iframSrc': '{2}','WindowWidth': mw}},";
		private string ft1 = "<li class='desktop_icon' id='{0}'> <span class='icon'><img src='icon/01/001.png'/></span> <div class='text'>{1}<s></s></div> </li>";
		protected void Page_Load(object sender, EventArgs e)
		{
			this.power_menu = this.GetUserPowerMenu(this.Modules);
			IList all = News_Type.Init().GetAll(null, " order by orders asc");
			for (int i = 0; i < all.Count; i++)
			{
				News_TypeInfo news_TypeInfo = all[i] as News_TypeInfo;
				this.news_type += string.Format(this.ft, "nn" + (i + 1), news_TypeInfo.TypeName, "News/News_List.aspx?tid=" + news_TypeInfo.id);
				this.news_type1 += string.Format(this.ft1, "nn" + (i + 1), news_TypeInfo.TypeName);
			}
			this.uid.Value = this.Uid;
			Bas_ComInfo bas_ComInfo = HttpContext.Current.Application["cominfo"] as Bas_ComInfo;
			this.comname = bas_ComInfo.ComName;
			this.weburl = bas_ComInfo.WebUrl;
			this.logo = bas_ComInfo.Logo;
			Sys_UserInfo byId = Sys_User.Init().GetById(Convert.ToInt32(this.Uid));
			byId.RoleGUID = (byId.RoleGUID ?? "");
			if (!string.IsNullOrEmpty(byId.RoleGUID) && byId.RoleGUID.ToLower().Contains(".jpg"))
			{
				this.wallpaper = "myLib.desktop.wallpaper.init('" + byId.RoleGUID + "');";
			}
			if (bas_ComInfo.MsgState != 1)
			{
				this.message_div.Visible = false;
			}
			else
			{
				try
				{
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
			}
		}
		private string GetUserPowerMenu(string m)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (string.IsNullOrEmpty(m))
			{
				stringBuilder.Append("myLib.desktop.startBtn.init([ \n");
				stringBuilder.Append("[{id:'pslogin1',text:'个人登录记录',icon:'icon/login.png',func:function(){runWin('个人登录记录','Common/User_LoginList.aspx','pslogin2');} }],\n[{id:'logout1',text:'安全退出',icon:'icon/out.png',func:function(){logout(); } }] ]);\n");
			}
			else
			{
				stringBuilder.Append("myLib.desktop.startBtn.init([ \n");
				if (this.GetValidPower(m, "14|43|21|22") != "")
				{
					stringBuilder.Append("[{\n");
					stringBuilder.Append("id: 'sys1',\n");
					stringBuilder.Append("text: '系统基础设置',\n");
					stringBuilder.Append("icon: 'icon/config.png',\n");
					stringBuilder.Append("func: function () { },\n");
					stringBuilder.Append("childItem: [\n");
					string validPower = this.GetValidPower(m, "14|21|22|43");
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
									stringBuilder.Append("[{id:'1014',text:'基本信息',icon:'icon/item0.png',func:function(){runWin('基本信息','sys/Com_Basic.aspx','d1014'); }}],\n");
								}
								if (a == "21")
								{
									stringBuilder.Append("[{id:'1021',text:'组织机构添加',icon:'icon/add.png',func:function(){runWin('组织机构添加','sys/Dep_Manage.aspx','d1021'); }}],\n");
								}
								if (a == "22")
								{
									stringBuilder.Append("[{id:'1022',text:'组织机构管理',icon:'icon/item0.png',func:function(){runWin('组织机构管理','sys/Dep_List.aspx','d1022'); }}],\n");
								}
								if (a == "43")
								{
									stringBuilder.Append("[{id:'1043',text:'数据库备份',icon:'icon/item0.png',func:function(){runWin('数据库备份','sys/DbBackup.aspx','d1043'); }}],\n");
								}
							}
							else
							{
								if (a == "14")
								{
									stringBuilder.Append("[{id:'1014',text:'基本信息',icon:'icon/item0.png',func:function(){runWin('基本信息','sys/Com_Basic.aspx','d1014'); }}]\n");
								}
								if (a == "21")
								{
									stringBuilder.Append("[{id:'1021',text:'组织机构添加',icon:'icon/add.png',func:function(){runWin('组织机构添加','sys/Dep_Manage.aspx','d1021'); }}]\n");
								}
								if (a == "22")
								{
									stringBuilder.Append("[{id:'1022',text:'组织机构管理',icon:'icon/item0.png',func:function(){runWin('组织机构管理','sys/Dep_List.aspx','d1022'); }}]\n");
								}
								if (a == "43")
								{
									stringBuilder.Append("[{id:'1043',text:'数据库备份',icon:'icon/item0.png',func:function(){runWin('数据库备份','sys/DbBackup.aspx','d1043'); }}]\n");
								}
							}
						}
					}
					else
					{
						if (validPower == "14")
						{
							stringBuilder.Append("[{id:'1014',text:'基本信息',icon:'icon/item0.png',func:function(){runWin('基本信息','sys/Com_Basic.aspx','d1014'); }}]\n");
						}
						if (validPower == "21")
						{
							stringBuilder.Append("[{id:'1021',text:'组织机构添加',icon:'icon/add.png',func:function(){runWin('组织机构添加','sys/Dep_Manage.aspx','d1021'); }}]\n");
						}
						if (validPower == "22")
						{
							stringBuilder.Append("[{id:'1022',text:'组织机构管理',icon:'icon/item0.png',func:function(){runWin('组织机构管理','sys/Dep_List.aspx','d1022'); }}]\n");
						}
						if (validPower == "43")
						{
							stringBuilder.Append("[{id:'1043',text:'数据库备份',icon:'icon/item0.png',func:function(){runWin('数据库备份','sys/DbBackup.aspx','d1043'); }}]\n");
						}
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("}],\n\n");
				}
				if (this.GetValidPower(m, "19|20|17|18|46|47") != "")
				{
					stringBuilder.Append("[{\n");
					stringBuilder.Append("id: 'user1',\n");
					stringBuilder.Append("text: '人事管理',\n");
					stringBuilder.Append("icon: 'icon/users.png',\n");
					stringBuilder.Append("func: function () { },\n");
					stringBuilder.Append("childItem: [\n");
					string validPower = this.GetValidPower(m, "19|20|17|18|46|47");
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
								if (a == "19")
								{
									stringBuilder.Append("[{id:'1019',text:'新增用户',icon:'icon/add.png',func:function(){runWin('新增用户','sys/User_Manage.aspx','d1019'); }}],\n");
								}
								if (a == "20")
								{
									stringBuilder.Append("[{id:'1020',text:'用户列表',icon:'icon/item0.png',func:function(){runWin('用户列表','sys/User_List.aspx','d1020'); }}],\n");
								}
								if (a == "17")
								{
									stringBuilder.Append("[{id:'1017',text:'新增角色',icon:'icon/add.png',func:function(){runWin('新增角色','sys/Role_Manage.aspx','d1017'); }}],\n");
								}
								if (a == "18")
								{
									stringBuilder.Append("[{id:'1018',text:'角色列表',icon:'icon/item0.png',func:function(){runWin('角色列表','sys/Role_List.aspx','d1018'); }}],\n");
								}
								if (a == "46")
								{
									stringBuilder.Append("[{id:'1046',text:'设置考勤时间',icon:'icon/item0.png',func:function(){runWin('设置考勤时间','Attend/WorkSet.aspx?type=edit','d1046'); }}],\n");
								}
								if (a == "47")
								{
									stringBuilder.Append("[{id:'1047',text:'考勤统计',icon:'icon/item0.png',func:function(){runWin('考勤统计','Attend/WorkList.aspx?type=1','d1047'); }}],\n");
								}
							}
							else
							{
								if (a == "19")
								{
									stringBuilder.Append("[{id:'1019',text:'新增用户',icon:'icon/add.png',func:function(){runWin('新增用户','sys/User_Manage.aspx','d1019'); }}]\n");
								}
								if (a == "20")
								{
									stringBuilder.Append("[{id:'1020',text:'用户列表',icon:'icon/item0.png',func:function(){runWin('用户列表','sys/User_List.aspx','d1020'); }}]\n");
								}
								if (a == "17")
								{
									stringBuilder.Append("[{id:'1017',text:'新增角色',icon:'icon/add.png',func:function(){runWin('新增角色','sys/Role_Manage.aspx','d1017'); }}]\n");
								}
								if (a == "18")
								{
									stringBuilder.Append("[{id:'1018',text:'角色列表',icon:'icon/item0.png',func:function(){runWin('角色列表','sys/Role_List.aspx','d1018'); }}]\n");
								}
								if (a == "46")
								{
									stringBuilder.Append("[{id:'1046',text:'设置考勤时间',icon:'icon/item0.png',func:function(){runWin('设置考勤时间','Attend/WorkSet.aspx?type=edit','d1046'); }}]\n");
								}
								if (a == "47")
								{
									stringBuilder.Append("[{id:'1047',text:'考勤统计',icon:'icon/item0.png',func:function(){runWin('考勤统计','Attend/WorkList.aspx?type=1','d1047'); }}]\n");
								}
							}
						}
					}
					else
					{
						if (validPower == "19")
						{
							stringBuilder.Append("[{id:'1019',text:'新增用户',icon:'icon/add.png',func:function(){runWin('新增用户','sys/User_Manage.aspx','d1019'); }}]\n");
						}
						if (validPower == "20")
						{
							stringBuilder.Append("[{id:'1020',text:'用户列表',icon:'icon/item0.png',func:function(){runWin('用户列表','sys/User_List.aspx','d1020'); }}]\n");
						}
						if (validPower == "17")
						{
							stringBuilder.Append("[{id:'1017',text:'新增角色',icon:'icon/add.png',func:function(){runWin('新增角色','sys/Role_Manage.aspx','d1017'); }}]\n");
						}
						if (validPower == "18")
						{
							stringBuilder.Append("[{id:'1018',text:'角色列表',icon:'icon/item0.png',func:function(){runWin('角色列表','sys/Role_List.aspx','d1018'); }}]\n");
						}
						if (validPower == "46")
						{
							stringBuilder.Append("[{id:'1046',text:'设置考勤时间',icon:'icon/item0.png',func:function(){runWin('设置考勤时间','Attend/WorkSet.aspx?type=edit','d1046'); }}]\n");
						}
						if (validPower == "47")
						{
							stringBuilder.Append("[{id:'1047',text:'考勤统计',icon:'icon/item0.png',func:function(){runWin('考勤统计','Attend/WorkList.aspx?type=1','d1047'); }}]\n");
						}
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("}],\n\n");
				}
				if (this.GetValidPower(m, "29|30|31|32|41|42") != "")
				{
					stringBuilder.Append("[{\n");
					stringBuilder.Append("id: 'news1',\n");
					stringBuilder.Append("text: '资讯管理',\n");
					stringBuilder.Append("icon: 'icon/news.png',\n");
					stringBuilder.Append("func: function () { },\n");
					stringBuilder.Append("childItem: [\n");
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
									stringBuilder.Append("[{id:'1029',text:'所有资讯列表',icon:'icon/item0.png',func:function(){runWin('所有资讯列表','news/News_AllList.aspx','d1029'); }}],\n");
								}
								if (a == "30")
								{
									stringBuilder.Append("[{id:'1030',text:'发布资讯',icon:'icon/add.png',func:function(){runWin('发布资讯','news/News_Manage.aspx','d1030'); }}],\n");
								}
								if (a == "31")
								{
									stringBuilder.Append("[{id:'1031',text:'资讯分类列表',icon:'icon/item0.png',func:function(){runWin('资讯分类列表','news/NewsType_List.aspx','d1031'); }}],\n");
								}
								if (a == "32")
								{
									stringBuilder.Append("[{id:'1032',text:'添加资讯分类',icon:'icon/add.png',func:function(){runWin('添加资讯分类','news/NewsType_Manage.aspx','d1032'); }}],\n");
								}
								if (a == "42")
								{
									stringBuilder.Append("[{id:'1042',text:'滚动公告列表',icon:'icon/item0.png',func:function(){runWin('滚动公告列表','news/Tips_List.aspx','d1042'); }}],\n");
								}
								if (a == "41")
								{
									stringBuilder.Append("[{id:'1041',text:'添加滚动公告',icon:'icon/add.png',func:function(){runWin('添加滚动公告','news/Tips_Manage.aspx','d1041'); }}],\n");
								}
							}
							else
							{
								if (a == "29")
								{
									stringBuilder.Append("[{id:'1029',text:'所有资讯列表',icon:'icon/item0.png',func:function(){runWin('所有资讯列表','news/News_AllList.aspx','d1029'); }}]\n");
								}
								if (a == "30")
								{
									stringBuilder.Append("[{id:'1030',text:'发布资讯',icon:'icon/add.png',func:function(){runWin('发布资讯','news/News_Manage.aspx','d1030'); }}]\n");
								}
								if (a == "31")
								{
									stringBuilder.Append("[{id:'1031',text:'资讯分类列表',icon:'icon/item0.png',func:function(){runWin('资讯分类列表','news/NewsType_List.aspx','d1031'); }}]\n");
								}
								if (a == "32")
								{
									stringBuilder.Append("[{id:'1032',text:'添加资讯分类',icon:'icon/add.png',func:function(){runWin('添加资讯分类','news/NewsType_Manage.aspx','d1032'); }}]\n");
								}
								if (a == "42")
								{
									stringBuilder.Append("[{id:'1042',text:'滚动公告列表',icon:'icon/item0.png',func:function(){runWin('滚动公告列表','news/Tips_List.aspx','d1042'); }}]\n");
								}
								if (a == "41")
								{
									stringBuilder.Append("[{id:'1041',text:'添加滚动公告',icon:'icon/add.png',func:function(){runWin('添加滚动公告','news/Tips_Manage.aspx','d1041'); }}]\n");
								}
							}
						}
					}
					else
					{
						if (validPower == "29")
						{
							stringBuilder.Append("[{id:'1029',text:'所有资讯列表',icon:'icon/item0.png',func:function(){runWin('所有资讯列表','news/News_AllList.aspx','d1029'); }}]\n");
						}
						if (validPower == "30")
						{
							stringBuilder.Append("[{id:'1030',text:'发布资讯',icon:'icon/add.png',func:function(){runWin('发布资讯','news/News_Manage.aspx','d1030'); }}]\n");
						}
						if (validPower == "31")
						{
							stringBuilder.Append("[{id:'1031',text:'资讯分类列表',icon:'icon/item0.png',func:function(){runWin('资讯分类列表','news/NewsType_List.aspx','d1031'); }}]\n");
						}
						if (validPower == "32")
						{
							stringBuilder.Append("[{id:'1032',text:'添加资讯分类',icon:'icon/add.png',func:function(){runWin('添加资讯分类','news/NewsType_Manage.aspx','d1032'); }}]\n");
						}
						if (validPower == "42")
						{
							stringBuilder.Append("[{id:'1042',text:'滚动公告列表',icon:'icon/item0.png',func:function(){runWin('滚动公告列表','news/Tips_List.aspx','d1042'); }}]\n");
						}
						if (validPower == "41")
						{
							stringBuilder.Append("[{id:'1041',text:'添加滚动公告',icon:'icon/add.png',func:function(){runWin('添加滚动公告','news/Tips_Manage.aspx','d1041'); }}]\n");
						}
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("}],\n\n");
				}
				if (this.GetValidPower(m, "24|25|26|27|57|58|28") != "")
				{
					stringBuilder.Append("[{\n");
					stringBuilder.Append("id: 'flow1',\n");
					stringBuilder.Append("text: '流程管理',\n");
					stringBuilder.Append("icon: 'icon/flow.png',\n");
					stringBuilder.Append("func: function () { },\n");
					stringBuilder.Append("childItem: [\n");
					string validPower2 = this.GetValidPower(m, "24|25");
					string validPower3 = this.GetValidPower(m, "26|27");
					string validPower4 = this.GetValidPower(m, "58|57");
					if (validPower2 != "")
					{
						stringBuilder.Append("[{\n");
						stringBuilder.Append("id: 'flowmodel1',\n");
						stringBuilder.Append("text: '流程模型管理',\n");
						stringBuilder.Append("icon: 'icon/item3.png',\n");
						stringBuilder.Append("func: function () { },\n");
						stringBuilder.Append("childItem: [\n");
						if (validPower2.Contains(":"))
						{
							string[] array = validPower2.Split(new char[]
							{
								':'
							});
							for (int i = 0; i < array.Length; i++)
							{
								string a = array[i];
								if (a == "24")
								{
									stringBuilder.Append("[{id:'1024',text:'流程模型列表',icon:'icon/item0.png',func:function(){runWin('流程模型列表','Flow/Flow_ModelList.aspx','d1024'); }}],\n");
								}
								if (a == "25")
								{
									stringBuilder.Append("[{id:'1025',text:'新增流程模型',icon:'icon/add.png',func:function(){runWin('新增流程模型','Flow/Flow_ModelManage.aspx','d1025'); }}]\n");
								}
							}
						}
						else
						{
							if (validPower2 == "24")
							{
								stringBuilder.Append("[{id:'1024',text:'流程模型列表',icon:'icon/item0.png',func:function(){runWin('流程模型列表','Flow/Flow_ModelList.aspx','d1024'); }}]\n");
							}
							if (validPower2 == "25")
							{
								stringBuilder.Append("[{id:'1025',text:'新增流程模型',icon:'icon/add.png',func:function(){runWin('新增流程模型','Flow/Flow_ModelManage.aspx','d1025'); }}]\n");
							}
						}
						string validPower5 = this.GetValidPower(m, "26|27|58|57|28");
						if (validPower5 != "")
						{
							stringBuilder.Append("]\n");
							stringBuilder.Append("}],\n\n");
						}
						else
						{
							stringBuilder.Append("]\n");
							stringBuilder.Append("}]\n\n");
						}
					}
					if (validPower3 != "")
					{
						stringBuilder.Append("[{\n");
						stringBuilder.Append("id: 'flowmodel2',\n");
						stringBuilder.Append("text: '模板表单管理',\n");
						stringBuilder.Append("icon: 'icon/item3.png',\n");
						stringBuilder.Append("func: function () { },\n");
						stringBuilder.Append("childItem: [\n");
						if (validPower3.Contains(":"))
						{
							string[] array = validPower3.Split(new char[]
							{
								':'
							});
							for (int i = 0; i < array.Length; i++)
							{
								string a = array[i];
								if (a == "26")
								{
									stringBuilder.Append("[{id:'1026',text:'模板表单列表',icon:'icon/item0.png',func:function(){runWin('模板表单列表','Flow/Flow_ModelFileList.aspx','d1026'); }}],\n");
								}
								if (a == "27")
								{
									stringBuilder.Append("[{id:'1027',text:'新增模板表单',icon:'icon/add.png',func:function(){runWin('新增模板表单','Flow/Flow_ModelFileManage.aspx','d1027'); }}]\n");
								}
							}
						}
						else
						{
							if (validPower3 == "26")
							{
								stringBuilder.Append("[{id:'1026',text:'模板表单列表',icon:'icon/item0.png',func:function(){runWin('模板表单列表','Flow/Flow_ModelFileList.aspx','d1026'); }}]\n");
							}
							if (validPower3 == "27")
							{
								stringBuilder.Append("[{id:'1027',text:'新增模板表单',icon:'icon/add.png',func:function(){runWin('新增模板表单','Flow/Flow_ModelFileManage.aspx','d1027'); }}]\n");
							}
						}
						string validPower5 = this.GetValidPower(m, "57|58|28");
						if (validPower5 != "")
						{
							stringBuilder.Append("]\n");
							stringBuilder.Append("}],\n\n");
						}
						else
						{
							stringBuilder.Append("]\n");
							stringBuilder.Append("}]\n\n");
						}
					}
					if (validPower4 != "")
					{
						stringBuilder.Append("[{\n");
						stringBuilder.Append("id: 'flowtype1',\n");
						stringBuilder.Append("text: '流程模型分类',\n");
						stringBuilder.Append("icon: 'icon/item3.png',\n");
						stringBuilder.Append("func: function () { },\n");
						stringBuilder.Append("childItem: [\n");
						if (validPower4.Contains(":"))
						{
							string[] array = validPower4.Split(new char[]
							{
								':'
							});
							for (int i = 0; i < array.Length; i++)
							{
								string a = array[i];
								if (a == "58")
								{
									stringBuilder.Append("[{id:'1058',text:'模型分类列表',icon:'icon/item0.png',func:function(){runWin('模型分类列表','Flow/FlowType_List.aspx','d1058'); }}],\n");
								}
								if (a == "57")
								{
									stringBuilder.Append("[{id:'1057',text:'新增模型分类',icon:'icon/add.png',func:function(){runWin('新增模型分类','Flow/FlowType_Manage.aspx','d1057'); }}]\n");
								}
							}
						}
						else
						{
							if (validPower4 == "58")
							{
								stringBuilder.Append("[{id:'1058',text:'模型分类列表',icon:'icon/item0.png',func:function(){runWin('模型分类列表','Flow/FlowType_List.aspx','d1058'); }}]\n");
							}
							if (validPower4 == "57")
							{
								stringBuilder.Append("[{id:'1057',text:'新增模型分类',icon:'icon/add.png',func:function(){runWin('新增模型分类','Flow/FlowType_Manage.aspx','d1057'); }}]\n");
							}
						}
						string validPower5 = this.GetValidPower(m, "28");
						if (validPower5 != "")
						{
							stringBuilder.Append("]\n");
							stringBuilder.Append("}],\n\n");
						}
						else
						{
							stringBuilder.Append("]\n");
							stringBuilder.Append("}]\n\n");
						}
					}
					if (this.GetValidPower(m, "28") == "28")
					{
						stringBuilder.Append("[{id:'1028',text:'所有流程监控',icon:'icon/item0.png',func:function(){runWin('所有流程监控','flow/Flow_ListAll.aspx','d1028'); }}]\n");
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("}],\n\n");
				}
				if (this.GetValidPower(m, "44|34|35|36|37|59|60|38") != "")
				{
					stringBuilder.Append("[{\n");
					stringBuilder.Append("id: 'gov1',\n");
					stringBuilder.Append("text: '公文管理',\n");
					stringBuilder.Append("icon: 'icon/gov.png',\n");
					stringBuilder.Append("func: function () { },\n");
					stringBuilder.Append("childItem: [\n");
					string validPower = this.GetValidPower(m, "44|34|35|36|37|38|59|60");
					if (validPower.Contains("44"))
					{
						stringBuilder.Append("[{id:'1044',text:'发文拟稿',icon:'icon/add.png',func:function(){runWin('发文拟稿','gov/Gov_Manage.aspx','d1044'); }}]\n");
						string validPower5 = this.GetValidPower(m, "34|35|36|37|38|59|60");
						if (validPower5 != "")
						{
							stringBuilder.Append(",\n");
						}
					}
					string validPower2 = this.GetValidPower(m, "34|35");
					string validPower3 = this.GetValidPower(m, "36|37");
					string validPower4 = this.GetValidPower(m, "60|59");
					if (validPower2 != "")
					{
						stringBuilder.Append("[{\n");
						stringBuilder.Append("id: 'govmodel1',\n");
						stringBuilder.Append("text: '公文模型管理',\n");
						stringBuilder.Append("icon: 'icon/item3.png',\n");
						stringBuilder.Append("func: function () { },\n");
						stringBuilder.Append("childItem: [\n");
						if (validPower2.Contains(":"))
						{
							string[] array = validPower2.Split(new char[]
							{
								':'
							});
							for (int i = 0; i < array.Length; i++)
							{
								string a = array[i];
								if (a == "34")
								{
									stringBuilder.Append("[{id:'1034',text:'公文模型列表',icon:'icon/item0.png',func:function(){runWin('公文模型列表','gov/gov_ModelList.aspx','d1034'); }}],\n");
								}
								if (a == "35")
								{
									stringBuilder.Append("[{id:'1035',text:'新增公文模型',icon:'icon/add.png',func:function(){runWin('新增公文模型','gov/gov_ModelManage.aspx','d1035'); }}]\n");
								}
							}
						}
						else
						{
							if (validPower2 == "34")
							{
								stringBuilder.Append("[{id:'1034',text:'公文模型列表',icon:'icon/item0.png',func:function(){runWin('公文模型列表','gov/gov_ModelList.aspx','d1034'); }}]\n");
							}
							if (validPower2 == "35")
							{
								stringBuilder.Append("[{id:'1035',text:'新增公文模型',icon:'icon/add.png',func:function(){runWin('新增公文模型','gov/gov_ModelManage.aspx','d1035'); }}]\n");
							}
						}
						string validPower5 = this.GetValidPower(m, "36|37|38|59|60");
						if (validPower5 != "")
						{
							stringBuilder.Append("]\n");
							stringBuilder.Append("}],\n\n");
						}
						else
						{
							stringBuilder.Append("]\n");
							stringBuilder.Append("}]\n\n");
						}
					}
					if (validPower3 != "")
					{
						stringBuilder.Append("[{\n");
						stringBuilder.Append("id: 'govmodel2',\n");
						stringBuilder.Append("text: '模板表单管理',\n");
						stringBuilder.Append("icon: 'icon/item3.png',\n");
						stringBuilder.Append("func: function () { },\n");
						stringBuilder.Append("childItem: [\n");
						if (validPower3.Contains(":"))
						{
							string[] array = validPower3.Split(new char[]
							{
								':'
							});
							for (int i = 0; i < array.Length; i++)
							{
								string a = array[i];
								if (a == "36")
								{
									stringBuilder.Append("[{id:'1036',text:'公文表单列表',icon:'icon/item0.png',func:function(){runWin('公文表单列表','gov/gov_ModelFileList.aspx','d1036'); }}],\n");
								}
								if (a == "37")
								{
									stringBuilder.Append("[{id:'1037',text:'新增公文表单',icon:'icon/add.png',func:function(){runWin('新增公文表单','gov/gov_ModelFileManage.aspx','d1037'); }}]\n");
								}
							}
						}
						else
						{
							if (validPower3 == "36")
							{
								stringBuilder.Append("[{id:'1036',text:'公文表单列表',icon:'icon/item0.png',func:function(){runWin('公文表单列表','gov/gov_ModelFileList.aspx','d1036'); }}]\n");
							}
							if (validPower3 == "37")
							{
								stringBuilder.Append("[{id:'1037',text:'新增公文表单',icon:'icon/add.png',func:function(){runWin('新增公文表单','gov/gov_ModelFileManage.aspx','d1037'); }}]\n");
							}
						}
						string validPower5 = this.GetValidPower(m, "38|59|60");
						if (validPower5 != "")
						{
							stringBuilder.Append("]\n");
							stringBuilder.Append("}],\n\n");
						}
						else
						{
							stringBuilder.Append("]\n");
							stringBuilder.Append("}]\n\n");
						}
					}
					if (validPower4 != "")
					{
						stringBuilder.Append("[{\n");
						stringBuilder.Append("id: 'govtype1',\n");
						stringBuilder.Append("text: '公文模型分类',\n");
						stringBuilder.Append("icon: 'icon/item3.png',\n");
						stringBuilder.Append("func: function () { },\n");
						stringBuilder.Append("childItem: [\n");
						if (validPower4.Contains(":"))
						{
							string[] array = validPower4.Split(new char[]
							{
								':'
							});
							for (int i = 0; i < array.Length; i++)
							{
								string a = array[i];
								if (a == "60")
								{
									stringBuilder.Append("[{id:'1060',text:'公文分类列表',icon:'icon/item0.png',func:function(){runWin('公文分类列表','Gov/GovType_List.aspx','d1060'); }}],\n");
								}
								if (a == "59")
								{
									stringBuilder.Append("[{id:'1059',text:'新增公文分类',icon:'icon/add.png',func:function(){runWin('新增公文分类','Gov/GovType_Manage.aspx','d1059'); }}]\n");
								}
							}
						}
						else
						{
							if (validPower4 == "60")
							{
								stringBuilder.Append("[{id:'1060',text:'公文分类列表',icon:'icon/item0.png',func:function(){runWin('公文分类列表','Gov/GovType_List.aspx','d1060'); }}]\n");
							}
							if (validPower4 == "59")
							{
								stringBuilder.Append("[{id:'1059',text:'新增公文分类',icon:'icon/add.png',func:function(){runWin('新增公文分类','Gov/GovType_Manage.aspx','d1059'); }}]\n");
							}
						}
						string validPower5 = this.GetValidPower(m, "38");
						if (validPower5 != "")
						{
							stringBuilder.Append("]\n");
							stringBuilder.Append("}],\n\n");
						}
						else
						{
							stringBuilder.Append("]\n");
							stringBuilder.Append("}]\n\n");
						}
					}
					if (this.GetValidPower(m, "38") == "38")
					{
						stringBuilder.Append("[{id:'1038',text:'所有公文监控',icon:'icon/item0.png',func:function(){runWin('所有公文监控','gov/gov_ListAll.aspx','d1038'); }}]\n");
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("}],\n\n");
				}
				if (this.GetValidPower(m, "49|50|51") != "")
				{
					stringBuilder.Append("[{\n");
					stringBuilder.Append("id: 'work1',\n");
					stringBuilder.Append("text: '工作任务管理',\n");
					stringBuilder.Append("icon: 'icon/task.png',\n");
					stringBuilder.Append("func: function () { },\n");
					stringBuilder.Append("childItem: [\n");
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
									stringBuilder.Append("[{id:'1049',text:'工作任务分类',icon:'icon/item0.png',func:function(){runWin('工作任务分类','Tasks/TaskType_List.aspx','d1049'); }}],\n");
								}
								if (a == "50")
								{
									stringBuilder.Append("[{id:'1050',text:'新增任务分类',icon:'icon/add.png',func:function(){runWin('新增任务分类','Tasks/TaskType_Manage.aspx','d1050'); }}],\n");
								}
								if (a == "51")
								{
									stringBuilder.Append("[{id:'1051',text:'所有工作任务',icon:'icon/item0.png',func:function(){runWin('所有工作任务','Tasks/Task_AllList.aspx','d1051'); }}],\n");
								}
							}
							else
							{
								if (a == "49")
								{
									stringBuilder.Append("[{id:'1049',text:'工作任务分类',icon:'icon/item0.png',func:function(){runWin('工作任务分类','Tasks/TaskType_List.aspx','d1049'); }}]\n");
								}
								if (a == "50")
								{
									stringBuilder.Append("[{id:'1050',text:'新增任务分类',icon:'icon/add.png',func:function(){runWin('新增任务分类','Tasks/TaskType_Manage.aspx','d1050'); }}]\n");
								}
								if (a == "51")
								{
									stringBuilder.Append("[{id:'1051',text:'所有工作任务',icon:'icon/item0.png',func:function(){runWin('所有工作任务','Tasks/Task_AllList.aspx','d1051'); }}]\n");
								}
							}
						}
					}
					else
					{
						if (validPower == "49")
						{
							stringBuilder.Append("[{id:'1049',text:'工作任务分类',icon:'icon/item0.png',func:function(){runWin('工作任务分类','Tasks/TaskType_List.aspx','d1049'); }}]\n");
						}
						if (validPower == "50")
						{
							stringBuilder.Append("[{id:'1050',text:'新增任务分类',icon:'icon/add.png',func:function(){runWin('新增任务分类','Tasks/TaskType_Manage.aspx','d1050'); }}]\n");
						}
						if (validPower == "51")
						{
							stringBuilder.Append("[{id:'1051',text:'所有工作任务',icon:'icon/item0.png',func:function(){runWin('所有工作任务','Tasks/Task_AllList.aspx','d1051'); }}]\n");
						}
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("}],\n\n");
				}
				if (this.GetValidPower(m, "63|64|65") != "")
				{
					stringBuilder.Append("[{\n");
					stringBuilder.Append("id: 'sms1',\n");
					stringBuilder.Append("text: '手机短信管理',\n");
					stringBuilder.Append("icon: 'icon/sms.png',\n");
					stringBuilder.Append("func: function () { },\n");
					stringBuilder.Append("childItem: [\n");
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
									stringBuilder.Append("[{id:'1063',text:'短信发送记录',icon:'icon/item0.png',func:function(){runWin('短信发送记录','/Manage/sms/SMS_AllList.aspx','d1063'); }}],\n");
								}
								if (a == "64")
								{
									stringBuilder.Append("[{id:'1064',text:'短信设置',icon:'icon/item0.png',func:function(){runWin('短信设置','/Manage/sms/SMS_SetUp.aspx','d1064'); }}],\n");
								}
								if (a == "65")
								{
									stringBuilder.Append("[{id:'1065',text:'发送手机短信',icon:'icon/add.png',func:function(){runWin('发送手机短信','/Manage/sms/SMS_Send.aspx','d1065'); }}],\n");
								}
							}
							else
							{
								if (a == "63")
								{
									stringBuilder.Append("[{id:'1063',text:'短信发送记录',icon:'icon/item0.png',func:function(){runWin('短信发送记录','/Manage/sms/SMS_AllList.aspx','d1063'); }}]\n");
								}
								if (a == "64")
								{
									stringBuilder.Append("[{id:'1064',text:'短信设置',icon:'icon/item0.png',func:function(){runWin('短信设置','/Manage/sms/SMS_SetUp.aspx','d1064'); }}]\n");
								}
								if (a == "65")
								{
									stringBuilder.Append("[{id:'1065',text:'发送手机短信',icon:'icon/add.png',func:function(){runWin('发送手机短信','/Manage/sms/SMS_Send.aspx','d1065'); }}]\n");
								}
							}
						}
					}
					else
					{
						if (validPower == "63")
						{
							stringBuilder.Append("[{id:'1063',text:'短信发送记录',icon:'icon/item0.png',func:function(){runWin('短信发送记录','/Manage/sms/SMS_AllList.aspx','d1063'); }}]\n");
						}
						if (validPower == "64")
						{
							stringBuilder.Append("[{id:'1064',text:'短信设置',icon:'icon/item0.png',func:function(){runWin('短信设置','/Manage/sms/SMS_SetUp.aspx','d1064'); }}]\n");
						}
						if (validPower == "65")
						{
							stringBuilder.Append("[{id:'1065',text:'发送手机短信',icon:'icon/add.png',func:function(){runWin('发送手机短信','/Manage/sms/SMS_Send.aspx','d1065'); }}]\n");
						}
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("}],\n\n");
				}
				if (this.GetValidPower(m, "52|53|54|55|56|39|40|45|48") != "")
				{
					stringBuilder.Append("[{\n");
					stringBuilder.Append("id: 'other1',\n");
					stringBuilder.Append("text: '其他功能管理',\n");
					stringBuilder.Append("icon: 'icon/other.png',\n");
					stringBuilder.Append("func: function () { },\n");
					stringBuilder.Append("childItem: [\n");
					string validPower2 = this.GetValidPower(m, "52|55|54|53|56");
					string validPower3 = this.GetValidPower(m, "39|40");
					if (validPower2 != "")
					{
						stringBuilder.Append("[{\n");
						stringBuilder.Append("id: 'paper1',\n");
						stringBuilder.Append("text: '电子档案管理',\n");
						stringBuilder.Append("icon: 'icon/item3.png',\n");
						stringBuilder.Append("func: function () { },\n");
						stringBuilder.Append("childItem: [\n");
						if (validPower2.Contains(":"))
						{
							string[] array = validPower2.Split(new char[]
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
										stringBuilder.Append("[{id:'1052',text:'新增电子档案',icon:'icon/add.png',func:function(){runWin('新增电子档案','Paper/PaperManage.aspx','d1052'); }}],\n");
									}
									if (a == "55")
									{
										stringBuilder.Append("[{id:'1055',text:'电子档案分类',icon:'icon/item0.png',func:function(){runWin('电子档案分类','Paper/PaperType_List.aspx','d1055'); }}],\n");
									}
									if (a == "54")
									{
										stringBuilder.Append("[{id:'1054',text:'新增档案分类',icon:'icon/add.png',func:function(){runWin('新增档案分类','Paper/PaperType_Manage.aspx','d1054'); }}],\n");
									}
									if (a == "53")
									{
										stringBuilder.Append("[{id:'1053',text:'所有电子档案',icon:'icon/item0.png',func:function(){runWin('所有电子档案','Paper/PaperAllList.aspx','d1053'); }}],\n");
									}
									if (a == "56")
									{
										stringBuilder.Append("[{id:'1056',text:'档案下载记录',icon:'icon/item0.png',func:function(){runWin('档案下载记录','Paper/DownLoadList.aspx','d1056'); }}],\n");
									}
								}
								else
								{
									if (a == "52")
									{
										stringBuilder.Append("[{id:'1052',text:'新增电子档案',icon:'icon/add.png',func:function(){runWin('新增电子档案','Paper/PaperManage.aspx','d1052'); }}]\n");
									}
									if (a == "55")
									{
										stringBuilder.Append("[{id:'1055',text:'电子档案分类',icon:'icon/item0.png',func:function(){runWin('电子档案分类','Paper/PaperType_List.aspx','d1055'); }}]\n");
									}
									if (a == "54")
									{
										stringBuilder.Append("[{id:'1054',text:'新增档案分类',icon:'icon/add.png',func:function(){runWin('新增档案分类','Paper/PaperType_Manage.aspx','d1054'); }}]\n");
									}
									if (a == "53")
									{
										stringBuilder.Append("[{id:'1053',text:'所有电子档案',icon:'icon/item0.png',func:function(){runWin('所有电子档案','Paper/PaperAllList.aspx','d1053'); }}]\n");
									}
									if (a == "56")
									{
										stringBuilder.Append("[{id:'1056',text:'档案下载记录',icon:'icon/item0.png',func:function(){runWin('档案下载记录','Paper/DownLoadList.aspx','d1056'); }}]\n");
									}
								}
							}
						}
						else
						{
							if (validPower2 == "52")
							{
								stringBuilder.Append("[{id:'1052',text:'新增电子档案',icon:'icon/add.png',func:function(){runWin('新增电子档案','Paper/PaperManage.aspx','d1052'); }}]\n");
							}
							if (validPower2 == "55")
							{
								stringBuilder.Append("[{id:'1055',text:'电子档案分类',icon:'icon/item0.png',func:function(){runWin('电子档案分类','Paper/PaperType_List.aspx','d1055'); }}]\n");
							}
							if (validPower2 == "54")
							{
								stringBuilder.Append("[{id:'1054',text:'新增档案分类',icon:'icon/add.png',func:function(){runWin('新增档案分类','Paper/PaperType_Manage.aspx','d1054'); }}]\n");
							}
							if (validPower2 == "53")
							{
								stringBuilder.Append("[{id:'1053',text:'所有电子档案',icon:'icon/item0.png',func:function(){runWin('所有电子档案','Paper/PaperAllList.aspx','d1053'); }}]\n");
							}
							if (validPower2 == "56")
							{
								stringBuilder.Append("[{id:'1056',text:'档案下载记录',icon:'icon/item0.png',func:function(){runWin('档案下载记录','Paper/DownLoadList.aspx','d1056'); }}]\n");
							}
						}
						string validPower5 = this.GetValidPower(m, "39|40|45|48");
						if (validPower5 != "")
						{
							stringBuilder.Append("]\n");
							stringBuilder.Append("}],\n\n");
						}
						else
						{
							stringBuilder.Append("]\n");
							stringBuilder.Append("}]\n\n");
						}
					}
					if (validPower3 != "")
					{
						stringBuilder.Append("[{\n");
						stringBuilder.Append("id: 'sign1',\n");
						stringBuilder.Append("text: '印章签名管理',\n");
						stringBuilder.Append("icon: 'icon/item3.png',\n");
						stringBuilder.Append("func: function () { },\n");
						stringBuilder.Append("childItem: [\n");
						if (validPower3.Contains(":"))
						{
							string[] array = validPower3.Split(new char[]
							{
								':'
							});
							for (int i = 0; i < array.Length; i++)
							{
								string a = array[i];
								if (a == "39")
								{
									stringBuilder.Append("[{id:'1039',text:'印章签名列表',icon:'icon/item0.png',func:function(){runWin('印章签名列表','Sys/Seal_List.aspx','d1039'); }}],\n");
								}
								if (a == "40")
								{
									stringBuilder.Append("[{id:'1040',text:'新增印章签名',icon:'icon/add.png',func:function(){runWin('新增印章签名','sys/Seal_Manage.aspx','d1040'); }}]\n");
								}
							}
						}
						else
						{
							if (validPower3 == "39")
							{
								stringBuilder.Append("[{id:'1039',text:'印章签名列表',icon:'icon/item0.png',func:function(){runWin('印章签名列表','Sys/Seal_List.aspx','d1039'); }}]\n");
							}
							if (validPower3 == "40")
							{
								stringBuilder.Append("[{id:'1040',text:'新增印章签名',icon:'icon/add.png',func:function(){runWin('新增印章签名','sys/Seal_Manage.aspx','d1040'); }}]\n");
							}
						}
						string validPower5 = this.GetValidPower(m, "45|48");
						if (validPower5 != "")
						{
							stringBuilder.Append("]\n");
							stringBuilder.Append("}],\n\n");
						}
						else
						{
							stringBuilder.Append("]\n");
							stringBuilder.Append("}]\n\n");
						}
					}
					if (this.GetValidPower(m, "45") == "45")
					{
						if (this.GetValidPower(m, "48") != "")
						{
							stringBuilder.Append("[{id:'1045',text:'投票管理',icon:'icon/item0.png',func:function(){runWin('投票管理','Common/Vote_AllList.aspx','d1045'); }}],\n");
						}
						else
						{
							stringBuilder.Append("[{id:'1045',text:'投票管理',icon:'icon/item0.png',func:function(){runWin('投票管理','Common/Vote_AllList.aspx','d1045'); }}]\n");
						}
					}
					if (this.GetValidPower(m, "48") == "48")
					{
						stringBuilder.Append("[{id:'1048',text:'系统登录记录',icon:'icon/item0.png',func:function(){runWin('系统登录记录','sys/User_LoginList.aspx','d1048'); }}]\n");
					}
					stringBuilder.Append("]\n");
					stringBuilder.Append("}],\n\n");
				}
				stringBuilder.Append("[{id:'pslogin1',text:'个人登录记录',icon:'icon/login.png',func:function(){runWin('个人登录记录','Common/User_LoginList.aspx','pslogin2');} }],\n[{id:'logout1',text:'安全退出',icon:'icon/out.png',func:function(){logout(); } }] ]);\n");
			}
			return stringBuilder.ToString();
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
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          