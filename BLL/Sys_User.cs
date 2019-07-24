using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Sys_User
    {
        private static readonly ISys_User dal = DALFactory.CreateSys_UserDAL();
        private Sys_User()
        {
        }
        public static Sys_User Init()
        {
            return new Sys_User();
        }
        public void Add(Sys_UserInfo com)
        {
            Sys_User.dal.Add(com);
        }
        public void Update(Sys_UserInfo com)
        {
            Sys_User.dal.Update(com);
        }
        public void Delete(int id)
        {
            Sys_User.dal.Delete(id);
        }
        public Sys_UserInfo GetById(int id)
        {
            return Sys_User.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Sys_User.dal.GetAll(where, orderBy);
        }
    }
}
