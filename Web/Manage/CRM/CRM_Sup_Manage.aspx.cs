using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
public partial class Manage_CRM_CRM_Sup_Manage : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Button Button1;
        //protected HtmlInputText Sup_Name;
        //protected HtmlInputText MainPeople;
        //protected HtmlInputText Tel;
        //protected HtmlInputText Addr;
        //protected HtmlTextArea Notes;
        //protected Button save_bt;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["cid"]))
			{
				this.Show(base.Request.QueryString["cid"]);
			}
		}
		private void Show(string cid)
		{
			if (!string.IsNullOrEmpty(cid))
			{
				CRM_SupInfo byId = CRM_Sup.Init().GetById(Convert.ToInt32(cid));
				if (byId != null)
				{
					this.ViewState["ci"] = byId;
					this.Sup_Name.Value = byId.Sup_Name;
					this.MainPeople.Value = byId.MainPeople;
					this.Tel.Value = byId.Tel;
					this.Addr.Value = byId.Addr;
					this.Notes.Value = byId.Notes;
				}
			}
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["cid"]))
			{
				CRM_SupInfo cRM_SupInfo = this.ViewState["ci"] as CRM_SupInfo;
				if (cRM_SupInfo != null && cRM_SupInfo.CreatorID == Convert.ToInt32(this.Uid))
				{
					cRM_SupInfo.MainPeople = this.MainPeople.Value;
					cRM_SupInfo.Notes = this.Notes.Value;
					cRM_SupInfo.Sup_Name = this.Sup_Name.Value;
					cRM_SupInfo.Tel = this.Tel.Value;
					cRM_SupInfo.Addr = this.Addr.Value;
					CRM_Sup.Init().Update(cRM_SupInfo);
					string str = HttpContext.Current.Server.HtmlEncode("您好!供应商信息已保存成功!");
					base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
				}
			}
			else
			{
				CRM_SupInfo cRM_SupInfo = new CRM_SupInfo();
				cRM_SupInfo.MainPeople = this.MainPeople.Value;
				cRM_SupInfo.Notes = this.Notes.Value;
				cRM_SupInfo.Sup_Name = this.Sup_Name.Value;
				cRM_SupInfo.Tel = this.Tel.Value;
				cRM_SupInfo.Addr = this.Addr.Value;
				cRM_SupInfo.CreatorDepName = this.DepName;
				cRM_SupInfo.CreatorID = Convert.ToInt32(this.Uid);
				cRM_SupInfo.CreatorRealName = this.RealName;
				CRM_Sup.Init().Add(cRM_SupInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!供应商信息已添加成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
		}
	}
