using System;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Manage_sys_Seal_Manage : ModulePages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Button Button1;
        //protected HtmlInputText SealName;
        //protected HtmlInputText TagName;
        //protected DropDownList uids;
        //protected HtmlInputPassword PWD;
        //protected FileUpload Fup;
        //protected Image PerPic;
        //protected HtmlInputCheckBox Status;
        //protected HtmlTextArea Notes;
        //protected Button save_bt;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				IList all = Sys_User.Init().GetAll(null, "order by depid asc,orders asc");
				this.uids.Items.Add(new ListItem("请选择 印章/签名使用者", ""));
				for (int i = 0; i < all.Count; i++)
				{
					Sys_UserInfo sys_UserInfo = all[i] as Sys_UserInfo;
					this.uids.Items.Add(new ListItem(sys_UserInfo.RealName + " (" + sys_UserInfo.DepName + ")", string.Concat(sys_UserInfo.id)));
				}
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["mid"]) && !base.IsPostBack)
			{
				this.Show(base.Request.QueryString["mid"]);
			}
		}
		private void Show(string id)
		{
			Sys_SealInfo byId = Sys_Seal.Init().GetById(Convert.ToInt32(id));
			this.ViewState["sm"] = byId;
			this.Status.Checked = Convert.ToBoolean(byId.Status);
			this.SealName.Value = byId.SealName;
			this.TagName.Value = byId.TagName;
			this.Notes.Value = byId.Notes;
			if (byId.Uid > 0)
			{
				this.uids.SelectedValue = string.Concat(byId.Uid);
			}
			if (!string.IsNullOrEmpty(byId.FilePath))
			{
				this.PerPic.ImageUrl = byId.FilePath;
			}
		}
		protected void Save_Btn(object obj, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["mid"]))
			{
				this.UpDate();
			}
			else
			{
				if (this.PWD.Value.Trim() == "")
				{
					base.Response.Write("<script>alert('使用者密码不能为空!');window.location='" + base.Request.Url.AbsoluteUri + "'</script>");
				}
				else
				{
					if (!this.Fup.HasFile)
					{
						base.Response.Write("<script>alert('上传图片不能为空!');window.location='" + base.Request.Url.AbsoluteUri + "'</script>");
					}
					else
					{
						this.AddSeal();
					}
				}
			}
		}
		private void UpDate()
		{
			Sys_SealInfo sys_SealInfo = this.ViewState["sm"] as Sys_SealInfo;
			sys_SealInfo.Status = Convert.ToInt32(this.Status.Checked);
			sys_SealInfo.AddTime = DateTime.Now;
			sys_SealInfo.Notes = this.Notes.Value;
			if (this.PWD.Value.Trim() != "")
			{
				sys_SealInfo.PWD = this.PWD.Value.Trim();
			}
			sys_SealInfo.SealName = this.SealName.Value;
			sys_SealInfo.TagName = this.TagName.Value;
			sys_SealInfo.Uid = Convert.ToInt32(base.Request.Form["uids"]);
			if (this.Fup.HasFile)
			{
				sys_SealInfo.FilePath = this.SaveJPG(this.Fup);
			}
			Sys_Seal.Init().Update(sys_SealInfo);
			string str = HttpContext.Current.Server.HtmlEncode("您好!印章/签名已编辑成功!");
			base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
		}
		private void AddSeal()
		{
			Sys_SealInfo sys_SealInfo = new Sys_SealInfo();
			sys_SealInfo.Status = Convert.ToInt32(this.Status.Checked);
			sys_SealInfo.AddTime = DateTime.Now;
			sys_SealInfo.Notes = this.Notes.Value;
			if (this.PWD.Value.Trim() != "")
			{
				sys_SealInfo.PWD = this.PWD.Value.Trim();
			}
			sys_SealInfo.SealName = this.SealName.Value;
			sys_SealInfo.TagName = this.TagName.Value;
			sys_SealInfo.Uid = Convert.ToInt32(base.Request.Form["uids"]);
			if (this.Fup.HasFile)
			{
				sys_SealInfo.FilePath = this.SaveJPG(this.Fup);
			}
			Sys_Seal.Init().Add(sys_SealInfo);
			string str = HttpContext.Current.Server.HtmlEncode("您好!印章/签名已添加成功!");
			base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
		}
		private string SaveJPG(FileUpload f)
		{
			string result = "";
			if (f.HasFile)
			{
				FileExtension[] fileEx = new FileExtension[]
				{
					FileExtension.JPG,
					FileExtension.GIF,
					FileExtension.PNG
				};
				if (FileSystemManager.IsAllowedExtension(f, fileEx))
				{
					string text = base.Server.MapPath("~/Files/SealFiles/");
					string str = DateTime.Now.ToString("yyMddhhmmssfff") + Path.GetExtension(this.Fup.FileName);
					text += str;
					this.Fup.PostedFile.SaveAs(text);
					result = "~/Files/SealFiles/" + str;
					this.Fup.Dispose();
				}
			}
			return result;
		}
	}
