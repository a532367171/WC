//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using System.Text;
//using System.Web;
//using System.Xml;
//using WC.Model;
//using WC.Tool;
///// <summary>
///// Config 的摘要说明
///// </summary>
//namespace WC.Tool
//{
//    public class Config
//    {
//        //public static bool CheckInstall()
//        //{
//        //    int a_ = 15;
//        //    bool result=false ;
//        //    while (true)
//        //    {
//        //        XmlDocument xmlDocument = new XmlDocument();
//        //        xmlDocument.Load(HttpContext.Current.Server.MapPath(Config.GetTap()));
//        //        //string value = xmlDocument.SelectSingleNode(Module .a("드뇞鋠쳢賤触髨鿪賬菮鷰", a_)).Attributes[Module.a("诜뻞跠離胤", a_)].Value;
//        //        //bool flag = !(value != Module.a("鳞쫠ꛢ꟤퇦\ud9e8훪", a_));
//        //        string value = xmlDocument.SelectSingleNode("ins/install").Attributes["Value"].Value;
//        //        bool flag = !(value != "9C+EB1260=");
//        //        int num = 3;
//        //        while (true)
//        //        {
//        //            switch (num)
//        //            {
//        //            case 0:
//        //                return result;
//        //            case 1:
//        //                //HttpContext.Current.Application[Module.a("드곞裠跢雤鏦裨蟪臬", a_)] = Module.a("", a_);
//        //                HttpContext.Current.Application["isinstall"] = "0";
//        //                result = false;
//        //                if (true)
//        //                {
//        //                }
//        //                num = 2;
//        //                continue;
//        //            case 2:
//        //                return result;
//        //            case 3:
//        //                if (!flag)
//        //                {
//        //                    num = 1;
//        //                    continue;
//        //                }
//        //                //HttpContext.Current.Application[Module.a("드곞裠跢雤鏦裨蟪臬", a_)] = Module.a("", a_);
//        //                HttpContext.Current.Application["isinstall"] = "1";
//        //                result = true;
//        //                num = 0;
//        //                continue;
//        //            }
//        //            break;
//        //        }
//        //    }
//        //    return result;
//        //}

//        public static bool CheckInstall()
//        {
//            XmlDocument xmlDocument = new XmlDocument();
//            xmlDocument.Load(HttpContext.Current.Server.MapPath(Config.GetTap()));
//            string value = xmlDocument.SelectSingleNode("ins/install").Attributes["Value"].Value;
//            bool result;
//            if (value != "9C+EB60=")
//            {
//                HttpContext.Current.Application["isinstall"] = "0";
//                result = false;
//            }
//            else
//            {
//                HttpContext.Current.Application["isinstall"] = "1";
//                result = true;
//            }
//            return result;
//        }
      
//        private static string GetTap()
//        {
//            if (true)
//            {
//            }
//            byte[] bytes = new byte[]
//            {
//                126,
//                47,
//                105,
//                109,
//                103,
//                47,
//                115,
//                110,
//                97,
//                112,
//                47,
//                105,
//                110,
//                115,
//                46,
//                103,
//                105,
//                102
//            };
//            return Encoding.UTF8.GetString(bytes);
//        }
       
