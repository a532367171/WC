using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Tasks_UserDAL : ITasks_User
    {
        private EntityControl control;
        public Tasks_UserDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Tasks_UserInfo Tasks_User_)
        {
            this.control.AddEntity(Tasks_User_);
        }
        public void Update(Tasks_UserInfo Tasks_User_)
        {
            this.control.UpdateEntity(Tasks_User_, Tasks_User_.id);
        }
        public void Delete(int id)
        {
            Tasks_UserInfo tasks_UserInfo = new Tasks_UserInfo();
            tasks_UserInfo.id = id;
            this.control.DeleteEntity(tasks_UserInfo);
        }
        public Tasks_UserInfo GetById(int id)
        {
            return (Tasks_UserInfo)this.control.GetEntity("WC.Model.Tasks_UserInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Tasks_UserInfo", where, orderBy);
        }
    }
}
