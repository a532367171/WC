using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class TasksDAL : ITasks
    {
        private EntityControl control;
        public TasksDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(TasksInfo Tasks_)
        {
            this.control.AddEntity(Tasks_);
        }
        public void Update(TasksInfo Tasks_)
        {
            this.control.UpdateEntity(Tasks_, Tasks_.id);
        }
        public void Delete(int id)
        {
            TasksInfo tasksInfo = new TasksInfo();
            tasksInfo.id = id;
            this.control.DeleteEntity(tasksInfo);
        }
        public TasksInfo GetById(int id)
        {
            return (TasksInfo)this.control.GetEntity("WC.Model.TasksInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.TasksInfo", where, orderBy);
        }
    }
}
