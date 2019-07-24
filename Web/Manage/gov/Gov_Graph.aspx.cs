using System;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;

public partial class Manage_gov_Gov_Graph : ViewPages


	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel model_flow;
        //protected HtmlGenericControl fm_name;
        //protected Repeater rpt_mf;
        //protected Panel flow;
        //protected HtmlGenericControl fl_name;
        //protected HtmlGenericControl fl_current;
        //protected Repeater rpt_f;
		protected void Page_Load(object sender, EventArgs e)
		{
			this.Show();
		}
		private void Show()
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["fm"]))
			{
				this.model_flow.Visible = true;
				this.flow.Visible = false;
				Gov_ModelInfo byId = Gov_Model.Init().GetById(Convert.ToInt32(base.Request.QueryString["fm"]));
				this.fm_name.InnerText = byId.Flow_Name;
				IList all = Gov_ModelStep.Init().GetAll("Flow_ModelID=" + byId.id, "order by id asc");
				this.rpt_mf.DataSource = all;
				this.rpt_mf.DataBind();
			}
			if (!string.IsNullOrEmpty(base.Request.QueryString["fl"]))
			{
				this.model_flow.Visible = false;
				this.flow.Visible = true;
				GovInfo byId2 = Gov.Init().GetById(Convert.ToInt32(base.Request.QueryString["fl"]));
				this.fl_name.InnerText = byId2.Flow_Name;
				this.fl_current.InnerHtml = "<u>流程状态</u>：" + this.GetStatus(byId2.Status) + " &nbsp;&nbsp; <u>当前环节</u>：" + byId2.CurrentStepName;
				IList all = Gov_Step.Init().GetAll("isact=0 and flow_id=" + byId2.id, "order by id asc");
				this.rpt_f.DataSource = all;
				this.rpt_f.DataBind();
			}
		}
		private string GetStatus(int t)
		{
			string result;
			if (t == 0)
			{
				result = "公文审批中";
			}
			else
			{
				if (t == 1)
				{
					result = "公文已签发";
				}
				else
				{
					if (t == -1)
					{
						result = "公文已锁定";
					}
					else
					{
						if (t == -2)
						{
							result = "公文已退回";
						}
						else
						{
							if (t == 5)
							{
								result = "公文已归档";
							}
							else
							{
								result = "已过期";
							}
						}
					}
				}
			}
			return result;
		}
	}