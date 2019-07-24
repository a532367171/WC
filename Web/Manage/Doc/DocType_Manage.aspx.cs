using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;

public partial class Manage_Doc_DocType_Manage : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlInputText TypeName;
        //protected HtmlTextArea Notes;
        //protected Button save_bt;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["tid"]))
			{
				this.Show(base.Request.QueryString["tid"]);
			}
		}
		private void Show(string id)
		{
			Docs_DocTypeInfo byId = Docs_DocType.Init().GetById(Convert.ToInt32(id));
			this.ViewState["ni"] = byId;
			this.TypeName.Value = byId.TypeName;
			this.Notes.Value = byId.Notes;
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
			{
				Docs_DocTypeInfo docs_DocTypeInfo = this.ViewState["ni"] as Docs_DocTypeInfo;
				docs_DocTypeInfo.Notes = this.Notes.Value;
				docs_DocTypeInfo.TypeName = this.TypeName.Value;
				docs_DocTypeInfo.Uid = Convert.ToInt32(this.Uid);
				Docs_DocType.Init().Update(docs_DocTypeInfo);
			}
			else
			{
				Docs_DocTypeInfo docs_DocTypeInfo = new Docs_DocTypeInfo();
				docs_DocTypeInfo.TypeName = this.TypeName.Value;
				docs_DocTypeInfo.Notes = this.Notes.Value;
				docs_DocTypeInfo.Uid = Convert.ToInt32(this.Uid);
				Docs_DocType.Init().Add(docs_DocTypeInfo);
			}
			string str = HttpContext.Current.Server.HtmlEncode("您好!文档分类保存成功!");
			base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=../Manage/doc/DocType_List.aspx&tip=" + str);
		}
	}
