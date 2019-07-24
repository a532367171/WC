using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;

public partial class Mobile_GovRec_RecView : MobilePage

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlGenericControl NewsTitle;
        //protected HtmlGenericControl Creator;
        //protected HtmlGenericControl addtime;
        //protected HtmlGenericControl top;
        //protected HtmlGenericControl DocBody;
    protected PlaceHolder pals;
        //protected HtmlTextArea FeedBack;
        //protected Button BtnOk;
		protected string fjs = "";
		protected string sm = "";
		protected string gd = "";
		protected string fj = "<span style='font-weight:bold;'>{1}</span> &nbsp;&nbsp;&nbsp;&nbsp;<a href='/Manage/Utils/Download.aspx?destFileName={0}' ><img src='/img/mail_attachment.gif' />下载附件</a><br>";
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["fl"]))
			{
				this.Show(base.Request.QueryString["fl"]);
			}
		}
		private void Show(string nid)
		{
			GovInfo byId = Gov.Init().GetById(Convert.ToInt32(nid));
			this.DocBody.InnerHtml = byId.DocBody;
			IList all = Gov_Recipient.Init().GetAll("UserID=" + this.Uid + " and Flow_ID=" + base.Request.QueryString["fl"], null);
			if (all.Count > 0)
			{
				Gov_RecipientInfo gov_RecipientInfo = all[0] as Gov_RecipientInfo;
				this.ViewState["gi"] = gov_RecipientInfo;
				if (gov_RecipientInfo.Sign == 0 && byId.Status == 1)
				{
					this.pals.Visible = true;
				}
			}
			this.NewsTitle.InnerText = byId.Flow_Name;
			this.Creator.InnerText = byId.CreatorRealName + " (" + byId.CreatorDepName + ")";
			this.addtime.InnerText = Utils.ConvertDate2(byId.AddTime);
			this.Page.Title = "公文签收：" + byId.Flow_Name;
			this.fjs = "<span style='color:#006600;'>相关文件</span>：<br>";
			if (!string.IsNullOrEmpty(byId.Flow_Files))
			{
				string[] array = byId.Flow_Files.Split(new char[]
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
			if (!string.IsNullOrEmpty(byId.Remark))
			{
				this.sm = "<span style='color:#006600;'>简要说明</span>：<br>" + byId.Remark + "<br><br>";
			}
			if (byId.IsValid == 0)
			{
				this.gd = "<br><span style='color:#006600;'>归档日期</span>：<br>所有人签收完 自动归档.<br><br>";
			}
			else
			{
				this.gd = "<br><span style='color:#006600;'>归档日期</span>：<br>" + Utils.ConvertDate3(byId.ValidTime) + ".";
			}
			string innerHtml;
			if (!string.IsNullOrEmpty(byId.DocNo))
			{
				innerHtml = "发文字号：" + byId.DocNo;
			}
			else
			{
				innerHtml = "发文字号：无";
			}
			this.top.InnerHtml = innerHtml;
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (this.ViewState["gi"] != null)
			{
				Gov_RecipientInfo gov_RecipientInfo = this.ViewState["gi"] as Gov_RecipientInfo;
				if (gov_RecipientInfo.Sign == 0)
				{
					gov_RecipientInfo.FeedBack = base.Request.Form["FeedBack"];
					gov_RecipientInfo.Sign = 1;
					gov_RecipientInfo.SignTime = DateTime.Now;
					Gov_Recipient.Init().Update(gov_RecipientInfo);
					string format = "update gov set status=5 where id={0} and status=1 and IsValid=0 and (select count(*) from Gov_Recipient where flow_id={0} and sign=0)=0";
					MsSqlOperate.ExecuteNonQuery(CommandType.Text, string.Format(format, gov_RecipientInfo.Flow_ID), new SqlParameter[0]);
					MessageBox.ShowAndRedirect(this, "公文已成功签收!", "RecMenu.aspx");
				}
			}
		}
	}