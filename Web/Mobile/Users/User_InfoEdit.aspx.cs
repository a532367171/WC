using System;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;
using WC.DK;

public partial class Mobile_Users_User_InfoEdit : MobilePage

	{
        //protected HtmlForm form1;
        //protected HtmlInputText PositionName;
        //protected DropDownList Sex;
        //protected HtmlInputText Birthday;
        //protected HtmlInputText QQ;
        //protected HtmlInputText Email;
        //protected HtmlInputText Phone;
        //protected HtmlInputText Tel;
        //protected HtmlInputText HomeAddress;
        //protected HtmlInputText JoinTime;
        //protected FileUpload Fup;
        //protected HtmlTextArea Notes;
        //protected Button bt5;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Show();
			}
		}
		private void Show()
		{
			Sys_UserInfo byId = Sys_User.Init().GetById(Convert.ToInt32(this.Uid));
			this.ViewState["su"] = byId;
			this.PositionName.Value = byId.PositionName;
			this.Sex.SelectedValue = string.Concat(byId.Sex);
			this.Birthday.Value = byId.Birthday;
			this.Phone.Value = byId.Phone;
			this.Tel.Value = byId.Tel;
			this.HomeAddress.Value = byId.HomeAddress;
			this.JoinTime.Value = byId.JoinTime;
			this.Notes.Value = byId.Notes;
			this.QQ.Value = byId.QQ;
			this.Email.Value = byId.Email;
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.PositionName.Value))
			{
				Sys_UserInfo sys_UserInfo = this.ViewState["su"] as Sys_UserInfo;
				sys_UserInfo.PositionName = this.PositionName.Value;
				sys_UserInfo.Sex = Convert.ToInt32(this.Sex.SelectedValue);
				sys_UserInfo.Birthday = this.Birthday.Value;
				sys_UserInfo.Phone = this.Phone.Value;
				sys_UserInfo.Tel = this.Tel.Value;
				sys_UserInfo.QQ = this.QQ.Value;
				sys_UserInfo.Email = this.Email.Value;
				sys_UserInfo.HomeAddress = this.HomeAddress.Value;
				sys_UserInfo.JoinTime = this.JoinTime.Value;
				sys_UserInfo.Notes = this.Notes.Value;
				if (this.Fup.HasFile)
				{
					FileExtension[] fileEx = new FileExtension[]
					{
						FileExtension.GIF,
						FileExtension.JPG,
						FileExtension.PNG,
						FileExtension.BMP
					};
					if (FileSystemManager.IsAllowedExtension(this.Fup, fileEx))
					{
						string userName = sys_UserInfo.UserName;
						string text = base.Server.MapPath("~/Files/common/");
						string text2 = userName + Path.GetExtension(this.Fup.FileName);
						text += text2;
						this.Fup.PostedFile.SaveAs(text);
						sys_UserInfo.PerPic = text2;
						this.Fup.Dispose();
					}
				}
				Sys_User.Init().Update(sys_UserInfo);
				Help.UpdateIMUser(sys_UserInfo);
				MessageBox.ShowAndRedirect(this, "资料编辑成功!", "UserMenu.aspx");
			}
			else
			{
				MessageBox.ShowAndRedirect(this, "职务不能为空!", "User_InfoEdit.aspx");
			}
		}
	}