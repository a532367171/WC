using System;
using System.Data;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.DBUtility;

public partial class Mobile_Files_FileMenu : MobilePage

	{
		protected string num1 = "0";
		protected string num2 = "0";
        //protected HtmlForm form1;
		protected void Page_Load(object sender, EventArgs e)
		{
			string cmdText = "select count(id) from Docs_Doc where CreatorID=" + this.Uid;
			string cmdText2 = string.Concat(new string[]
			{
				"select count(id) from Docs_Doc where CreatorID<>",
				this.Uid,
				" and IsShare=1 and ShareUsers like '%#",
				this.Uid,
				"#%' "
			});
			this.num1 = string.Concat(MsSqlOperate.ExecuteScalar(CommandType.Text, cmdText, null));
			this.num2 = string.Concat(MsSqlOperate.ExecuteScalar(CommandType.Text, cmdText2, null));
		}
	}