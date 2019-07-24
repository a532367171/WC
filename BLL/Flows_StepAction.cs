using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Flows_StepAction
    {
        private static readonly IFlows_StepAction dal = DALFactory.CreateFlows_StepActionDAL();
        private Flows_StepAction()
        {
        }
        public static Flows_StepAction Init()
        {
            return new Flows_StepAction();
        }
        public void Add(Flows_StepActionInfo com)
        {
            Flows_StepAction.dal.Add(com);
        }
        public void Update(Flows_StepActionInfo com)
        {
            Flows_StepAction.dal.Update(com);
        }
        public void Delete(int id)
        {
            Flows_StepAction.dal.Delete(id);
        }
        public Flows_StepActionInfo GetById(int id)
        {
            return Flows_StepAction.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Flows_StepAction.dal.GetAll(where, orderBy);
        }
    }
}
