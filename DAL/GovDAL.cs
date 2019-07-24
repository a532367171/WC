using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class GovDAL : IGov
    {
        private EntityControl control;
        public GovDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(GovInfo Gov_)
        {
            this.control.AddEntity(Gov_);
        }
        public void Update(GovInfo Gov_)
        {
            this.control.UpdateEntity(Gov_, Gov_.id);
        }
        public void Delete(int id)
        {
            GovInfo govInfo = new GovInfo();
            govInfo.id = id;
            this.control.DeleteEntity(govInfo);
        }
        public GovInfo GetById(int id)
        {
            return (GovInfo)this.control.GetEntity("WC.Model.GovInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.GovInfo", where, orderBy);
        }
    }
}
