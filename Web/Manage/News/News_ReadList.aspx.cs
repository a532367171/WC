using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;

public partial class Manage_News_News_ReadList : ViewPages
{
   

		protected string news_menu = "";
		private string news_tmp = "<a href='/Manage/News/News_List.aspx?tid={0}' >{1}</a>";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["nid"]))
			{
				this.Show(base.Request.QueryString["nid"]);
			}
		}
		private void Show(string nid)
		{
			IList all = News_Type.Init().GetAll(null, " order by orders asc");
			for (int i = 0; i < all.Count; i++)
			{
				News_TypeInfo news_TypeInfo = all[i] as News_TypeInfo;
				this.news_menu += string.Format(this.news_tmp, news_TypeInfo.id, news_TypeInfo.TypeName);
			}
			using (DataSet readList = this.GetReadList(nid))
			{
				int pageSize = 100;
				int num = 0;
				try
				{
					if (!string.IsNullOrEmpty(base.Request.QueryString["page"]))
					{
						num = Convert.ToInt32(base.Request.QueryString["page"]);
					}
				}
				catch
				{
				}
				if (num == 0)
				{
					num = 1;
				}
				PagedDataSource pagedDataSource = new PagedDataSource();
				DataView defaultView = readList.Tables[0].DefaultView;
				defaultView.Sort = "et3 Desc,et4 Desc";
				pagedDataSource.DataSource = defaultView;
				pagedDataSource.AllowPaging = true;
				pagedDataSource.PageSize = pageSize;
				pagedDataSource.CurrentPageIndex = num - 1;
				this.rpt.DataSource = pagedDataSource;
				this.rpt.DataBind();
				this.Page2.sty("meneame", num, pagedDataSource.PageCount, "?nid=" + nid + "&page=");
				this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + readList.Tables[0].Rows.Count + "</span> 条 记录数据";
			}
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			string text = base.Request.Form["keyword"];
			string str = "?keywords=" + HttpContext.Current.Server.HtmlEncode(text.Trim());
			base.Response.Redirect("News_List.aspx" + str);
		}
		private DataSet GetReadList(string nid)
		{
			IList all = ZEX2.Init().GetAll("e1=" + nid, null);
			IList allNewsUser = this.GetAllNewsUser(nid);
			foreach (object current in allNewsUser)
			{
				Sys_UserInfo sys_UserInfo = current as Sys_UserInfo;
				sys_UserInfo.et4 = "";
				foreach (object current2 in all)
				{
					ZEX2Info zEX2Info = current2 as ZEX2Info;
					if (sys_UserInfo.id == zEX2Info.e2)
					{
						sys_UserInfo.et3 = 1;
						sys_UserInfo.et4 = Utils.ConvertDate3(zEX2Info.e10);
					}
				}
			}
			IList<Sys_UserInfo> list = (List<Sys_UserInfo>)allNewsUser;
			return Utils.ConvertListToDataSet<Sys_UserInfo>(list);
		}
		private IList GetAllNewsUser(string nid)
		{
			IList<Sys_UserInfo> list = new List<Sys_UserInfo>();
			string cmdText = "select ShareDeps from News_Article where id=" + nid;
			string text = string.Concat(MsSqlOperate.ExecuteScalar(CommandType.Text, cmdText, new SqlParameter[0]));
			IEnumerator enumerator;
			if (text.Contains(","))
			{
				string[] array = text.Split(new char[]
				{
					','
				});
				string text2 = "";
				List<string> list2 = new List<string>();
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].Contains("#"))
					{
						string item = array[i].Split(new char[]
						{
							'#'
						})[1];
						list2.Add(item);
					}
				}
				string[] array2 = list2.ToArray();
				for (int i = 0; i < array2.Length; i++)
				{
					if (i != array2.Length - 1)
					{
						text2 = text2 + " depid=" + array2[i] + " or ";
					}
					else
					{
						text2 = text2 + " depid=" + array2[i] + " ";
					}
				}
				IList all = Sys_User.Init().GetAll(text2, null);
				enumerator = all.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						object current = enumerator.Current;
						Sys_UserInfo item2 = current as Sys_UserInfo;
						list.Add(item2);
					}
					goto IL_1C3;
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (disposable != null)
					{
						disposable.Dispose();
					}
				}
			}
			IList all2 = Sys_User.Init().GetAll("Status=0 and IsLock=0", null);
			enumerator = all2.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					Sys_UserInfo item2 = current as Sys_UserInfo;
					list.Add(item2);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			IL_1C3:
			return (IList)list;
		}
	}