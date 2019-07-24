using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
public partial class Manage_Common_PrivateAddrBook_Manage : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlInputText Person;
        //protected HtmlInputText TagName;
        //protected HtmlInputText Phone;
        //protected HtmlTextArea Notes;
        //protected Button save_bt;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Show();
			}
		}
		protected void Save_Btn(object obj, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["pid"]))
			{
				PhoneBookInfo phoneBookInfo = this.ViewState["pi"] as PhoneBookInfo;
				phoneBookInfo.Person = this.Person.Value;
				phoneBookInfo.TagName = this.TagName.Value;
				phoneBookInfo.Phone = this.Phone.Value;
				phoneBookInfo.Notes = this.Notes.Value;
				PhoneBook.Init().Update(phoneBookInfo);
			}
			else
			{
				PhoneBookInfo phoneBookInfo = new PhoneBookInfo();
				phoneBookInfo.Person = this.Person.Value;
				phoneBookInfo.Phone = this.Phone.Value;
				phoneBookInfo.Notes = this.Notes.Value;
				phoneBookInfo.RealName = this.RealName;
				phoneBookInfo.TagName = this.TagName.Value;
				phoneBookInfo.UserID = Convert.ToInt32(this.Uid);
				phoneBookInfo.DepName = this.DepName;
				phoneBookInfo.AddTime = DateTime.Now;
				PhoneBook.Init().Add(phoneBookInfo);
			}
			string str = HttpContext.Current.Server.HtmlEncode("您好!个人通讯录保存成功!");
			base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=../Manage/common/PrivateAddrBook.aspx&tip=" + str);
		}
		private void Show()
		{
			PhoneBookInfo byId = PhoneBook.Init().GetById(Convert.ToInt32(base.Request.QueryString["pid"]));
			if (byId != null)
			{
				this.Phone.Value = byId.Phone;
				this.TagName.Value = byId.TagName;
				this.Person.Value = byId.Person;
				this.Notes.Value = byId.Notes;
				this.ViewState["pi"] = byId;
			}
		}
	}
