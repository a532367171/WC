using System;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;
using WC.DK;

public partial class Mobile_Users_User_PwdEdit : MobilePage

	{
        //protected HtmlForm form1;
        //protected HtmlGenericControl Uname;
        //protected HtmlGenericControl Urealname;
        //protected HtmlInputPassword Oldpwd;
        //protected HtmlInputPassword newpwd;
        //protected HtmlInputPassword newpwd1;
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
			this.Uname.InnerText = this.UserName;
			this.Urealname.InnerText = this.RealName;
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.Oldpwd.Value) && !string.IsNullOrEmpty(this.newpwd.Value))
			{
				if (this.newpwd.Value.Trim() == this.newpwd1.Value.Trim())
				{
					IList all = Sys_User.Init().GetAll(string.Concat(new string[]
					{
						"id=",
						this.Uid,
						" and password='",
						Encrypt.MD5_32(this.Oldpwd.Value.Trim().ToLower()),
						"'"
					}), null);
					if (all.Count > 0)
					{
						Sys_UserInfo sys_UserInfo = all[0] as Sys_UserInfo;
						sys_UserInfo.PassWord = Encrypt.MD5_32(this.newpwd.Value.Trim().ToLower());
						Sys_User.Init().Update(sys_UserInfo);
						Help.UpdateIMUser(sys_UserInfo);
						MessageBox.ShowAndRedirect(this, "密码修改成功!", "UserMenu.aspx");
					}
					else
					{
						MessageBox.ShowAndRedirect(this, "原密码不正确,重新输入!", "User_PwdEdit.aspx");
					}
				}
				else
				{
					MessageBox.ShowAndRedirect(this, "确认密码不一致,重新输入!", "User_PwdEdit.aspx");
				}
			}
			else
			{
				MessageBox.ShowAndRedirect(this, "新旧密码不能为空!", "User_PwdEdit.aspx");
			}
		}
	}