using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Xml;
using WC.DBUtility;
using WC.Model;
using WC.Tool;

/// <summary>
/// Admin_Help 的摘要说明
/// </summary>
namespace WC.BLL
{
    public class Admin_Help
    {
        //public static void UpdateApp()
        //{
        //    int a_ = 19;
        //    while (true)
        //    {
        //        int num = 2;
        //        while (true)
        //        {
        //            bool arg_1AB_0;
        //            bool flag = false;
        //            switch (num)
        //            {
        //                case 0:
        //                    arg_1AB_0 = false;
        //                    goto IL_1AB;
        //                case 1:
        //                    return;
        //                case 2:
        //                    //                                          hbm
        //                //    if (HttpContext.Current.Application[Module.a("햼\uddbe곀", a_)] != null)
        //                    if (HttpContext.Current.Application["hbm"] != null)

        //                    {
        //                        num = 4;
        //                        continue;
        //                    }
        //                    num = 0;
        //                    continue;
        //                case 3:
        //                    if (!flag)
        //                    {
        //                        num = 5;
        //                        continue;
        //                    }
        //                    return;
        //                case 4:
        //                    num = 6;
        //                    continue;
        //                case 5:
        //                    ////                                           hbm
        //                    //HttpContext.Current.Application[Module.a("햼\uddbe곀", a_)] = Admin_Help.GetHbmHash();
        //                    ////                                        stand_config                                                        ~/DK_Config/config_stand.cfgg  
        //               //     HttpContext.Current.Application[Module.a("캼쮾ꃀ귂ꇄ飆꫈꓊ꏌ꧎룐듒", a_)] = Config.GetConfigByFileName(Module.a("쎼邾藀裂髄蓆ꛈꗊꯌꛎ뛐ﳒ뛔룖럘뷚드룞뻠郢釤蛦蟨迪쏬賮韰铲鋴", a_));
        //                    ////                                        confige_fenye                                       DK_Config/config_stand.cfgg
        //                //    HttpContext.Current.Application[Module.a("\udebc킾꿀ꗂ계ꃆ雈귊꣌ꇎ꣐뛒", a_)] = Config.GetConfigByFileName(Module.a("쎼邾藀裂髄蓆ꛈꗊꯌꛎ뛐ﳒ뛔룖럘뷚드룞뻠藢胤触部軪쏬賮韰铲鋴", a_));


        //                    ////                                           hbm

        //                    HttpContext.Current.Application["hbm"] = Admin_Help.GetHbmHash();
        //                    ////                                        stand_config                                  ~/DK_Config/config_stand.cfgg  

        //                    HttpContext.Current.Application["stand_config"] = Config.GetConfigByFileName("~/DK_Config/config_stand.cfgg");
        //                    ////                                        confige_fenye                                       DK_Config/confige_fenye.cfgg

        //                    HttpContext.Current.Application["confige_fenye"] = Config.GetConfigByFileName("~/DK_Config/config_fenye.cfgg");







        //                ////                                        cominfo                                      DK_Config/config_stand.cfgg

        //                //HttpContext.Current.Application[Module.a("\udebc킾곀ꫂꯄꇆꛈ", a_)] = Admin_Help.GetComInfo();

        //                    HttpContext.Current.Application["cominfo"] = Admin_Help.GetComInfo();

        //                    //HttpContext.Current.Application[Module.a("킼킾ꗀ뛂꧄ꋆꃈ꿊鋌ꋎ뻐럒ꃔ믖볘껚꿜돞", a_)] = Admin_Help.GetModuleHash();
        //                    //HttpContext.Current.Application[Module.a("좼첾꓀뇂髄꣆ꟈꟊ꓌ꇎ듐", a_)] = Admin_Help.GetUserHash();

        //                    HttpContext.Current.Application["moduleid_moduleurl"] = Admin_Help.GetModuleHash();
        //                    HttpContext.Current.Application["user_online"] = Admin_Help.GetUserHash();


