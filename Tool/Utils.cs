using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Management;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
namespace WC.Tool
{
    public class Utils
    {
        public static string ConvertDate(object a)
        {
            return Convert.ToDateTime(a).ToString("yy-M-dd");
        }
        public static string ConvertDate_(object a)
        {
            return Convert.ToDateTime(a).ToString("yy-M-dd HH:mm");
        }
        public static string ConvertDate__(object a)
        {
            return Convert.ToDateTime(a).ToString("yyyyMMddHHmm");
        }
        public static string ConvertDate0(object a)
        {
            return Convert.ToDateTime(a).ToString("yyyy-MM-dd");
        }
        public static string ConvertDate1(object a)
        {
            return Convert.ToDateTime(a).ToString("yyyy-MM-dd HH:mm");
        }
        public static string ConvertDate2(object a)
        {
            DateTime dateTime = Convert.ToDateTime(a);
            return string.Concat(new string[]
			{
				dateTime.ToString("yyyy"),
				"年",
				dateTime.ToString("MM"),
				"月",
				dateTime.ToString("dd"),
				"日 ",
				dateTime.ToString("HH:mm")
			});
        }
        public static string ConvertDate3(object a)
        {
            DateTime dateTime = Convert.ToDateTime(a);
            return string.Concat(new string[]
			{
				dateTime.ToString("yyyy"),
				"年",
				dateTime.ToString("MM"),
				"月",
				dateTime.ToString("dd"),
				"日 ",
				dateTime.ToString("HH:mm"),
				" ",
				Utils.GetDayOfWeek(dateTime)
			});
        }
        public static string ConvertDate4(object a)
        {
            DateTime dateTime = Convert.ToDateTime(a);
            return string.Concat(new string[]
			{
				dateTime.ToString("yyyy"),
				"年",
				dateTime.ToString("MM"),
				"月",
				dateTime.ToString("dd"),
				"日 ",
				Utils.GetDayOfWeek(dateTime)
			});
        }
        public static string ConvertDate5(object a)
        {
            DateTime dateTime = Convert.ToDateTime(a);
            return string.Concat(new string[]
			{
				dateTime.ToString("yyyy"),
				"-",
				dateTime.ToString("MM"),
				"-",
				dateTime.ToString("dd"),
				"  ",
				dateTime.ToString("HH:mm"),
				" ",
				Utils.GetDayOfWeek(dateTime)
			});
        }
        public static int GetDayOf2Date(DateTime d1, DateTime d2)
        {
            TimeSpan timeSpan = new TimeSpan(d2.Ticks - d1.Ticks);
            return timeSpan.Days;
        }
        public static string GetDayOfWeek(object a)
        {
            string text = Convert.ToDateTime(a).DayOfWeek.ToString();
            string result = "";
            if (text.ToLower() == "monday")
            {
                result = "周一";
            }
            if (text.ToLower() == "tuesday")
            {
                result = "周二";
            }
            if (text.ToLower() == "wednesday")
            {
                result = "周三";
            }
            if (text.ToLower() == "thursday")
            {
                result = "周四";
            }
            if (text.ToLower() == "friday")
            {
                result = "周五";
            }
            if (text.ToLower() == "saturday")
            {
                result = "周六";
            }
            if (text.ToLower() == "sunday")
            {
                result = "周日";
            }
            return result;
        }
        public static string GetAgeByDatetime(object a)
        {
            DateTime dateTime = Convert.ToDateTime(a);
            int year = DateTime.Now.Year;
            int year2 = dateTime.Year;
            int month = DateTime.Now.Month;
            int month2 = dateTime.Month;
            int day = DateTime.Now.Day;
            int day2 = dateTime.Day;
            int num = (year - 1900) * 365 + month * 30 + day;
            int num2 = (year2 - 1900) * 365 + month2 * 30 + day2;
            int num3 = num - num2;
            int num4 = (int)Math.Floor(Convert.ToDouble(num3 / 365));
            int num5 = num3 - num4 * 365;
            int num6 = num5 / 30;
            int num7 = num5 - num6 * 30;
            return string.Concat(new object[]
			{
				num4.ToString(),
				"岁,零",
				num6.ToString(),
				"个月,零",
				num7,
				"天"
			});
        }
        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }
        public static int GetRandom(int send)
        {
            return new Random().Next(send);
        }
        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            int result;
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (caseInsensetive)
                {
                    if (strSearch.ToLower() == stringArray[i].ToLower())
                    {
                        result = i;
                        return result;
                    }
                }
                else
                {
                    if (strSearch == stringArray[i])
                    {
                        result = i;
                        return result;
                    }
                }
            }
            result = -1;
            return result;
        }
        public static bool IsNumber(string strNumber)
        {
            return new Regex("^([0-9])[0-9]*(\\.\\w*)?$").IsMatch(strNumber);
        }
        public static bool IsNumberArray(string[] strNumber)
        {
            bool result;
            if (strNumber == null)
            {
                result = false;
            }
            else
            {
                if (strNumber.Length < 1)
                {
                    result = false;
                }
                else
                {
                    for (int i = 0; i < strNumber.Length; i++)
                    {
                        string strNumber2 = strNumber[i];
                        if (!Utils.IsNumber(strNumber2))
                        {
                            result = false;
                            return result;
                        }
                    }
                    result = true;
                }
            }
            return result;
        }
        public static bool IsTime(string timeval)
        {
            return Regex.IsMatch(timeval, "^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$");
        }
        public static bool IsDate(string dateStr)
        {
            string pattern = "^(\\d{4})(\\/|-)(\\d{1,2})(\\/|-)(\\d{1,2})$";
            bool result;
            if (!Regex.IsMatch(dateStr, pattern))
            {
                result = false;
            }
            else
            {
                string[] array = dateStr.Split(new char[]
				{
					'/',
					'-'
				});
                if (array == null || array.Length < 3)
                {
                    result = false;
                }
                else
                {
                    int num = int.Parse(array[0]);
                    int num2 = int.Parse(array[1]);
                    int num3 = int.Parse(array[2]);
                    if (num2 < 1 || num2 > 12)
                    {
                        result = false;
                    }
                    else
                    {
                        if (num3 < 1 || num3 > 31)
                        {
                            result = false;
                        }
                        else
                        {
                            bool arg_B9_0;
                            if (num2 != 4 && num2 != 6 && num2 != 9)
                            {
                                if (num2 != 11)
                                {
                                    arg_B9_0 = true;
                                    goto IL_B9;
                                }
                            }
                            arg_B9_0 = (num3 != 31);
                        IL_B9:
                            if (!arg_B9_0)
                            {
                                result = false;
                            }
                            else
                            {
                                if (num2 == 2)
                                {
                                    bool flag = num % 4 == 0 && (num % 100 != 0 || num % 400 == 0);
                                    if (num3 > 29 || (num3 == 29 && !flag))
                                    {
                                        result = false;
                                        return result;
                                    }
                                }
                                result = true;
                            }
                        }
                    }
                }
            }
            return result;
        }
        public static string GetMapPath(string strPath)
        {
            string result;
            if (HttpContext.Current != null)
            {
                result = HttpContext.Current.Server.MapPath(strPath);
            }
            else
            {
                result = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
            return result;
        }
        public static bool FileExists(string filename)
        {
            return File.Exists(filename);
        }
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie httpCookie = HttpContext.Current.Request.Cookies[strName];
            if (httpCookie == null)
            {
                httpCookie = new HttpCookie(strName);
            }
            httpCookie.Value = strValue;
            httpCookie.Expires = DateTime.Now.AddMinutes((double)expires);
            HttpContext.Current.Response.AppendCookie(httpCookie);
        }
        public static bool IsImgFilename(string filename)
        {
            filename = filename.Trim();
            bool result;
            if (filename.EndsWith(".") || filename.IndexOf(".") == -1)
            {
                result = false;
            }
            else
            {
                string a = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
                result = (a == "jpg" || a == "jpeg" || a == "png" || a == "bmp" || a == "gif");
            }
            return result;
        }
        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, "^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)$");
        }
        public static void ResponseFile(string filepath, string filename, string filetype)
        {
            Stream stream = null;
            byte[] buffer = new byte[10000];
            try
            {
                stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
                long num = stream.Length;
                HttpContext.Current.Response.ContentType = filetype;
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + Utils.UrlEncode(filename.Trim()).Replace("+", " "));
                while (num > 0L)
                {
                    if (HttpContext.Current.Response.IsClientConnected)
                    {
                        int num2 = stream.Read(buffer, 0, 10000);
                        HttpContext.Current.Response.OutputStream.Write(buffer, 0, num2);
                        HttpContext.Current.Response.Flush();
                        buffer = new byte[10000];
                        num -= (long)num2;
                    }
                    else
                    {
                        num = -1L;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("Error : " + ex.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            HttpContext.Current.Response.End();
        }
        public static XmlElement CreateXmlNode(XmlDocument xDocument, string elementName, string textName)
        {
            XmlElement result;
            try
            {
                XmlElement xmlElement = xDocument.CreateElement(elementName);
                XmlText newChild = xDocument.CreateTextNode(textName);
                xmlElement.AppendChild(newChild);
                result = xmlElement;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public static XmlElement CreateXmlNodeCDATA(XmlDocument xDocument, string elementName, string cdataValue)
        {
            XmlElement result;
            try
            {
                XmlElement xmlElement = xDocument.CreateElement(elementName);
                XmlCDataSection newChild = xDocument.CreateCDataSection(cdataValue);
                xmlElement.AppendChild(newChild);
                result = xmlElement;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public static string HtmlEnCoding(string input)
        {
            return input;
        }
        public void MD5Conputer()
        {
            throw new NotImplementedException();
        }
        public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
        {
            string text = p_SrcString;
            if (p_Length >= 0)
            {
                byte[] bytes = Encoding.Default.GetBytes(p_SrcString);
                if (bytes.Length > p_Length)
                {
                    int num = p_Length;
                    int[] array = new int[p_Length];
                    int num2 = 0;
                    for (int i = 0; i < p_Length; i++)
                    {
                        if (bytes[i] > 127)
                        {
                            num2++;
                            if (num2 == 3)
                            {
                                num2 = 1;
                            }
                        }
                        else
                        {
                            num2 = 0;
                        }
                        array[i] = num2;
                    }
                    if (bytes[p_Length - 1] > 127 && array[p_Length - 1] == 1)
                    {
                        num = p_Length + 1;
                    }
                    byte[] array2 = new byte[num];
                    Array.Copy(bytes, array2, num);
                    text = Encoding.Default.GetString(array2);
                    text += p_TailString;
                }
            }
            return text;
        }
        public static bool IsValidEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, "^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$");
        }
        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, "[-|;|,|\\/|\\(|\\)|\\[|\\]|\\}|\\{|%|@|\\*|!|\\']");
        }
        public static string[] SplitString(string strContent, string strSplit)
        {
            string[] result;
            if (strContent.IndexOf(strSplit) < 0)
            {
                string[] array = new string[]
				{
					strContent
				};
                result = array;
            }
            else
            {
                result = Regex.Split(strContent, strSplit.Replace(".", "\\."), RegexOptions.IgnoreCase);
            }
            return result;
        }
        public static string HtmlEncode(string str)
        {
            return HttpUtility.HtmlEncode(str);
        }
        public static string HtmlDecode(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }
        public static string UrlEncode(string str)
        {
            return HttpUtility.UrlEncode(str);
        }
        public static string UrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }
        public static string FormatBytesStr(int bytes)
        {
            string result;
            if (bytes > 1073741824)
            {
                result = ((double)(bytes / 1073741824)).ToString("0") + "G";
            }
            else
            {
                if (bytes > 1048576)
                {
                    result = ((double)(bytes / 1048576)).ToString("0") + "M";
                }
                else
                {
                    if (bytes > 1024)
                    {
                        result = ((double)(bytes / 1024)).ToString("0") + "K";
                    }
                    else
                    {
                        result = bytes.ToString() + "Bytes";
                    }
                }
            }
            return result;
        }
        public static string GetStaticPageUrl(string oldPage, string firstPram, string scendPram)
        {
            if (oldPage.IndexOf('.') < 0)
            {
                throw new Exception("输入的页面文件名称不符合规范");
            }
            string[] array = oldPage.Split(new char[]
			{
				'.'
			});
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(array[0]);
            stringBuilder.Append("_" + firstPram);
            stringBuilder.Append("_" + scendPram);
            stringBuilder.Append("." + array[1]);
            return stringBuilder.ToString();
        }
        public static string GetStaticPageUrl(string oldPage, string firstPram)
        {
            if (oldPage.IndexOf('.') < 0)
            {
                throw new Exception("输入的页面文件名称不符合规范");
            }
            string[] array = oldPage.Split(new char[]
			{
				'.'
			});
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(array[0]);
            stringBuilder.Append("_" + firstPram);
            stringBuilder.Append("." + array[1]);
            return stringBuilder.ToString();
        }
        public static string FormatUrl(string oldPage, string firstPram, string scendPram)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (!string.IsNullOrEmpty(oldPage))
            {
                stringBuilder.Append(oldPage);
            }
            if (!string.IsNullOrEmpty(firstPram))
            {
                stringBuilder.Append("?" + firstPram);
            }
            if (!string.IsNullOrEmpty(scendPram))
            {
                stringBuilder.Append("&" + scendPram);
            }
            return stringBuilder.ToString();
        }
        public static string CreateRandomStr(int len)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < len; i++)
            {
                int num = random.Next();
                if (num % 2 == 0)
                {
                    stringBuilder.Append((char)(48 + (ushort)(num % 10)));
                }
                else
                {
                    stringBuilder.Append((char)(65 + (ushort)(num % 26)));
                }
            }
            return stringBuilder.ToString();
        }
        public static string FormatUrl(string oldPage, string firstPram)
        {
            return Utils.FormatUrl(oldPage, firstPram, null);
        }
        public static T SetParm<T>(SqlDataReader dr)
        {
            T t = (T)((object)typeof(T).Assembly.CreateInstance(typeof(T).FullName));
            PropertyInfo[] properties = typeof(T).GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo propertyInfo = properties[i];
                if (dr[propertyInfo.Name] is DBNull)
                {
                    propertyInfo.SetValue(t, null, null);
                }
                else
                {
                    propertyInfo.SetValue(t, dr[propertyInfo.Name], null);
                }
            }
            return t;
        }
        public static IList<T> GetList<T>(SqlDataReader dr)
        {
            IList<T> list = new List<T>();
            while (dr.Read())
            {
                list.Add(Utils.SetParm<T>(dr));
            }
            return list;
        }
        public static T SetParm<T>(DataRow dr)
        {
            T t = (T)((object)typeof(T).Assembly.CreateInstance(typeof(T).FullName));
            List<string> dataRowColumnName = Utils.GetDataRowColumnName(dr);
            PropertyInfo[] properties = typeof(T).GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo propertyInfo = properties[i];
                if (dataRowColumnName.Contains(propertyInfo.Name.ToLower()))
                {
                    if (dr[propertyInfo.Name] is DBNull)
                    {
                        propertyInfo.SetValue(t, null, null);
                    }
                    else
                    {
                        propertyInfo.SetValue(t, dr[propertyInfo.Name], null);
                    }
                }
            }
            return t;
        }
        private static List<string> GetDataRowColumnName(DataRow dr)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                list.Add(dr.Table.Columns[i].ColumnName.ToLower());
            }
            return list;
        }
        public static IList<T> GetList<T>(DataSet ds)
        {
            IList<T> list = new List<T>();
            foreach (DataRow parm in ds.Tables[0].Rows)
            {
                list.Add(Utils.SetParm<T>(parm));
            }
            return list;
        }
        public static string ClearHtml(string html)
        {
            Regex regex = new Regex("<script[\\s\\S]+</script *>", RegexOptions.IgnoreCase);
            Regex regex2 = new Regex(" href *= *[\\s\\S]*script *:", RegexOptions.IgnoreCase);
            Regex regex3 = new Regex(" on[\\s\\S]*=", RegexOptions.IgnoreCase);
            Regex regex4 = new Regex("<iframe[\\s\\S]+</iframe *>", RegexOptions.IgnoreCase);
            Regex regex5 = new Regex("<frameset[\\s\\S]+</frameset *>", RegexOptions.IgnoreCase);
            Regex regex6 = new Regex(" src *= *[\\s\\S]*script *:", RegexOptions.IgnoreCase);
            html = regex.Replace(html, "");
            html = regex2.Replace(html, "");
            html = regex3.Replace(html, " _disibledevent=");
            html = regex4.Replace(html, "");
            html = regex5.Replace(html, "");
            html = regex6.Replace(html, "");
            return html;
        }
        public static bool CheckSql(string Str)
        {
            bool result;
            if (Str != null)
            {
                string text = "dbcc |alter |drop |exec |insert |select |delete |update |master |truncate |declare |char |where |--|cmdshell|sysobjects|db_|backup| from";
                bool flag = true;
                try
                {
                    if (Str.Trim() != "")
                    {
                        Str = Str.Trim().ToLower();
                        string[] array = text.Split(new char[]
						{
							'|'
						});
                        string[] array2 = array;
                        for (int i = 0; i < array2.Length; i++)
                        {
                            string value = array2[i];
                            if (Str.IndexOf(value) >= 0)
                            {
                                flag = false;
                            }
                        }
                    }
                }
                catch
                {
                    flag = false;
                }
                result = flag;
            }
            else
            {
                result = true;
            }
            return result;
        }

        //public static string[] GetMulti(string str, string head, string tail)
        //{
        //    List<string> list = new List<string>();
        //    if (str.Contains(head) && str.Contains(tail))
        //    {
        //        string[] array = str.Split(new string[]
        //        {
        //            head
        //        }, StringSplitOptions.None);
        //        for (int i = 1; i < array.Length; i++)
        //        {
        //            if (array[i].Contains(tail))
        //            {
        //                int length = array[i].IndexOf(tail);
        //                list.Add(array[i].Substring(0, length).ToLower());
        //            }
        //        }
        //    }
        //    return list.ToArray();
        //}

        public static string[] GetMulti(string str, string head, string tail)
        {
            string[] result = { "", "", "" };
            try
            {
                List<string> list = new List<string>();


                string[] array = { "", "" };

                if (str.Contains(head))
                {
                    array = str.Split(new string[]
                                           {
                                         head
                                            }, StringSplitOptions.None);
                }


                if (str.Contains(tail))
                {
                    int length = array[1].IndexOf(tail);
                    list.Add(array[1].Substring(0, length).ToLower());

                }

                result = list.ToArray();
            }


            finally
            {



            }
            return result;
        }



        public static string GetSubString2(string obj, int length, string token)
        {
            return (obj.Length > length) ? (obj.Substring(0, length) + token) : obj;
        }
        public static string GetStringByInt(int b)
        {
            return (b == 0) ? "否" : "是";
        }
        public static string Win32_GetMainBoardBiosSerialNumber()
        {
            ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection instances = managementClass.GetInstances();
            string result = "";
            using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ManagementObject managementObject = (ManagementObject)enumerator.Current;
                    if ((bool)managementObject["IPEnabled"])
                    {
                        result = managementObject["MacAddress"].ToString();
                    }
                }
            }
            return result;
        }
        public static string Win32_GetMainBoardBiosSerialNumber1()
        {
            ManagementObject managementObject = new ManagementObject("win32_logicaldisk.deviceid=\"d:\"");
            managementObject.Get();
            return managementObject.GetPropertyValue("VolumeSerialNumber").ToString();
        }
        public static string Win32_GetCpuSerialNumber()
        {
            string result = "";
            ManagementClass managementClass = new ManagementClass("Win32_Processor");
            ManagementObjectCollection instances = managementClass.GetInstances();
            using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    ManagementObject managementObject = (ManagementObject)enumerator.Current;
                    result = managementObject.Properties["ProcessorId"].Value.ToString();
                }
            }
            return result;
        }
        public static object Serialize(object a)
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, a);
            memoryStream.Close();
            byte[] buffer = memoryStream.ToArray();
            memoryStream.Dispose();
            MemoryStream serializationStream = new MemoryStream(buffer);
            return binaryFormatter.Deserialize(serializationStream);
        }
        public static string RemoveHtml(string html)
        {
            string result;
            if (string.IsNullOrEmpty(html))
            {
                result = string.Empty;
            }
            else
            {
                result = Regex.Replace(html, "<.+?/?>", "", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            }
            return result;
        }
        public static bool IsWordAndNum(string _value)
        {
            Regex regex = new Regex("[a-zA-Z0-9]?");
            return regex.Match(_value).Success;
        }
        public static void SetPageNoCache()
        {
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1.0);
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.CacheControl = "no-cache";
            HttpContext.Current.Response.AddHeader("Pragma", "No-Cache");
        }
        public static bool IsOfficeFile(string filename)
        {
            bool result = false;
            if (filename.Contains("."))
            {
                string[] array = filename.Split(new char[]
				{
					'.'
				});
                string text = array[array.Length - 1].ToLower();
                if (text.Contains("doc") || text.Contains("xls") || text.Contains("wps"))
                {
                    result = true;
                }
            }
            return result;
        }
        public static string GetRequestHostUrl()
        {
            string text = "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"].ToString() + HttpContext.Current.Request.ServerVariables["PATH_INFO"].ToString();
            int length = text.LastIndexOf("/");
            return text.Substring(0, length) + "/";
        }
        public static long DirSize(DirectoryInfo d)
        {
            long num = 0L;
            FileInfo[] files = d.GetFiles();
            FileInfo[] array = files;
            for (int i = 0; i < array.Length; i++)
            {
                FileInfo fileInfo = array[i];
                num += fileInfo.Length;
            }
            DirectoryInfo[] directories = d.GetDirectories();
            DirectoryInfo[] array2 = directories;
            for (int i = 0; i < array2.Length; i++)
            {
                DirectoryInfo d2 = array2[i];
                num += Utils.DirSize(d2);
            }
            return num;
        }
        public static bool IsRandomHit(int s)
        {
            int num = new Random().Next(1, 101);
            return num % s == 0;
        }
        public static int GetSplitNum(string s, string r)
        {
            int result = 0;
            if (r.Contains(s))
            {
                result = r.Split(new string[]
				{
					s
				}, StringSplitOptions.None).Length - 1;
            }
            return result;
        }
        public static string GetFileExtension(string filename)
        {
            string result = "";
            if (filename.Contains("."))
            {
                string[] array = filename.Split(new char[]
				{
					'.'
				});
                result = "." + array[array.Length - 1].ToLower();
            }
            return result;
        }
        public static DataSet ConvertListToDataSet<T>(IList<T> list)
        {
            DataSet result;
            if (list == null || list.Count <= 0)
            {
                result = null;
            }
            else
            {
                DataSet dataSet = new DataSet();
                DataTable dataTable = new DataTable(typeof(T).Name);
                PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (T current in list)
                {
                    if (current != null)
                    {
                        DataRow dataRow = dataTable.NewRow();
                        int i = 0;
                        int num = properties.Length;
                        while (i < num)
                        {
                            PropertyInfo propertyInfo = properties[i];
                            string name = propertyInfo.Name;
                            if (dataTable.Columns[name] == null)
                            {
                                DataColumn column = new DataColumn(name, propertyInfo.PropertyType);
                                dataTable.Columns.Add(column);
                            }
                            dataRow[name] = propertyInfo.GetValue(current, null);
                            i++;
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }
                dataSet.Tables.Add(dataTable);
                result = dataSet;
            }
            return result;
        }
    }
}
//flag2 = false;
//        //                        try
//        //                        {
//        //                            while (true)
//        //                            {
//        //                                flag = !(Str.Trim() != "");
//        //                                num = 1;
//        //                                while (true)
//        //                                {
//        //                                    string[] array2 = { "", "", "", "", "" };
//        //                                    int num2 = 0;
//        //                                    switch (num)
//        //                                    {
//        //                                        case 0:
//        //                                            {
//        //                                                Str = Str.Trim().ToLower();
//        //                                                string text = "";
//        //                                                string[] array = text.Split(new char[]
//        //                                {
//        //                                    '|'
//        //                                });
//        //                                                array2 = array;
//        //                                                num2 = 0;
//        //                                                num = 2;
//        //                                                continue;
//        //                                            }
//        //                                        case 1:
//        //                                            if (!flag)
//        //                                            {
//        //                                                num = 0;
//        //                                                continue;
//        //                                            }
//        //                                            goto IL_1F0;
//        //                                        case 2:
//        //                                            goto IL_10B;
//        //                                        case 3:
//        //                                            goto IL_1FF;
//        //                                        case 4:
//        //                                            {
//        //                                                if (!flag)
//        //                                                {
//        //                                                    num = 9;
//        //                                                    continue;
//        //                                                }
//        //                                                string value = array2[num2];
//        //                                                flag = (Str.IndexOf(value) < 0);
//        //                                                num = 8;
//        //                                                continue;
//        //                                            }
//        //                                        case 5:
//        //                                            goto IL_19E;
//        //                                        case 6:
//        //                                            goto IL_1F0;
//        //                                        case 7:
//        //                                            goto IL_10B;
//        //                                        case 8:
//        //                                            if (!flag)
//        //                                            {
//        //                                                num = 10;
//        //                                                continue;
//        //                                            }
//        //                                            goto IL_19E;
//        //                                        case 9:
//        //                                            num = 6;
//        //                                            continue;
//        //                                        case 10:
//        //                                            flag2 = false;
//        //                                            num = 5;
//        //                                            continue;
//        //                                    }
//        //                                    break;
//        //                                IL_10B:
//        //                                    flag = (num2 < array2.Length);
//        //                                    num = 4;
//        //                                    continue;
//        //                                IL_19E:
//        //                                    num2++;
//        //                                    num = 7;
//        //                                    continue;
//        //                                IL_1F0:
//        //                                    num = 3;
//        //                                }
//        //                            }
//        //                        IL_1FF:
//        //                            goto IL_4E;
//        //                        }
//        //                        catch
//        //                        {
//        //                            flag2 = false;
//        //                            goto IL_4E;
//        //                        }
//        //                        return result;
//        //                    IL_4E:
//        //                        result = flag2;
//        //                        num = 4;
//        //                        continue;
//        //                    }
//        //                case 2:
//        //                    if (!flag)
//        //                    {
//        //                        num = 3;
//        //                        continue;
//        //                    }
//        //                    result = true;
//        //                    num = 0;
//        //                    continue;
//        //                case 3:
//        //                    {
//        //                        if (true)
//        //                        {
//        //                        }
//        //                        string text = "dbcc |alter |drop | *|exec |insert |select |delete |update |count |master |truncate |declare | char| mid| chr|set |where | xp_cmdshell|cmdshell";
//        //                        bool flag2 = true;
//        //                        num = 1;
//        //                        continue;
//        //                    }
//        //                case 4:
//        //                    return result;
//        //            }
//        //            break;
//        //        }
//        //    }
//        //    return result;
//        //}

