using System;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;
using WC.DK;

public partial class Manage_Common_User_PwdEdit : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlInputText Uname;
        //protected HtmlInputText Urealname;
        //protected HtmlInputPassword Oldpwd;
        //protected HtmlInputPassword newpwd;
        //protected HtmlInputPassword newpwd1;
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
			this.Uname.Value = this.UserName;
			this.Urealname.Value = this.RealName;
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
						base.Response.Write("<script>alert('您好!密码已修改成功!');window.location='" + base.Request.Url.AbsoluteUri + "'</script>");
					}
					else
					{
						base.Response.Write("<script>alert('原密码不正确,请重新输入!');window.location='" + base.Request.Url.AbsoluteUri + "'</script>");
					}
				}
				else
				{
					base.Response.Write("<script>alert('确认密码 不一致,请重新输入!');window.location='" + base.Request.Url.AbsoluteUri + "'</script>");
				}
			}
		}
	}
