using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface ISys_UserLogin
    {
        void Add(Sys_UserLoginInfo com);
        void Update(Sys_UserLoginInfo com);
        void Delete(int id);
        Sys_UserLoginInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
