using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Gov_StepDAL : IGov_Step
    {
        private EntityControl control;
        public Gov_StepDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Gov_StepInfo Gov_Step_)
        {
            this.control.AddEntity(Gov_Step_);
        }
        public void Update(Gov_StepInfo Gov_Step_)
        {
            this.control.UpdateEntity(Gov_Step_, Gov_Step_.id);
        }
        public void Delete(int id)
        {
            Gov_StepInfo gov_StepInfo = new Gov_StepInfo();
            gov_StepInfo.id = id;
            this.control.DeleteEntity(gov_StepInfo);
        }
        public Gov_StepInfo GetById(int id)
        {
            return (Gov_StepInfo)this.control.GetEntity("WC.Model.Gov_StepInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Gov_StepInfo", where, orderBy);
        }
    }
}
