using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.DBUtility;

public partial class Mobile_Mails_MailMenu : MobilePage

	{
        //protected HtmlForm form1;
        //protected HtmlGenericControl sjx;
        //protected HtmlGenericControl cgx;
        //protected HtmlGenericControl fjx;
        //protected HtmlGenericControl ljx;
		protected void Page_Load(object sender, EventArgs e)
		{
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
			this.sjx.InnerText = sqlParameter2.Value + "/" + sqlParameter6.Value;
			this.cgx.InnerText = string.Concat(sqlParameter3.Value);
			this.fjx.InnerText = string.Concat(sqlParameter4.Value);
			this.ljx.InnerText = string.Concat(sqlParameter5.Value);
		}
	}