        //                    Admin_Help.UpdateDeps();
        //                    num = 1;
        //                    continue;
        //                case 6:
        //                    //                                                                                     utt
        //                    //arg_1AB_0 = !string.IsNullOrEmpty(string.Concat(HttpContext.Current.Application[Module.a("좼쮾뗀", a_)]));
        //                    arg_1AB_0 = !string.IsNullOrEmpty(string.Concat(HttpContext.Current.Application["utt"]));
        //                    goto IL_1AB;
        //            }
        //            break;
        //        IL_1AB:
        //            flag = arg_1AB_0;
        //            if (true)
        //            {
        //            }
        //            num = 3;
        //        }
        //    }
        //}


        public static void UpdateApp()
        {
            if (HttpContext.Current.Application["hbm"] == null || string.IsNullOrEmpty(string.Concat(HttpContext.Current.Application[Admin_Help.GetUtt()])))
            //if (HttpContext.Current.Application["hbm"] == null)
            //if (HttpContext.Current.Application["hbm"] == null || string.IsNullOrEmpty(string.Concat(HttpContext.Current.Application[Admin_Help.GetUtt()])))
            {
                //if (string.IsNullOrEmpty(string.Concat(HttpContext.Current.Application["utt"])))
                //{

                if (!Config.CheckInstall())
                {

                    // HttpContext.Current.Response.Redirect("~/Install/Default.aspx");
                    //System.Web.HttpContext.Current.Response.Redirect("Install/Default.aspx");
                    //HttpContext.Current.Server.Transfer("~/Install/Default.aspx");
                    //HttpContext.Current.Server.Execute("Install/Default.aspx");
                }
                else
                {

                    HttpContext.Current.Application["hbm"] = Admin_Help.GetHbmHash();

                    HttpContext.Current.Application["stand_config"] = Config.GetConfigByFileName("~/DK_Config/config_stand.cfgg");

                    HttpContext.Current.Application["config_fenye"] = Config.GetConfigByFileName("~/DK_Config/config_fenye.cfgg");

                    HttpContext.Current.Application["cominfo"] = Admin_Help.GetComInfo();

                    HttpContext.Current.Application["moduleid_moduleurl"] = Admin_Help.GetModuleHash();

                    HttpContext.Current.Application["user_online"] = Admin_Help.GetUserHash();

                    HttpContext.Current.Application["sms"] = Admin_Help.GetSMSHash();
                }
            }

        }


        public static object GetComInfo()
        {
            // JScript.ShowModalDialogWindow();
            object result = Bas_Com.Init().GetAll(null, null)[0];
            if (true)
            {
            }
            return result;
        }

        //public static Hashtable GetHbmHash()
        //{
        //    int a_ = 0;
        //    if (true)
        //    {
        //    }
        //    Hashtable hashtable = new Hashtable();
        //    XmlDocument xmlDocument = new XmlDocument();
        //    xmlDocument.Load(HttpContext.Current.Server.MapPath(Module.a("풩莫\udfaf킱薳躵隷승톻튽", a_)));
        //    string aaaa1 = Module.a("풩莫\udfaf킱薳躵隷승톻튽", a_);
        //    hashtable.Add(Module.a("슩얫청햯삱\udab3ힵ첷\udfb9銻\uddbd꾿곁꫃ꏅꯇ뻉ꗋꇍ뻏ﳑꓓꓕ럗곙뗛뫝藟郡", a_), xmlDocument.SelectSingleNode(Module.a("쎫청膯誱鮳\udeb5톷\ud8b9\ud9bb첽꺿ꏁ냃ꏅ꧉ꏋꃍ뻏럑럓ꋕ뇗뗙닛郟郡诣郥臧軩觫鳭", a_)).Attributes[Module.a("ﲩ춫슭얯ힱ", a_)].Value);

