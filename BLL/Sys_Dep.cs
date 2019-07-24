using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Sys_Dep
    {
        private static readonly ISys_Dep dal = DALFactory.CreateSys_DepDAL();
        private Sys_Dep()
        {
        }
        public static Sys_Dep Init()
        {
            return new Sys_Dep();
        }
        public void Add(Sys_DepInfo com)
        {
            Sys_Dep.dal.Add(com);
        }
        public void Update(Sys_DepInfo com)
        {
            Sys_Dep.dal.Update(com);
        }
        public void Delete(int id)
        {
            Sys_Dep.dal.Delete(id);
        }
        public Sys_DepInfo GetById(int id)
        {
            return Sys_Dep.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Sys_Dep.dal.GetAll(where, orderBy);
        }
    }
}
