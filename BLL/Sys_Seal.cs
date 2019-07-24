using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Sys_Seal
    {
        private static readonly ISys_Seal dal = DALFactory.CreateSys_SealDAL();
        private Sys_Seal()
        {
        }
        public static Sys_Seal Init()
        {
            return new Sys_Seal();
        }
        public void Add(Sys_SealInfo com)
        {
            Sys_Seal.dal.Add(com);
        }
        public void Update(Sys_SealInfo com)
        {
            Sys_Seal.dal.Update(com);
        }
        public void Delete(int id)
        {
            Sys_Seal.dal.Delete(id);
        }
        public Sys_SealInfo GetById(int id)
        {
            return Sys_Seal.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Sys_Seal.dal.GetAll(where, orderBy);
        }
    }
}
