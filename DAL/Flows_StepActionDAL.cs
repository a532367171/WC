using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Flows_StepActionDAL : IFlows_StepAction
    {
        private EntityControl control;
        public Flows_StepActionDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Flows_StepActionInfo Flows_StepAction_)
        {
            this.control.AddEntity(Flows_StepAction_);
        }
        public void Update(Flows_StepActionInfo Flows_StepAction_)
        {
            this.control.UpdateEntity(Flows_StepAction_, Flows_StepAction_.id);
        }
        public void Delete(int id)
        {
            Flows_StepActionInfo flows_StepActionInfo = new Flows_StepActionInfo();
            flows_StepActionInfo.id = id;
            this.control.DeleteEntity(flows_StepActionInfo);
        }
        public Flows_StepActionInfo GetById(int id)
        {
            return (Flows_StepActionInfo)this.control.GetEntity("WC.Model.Flows_StepActionInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Flows_StepActionInfo", where, orderBy);
        }
    }
}
