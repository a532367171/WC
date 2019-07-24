using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;

public partial class Manage_Common_NoteBook_Manage : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Button Button1;
        //protected HtmlInputText Subject;
        //protected HtmlTextArea Bodys;
        //protected Button save_bt;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["nid"]))
			{
				this.Show();
			}
		}
		private void Show()
		{
			NoteBookInfo byId = NoteBook.Init().GetById(Convert.ToInt32(base.Request.QueryString["nid"]));
			this.Bodys.Value = byId.Bodys;
			this.Subject.Value = byId.Subject;
			this.ViewState["ni"] = byId;
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(base.Request.QueryString["nid"]))
			{
				NoteBookInfo noteBookInfo = new NoteBookInfo();
				noteBookInfo.AddTime = DateTime.Now;
				noteBookInfo.Bodys = this.Bodys.Value;
				noteBookInfo.DepName = this.DepName;
				noteBookInfo.RealName = this.RealName;
				noteBookInfo.UserID = Convert.ToInt32(this.Uid);
				noteBookInfo.Subject = this.Subject.Value;
				NoteBook.Init().Add(noteBookInfo);
			}
			else
			{
				NoteBookInfo noteBookInfo = this.ViewState["ni"] as NoteBookInfo;
				noteBookInfo.AddTime = DateTime.Now;
				noteBookInfo.Bodys = this.Bodys.Value;
				noteBookInfo.Subject = this.Subject.Value;
				NoteBook.Init().Update(noteBookInfo);
			}
			string str = HttpContext.Current.Server.HtmlEncode("您好!记事便笺保存成功!");
			base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=../Manage/Common/NoteBook_List.aspx&tip=" + str);
		}
	}
