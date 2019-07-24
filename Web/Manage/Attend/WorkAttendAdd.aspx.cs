using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;
using WC.Tool;

public partial class Manage_Attend_WorkAttendAdd : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel type1;
        //protected Repeater rpt1;
        //protected Panel Attend1;
        //protected HtmlTextArea Notes1;
        //protected Button Button11;
        //protected Panel type2;
        //protected HtmlTextArea Notes2;
        //protected Button Button2;
        //protected Panel type3;
        //protected HtmlTextArea Notes3;
        //protected Button Button3;
        //protected Panel type4;
        //protected HtmlInputText TravelAddress4;
        //protected HtmlTextArea Notes4;
        //protected Button save_bt4;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["type"]))
			{
				this.Show(base.Request.QueryString["type"]);
			}
		}
		private void Show(string t)
		{
			if (t != null)
			{
				if (!(t == "1"))
				{
					if (!(t == "2"))
					{
						if (!(t == "3"))
						{
							if (t == "4")
							{
								this.type4.Visible = true;
							}
						}
						else
						{
							this.type3.Visible = true;
						}
					}
					else
					{
						this.type2.Visible = true;
					}
				}
				else
				{
					this.Show1();
				}
			}
		}
		private void Show1()
		{
			this.type1.Visible = true;
			if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]))
			{
				this.Attend1.Visible = true;
			}
			string cmdText = "select a.id,a.AttendNames,a.AttendTimes,b.SignTimes,b.SignJudge,b.Notes,b.id as wid from Work_AttendSet as a left join (select * from Work_Attend where AttendType=1 and UID=" + this.Uid + " and datediff(d,addtime,getdate())=0) as b on a.id=b.AttendTimeID";
			using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
			{
				this.rpt1.DataSource = dataSet.Tables[0].DefaultView;
				this.rpt1.DataBind();
			}
		}
		protected void Sign_Btn1(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["tid"]) && base.Request.QueryString["type"] == "1")
			{
				string text = base.Request.QueryString["tid"];
				IList all = Work_Attend.Init().GetAll(string.Concat(new string[]
				{
					" AttendType=1 and UID=",
					this.Uid,
					" and AttendTimeID=",
					text,
					" and datediff(d,addtime,getdate())=0 "
				}), null);
				if (all.Count == 0)
				{
					Work_AttendSetInfo byId = Work_AttendSet.Init().GetById(Convert.ToInt32(text));
					Work_AttendInfo work_AttendInfo = new Work_AttendInfo();
					work_AttendInfo.AddTime = DateTime.Now;
					work_AttendInfo.UID = Convert.ToInt32(this.Uid);
					work_AttendInfo.DepID = Convert.ToInt32(this.DepID);
					work_AttendInfo.RealName = this.RealName;
					work_AttendInfo.DepName = this.DepName;
					work_AttendInfo.AttendTimeID = Convert.ToInt32(text);
					work_AttendInfo.StandardTimes = byId.AttendTimes;
					work_AttendInfo.StandardNames = byId.AttendNames;
					work_AttendInfo.SignTimes = DateTime.Now.TimeOfDay.ToString().Substring(0, 5);
					work_AttendInfo.SignDates = DateTime.Now.ToString("yyyy-MM-dd");
					DateTime t = Convert.ToDateTime(byId.AttendTimes);
					DateTime t2 = Convert.ToDateTime(DateTime.Now.Hour + ":" + DateTime.Now.Minute);
					if (byId.AttendNames.Contains("上班"))
					{
						if (DateTime.Compare(t, t2) >= 0)
						{
							work_AttendInfo.SignJudge = "正常";
						}
						else
						{
							work_AttendInfo.SignJudge = "迟到";
						}
					}
					if (byId.AttendNames.Contains("下班"))
					{
						if (DateTime.Compare(t, t2) <= 0)
						{
							work_AttendInfo.SignJudge = "正常";
						}
						else
						{
							work_AttendInfo.SignJudge = "早退";
						}
					}
					work_AttendInfo.AttendType = 1;
					work_AttendInfo.Notes = "(" + RequestUtils.GetIP() + ") " + this.Notes1.Value;
					work_AttendInfo.BeginTime = DateTime.Now;
					work_AttendInfo.EndTime = DateTime.Now;
					Work_Attend.Init().Add(work_AttendInfo);
					base.Response.Write("<script>alert('上下班登记已添加！');window.location='WorkAttendAdd.aspx?type=1'</script>");
				}
			}
		}
		protected void Sign_Btn2(object sender, EventArgs e)
		{
			Work_AttendInfo work_AttendInfo = new Work_AttendInfo();
			work_AttendInfo.AddTime = DateTime.Now;
			work_AttendInfo.UID = Convert.ToInt32(this.Uid);
			work_AttendInfo.DepID = Convert.ToInt32(this.DepID);
			work_AttendInfo.RealName = this.RealName;
			work_AttendInfo.DepName = this.DepName;
			work_AttendInfo.AttendTimeID = 0;
			work_AttendInfo.StandardTimes = "";
			work_AttendInfo.StandardNames = "";
			work_AttendInfo.SignTimes = "";
			work_AttendInfo.SignDates = "";
			work_AttendInfo.SignJudge = "";
			work_AttendInfo.AttendType = 2;
			work_AttendInfo.TravelAddress = "";
			work_AttendInfo.Notes = "(" + RequestUtils.GetIP() + ") " + this.Notes2.Value;
			work_AttendInfo.BeginTime = Convert.ToDateTime(base.Request.Form["BeginTime2"]);
			work_AttendInfo.EndTime = Convert.ToDateTime(base.Request.Form["EndTime2"]);
			work_AttendInfo.B1 = base.Request.Form["B1_2"];
			work_AttendInfo.B2 = base.Request.Form["B2_2"];
			work_AttendInfo.E1 = base.Request.Form["E1_2"];
			work_AttendInfo.E2 = base.Request.Form["E2_2"];
			Work_Attend.Init().Add(work_AttendInfo);
			base.Response.Write("<script>alert('外出登记已添加！');window.location='WorkAttendAdd.aspx?type=2'</script>");
		}
		protected void Sign_Btn3(object sender, EventArgs e)
		{
			Work_AttendInfo work_AttendInfo = new Work_AttendInfo();
			work_AttendInfo.AddTime = DateTime.Now;
			work_AttendInfo.UID = Convert.ToInt32(this.Uid);
			work_AttendInfo.DepID = Convert.ToInt32(this.DepID);
			work_AttendInfo.RealName = this.RealName;
			work_AttendInfo.DepName = this.DepName;
			work_AttendInfo.AttendTimeID = 0;
			work_AttendInfo.StandardTimes = "";
			work_AttendInfo.StandardNames = "";
			work_AttendInfo.SignTimes = "";
			work_AttendInfo.SignDates = "";
			work_AttendInfo.SignJudge = "";
			work_AttendInfo.AttendType = 3;
			work_AttendInfo.TravelAddress = "";
			work_AttendInfo.Notes = "(" + RequestUtils.GetIP() + ") " + this.Notes3.Value;
			work_AttendInfo.BeginTime = Convert.ToDateTime(base.Request.Form["BeginTime3"]);
			work_AttendInfo.EndTime = Convert.ToDateTime(base.Request.Form["EndTime3"]);
			work_AttendInfo.B1 = base.Request.Form["B1_3"];
			work_AttendInfo.B2 = base.Request.Form["B2_3"];
			work_AttendInfo.E1 = base.Request.Form["E1_3"];
			work_AttendInfo.E2 = base.Request.Form["E2_3"];
			Work_Attend.Init().Add(work_AttendInfo);
			base.Response.Write("<script>alert('请假登记已添加！');window.location='WorkAttendAdd.aspx?type=3'</script>");
		}
		protected void Sign_Btn4(object sender, EventArgs e)
		{
			Work_AttendInfo work_AttendInfo = new Work_AttendInfo();
			work_AttendInfo.AddTime = DateTime.Now;
			work_AttendInfo.UID = Convert.ToInt32(this.Uid);
			work_AttendInfo.DepID = Convert.ToInt32(this.DepID);
			work_AttendInfo.RealName = this.RealName;
			work_AttendInfo.DepName = this.DepName;
			work_AttendInfo.AttendTimeID = 0;
			work_AttendInfo.StandardTimes = "";
			work_AttendInfo.StandardNames = "";
			work_AttendInfo.SignTimes = "";
			work_AttendInfo.SignDates = "";
			work_AttendInfo.SignJudge = "";
			work_AttendInfo.AttendType = 4;
			work_AttendInfo.TravelAddress = this.TravelAddress4.Value;
			work_AttendInfo.Notes = "(" + RequestUtils.GetIP() + ") " + this.Notes4.Value;
			work_AttendInfo.BeginTime = Convert.ToDateTime(base.Request.Form["BeginTime4"]);
			work_AttendInfo.EndTime = Convert.ToDateTime(base.Request.Form["EndTime4"]);
			work_AttendInfo.B1 = base.Request.Form["B1_4"];
			work_AttendInfo.B2 = base.Request.Form["B2_4"];
			work_AttendInfo.E1 = base.Request.Form["E1_4"];
			work_AttendInfo.E2 = base.Request.Form["E2_4"];
			Work_Attend.Init().Add(work_AttendInfo);
			base.Response.Write("<script>alert('出差登记已添加！');window.location='WorkAttendAdd.aspx?type=4'</script>");
		}
		protected string SignClick(object d, object j)
		{
			string format = "<a href='WorkAttendAdd.aspx?type=1&tid={0}'>登记</a>";
			string result = "<span style='color:#666666'>已登记</span>";
			if (!Utils.IsNumber(string.Concat(j)))
			{
				result = string.Format(format, string.Concat(d));
			}
			return result;
		}
		protected string SignJudge(object b)
		{
			string result;
			if (b.ToString().Contains("正常"))
			{
				result = "<span style='color:#006600'>" + b + "</span>";
			}
			else
			{
				result = "<span style='color:#ff0000'>" + b + "</span>";
			}
			return result;
		}
		protected string TypeStr()
		{
			string result = "";
			string text = base.Request.QueryString["type"];
			string text2 = text;
			if (text2 != null)
			{
				if (!(text2 == "1"))
				{
					if (!(text2 == "2"))
					{
						if (!(text2 == "3"))
						{
							if (text2 == "4")
							{
								result = " >> 出差";
							}
						}
						else
						{
							result = " >> 请假";
						}
					}
					else
					{
						result = " >> 外出";
					}
				}
				else
				{
					result = " >> 上下班";
				}
			}
			return result;
		}
	}
