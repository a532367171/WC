using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Sms_Data
    {
        private static readonly ISms_Data dal = DALFactory.CreateSms_DataDAL();
        private Sms_Data()
        {
        }
        public static Sms_Data Init()
        {
            return new Sms_Data();
        }
        public void Add(Sms_DataInfo com)
        {
            Sms_Data.dal.Add(com);
        }
        public void Update(Sms_DataInfo com)
        {
            Sms_Data.dal.Update(com);
        }
        public void Delete(int id)
        {
            Sms_Data.dal.Delete(id);
        }
        public Sms_DataInfo GetById(int id)
        {
            return Sms_Data.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Sms_Data.dal.GetAll(where, orderBy);
        }
    }
}
