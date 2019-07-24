using System;
using System.Collections;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;

public partial class Manage_Common_PrivateAddrBook : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel panLogin;
        //protected Button search_bt;
        //protected LinkButton LinkButton1;
        //protected Repeater rpt_person;
        //protected HtmlGenericControl num;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.Show();
			}
		}
		protected void Del_Btn(object obj, EventArgs e)
		{
			LinkButton linkButton = obj as LinkButton;
			RepeaterItem repeaterItem = linkButton.Parent as RepeaterItem;
			HtmlInputCheckBox htmlInputCheckBox = repeaterItem.FindControl("chk") as HtmlInputCheckBox;
			int id = Convert.ToInt32(htmlInputCheckBox.Value);
			PhoneBook.Init().Delete(id);
			this.Show();
		}
		protected void Search_Btn(object sender, EventArgs e)
		{
			string text = base.Request.Form["keyword"];
			string str = "?keywords=" + HttpContext.Current.Server.HtmlEncode(text.Trim());
			base.Response.Redirect("PrivateAddrBook.aspx" + str);
		}
		private void Show()
		{
			string where = "userid=" + this.Uid;
			if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
			{
				string text = base.Request.QueryString["keywords"];
				where = string.Concat(new string[]
				{
					"userid=",
					this.Uid,
					" and ( Person like '%",
					text,
					"%' or Phone like '%",
					text,
					"%' or TagName like '%",
					text,
					"%' )"
				});
			}
			IList all = PhoneBook.Init().GetAll(where, "order by TagName asc,id desc");
			this.rpt_person.DataSource = all;
			this.rpt_person.DataBind();
			this.num.InnerHtml = "当前 总计 - <span style='color:#ff0000; font-weight:bold;'>" + all.Count + "</span> 个 记录数据";
		}
		protected void DownLoad(object sender, EventArgs e)
		{
			IList all = PhoneBook.Init().GetAll("userid=" + this.Uid, "order by TagName asc,id desc");
			string text = this.RealName + " 的个人通讯录\r\n\r\n";
			string str = "Personal ContactsBook";
			foreach (object current in all)
			{
				PhoneBookInfo phoneBookInfo = current as PhoneBookInfo;
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					"姓名 (",
					phoneBookInfo.TagName,
					")：",
					phoneBookInfo.Person,
					" 电话：",
					phoneBookInfo.Phone,
					" \r\n"
				});
			}
			base.Response.Clear();
			base.Response.ClearHeaders();
			base.Response.Buffer = false;
			base.Response.AppendHeader("Content-Disposition", "attachment;filename=" + str + ".txt");
			base.Response.ContentType = "application/vnd.txt";
			base.Response.Write(text);
			base.Response.Flush();
			base.Response.End();
		}
	}
