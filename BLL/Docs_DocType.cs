using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Docs_DocType
    {
        private static readonly IDocs_DocType dal = DALFactory.CreateDocs_DocTypeDAL();
        private Docs_DocType()
        {
        }
        public static Docs_DocType Init()
        {
            return new Docs_DocType();
        }
        public void Add(Docs_DocTypeInfo com)
        {
            Docs_DocType.dal.Add(com);
        }
        public void Update(Docs_DocTypeInfo com)
        {
            Docs_DocType.dal.Update(com);
        }
        public void Delete(int id)
        {
            Docs_DocType.dal.Delete(id);
        }
        public Docs_DocTypeInfo GetById(int id)
        {
            return Docs_DocType.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Docs_DocType.dal.GetAll(where, orderBy);
        }
    }
}
