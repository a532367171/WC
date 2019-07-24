using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Sys_DepDAL : ISys_Dep
    {
        private EntityControl control;
        public Sys_DepDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Sys_DepInfo Sys_Dep)
        {
            this.control.AddEntity(Sys_Dep);
        }
        public void Update(Sys_DepInfo Sys_Dep)
        {
            this.control.UpdateEntity(Sys_Dep, Sys_Dep.id);
        }
        public void Delete(int id)
        {
            Sys_DepInfo sys_DepInfo = new Sys_DepInfo();
            sys_DepInfo.id = id;
            this.control.DeleteEntity(sys_DepInfo);
        }
        public Sys_DepInfo GetById(int id)
        {
            return (Sys_DepInfo)this.control.GetEntity("WC.Model.Sys_DepInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Sys_DepInfo", where, orderBy);
        }
    }
}
