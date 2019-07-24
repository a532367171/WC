using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Tasks_TypeDAL : ITasks_Type
    {
        private EntityControl control;
        public Tasks_TypeDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Tasks_TypeInfo Tasks_Type_)
        {
            this.control.AddEntity(Tasks_Type_);
        }
        public void Update(Tasks_TypeInfo Tasks_Type_)
        {
            this.control.UpdateEntity(Tasks_Type_, Tasks_Type_.id);
        }
        public void Delete(int id)
        {
            Tasks_TypeInfo tasks_TypeInfo = new Tasks_TypeInfo();
            tasks_TypeInfo.id = id;
            this.control.DeleteEntity(tasks_TypeInfo);
        }
        public Tasks_TypeInfo GetById(int id)
        {
            return (Tasks_TypeInfo)this.control.GetEntity("WC.Model.Tasks_TypeInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Tasks_TypeInfo", where, orderBy);
        }
    }
}
