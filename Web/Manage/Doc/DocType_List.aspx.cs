using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.DK;

public partial class Manage_Doc_DocType_List : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Show();
			}
		}
		private void Show()
		{
			IList all = Docs_DocType.Init().GetAll("uid=" + this.Uid, null);
			this.rpt.DataSource = all;
			this.rpt.DataBind();
			this.num.InnerHtml = "当前 总计 - <span style='color:#ff0000; font-weight:bold;'>" + all.Count + "</span> 个 记录数据";
		}
		protected void Del_Btn(object obj, EventArgs e)
		{
			LinkButton linkButton = obj as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
			HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
			int num = Convert.ToInt32(htmlInputCheckBox.Value);
			try
			{
				IList all = Docs_Doc.Init().GetAll("doctypeid=" + num, null);
				if (all != null && all.Count > 0)
				{
					foreach (object current in all)
					{
						Docs_DocInfo docs_DocInfo = current as Docs_DocInfo;
						Help.DeleteFiles(docs_DocInfo.FilePath);
					}
				}
			}
			catch
			{
			}
			string cmdText = "delete from Docs_Doc where doctypeid=" + num;
			MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
			Docs_DocType.Init().Delete(num);
			this.Show();
		}
	}

