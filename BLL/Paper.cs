using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Paper
    {
        private static readonly IPaper dal = DALFactory.CreatePaperDAL();
        private Paper()
        {
        }
        public static Paper Init()
        {
            return new Paper();
        }
        public void Add(PaperInfo com)
        {
            Paper.dal.Add(com);
        }
        public void Update(PaperInfo com)
        {
            Paper.dal.Update(com);
        }
        public void Delete(int id)
        {
            Paper.dal.Delete(id);
        }
        public PaperInfo GetById(int id)
        {
            return Paper.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Paper.dal.GetAll(where, orderBy);
        }
    }
}
