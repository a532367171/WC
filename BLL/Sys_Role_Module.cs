using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Sys_Role_Module
    {
        private static readonly ISys_Role_Module dal = DALFactory.CreateSys_Role_ModuleDAL();
        private Sys_Role_Module()
        {
        }
        public static Sys_Role_Module Init()
        {
            return new Sys_Role_Module();
        }
        public void Add(Sys_Role_ModuleInfo com)
        {
            Sys_Role_Module.dal.Add(com);
        }
        public void Update(Sys_Role_ModuleInfo com)
        {
            Sys_Role_Module.dal.Update(com);
        }
        public void Delete(int id)
        {
            Sys_Role_Module.dal.Delete(id);
        }
        public Sys_Role_ModuleInfo GetById(int id)
        {
            return Sys_Role_Module.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Sys_Role_Module.dal.GetAll(where, orderBy);
        }
    }
}
