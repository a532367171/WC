using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Flows_Doc
    {
        private static readonly IFlows_Doc dal = DALFactory.CreateFlows_DocDAL();
        private Flows_Doc()
        {
        }
        public static Flows_Doc Init()
        {
            return new Flows_Doc();
        }
        public void Add(Flows_DocInfo com)
        {
            Flows_Doc.dal.Add(com);
        }
        public void Update(Flows_DocInfo com)
        {
            Flows_Doc.dal.Update(com);
        }
        public void Delete(int id)
        {
            Flows_Doc.dal.Delete(id);
        }
        public Flows_DocInfo GetById(int id)
        {
            return Flows_Doc.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Flows_Doc.dal.GetAll(where, orderBy);
        }
    }
}
