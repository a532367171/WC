<%@ WebHandler Language="C#" Class="message" %>

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Services;
using WC.DBUtility;

    [WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class message : IHttpHandler {
    



		private string mail = "<span style=font-weight:bold><a href=# onclick=addTab('收件箱','../../Manage/Common/Mail_List.aspx?fid=0','icon-data3') >您有 ({0}) 封新邮件请查收</a></span><br>";
        private string gov = "<span style=font-weight:bold><a href=# onclick=addTab('我的审核','../../Manage/gov/Gov_List.aspx?action=verify','icon-password') >您有 ({0}) 件新公文需审批</a></span><br>";
        private string gov_r = "<span style=font-weight:bold><a href=# onclick=addTab('公文签收','../../Manage/gov/Gov_Recipient.aspx?action=verify','icon-et') >您有 ({0}) 件新公文需签收</a></span><br>";
        private string flow = "<span style=font-weight:bold><a href=# onclick=addTab('我的批阅','../../Manage/flow/Flow_List.aspx?action=verify','icon-html') >您有 ({0}) 个新流程需审批</a></span><br>";
		private string cal = "<span style=font-weight:bold><a href=# onclick=addTab('我的日程','../../Manage/CalendarMemo/CalendarMemo.aspx','icon-calendar') >您有 ({0}) 个今天日程安排</a></span><br>";
		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
		public void ProcessRequest(HttpContext context)
		{
			context.Response.Charset = "UTF-8";
			context.Response.Cache.SetNoStore();
			string value = context.Request.Params["uid"];
			string text = "";
			SqlParameter sqlParameter = new SqlParameter();
			sqlParameter.ParameterName = "@uid";
			sqlParameter.Size = 50;
			sqlParameter.Value = Convert.ToInt32(value);
			SqlParameter sqlParameter2 = new SqlParameter();
			sqlParameter2.Direction = ParameterDirection.Output;
			sqlParameter2.ParameterName = "@pt1";
			sqlParameter2.Size = 4;
			SqlParameter sqlParameter3 = new SqlParameter();
			sqlParameter3.Direction = ParameterDirection.Output;
			sqlParameter3.ParameterName = "@pt2";
			sqlParameter3.Size = 4;
			SqlParameter sqlParameter4 = new SqlParameter();
			sqlParameter4.Direction = ParameterDirection.Output;
			sqlParameter4.ParameterName = "@pt3";
			sqlParameter4.Size = 4;
			SqlParameter sqlParameter5 = new SqlParameter();
			sqlParameter5.Direction = ParameterDirection.Output;
			sqlParameter5.ParameterName = "@pt4";
			sqlParameter5.Size = 4;
			SqlParameter sqlParameter6 = new SqlParameter();
			sqlParameter6.Direction = ParameterDirection.Output;
			sqlParameter6.ParameterName = "@pt5";
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
			int[] array = new int[5];
			int[] array2 = array;
			using (MsSqlOperate.ExecuteDataset(CommandType.StoredProcedure, "Global_Message", cmdParms))
			{
				array2[0] = Convert.ToInt32(sqlParameter2.Value);
				array2[1] = Convert.ToInt32(sqlParameter3.Value);
				array2[2] = Convert.ToInt32(sqlParameter4.Value);
				array2[3] = Convert.ToInt32(sqlParameter5.Value);
				array2[4] = Convert.ToInt32(sqlParameter6.Value);
				if (array2[0] > 0)
				{
					text += string.Format(this.mail, array2[0]);
				}
				if (array2[1] > 0)
				{
					text += string.Format(this.gov, array2[1]);
				}
				if (array2[2] > 0)
				{
					text += string.Format(this.gov_r, array2[2]);
				}
				if (array2[3] > 0)
				{
					text += string.Format(this.flow, array2[3]);
				}
				if (array2[4] > 0)
				{
					text += string.Format(this.cal, array2[4]);
				}
			}
			if (text == "")
			{
				text = "1";
			}
			context.Response.Write(text);
			context.Response.End();
		}
	}

