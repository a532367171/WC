using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Mails_Detail
    {
        private static readonly IMails_Detail dal = DALFactory.CreateMails_DetailDAL();
        private Mails_Detail()
        {
        }
        public static Mails_Detail Init()
        {
            return new Mails_Detail();
        }
        public void Add(Mails_DetailInfo com)
        {
            Mails_Detail.dal.Add(com);
        }
        public void Update(Mails_DetailInfo com)
        {
            Mails_Detail.dal.Update(com);
        }
        public void Delete(int id)
        {
            Mails_Detail.dal.Delete(id);
        }
        public Mails_DetailInfo GetById(int id)
        {
            return Mails_Detail.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Mails_Detail.dal.GetAll(where, orderBy);
        }
    }
}
