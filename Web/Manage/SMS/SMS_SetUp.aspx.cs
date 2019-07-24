using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using WC.BLL;
using WC.Model;

public partial class Manage_SMS_SMS_SetUp : ModulePages

	{
        //protected HtmlForm form1;
        //protected Button Button1;
        // protected CheckBox et2;
        // protected HtmlInputText sms_url;
        // protected HtmlInputText sms_user;
        // protected HtmlInputText sms_pwd;
        // protected HtmlInputText cont_f;
        // protected HtmlInputText cont_g;
        // protected HtmlInputText cont_n;
        // protected HtmlInputText cont_m;
        // protected Label DXYE;
         //protected Button save_bt;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				Bas_ComInfo bas_ComInfo = HttpContext.Current.Application["cominfo"] as Bas_ComInfo;
				this.et2.Checked = Convert.ToBoolean(bas_ComInfo.et2);
				Hashtable hashtable = (Hashtable)HttpContext.Current.Application["sms"];
				string value = string.Concat(hashtable["sms_url"]);
				string text = string.Concat(hashtable["sms_user"]);
				string text2 = string.Concat(hashtable["sms_pwd"]);
				string value2 = string.Concat(hashtable["cont_f"]);
				string value3 = string.Concat(hashtable["cont_g"]);
				string value4 = string.Concat(hashtable["cont_n"]);
				string value5 = string.Concat(hashtable["cont_m"]);
				this.sms_url.Value = value;
				this.sms_user.Value = text;
				this.sms_pwd.Value = text2;
				this.cont_f.Value = value2;
				this.cont_g.Value = value3;
				this.cont_n.Value = value4;
				this.cont_m.Value = value5;
				try
				{
					string str = text;
					string str2 = text2;
					string text3 = "http://sms.webchinese.cn/web_api/SMS/GBK/?Action=SMS_Num&Uid=" + str + "&Key=" + str2;
					string requestUriString = text3.Trim().ToString();
					HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
					httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
					httpWebRequest.Method = "GET";
					httpWebRequest.Timeout = 1800000;
					WebResponse response = httpWebRequest.GetResponse();
					Stream responseStream = response.GetResponseStream();
					StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding("GBK"));
					string text4 = streamReader.ReadToEnd();
					this.DXYE.Text = text4;
				}
				catch
				{
					this.DXYE.Text = "短信查询接口繁忙";
				}
			}
		}
		protected void Save_Btn(object sender, EventArgs e)
		{
			Hashtable hashtable = (Hashtable)HttpContext.Current.Application["sms"];
			hashtable["sms_url"] = this.sms_url.Value;
			hashtable["sms_user"] = this.sms_user.Value;
			hashtable["sms_pwd"] = this.sms_pwd.Value;
			hashtable["cont_f"] = this.cont_f.Value;
			hashtable["cont_g"] = this.cont_g.Value;
			hashtable["cont_n"] = this.cont_n.Value;
			hashtable["cont_m"] = this.cont_m.Value;
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(HttpContext.Current.Server.MapPath("~/sms.config"));
			xmlDocument.SelectSingleNode("sms/sms_url").Attributes["Value"].Value = this.sms_url.Value;
			xmlDocument.SelectSingleNode("sms/sms_user").Attributes["Value"].Value = this.sms_user.Value;
			xmlDocument.SelectSingleNode("sms/sms_pwd").Attributes["Value"].Value = this.sms_pwd.Value;
			xmlDocument.SelectSingleNode("sms/cont_f").Attributes["Value"].Value = this.cont_f.Value;
			xmlDocument.SelectSingleNode("sms/cont_g").Attributes["Value"].Value = this.cont_g.Value;
			xmlDocument.SelectSingleNode("sms/cont_n").Attributes["Value"].Value = this.cont_n.Value;
			xmlDocument.SelectSingleNode("sms/cont_m").Attributes["Value"].Value = this.cont_m.Value;
			xmlDocument.Save(HttpContext.Current.Server.MapPath("~/sms.config"));
			Bas_ComInfo bas_ComInfo = HttpContext.Current.Application["cominfo"] as Bas_ComInfo;
			bas_ComInfo.et2 = Convert.ToInt32(this.et2.Checked);
			HttpContext.Current.Application["cominfo"] = bas_ComInfo;
			string str = HttpContext.Current.Server.HtmlEncode("您好!短信设置修改已成功!");
			base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
		}
	}
