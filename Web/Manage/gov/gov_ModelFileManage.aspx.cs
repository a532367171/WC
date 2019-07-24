using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;

public partial class Manage_gov_gov_ModelFileManage : ModulePages
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
            Gov_ModelFileInfo byId = Gov_ModelFile.Init().GetById(Convert.ToInt32(id));
            this.FormTitle.Value = byId.FormTitle;
            this.DocBody.Value = byId.DocBody;
        }
        protected void Save_Btn(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(base.Request.QueryString["fmf"]))
            {
                Gov_ModelFileInfo gov_ModelFileInfo = Gov_ModelFile.Init().GetById(Convert.ToInt32(base.Request.QueryString["fmf"]));
                gov_ModelFileInfo.FormTitle = this.FormTitle.Value;
                gov_ModelFileInfo.AddTime = DateTime.Now;
                gov_ModelFileInfo.CreatorDepName = this.DepName;
                gov_ModelFileInfo.CreatorID = Convert.ToInt32(this.Uid);
                gov_ModelFileInfo.CreatorRealName = this.RealName;
                gov_ModelFileInfo.DocBody = this.DocBody.Value;
                Gov_ModelFile.Init().Update(gov_ModelFileInfo);
                string str = HttpContext.Current.Server.HtmlEncode("您好!模板表单编辑成功!");
                base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
            }
            else
            {
                Gov_ModelFileInfo gov_ModelFileInfo = new Gov_ModelFileInfo();
                gov_ModelFileInfo.AddTime = DateTime.Now;
                gov_ModelFileInfo.CreatorDepName = this.DepName;
                gov_ModelFileInfo.CreatorID = Convert.ToInt32(this.Uid);
                gov_ModelFileInfo.CreatorRealName = this.RealName;
                gov_ModelFileInfo.FormTitle = this.FormTitle.Value;
                gov_ModelFileInfo.DocBody = this.DocBody.Value;
                Gov_ModelFile.Init().Add(gov_ModelFileInfo);
                string str = HttpContext.Current.Server.HtmlEncode("您好!模板表单添加成功!");
                base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
            }
        }
    }
