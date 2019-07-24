using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Tasks_User
    {
        private static readonly ITasks_User dal = DALFactory.CreateTasks_UserDAL();
        private Tasks_User()
        {
        }
        public static Tasks_User Init()
        {
            return new Tasks_User();
        }
        public void Add(Tasks_UserInfo com)
        {
            Tasks_User.dal.Add(com);
        }
        public void Update(Tasks_UserInfo com)
        {
            Tasks_User.dal.Update(com);
        }
        public void Delete(int id)
        {
            Tasks_User.dal.Delete(id);
        }
        public Tasks_UserInfo GetById(int id)
        {
            return Tasks_User.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Tasks_User.dal.GetAll(where, orderBy);
        }
    }
}
