using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;

public partial class Mobile_News_NewsMenu : MobilePage

	{
		private string s = "<li class='menu'><a href='NewsList.aspx?tid={0}' ><img src='../Style/Mobile/thumbs/start.png'/><span class='name'>{1} ({2})</span><span class='arrow'></span></a></li> ";
		protected string news_menu = "";
        //protected HtmlForm form1;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Show();
			}
		}
		private void Show()
		{
			this.news_menu = "<li class='menu'><a href='NewsList.aspx' ><img src='../Style/Mobile/thumbs/other.png'/><span class='name'>所有资讯 ({0})</span><span class='arrow'></span></a></li> ";
			this.news_menu = string.Format(this.news_menu, this.GetAllNums());
			IList all = News_Type.Init().GetAll(null, " order by orders asc");
			for (int i = 0; i < all.Count; i++)
			{
				News_TypeInfo news_TypeInfo = all[i] as News_TypeInfo;
				this.news_menu += string.Format(this.s, news_TypeInfo.id, news_TypeInfo.TypeName, this.GetNumsByType(news_TypeInfo.id));
			}
		}
		private string GetNumsByType(int typeid)
		{
			return string.Concat(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(id) from News_Article where typeid=" + typeid, new SqlParameter[0]));
		}
		private string GetAllNums()
		{
			return string.Concat(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(id) from News_Article", new SqlParameter[0]));
		}
	}