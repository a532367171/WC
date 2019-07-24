using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Manage_Common_User_OnLine : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Repeater rpt_person;
        //protected HtmlGenericControl num;
        //protected Page Page1;
		protected void Page_Load(object sender, EventArgs e)
		{
			this.Show();
		}
		private void Show()
		{
			IList<Sys_UserInfo> list = base.Application["user_online"] as IList<Sys_UserInfo>;
			foreach (object current in list)
			{
				Sys_UserInfo sys_UserInfo = current as Sys_UserInfo;
				if (sys_UserInfo.IsOnline == 1 && sys_UserInfo.LastLoginTime.AddMinutes(60.0) < DateTime.Now)
				{
					sys_UserInfo.IsOnline = 0;
				}
			}
			using (DataSet dataSet = Utils.ConvertListToDataSet<Sys_UserInfo>(list))
			{
				int pageSize = 50;
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
				DataView defaultView = dataSet.Tables[0].DefaultView;
				defaultView.Sort = "IsOnline Desc,LastLoginTime Desc";
				defaultView.RowFilter = "IsOnline<>9";
				pagedDataSource.DataSource = defaultView;
				pagedDataSource.AllowPaging = true;
				pagedDataSource.PageSize = pageSize;
				pagedDataSource.CurrentPageIndex = num - 1;
				this.Page2.sty("meneame", num, pagedDataSource.PageCount, "?page=");
				this.num.InnerHtml = "当前总计 - <span style='color:#ff0000; font-weight:bold;'>" + dataSet.Tables[0].Select("IsOnline=1").Length + "</span> 位 在线用户";
				this.rpt_person.DataSource = pagedDataSource;
				this.rpt_person.DataBind();
			}
		}
	}
