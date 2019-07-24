//using System;
//using System.Web;

//namespace WC.Tool
//{
//    public class RequestUtils
//    {
//        public static string GetQueryString(string strName)
//        {
//            string result="";
//            while (true)
//            {
//                bool flag = HttpContext.Current.Request.QueryString[strName] != null;
//                if (true)
//                {
//                }
//                int num = 2;
//                while (true)
//                {
//                    switch (num)
//                    {
//                        case 0:
//                            result = "";
//                            num = 1;
//                            continue;
//                        case 1:
//                            return result;
//                        case 2:
//                            if (!flag)
//                            {
//                                num = 0;
//                                continue;
//                            }
//                            result = HttpContext.Current.Request.QueryString[strName];
//                            num = 3;
//                            continue;
//                        case 3:
//                            return result;
//                    }
//                    break;
//                }
//            }
//            return result;
//        }
//        public static int GetParamCount()
//        {
//            if (true)
//            {
//            }
//            return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
//        }
//        public static string GetFormString(string strName)
//        {
//            string result="";
//            while (true)
//            {
//                bool flag = HttpContext.Current.Request.Form[strName] != null;
//                int num = 0;
//                while (true)
//                {
//                    switch (num)
//                    {
//                        case 0:
//                            if (!flag)
//                            {
//                                num = 3;
//                                continue;
//                            }
//                            result = HttpContext.Current.Request.Form[strName];
//                            num = 2;
//                            continue;
//                        case 1:
//                            return result;
//                        case 2:
//                            return result;
//                        case 3:
//                            result = "";
//                            if (true)
//                            {
//                            }
//                            num = 1;
//                            continue;
//                    }
//                    break;
//                }
//            }
//            return result;
//        }
//        public static string GetUrlReferrer()
//        {
//            string result="";
//            while (true)
//            {
//                string text = null;
//                int num = 2;
//                while (true)
//                {
//                    switch (num)
//                    {
//                        case 0:
//                            return result;
//                        case 1:
//                            return result;
//                        case 2:
//                            {
//                                try
//                                {
//                                    text = HttpContext.Current.Request.UrlReferrer.ToString();
//                                    goto IL_42;
//                                }
//                                catch
//                                {
//                                    goto IL_42;
//                                }
//                                goto IL_84;
//                            IL_42:
//                                bool flag = text != null;
//                                num = 3;
//                                continue;
//                            }
//                        case 3:
//                            {
//                                bool flag=false ;
//                                if (!flag)
//                                {
//                                    num = 4;
//                                    continue;
//                                }
//                                goto IL_84;
//                            }
//                        case 4:
//                            result = "";
//                            num = 0;
//                            continue;
//                    }
//                    break;
//                IL_84:
//                    if (true)
//                    {
//                    }
//                    result = text;
//                    num = 1;
//                }
//            }
//            return result;
//        }
//        public static string GetIP()
//        {
//            int a_ = 13;
//            string result="";
//            while (true)
//            {
//                string text = string.Empty;
//                text = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
//                int num = 0;
//                while (true)
//                {
//                    bool flag=false;
//                    bool arg_289_0;
//                    bool arg_1C6_0;
//                    bool arg_130_0;
//                    switch (num)
//                    {
//                    case 0:
//                        if (text != null)
//                        {
//                            num = 21;
//                            continue;
//                        }
//                        num = 18;
//                        continue;
//                    case 1:
//                        if (text != null)
//                        {
//                            num = 11;
//                            continue;
//                        }
//                        num = 23;
//                        continue;
//                    case 2:
//                        if (!flag)
//                        {
//                            num = 9;
//                            continue;
//                        }
//                        goto IL_194;
//                    case 3:
//                        num = 19;
//                        continue;
//                    case 4:
//                        arg_289_0 = !(text == string.Empty);
//                        goto IL_289;
//                    case 5:
//                        if (!flag)
//                        {
//                            num = 17;
//                            continue;
//                        }
//                        goto IL_265;
//                    case 6:
//                        arg_1C6_0 = Utils.IsIP(text);
//                        goto IL_1C6;
//                    case 7:
//                        arg_1C6_0 = false;
//                        goto IL_1C6;
//                    case 8:
//                        goto IL_194;
//                    case 9:
//                        text = HttpContext.Current.Request.UserHostAddress;
//                        num = 8;
//                        continue;
//                    case 10:
//                        goto IL_265;
//                    case 11:
//                        num = 4;
//                        continue;
//                    case 12:
//                        arg_130_0 = !(text == string.Empty);
//                        goto IL_130;
//                    case 13:
//                        if (!flag)
//                        {
//                            num = 20;
//                            continue;
//                        }
//                        result = text;
//                        num = 22;
//                        continue;
//                    case 14:
//                        if (text != null)
//                        {
//                            num = 3;
//                            continue;
//                        }
//                        goto IL_1B5;
//                    case 15:
//                        return result;
//                    case 16:
//                        num = 6;
//                        continue;
//                    case 17:
//                        text = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
//                        num = 10;
//                        continue;
//                    case 18:
//                        arg_130_0 = false;
//                        goto IL_130;
//                    case 19:
//                        if (true)
//                        {
//                        }
//                        if (!(text == string.Empty))
//                        {
//                            num = 16;
//                            continue;
//                        }
//                        goto IL_1B5;
//                    case 20:
//                        result = "0.0.0.0";
//                        num = 15;
//                        continue;
//                    case 21:
//                        num = 12;
//                        continue;
//                    case 22:
//                        return result;
//                    case 23:
//                        arg_289_0 = false;
//                        goto IL_289;
//                    }
//                    break;
//                    IL_130:
//                    flag = arg_130_0;
//                    num = 5;
//                    continue;
//                    IL_194:
//                    num = 14;
//                    continue;
//                    IL_1B5:
//                    num = 7;
//                    continue;
//                    IL_1C6:
//                    flag = arg_1C6_0;
//                    num = 13;
//                    continue;
//                    IL_265:
//                    num = 1;
//                    continue;
//                    IL_289:
//                    flag = arg_289_0;
//                    num = 2;
//                }
//            }
//            return result;
//        }
//        public static void SaveRequestFile(string path)
//        {
//            while (true)
//            {
//                if (true)
//                {
//                }
//                bool flag = HttpContext.Current.Request.Files.Count <= 0;
//                int num = 1;
//                while (true)
//                {
//                    switch (num)
//                    {
//                        case 0:
//                            HttpContext.Current.Request.Files[0].SaveAs(path);
//                            num = 2;
//                            continue;
//                        case 1:
//                            if (!flag)
//                            {
//                                num = 0;
//                                continue;
//                            }
//                            return;
//                        case 2:
//                            return;
//                    }
//                    break;
//                }
//            }
//        }
//        public static string GetString(string strName)
//        {
//            string result="";
//            while (true)
//            {
//                bool flag = !"".Equals(RequestUtils.GetQueryString(strName));
//                if (true)
//                {
//                }
//                int num = 1;
//                while (true)
//                {
//                    switch (num)
//                    {
//                        case 0:
//                            return result;
//                        case 1:
//                            if (!flag)
//                            {
//                                num = 3;
//                                continue;
//                            }
//                            result = RequestUtils.GetQueryString(strName);
//                            num = 0;
//                            continue;
//                        case 2:
//                            return result;
//                        case 3:
//                            result = RequestUtils.GetFormString(strName);
//                            num = 2;
//                            continue;
//                    }
//                    break;
//                }
//            }
//            return result;
//        }
//        public static bool IsBrowserGet()
//        {
//            int a_ = 8;
//            bool result=false ;
//            while (true)
//            {
//                string[] array = new string[]
//                {
//                    "ie",
//                    "opera",
//                    "netscape",
//                    "mozilla"
//                };
//                string text = HttpContext.Current.Request.Browser.Type.ToLower();
//                int num = 0;
//                int num2 = 0;
//                while (true)
//                {
//                    bool flag=false;
//                    switch (num2)
//                    {
//                    case 0:
//                        goto IL_B4;
//                    case 1:
//                        return result;
//                    case 2:
//                        result = true;
//                        num2 = 1;
//                        continue;
//                    case 3:
//                        if (true)
//                        {
//                        }
//                        if (!flag)
//                        {
//                            num2 = 2;
//                            continue;
//                        }
//                        num++;
//                        num2 = 5;
//                        continue;
//                    case 4:
//                        return result;
//                    case 5:
//                        goto IL_B4;
//                    case 6:
//                        result = false;
//                        num2 = 4;
//                        continue;
//                    case 7:
//                        if (!flag)
//                        {
//                            num2 = 6;
//                            continue;
//                        }
//                        flag = (text.IndexOf(array[num]) < 0);
//                        num2 = 3;
//                        continue;
//                    }
//                    break;
//                    IL_B4:
//                    flag = (num < array.Length);
//                    num2 = 7;
//                }
//            }
//            return result;
//        }
//        public static string GetCurrentFullHost()
//        {
//            int a_ = 10;
//            string result="";
//            while (true)
//            {
//                if (true)
//                {
//                }
//                HttpRequest request = HttpContext.Current.Request;
//                bool isDefaultPort = request.Url.IsDefaultPort;
//                int num = 0;
//                while (true)
//                {
//                    switch (num)
//                    {
//                    case 0:
//                        if (!isDefaultPort)
//                        {
//                            num = 1;
//                            continue;
//                        }
//                        result = request.Url.Host;
//                        num = 3;
//                        continue;
//                    case 1:
//                        result = string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());
//                        num = 2;
//                        continue;
//                    case 2:
//                        return result;
//                    case 3:
//                        return result;
//                    }
//                    break;
//                }
//            }
//            return result;
//        }
//    }
//}
using System;
using System.Web;
namespace WC.Tool
{
    public class RequestUtils
    {
        public static string GetQueryString(string strName)
        {
            string result;
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                result = "";
            }
            else
            {
                result = HttpContext.Current.Request.QueryString[strName];
            }
            return result;
        }
        public static int GetParamCount()
        {
            return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
        }
        public static string GetFormString(string strName)
        {
            string result;
            if (HttpContext.Current.Request.Form[strName] == null)
            {
                result = "";
            }
            else
            {
                result = HttpContext.Current.Request.Form[strName];
            }
            return result;
        }
        public static string GetUrlReferrer()
        {
            string text = null;
            try
            {
                text = HttpContext.Current.Request.UrlReferrer.ToString();
            }
            catch
            {
            }
            string result;
            if (text == null)
            {
                result = "";
            }
            else
            {
                result = text;
            }
            return result;
        }
        public static string GetIP()
        {
            string text = string.Empty;
            text = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (text == null || text == string.Empty)
            {
                text = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if (text == null || text == string.Empty)
            {
                text = HttpContext.Current.Request.UserHostAddress;
            }
            string result;
            if (text == null || text == string.Empty || !Utils.IsIP(text))
            {
                result = "0.0.0.0";
            }
            else
            {
                result = text;
            }
            return result;
        }
        public static void SaveRequestFile(string path)
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                HttpContext.Current.Request.Files[0].SaveAs(path);
            }
        }
        public static string GetString(string strName)
        {
            string result;
            if ("".Equals(RequestUtils.GetQueryString(strName)))
            {
                result = RequestUtils.GetFormString(strName);
            }
            else
            {
                result = RequestUtils.GetQueryString(strName);
            }
            return result;
        }
        public static bool IsBrowserGet()
        {
            string[] array = new string[]
			{
				"ie",
				"opera",
				"netscape",
				"mozilla"
			};
            string text = HttpContext.Current.Request.Browser.Type.ToLower();
            bool result;
            for (int i = 0; i < array.Length; i++)
            {
                if (text.IndexOf(array[i]) >= 0)
                {
                    result = true;
                    return result;
                }
            }
            result = false;
            return result;
        }
        public static string GetCurrentFullHost()
        {
            HttpRequest request = HttpContext.Current.Request;
            string result;
            if (!request.Url.IsDefaultPort)
            {
                result = string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());
            }
            else
            {
                result = request.Url.Host;
            }
            return result;
        }
    }
}
