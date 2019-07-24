using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;

public partial class Manage_CRM_CRM_View : ViewPages

	{
		protected string c = "";
		protected string fjs = "";
		protected string fj = "<span style='font-weight:bold;'>{1}</span> &nbsp;&nbsp;&nbsp;&nbsp;<a href='/Manage/Utils/Download.aspx?destFileName={0}' ><img src='/img/mail_attachment.gif' />下载附件</a><br>";
        //protected HtmlForm form1;
        //protected HtmlGenericControl CRM_Name1;
        //protected Label Grade;
        //protected HtmlTableRow div;
        //protected Label Contact;
        //protected Label lx;
        //protected Label Address;
        //protected Label hlw;
        //protected Label MainPeople;
        //protected Label Position;
        //protected Label Product;
        //protected Label TypeName;
        //protected Label Notes;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["cid"]))
			{
				this.Show(base.Request.QueryString["cid"]);
				this.c = base.Request.QueryString["cid"];
			}
		}
		private void Show(string cid)
		{
			CRMInfo byId = CRM.Init().GetById(Convert.ToInt32(cid));
			this.CRM_Name1.InnerText = byId.CRM_Name;
			if (string.Concat(byId.CreatorID) != this.Uid)
			{
				this.div.Visible = false;
			}
			this.Grade.Text = Convert.ToString(byId.Grade).ToUpper() + " - " + this.GetGrade(byId.Grade);
			this.lx.Text = string.Concat(new string[]
			{
				" <span style='color:#006600;font-weight:bold;'>电话:</span> ",
				byId.Tel,
				" &nbsp;&nbsp; <span style='color:#006600;font-weight:bold;'>传真:</span> ",
				byId.Fax,
				" &nbsp;&nbsp; <span style='color:#006600;font-weight:bold;'>邮编:</span> ",
				byId.Zip
			});
			this.hlw.Text = string.Concat(new string[]
			{
				" <span style='color:#006600;font-weight:bold;'>网站:</span> ",
				byId.Site,
				" &nbsp;&nbsp; <span style='color:#006600;font-weight:bold;'>QQ:</span> ",
				byId.QQ,
				" &nbsp;&nbsp; <span style='color:#006600;font-weight:bold;'>Email:</span> ",
				byId.Email
			});
			this.Address.Text = byId.Address;
			this.MainPeople.Text = byId.MainPeople;
			this.Position.Text = byId.Position;
			this.Product.Text = byId.Product;
			this.TypeName.Text = byId.TypeName;
			this.Notes.Text = byId.Notes;
			string cmdText = "select count(*) from crm_contact where cid=" + cid;
			object obj = MsSqlOperate.ExecuteScalar(CommandType.Text, cmdText, new SqlParameter[0]);
			this.Contact.Text = string.Concat(new object[]
			{
				"目前已接触 <strong>",
				obj,
				"</strong> 次 &nbsp;&nbsp;&nbsp;&nbsp; <a href=/manage/crm/CRM_Contact_List.aspx?cid=",
				cid,
				"><strong>查看接触详情</strong></a> &nbsp;&nbsp;&nbsp;&nbsp; <a href=/manage/crm/CRM_Contact_Manage.aspx?cid=",
				cid,
				"><strong>添加客户接触</strong></a>"
			});
			if (!string.IsNullOrEmpty(byId.FilePath))
			{
				string[] array = byId.FilePath.Split(new char[]
				{
					'|'
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].Trim() != "")
					{
						int num = array[i].LastIndexOf('/') + 1;
						string arg = array[i].Substring(num, array[i].Length - num);
						string s = array[i].Replace("~", "");
						this.fjs += string.Format(this.fj, base.Server.UrlEncode(s), arg);
					}
				}
			}
		}
		protected string GetGrade(object obj)
		{
			string text = string.Concat(obj);
			text = text.ToUpper();
			string result = "";
			if (text == "A")
			{
				result = "暂无需求，潜在培养的客户";
			}
			if (text == "B")
			{
				result = "有需求，正在跟进客户";
			}
			if (text == "C")
			{
				result = "短期可签入的客户";
			}
			if (text == "D")
			{
				result = "已签约客户/老客户";
			}
			return result;
		}
	}