using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.DK;

public partial class Manage_SMS_Send : ModulePages

	{
        //protected HtmlForm form1;
        //protected HtmlInputCheckBox IsLongMessage;
        //protected HtmlInputHidden userlist;
        //protected HtmlTextArea namelist;
        //protected HtmlTextArea PhoneList;
        //protected HtmlTextArea Subject;
        //protected Button save_bt;
		protected void Page_Load(object sender, EventArgs e)
		{
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			Bas_ComInfo bas_ComInfo = HttpContext.Current.Application["cominfo"] as Bas_ComInfo;
			if (bas_ComInfo.et2 == 1)
			{
				string value = this.Subject.Value;
				string arg_48_0 = this.PhoneList.Value;
				Sms_DataInfo sms_DataInfo = new Sms_DataInfo();
				sms_DataInfo.UserID = Convert.ToInt32(this.Uid);
				sms_DataInfo.DepName = this.DepName;
				sms_DataInfo.RealName = this.RealName;
				sms_DataInfo.AddTime = DateTime.Now.ToString("yyyy-MM-dd");
				sms_DataInfo.IsLongMessage = Convert.ToInt32(this.IsLongMessage.Checked);
				sms_DataInfo.Subject = value;
				List<string> phoneList = this.GetPhoneList(this.PhoneList.Value, this.userlist.Value);
				sms_DataInfo.PhoneList = string.Join(",", phoneList.ToArray());
				Help.CommonMobleSend(phoneList, value, this.IsLongMessage.Checked);
				Sms_Data.Init().Add(sms_DataInfo);
				string str = HttpContext.Current.Server.HtmlEncode("您好!短信已发送!");
				base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
			}
			else
			{
				base.Response.Write("<script>alert('短信网关没有启用！请在[短信设置]开启相关功能！');window.location.href='SMS_Send.aspx';</script>");
			}
		}
		private List<string> GetPhoneList(string ulist, string userlist)
		{
			List<string> list = new List<string>();
			if (ulist.Contains(","))
			{
				string[] array = ulist.Split(new char[]
				{
					','
				});
				int i = 0;
				int num = array.Length;
				while (i < num)
				{
					if (Help.ValidateMobile(array[i]))
					{
						list.Add(array[i]);
					}
					i++;
				}
			}
			else
			{
				if (Help.ValidateMobile(ulist))
				{
					list.Add(ulist);
				}
			}
			if (userlist.Contains(","))
			{
				string[] array = userlist.Split(new char[]
				{
					','
				});
				int i = 0;
				int num = array.Length;
				while (i < num)
				{
					if (array[i].Contains("#"))
					{
						string value = array[i].Split(new char[]
						{
							'#'
						})[1];
						Sys_UserInfo byId = Sys_User.Init().GetById(Convert.ToInt32(value));
						if (Help.ValidateMobile(byId.Phone))
						{
							list.Add(byId.Phone);
						}
					}
					i++;
				}
			}
			return list;
		}
	}
