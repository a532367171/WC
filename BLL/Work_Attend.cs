using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Work_Attend
    {
        private static readonly IWork_Attend dal = DALFactory.CreateWork_AttendDAL();
        private Work_Attend()
        {
        }
        public static Work_Attend Init()
        {
            return new Work_Attend();
        }
        public void Add(Work_AttendInfo com)
        {
            Work_Attend.dal.Add(com);
        }
        public void Update(Work_AttendInfo com)
        {
            Work_Attend.dal.Update(com);
        }
        public void Delete(int id)
        {
            Work_Attend.dal.Delete(id);
        }
        public Work_AttendInfo GetById(int id)
        {
            return Work_Attend.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Work_Attend.dal.GetAll(where, orderBy);
        }
    }
}
