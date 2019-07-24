using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Sys_UserLogin
    {
        private static readonly ISys_UserLogin dal = DALFactory.CreateSys_UserLoginDAL();
        private Sys_UserLogin()
        {
        }
        public static Sys_UserLogin Init()
        {
            return new Sys_UserLogin();
        }
        public void Add(Sys_UserLoginInfo com)
        {
            Sys_UserLogin.dal.Add(com);
        }
        public void Update(Sys_UserLoginInfo com)
        {
            Sys_UserLogin.dal.Update(com);
        }
        public void Delete(int id)
        {
            Sys_UserLogin.dal.Delete(id);
        }
        public Sys_UserLoginInfo GetById(int id)
        {
            return Sys_UserLogin.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Sys_UserLogin.dal.GetAll(where, orderBy);
        }
    }
}
