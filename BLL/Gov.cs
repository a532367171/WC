using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Gov
    {
        private static readonly IGov dal = DALFactory.CreateGovDAL();
        private Gov()
        {
        }
        public static Gov Init()
        {
            return new Gov();
        }
        public void Add(GovInfo com)
        {
            Gov.dal.Add(com);
        }
        public void Update(GovInfo com)
        {
            Gov.dal.Update(com);
        }
        public void Delete(int id)
        {
            Gov.dal.Delete(id);
        }
        public GovInfo GetById(int id)
        {
            return Gov.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Gov.dal.GetAll(where, orderBy);
        }
    }
}
