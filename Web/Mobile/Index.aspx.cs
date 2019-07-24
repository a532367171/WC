using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.DBUtility;

public partial class Mobile_Index : MobilePage

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
		protected string news_num = "0";
		protected string mails_num1 = "0";
		protected string mails_num2 = "0";
		protected string flows_num1 = "0";
		protected string flows_num2 = "0";
		protected string calendar_num = "0";
		protected string note_num = "0";
		protected string mydoc_num = "0";
		protected string shared_num = "0";
		protected string shared_num2 = "0";
		protected string exe_num = "0";
		protected string man_num = "0";
		protected string work_num1 = "0";
		protected string work_num2 = "0";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(this.Uid))
			{
				this.Show();
			}
		}
		private void Show()
		{
			SqlParameter sqlParameter = new SqlParameter();
			sqlParameter.ParameterName = "@uid";
			sqlParameter.Size = 50;
			sqlParameter.Value = this.Uid;
			SqlParameter sqlParameter2 = new SqlParameter();
			sqlParameter2.ParameterName = "@depid";
			sqlParameter2.Size = 50;
			sqlParameter2.Value = this.DepID;
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
			SqlParameter sqlParameter7 = new SqlParameter();
			sqlParameter7.Direction = ParameterDirection.Output;
			sqlParameter7.ParameterName = "@pt5";
			sqlParameter7.Size = 4;
			SqlParameter sqlParameter8 = new SqlParameter();
			sqlParameter8.Direction = ParameterDirection.Output;
			sqlParameter8.ParameterName = "@pt6";
			sqlParameter8.Size = 4;
			SqlParameter sqlParameter9 = new SqlParameter();
			sqlParameter9.Direction = ParameterDirection.Output;
			sqlParameter9.ParameterName = "@pt7";
			sqlParameter9.Size = 4;
			SqlParameter sqlParameter10 = new SqlParameter();
			sqlParameter10.Direction = ParameterDirection.Output;
			sqlParameter10.ParameterName = "@pt8";
			sqlParameter10.Size = 4;
			SqlParameter sqlParameter11 = new SqlParameter();
			sqlParameter11.Direction = ParameterDirection.Output;
			sqlParameter11.ParameterName = "@pt10";
			sqlParameter11.Size = 4;
			SqlParameter sqlParameter12 = new SqlParameter();
			sqlParameter12.Direction = ParameterDirection.Output;
			sqlParameter12.ParameterName = "@pt11";
			sqlParameter12.Size = 4;
			SqlParameter sqlParameter13 = new SqlParameter();
			sqlParameter13.Direction = ParameterDirection.Output;
			sqlParameter13.ParameterName = "@pt12";
			sqlParameter13.Size = 4;
			SqlParameter sqlParameter14 = new SqlParameter();
			sqlParameter14.Direction = ParameterDirection.Output;
			sqlParameter14.ParameterName = "@pt13";
			sqlParameter14.Size = 4;
			SqlParameter[] cmdParms = new SqlParameter[]
			{
				sqlParameter3,
				sqlParameter4,
				sqlParameter5,
				sqlParameter6,
				sqlParameter7,
				sqlParameter8,
				sqlParameter9,
				sqlParameter10,
				sqlParameter11,
				sqlParameter12,
				sqlParameter13,
				sqlParameter14,
				sqlParameter,
				sqlParameter2
			};
			using (MsSqlOperate.ExecuteDataset(CommandType.StoredProcedure, "Global_GetDesktopData", cmdParms))
			{
				this.news_num = string.Concat(sqlParameter3.Value);
				this.mails_num1 = string.Concat(sqlParameter4.Value);
				this.mails_num2 = string.Concat(sqlParameter5.Value);
				this.flows_num1 = string.Concat(sqlParameter6.Value);
				this.flows_num2 = string.Concat(sqlParameter7.Value);
				this.calendar_num = string.Concat(sqlParameter8.Value);
				this.note_num = string.Concat(sqlParameter9.Value);
				this.mydoc_num = string.Concat(sqlParameter10.Value);
				this.shared_num = string.Concat(sqlParameter11.Value);
				this.shared_num2 = string.Concat(sqlParameter12.Value);
				this.exe_num = string.Concat(sqlParameter13.Value);
				this.man_num = string.Concat(sqlParameter14.Value);
				this.work_num1 = string.Concat(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(id) from worklog where CreatorID=" + this.Uid, new SqlParameter[0]));
				this.work_num2 = string.Concat(MsSqlOperate.ExecuteScalar(CommandType.Text, string.Concat(new string[]
				{
					"select count(id) from worklog where  CreatorID<>",
					this.Uid,
					" and ShareUsers like '%#",
					this.Uid,
					"#%' "
				}), new SqlParameter[0]));
			}
		}
	}
