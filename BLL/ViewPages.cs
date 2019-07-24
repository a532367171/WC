using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using WC.Model;
using WC.Tool;
namespace WC.BLL
{
    public class ViewPages : Page
    {
        protected string Uid;
        protected string UserName;
        protected string RealName;
        protected string DepID;
        protected string DepName;
        protected string Modules;
        protected string CurrentLoginTime;
        protected string px;
        public ViewPages()
        {
            Admin_Help.UpdateApp();
            this.Context.Response.Cache.SetNoStore();
            base.Load += new EventHandler(this.AdminPage_Load);
        }
        private void AdminPage_Load(object sender, EventArgs e)
        {
            this.IsLoginUser();
        }
        private void IsLoginUser()
        {
            string absoluteUri = this.Context.Request.Url.AbsoluteUri;
            if (this.Context.Request.Cookies["UserCookies"] != null && this.Context.Request.Cookies["UserCookies"]["key"] != null)
            {
                string decryptString = this.Context.Request.Cookies["UserCookies"]["key"].ToString();
                
                //string text = Encrypt.RC4_Decode(decryptString, "lazy_oa");

                string text = Encrypt.DecryptString(decryptString, "lazy1111");


                if (text.Contains("|") && (HttpContext.Current.Session["UserCookies"] == null || string.IsNullOrEmpty(string.Concat(HttpContext.Current.Session["UserCookies"]))))
                {
                    HttpContext.Current.Session["UserCookies"] = text;
                }
            }
            if (HttpContext.Current.Session["UserCookies"] == null || string.IsNullOrEmpty(string.Concat(HttpContext.Current.Session["UserCookies"])))
            {
                this.Context.Response.Redirect("~/InfoTip/Operate_Redirect.aspx?type=1&url=" + absoluteUri);
            }
            else
            {
                if (!string.IsNullOrEmpty(string.Concat(HttpContext.Current.Session["UserCookies"])))
                {
                    string text2 = string.Concat(HttpContext.Current.Session["UserCookies"]);
                    if (text2.Contains("|"))
                    {
                        Hashtable hashtable = (Hashtable)HttpContext.Current.Application["stand_config"];
                        Convert.ToInt32(hashtable["user_cookie_delay"]);
                        this.Uid = text2.Split(new char[]
						{
							'|'
						})[0];
                        this.UserName = text2.Split(new char[]
						{
							'|'
						})[1];
                        this.RealName = text2.Split(new char[]
						{
							'|'
						})[2];
                        this.DepID = text2.Split(new char[]
						{
							'|'
						})[3];
                        this.DepName = text2.Split(new char[]
						{
							'|'
						})[4];
                        this.Modules = text2.Split(new char[]
						{
							'|'
						})[5];
                        this.CurrentLoginTime = text2.Split(new char[]
						{
							'|'
						})[6];
                        this.px = text2.Split(new char[]
						{
							'|'
						})[7];
                        List<Sys_UserInfo> list = HttpContext.Current.Application["user_online"] as List<Sys_UserInfo>;
                        Sys_UserInfo su = null;
                        list.Find(delegate(Sys_UserInfo s)
                        {
                            bool result;
                            if (s.id.ToString() == this.Uid)
                            {
                                su = s;
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                            return result;
                        });
                        if (Utils.IsNumber(string.Concat(HttpContext.Current.Application[this.GetUtt()])))
                        {
                            int num = Convert.ToInt32(string.Concat(HttpContext.Current.Application[this.GetUtt()]));
                            int num2 = 5000;
                            int num3 = 30;
                            if (num > 30 && num <= num2)
                            {
                                int num4 = 0;
                                try
                                {
                                    num4 = Convert.ToInt32(HttpContext.Current.Application[this.JavaScriptGetUrlAction()]);
                                }
                                catch
                                {
                                    num4 = 0;
                                }
                                if (num4 != this.JavascriptOpenDiv() && Utils.IsRandomHit(10))
                                {
                                    this.Context.Response.Write(string.Concat(new object[]
									{
										"<script>if(window.parent !=null){window.parent.location='/InfoTip/Operate_Reg.aspx?tips=",
										num3,
										"';}else{window.location='/InfoTip/Operate_Reg.aspx?tips=",
										num3,
										"';}</script>"
									}));
                                    return;
                                }
                            }
                            if (num > num2 && Utils.IsRandomHit(8))
                            {
                                this.Context.Response.Write(string.Concat(new object[]
								{
									"<script>if(window.parent !=null){window.parent.location='/InfoTip/Operate_Reg.aspx?ns=",
									num2,
									"';}else{window.location='/InfoTip/Operate_Reg.aspx?ns=",
									num2,
									"';}</script>"
								}));
                                return;
                            }
                        }
                        if (su != null)
                        {
                            su.IsOnline = 1;
                            su.LastLoginTime = DateTime.Now;
                            if (!string.IsNullOrEmpty(su.CurrentLoginTime) && su.CurrentLoginTime == this.CurrentLoginTime)
                            {
                                string value = text2;
                                HttpContext.Current.Session["UserCookies"] = value;
                            }
                        }
                        if (!Utils.IsNumber(this.Uid ?? ""))
                        {
                            this.Context.Response.Redirect("~/InfoTip/Operate_Redirect.aspx?type=2&url=" + absoluteUri);
                        }
                    }
                    else
                    {
                        this.Context.Response.Redirect("~/InfoTip/Operate_Redirect.aspx?type=2&url=" + absoluteUri);
                    }
                }
                else
                {
                    this.Context.Response.Redirect("~/InfoTip/Operate_Redirect.aspx?type=2&url=" + absoluteUri);
                }
            }
        }
        protected void Page_Error(object sender, EventArgs e)
        {
            Exception lastError = base.Server.GetLastError();
            ErrorLog.ToTxt(lastError, base.Server.MapPath("~/DK_Log/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log"), base.Request.UserHostAddress + "|" + base.Request.Url);
            if (lastError is NullReferenceException)
            {
                base.Response.Redirect("~/InfoTip/nofind.htm");
            }
            if (lastError is HttpRequestValidationException || lastError is HttpException)
            {
                base.Server.ClearError();
            }
            else
            {
                base.Response.Redirect("~/InfoTip/Error.htm");
            }
        }
        private int JavascriptOpenDiv()
        {
            byte[] bytes = new byte[]
			{
				57,
				48,
				49,
				49,
				51,
				53,
				56,
				55
			};
            string @string = Encoding.UTF8.GetString(bytes);
            return Convert.ToInt32(@string);
        }
        private string JavaScriptGetUrlAction()
        {
            byte[] bytes = new byte[]
			{
				99,
				118,
				112,
				115
			};
            //cvps

            return Encoding.UTF8.GetString(bytes);
        }
        private string GetUtt()
        {
            byte[] bytes = new byte[]
			{
				117,
				116,
				116,
				115,
				116,
				97,
				114,
				115,
				49,
				48,
				50,
				56,
				56
			};
            //uttstars10288

            return Encoding.UTF8.GetString(bytes);
        }
    }
}
