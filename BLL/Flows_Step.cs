using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Flows_Step
    {
        private static readonly IFlows_Step dal = DALFactory.CreateFlows_StepDAL();
        private Flows_Step()
        {
        }
        public static Flows_Step Init()
        {
            return new Flows_Step();
        }
        public void Add(Flows_StepInfo com)
        {
            Flows_Step.dal.Add(com);
        }
        public void Update(Flows_StepInfo com)
        {
            Flows_Step.dal.Update(com);
        }
        public void Delete(int id)
        {
            Flows_Step.dal.Delete(id);
        }
        public Flows_StepInfo GetById(int id)
        {
            return Flows_Step.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Flows_Step.dal.GetAll(where, orderBy);
        }
    }
}
