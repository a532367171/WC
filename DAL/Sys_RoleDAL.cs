using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Sys_RoleDAL : ISys_Role
    {
        private EntityControl control;
        public Sys_RoleDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Sys_RoleInfo Sys_Role)
        {
            this.control.AddEntity(Sys_Role);
        }
        public void Update(Sys_RoleInfo Sys_Role)
        {
            this.control.UpdateEntity(Sys_Role, Sys_Role.id);
        }
        public void Delete(int id)
        {
            Sys_RoleInfo sys_RoleInfo = new Sys_RoleInfo();
            sys_RoleInfo.id = id;
            this.control.DeleteEntity(sys_RoleInfo);
        }
        public Sys_RoleInfo GetById(int id)
        {
            return (Sys_RoleInfo)this.control.GetEntity("WC.Model.Sys_RoleInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Sys_RoleInfo", where, orderBy);
        }
    }
}
