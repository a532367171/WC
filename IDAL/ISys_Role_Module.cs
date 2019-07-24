using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface ISys_Role_Module
    {
        void Add(Sys_Role_ModuleInfo com);
        void Update(Sys_Role_ModuleInfo com);
        void Delete(int id);
        Sys_Role_ModuleInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
