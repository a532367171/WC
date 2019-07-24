using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.DBUtility;

public partial class Mobile_GovApp_AppMenu : MobilePage

	{
        //protected HtmlForm form1;
        //protected HtmlGenericControl wdpy;
        //protected HtmlGenericControl yjpy;
        //protected HtmlGenericControl wdsq;
		protected void Page_Load(object sender, EventArgs e)
		{
			SqlParameter sqlParameter = new SqlParameter();
			sqlParameter.ParameterName = "@uid";
			sqlParameter.Size = 50;
			sqlParameter.Value = this.Uid;
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
			SqlParameter[] cmdParms = new SqlParameter[]
			{
				sqlParameter2,
				sqlParameter3,
				sqlParameter4,
				sqlParameter
			};
			MsSqlOperate.ExecuteNonQuery(CommandType.StoredProcedure, "Gov_GetUserFlowBoxCount", cmdParms);
			this.wdpy.InnerText = string.Concat(sqlParameter2.Value);
			this.yjpy.InnerText = string.Concat(sqlParameter3.Value);
			this.wdsq.InnerText = string.Concat(sqlParameter4.Value);
		}
	}