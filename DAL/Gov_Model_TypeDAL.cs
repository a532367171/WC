using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Gov_Model_TypeDAL : IGov_Model_Type
    {
        private EntityControl control;
        public Gov_Model_TypeDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Gov_Model_TypeInfo Gov_Model_Type_)
        {
            this.control.AddEntity(Gov_Model_Type_);
        }
        public void Update(Gov_Model_TypeInfo Gov_Model_Type_)
        {
            this.control.UpdateEntity(Gov_Model_Type_, Gov_Model_Type_.id);
        }
        public void Delete(int id)
        {
            Gov_Model_TypeInfo gov_Model_TypeInfo = new Gov_Model_TypeInfo();
            gov_Model_TypeInfo.id = id;
            this.control.DeleteEntity(gov_Model_TypeInfo);
        }
        public Gov_Model_TypeInfo GetById(int id)
        {
            return (Gov_Model_TypeInfo)this.control.GetEntity("WC.Model.Gov_Model_TypeInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Gov_Model_TypeInfo", where, orderBy);
        }
    }
}
