using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using LINQ_to_SQL;
using WC.Model;
using WC.DBUtility;

    public class limaganDataDAL
    {
        //public List<Calendar> Find_Calendar_List_ByUID_and_TIME(string[] uid, string[] stime, string[] etime, int startIndex, int pageNum)
        //{
        //    string text = " ";
        //    for (int i = 0; i < uid.Length; i++)
        //    {
        //        if (i != uid.Length - 1)
        //        {
        //            string text2 = text;
        //            text = string.Concat(new string[]
        //            {
        //                text2,
        //                " ( logicdelete= 0 and UID = '",
        //                uid[i].ToString(),
        //                "' and STime > '",
        //                stime[i].ToString(),
        //                "' and STime <= '",
        //                etime[i].ToString(),
        //                "') or "
        //            });
        //        }
        //        else
        //        {
        //            string text2 = text;
        //            text = string.Concat(new string[]
        //            {
        //                text2,
        //                " ( logicdelete= 0 and UID = '",
        //                uid[i].ToString(),
        //                "' and STime > '",
        //                stime[i].ToString(),
        //                "' and STime <= '",
        //                etime[i].ToString(),
        //                "') "
        //            });
        //        }
        //    }
        //    string text3 = "select * from Calendar where {0}";
        //    text3 = string.Format(text3, text);
        //    List<Calendar> result;
        //    using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, text3, new SqlParameter[0]))
        //    {
        //        List<Calendar> list = new List<Calendar>();
        //        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
        //        {
        //            list.Add(this.SetPram(dataSet.Tables[0].Rows[i]));
        //        }
        //        result = list;
        //    }
        //    return result;
        //}
        //public List<Calendar> Find_Calendar_List_ByUID_and_TIME(string[] uid, string[] mtime, int startIndex, int pageNum)
        //{
        //    string text = " ";
        //    for (int i = 0; i < uid.Length; i++)
        //    {
        //        DateTime dateTime = new DateTime(1, 1, 1, 0, 0, 0).AddSeconds((double)Convert.ToInt64(mtime[i].ToString()));
        //        if (i != uid.Length - 1)
        //        {
        //            string text2 = text;
        //            text = string.Concat(new string[]
        //            {
        //                text2,
        //                " ( logicdelete= 0 and UID = '",
        //                uid[i].ToString(),
        //                "' and MTime > '",
        //                dateTime.ToString("yyyy-MM-dd HH:mm:ss"),
        //                "' ) or "
        //            });
        //        }
        //        else
        //        {
        //            string text2 = text;
        //            text = string.Concat(new string[]
        //            {
        //                text2,
        //                " ( logicdelete= 0 and UID = '",
        //                uid[i].ToString(),
        //                "' and MTime > '",
        //                dateTime.ToString("yyyy-MM-dd HH:mm:ss"),
        //                "' ) "
        //            });
        //        }
        //    }
        //    string text3 = "select * from Calendar where {0}";
        //    text3 = string.Format(text3, text);
        //    List<Calendar> result;
        //    using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, text3, new SqlParameter[0]))
        //    {
        //        List<Calendar> list = new List<Calendar>();
        //        for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
        //        {
        //            list.Add(this.SetPram(dataSet.Tables[0].Rows[i]));
        //        }
        //        result = list;
        //    }
        //    return result;
        //}
        //public Calendar Find_Calendar_ByPara(string uid, string eid)
        //{
        //    string text = "select * from Calendar where {0}";
        //    string arg = string.Concat(new string[]
        //    {
        //        " LogicDelete=0 and Uid='",
        //        uid,
        //        "' and Eid='",
        //        eid,
        //        "' "
        //    });
        //    text = string.Format(text, arg);
        //    Calendar result;
        //    using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, text, new SqlParameter[0]))
        //    {
        //        if (dataSet.Tables[0].Rows.Count > 0)
        //        {
        //            result = this.SetPram(dataSet.Tables[0].Rows[0]);
        //        }
        //        else
        //        {
        //            result = null;
        //        }
        //    }
        //    return result;
        //}
        //public List<Calendar> Find_Calendar_ByPara_list(string uid, string eid)
        //{
        //    string text = "select * from Calendar where {0}";
        //    string arg = string.Concat(new string[]
        //    {
        //        " LogicDelete=0 and Uid='",
        //        uid,
        //        "' and Eid='",
        //        eid,
        //        "' "
        //    });
        //    text = string.Format(text, arg);
        //    List<Calendar> result;
        //    using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, text, new SqlParameter[0]))
        //    {
        //        if (dataSet.Tables[0].Rows.Count > 0)
        //        {
        //            List<Calendar> list = new List<Calendar>();
        //            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
        //            {
        //                list.Add(this.SetPram(dataSet.Tables[0].Rows[i]));
        //            }
        //            result = list;
        //        }
        //        else
        //        {
        //            result = null;
        //        }
        //    }
        //    return result;
        //}

        //public string Update<T>(T entity, Action<T> update) where T : class
        //{
        //    string result;
        //    try
        //    {
        //        update(entity);
        //        string cmdText = "update Calendar set UID=@UID,EID=@EID,EName=@EName,STime=@STime,ETime=@ETime,CTime=@CTime,MEMO=@MEMO,MTime=@MTime,LogicDelete=@LogicDelete where ID=@ID";
        //        Calendar calendars = entity as Calendar;
        //        SqlParameter[] cmdParms = new SqlParameter[]
        //        {
        //            new SqlParameter("@UID", calendars.UID),
        //            new SqlParameter("@EID", calendars.EID),
        //            new SqlParameter("@EName", calendars.EName),
        //            new SqlParameter("@STime", calendars.STime),
        //            new SqlParameter("@ETime", calendars.ETime),
        //            new SqlParameter("@CTime", calendars.CTime),
        //            new SqlParameter("@MEMO", calendars.MEMO),
        //            new SqlParameter("@MTime", calendars.MTime),
        //            new SqlParameter("@LogicDelete", calendars.LogicDelete),
        //            new SqlParameter("@ID", calendars.ID)
        //        };
        //        int num = MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, cmdParms);
        //        if (num > 0)
        //        {
        //            result = "1";
        //        }
        //        else
        //        {
        //            result = "0";
        //        }
        //    }
        //    catch
        //    {
        //        result = "0";
        //    }
        //    return result;
        //}
        //public string Insert<T>(T entity) where T : class
        //{
        //    string result;
        //    try
        //    {
        //        string cmdText = "insert into Calendar(UID,EID,EName,STime,ETime,CTime,MEMO,MTime,LogicDelete) values(@UID,@EID,@EName,@STime,@ETime,@CTime,@MEMO,@MTime,@LogicDelete)";
        //        Calendar calendars = entity as Calendar;
        //        SqlParameter[] cmdParms = new SqlParameter[]
        //        {
        //            new SqlParameter("@UID", calendars.UID),
        //            new SqlParameter("@EID", calendars.EID),
        //            new SqlParameter("@EName", calendars.EName),
        //            new SqlParameter("@STime", calendars.STime),
        //            new SqlParameter("@ETime", calendars.ETime),
        //            new SqlParameter("@CTime", calendars.CTime),
        //            new SqlParameter("@MEMO", calendars.MEMO),
        //            new SqlParameter("@MTime", calendars.MTime),
        //            new SqlParameter("@LogicDelete", calendars.LogicDelete)
        //        };
        //        int num = MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, cmdParms);
        //        if (num > 0)
        //        {
        //            result = "1";
        //        }
        //        else
        //        {
        //            result = "0";
        //        }
        //    }
        //    catch
        //    {
        //        result = "0";
        //    }
        //    return result;
        //}
        //public string Delete<T>(T entity) where T : class
        //{
        //    string result;
        //    try
        //    {
        //        Calendar calendars = entity as Calendar;
        //        string cmdText = "delete from Calendar where id=" + calendars.ID;
        //        int num = MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
        //        if (num > 0)
        //        {
        //            result = "1";
        //        }
        //        else
        //        {
        //            result = "0";
        //        }
        //    }
        //    catch
        //    {
        //        result = "0";
        //    }
        //    return result;
        //}
        //private Calendar SetPram(DataRow dbRow)
        //{
        //    return new Calendar
        //    {
        //        CTime = string.Concat(dbRow["CTime"]),
        //        EID = string.Concat(dbRow["EID"]),
        //        EName = string.Concat(dbRow["EName"]),
        //        ETime = string.Concat(dbRow["ETime"]),
        //        MEMO = string.Concat(dbRow["MEMO"]),
        //        UID = string.Concat(dbRow["UID"]),
        //        STime = string.Concat(dbRow["STime"]),
        //        MTime = Convert.ToDateTime(dbRow["MTime"]),
        //        ID = Convert.ToInt32(dbRow["ID"]),
        //        LogicDelete = Convert.ToInt32(dbRow["LogicDelete"])
        //    };
        //}









        #region 数据库相关操作

        #region Calendar
        public List<Calendar> Find_Calendar_List(int startIndex, int pageNum)
        {
            using (dblimaganDataContext db = new dblimaganDataContext())
            {
                var query = (from c in db.Calendar
                             select c).Skip(startIndex).Take(pageNum);
                return query.ToList<Calendar>();
            }
        }

        public List<Calendar> Find_Calendar_List_ByUID(string uid, int startIndex, int pageNum)
        {
            using (dblimaganDataContext db = new dblimaganDataContext())
            {
                var query = (from c in db.Calendar
                             where c.UID == uid
                             orderby c.ID descending
                             select c).Skip(startIndex).Take(pageNum);
                return query.ToList<Calendar>();
            }
        }

        public int Find_Calendar_count()
        {
            using (dblimaganDataContext db = new dblimaganDataContext())
            {
                return db.Calendar.Count();
            }
        }

        public Calendar Find_Calendar_ByPK(int ID)
        {
            using (dblimaganDataContext db = new dblimaganDataContext())
            {
                try
                {
                    Calendar my_lc = db.Calendar.Single(c => c.ID == ID);
                    return my_lc;
                }
                catch
                {
                    return null;
                }
            }
        }

        public Calendar Find_Calendar_ByPara(string uid, string eid)
        {
            using (dblimaganDataContext db = new dblimaganDataContext())
            {
                try
                {
                    Calendar my_lc = db.Calendar.Single(c => c.UID == uid && c.EID == eid);
                    return my_lc;
                }
                catch
                {
                    return null;
                }
            }
        }
        #endregion

        #region 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="update"></param>
        /// <returns></returns>
        public string Update<T>(T entity, Action<T> update) where T : class
        {
            using (dblimaganDataContext db = new dblimaganDataContext())
            {
                try
                {
                    db.GetTable<T>().Attach(entity);
                    update(entity);
                    db.SubmitChanges();
                    return "1";
                }
                catch
                {
                    return "0";
                }
            }
        }
        #endregion

        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string Insert<T>(T entity) where T : class
        {
            using (dblimaganDataContext db = new dblimaganDataContext())
            {
                try
                {
                    db.GetTable<T>().InsertOnSubmit(entity);
                    db.SubmitChanges();
                    return "1";
                }
                catch
                {
                    return "0";
                }
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string Delete<T>(T entity) where T : class
        {
            using (dblimaganDataContext db = new dblimaganDataContext())
            {
                try
                {
                    db.GetTable<T>().Attach(entity);
                    db.GetTable<T>().DeleteOnSubmit(entity);
                    db.SubmitChanges();
                    return "1";
                }
                catch
                {
                    return "0";
                }
            }
        }
        #endregion

        #endregion

    }

