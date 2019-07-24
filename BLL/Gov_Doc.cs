using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Gov_Doc
    {
        private static readonly IGov_Doc dal = DALFactory.CreateGov_DocDAL();
        private Gov_Doc()
        {
        }
        public static Gov_Doc Init()
        {
            return new Gov_Doc();
        }
        public void Add(Gov_DocInfo com)
        {
            Gov_Doc.dal.Add(com);
        }
        public void Update(Gov_DocInfo com)
        {
            Gov_Doc.dal.Update(com);
        }
        public void Delete(int id)
        {
            Gov_Doc.dal.Delete(id);
        }
        public Gov_DocInfo GetById(int id)
        {
            return Gov_Doc.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Gov_Doc.dal.GetAll(where, orderBy);
        }
    }
}
