using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Flows
    {
        private static readonly IFlows dal = DALFactory.CreateFlowsDAL();
        private Flows()
        {
        }
        public static Flows Init()
        {
            return new Flows();
        }
        public void Add(FlowsInfo com)
        {
            Flows.dal.Add(com);
        }
        public void Update(FlowsInfo com)
        {
            Flows.dal.Update(com);
        }
        public void Delete(int id)
        {
            Flows.dal.Delete(id);
        }
        public FlowsInfo GetById(int id)
        {
            return Flows.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Flows.dal.GetAll(where, orderBy);
        }
    }
}
