using System;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.Model;

public partial class Manage_flow_DocBodyView : ViewPages

	{
		protected string name = "";
		protected string dep = "";
        //protected HtmlForm form1;
        //protected HtmlTextArea DocBody;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["gid"]))
			{
				Flows_DocInfo byId = Flows_Doc.Init().GetById(Convert.ToInt32(base.Request.QueryString["gid"]));
				this.DocBody.Value = byId.DocBody;
			}
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["fid"]))
			{
				FlowsInfo byId2 = Flows.Init().GetById(Convert.ToInt32(base.Request.QueryString["fid"]));
				this.DocBody.Value = byId2.DocBody;
			}
		}
	}
