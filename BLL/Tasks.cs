using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Tasks
    {
        private static readonly ITasks dal = DALFactory.CreateTasksDAL();
        private Tasks()
        {
        }
        public static Tasks Init()
        {
            return new Tasks();
        }
        public void Add(TasksInfo com)
        {
            Tasks.dal.Add(com);
        }
        public void Update(TasksInfo com)
        {
            Tasks.dal.Update(com);
        }
        public void Delete(int id)
        {
            Tasks.dal.Delete(id);
        }
        public TasksInfo GetById(int id)
        {
            return Tasks.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Tasks.dal.GetAll(where, orderBy);
        }
    }
}
