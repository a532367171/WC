using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class ZEX2
    {
        private static readonly IZEX2 dal = DALFactory.CreateZEX2DAL();
        private ZEX2()
        {
        }
        public static ZEX2 Init()
        {
            return new ZEX2();
        }
        public void Add(ZEX2Info com)
        {
            ZEX2.dal.Add(com);
        }
        public void Update(ZEX2Info com)
        {
            ZEX2.dal.Update(com);
        }
        public void Delete(int id)
        {
            ZEX2.dal.Delete(id);
        }
        public ZEX2Info GetById(int id)
        {
            return ZEX2.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return ZEX2.dal.GetAll(where, orderBy);
        }
    }
}
