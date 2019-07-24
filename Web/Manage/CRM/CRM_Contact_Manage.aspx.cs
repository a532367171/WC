using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
public partial class Manage_CRM_CRM_Contact_Manage : ViewPages

	{
		protected string c = "";
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Button Button1;
        //protected HtmlGenericControl CRM_Name1;
        //protected HtmlInputText ContactAim;
        //protected HtmlInputText ContactPeople;
        //protected HtmlInputText AddTime;
        //protected HtmlInputText ContactCharge;
        //protected CheckBoxList ContactChargeType;
        //protected CheckBoxList ContactType;
        //protected DropDownList ContactState;
        //protected HtmlTextArea ContactDetail;
        //protected Button save_bt;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["cid"]))
			{
				this.c = base.Request.QueryString["cid"];
			}
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["cid"]) && !string.IsNullOrEmpty(base.Request.QueryString["ctid"]))
			{
				this.Show(base.Request.QueryString["cid"], base.Request.QueryString["ctid"]);
			}
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["cid"]))
			{
				CRMInfo byId = CRM.Init().GetById(Convert.ToInt32(base.Request.QueryString["cid"]));
				this.ViewState["ci"] = byId;
				this.CRM_Name1.InnerText = byId.CRM_Name;
			}
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["cid"]) && !string.IsNullOrEmpty(base.Request.QueryString["ctid"]))
			{
				CRM_ContactInfo cRM_ContactInfo = this.ViewState["cti"] as CRM_ContactInfo;
				if (!string.IsNullOrEmpty(this.AddTime.Value))
				{
					cRM_ContactInfo.AddTime = Convert.ToDateTime(this.AddTime.Value);
				}
				else
				{
					cRM_ContactInfo.AddTime = DateTime.Now;
				}
				cRM_ContactInfo.cid = Convert.ToInt32(base.Request.QueryString["cid"]);
				cRM_ContactInfo.ContactAim = this.ContactAim.Value;
				cRM_ContactInfo.ContactCharge = this.ContactCharge.Value;
				cRM_ContactInfo.ContactDetail = this.ContactDetail.Value;
				cRM_ContactInfo.ContactState = this.ContactState.SelectedValue;
				string text = "";
				for (int i = 0; i < this.ContactChargeType.Items.Count; i++)
				{
					if (this.ContactChargeType.Items[i].Selected)
					{
						text += this.ContactChargeType.Items[i].Value;
					}
				}
				cRM_ContactInfo.ContactChargeType = "";
				cRM_ContactInfo.ContactChargeType = text;
				string text2 = "";
				for (int i = 0; i < this.ContactType.Items.Count; i++)
				{
					if (this.ContactType.Items[i].Selected)
					{
						text2 += this.ContactType.Items[i].Value;
					}
				}
				cRM_ContactInfo.ContactType = "";
				cRM_ContactInfo.ContactType = text2;
				if (this.ContactPeople.Value.Trim() != "")
				{
					cRM_ContactInfo.ContactPeople = this.ContactPeople.Value;
				}
				else
				{
					cRM_ContactInfo.ContactPeople = this.RealName;
				}
				CRM_Contact.Init().Update(cRM_ContactInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!客户接触已保存成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["cid"]) && string.IsNullOrEmpty(base.Request.QueryString["ctid"]))
			{
				CRM_ContactInfo cRM_ContactInfo = new CRM_ContactInfo();
				CRMInfo cRMInfo = this.ViewState["ci"] as CRMInfo;
				if (!string.IsNullOrEmpty(this.AddTime.Value))
				{
					cRM_ContactInfo.AddTime = Convert.ToDateTime(this.AddTime.Value);
				}
				else
				{
					cRM_ContactInfo.AddTime = DateTime.Now;
				}
				cRM_ContactInfo.cid = Convert.ToInt32(base.Request.QueryString["cid"]);
				cRM_ContactInfo.ContactAim = this.ContactAim.Value;
				cRM_ContactInfo.ContactCharge = this.ContactCharge.Value;
				cRM_ContactInfo.ContactDetail = this.ContactDetail.Value;
				cRM_ContactInfo.ContactState = this.ContactState.SelectedValue;
				cRM_ContactInfo.CreatorID = cRMInfo.CreatorID;
				cRM_ContactInfo.CreatorDepName = cRMInfo.CreatorDepName;
				cRM_ContactInfo.CreatorRealName = cRMInfo.CreatorRealName;
				cRM_ContactInfo.CRM_Name = cRMInfo.CRM_Name;
				string text = "";
				for (int i = 0; i < this.ContactChargeType.Items.Count; i++)
				{
					if (this.ContactChargeType.Items[i].Selected)
					{
						text += this.ContactChargeType.Items[i].Value;
					}
				}
				cRM_ContactInfo.ContactChargeType = text;
				string text2 = "";
				for (int i = 0; i < this.ContactType.Items.Count; i++)
				{
					if (this.ContactType.Items[i].Selected)
					{
						text2 += this.ContactType.Items[i].Value;
					}
				}
				cRM_ContactInfo.ContactType = text2;
				if (this.ContactPeople.Value.Trim() != "")
				{
					cRM_ContactInfo.ContactPeople = this.ContactPeople.Value;
				}
				else
				{
					cRM_ContactInfo.ContactPeople = this.RealName;
				}
				CRM_Contact.Init().Add(cRM_ContactInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!客户接触已添加成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
		}
		private void Show(string cid, string ctid)
		{
			CRM_ContactInfo byId = CRM_Contact.Init().GetById(Convert.ToInt32(ctid));
			if (byId != null)
			{
				this.ViewState["cti"] = byId;
				this.ContactAim.Value = byId.ContactAim;
				DateTime arg_48_0 = byId.AddTime;
				this.AddTime.Value = byId.AddTime.ToString("yyyy-MM-dd");
				this.ContactCharge.Value = byId.ContactCharge;
				this.ContactState.SelectedValue = byId.ContactState;
				this.ContactDetail.Value = byId.ContactDetail;
				this.ContactPeople.Value = byId.ContactPeople;
				for (int i = 0; i < this.ContactChargeType.Items.Count; i++)
				{
					if (byId.ContactChargeType.Contains(this.ContactChargeType.Items[i].Value))
					{
						this.ContactChargeType.Items[i].Selected = true;
					}
				}
				for (int i = 0; i < this.ContactType.Items.Count; i++)
				{
					if (byId.ContactType.Contains(this.ContactType.Items[i].Value))
					{
						this.ContactType.Items[i].Selected = true;
					}
				}
			}
		}
	}