using System;
using System.Collections;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Manage_flow_Flow_ViewTable : ViewPages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected HtmlGenericControl Flow_Name;
        //protected HtmlGenericControl CreatorDepName;
        //protected HtmlGenericControl CreatorRealName;
        //protected HtmlGenericControl AddTime;
        //protected HtmlGenericControl Remark;
        //protected HtmlGenericControl content;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["fl"]))
			{
				this.Show(base.Request.QueryString["fl"]);
			}
		}
		private void Show(string fl)
		{
			FlowsInfo byId = Flows.Init().GetById(Convert.ToInt32(fl));
			if (byId.id > 0)
			{
				string text = "";
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					"<p>0、<b>流程申请</b> &nbsp;&nbsp; ",
					byId.CreatorRealName,
					" 在 ",
					Utils.ConvertDate2(byId.AddTime),
					" 发起流程(申请人) </p>"
				});
				this.Flow_Name.InnerHtml = string.Concat(new object[]
				{
					byId.Flow_Name,
					" &nbsp; (流水编号:",
					byId.AddTime.Year,
					"-",
					100000 + byId.id,
					")"
				});
				this.CreatorRealName.InnerText = byId.CreatorRealName;
				this.CreatorDepName.InnerText = byId.CreatorDepName;
				this.AddTime.InnerText = byId.AddTime.ToString("yyyy-MM-dd");
				this.Remark.InnerHtml = "<br>" + byId.Remark.Replace("\n", "<br>");
				IList all = Flows_StepAction.Init().GetAll("FlowID=" + byId.id, "order by id asc");
				foreach (object current in all)
				{
					Flows_StepActionInfo flows_StepActionInfo = current as Flows_StepActionInfo;
					object obj = text;
					text = string.Concat(new object[]
					{
						obj,
						"<p>",
						all.IndexOf(current) + 1,
						"、<b>",
						flows_StepActionInfo.OperationStepName,
						"</b> &nbsp;&nbsp; ",
						flows_StepActionInfo.UserRealName,
						" 在 ",
						Utils.ConvertDate2(flows_StepActionInfo.AddTime),
						" 已审 ",
						flows_StepActionInfo.OperationWord,
						"</p>"
					});
				}
				this.content.InnerHtml = "<br>" + text + "<br>";
			}
		}
	}
