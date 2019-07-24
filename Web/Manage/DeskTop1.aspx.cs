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

public partial class Manage_DeskTop : ViewPages
{
    private string tmp = "<tr><td height=24><img src='../img/news.gif' style='border:0px;height:12px;' /><a href=#@ onclick=window.parent.addTab('{4}','{0}','icon8a1{5}')  title='{1}'> {2} &nbsp;({3})</a></td></tr>";
    private string tmp_noread = "<tr><td height=24><span><img src='../img/mail_noread.gif' style='border:0px;height:12px;width:12px;' /><a href=#@ onclick=window.parent.addTab('{4}','{0}','icon9c3{5}')  title='{1}'> {2} &nbsp;({3})</a></span></td></tr>";
    private string tmp_hasread = "<tr><td height=24><span><img src='../img/mail_isread.gif' style='border:0px;height:12px;width:12px;' /><a href=#@ onclick=window.parent.addTab('{4}','{0}','icon1d2{5}')  title='{1}'> {2} &nbsp;({3})</a></span></td></tr>";
    private string tmp_flow = "<tr><td height=24><span><img src='../img/flow.gif' style='border:0px;height:12px;' /><a href=#@ onclick=window.parent.addTab('{4}','{0}','icon3e5{5}') title='{1}'> {2} &nbsp;({3})</a></span></td></tr>";
    private string block_line = "<tr><td height=24>&nbsp;</td></tr>";
    protected string script = "";
    protected string news_num = "0";
    protected string mails_num1 = "0";
    protected string mails_num2 = "0";
    protected string flows_num1 = "0";
    protected string flows_num2 = "0";
    protected string calendar_num = "0";
    protected string note_num = "0";
    protected string mydoc_num = "0";
    protected string shared_num = "0";
    protected string shared_num2 = "0";
    protected string exe_num = "0";
    protected string man_num = "0";
    protected string forum_num = "0";
    protected string qyzx = "";
    protected string wdyj = "";
    protected string wdsp = "";
    protected string wdgw = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack && !string.IsNullOrEmpty(this.Uid))
        {
            Bas_ComInfo bas_ComInfo = HttpContext.Current.Application["cominfo"] as Bas_ComInfo;
            if (bas_ComInfo.TipsState == 1)
            {
                this.TipsState.Visible = true;
            }
            else
            {
                this.TipsState.Visible = false;
            }
            this.Show();
        }
    }
    private void Show()
    {
        SqlParameter sqlParameter = new SqlParameter();
        sqlParameter.ParameterName = "@uid";
        sqlParameter.Size = 50;
        sqlParameter.Value = this.Uid;
        SqlParameter sqlParameter2 = new SqlParameter();
        sqlParameter2.ParameterName = "@depid";
        sqlParameter2.Size = 50;
        sqlParameter2.Value = this.DepID;
        SqlParameter sqlParameter3 = new SqlParameter();
        sqlParameter3.Direction = ParameterDirection.Output;
        sqlParameter3.ParameterName = "@pt1";
        sqlParameter3.Size = 4;
        SqlParameter sqlParameter4 = new SqlParameter();
        sqlParameter4.Direction = ParameterDirection.Output;
        sqlParameter4.ParameterName = "@pt2";
        sqlParameter4.Size = 4;
        SqlParameter sqlParameter5 = new SqlParameter();
        sqlParameter5.Direction = ParameterDirection.Output;
        sqlParameter5.ParameterName = "@pt3";
        sqlParameter5.Size = 4;
        SqlParameter sqlParameter6 = new SqlParameter();
        sqlParameter6.Direction = ParameterDirection.Output;
        sqlParameter6.ParameterName = "@pt4";
        sqlParameter6.Size = 4;
        SqlParameter sqlParameter7 = new SqlParameter();
        sqlParameter7.Direction = ParameterDirection.Output;
        sqlParameter7.ParameterName = "@pt5";
        sqlParameter7.Size = 4;
        SqlParameter sqlParameter8 = new SqlParameter();
        sqlParameter8.Direction = ParameterDirection.Output;
        sqlParameter8.ParameterName = "@pt6";
        sqlParameter8.Size = 4;
        SqlParameter sqlParameter9 = new SqlParameter();
        sqlParameter9.Direction = ParameterDirection.Output;
        sqlParameter9.ParameterName = "@pt7";
        sqlParameter9.Size = 4;
        SqlParameter sqlParameter10 = new SqlParameter();
        sqlParameter10.Direction = ParameterDirection.Output;
        sqlParameter10.ParameterName = "@pt8";
        sqlParameter10.Size = 4;
        SqlParameter sqlParameter11 = new SqlParameter();
        sqlParameter11.Direction = ParameterDirection.Output;
        sqlParameter11.ParameterName = "@pt10";
        sqlParameter11.Size = 4;
        SqlParameter sqlParameter12 = new SqlParameter();
        sqlParameter12.Direction = ParameterDirection.Output;
        sqlParameter12.ParameterName = "@pt11";
        sqlParameter12.Size = 4;
        SqlParameter sqlParameter13 = new SqlParameter();
        sqlParameter13.Direction = ParameterDirection.Output;
        sqlParameter13.ParameterName = "@pt12";
        sqlParameter13.Size = 4;
        SqlParameter sqlParameter14 = new SqlParameter();
        sqlParameter14.Direction = ParameterDirection.Output;
        sqlParameter14.ParameterName = "@pt13";
        sqlParameter14.Size = 4;
        SqlParameter[] cmdParms = new SqlParameter[]
			{
				sqlParameter3,
				sqlParameter4,
				sqlParameter5,
				sqlParameter6,
				sqlParameter7,
				sqlParameter8,
				sqlParameter9,
				sqlParameter10,
				sqlParameter11,
				sqlParameter12,
				sqlParameter13,
				sqlParameter14,
				sqlParameter,
				sqlParameter2
			};
        using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.StoredProcedure, "Global_GetDesktopData", cmdParms))
        {
            this.news_num = string.Concat(sqlParameter3.Value);
            this.mails_num1 = string.Concat(sqlParameter4.Value);
            this.mails_num2 = string.Concat(sqlParameter5.Value);
            this.flows_num1 = string.Concat(sqlParameter6.Value);
            this.flows_num2 = string.Concat(sqlParameter7.Value);
            this.calendar_num = string.Concat(sqlParameter8.Value);
            this.note_num = string.Concat(sqlParameter9.Value);
            this.mydoc_num = string.Concat(sqlParameter10.Value);
            this.shared_num = string.Concat(sqlParameter11.Value);
            this.shared_num2 = string.Concat(sqlParameter12.Value);
            this.exe_num = string.Concat(sqlParameter13.Value);
            this.man_num = string.Concat(sqlParameter14.Value);
            this.forum_num = string.Concat(MsSqlOperate.ExecuteScalar(CommandType.Text, "select count(id) from wc_forum_reply1 where DateDiff(d,addtime,getdate())=0", new SqlParameter[0]));
            int num = 22;
            if (!string.IsNullOrEmpty(this.px))
            {
                int num2 = Convert.ToInt32(this.px.Split(new char[]
					{
						'?'
					})[0]);
                if (num2 < 1030 && num2 > 1000)
                {
                    num = 22;
                }
                if (num2 < 1000)
                {
                    num = 18;
                }
                if (num2 > 1100 && num2 < 1300)
                {
                    num = 31;
                }
                if (num2 >= 1300)
                {
                    num = 36;
                }
            }
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                string text = string.Format(this.tmp, new object[]
					{
						"News/News_View.aspx?nid=" + dataSet.Tables[0].Rows[i]["id"],
						dataSet.Tables[0].Rows[i]["NewsTitle"],
						Utils.GetSubString2(string.Concat(dataSet.Tables[0].Rows[i]["NewsTitle"]), num, ".."),
						Utils.ConvertDate(dataSet.Tables[0].Rows[i]["addtime"]),
						"资讯" + (i + 1),
						i
					});
                this.qyzx += text;
            }
            int num3 = 7 - dataSet.Tables[0].Rows.Count;
            for (int i = 0; i < num3; i++)
            {
                this.qyzx += this.block_line;
            }
            for (int i = 0; i < dataSet.Tables[1].Rows.Count; i++)
            {
                string text;
                if (string.Concat(dataSet.Tables[1].Rows[i]["isread"]) == "0")
                {
                    text = string.Format(this.tmp_noread, new object[]
						{
							"/Manage/Common/Mail_View.aspx?fid=0&mid=" + dataSet.Tables[1].Rows[i]["id"],
							dataSet.Tables[1].Rows[i]["Subject"] + " - " + Utils.ConvertDate3(dataSet.Tables[1].Rows[i]["SendTime"]),
							Utils.GetSubString2(string.Concat(dataSet.Tables[1].Rows[i]["Subject"]), num + 1, ".."),
							dataSet.Tables[1].Rows[i]["SenderRealName"],
							"未读邮件" + (i + 1),
							i
						});
                }
                else
                {
                    text = string.Format(this.tmp_hasread, new object[]
						{
							"/Manage/Common/Mail_View.aspx?fid=0&mid=" + dataSet.Tables[1].Rows[i]["id"],
							dataSet.Tables[1].Rows[i]["Subject"] + " - " + Utils.ConvertDate3(dataSet.Tables[1].Rows[i]["SendTime"]),
							Utils.GetSubString2(string.Concat(dataSet.Tables[1].Rows[i]["Subject"]), num + 1, ".."),
							dataSet.Tables[1].Rows[i]["SenderRealName"],
							"已读邮件" + (i + 1),
							i
						});
                }
                this.wdyj += text;
            }
            int num4 = 7 - dataSet.Tables[1].Rows.Count;
            for (int i = 0; i < num4; i++)
            {
                this.wdyj += this.block_line;
            }
            int num5 = 0;
            for (int i = 0; i < dataSet.Tables[2].Rows.Count; i++)
            {
                if (i < 7)
                {
                    string text2 = string.Concat(dataSet.Tables[2].Rows[i]["CreatorRealName"]);
                    string arg;
                    if (text2.Trim() == this.RealName)
                    {
                        arg = "[我的申请] ";
                    }
                    else
                    {
                        arg = "[审批/查阅] ";
                    }
                    string text = string.Format(this.tmp_flow, new object[]
						{
							"/Manage/Flow/Flow_View.aspx?fl=" + dataSet.Tables[2].Rows[i]["id"],
							dataSet.Tables[2].Rows[i]["Flow_Name"],
							Utils.GetSubString2(arg + dataSet.Tables[2].Rows[i]["Flow_Name"], num + 1, ".."),
							dataSet.Tables[2].Rows[i]["CreatorRealName"],
							"流程" + (i + 1),
							i
						});
                    if (!this.wdsp.Contains(text))
                    {
                        this.wdsp += text;
                    }
                    else
                    {
                        num5++;
                    }
                }
            }
            int num6 = 7 - Utils.GetSplitNum("<tr><td height=24>", this.wdsp);
            for (int i = 0; i < num6; i++)
            {
                this.wdsp += this.block_line;
            }
            Hashtable hashtable = (Hashtable)HttpContext.Current.Application["stand_config"];
            this.script = string.Concat(hashtable["index_tips"]);
            if (dataSet.Tables[3].Rows.Count > 0)
            {
                string format = " marqueecontent[{0}] = '{1}';  ";
                string str = "";
                for (int i = 0; i < dataSet.Tables[3].Rows.Count; i++)
                {
                    str += string.Format(format, i, string.Concat(dataSet.Tables[3].Rows[i]["tips"]));
                }
                this.script = str;
            }
        }
    }
}