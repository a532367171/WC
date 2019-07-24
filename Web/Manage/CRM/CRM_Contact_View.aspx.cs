using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Manage_CRM_CRM_Contact_View : ViewPages

	{
		protected string c = "";
        //protected HtmlGenericControl CRM_Name1;
        //protected Label ContactAim;
        //protected HtmlTableRow div;
        //protected Label ContactPeople;
        //protected Label AddTime;
        //protected Label ContactType;
        //protected Label ContactState;
        //protected Label ContactCharge;
        //protected Label ContactChargeType;
        //protected Label ContactDetail;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["cid"]))
			{
				this.c = base.Request.QueryString["cid"];
			}
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["ctid"]))
			{
				this.Show(base.Request.QueryString["ctid"]);
			}
		}
		private void Show(string ctid)
		{
			CRM_ContactInfo byId = CRM_Contact.Init().GetById(Convert.ToInt32(ctid));
			this.CRM_Name1.InnerText = byId.CRM_Name;
			this.ContactAim.Text = byId.ContactAim;
			this.ContactPeople.Text = byId.ContactPeople;
			this.AddTime.Text = Utils.ConvertDate3(byId.AddTime);
			this.ContactType.Text = byId.ContactType;
			this.ContactCharge.Text = byId.ContactCharge;
			this.ContactChargeType.Text = byId.ContactChargeType;
			this.ContactDetail.Text = byId.ContactDetail;
			this.ContactState.Text = "[" + byId.ContactState + "]";
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