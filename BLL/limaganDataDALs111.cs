using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WC.DBUtility;
using WC.Model;


public class limaganDataDALs111
    {
        public List<Calendars> Find_Calendar_List_ByUID_and_TIME(string[] uid, string[] stime, string[] etime, int startIndex, int pageNum)
        {
            string text = " ";
            for (int i = 0; i < uid.Length; i++)
            {
                if (i != uid.Length - 1)
                {
                    string text2 = text;
                    text = string.Concat(new string[]
					{
						text2,
						" ( logicdelete= 0 and UID = '",
						uid[i].ToString(),
						"' and STime > '",
						stime[i].ToString(),
						"' and STime <= '",
						etime[i].ToString(),
						"') or "
					});
                }
                else
                {
                    string text2 = text;
                    text = string.Concat(new string[]
					{
						text2,
						" ( logicdelete= 0 and UID = '",
						uid[i].ToString(),
						"' and STime > '",
						stime[i].ToString(),
						"' and STime <= '",
						etime[i].ToString(),
						"') "
					});
                }
            }
            string text3 = "select * from Calendar where {0}";
            text3 = string.Format(text3, text);
            List<Calendars> result;
            using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, text3, new SqlParameter[0]))
            {
                List<Calendars> list = new List<Calendars>();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    list.Add(this.SetPram(dataSet.Tables[0].Rows[i]));
                }
                result = list;
            }
            return result;
        }
        public List<Calendars> Find_Calendar_List_ByUID_and_TIME(string[] uid, string[] mtime, int startIndex, int pageNum)
        {
            string text = " ";
            for (int i = 0; i < uid.Length; i++)
            {
                DateTime dateTime = new DateTime(1, 1, 1, 0, 0, 0).AddSeconds((double)Convert.ToInt64(mtime[i].ToString()));
                if (i != uid.Length - 1)
                {
                    string text2 = text;
                    text = string.Concat(new string[]
					{
						text2,
						" ( logicdelete= 0 and UID = '",
						uid[i].ToString(),
						"' and MTime > '",
						dateTime.ToString("yyyy-MM-dd HH:mm:ss"),
						"' ) or "
					});
                }
                else
                {
                    string text2 = text;
                    text = string.Concat(new string[]
					{
						text2,
						" ( logicdelete= 0 and UID = '",
						uid[i].ToString(),
						"' and MTime > '",
						dateTime.ToString("yyyy-MM-dd HH:mm:ss"),
						"' ) "
					});
                }
            }
            string text3 = "select * from Calendar where {0}";
            text3 = string.Format(text3, text);
            List<Calendars> result;
            using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, text3, new SqlParameter[0]))
            {
                List<Calendars> list = new List<Calendars>();
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    list.Add(this.SetPram(dataSet.Tables[0].Rows[i]));
                }
                result = list;
            }
            return result;
        }
        public Calendars Find_Calendar_ByPara(string uid, string eid)
        {
            string text = "select * from Calendar where {0}";
            string arg = string.Concat(new string[]
			{
				" LogicDelete=0 and Uid='",
				uid,
				"' and Eid='",
				eid,
				"' "
			});
            text = string.Format(text, arg);
            Calendars result;
            using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, text, new SqlParameter[0]))
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    result = this.SetPram(dataSet.Tables[0].Rows[0]);
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }
        public List<Calendars> Find_Calendar_ByPara_list(string uid, string eid)
        {
            string text = "select * from Calendar where {0}";
            string arg = string.Concat(new string[]
			{
				" LogicDelete=0 and Uid='",
				uid,
				"' and Eid='",
				eid,
				"' "
			});
            text = string.Format(text, arg);
            List<Calendars> result;
            using (DataSet dataSet = MsSqlOperate.ExecuteDataset(CommandType.Text, text, new SqlParameter[0]))
            {
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    List<Calendars> list = new List<Calendars>();
                    for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                    {
                        list.Add(this.SetPram(dataSet.Tables[0].Rows[i]));
                    }
                    result = list;
                }
                else
                {
                    result = null;
                }
            }
            return result;
        }
        public string Update<T>(T entity, Action<T> update) where T : class
        {
            string result;
            try
            {
                update(entity);
                string cmdText = "update Calendar set UID=@UID,EID=@EID,EName=@EName,STime=@STime,ETime=@ETime,CTime=@CTime,MEMO=@MEMO,MTime=@MTime,LogicDelete=@LogicDelete where ID=@ID";
                Calendars calendars = entity as Calendars;
                SqlParameter[] cmdParms = new SqlParameter[]
				{
					new SqlParameter("@UID", calendars.UID),
					new SqlParameter("@EID", calendars.EID),
					new SqlParameter("@EName", calendars.EName),
					new SqlParameter("@STime", calendars.STime),
					new SqlParameter("@ETime", calendars.ETime),
					new SqlParameter("@CTime", calendars.CTime),
					new SqlParameter("@MEMO", calendars.MEMO),
					new SqlParameter("@MTime", calendars.MTime),
					new SqlParameter("@LogicDelete", calendars.LogicDelete),
					new SqlParameter("@ID", calendars.ID)
				};
                int num = MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, cmdParms);
                if (num > 0)
                {
                    result = "1";
                }
                else
                {
                    result = "0";
                }
            }
            catch
            {
                result = "0";
            }
            return result;
        }
        public string Insert<T>(T entity) where T : class
        {
            string result;
            try
            {
                string cmdText = "insert into Calendar(UID,EID,EName,STime,ETime,CTime,MEMO,MTime,LogicDelete) values(@UID,@EID,@EName,@STime,@ETime,@CTime,@MEMO,@MTime,@LogicDelete)";
                Calendars calendars = entity as Calendars;
                SqlParameter[] cmdParms = new SqlParameter[]
				{
					new SqlParameter("@UID", calendars.UID),
					new SqlParameter("@EID", calendars.EID),
					new SqlParameter("@EName", calendars.EName),
					new SqlParameter("@STime", calendars.STime),
					new SqlParameter("@ETime", calendars.ETime),
					new SqlParameter("@CTime", calendars.CTime),
					new SqlParameter("@MEMO", calendars.MEMO),
					new SqlParameter("@MTime", calendars.MTime),
					new SqlParameter("@LogicDelete", calendars.LogicDelete)
				};
                int num = MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, cmdParms);
                if (num > 0)
                {
                    result = "1";
                }
                else
                {
                    result = "0";
                }
            }
            catch
            {
                result = "0";
            }
            return result;
        }
        public string Delete<T>(T entity) where T : class
        {
            string result;
            try
            {
                Calendars calendars = entity as Calendars;
                string cmdText = "delete from Calendar where id=" + calendars.ID;
                int num = MsSqlOperate.ExecuteNonQuery(CommandType.Text, cmdText, new SqlParameter[0]);
                if (num > 0)
                {
                    result = "1";
                }
                else
                {
                    result = "0";
                }
            }
            catch
            {
                result = "0";
            }
            return result;
        }
        private Calendars SetPram(DataRow dbRow)
        {
            return new Calendars
            {
                CTime = string.Concat(dbRow["CTime"]),
                EID = string.Concat(dbRow["EID"]),
                EName = string.Concat(dbRow["EName"]),
                ETime = string.Concat(dbRow["ETime"]),
                MEMO = string.Concat(dbRow["MEMO"]),
                UID = string.Concat(dbRow["UID"]),
                STime = string.Concat(dbRow["STime"]),
                MTime = Convert.ToDateTime(dbRow["MTime"]),
                ID = Convert.ToInt32(dbRow["ID"]),
                LogicDelete = Convert.ToInt32(dbRow["LogicDelete"])
            };
        }
    }