//        //public static bool CheckSql(string Str)
//        //{ 
//        //    bool result = false;
//        //    if (Str == null || Str == "")
//        //        return result;

//        //    string text = "dbcc |alter |drop | *|exec |insert |select |delete |update |count |master |truncate |declare | char| mid| chr|set |where | xp_cmdshell|cmdshell";
//        //  string[] array = text.Split(new char[]{'|'});
    
//        //    bool flag = false ;
//        //    string value = array[num2];
//        //   flag = (Str.IndexOf(value) < 0);   
//        //}



//        public static bool CheckSql(String str)  
//{

//    if (str == null)
//    {
//        return true ;
//    }
//                   bool result = false;
//                   bool flag = true;
//    string text = "dbcc |alter |drop | *|exec |insert |select |delete |update |count |master |truncate |declare | char| mid| chr|set |where | xp_cmdshell|cmdshell";
//           string[] array = text.Split(new char[]{'|'});
//            for (int i=0 ; i < array.Length ; i++ )  
//               {   
                
//                   if (str.IndexOf(array[i])>=0)  
//                 {

//                     flag = false;  
//                  }  
//               }

//            result = flag;
//         return result;
// }  
  


//        public static string[] GetMulti(string str, string head, string tail)
//        {
//            string[] result = { "", "", "" };       
//         try 
//           {
//               List<string> list = new List<string>();
 
      
//                    string[] array = { "", ""};
        
