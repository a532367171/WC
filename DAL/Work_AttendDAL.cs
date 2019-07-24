using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Work_AttendDAL : IWork_Attend
    {
        private EntityControl control;
        public Work_AttendDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Work_AttendInfo Work_Attend_)
        {
            this.control.AddEntity(Work_Attend_);
        }
        public void Update(Work_AttendInfo Work_Attend_)
        {
            this.control.UpdateEntity(Work_Attend_, Work_Attend_.id);
        }
        public void Delete(int id)
        {
            Work_AttendInfo work_AttendInfo = new Work_AttendInfo();
            work_AttendInfo.id = id;
            this.control.DeleteEntity(work_AttendInfo);
        }
        public Work_AttendInfo GetById(int id)
        {
            return (Work_AttendInfo)this.control.GetEntity("WC.Model.Work_AttendInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Work_AttendInfo", where, orderBy);
        }
    }
}
