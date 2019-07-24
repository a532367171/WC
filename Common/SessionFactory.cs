using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections;
using System.Threading;
using System.Web;

/// <summary>
/// SessionFactory 的摘要说明
/// </summary>
namespace WC.Common
{
    public class SessionFactory
    {
        private static ISessionFactory sessions;
        private static Configuration cfg;
        private static readonly object padlock = new object();
        //public static ISession OpenSession(string AssemblyName)
        //{
        //    ISession result;
        //    while (true)
        //    {
        //        bool flag = SessionFactory.sessions != null;
        //        int num = 0;
        //        while (true)
        //        {
        //            switch (num)
        //            {
        //                case 0:
        //                    if (true)
        //                    {
        //                    }
        //                    if (!flag)
        //                    {
        //                        num = 1;
        //                        continue;
        //                    }
        //                    goto IL_79;
        //                case 1:
        //                    {
        //                        object obj;
        //                        Monitor.Enter(obj = SessionFactory.padlock);
        //                        num = 4;
        //                        continue;
        //                    }
        //                case 2:
        //                    goto IL_79;
        //                case 3:
        //                 //  return result;
        //                case 4:
        //                    try
        //                    {
        //                        while (true)
        //                        {
        //                            flag = (SessionFactory.sessions != null);
        //                            num = 2;
        //                            while (true)
        //                            {
        //                                switch (num)
        //                                {
        //                                    case 0:
        //                                        SessionFactory.BuildSessionFactory(AssemblyName);
        //                                        num = 3;
        //                                        continue;
        //                                    case 1:
        //                                        goto IL_F9;
        //                                    case 2:
        //                                        if (!flag)
        //                                        {
        //                                            num = 0;
        //                                            continue;
        //                                        }
        //                                        goto IL_ED;
        //                                    case 3:
        //                                        goto IL_ED;
        //                                }
        //                                break;
        //                            IL_ED:
        //                                num = 1;
        //                            }
        //                        }
        //                    IL_F9:
        //                        goto IL_4F;
        //                    }
        //                    finally
        //                    {
        //                        //object obj=null;
        //                        //Monitor.Exit(obj);
        //                    }
        //                    return result;
        //                IL_4F:
        //                    num = 2;
        //                    continue;
        //            }
        //            break;
        //        IL_79:
        //            result = SessionFactory.sessions.OpenSession();
        //            num = 3;
        //        }
        //    }
        //    return result;
        //}

        //public static ISession OpenSession(string AssemblyName)
        //{
        //    if (sessions == null)
        //    {
        //        lock (padlock)
        //        {
        //            if (sessions == null)
        //            {
        //                BuildSessionFactory(AssemblyName);
        //            }
        //        }
        //    }
        //    return sessions.OpenSession();
        //}
        public static ISession OpenSession(string AssemblyName)
        {
            if (SessionFactory.sessions == null)
            {
                object obj;
                Monitor.Enter(obj = SessionFactory.padlock);
                try
                {
                    if (SessionFactory.sessions == null)
                    {
                        SessionFactory.BuildSessionFactory(AssemblyName);
                    }
                }
                finally
                {
                    Monitor.Exit(obj);
                }
            }
            return SessionFactory.sessions.OpenSession();
        }


        private static void BuildSessionFactory(string AssemblyName)
        {
            if (true)
            {
            }
            Hashtable hashtable = HttpContext.Current.Application["hbm"] as Hashtable;
            SessionFactory.cfg = new Configuration();
            SessionFactory.cfg.SetProperty("hibernate.connection.provider", string.Concat(hashtable["hibernate.connection.provider"]));
            SessionFactory.cfg.SetProperty("hibernate.dialect", string.Concat(hashtable["hibernate.dialect"]));
            SessionFactory.cfg.SetProperty("hibernate.connection.driver_class", string.Concat(hashtable["hibernate.connection.driver_class"]));
            SessionFactory.cfg.SetProperty("hibernate.connection.connection_string", string.Concat(hashtable["hibernate.connection.connection_string"]));
            SessionFactory.cfg.SetProperty("hibernate.cache.provider_class", string.Concat(hashtable["hibernate.cache.provider_class"]));
            SessionFactory.cfg.SetProperty("hibernate.cache.use_query_cache", string.Concat(hashtable["hibernate.cache.use_query_cache"]));
            SessionFactory.cfg.AddAssembly(AssemblyName);
            SessionFactory.sessions = SessionFactory.cfg.BuildSessionFactory();
        }
    }
}