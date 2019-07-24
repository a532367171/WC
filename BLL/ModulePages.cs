using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using WC.Model;
using WC.Tool;
namespace WC.BLL
{
    public class ModulePages : Page
    {
        protected string Uid;
        protected string UserName;
        protected string RealName;
        protected string DepID;
        protected string DepName;
        protected string Modules;
        protected string CurrentLoginTime;
        protected string px;
        public ModulePages()
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
            string value = "has no any modules!!";
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
                        if (su != null)
                        {
                            su.IsOnline = 1;
                            su.LastLoginTime = DateTime.Now;
                            if (!string.IsNullOrEmpty(su.CurrentLoginTime) && su.CurrentLoginTime == this.CurrentLoginTime)
                            {
                                string value2 = text2;
                                HttpContext.Current.Session["UserCookies"] = value2;
                            }
                        }
                        Hashtable hashtable2 = (Hashtable)HttpContext.Current.Application["moduleid_moduleurl"];
                        foreach (DictionaryEntry dictionaryEntry in hashtable2)
                        {
                            string text3 = string.Concat(dictionaryEntry.Value);
                            if (absoluteUri.ToLower().Contains(text3.ToLower()))
                            {
                                value = string.Concat(dictionaryEntry.Key);
                            }
                        }
                        IList list2 = new ArrayList();
                        string[] array = this.Modules.Split(new char[]
						{
							','
						});
                        for (int i = 0; i < array.Length; i++)
                        {
                            list2.Add(array[i]);
                        }
                        if (!list2.Contains(value))
                        {
                            this.Context.Response.Write("<script>window.location='/InfoTip/Operate_Nopower.aspx?ReturnUrl=" + absoluteUri + "'</script>");
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(this.Uid) && !Utils.IsNumber(this.Uid))
                            {
                                this.Context.Response.Redirect("~/InfoTip/Operate_Redirect.aspx?type=2&url=" + absoluteUri);
                            }
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
            if (lastError is HttpRequestValidationException)
            {
                base.Server.ClearError();
            }
            else
            {
                base.Response.Redirect("~/InfoTip/Error.htm");
            }
        }
    }
}
