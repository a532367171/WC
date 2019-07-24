using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Gov_ModelDAL : IGov_Model
    {
        private EntityControl control;
        public Gov_ModelDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Gov_ModelInfo Gov_Model_)
        {
            this.control.AddEntity(Gov_Model_);
        }
        public void Update(Gov_ModelInfo Gov_Model_)
        {
            this.control.UpdateEntity(Gov_Model_, Gov_Model_.id);
        }
        public void Delete(int id)
        {
            Gov_ModelInfo gov_ModelInfo = new Gov_ModelInfo();
            gov_ModelInfo.id = id;
            this.control.DeleteEntity(gov_ModelInfo);
        }
        public Gov_ModelInfo GetById(int id)
        {
            return (Gov_ModelInfo)this.control.GetEntity("WC.Model.Gov_ModelInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Gov_ModelInfo", where, orderBy);
        }
    }
}
