using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Gov_ModelStepDAL : IGov_ModelStep
    {
        private EntityControl control;
        public Gov_ModelStepDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Gov_ModelStepInfo Gov_ModelStep_)
        {
            this.control.AddEntity(Gov_ModelStep_);
        }
        public void Update(Gov_ModelStepInfo Gov_ModelStep_)
        {
            this.control.UpdateEntity(Gov_ModelStep_, Gov_ModelStep_.id);
        }
        public void Delete(int id)
        {
            Gov_ModelStepInfo gov_ModelStepInfo = new Gov_ModelStepInfo();
            gov_ModelStepInfo.id = id;
            this.control.DeleteEntity(gov_ModelStepInfo);
        }
        public Gov_ModelStepInfo GetById(int id)
        {
            return (Gov_ModelStepInfo)this.control.GetEntity("WC.Model.Gov_ModelStepInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Gov_ModelStepInfo", where, orderBy);
        }
    }
}