//       //public static Hashtable GetConfigByFileName(string filename)
//       // {
//       //     int a_ = 4;
//       //     string path = HttpContext.Current.Server.MapPath(filename);
//       //     Hashtable hashtable = new Hashtable();
//       //     StreamReader streamReader = new StreamReader(path, Encoding.UTF8);
//       //     try
//       //     {
//       //         while (true)
//       //         {
//       //             string text = streamReader.ReadToEnd().Trim();
//       //             string[] array = text.Split(new string[]
//       //             {
//       //                //  Module.a("鋑뇓룕볗", a_)
//       //                 "@end"
//       //             }, StringSplitOptions.None);
//       //             string[] array2 = array;
//       //             int num = 0;
//       //             int num2 = 6;
//       //             while (true)
//       //             {
//       //                 string text3="";
//       //                 string[] array3=null;
//       //                 int num3=0;
//       //                 bool flag = false;
//       //                 switch (num2)
//       //                 {
//       //                 case 0:
//       //                 {
//       //                     string key="";
//       //                     Hashtable hashtable2 = new Hashtable();
//       //                     hashtable.Add(key, hashtable2);
//       //                     num2 = 8;
//       //                     continue;
//       //                 }
//       //                 case 1:
//       //                 {
//       //                     //string text2 = Utils.GetMulti(text3, Module.a("꧑", a_), Module.a("꿑", a_))[0];
//       //                     string text2 = Utils.GetMulti(text3, "{", "}")[0];
//       //                     string key = text2.Split(new char[]
//       //                     {
//       //                         '!'
//       //                     })[0];
//       //                     string text4 = text2.Split(new char[]
//       //                     {
//       //                         '!'
//       //                     })[1];
//       //                     Hashtable hashtable2 = new Hashtable();
//       //                     array3 = text4.Split(new char[]
//       //                     {
//       //                         ','
//       //                     });
//       //                     num3 = 0;
//       //                     num2 = 15;
//       //                     continue;
//       //                 }
//       //                 case 2:
//       //                     goto IL_3BF;
//       //                 case 3:
//       //                     if (!flag)
//       //                     {
//       //                         num2 = 4;
//       //                         continue;
//       //                     }
//       //                     goto IL_297;
//       //                 case 4:
//       //                 {
//       //                     //string text2 = Utils.GetMulti(text3, Module.a("꧑", a_), Module.a("꿑", a_))[0];
//       //                     string text2 = Utils.GetMulti(text3, "{", "}")[0];
//       //                     hashtable.Add(text2.Split(new char[]
//       //                     {
//       //                         '?'
//       //                     })[0], text2.Split(new char[]
//       //                     {
//       //                         '?'
//       //                     })[1]);
//       //                     num2 = 13;
//       //                     continue;
//       //                 }
//       //                 case 5:
//       //                     goto IL_24B;
//       //                 case 6:
//       //                     goto IL_14B;
//       //                 case 7:
//       //                     streamReader.Close();
//       //                     num2 = 2;
//       //                     continue;
//       //                 case 8:
//       //                     goto IL_D8;
//       //                 case 9:
//       //                 {
//       //                     if (!flag)
//       //                     {
//       //                         num2 = 0;
//       //                         continue;
//       //                     }
//       //                     string text5 = array3[num3];
//       //                     Hashtable hashtable2=new Hashtable();
//       //                     hashtable2.Add(text5.Split(new char[]
//       //                     {
//       //                         ':'
//       //                     })[0], text5.Split(new char[]
//       //                     {
//       //                         ':'
//       //                     })[1]);
//       //                     num3++;
//       //                     num2 = 14;
//       //                     continue;
//       //                 }
//       //                 case 10:
//       //                     if (!flag)
//       //                     {
//       //                         num2 = 7;
//       //                         continue;
//       //                     }
//       //                     text3 = array2[num];
//       //                     flag = string.IsNullOrEmpty(text3.Trim());
//       //                     num2 = 11;
//       //                     continue;
//       //                 case 11:
//       //                     if (!flag)
//       //                     {
//       //                         num2 = 16;
//       //                         continue;
//       //                     }
//       //                     goto IL_24B;
//       //                 case 12:
//       //                     if (!flag)
//       //                     {
//       //                         num2 = 1;
//       //                         continue;
//       //                     }
//       //                     goto IL_D8;
//       //                 case 13:
//       //                     goto IL_297;
//       //                 case 14:
//       //                     goto IL_265;
//       //                 case 15:
//       //                     goto IL_265;
//       //                 case 16:
//       //                     //flag = !text3.Contains(Module.a("", a_));
//       //                     flag = !text3.Contains("?");
//       //                     num2 = 3;
//       //                     continue;
//       //                 case 17:
//       //                     goto IL_14B;
//       //                 }
//       //                 break;
//       //                 IL_D8:
//       //                 num2 = 5;
//       //                 continue;
//       //                 IL_14B:
//       //                 flag = (num < array2.Length);
//       //                 num2 = 10;
//       //                 continue;
//       //                 IL_24B:
//       //                 num++;
//       //                 num2 = 17;
//       //                 continue;
//       //                 IL_265:
//       //                 flag = (num3 < array3.Length);
//       //                 num2 = 9;
//       //                 continue;
//       //                 IL_297:
//       //                 //flag = !text3.Contains(Module.a("", a_));
//       //                 flag = !text3.Contains("!");
//       //                 num2 = 12;
//       //             }
//       //         }
//       //         IL_3BF:
//       //         goto IL_2F;
//       //     }
//       //     finally
//       //     {
//       //         while (true)
//       //         {
//       //             bool flag = streamReader == null;
//       //             int num4 = 1;
//       //             while (true)
//       //             {
//       //                 switch (num4)
//       //                 {
//       //                 case 0:
//       //                     ((IDisposable)streamReader).Dispose();
//       //                     num4 = 2;
//       //                     continue;
//       //                 case 1:
//       //                     if (!flag)
//       //                     {
//       //                         num4 = 0;
//       //                         continue;
//       //                     }
//       //                     goto IL_411;
//       //                 case 2:
//       //                     goto IL_40F;
//       //                 }
//       //                 break;
//       //             }
//       //         }
//       //         IL_40F:
//       //         IL_411:;
//       //     }
//       //     goto IL_412;

