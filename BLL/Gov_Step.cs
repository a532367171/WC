using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Gov_Step
    {
        private static readonly IGov_Step dal = DALFactory.CreateGov_StepDAL();
        private Gov_Step()
        {
        }
        public static Gov_Step Init()
        {
            return new Gov_Step();
        }
        public void Add(Gov_StepInfo com)
        {
            Gov_Step.dal.Add(com);
        }
        public void Update(Gov_StepInfo com)
        {
            Gov_Step.dal.Update(com);
        }
        public void Delete(int id)
        {
            Gov_Step.dal.Delete(id);
        }
        public Gov_StepInfo GetById(int id)
        {
            return Gov_Step.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Gov_Step.dal.GetAll(where, orderBy);
        }
    }
}
