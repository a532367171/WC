using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Sys_UserLoginDAL : ISys_UserLogin
    {
        private EntityControl control;
        public Sys_UserLoginDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Sys_UserLoginInfo Sys_UserLogin_)
        {
            this.control.AddEntity(Sys_UserLogin_);
        }
        public void Update(Sys_UserLoginInfo Sys_UserLogin_)
        {
            this.control.UpdateEntity(Sys_UserLogin_, Sys_UserLogin_.id);
        }
        public void Delete(int id)
        {
            Sys_UserLoginInfo sys_UserLoginInfo = new Sys_UserLoginInfo();
            sys_UserLoginInfo.id = id;
            this.control.DeleteEntity(sys_UserLoginInfo);
        }
        public Sys_UserLoginInfo GetById(int id)
        {
            return (Sys_UserLoginInfo)this.control.GetEntity("WC.Model.Sys_UserLoginInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Sys_UserLoginInfo", where, orderBy);
        }
    }
}
