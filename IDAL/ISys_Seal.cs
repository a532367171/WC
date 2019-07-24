using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface ISys_Seal
    {
        void Add(Sys_SealInfo com);
        void Update(Sys_SealInfo com);
        void Delete(int id);
        Sys_SealInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
