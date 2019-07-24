using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.DBUtility;

public partial class Mobile_Tasks_TaskMenu : MobilePage

	{
        //protected HtmlForm form1;
        //protected HtmlGenericControl t_all;
        //protected HtmlGenericControl t_exeute;
        //protected HtmlGenericControl t_manage;
        //protected HtmlGenericControl t_create;
		protected void Page_Load(object sender, EventArgs e)
		{
			SqlParameter sqlParameter = new SqlParameter();
			sqlParameter.ParameterName = "@uid";
			sqlParameter.Size = 50;
			sqlParameter.Value = this.Uid;
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
			SqlParameter[] cmdParms = new SqlParameter[]
			{
				sqlParameter2,
				sqlParameter3,
				sqlParameter4,
				sqlParameter5,
				sqlParameter
			};
			MsSqlOperate.ExecuteNonQuery(CommandType.StoredProcedure, "Tasks_GetTaskCount", cmdParms);
			this.t_all.InnerText = string.Concat(sqlParameter2.Value);
			this.t_exeute.InnerText = string.Concat(sqlParameter3.Value);
			this.t_manage.InnerText = string.Concat(sqlParameter4.Value);
			this.t_create.InnerText = string.Concat(sqlParameter5.Value);
		}
	}