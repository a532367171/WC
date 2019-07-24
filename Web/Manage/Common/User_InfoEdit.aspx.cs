using System;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;
using WC.DK;

public partial class Manage_Common_User_InfoEdit : ViewPages

	{
        //protected HtmlForm form1;
        //protected HtmlInputText PositionName;
        //protected HtmlTableRow zjss;
        //protected HtmlInputHidden userlist;
        //protected HtmlInputText namelist;
        //protected HtmlInputCheckBox MemoShare;
        //protected DropDownList RoleGUID;
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
        //protected Button save_bt;
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
			this.userlist.Value = byId.et6;
			this.namelist.Value = byId.et5;
			if (byId.DepGUID == "no")
			{
				this.zjss.Visible = false;
			}
			this.Sex.SelectedValue = string.Concat(byId.Sex);
			this.Birthday.Value = byId.Birthday;
			this.Phone.Value = byId.Phone;
			this.Tel.Value = byId.Tel;
			this.HomeAddress.Value = byId.HomeAddress;
			this.JoinTime.Value = byId.JoinTime;
			this.Notes.Value = byId.Notes;
			this.QQ.Value = byId.QQ;
			this.Email.Value = byId.Email;
			this.RoleGUID.SelectedValue = string.Concat(byId.MsgTime);
			this.MemoShare.Checked = Convert.ToBoolean(byId.MemoShare);
		}
		protected void Save_Btn(object sender, EventArgs e)
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
			sys_UserInfo.MsgTime = Convert.ToInt32(this.RoleGUID.SelectedValue);
			sys_UserInfo.MemoShare = Convert.ToInt32(this.MemoShare.Checked);
			sys_UserInfo.et6 = this.userlist.Value;
			sys_UserInfo.et5 = this.namelist.Value;
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
            //Help.UpdateIMUser(sys_UserInfo);
			string str = HttpContext.Current.Server.HtmlEncode("您好!基本资料修改成功!");
			base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
		}
	}
