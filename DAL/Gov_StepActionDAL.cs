using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Gov_StepActionDAL : IGov_StepAction
    {
        private EntityControl control;
        public Gov_StepActionDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Gov_StepActionInfo Gov_StepAction_)
        {
            this.control.AddEntity(Gov_StepAction_);
        }
        public void Update(Gov_StepActionInfo Gov_StepAction_)
        {
            this.control.UpdateEntity(Gov_StepAction_, Gov_StepAction_.id);
        }
        public void Delete(int id)
        {
            Gov_StepActionInfo gov_StepActionInfo = new Gov_StepActionInfo();
            gov_StepActionInfo.id = id;
            this.control.DeleteEntity(gov_StepActionInfo);
        }
        public Gov_StepActionInfo GetById(int id)
        {
            return (Gov_StepActionInfo)this.control.GetEntity("WC.Model.Gov_StepActionInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Gov_StepActionInfo", where, orderBy);
        }
    }
}
