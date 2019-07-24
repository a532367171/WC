using System;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;

public partial class Manage_Attend_WorkSet : ModulePages

	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Panel p_list;
        //protected Repeater rpt;
        //protected HtmlGenericControl num;
        //protected Panel p_edit;
        //protected DropDownList AttendNames1;
        //protected DropDownList ddl_hour;
        //protected DropDownList ddl_minute;
        //protected Button save_bt;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && !string.IsNullOrEmpty(base.Request.QueryString["type"]))
			{
				if (base.Request.QueryString["type"] == "edit")
				{
					this.Edit_Show();
				}
				if (base.Request.QueryString["type"] == "del" && !string.IsNullOrEmpty(base.Request.QueryString["manage"]))
				{
					int id = Convert.ToInt32(base.Request.QueryString["manage"]);
					Work_AttendSet.Init().Delete(id);
					base.Response.Redirect("WorkSet.aspx?type=edit");
				}
			}
		}
		private void Edit_Show()
		{
			this.p_edit.Visible = true;
			this.p_list.Visible = true;
			if (!string.IsNullOrEmpty(base.Request.QueryString["manage"]))
			{
				Work_AttendSetInfo byId = Work_AttendSet.Init().GetById(Convert.ToInt32(base.Request.QueryString["manage"]));
				this.ViewState["wi"] = byId;
				this.AttendNames1.SelectedValue = byId.AttendNames;
				if (byId.AttendTimes.Contains(":"))
				{
					this.ddl_hour.SelectedValue = byId.AttendTimes.Split(new char[]
					{
						':'
					})[0];
					this.ddl_minute.SelectedValue = byId.AttendTimes.Split(new char[]
					{
						':'
					})[1];
				}
			}
			IList all = Work_AttendSet.Init().GetAll(null, null);
			this.rpt.DataSource = all;
			this.rpt.DataBind();
			this.num.InnerHtml = "当前 总计 - <span style='color:#ff0000; font-weight:bold;'>" + all.Count + "</span> 个 记录数据";
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["manage"]))
			{
				Work_AttendSetInfo work_AttendSetInfo = this.ViewState["wi"] as Work_AttendSetInfo;
				work_AttendSetInfo.AttendNames = this.AttendNames1.SelectedValue;
				work_AttendSetInfo.AttendTimes = this.ddl_hour.SelectedValue + ":" + this.ddl_minute.SelectedValue;
				Work_AttendSet.Init().Update(work_AttendSetInfo);
				base.Response.Write("<script>alert('编辑上下班时间成功!');window.location='WorkSet.aspx?type=edit'</script>");
			}
			else
			{
				Work_AttendSetInfo work_AttendSetInfo = new Work_AttendSetInfo();
				work_AttendSetInfo.AttendNames = this.AttendNames1.SelectedValue;
				work_AttendSetInfo.AttendTimes = this.ddl_hour.SelectedValue + ":" + this.ddl_minute.SelectedValue;
				Work_AttendSet.Init().Add(work_AttendSetInfo);
				base.Response.Write("<script>alert('添加上下班时间成功!');window.location='WorkSet.aspx?type=edit'</script>");
			}
		}
	}
