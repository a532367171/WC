using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Gov_Model
    {
        private static readonly IGov_Model dal = DALFactory.CreateGov_ModelDAL();
        private Gov_Model()
        {
        }
        public static Gov_Model Init()
        {
            return new Gov_Model();
        }
        public void Add(Gov_ModelInfo com)
        {
            Gov_Model.dal.Add(com);
        }
        public void Update(Gov_ModelInfo com)
        {
            Gov_Model.dal.Update(com);
        }
        public void Delete(int id)
        {
            Gov_Model.dal.Delete(id);
        }
        public Gov_ModelInfo GetById(int id)
        {
            return Gov_Model.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Gov_Model.dal.GetAll(where, orderBy);
        }
    }
}
