using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Sys_SealDAL : ISys_Seal
    {
        private EntityControl control;
        public Sys_SealDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Sys_SealInfo Sys_Seal_)
        {
            this.control.AddEntity(Sys_Seal_);
        }
        public void Update(Sys_SealInfo Sys_Seal_)
        {
            this.control.UpdateEntity(Sys_Seal_, Sys_Seal_.id);
        }
        public void Delete(int id)
        {
            Sys_SealInfo sys_SealInfo = new Sys_SealInfo();
            sys_SealInfo.id = id;
            this.control.DeleteEntity(sys_SealInfo);
        }
        public Sys_SealInfo GetById(int id)
        {
            return (Sys_SealInfo)this.control.GetEntity("WC.Model.Sys_SealInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Sys_SealInfo", where, orderBy);
        }
    }
}
