using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface ISys_Role
    {
        void Add(Sys_RoleInfo com);
        void Update(Sys_RoleInfo com);
        void Delete(int id);
        Sys_RoleInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