        //    string aaaa21 = Module.a("슩얫청햯삱\udab3ힵ첷\udfb9銻\uddbd꾿곁꫃ꏅꯇ뻉ꗋꇍ뻏ﳑꓓꓕ럗곙뗛뫝藟郡", a_);
        //    string aaaa22 = Module.a("쎫청膯誱鮳\udeb5톷\ud8b9\ud9bb첽꺿ꏁ냃ꏅ꧉ꏋꃍ뻏럑럓ꋕ뇗뗙닛郟郡诣郥臧軩觫鳭", a_);
        //    string aaaa23 = Module.a("ﲩ춫슭얯ힱ", a_);


        //    hashtable.Add(Module.a("슩얫청햯삱\udab3ힵ첷\udfb9銻\udabdꦿꏁꣃꏅꯇ뻉", a_), xmlDocument.SelectSingleNode(Module.a("쎫청膯誱鮳\udeb5톷\ud8b9\ud9bb첽꺿ꏁ냃ꏅ껉ꗋ꿍볏럑럓ꋕ", a_)).Attributes[Module.a("ﲩ춫슭얯ힱ", a_)].Value);
        //    string aaaa31 = Module.a("슩얫청햯삱\udab3ힵ첷\udfb9銻\udabdꦿꏁꣃꏅꯇ뻉", a_);
        //    string aaaa32 = Module.a("쎫청膯誱鮳\udeb5톷\ud8b9\ud9bb첽꺿ꏁ냃ꏅ껉ꗋ꿍볏럑럓ꋕ", a_);
        //    string aaaa33 = Module.a("ﲩ춫슭얯ힱ", a_);

        //    hashtable.Add(Module.a("슩얫청햯삱\udab3ힵ첷\udfb9銻\uddbd꾿곁꫃ꏅꯇ뻉ꗋꇍ뻏ﳑ냓ꓕ뇗곙맛곝뿟臡裣蟥鯧駩", a_), xmlDocument.SelectSingleNode(Module.a("쎫청膯誱鮳\udeb5톷\ud8b9\ud9bb첽꺿ꏁ냃ꏅ꧉ꏋꃍ뻏럑럓ꋕ뇗뗙닛蓟郡跣郥跧飩돫跭鳯鏱蟳藵", a_)).Attributes[Module.a("ﲩ춫슭얯ힱ", a_)].Value);
        //    string aaaa41 = Module.a("슩얫청햯삱\udab3ힵ첷\udfb9銻\uddbd꾿곁꫃ꏅꯇ뻉ꗋꇍ뻏ﳑ냓ꓕ뇗곙맛곝뿟臡裣蟥鯧駩", a_);
        //    string aaaa42 = Module.a("쎫청膯誱鮳\udeb5톷\ud8b9\ud9bb첽꺿ꏁ냃ꏅ꧉ꏋꃍ뻏럑럓ꋕ뇗뗙닛蓟郡跣郥跧飩돫跭鳯鏱蟳藵", a_);
        //    string aaaa43 = Module.a("ﲩ춫슭얯ힱ", a_);



        //    hashtable.Add(Module.a("슩얫청햯삱\udab3ힵ첷\udfb9銻\uddbd꾿곁꫃ꏅꯇ뻉ꗋꇍ뻏ﳑ럓맕뛗듙맛뷝铟诡诣裥럧駩飫鳭駯鳱鏳", a_), xmlDocument.SelectSingleNode(Module.a("쎫청膯誱鮳\udeb5톷\ud8b9\ud9bb첽꺿ꏁ냃ꏅ꧉ꏋꃍ뻏럑럓ꋕ뇗뗙닛菟跡諣裥跧觩飫蟭鿯鳱꯳藵賷裹闻都柿", a_)).Attributes[Module.a("ﲩ춫슭얯ힱ", a_)].Value);
        //    string aaaa51 = Module.a("슩얫청햯삱\udab3ힵ첷\udfb9銻\uddbd꾿곁꫃ꏅꯇ뻉ꗋꇍ뻏ﳑ럓맕뛗듙맛뷝铟诡诣裥럧駩飫鳭駯鳱鏳", a_);
        //    string aaaa52 = Module.a("쎫청膯誱鮳\udeb5톷\ud8b9\ud9bb첽꺿ꏁ냃ꏅ꧉ꏋꃍ뻏럑럓ꋕ뇗뗙닛菟跡諣裥跧觩飫蟭鿯鳱꯳藵賷裹闻都柿", a_);
        //    string aaaa53 = Module.a("ﲩ춫슭얯ힱ", a_);



