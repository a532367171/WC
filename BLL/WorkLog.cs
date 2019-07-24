using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class WorkLog
    {
        private static readonly IWorkLog dal = DALFactory.CreateWorkLogDAL();
        private WorkLog()
        {
        }
        public static WorkLog Init()
        {
            return new WorkLog();
        }
        public void Add(WorkLogInfo com)
        {
            WorkLog.dal.Add(com);
        }
        public void Update(WorkLogInfo com)
        {
            WorkLog.dal.Update(com);
        }
        public void Delete(int id)
        {
            WorkLog.dal.Delete(id);
        }
        public WorkLogInfo GetById(int id)
        {
            return WorkLog.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return WorkLog.dal.GetAll(where, orderBy);
        }
    }
}
