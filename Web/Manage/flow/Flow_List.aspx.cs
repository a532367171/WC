using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;

public partial class Manage_flow_Flow_List : ViewPages
{
    //protected HtmlHead Head1;
    //protected HtmlForm form1;
    //protected HtmlGenericControl wdpy;
    //protected HtmlGenericControl yjpy;
    //protected HtmlGenericControl wdsq;
    //protected HtmlGenericControl view;
    //protected Panel panLogin;
    //protected Button search_bt;
    //protected Repeater rpt;
    //protected HtmlGenericControl num;
    protected string flow_list = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            if (!string.IsNullOrEmpty(base.Request.QueryString["action"]))
            {
                this.Show(base.Request.QueryString["action"]);
            }
            else
            {
                base.Response.Write("<script>alert('非法的请求!');window.location='Flow_Manage.aspx'</script>");
            }
        }
    }
    protected void Search_Btn(object sender, EventArgs e)
    {
        string str = base.Request.Form["keyword"];
        string str2 = "?action=" + base.Request.QueryString["action"] + "&keywords=" + str;
        base.Response.Redirect("Flow_List.aspx" + str2);
    }
    private void Show(string type)
    {
        SqlParameter sqlParameter = new SqlParameter();
        sqlParameter.ParameterName = "@uid";
        sqlParameter.Size = 50;
        sqlParameter.Value = this.Uid;
        SqlParameter sqlParameter2 = new SqlParameter();
        sqlParameter2.Direction = ParameterDirection.Output;
        sqlParameter2.ParameterName = "@pt1";
        sqlParameter2.Size = 4;
        SqlParameter sqlParameter3 = new SqlParameter();
        sqlParameter3.Direction = ParameterDirection.Output;
        sqlParameter3.ParameterName = "@pt2";
        sqlParameter3.Size = 4;
        SqlParameter sqlParameter4 = new SqlParameter();
        sqlParameter4.Direction = ParameterDirection.Output;
        sqlParameter4.ParameterName = "@pt3";
        sqlParameter4.Size = 4;
        SqlParameter sqlParameter5 = new SqlParameter();
        sqlParameter5.Direction = ParameterDirection.Output;
        sqlParameter5.ParameterName = "@pt4";
        sqlParameter5.Size = 4;
        SqlParameter[] cmdParms = new SqlParameter[]
			{
				sqlParameter2,
				sqlParameter3,
				sqlParameter4,
				sqlParameter5,
				sqlParameter
			};
        MsSqlOperate.ExecuteNonQuery(CommandType.StoredProcedure, "Flows_GetUserFlowBoxCount", cmdParms);
        this.wdpy.InnerText = string.Concat(sqlParameter2.Value);
        this.yjpy.InnerText = string.Concat(sqlParameter3.Value);
        this.wdsq.InnerText = string.Concat(sqlParameter4.Value);
        this.view.InnerText = string.Concat(sqlParameter5.Value);
        if (type == "verify")
        {
            this.flow_list = ">> 我的批阅";
            string cmdText;
            if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
            {
                string text = base.Request.QueryString["keywords"];
                string text2 = string.Concat(new string[]
					{
						" (Flow_Name like '%",
						text,
						"%' or CreatorRealName like '%",
						text,
						"%' ) "
					});
                cmdText = string.Concat(new string[]
					{
						"select a.* from flows a where a.status=0 and a.CurrentStepUserList like '%#",
						this.Uid,
						"#%' and a.CurrentStepID not in (select b.OperationStepID from Flows_StepAction b where b.UserID=",
						this.Uid,
						" and b.FlowID=a.id ) and ",
						text2
					});
                using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
                {
                    this.CutPage(dataSet, "verify");
                    goto IL_330;
                }
            }
            cmdText = string.Concat(new string[]
				{
					"select a.* from flows a where a.status=0 and a.CurrentStepUserList like '%#",
					this.Uid,
					"#%' and a.CurrentStepID not in (select b.OperationStepID from Flows_StepAction b where b.UserID=",
					this.Uid,
					" and b.FlowID=a.id ) order by a.id desc"
				});
            if (!string.IsNullOrEmpty(base.Request.QueryString["td"]))
            {
                cmdText = string.Concat(new string[]
					{
						"select a.* from flows a where a.comid=",
						base.Request.QueryString["td"],
						" and a.status=0 and a.CurrentStepUserList like '%#",
						this.Uid,
						"#%' and a.CurrentStepID not in (select b.OperationStepID from Flows_StepAction b where b.UserID=",
						this.Uid,
						" and b.FlowID=a.id ) order by a.id desc"
					});
            }
            using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, cmdText, new SqlParameter[0]))
            {
                this.CutPage(dataSet, "verify");
            }
        }
    IL_330:
        if (type == "verified")
        {
            this.flow_list = ">> 已经批阅";
            IList all;
            if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
            {
                string text = base.Request.QueryString["keywords"];
                string text2 = string.Concat(new string[]
					{
						"(Flow_Name like '%",
						text,
						"%' or CreatorRealName like '%",
						text,
						"%' ) and "
					});
                all = Flows.Init().GetAll(text2 + " HasOperatedUserList like '%#" + this.Uid + "#%'", "order by id desc");
            }
            else
            {
                if (string.IsNullOrEmpty(base.Request.QueryString["td"]))
                {
                    all = Flows.Init().GetAll("HasOperatedUserList like '%#" + this.Uid + "#%'", "order by id desc");
                }
                else
                {
                    all = Flows.Init().GetAll(string.Concat(new string[]
						{
							"comid=",
							base.Request.QueryString["td"],
							" and HasOperatedUserList like '%#",
							this.Uid,
							"#%'"
						}), "order by id desc");
                }
            }
            this.CutPage(all, "verified");
        }
        if (type == "apply")
        {
            this.flow_list = ">> 我的申请";
            IList all;
            if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
            {
                string text = base.Request.QueryString["keywords"];
                string text2 = string.Concat(new string[]
					{
						"(Flow_Name like '%",
						text,
						"%' or CreatorRealName like '%",
						text,
						"%') and "
					});
                all = Flows.Init().GetAll(text2 + " CreatorID=" + this.Uid, "order by id desc");
            }
            else
            {
                if (string.IsNullOrEmpty(base.Request.QueryString["td"]))
                {
                    all = Flows.Init().GetAll("CreatorID=" + this.Uid, "order by id desc");
                }
                else
                {
                    all = Flows.Init().GetAll("comid=" + base.Request.QueryString["td"] + " and CreatorID=" + this.Uid, "order by id desc");
                }
            }
            this.CutPage(all, "apply");
        }
        if (type == "view")
        {
            this.flow_list = ">> 抄送呈报";
            IList all;
            if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
            {
                string text = base.Request.QueryString["keywords"];
                string text2 = string.Concat(new string[]
					{
						"(Flow_Name like '%",
						text,
						"%' or CreatorRealName like '%",
						text,
						"%' ) and "
					});
                all = Flows.Init().GetAll(text2 + " ViewUserList like '%#" + this.Uid + "#%'", "order by id desc");
            }
            else
            {
                if (string.IsNullOrEmpty(base.Request.QueryString["td"]))
                {
                    all = Flows.Init().GetAll("ViewUserList like '%#" + this.Uid + "#%'", "order by id desc");
                }
                else
                {
                    all = Flows.Init().GetAll(string.Concat(new string[]
						{
							"comid=",
							base.Request.QueryString["td"],
							" and ViewUserList like '%#",
							this.Uid,
							"#%'"
						}), "order by id desc");
                }
            }
            this.CutPage(all, "view");
        }
    }
    private void CutPage(IList list, string action)
    {
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
        if (string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
        {
            if (string.IsNullOrEmpty(base.Request.QueryString["td"]))
            {
                this.Page2.sty("meneame", num, pagedDataSource.PageCount, "?action=" + action + "&page=");
            }
            else
            {
                this.Page2.sty("meneame", num, pagedDataSource.PageCount, string.Concat(new string[]
					{
						"?action=",
						action,
						"&td=",
						base.Request.QueryString["td"],
						"&page="
					}));
            }
        }
        if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
        {
            this.Page2.sty("meneame", num, pagedDataSource.PageCount, string.Concat(new string[]
				{
					"?action=",
					action,
					"&keywords=",
					base.Request.QueryString["keywords"],
					"&page="
				}));
        }
        this.rpt.DataSource = pagedDataSource;
        this.rpt.DataBind();
        this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + list.Count + "</span> 条 记录数据";
    }
    private void CutPage(DataSet ds, string action)
    {
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
        pagedDataSource.DataSource = ds.Tables[0].DefaultView;
        pagedDataSource.AllowPaging = true;
        pagedDataSource.PageSize = pageSize;
        pagedDataSource.CurrentPageIndex = num - 1;
        this.rpt.DataSource = pagedDataSource;
        this.rpt.DataBind();
        if (string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
        {
            if (string.IsNullOrEmpty(base.Request.QueryString["td"]))
            {
                this.Page2.sty("meneame", num, pagedDataSource.PageCount, "?action=" + action + "&page=");
            }
            else
            {
                this.Page2.sty("meneame", num, pagedDataSource.PageCount, string.Concat(new string[]
					{
						"?action=",
						action,
						"&td=",
						base.Request.QueryString["td"],
						"&page="
					}));
            }
        }
        if (!string.IsNullOrEmpty(base.Request.QueryString["keywords"]))
        {
            this.Page2.sty("meneame", num, pagedDataSource.PageCount, string.Concat(new string[]
				{
					"?action=",
					action,
					"&keywords=",
					base.Request.QueryString["keywords"],
					"&page="
				}));
        }
        this.rpt.DataSource = pagedDataSource;
        this.rpt.DataBind();
        this.num.InnerHtml = "当前查询条件总计 - <span style='color:#ff0000; font-weight:bold;'>" + ds.Tables[0].Rows.Count + "</span> 条 记录数据";
    }
    protected string GetStatus(object obj)
    {
        int num = Convert.ToInt32(obj);
        string result;
        if (num == 0)
        {
            if (base.Request.QueryString["action"] == "verify")
            {
                result = "<span style='color:#ff0000;'>待审批</span>";
            }
            else
            {
                result = "<span style='color:#ff0000;'>审批中</span>";
            }
        }
        else
        {
            if (num == 1)
            {
                result = "<span style='color:#006600;font-weight:bold'>已完成</span>";
            }
            else
            {
                if (num == -1)
                {
                    result = "<span style='color:#999999;font-weight:bold'>已锁定</span>";
                }
                else
                {
                    if (num == -2)
                    {
                        result = "<span style='color:black;font-weight:bold'>已退回</span>";
                    }
                    else
                    {
                        result = "<span style='color:blue;'>已过期</span>";
                    }
                }
            }
        }
        return result;
    }
    protected string GetTrTitle(object t)
    {
        string result = "";
        string text = base.Request.QueryString["action"];
        if (!string.IsNullOrEmpty(text))
        {
            if (text.ToLower().Contains("verify"))
            {
                result = "您需要审批的流程：" + t;
            }
            if (text.ToLower().Contains("verified"))
            {
                result = "您已经审批过的流程：" + t;
            }
            if (text.ToLower().Contains("apply"))
            {
                result = "您申请的工作流程：" + t;
            }
            if (text.ToLower().Contains("view"))
            {
                result = "抄送呈报给您的工作流程：" + t;
            }
        }
        return result;
    }
    protected string GetSelected(string i)
    {
        string a = base.Request.QueryString["action"] ?? "";
        string result;
        if (a == (i ?? ""))
        {
            result = "class='selected'";
        }
        else
        {
            result = "";
        }
        return result;
    }
}