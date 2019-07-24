using NHibernate;
using System;
using System.Collections;
using System.Threading;
namespace WC.Common
{
    public class EntityControl
    {
        private static EntityControl entity;
        private string _AssemblyName;
        private static readonly object padlock = new object();
        public static EntityControl CreateEntityControl(string AssemblyName)
        {
            if (EntityControl.entity == null)
            {
                object obj;
                Monitor.Enter(obj = EntityControl.padlock);
                try
                {
                    if (EntityControl.entity == null)
                    {
                        EntityControl.entity = new EntityControl();
                        EntityControl.entity._AssemblyName = AssemblyName;
                    }
                }
                finally
                {
                    Monitor.Exit(obj);
                }
            }
            return EntityControl.entity;
        }
        public void AddEntity(object entity)
        {
            ISession session = SessionFactory.OpenSession(this._AssemblyName);
            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.Save(entity);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                session.Close();
                session.Dispose();
            }
        }
        public void UpdateEntity(object entity, object key)
        {
            ISession session = SessionFactory.OpenSession(this._AssemblyName);
            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.Update(entity, key);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                session.Close();
                session.Dispose();
            }
        }
        public void DeleteEntity(object entity)
        {
            ISession session = SessionFactory.OpenSession(this._AssemblyName);
            ITransaction transaction = session.BeginTransaction();
            try
            {
                session.Delete(entity);
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                session.Close();
                session.Dispose();
            }
        }
        public object GetEntity(string table, string idFieldName, string id)
        {
            string queryString = string.Concat(new string[]
			{
				"From ",
				table,
				" Where ",
				idFieldName,
				" = '",
				id,
				"'"
			});
            ISession session = SessionFactory.OpenSession(this._AssemblyName);
            object result = session.CreateQuery(queryString).UniqueResult();
            session.Close();
            session.Dispose();
            return result;
        }
        public IList GetEntitesPage(int pageIndex, int pageSize, string table, string where, string orderBy)
        {
            string text = "From " + table;
            if (!string.IsNullOrEmpty(where) && where != "")
            {
                text = text + " Where " + where;
            }
            if (!string.IsNullOrEmpty(orderBy) && orderBy != "")
            {
                text = text + " Order By " + orderBy;
            }
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 1;
            }
            ISession session = SessionFactory.OpenSession(this._AssemblyName);
            IList result = session.CreateQuery(text).SetFirstResult(pageSize * (pageIndex - 1)).SetMaxResults(pageSize).List();
            session.Close();
            session.Dispose();
            return result;
        }
        public string GetPageSet(int pageIndex, int pageSize, string tableName, string where, string urlFormat, int mode)
        {
            ISession session = SessionFactory.OpenSession(this._AssemblyName);
            int recordCount = DirectRun.GetRecordCount(session, tableName, where);
            session.Close();
            session.Dispose();
            return SplitPage.GetPageSet(pageIndex, pageSize, recordCount, urlFormat, mode);
        }
        public IList GetEntities(string table, string where, string orderBy)
        {
            string text = "From " + table;
            if (!string.IsNullOrEmpty(where) && where != "")
            {
                text = text + " Where " + where;
            }
            if (!string.IsNullOrEmpty(orderBy) && orderBy != "")
            {
                text = text + " Order By " + orderBy;
            }
            ISession session = SessionFactory.OpenSession(this._AssemblyName);
           IList result = session.CreateQuery(text).List();
            session.Close();
            session.Dispose();
            return result;
        }
        public int ExecuteNonQuery(string sqlString)
        {
            ISession session = SessionFactory.OpenSession(this._AssemblyName);
            int result = DirectRun.ExecuteNonQuery(session, sqlString);
            session.Close();
            session.Dispose();
            return result;
        }
    }
}
