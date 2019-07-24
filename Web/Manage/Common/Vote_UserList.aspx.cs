using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;

public partial class Manage_Common_Vote_UserList : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Repeater rpt;
        private DataSet ds;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["vid"]))
			{
				this.Show(Convert.ToInt32(base.Request.QueryString["vid"]));
			}
		}
		private void Show(int vid)
		{
			VoteInfo byId = Vote.Init().GetById(vid);
			if (!string.IsNullOrEmpty(byId.VoteContent) && (byId.ShowUser == 1 || this.Modules.Contains("45")))
			{
				this.ds = MsSqlOperate.ExecuteDataset(CommandType.Text, "select * from VoteDetail where VoteID=" + vid, new SqlParameter[0]);
				List<TmpInfo> list = new List<TmpInfo>();
				if (byId.VoteContent.Contains("\n"))
				{
					string[] array = byId.VoteContent.Split(new string[]
					{
						"\n"
					}, StringSplitOptions.None);
					for (int i = 0; i < array.Length; i++)
					{
						if (!string.IsNullOrEmpty(array[i].Replace("\n", "").Replace("\r", "")))
						{
							list.Add(new TmpInfo
							{
								Tmp1 = array[i].Replace("\n", "").Replace("\r", "")
							});
						}
					}
				}
				else
				{
					list.Add(new TmpInfo
					{
						Tmp1 = byId.VoteContent.Replace("\n", "").Replace("\r", "")
					});
				}
				this.rpt.DataSource = list;
				this.rpt.DataBind();
			}
		}
		protected string GetCountDetail(string name)
		{
			string text = "";
			DataRow[] array = this.ds.Tables[0].Select("ItemName='" + name + "'");
			DataRow[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				DataRow dataRow = array2[i];
				object obj = text;
				text = string.Concat(new object[]
				{
					obj,
					dataRow["VoteRealName"],
					"(",
					dataRow["VoteDepName"],
					"),"
				});
			}
			return text;
		}
		protected string GetCount(string name)
		{
			return string.Concat(this.ds.Tables[0].Select("ItemName='" + name + "'").Length);
		}
	}
