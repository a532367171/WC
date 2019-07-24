using NHibernate;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using WC.Common;
namespace WC.DBUtility
{
    public abstract class MsSqlOperate
    {
        public static readonly string ConnString = "";
        public MsSqlOperate()
        {
        }
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            ISession session = SessionFactory.OpenSession("WC.Model");
            int result;
         			using (SqlConnection sqlConnection = (SqlConnection)session.Connection)
            //   using (SqlConnection sqlConnection = (SqlConnection)session.get_Connection())
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    MsSqlOperate.PrepareCommand(sqlCommand, sqlConnection, null, cmdType, cmdText, cmdParms);
                    int num = sqlCommand.ExecuteNonQuery();
                    sqlCommand.Parameters.Clear();
                    result = num;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    session.Close();
                    session.Dispose();
                }
            }
            return result;
        }
        public static int ExecuteNonQuery(SqlTransaction trans, SqlConnection conn, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            int result;
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                MsSqlOperate.PrepareCommand(sqlCommand, conn, trans, cmdType, cmdText, cmdParms);
                int num = sqlCommand.ExecuteNonQuery();
                sqlCommand.Parameters.Clear();
                result = num;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            ISession session = SessionFactory.OpenSession("WC.Model");
            object result;
            using (SqlConnection sqlConnection = (SqlConnection)session.Connection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    MsSqlOperate.PrepareCommand(sqlCommand, sqlConnection, null, cmdType, cmdText, cmdParms);
                    object obj = sqlCommand.ExecuteScalar();
                    sqlCommand.Parameters.Clear();
                    result = obj;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    session.Close();
                    session.Dispose();
                }
            }
            return result;
        }
        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            ISession session = SessionFactory.OpenSession("WC.Model");
            SqlConnection conn = (SqlConnection)session.Connection;
            SqlDataReader result;
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                MsSqlOperate.PrepareCommand(sqlCommand, conn, null, cmdType, cmdText, cmdParms);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                sqlCommand.Parameters.Clear();
                result = sqlDataReader;
            }
            catch (SqlException ex)
            {
                session.Close();
                session.Dispose();
                throw ex;
            }
            return result;
        }
        public static DataSet ExecuteDataset(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            ISession session = SessionFactory.OpenSession("WC.Model");
            DataSet result;
            using (SqlConnection sqlConnection = (SqlConnection)session.Connection)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    MsSqlOperate.PrepareCommand(sqlCommand, sqlConnection, null, cmdType, cmdText, cmdParms);
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        DataSet dataSet = new DataSet();
                        sqlDataAdapter.Fill(dataSet);
                        sqlCommand.Parameters.Clear();
                        result = dataSet;
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    session.Close();
                    session.Dispose();
                }
            }
            return result;
        }
        public static DataTable ConvertDataReaderToDataTable(SqlDataReader dataReader)
        {
            DataTable dataTable = new DataTable();
            DataTable dataTable2 = dataReader.GetSchemaTable();
            DataTable result;
            try
            {
                IEnumerator enumerator = dataTable2.Rows.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        DataRow dataRow = (DataRow)enumerator.Current;
                        DataColumn dataColumn = new DataColumn();
                        dataColumn.DataType = Type.GetType("System.String");
                        dataColumn.ColumnName = dataRow[0].ToString();
                        dataTable.Columns.Add(dataColumn);
                    }
                    goto IL_C9;
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
            IL_83:
                DataRow dataRow2 = dataTable.NewRow();
                for (int i = 0; i < dataTable2.Rows.Count; i++)
                {
                    dataRow2[i] = dataReader[i].ToString();
                }
                dataTable.Rows.Add(dataRow2);
            IL_C9:
                if (dataReader.Read())
                {
                    goto IL_83;
                }
                dataTable2 = null;
                dataReader.Close();
                result = dataTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                for (int i = 0; i < cmdParms.Length; i++)
                {
                    SqlParameter value = cmdParms[i];
                    cmd.Parameters.Add(value);
                }
            }
        }
    }
}
