using System;
using System.Collections;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Tool;

public partial class Mobile_Tasks_TaskList : MobilePage

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page1;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["t"]))
			{
				base.Response.Redirect("TaskList.aspx?type=" + base.Request.QueryString["t"] + "&keywords=" + HttpContext.Current.Server.HtmlEncode(base.Request.Form["keywords"]));
			}
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["type"]))
			{
				string text = base.Request.QueryString["type"];
				if (text == "all" || text == "exeute" || text == "manage" || text == "create")
				{
					this.Show(text);
				}
			}
		}
		private void Show(string tp)
		{
			IList list = null;
			if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
			{
				string text = " 1=1 ";
				if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
				{
					text = text + " and (TaskName like '%" + base.Request.QueryString["keywords"] + "%') ";
				}
				if (tp == "all")
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						" and ( ManageUserList like '%#",
						this.Uid,
						"#%' or ExecuteUserList like '%#",
						this.Uid,
						"#%' )"
					});
				}
				if (tp == "exeute")
				{
					text = text + " and ( ExecuteUserList like '%#" + this.Uid + "#%' )";
				}
				if (tp == "manage")
				{
					text = text + " and ( ManageUserList like '%#" + this.Uid + "#%' )";
				}
				if (tp == "create")
				{
					text = text + " and ( CreatorID=" + this.Uid + " )";
				}
				list = Tasks.Init().GetAll(text, "order by id desc");
			}
			else
			{
				string text = " 1=1 and ";
				if (tp == "all")
				{
					if (!string.IsNullOrEmpty(base.Request.QueryString["td"]))
					{
						if (Utils.IsNumber(base.Request.QueryString["td"]))
						{
							string text2 = text;
							text = string.Concat(new string[]
							{
								text2,
								" ( TypeID=",
								base.Request.QueryString["td"],
								" ) and ( ManageUserList like '%#",
								this.Uid,
								"#%' or ExecuteUserList like '%#",
								this.Uid,
								"#%' )"
							});
						}
					}
					else
					{
						string text2 = text;
						text = string.Concat(new string[]
						{
							text2,
							" ( ManageUserList like '%#",
							this.Uid,
							"#%' or ExecuteUserList like '%#",
							this.Uid,
							"#%' )"
						});
					}
				}
				if (tp == "exeute")
				{
					text = text + " ( ExecuteUserList like '%#" + this.Uid + "#%' )";
				}
				if (tp == "manage")
				{
					text = text + " ( ManageUserList like '%#" + this.Uid + "#%' )";
				}
				if (tp == "create")
				{
					text = text + " ( CreatorID=" + this.Uid + " )";
				}
				list = Tasks.Init().GetAll(text, "order by id desc");
			}
			int pageSize = 30;
			int num = 0;
			try
			{
				if (!string.IsNullOrEmpty(base.Request.QueryString["page"]))
				{
					num = Convert.ToInt32(base.Request.QueryString["page"]);
				}
			}
			catch
			{
			}
			if (num == 0)
			{
				num = 1;
			}
			PagedDataSource pagedDataSource = new PagedDataSource();
			pagedDataSource.DataSource = list;
			pagedDataSource.AllowPaging = true;
			pagedDataSource.PageSize = pageSize;
			pagedDataSource.CurrentPageIndex = num - 1;
			this.rpt.DataSource = pagedDataSource;
			this.rpt.DataBind();
			if (base.Request.QueryString["keywords"] == null)
			{
				this.Page1.sty("meneame", num, pagedDataSource.PageCount, "?type=" + tp + "&page=");
			}
			if (base.Request.QueryString["keywords"] != null)
			{
				this.Page1.sty("meneame", num, pagedDataSource.PageCount, string.Concat(new string[]
				{
					"?keywords=",
					base.Request.QueryString["keywords"],
					"&type=",
					tp,
					"&page="
				}));
			}
			this.num.InnerHtml = "当前总计 - <span style='color:#ff0000; font-weight:bold;'>" + list.Count + "</span> 条 记录数据";
		}
	}