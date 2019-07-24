using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface ISys_Dep
    {
        void Add(Sys_DepInfo com);
        void Update(Sys_DepInfo com);
        void Delete(int id);
        Sys_DepInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
