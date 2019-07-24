using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class PaperType
    {
        private static readonly IPaperType dal = DALFactory.CreatePaperTypeDAL();
        private PaperType()
        {
        }
        public static PaperType Init()
        {
            return new PaperType();
        }
        public void Add(PaperTypeInfo com)
        {
            PaperType.dal.Add(com);
        }
        public void Update(PaperTypeInfo com)
        {
            PaperType.dal.Update(com);
        }
        public void Delete(int id)
        {
            PaperType.dal.Delete(id);
        }
        public PaperTypeInfo GetById(int id)
        {
            return PaperType.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return PaperType.dal.GetAll(where, orderBy);
        }
    }
}
