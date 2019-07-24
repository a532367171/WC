using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface ISys_Dep_Module
    {
        void Add(Sys_Dep_ModuleInfo com);
        void Update(Sys_Dep_ModuleInfo com);
        void Delete(int id);
        Sys_Dep_ModuleInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
