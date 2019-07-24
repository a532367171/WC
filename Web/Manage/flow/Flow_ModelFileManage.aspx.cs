using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;

public partial class Manage_flow_Flow_ModelFileManage : ModulePages
{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Button Button1;
        //protected HtmlInputText FormTitle;
        //protected HtmlTextArea DocBody;
        //protected Button Button2;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["fmf"]))
			{
				this.Show(base.Request.QueryString["fmf"]);
			}
		}
		private void Show(string id)
		{
			Flows_ModelFileInfo byId = Flows_ModelFile.Init().GetById(Convert.ToInt32(id));
			this.FormTitle.Value = byId.FormTitle;
			this.DocBody.Value = byId.DocBody;
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["fmf"]))
			{
				Flows_ModelFileInfo flows_ModelFileInfo = Flows_ModelFile.Init().GetById(Convert.ToInt32(base.Request.QueryString["fmf"]));
				flows_ModelFileInfo.FormTitle = this.FormTitle.Value;
				flows_ModelFileInfo.AddTime = DateTime.Now;
				flows_ModelFileInfo.CreatorDepName = this.DepName;
				flows_ModelFileInfo.CreatorID = Convert.ToInt32(this.Uid);
				flows_ModelFileInfo.CreatorRealName = this.RealName;
				flows_ModelFileInfo.DocBody = this.DocBody.Value;
				Flows_ModelFile.Init().Update(flows_ModelFileInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!模板表单编辑成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
			else
			{
				Flows_ModelFileInfo flows_ModelFileInfo = new Flows_ModelFileInfo();
				flows_ModelFileInfo.AddTime = DateTime.Now;
				flows_ModelFileInfo.CreatorDepName = this.DepName;
				flows_ModelFileInfo.CreatorID = Convert.ToInt32(this.Uid);
				flows_ModelFileInfo.CreatorRealName = this.RealName;
				flows_ModelFileInfo.FormTitle = this.FormTitle.Value;
				flows_ModelFileInfo.DocBody = this.DocBody.Value;
				Flows_ModelFile.Init().Add(flows_ModelFileInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!模板表单添加成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
		}
	}
