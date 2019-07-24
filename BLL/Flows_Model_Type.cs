using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Flows_Model_Type
    {
        private static readonly IFlows_Model_Type dal = DALFactory.CreateFlows_Model_TypeDAL();
        private Flows_Model_Type()
        {
        }
        public static Flows_Model_Type Init()
        {
            return new Flows_Model_Type();
        }
        public void Add(Flows_Model_TypeInfo com)
        {
            Flows_Model_Type.dal.Add(com);
        }
        public void Update(Flows_Model_TypeInfo com)
        {
            Flows_Model_Type.dal.Update(com);
        }
        public void Delete(int id)
        {
            Flows_Model_Type.dal.Delete(id);
        }
        public Flows_Model_TypeInfo GetById(int id)
        {
            return Flows_Model_Type.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Flows_Model_Type.dal.GetAll(where, orderBy);
        }
    }
}
