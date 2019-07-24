using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.DBUtility;
using WC.Model;

public partial class Manage_sys_Role_Manage : ModulePages


	{
        //protected HtmlHead Head1;
        //protected HtmlForm form1;
        //protected Button Button1;
        //protected HtmlInputText RoleName;
        //protected CheckBoxList powerList;
        //protected HtmlTextArea Notes;
        //protected Button save_bt;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				IList all = Sys_Module.Init().GetAll(null, "order by TypeName,Orders");
				for (int i = 0; i < all.Count; i++)
				{
					Sys_ModuleInfo sys_ModuleInfo = all[i] as Sys_ModuleInfo;
					this.powerList.Items.Add(new ListItem("<" + sys_ModuleInfo.TypeName + "> - " + sys_ModuleInfo.ModuleName, string.Concat(sys_ModuleInfo.id)));
				}
				if (!string.IsNullOrEmpty(base.Request.QueryString["rid"]))
				{
					this.Show(base.Request.QueryString["rid"]);
				}
			}
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(base.Request.QueryString["rid"]))
			{
				int num = Convert.ToInt32(base.Request.QueryString["rid"]);
				Sys_RoleInfo sys_RoleInfo = this.ViewState["sr"] as Sys_RoleInfo;
				sys_RoleInfo.RoleName = this.RoleName.Value;
				sys_RoleInfo.Notes = this.Notes.Value;
				Sys_Role.Init().Update(sys_RoleInfo);
				List<string> list = this.ViewState["old_module"] as List<string>;
				List<string> list2 = new List<string>();
				for (int i = 0; i < this.powerList.Items.Count; i++)
				{
					if (this.powerList.Items[i].Selected)
					{
						list2.Add(this.powerList.Items[i].Value);
					}
				}
				for (int i = 0; i < list.Count; i++)
				{
					if (!list2.Contains(list[i]))
					{
						string cmdText = string.Concat(new object[]
						{
							"delete from Sys_Role_Module where RoleID=",
							num,
							" and ModuleID=",
							list[i]
						});
						MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, null);
					}
				}
				for (int i = 0; i < list2.Count; i++)
				{
					if (!list.Contains(list2[i]))
					{
						Sys_Role_ModuleInfo sys_Role_ModuleInfo = new Sys_Role_ModuleInfo();
						sys_Role_ModuleInfo.ModuleID = Convert.ToInt32(list2[i]);
						sys_Role_ModuleInfo.RoleID = num;
						Sys_Role_Module.Init().Add(sys_Role_ModuleInfo);
					}
				}
				string str = HttpContext.Current.Server.HtmlEncode("您好!角色已编辑成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
			else
			{
				Sys_RoleInfo sys_RoleInfo = new Sys_RoleInfo();
				sys_RoleInfo.RoleName = this.RoleName.Value;
				sys_RoleInfo.Notes = this.Notes.Value;
				Sys_Role.Init().Add(sys_RoleInfo);
				for (int i = 0; i < this.powerList.Items.Count; i++)
				{
					if (this.powerList.Items[i].Selected)
					{
						Sys_Role_ModuleInfo sys_Role_ModuleInfo = new Sys_Role_ModuleInfo();
						sys_Role_ModuleInfo.ModuleID = Convert.ToInt32(this.powerList.Items[i].Value);
						sys_Role_ModuleInfo.RoleID = sys_RoleInfo.id;
						Sys_Role_Module.Init().Add(sys_Role_ModuleInfo);
					}
				}
				string str = HttpContext.Current.Server.HtmlEncode("您好!角色已添加成功!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
		}
		private void Show(string id)
		{
			Sys_RoleInfo byId = Sys_Role.Init().GetById(Convert.ToInt32(id));
			this.ViewState["sr"] = byId;
			this.RoleName.Value = byId.RoleName;
			this.Notes.Value = byId.Notes;
			IList all = Sys_Role_Module.Init().GetAll("RoleID=" + id, null);
			List<string> list = new List<string>();
			for (int i = 0; i < all.Count; i++)
			{
				Sys_Role_ModuleInfo sys_Role_ModuleInfo = all[i] as Sys_Role_ModuleInfo;
				list.Add(string.Concat(sys_Role_ModuleInfo.ModuleID));
			}
			this.ViewState["old_module"] = list;
			this.powerListBind(all, this.powerList);
		}
		private void powerListBind(IList list, CheckBoxList cbList)
		{
			for (int i = 0; i < cbList.Items.Count; i++)
			{
				for (int j = 0; j < list.Count; j++)
				{
					Sys_Role_ModuleInfo sys_Role_ModuleInfo = list[j] as Sys_Role_ModuleInfo;
					if (cbList.Items[i].Value == string.Concat(sys_Role_ModuleInfo.ModuleID))
					{
						cbList.Items[i].Selected = true;
					}
				}
			}
		}
	}

