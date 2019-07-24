using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;

public partial class Manage_Common_Vote_View : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlGenericControl Creator;
        //protected HtmlGenericControl AddTime;
        //protected HtmlGenericControl IsValide;
        //protected HtmlGenericControl ShowUser;
        //protected HtmlGenericControl namelist;
        //protected HtmlGenericControl IsVote1;
        //protected HtmlGenericControl notes;
		protected string data = "";
		protected string title = "";
		protected string showPoll = "";
		protected string multiple = "";
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
			this.Creator.InnerText = byId.CreateRealName + "(" + byId.CreateDepName + ")";
			this.AddTime.InnerText = Utils.ConvertDate3(byId.AddTime);
			this.IsValide.InnerHtml = (Convert.ToBoolean(byId.IsValide) ? "<strong>投票进行中</strong>" : "<strong>投票已停止</strong>");
			this.ShowUser.InnerHtml = (Convert.ToBoolean(byId.IsMultiple) ? "多选投票" : "单选投票") + " &nbsp; &nbsp; &nbsp; " + (Convert.ToBoolean(byId.ShowUser) ? ("公开投票&nbsp;<a href='Vote_UserList.aspx?vid=" + vid + "' target=_blank>[查看选票]</a>") : "匿名投票");
			this.namelist.InnerText = Utils.GetSubString2(byId.namelist, 250, "...");
			if (!string.IsNullOrEmpty(byId.VoteContent))
			{
				if (byId.VoteContent.Contains("\n"))
				{
					string[] array = byId.VoteContent.Split(new string[]
					{
						"\n"
					}, StringSplitOptions.None);
					List<string> list = new List<string>();
					for (int i = 0; i < array.Length; i++)
					{
						if (!string.IsNullOrEmpty(array[i].Replace("\n", "").Replace("\r", "")))
						{
							list.Add(array[i]);
						}
					}
					this.data = "\"{root:[";
					for (int i = 0; i < list.Count; i++)
					{
						string text = list[i].Replace("\n", "").Replace("\r", "");
						string voteItemCount = this.GetVoteItemCount(text, vid);
						if (i != list.Count - 1)
						{
							object obj = this.data;
							this.data = string.Concat(new object[]
							{
								obj,
								"{id:'",
								i + 1,
								"',name:'",
								text,
								"',value:'",
								voteItemCount,
								"'},"
							});
						}
						else
						{
							object obj = this.data;
							this.data = string.Concat(new object[]
							{
								obj,
								"{id:'",
								i + 1,
								"',name:'",
								text,
								"',value:'",
								voteItemCount,
								"'}]}\""
							});
						}
					}
				}
				else
				{
					string text = byId.VoteContent.Replace("\n", "").Replace("\r", "");
					string voteItemCount = this.GetVoteItemCount(text, vid);
					this.data = string.Concat(new string[]
					{
						"\"{root:[{id:'1',name:'",
						text,
						"',value:'",
						voteItemCount,
						"'}]}\""
					});
				}
				this.title = "'" + byId.VoteTitle + "'";
				this.multiple = "false";
				this.showPoll = "false";
				if (byId.userlist.Contains("#" + this.Uid + "#") && byId.IsValide == 1 && !this.IsUserVoted(this.Uid, string.Concat(vid)))
				{
					this.multiple = (Convert.ToBoolean(byId.IsMultiple) ? "true" : "false");
					this.IsVote1.Visible = true;
					this.showPoll = "true";
				}
				byId.VoteNotes = (byId.VoteNotes ?? "");
				if (byId.VoteNotes.ToLower().Contains("script"))
				{
					this.notes.InnerHtml = byId.VoteNotes.ToLower().Replace("script", "scrript");
				}
				else
				{
					this.notes.InnerHtml = byId.VoteNotes;
				}
			}
		}
		private string GetVoteItemCount(string name, int vid)
		{
			string cmdText = "select count(*) from VoteDetail where VoteID=" + vid + " and ItemName=@ItemName";
			return string.Concat(MsSqlOperate.ExecuteScalar(CommandType.Text, cmdText, new SqlParameter[]
			{
				new SqlParameter("@ItemName", name ?? "")
			}));
		}
		private bool IsUserVoted(string uid, string vid)
		{
			IList all = VoteDetail.Init().GetAll("VoteUserID=" + uid + " and VoteID=" + vid, null);
			return all.Count > 0;
		}
	}
