using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Manage_Attend_WorkAttendView : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlGenericControl WorkType;
        //protected Label WorkPeople;
        //protected Label WorkDate;
        //protected Label WorkInfo;
        //protected Label WorkNote;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["wid"]))
			{
				this.Show(base.Request.QueryString["wid"]);
			}
		}
		private void Show(string wid)
		{
			Work_AttendInfo byId = Work_Attend.Init().GetById(Convert.ToInt32(wid));
			this.WorkNote.Text = byId.Notes;
			this.WorkPeople.Text = byId.RealName + "(" + byId.DepName + ")";
			this.WorkDate.Text = Utils.ConvertDate4(byId.AddTime);
			switch (byId.AttendType)
			{
			case 1:
				this.WorkType.InnerText = "上下班考勤";
				this.WorkInfo.Text = string.Concat(new string[]
				{
					byId.StandardNames,
					": ",
					byId.SignTimes,
					" &nbsp; (",
					byId.SignJudge,
					" ",
					byId.StandardTimes,
					")"
				});
				break;
			case 2:
				this.WorkType.InnerText = "外出";
				this.WorkInfo.Text = string.Concat(new string[]
				{
					Utils.ConvertDate0(byId.BeginTime),
					" ",
					byId.B1,
					":",
					byId.B2,
					"&nbsp; - &nbsp;",
					Utils.ConvertDate0(byId.EndTime),
					" ",
					byId.E1,
					":",
					byId.E2
				});
				break;
			case 3:
				this.WorkType.InnerText = "请假";
				this.WorkInfo.Text = string.Concat(new string[]
				{
					Utils.ConvertDate0(byId.BeginTime),
					" ",
					byId.B1,
					":",
					byId.B2,
					"&nbsp; - &nbsp;",
					Utils.ConvertDate0(byId.EndTime),
					" ",
					byId.E1,
					":",
					byId.E2
				});
				break;
			case 4:
				this.WorkType.InnerText = "出差";
				this.WorkInfo.Text = string.Concat(new string[]
				{
					Utils.ConvertDate0(byId.BeginTime),
					" ",
					byId.B1,
					":",
					byId.B2,
					"&nbsp; - &nbsp;",
					Utils.ConvertDate0(byId.EndTime),
					" ",
					byId.E1,
					":",
					byId.E2
				});
				break;
			}
		}
	}
