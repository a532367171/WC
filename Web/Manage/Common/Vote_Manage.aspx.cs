using System;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;

public partial class Manage_Common_Vote_Manage : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Button Button1;
        //protected HtmlInputText VoteTitle;
        //protected HtmlTextArea VoteContent;
        //protected HtmlInputHidden userlist;
        //protected HtmlTextArea namelist;
        //protected DropDownList IsMultiple;
        //protected DropDownList ShowUser;
        //protected DropDownList IsValide;
        //protected Button save_bt;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["vid"]))
			{
				this.Show(Convert.ToInt32(base.Request.QueryString["vid"]));
			}
		}
		private void Show(int vid)
		{
			VoteInfo byId = Vote.Init().GetById(vid);
			this.VoteTitle.Value = byId.VoteTitle;
			this.VoteContent.Value = byId.VoteContent;
			this.IsValide.SelectedValue = string.Concat(byId.IsValide);
			this.IsMultiple.SelectedValue = string.Concat(byId.IsMultiple);
			this.ShowUser.SelectedValue = string.Concat(byId.ShowUser);
			this.userlist.Value = byId.userlist;
			this.namelist.Value = byId.namelist;
			this.ViewState["vi"] = byId;
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (this.CheckItemCount(this.VoteContent.Value))
			{
				if (string.IsNullOrEmpty(base.Request.QueryString["vid"]))
				{
					VoteInfo voteInfo = new VoteInfo();
					voteInfo.AddTime = DateTime.Now;
					voteInfo.CreateDepName = this.DepName;
					voteInfo.CreateRealName = this.RealName;
					voteInfo.CreateUserID = Convert.ToInt32(this.Uid);
					voteInfo.VoteTitle = this.VoteTitle.Value;
					voteInfo.VoteContent = this.VoteContent.Value.Replace("'", "").Replace("\"", "");
					voteInfo.IsMultiple = Convert.ToInt32(this.IsMultiple.SelectedValue);
					voteInfo.IsValide = Convert.ToInt32(this.IsValide.SelectedValue);
					voteInfo.ShowUser = Convert.ToInt32(this.ShowUser.SelectedValue);
					voteInfo.userlist = this.userlist.Value;
					voteInfo.namelist = this.namelist.Value;
					Vote.Init().Add(voteInfo);
				}
				else
				{
					VoteInfo voteInfo = this.ViewState["vi"] as VoteInfo;
					voteInfo.VoteTitle = this.VoteTitle.Value;
					voteInfo.VoteContent = this.VoteContent.Value.Replace("'", "").Replace("\"", "");
					voteInfo.IsMultiple = Convert.ToInt32(this.IsMultiple.SelectedValue);
					voteInfo.IsValide = Convert.ToInt32(this.IsValide.SelectedValue);
					voteInfo.ShowUser = Convert.ToInt32(this.ShowUser.SelectedValue);
					voteInfo.userlist = this.userlist.Value;
					voteInfo.namelist = this.namelist.Value;
					Vote.Init().Update(voteInfo);
				}
				string str = HttpContext.Current.Server.HtmlEncode("您好!投票保存成功!");
				base.Response.Redirect("/InfoTip/Operate_Success.aspx?returnpage=/Manage/Common/Vote_List.aspx&tip=" + str);
			}
			else
			{
				base.Response.Write("<script>alert('最多只支持11个选项!');window.location='Vote_List.aspx';</script>");
			}
		}
		private bool CheckItemCount(string content)
		{
			bool result = true;
			int num = 0;
			if (content.Contains("\n"))
			{
				string[] array = content.Split(new string[]
				{
					"\n"
				}, StringSplitOptions.None);
				for (int i = 0; i < array.Length; i++)
				{
					if (!string.IsNullOrEmpty(array[i].Replace("\n", "").Replace("\r", "")))
					{
						num++;
					}
				}
				if (num > 11)
				{
					result = false;
				}
			}
			return result;
		}
	}
