using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;

namespace WC.BLL
{
    public class Sys_Dep_Module
    {
        private static readonly ISys_Dep_Module dal = DALFactory.CreateSys_Dep_ModuleDAL();
        private Sys_Dep_Module()
        {
        }
        public static Sys_Dep_Module Init()
        {
            return new Sys_Dep_Module();
        }
        public void Add(Sys_Dep_ModuleInfo com)
        {
            Sys_Dep_Module.dal.Add(com);
        }
        public void Update(Sys_Dep_ModuleInfo com)
        {
            Sys_Dep_Module.dal.Update(com);
        }
        public void Delete(int id)
        {
            Sys_Dep_Module.dal.Delete(id);
        }
        public Sys_Dep_ModuleInfo GetById(int id)
        {
            return Sys_Dep_Module.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Sys_Dep_Module.dal.GetAll(where, orderBy);
        }

    }
}