//       //     IL_2F:

//       //     Hashtable result = hashtable;

//       //     IL_412:

//       //     if (true)
//       //     {
//       //     }
//       //     return result;
//       // }

//        public static Hashtable GetConfigByFileName(string filename)
//        {
//            string path = HttpContext.Current.Server.MapPath(filename);
//            Hashtable hashtable = new Hashtable();
//            StreamReader streamReader = new StreamReader(path, Encoding.UTF8);
//            try
//            {

//                string text = streamReader.ReadToEnd().Trim();
//                string[] array = text.Split(new string[]
//                    {
//                        "@end"
//                    }, StringSplitOptions.None);

//                string[] array3;

//                foreach (string text3 in array)
//                {
//                    if (text3.Contains("?"))
//                    {
//                        string text2 = Utils.GetMulti(text3, "{", "}")[0];

//                        string key = text2.Split(new char[] { '?' })[0];

//                        string text4 = text2.Split(new char[] { '?' })[1];

//                        hashtable.Add(key, text4);
//                    }
//                    if (text3.Contains("!"))
//                    {
//                        string text2 = Utils.GetMulti(text3, "{", "}")[0];
//                        string key = text2.Split(new char[]{'!'})[0];
//                        string text4 = text2.Split(new char[]{'!'})[1];
//                        array3 = text4.Split(new char[]{','});
//                        Hashtable hashtable2 = new Hashtable();
//                        foreach (string text5 in array3)
//                        {
//                            hashtable2.Add(text5.Split(new char[] { ':' })[0], text5.Split(new char[] { ':' })[1]); 
//                        }
//                        hashtable.Add(key, hashtable2);
//                    }
//                }

//            }
//            finally
//            {
//                if (streamReader != null)
//                {
//                    ((IDisposable)streamReader).Dispose();
//                }
//            }
//           Hashtable result = hashtable;
           
//            return result;       
//        }

//        public static bool IsValidFile(HttpPostedFile f)
//        {
//            string text = Utils.GetFileExtension(f.FileName).ToLower();
//            if (Config.ForbiddenUploadType.Length == 7)
//            {
//                Config.ForbiddenUploadType = Config.GetForbidden();
//            }
//            bool result = true;
//            for (int i = 0; i < Config.ForbiddenUploadType.Length; i++)
//            {
//                string value = Config.ForbiddenUploadType[i].ToLower();
//                if (!string.IsNullOrEmpty(text))
//                {
//                    string text2 = Path.GetFileName(text).ToLower();
//                    if (text2.Contains(value))
//                    {
//                        result = false;
//                    }
//                }
//                else
//                {
//                    result = false;
//                }
//            }
//            return result;
//        }

//        public static string GetBeckHam()
//        {
//            if (true)
//            {
//            }
//            byte[] bytes = new byte[]
//            {
//                106,
//                57,
//                111,
//                54,
//                98,
//                49,
//                56
//            };
//            return Encoding.UTF8.GetString(bytes);
//        }

