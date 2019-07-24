using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class News_Type
    {
        private static readonly INews_Type dal = DALFactory.CreateNews_TypeDAL();
        private News_Type()
        {
        }
        public static News_Type Init()
        {
            return new News_Type();
        }
        public void Add(News_TypeInfo com)
        {
            News_Type.dal.Add(com);
        }
        public void Update(News_TypeInfo com)
        {
            News_Type.dal.Update(com);
        }
        public void Delete(int id)
        {
            News_Type.dal.Delete(id);
        }
        public News_TypeInfo GetById(int id)
        {
            return News_Type.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return News_Type.dal.GetAll(where, orderBy);
        }
    }
}