//                            if (str.Contains(head))
//                            {
//                                array = str.Split(new string[]
//                                   {
//                                 head
//                                    }, StringSplitOptions.None);
//                            }


//                            if (str.Contains(tail))
//                            {
//                                int length = array[1].IndexOf(tail);
//                                list.Add(array[1].Substring(0, length).ToLower());
                            
//                            }
                 
//                    result = list.ToArray();               
//                    }
            

//            finally 

//           {

                

//           }
//             return result;
//        }



//        public static string GetMulti1(string str, string head, string tail)
//        {

//            Regex rg = new Regex("(?<=(" + head + "))[.\\s\\S]*?(?=(" + tail + "))", RegexOptions.Multiline | RegexOptions.Singleline);
//            return rg.Match(str).Value;
//        }


//        public static string GetSubString2(string obj, int length, string token)
//        {
//            string result="";
//            while (true)
//            {
//                int num = 4;
//                while (true)
//                {
//                    string arg_72_0;
//                    switch (num)
//                    {
//                        case 0:
//                            arg_72_0 = obj;
//                            goto IL_72;
//                        case 1:
//                            if (true)
//                            {
//                            }
//                            num = 0;
//                            continue;
//                        case 2:
//                            return result;
//                        case 3:
//                            arg_72_0 = obj.Substring(0, length) + token;
//                            goto IL_72;
//                        case 4:
//                            if (obj.Length <= length)
//                            {
//                                num = 1;
//                                continue;
//                            }
//                            num = 3;
//                            continue;
//                    }
//                    break;
//                IL_72:
//                    result = arg_72_0;
//                    num = 2;
//                }
//            }
//            return result;
//        }
//        public static string GetStringByInt(int b)
//        {
//            int a_ = 36+ 3;
//            return (b == 0) ? Module.a("", a_) : Module.a("ﺶ", a_);
//        }

