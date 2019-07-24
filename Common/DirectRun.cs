using NHibernate;
using System;
using System.Data;
using System.Data.OleDb;
namespace WC.Common
{
    public static class DirectRun
    {
        public static int GetRecordCount(ISession session, string tableName, string where)
        {
            int result = 0;
            string text = "Select Count(*) From [" + tableName + "]";
            if (!string.IsNullOrEmpty(where) && where != "")
            {
                text = text + " Where " + where;
            }
            try
            {
                IDbConnection connection = session.Connection;
                OleDbDataReader oleDbDataReader = new OleDbCommand
                {
                    Connection = (OleDbConnection)connection,
                    CommandType = CommandType.Text,
                    CommandText = text
                }.ExecuteReader();
                if (oleDbDataReader.Read())
                {
                    result = Convert.ToInt32(oleDbDataReader[0]);
                }
            }
            finally
            {
                if (session != null)
                {
                    session.Dispose();
                }
            }
            return result;
        }
        public static int ExecuteNonQuery(ISession session, string cmdText)
        {
            int result;
            try
            {
                IDbConnection connection = session.Connection;
                int num = new OleDbCommand
                {
                    Connection = (OleDbConnection)connection,
                    CommandType = CommandType.Text,
                    CommandText = cmdText
                }.ExecuteNonQuery();
                result = num;
            }
            finally
            {
                if (session != null)
                {
                    session.Dispose();
                }
            }
            return result;
        }
    }
}
