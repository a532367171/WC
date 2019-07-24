using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Sys_Role
    {
        private static readonly ISys_Role dal = DALFactory.CreateSys_RoleDAL();
        private Sys_Role()
        {
        }
        public static Sys_Role Init()
        {
            return new Sys_Role();
        }
        public void Add(Sys_RoleInfo com)
        {
            Sys_Role.dal.Add(com);
        }
        public void Update(Sys_RoleInfo com)
        {
            Sys_Role.dal.Update(com);
        }
        public void Delete(int id)
        {
            if (id != 4)
            {
                Sys_Role.dal.Delete(id);
            }
        }
        public Sys_RoleInfo GetById(int id)
        {
            return Sys_Role.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Sys_Role.dal.GetAll(where, orderBy);
        }
    }
}
