using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Work_AttendSet
    {
        private static readonly IWork_AttendSet dal = DALFactory.CreateWork_AttendSetDAL();
        private Work_AttendSet()
        {
        }
        public static Work_AttendSet Init()
        {
            return new Work_AttendSet();
        }
        public void Add(Work_AttendSetInfo com)
        {
            Work_AttendSet.dal.Add(com);
        }
        public void Update(Work_AttendSetInfo com)
        {
            Work_AttendSet.dal.Update(com);
        }
        public void Delete(int id)
        {
            Work_AttendSet.dal.Delete(id);
        }
        public Work_AttendSetInfo GetById(int id)
        {
            return Work_AttendSet.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Work_AttendSet.dal.GetAll(where, orderBy);
        }
    }
}
