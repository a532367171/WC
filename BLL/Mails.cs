using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Mails
    {
        private static readonly IMails dal = DALFactory.CreateMailsDAL();
        private Mails()
        {
        }
        public static Mails Init()
        {
            return new Mails();
        }
        public void Add(MailsInfo com)
        {
            Mails.dal.Add(com);
        }
        public void Update(MailsInfo com)
        {
            Mails.dal.Update(com);
        }
        public void Delete(int id)
        {
            Mails.dal.Delete(id);
        }
        public MailsInfo GetById(int id)
        {
            return Mails.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Mails.dal.GetAll(where, orderBy);
        }
    }
}
