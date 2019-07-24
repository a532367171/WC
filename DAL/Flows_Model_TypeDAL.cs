using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Flows_Model_TypeDAL : IFlows_Model_Type
    {
        private EntityControl control;
        public Flows_Model_TypeDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Flows_Model_TypeInfo Flows_Model_Type_)
        {
            this.control.AddEntity(Flows_Model_Type_);
        }
        public void Update(Flows_Model_TypeInfo Flows_Model_Type_)
        {
            this.control.UpdateEntity(Flows_Model_Type_, Flows_Model_Type_.id);
        }
        public void Delete(int id)
        {
            Flows_Model_TypeInfo flows_Model_TypeInfo = new Flows_Model_TypeInfo();
            flows_Model_TypeInfo.id = id;
            this.control.DeleteEntity(flows_Model_TypeInfo);
        }
        public Flows_Model_TypeInfo GetById(int id)
        {
            return (Flows_Model_TypeInfo)this.control.GetEntity("WC.Model.Flows_Model_TypeInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Flows_Model_TypeInfo", where, orderBy);
        }
    }
}
