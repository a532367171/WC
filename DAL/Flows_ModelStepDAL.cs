using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Flows_ModelStepDAL : IFlows_ModelStep
    {
        private EntityControl control;
        public Flows_ModelStepDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Flows_ModelStepInfo Flows_ModelStep_)
        {
            this.control.AddEntity(Flows_ModelStep_);
        }
        public void Update(Flows_ModelStepInfo Flows_ModelStep_)
        {
            this.control.UpdateEntity(Flows_ModelStep_, Flows_ModelStep_.id);
        }
        public void Delete(int id)
        {
            Flows_ModelStepInfo flows_ModelStepInfo = new Flows_ModelStepInfo();
            flows_ModelStepInfo.id = id;
            this.control.DeleteEntity(flows_ModelStepInfo);
        }
        public Flows_ModelStepInfo GetById(int id)
        {
            return (Flows_ModelStepInfo)this.control.GetEntity("WC.Model.Flows_ModelStepInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Flows_ModelStepInfo", where, orderBy);
        }
    }
}
