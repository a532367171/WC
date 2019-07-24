using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Docs_Doc
    {
        private static readonly IDocs_Doc dal = DALFactory.CreateDocs_DocDAL();
        private Docs_Doc()
        {
        }
        public static Docs_Doc Init()
        {
            return new Docs_Doc();
        }
        public void Add(Docs_DocInfo com)
        {
            Docs_Doc.dal.Add(com);
        }
        public void Update(Docs_DocInfo com)
        {
            Docs_Doc.dal.Update(com);
        }
        public void Delete(int id)
        {
            Docs_Doc.dal.Delete(id);
        }
        public Docs_DocInfo GetById(int id)
        {
            return Docs_Doc.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Docs_Doc.dal.GetAll(where, orderBy);
        }
    }
}
