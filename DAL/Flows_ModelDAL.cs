using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Flows_ModelDAL : IFlows_Model
    {
        private EntityControl control;
        public Flows_ModelDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Flows_ModelInfo Flows_Model_)
        {
            this.control.AddEntity(Flows_Model_);
        }
        public void Update(Flows_ModelInfo Flows_Model_)
        {
            this.control.UpdateEntity(Flows_Model_, Flows_Model_.id);
        }
        public void Delete(int id)
        {
            Flows_ModelInfo flows_ModelInfo = new Flows_ModelInfo();
            flows_ModelInfo.id = id;
            this.control.DeleteEntity(flows_ModelInfo);
        }
        public Flows_ModelInfo GetById(int id)
        {
            return (Flows_ModelInfo)this.control.GetEntity("WC.Model.Flows_ModelInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Flows_ModelInfo", where, orderBy);
        }
    }
}