//    }
//}
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
namespace WC.Tool
{
    public class Config
    {
        private static string[] ForbiddenUploadType = new string[]
		{
			".asp",
			".aspx",
			".php",
			".cgi",
			".asa",
			".exe",
			".dll",
			".bat",
			".com",
			".xhtml",
			".shtml",
			".htx",
			".ashx",
			".cmd",
			".cer",
			".cdx",
			".ad",
			".adprototype",
			".asax",
			".ascx",
			".ashx",
			".asmx",
			".axd",
			".browser",
			".cd",
			".compiled",
			".config",
			".csproj",
			".dd",
			".exclude",
			".idc",
			".java",
			".jsl",
			".ldb",
			".ldd",
			".lddprototype",
			".ldf",
			".licx",
			".master",
			".mdb",
			".mdf",
			".msgx",
			".refresh",
			".rem",
			".resources",
			".resx",
			".rules",
			".sd",
			".sdm",
			".sdmdocument",
			".shtm",
			".sitemap",
			".skin",
			".soap",
			".stm",
			".svc",
			".vb",
			".vbproj",
			".vjsproj",
			".vsdisco",
			".webinfo",
			".xoml"
		};
        private static string[] GetForbidden()
        {
            List<string> list = new List<string>();
            Hashtable hashtable = (Hashtable)HttpContext.Current.Application["stand_config"];
            Hashtable hashtable2 = (Hashtable)hashtable["forbiddenuploadtype"];
            foreach (DictionaryEntry dictionaryEntry in hashtable2)
            {
                list.Add(string.Concat(dictionaryEntry.Value));
            }
            return list.ToArray();
        }
        public static bool IsValidFile(HttpPostedFile f)
        {
            string text = Utils.GetFileExtension(f.FileName).ToLower();
            if (Config.ForbiddenUploadType.Length == 7)
            {
                Config.ForbiddenUploadType = Config.GetForbidden();
            }
            bool result = true;
            for (int i = 0; i < Config.ForbiddenUploadType.Length; i++)
            {
                string value = Config.ForbiddenUploadType[i].ToLower();
                if (!string.IsNullOrEmpty(text))
                {
                    string text2 = Path.GetFileName(text).ToLower();
                    if (text2.Contains(value))
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }


        public static Hashtable GetConfigByFileName(string filename)
        {
            string path = HttpContext.Current.Server.MapPath(filename);
            Hashtable hashtable = new Hashtable();
            using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
            {
                string text = streamReader.ReadToEnd().Trim();
                string[] array = text.Split(new string[]
				{
					"@end"
				}, StringSplitOptions.None);
                string[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    string text2 = array2[i];
                    if (!string.IsNullOrEmpty(text2.Trim()))
                    {
                        if (text2.Contains("?"))
                        {
                            string text3 = Utils.GetMulti(text2, "{", "}")[0];
                            hashtable.Add(text3.Split(new char[]
							{
								'?'
							})[0], text3.Split(new char[]
							{
								'?'
							})[1]);
                        }
                        if (text2.Contains("!"))
                        {
                            string text3 = Utils.GetMulti(text2, "{", "}")[0];
                            string key = text3.Split(new char[]
							{
								'!'
							})[0];
                            string text4 = text3.Split(new char[]
							{
								'!'
							})[1];
                            Hashtable hashtable2 = new Hashtable();
                            string[] array3 = text4.Split(new char[]
							{
								','
							});
                            for (int j = 0; j < array3.Length; j++)
                            {
                                string text5 = array3[j];
                                hashtable2.Add(text5.Split(new char[]
								{
									':'
								})[0], text5.Split(new char[]
								{
									':'
								})[1]);
                            }
                            hashtable.Add(key, hashtable2);
                        }
                    }
                }
                streamReader.Close();
            }
            return hashtable;
        }

        public static bool CheckInstall()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(HttpContext.Current.Server.MapPath(Config.GetTap()));
            string value = xmlDocument.SelectSingleNode("ins/install").Attributes["Value"].Value;
            bool result;
            if (value != "9C+EB60=")
            {
                HttpContext.Current.Application["isinstall"] = "0";
                result = false;
            }
            else
            {
                HttpContext.Current.Application["isinstall"] = "1";
                result = true;
            }
            return result;
        }
        public static void IsInstall()
        {
            if (string.Concat(HttpContext.Current.Application["isinstall"]) == "0")
            {
                HttpContext.Current.Response.Redirect("~/Install/Default.aspx");
            }
        }
        private static string GetTap()
        {
            byte[] bytes = new byte[]
			{
				126,
				47,
				105,
				109,
				103,
				47,
				115,
				110,
				97,
				112,
				47,
				105,
				110,
				115,
				46,
				103,
				105,
				102
			};
            //~/img/snap/ins.gif
            return Encoding.UTF8.GetString(bytes);
        }
        public static string Get111()
        {
            return JScript.GetPersonInfo();
        }
        public static bool Get222(string m)
        {
            return JScript.GetCusInfo(m);
        }
        public static bool Get333()
        {
            return JScript.ShowModalDialogWindow(333);
        }
        public static string GetBeckHam()
        {
            string text = RequestUtils.GetIP() ?? "";
            if (!text.Contains("."))
            {
                text = "0.0.0.0";
            }
            string[] array = text.Split(new char[]
			{
				'.'
			});
            return array[3] + array[2] + array[1] + array[0];
        }
    }
}
