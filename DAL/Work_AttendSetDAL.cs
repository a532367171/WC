using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Work_AttendSetDAL : IWork_AttendSet
    {
        private EntityControl control;
        public Work_AttendSetDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Work_AttendSetInfo Work_AttendSet_)
        {
            this.control.AddEntity(Work_AttendSet_);
        }
        public void Update(Work_AttendSetInfo Work_AttendSet_)
        {
            this.control.UpdateEntity(Work_AttendSet_, Work_AttendSet_.id);
        }
        public void Delete(int id)
        {
            Work_AttendSetInfo work_AttendSetInfo = new Work_AttendSetInfo();
            work_AttendSetInfo.id = id;
            this.control.DeleteEntity(work_AttendSetInfo);
        }
        public Work_AttendSetInfo GetById(int id)
        {
            return (Work_AttendSetInfo)this.control.GetEntity("WC.Model.Work_AttendSetInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Work_AttendSetInfo", where, orderBy);
        }
    }
}
