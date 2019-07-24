using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Gov_ModelStep
    {
        private static readonly IGov_ModelStep dal = DALFactory.CreateGov_ModelStepDAL();
        private Gov_ModelStep()
        {
        }
        public static Gov_ModelStep Init()
        {
            return new Gov_ModelStep();
        }
        public void Add(Gov_ModelStepInfo com)
        {
            Gov_ModelStep.dal.Add(com);
        }
        public void Update(Gov_ModelStepInfo com)
        {
            Gov_ModelStep.dal.Update(com);
        }
        public void Delete(int id)
        {
            Gov_ModelStep.dal.Delete(id);
        }
        public Gov_ModelStepInfo GetById(int id)
        {
            return Gov_ModelStep.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Gov_ModelStep.dal.GetAll(where, orderBy);
        }
    }
}
