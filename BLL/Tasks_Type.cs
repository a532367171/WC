using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Tasks_Type
    {
        private static readonly ITasks_Type dal = DALFactory.CreateTasks_TypeDAL();
        private Tasks_Type()
        {
        }
        public static Tasks_Type Init()
        {
            return new Tasks_Type();
        }
        public void Add(Tasks_TypeInfo com)
        {
            Tasks_Type.dal.Add(com);
        }
        public void Update(Tasks_TypeInfo com)
        {
            Tasks_Type.dal.Update(com);
        }
        public void Delete(int id)
        {
            Tasks_Type.dal.Delete(id);
        }
        public Tasks_TypeInfo GetById(int id)
        {
            return Tasks_Type.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Tasks_Type.dal.GetAll(where, orderBy);
        }
    }
}
