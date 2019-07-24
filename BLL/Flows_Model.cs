using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Flows_Model
    {
        private static readonly IFlows_Model dal = DALFactory.CreateFlows_ModelDAL();
        private Flows_Model()
        {
        }
        public static Flows_Model Init()
        {
            return new Flows_Model();
        }
        public void Add(Flows_ModelInfo com)
        {
            Flows_Model.dal.Add(com);
        }
        public void Update(Flows_ModelInfo com)
        {
            Flows_Model.dal.Update(com);
        }
        public void Delete(int id)
        {
            Flows_Model.dal.Delete(id);
        }
        public Flows_ModelInfo GetById(int id)
        {
            return Flows_Model.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Flows_Model.dal.GetAll(where, orderBy);
        }
    }
}
