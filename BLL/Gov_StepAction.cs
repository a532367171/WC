using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Gov_StepAction
    {
        private static readonly IGov_StepAction dal = DALFactory.CreateGov_StepActionDAL();
        private Gov_StepAction()
        {
        }
        public static Gov_StepAction Init()
        {
            return new Gov_StepAction();
        }
        public void Add(Gov_StepActionInfo com)
        {
            Gov_StepAction.dal.Add(com);
        }
        public void Update(Gov_StepActionInfo com)
        {
            Gov_StepAction.dal.Update(com);
        }
        public void Delete(int id)
        {
            Gov_StepAction.dal.Delete(id);
        }
        public Gov_StepActionInfo GetById(int id)
        {
            return Gov_StepAction.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Gov_StepAction.dal.GetAll(where, orderBy);
        }
    }
}
