using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Gov_Model_Type
    {
        private static readonly IGov_Model_Type dal = DALFactory.CreateGov_Model_TypeDAL();
        private Gov_Model_Type()
        {
        }
        public static Gov_Model_Type Init()
        {
            return new Gov_Model_Type();
        }
        public void Add(Gov_Model_TypeInfo com)
        {
            Gov_Model_Type.dal.Add(com);
        }
        public void Update(Gov_Model_TypeInfo com)
        {
            Gov_Model_Type.dal.Update(com);
        }
        public void Delete(int id)
        {
            Gov_Model_Type.dal.Delete(id);
        }
        public Gov_Model_TypeInfo GetById(int id)
        {
            return Gov_Model_Type.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Gov_Model_Type.dal.GetAll(where, orderBy);
        }
    }
}
