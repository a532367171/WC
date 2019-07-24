using System;
using System.Web.UI.HtmlControls;
using WC.BLL;
using WC.Model;

public partial class Manage_sys_Dep_View : ViewPages

	{
        //protected HtmlForm form1;
        //protected HtmlGenericControl UDepName5;
        //protected HtmlGenericControl father5;
        //protected HtmlGenericControl Phone5;
        //protected HtmlGenericControl IsPosition5;
        //protected HtmlGenericControl Orders5;
        //protected HtmlGenericControl Notes5;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["uid"]))
			{
				this.Show(base.Request.QueryString["uid"]);
			}
			else
			{
				base.Response.Write("<script>alert('信息不存在!');window.close();</script>");
			}
		}
		private void Show(string uid)
		{
			Sys_DepInfo byId = Sys_Dep.Init().GetById(Convert.ToInt32(uid));
			this.UDepName5.InnerText = byId.DepName;
			this.Orders5.InnerText = string.Concat(byId.Orders);
			this.Notes5.InnerText = byId.Notes;
			this.IsPosition5.InnerText = ((byId.IsPosition == 0) ? "职位" : "部门");
			this.Phone5.InnerText = byId.Phone;
			if (byId.ParentID != 0)
			{
				Sys_DepInfo byId2 = Sys_Dep.Init().GetById(Convert.ToInt32(byId.ParentID));
				this.father5.InnerText = byId2.DepName;
			}
			else
			{
				this.father5.InnerText = "无上级 部门/职位";
			}
		}
	}

