using System;
using System.Collections;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;

public partial class Manage_Paper_PaperList : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected DropDownList TypeID;
        //protected HtmlInputText PaperName;
        //protected HtmlInputText PaperSymbol;
        //protected HtmlInputText SendDep;
        //protected HtmlInputText PaperGrade;
        //protected HtmlInputText StartTime;
        //protected HtmlInputText EndTime;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page1;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Show();
			}
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			string text = HttpContext.Current.Server.HtmlEncode(base.Request.Form["TypeID"].Trim());
			string text2 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["PaperName"].Trim());
			string text3 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["PaperSymbol"].Trim());
			string text4 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["SendDep"].Trim());
			string text5 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["PaperGrade"].Trim());
			string text6 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["StartTime"].Trim());
			string text7 = HttpContext.Current.Server.HtmlEncode(base.Request.Form["EndTime"].Trim());
			string str = string.Concat(new string[]
			{
				"?TypeID=",
				text,
				"&PaperName=",
				text2,
				"&PaperSymbol=",
				text3,
				"&SendDep=",
				text4,
				"&PaperGrade=",
				text5,
				"&StartTime=",
				text6,
				"&EndTime=",
				text7
			});
			base.Response.Redirect("PaperList.aspx" + str);
		}
		private void Show()
		{
			IList all = PaperType.Init().GetAll(null, null);
			this.TypeID.Items.Clear();
			this.TypeID.Items.Add(new ListItem("所有电子档案分类", ""));
			foreach (object current in all)
			{
				PaperTypeInfo paperTypeInfo = current as PaperTypeInfo;
				this.TypeID.Items.Add(new ListItem(paperTypeInfo.TypeName, string.Concat(paperTypeInfo.id)));
			}
			IList list = null;
			if (!string.IsNullOrEmpty(base.Request.QueryString["TypeID"]) || !string.IsNullOrEmpty(base.Request.QueryString["PaperName"]) || !string.IsNullOrEmpty(base.Request.QueryString["PaperSymbol"]) || !string.IsNullOrEmpty(base.Request.QueryString["SendDep"]) || !string.IsNullOrEmpty(base.Request.QueryString["PaperGrade"]) || !string.IsNullOrEmpty(base.Request.QueryString["StartTime"]) || !string.IsNullOrEmpty(base.Request.QueryString["EndTime"]))
			{
				string text = base.Request.QueryString["TypeID"];
				string text2 = base.Request.QueryString["PaperName"];
				string text3 = base.Request.QueryString["PaperSymbol"];
				string text4 = base.Request.QueryString["SendDep"];
				string text5 = base.Request.QueryString["PaperGrade"];
				string text6 = base.Request.QueryString["StartTime"];
				string text7 = base.Request.QueryString["EndTime"];
				string text8 = " 1=1 and (ShareDeps='' or ShareDeps like '%#" + this.DepID + "#%') ";
				if (!string.IsNullOrEmpty(text))
				{
					text8 = text8 + " and (TypeID=" + text + ") ";
				}
				if (!string.IsNullOrEmpty(text2))
				{
					text8 = text8 + " and (PaperName like '%" + text2 + "%') ";
				}
				if (!string.IsNullOrEmpty(text3))
				{
					text8 = text8 + " and (PaperSymbol like '%" + text3 + "%') ";
				}
				if (!string.IsNullOrEmpty(text4))
				{
					text8 = text8 + " and (SendDep like '%" + text4 + "%') ";
				}
				if (!string.IsNullOrEmpty(text5))
				{
					text8 = text8 + " and (PaperGrade like '%" + text5 + "%') ";
				}
				if (!string.IsNullOrEmpty(text6) && !string.IsNullOrEmpty(text7))
				{
					string text9 = text8;
					text8 = string.Concat(new string[]
					{
						text9,
						" and (PaperDate between '",
						text6,
						"' and '",
						text7,
						"')"
					});
				}
				if (!string.IsNullOrEmpty(text6) && string.IsNullOrEmpty(text7))
				{
					text8 = text8 + " and (PaperDate between '" + text6 + "' and getdate())";
				}
				if (string.IsNullOrEmpty(text6) && !string.IsNullOrEmpty(text7))
				{
					text8 = text8 + " and (PaperDate between getdate() and '" + text7 + "')";
				}
				list = Paper.Init().GetAll(text8, "order by id desc");
			}
			else
			{
				if (base.Request.QueryString["td"] != null)
				{
					list = Paper.Init().GetAll("TypeID=" + base.Request.QueryString["td"], "order by id desc");
				}
				else
				{
					list = Paper.Init().GetAll(null, "order by id desc");
				}
			}
			Hashtable hashtable = (Hashtable)HttpContext.Current.Application["config_fenye"];
			int pageSize = Convert.ToInt32(hashtable["fenye_commom"]);
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
			if (base.Request.QueryString["PaperName"] == null)
			{
				if (base.Request.QueryString["td"] != null)
				{
					this.Page1.sty("meneame", num, pagedDataSource.PageCount, "?td=" + base.Request.QueryString["td"] + "&page=");
				}
				else
				{
					this.Page1.sty("meneame", num, pagedDataSource.PageCount, "?page=");
				}
			}
			if (base.Request.QueryString["PaperName"] != null)
			{
				this.Page1.sty("meneame", num, pagedDataSource.PageCount, string.Concat(new string[]
				{
					"?PaperName=",
					base.Request.QueryString["PaperName"],
					"&TypeID=",
					base.Request.QueryString["TypeID"],
					"&PaperSymbol=",
					base.Request.QueryString["PaperSymbol"],
					"&SendDep=",
					base.Request.QueryString["SendDep"],
					"&PaperGrade=",
					base.Request.QueryString["PaperGrade"],
					"&StartTime=",
					base.Request.QueryString["StartTime"],
					"&EndTime=",
					base.Request.QueryString["EndTime"],
					"&page="
				}));
			}
			this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + list.Count + "</span> 条 记录数据";
		}
		protected string GetTypeName(object tid)
		{
			return PaperType.Init().GetById(Convert.ToInt32(tid)).TypeName;
		}
	}