        //    hashtable.Add(Module.a("슩얫청햯삱\udab3ힵ첷\udfb9銻\uddbdꆿꇁ곃ꏅ뫉뻋ꇍꛏ믑냓돕꫗藙뿛닝臟釡韣", a_), xmlDocument.SelectSingleNode(Module.a("쎫청膯誱鮳\udeb5톷\ud8b9\ud9bb첽꺿ꏁ냃ꏅ꧉귋귍룏럑䀘ꛕ꫗뗙ꫛ럝蓟蟡難맥诧蛩跫鷭華", a_)).Attributes[Module.a("ﲩ춫슭얯ힱ", a_)].Value);
        //    string aaaa61 = Module.a("슩얫청햯삱\udab3ힵ첷\udfb9銻\uddbdꆿꇁ곃ꏅ뫉뻋ꇍꛏ믑냓돕꫗藙뿛닝臟釡韣", a_);
        //    string aaaa62 = Module.a("쎫청膯誱鮳\udeb5톷\ud8b9\ud9bb첽꺿ꏁ냃ꏅ꧉귋귍룏럑䀘ꛕ꫗뗙ꫛ럝蓟蟡難맥诧蛩跫鷭華", a_);
        //    string aaaa63 = Module.a("ﲩ춫슭얯ힱ", a_);



        //    hashtable.Add(Module.a("슩얫청햯삱\udab3ힵ첷\udfb9銻\uddbdꆿꇁ곃ꏅ뿉뿋ꯍ迏ꏑꇓ돕꫗ꏙ菛뷝臟臡賣菥", a_), xmlDocument.SelectSingleNode(Module.a("쎫청膯誱鮳\udeb5톷\ud8b9\ud9bb첽꺿ꏁ냃ꏅ꧉귋귍룏럑䀘ꏕꯗ뿙菛꿝闟蟡難鿥럧觩跫跭飯韱", a_)).Attributes[Module.a("ﲩ춫슭얯ힱ", a_)].Value);
        //    string aaaa71 = Module.a("슩얫청햯삱\udab3ힵ첷\udfb9銻\uddbdꆿꇁ곃ꏅ뿉뿋ꯍ迏ꏑꇓ돕꫗ꏙ菛뷝臟臡賣菥", a_);
        //    string aaaa72 = Module.a("쎫청膯誱鮳\udeb5톷\ud8b9\ud9bb첽꺿ꏁ냃ꏅ꧉귋귍룏럑䀘ꏕꯗ뿙菛꿝闟蟡難鿥럧觩跫跭飯韱", a_);
        //    string aaaa73 = Module.a("ﲩ춫슭얯ힱ", a_);



        //    return hashtable;
        //}


        public static Hashtable GetHbmHash()
        {

            Hashtable hashtable = new Hashtable();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(HttpContext.Current.Server.MapPath("~/Job18.xml"));
            hashtable.Add("hibernate.connection.provider", xmlDocument.SelectSingleNode("Job18/hibernate.connection.provider").Attributes["Value"].Value);

            hashtable.Add("hibernate.dialect", xmlDocument.SelectSingleNode("Job18/hibernate.dialect").Attributes["Value"].Value);

            hashtable.Add("hibernate.connection.driver_class", xmlDocument.SelectSingleNode("Job18/hibernate.connection.driver_class").Attributes["Value"].Value);

            hashtable.Add("hibernate.connection.connection_string", xmlDocument.SelectSingleNode("Job18/hibernate.connection.connection_string").Attributes["Value"].Value);

            hashtable.Add("hibernate.cache.provider_class", xmlDocument.SelectSingleNode("Job18/hibernate.cache.provider_class").Attributes["Value"].Value);

            hashtable.Add("hibernate.cache.use_query_cache", xmlDocument.SelectSingleNode("Job18/hibernate.cache.use_query_cache").Attributes["Value"].Value);

            return hashtable;
        }

