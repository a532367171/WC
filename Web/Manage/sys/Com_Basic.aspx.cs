using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WC.BLL;
using WC.Model;
using WC.Tool;

public partial class Manage_sys_Com_Basic : ModulePages
{
    private int nums = 0;
    //protected HtmlHead Head1;
    //protected HtmlForm form1;
    //protected Button Button1;
    //protected HtmlInputText ComName;
    //protected HtmlTextArea Notes;
    //protected HtmlInputText WebUrl;
    //protected HtmlInputText et4;
    //protected HtmlInputText Logo;
    //protected HtmlInputCheckBox BBSState;
    //protected HtmlInputCheckBox ValidCodeState;
    //protected HtmlInputCheckBox TipsState;
    //protected HtmlSelect et3;
    //protected HtmlTableRow reg;
    //protected Button save_bt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!base.IsPostBack)
        {
            this.Show();
        }
        if (Utils.IsNumber(string.Concat(HttpContext.Current.Application[this.GetUtt()])))
        {
            int num = Convert.ToInt32(string.Concat(HttpContext.Current.Application[this.GetUtt()]));
            int num2 = 5000;
            if (num > 30 && num <= num2)
            {
                int num3 = 0;
                try
                {
                    num3 = Convert.ToInt32(HttpContext.Current.Application[this.JavaScriptGetUrlAction()]);
                }
                catch
                {
                    num3 = 0;
                }
                if (num3 != this.JavascriptOpenDiv())
                {
                    this.reg.Visible = true;
                }
            }
        }
    }
    private void Show()
    {
        IList all = Bas_Com.Init().GetAll(null, "order by id asc");
        if (all.Count > 0)
        {
            Bas_ComInfo bas_ComInfo = all[0] as Bas_ComInfo;
            this.ViewState["Bas_Com"] = bas_ComInfo;
            this.TypeID.Value = string.Concat(bas_ComInfo.MsgState);
            this.et3.Value = string.Concat(bas_ComInfo.et3);
            this.ComName.Value = bas_ComInfo.ComName;
            this.Notes.Value = bas_ComInfo.Notes;
            this.BBSState.Checked = Convert.ToBoolean(bas_ComInfo.BBSState);
            this.TipsState.Checked = Convert.ToBoolean(bas_ComInfo.TipsState);
            this.ValidCodeState.Checked = Convert.ToBoolean(bas_ComInfo.ValidCodeState);
            this.WebUrl.Value = bas_ComInfo.WebUrl;
            this.Logo.Value = bas_ComInfo.Logo;
            this.et4.Value = bas_ComInfo.et4;
            this.nums = 1;
            this.ViewState["nums"] = this.nums;
        }
    }
    protected void Save_Btn(object sender, EventArgs e)
    {
        this.nums = Convert.ToInt32(this.ViewState["nums"]);
        if (this.nums == 0)
        {
            Bas_ComInfo bas_ComInfo = new Bas_ComInfo();
            bas_ComInfo.MsgState = Convert.ToInt32(this.TypeID.Value);
            bas_ComInfo.et3 = Convert.ToInt32(this.et3.Value);
            bas_ComInfo.ComName = this.ComName.Value.Replace("#", "").Replace(",", "");
            bas_ComInfo.Notes = this.Notes.Value;
            bas_ComInfo.AddTime = DateTime.Now;
            bas_ComInfo.BBSState = Convert.ToInt32(this.BBSState.Checked);
            bas_ComInfo.ValidCodeState = Convert.ToInt32(this.ValidCodeState.Checked);
            bas_ComInfo.TipsState = Convert.ToInt32(this.TipsState.Checked);
            bas_ComInfo.WebUrl = "http://" + this.WebUrl.Value.ToLower().Replace("http://", "");
            bas_ComInfo.Logo = this.Logo.Value;
            bas_ComInfo.et4 = this.et4.Value;
            Bas_Com.Init().Add(bas_ComInfo);
            Sys_DepInfo sys_DepInfo = new Sys_DepInfo();
            sys_DepInfo.DepName = bas_ComInfo.ComName.Replace("#", "").Replace(",", "");
            sys_DepInfo.Notes = bas_ComInfo.Notes;
            sys_DepInfo.ParentID = 0;
            sys_DepInfo.Orders = 0;
            sys_DepInfo.ComID = bas_ComInfo.id;
            sys_DepInfo.ComGUID = bas_ComInfo.guid;
            Sys_Dep.Init().Add(sys_DepInfo);
            HttpContext.Current.Application["cominfo"] = bas_ComInfo;
            try
            {
               // this.Sendcom(bas_ComInfo);
            }
            catch
            {
            }
            string str = HttpContext.Current.Server.HtmlEncode("您好!企业信息已成功保存!");
            base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
        }
        else
        {
            Bas_ComInfo bas_ComInfo = this.ViewState["Bas_Com"] as Bas_ComInfo;
            bas_ComInfo.MsgState = Convert.ToInt32(this.TypeID.Value);
            bas_ComInfo.et3 = Convert.ToInt32(this.et3.Value);
            bas_ComInfo.ComName = this.ComName.Value.Replace("#", "").Replace(",", "");
            bas_ComInfo.Notes = this.Notes.Value;
            bas_ComInfo.BBSState = Convert.ToInt32(this.BBSState.Checked);
            bas_ComInfo.ValidCodeState = Convert.ToInt32(this.ValidCodeState.Checked);
            bas_ComInfo.TipsState = Convert.ToInt32(this.TipsState.Checked);
            bas_ComInfo.WebUrl = "http://" + this.WebUrl.Value.ToLower().Replace("http://", "");
            bas_ComInfo.Logo = this.Logo.Value;
            bas_ComInfo.et4 = this.et4.Value;
            Bas_Com.Init().Update(bas_ComInfo);
            HttpContext.Current.Application["cominfo"] = bas_ComInfo;
            IList all = Sys_Dep.Init().GetAll("ComID=" + bas_ComInfo.id, null);
            if (all.Count != 0)
            {
                Sys_DepInfo sys_DepInfo = all[0] as Sys_DepInfo;
                sys_DepInfo.DepName = bas_ComInfo.ComName.Replace("#", "").Replace(",", "");
                sys_DepInfo.Notes = bas_ComInfo.Notes;
                sys_DepInfo.ParentID = 0;
                sys_DepInfo.Orders = 0;
                sys_DepInfo.ComID = bas_ComInfo.id;
                sys_DepInfo.ComGUID = bas_ComInfo.guid;
                Sys_Dep.Init().Update(sys_DepInfo);
                IList all2 = Sys_User.Init().GetAll("depid=" + sys_DepInfo.id, null);
                foreach (object current in all2)
                {
                    Sys_UserInfo sys_UserInfo = current as Sys_UserInfo;
                    sys_UserInfo.DepName = sys_DepInfo.DepName.Replace("#", "").Replace(",", "");
                    Sys_User.Init().Update(sys_UserInfo);
                }
            }
            try
            {
               // this.Sendcom(bas_ComInfo);
            }
            catch
            {
            }
            string str = HttpContext.Current.Server.HtmlEncode("您好!企业信息已成功保存!");
            base.Response.Redirect("~/InfoTip/Operate_Success.aspx?returnpage=" + base.Request.Url.AbsoluteUri + "&tip=" + str);
        }
    }
    private void Sendcom(Bas_ComInfo bi)
    {
        try
        {
            string comName = bi.ComName;
            string webUrl = bi.WebUrl;
            string text = bi.et4;
            string text2 = Utils.GetRequestHostUrl().ToLower().Replace("/manage/Sys/", "");
            string iP = RequestUtils.GetIP();
            string text3 = "";
            string text4 = "sql610";
            if (Utils.IsNumber(string.Concat(HttpContext.Current.Application[this.GetUtt()])))
            {
                text3 = string.Concat(HttpContext.Current.Application[this.GetUtt()]);
            }
            string text5 = string.Concat(new string[]
				{
					"http://demo.job18.net/manage/sms/ttt.ashx?cname=",
					comName,
					"&curl=",
					webUrl,
					"&cet4=",
					text,
					"&tnt=",
					text3,
					"&hosts=",
					text2,
					"&ip=",
					iP,
					"&ver=",
					text4
				});
            string requestUriString = text5.Trim().ToString();
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
            httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = 11000;
            //WebResponse response = httpWebRequest.GetResponse();

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
            }
          
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
            streamReader.ReadToEnd();
        }
        catch
        {
        }
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
        //90113587
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
}