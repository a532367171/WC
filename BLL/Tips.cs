using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Tips
    {
        private static readonly ITips dal = DALFactory.CreateTipsDAL();
        private Tips()
        {
        }
        public static Tips Init()
        {
            return new Tips();
        }
        public void Add(TipsInfo com)
        {
            Tips.dal.Add(com);
        }
        public void Update(TipsInfo com)
        {
            Tips.dal.Update(com);
        }
        public void Delete(int id)
        {
            Tips.dal.Delete(id);
        }
        public TipsInfo GetById(int id)
        {
            return Tips.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Tips.dal.GetAll(where, orderBy);
        }
    }
}