        //public static Hashtable GetModuleHash()
        //{
        //    Hashtable hashtable = new Hashtable();
        //    IList all = Sys_Module.Init().GetAll(null, null);
        //    IEnumerator enumerator = all.GetEnumerator();
        //    try
        //    {
        //        int num = 0;
        //        while (true)
        //        {
        //            bool flag = false;
        //            switch (num)
        //            {
        //                case 1:
        //                    num = 3;
        //                    continue;
        //                case 2:
        //                    {
        //                        if (!flag)
        //                        {
        //                            num = 1;
        //                            continue;
        //                        }
        //                        object current = enumerator.Current;
        //                        Sys_ModuleInfo sys_ModuleInfo = current as Sys_ModuleInfo;
        //                        hashtable.Add(sys_ModuleInfo.id.ToString(), sys_ModuleInfo.ModuleUrl);
        //                        num = 4;
        //                        continue;
        //                    }
        //                case 3:
        //                    goto IL_C9;
        //            }
        //        IL_5C:
        //            flag = enumerator.MoveNext();
        //            num = 2;
        //            continue;
        //            goto IL_5C;
        //        }
        //    IL_C9:
        //        goto IL_1F;
        //    }
        //    finally
        //    {
        //        while (true)
        //        {
        //            IDisposable disposable = enumerator as IDisposable;
        //            bool flag = disposable == null;
        //            int num2 = 0;
        //            while (true)
        //            {
        //                switch (num2)
        //                {
        //                    case 0:
        //                        if (!flag)
        //                        {
        //                            num2 = 2;
        //                            continue;
        //                        }
        //                        goto IL_126;
        //                    case 1:
        //                        goto IL_124;
        //                    case 2:
        //                        disposable.Dispose();
        //                        num2 = 1;
        //                        continue;
        //                }
        //                break;
        //            }
        //        }
        //    IL_124:
        //    IL_126: ;
        //    }
        //    Hashtable result;
        //    return result;
        //IL_1F:
        //    if (true)
        //    {
        //    }
        //    result = hashtable;
        //    return result;
        //}

        public static Hashtable GetModuleHash()
        {
            Hashtable hashtable = new Hashtable();
            IList all = Sys_Module.Init().GetAll(null, null);
            IEnumerator enumerator = all.GetEnumerator();

            try
            {
                while (enumerator.MoveNext())
                {
                    object current = enumerator.Current;
                    Sys_ModuleInfo sys_ModuleInfo = current as Sys_ModuleInfo;
                    hashtable.Add(sys_ModuleInfo.id.ToString(), sys_ModuleInfo.ModuleUrl);
                }
            }

            finally

            {

                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)

                {
                    disposable.Dispose();
                }

            }
            Hashtable result;
            result = hashtable;
            return result;
        }

        //public static Hashtable GetUserHash()
        //{
        //    Hashtable hashtable = new Hashtable();
        //    IList all = Sys_User.Init().GetAll(null, null);
        //    IEnumerator enumerator = all.GetEnumerator();
        //    try
        //    {
        //        int num = 1;
        //        while (true)
        //        {
        //            bool flag = false;
        //            switch (num)
        //            {
        //                case 2:
        //                    goto IL_BC;
        //                case 3:
        //                    {
        //                        if (!flag)
        //                        {
        //                            num = 4;
        //                            continue;
        //                        }
        //                        object current = enumerator.Current;
        //                        Sys_UserInfo sys_UserInfo = current as Sys_UserInfo;
        //                        hashtable.Add(sys_UserInfo.id.ToString(), sys_UserInfo);
        //                        num = 0;
        //                        continue;
        //                    }
        //                case 4:
        //                    num = 2;
        //                    continue;
        //            }
        //        IL_54:
        //            flag = enumerator.MoveNext();
        //            num = 3;
        //            continue;
        //            goto IL_54;
        //        }
        //    IL_BC:
        //        goto IL_1F;
        //    }
        //    finally
        //    {
        //        while (true)
        //        {
        //            IDisposable disposable = enumerator as IDisposable;
        //            bool flag = disposable == null;
        //            int num2 = 2;
        //            while (true)
        //            {
        //                switch (num2)
        //                {
        //                    case 0:
        //                        disposable.Dispose();
        //                        num2 = 1;
        //                        continue;
        //                    case 1:
        //                        goto IL_117;
        //                    case 2:
        //                        if (!flag)
        //                        {
        //                            num2 = 0;
        //                            continue;
        //                        }
        //                        goto IL_119;
        //                }
        //                break;
        //            }
        //        }
        //    IL_117:
        //    IL_119: ;
        //    }
        //    goto IL_11A;
        //IL_1F:
        //    Hashtable result = hashtable;
        //IL_11A:
        //    if (true)
        //    {
        //    }
        //    return result;
        //}

