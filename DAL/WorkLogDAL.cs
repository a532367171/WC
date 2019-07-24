using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class WorkLogDAL : IWorkLog
    {
        private EntityControl control;
        public WorkLogDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(WorkLogInfo WorkLog_)
        {
            this.control.AddEntity(WorkLog_);
        }
        public void Update(WorkLogInfo WorkLog_)
        {
            this.control.UpdateEntity(WorkLog_, WorkLog_.id);
        }
        public void Delete(int id)
        {
            WorkLogInfo workLogInfo = new WorkLogInfo();
            workLogInfo.id = id;
            this.control.DeleteEntity(workLogInfo);
        }
        public WorkLogInfo GetById(int id)
        {
            return (WorkLogInfo)this.control.GetEntity("WC.Model.WorkLogInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.WorkLogInfo", where, orderBy);
        }
    }
}
