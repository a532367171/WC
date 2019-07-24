using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Flows_ModelStep
    {
        private static readonly IFlows_ModelStep dal = DALFactory.CreateFlows_ModelStepDAL();
        private Flows_ModelStep()
        {
        }
        public static Flows_ModelStep Init()
        {
            return new Flows_ModelStep();
        }
        public void Add(Flows_ModelStepInfo com)
        {
            Flows_ModelStep.dal.Add(com);
        }
        public void Update(Flows_ModelStepInfo com)
        {
            Flows_ModelStep.dal.Update(com);
        }
        public void Delete(int id)
        {
            Flows_ModelStep.dal.Delete(id);
        }
        public Flows_ModelStepInfo GetById(int id)
        {
            return Flows_ModelStep.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Flows_ModelStep.dal.GetAll(where, orderBy);
        }
    }
}