///*
//      public static string Win32_GetMainBoardBiosSerialNumber()
//        {
//            int a_ = 36+ 13;
//            if (true)
//            {
//            }
//            ManagementClass managementClass = new ManagementClass(Module.a("賚드뇞틠퇢뫤ꧦ賨鿪髬胮菰飲듴鏶飸诺觼髾猀䀂樄椆漈戊樌税挐爒愔縖瘘甚", a_));
//            ManagementObjectCollection instances = managementClass.GetInstances();
//            string text = "";
//            ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator();
//            try
//            {
//                int num = 7;
//                while (true)
//                {
//                    bool flag;
//                    switch (num)
//                    {
//                    case 0:
//                    {
//                        if (!flag)
//                        {
//                            num = 6;
//                            continue;
//                        }
//                        ManagementObject managementObject = (ManagementObject)enumerator.Current;
//                        flag = !(bool)managementObject[Module.a("鋚跜髞迠苢蟤详賨迪", a_)];
//                        num = 2;
//                        continue;
//                    }
//                    case 2:
//                        if (!flag)
//                        {
//                            num = 5;
//                            continue;
//                        }
//                        goto IL_F5;
//                    case 3:
//                        goto IL_F5;
//                    case 4:
//                        goto IL_141;
//                    case 5:
//                    {
//                        ManagementObject managementObject;
//                        text = managementObject[Module.a("雚볜볞ꃠ蟢臤闦賨飪黬", a_)].ToString();
//                        num = 3;
//                        continue;
//                    }
//                    case 6:
//                        num = 4;
//                        continue;
//                    }
//                    IL_7F:
//                    flag = enumerator.MoveNext();
//                    num = 0;
//                    continue;
//                    goto IL_7F;
//                    IL_F5:
//                    num = 1;
//                }
//                IL_141:
//                goto IL_3E;
//            }
//            finally
//            {
//                while (true)
//                {
//                    bool flag = enumerator == null;
//                    int num2 = 2;
//                    while (true)
//                    {
//                        switch (num2)
//                        {
//                        case 0:
//                  