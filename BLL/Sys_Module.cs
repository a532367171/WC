using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Sys_Module
    {
        private static readonly ISys_Module dal = DALFactory.CreateSys_ModuleDAL();
        private Sys_Module()
        {
        }
        public static Sys_Module Init()
        {
            return new Sys_Module();
        }
        public void Add(Sys_ModuleInfo com)
        {
            Sys_Module.dal.Add(com);
        }
        public void Update(Sys_ModuleInfo com)
        {
            Sys_Module.dal.Update(com);
        }
        public void Delete(int id)
        {
            Sys_Module.dal.Delete(id);
        }
        public Sys_ModuleInfo GetById(int id)
        {
            return Sys_Module.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Sys_Module.dal.GetAll(where, orderBy);
        }
    }
}
