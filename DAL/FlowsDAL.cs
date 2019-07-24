using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class FlowsDAL : IFlows
    {
        private EntityControl control;
        public FlowsDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(FlowsInfo Flows_)
        {
            this.control.AddEntity(Flows_);
        }
        public void Update(FlowsInfo Flows_)
        {
            this.control.UpdateEntity(Flows_, Flows_.id);
        }
        public void Delete(int id)
        {
            FlowsInfo flowsInfo = new FlowsInfo();
            flowsInfo.id = id;
            this.control.DeleteEntity(flowsInfo);
        }
        public FlowsInfo GetById(int id)
        {
            return (FlowsInfo)this.control.GetEntity("WC.Model.FlowsInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.FlowsInfo", where, orderBy);
        }
    }
}
