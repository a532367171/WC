using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Bas_Com
    {
        private static readonly IBas_Com dal = DALFactory.CreateBas_ComDAL();
        private Bas_Com()
        {
        }
        public static Bas_Com Init()
        {
            return new Bas_Com();
        }
        public void Add(Bas_ComInfo com)
        {
            Bas_Com.dal.Add(com);
        }
        public void Update(Bas_ComInfo com)
        {
            Bas_Com.dal.Update(com);
        }
        public void Delete(int id)
        {
            Bas_Com.dal.Delete(id);
        }
        public Bas_ComInfo GetById(int id)
        {
            return Bas_Com.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Bas_Com.dal.GetAll(where, orderBy);
        }
    }
}