        public static List<Sys_UserInfo> GetUserHash()
        {
            Admin_Help.UpdateDeps();
            IList all = Sys_User.Init().GetAll(null, null);
            List<Sys_UserInfo> list = new List<Sys_UserInfo>();
            foreach (object current in all)
            {
                Sys_UserInfo item = current as Sys_UserInfo;
                list.Add(item);
            }
            return list;
        }

        private static void UpdateDeps()
        {
            int a_ = 7;
            if (true)
            {
            }
            //HttpContext.Current.Application[Module.a("쒰잲솴", a_)] = string.Concat(MsSqlOperate.ExecuteScalar(CommandType.Text, Admin_Help.UpdateFlows(), new SqlParameter[0]));
            HttpContext.Current.Application["uut"] = string.Concat(MsSqlOperate.ExecuteScalar(CommandType.Text, Admin_Help.UpdateFlows(), new SqlParameter[0]));

        }

        private static string UpdateFlows()
        {
            if (true)
            {
            }
            byte[] bytes = new byte[]
            {
                115,
                101,
                108,
                101,
                99,
                116,
                32,
                99,
                111,
                117,
                110,
                116,
                40,
                105,
                100,
                41,
                32,
                102,
                114,
                111,
                109,
                32,
                83,
                121,
                115,
                95,
                117,
                115,
                101,
                114
            };
            //select count(id) from Sys_user
            return Encoding.UTF8.GetString(bytes);
        }

        private static string GetUtt()
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

        public static Hashtable GetSMSHash()
        {
            Hashtable hashtable = new Hashtable();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(HttpContext.Current.Server.MapPath("~/sms.config"));
            hashtable.Add("sms_url", xmlDocument.SelectSingleNode("sms/sms_url").Attributes["Value"].Value);
            hashtable.Add("sms_user", xmlDocument.SelectSingleNode("sms/sms_user").Attributes["Value"].Value);
            hashtable.Add("sms_pwd", xmlDocument.SelectSingleNode("sms/sms_pwd").Attributes["Value"].Value);
            hashtable.Add("cont_f", xmlDocument.SelectSingleNode("sms/cont_f").Attributes["Value"].Value);
            hashtable.Add("cont_g", xmlDocument.SelectSingleNode("sms/cont_g").Attributes["Value"].Value);
            hashtable.Add("cont_n", xmlDocument.SelectSingleNode("sms/cont_n").Attributes["Value"].Value);
            hashtable.Add("cont_m", xmlDocument.SelectSingleNode("sms/cont_m").Attributes["Value"].Value);
            hashtable.Add("cont_f_e", xmlDocument.SelectSingleNode("sms/cont_f").Attributes["Enable"].Value);
            hashtable.Add("cont_g_e", xmlDocument.SelectSingleNode("sms/cont_g").Attributes["Enable"].Value);
            hashtable.Add("cont_n_e", xmlDocument.SelectSingleNode("sms/cont_n").Attributes["Enable"].Value);
            hashtable.Add("cont_m_e", xmlDocument.SelectSingleNode("sms/cont_m").Attributes["Enable"].Value);
            return hashtable;
        }
    }
}