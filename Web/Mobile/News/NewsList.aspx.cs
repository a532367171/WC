using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;

public partial class Mobile_News_NewsList : MobilePage

	{
		protected string news_list = "所有资讯";
		protected string t = "";
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Page Page1;
		protected void Page_Load(object sender, EventArgs e)
		{
			this.t = ((!string.IsNullOrEmpty(base.Request.QueryString["tid"])) ? base.Request.QueryString["tid"] : "0");
			if (!string.IsNullOrEmpty(base.Request.QueryString["type"]))
			{
				if (base.Request.QueryString["type"] != "0")
				{
					base.Response.Redirect("NewsList.aspx?tid=" + base.Request.QueryString["type"] + "&keywords=" + HttpContext.Current.Server.HtmlEncode(base.Request.Form["keywords"]));
				}
				else
				{
					base.Response.Redirect("NewsList.aspx?keywords=" + HttpContext.Current.Server.HtmlEncode(base.Request.Form["keywords"]));
				}
			}
			if (!base.IsPostBack)
			{
				this.Show();
			}
		}
		private void Show()
		{
			IList all = News_Type.Init().GetAll(null, " order by orders asc");
			for (int i = 0; i < all.Count; i++)
			{
				News_TypeInfo news_TypeInfo = all[i] as News_TypeInfo;
				if (string.Concat(news_TypeInfo.id) == (base.Request.QueryString["tid"] ?? ""))
				{
					this.news_list = news_TypeInfo.TypeName;
				}
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
			string text = " a.TypeID = b.id and ( a.ShareDeps='' or a.ShareDeps like '%#" + this.DepID + "#%') ";
			string text2 = base.Request.QueryString["keywords"];
			if (!string.IsNullOrEmpty(text2) && Utils.CheckSql(text2))
			{
				text = " a.TypeID = b.id and ( a.ShareDeps='' or a.ShareDeps like '%#" + this.DepID + "#%') ";
				text = text + " and (a.NewsTitle like '%" + text2 + "%'  ) ";
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
			{
				string text3 = base.Request.QueryString["tid"];
				text = string.Concat(new string[]
				{
					" a.TypeID=",
					text3,
					" and a.TypeID = b.id and ( a.ShareDeps='' or a.ShareDeps like '%#",
					this.DepID,
					"#%') "
				});
			}
			string cmdText = "select a.*,b.TypeName from News_Article as a,News_Type as b where " + text + " order by a.id desc";
			using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
			{
				this.num.InnerHtml = "当前总计 - <span style='color:#ff0000; font-weight:bold;'>" + dataSet.Tables[0].Rows.Count + "</span> 条 记录数据";
				pagedDataSource.DataSource = dataSet.Tables[0].DefaultView;
				pagedDataSource.AllowPaging = true;
				pagedDataSource.PageSize = pageSize;
				pagedDataSource.CurrentPageIndex = num - 1;
				this.rpt.DataSource = pagedDataSource;
				this.rpt.DataBind();
				if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
				{
					this.Page1.sty("meneame", num, pagedDataSource.PageCount, "?keywords=" + text2 + "&page=");
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
				{
					this.Page1.sty("meneame", num, pagedDataSource.PageCount, "?tid=" + base.Request.QueryString["tid"] + "&page=");
				}
				this.Page1.sty("meneame", num, pagedDataSource.PageCount, "?page=");
			}
		}
	}