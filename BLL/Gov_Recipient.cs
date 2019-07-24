using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Gov_Recipient
    {
        private static readonly IGov_Recipient dal = DALFactory.CreateGov_RecipientDAL();
        private Gov_Recipient()
        {
        }
        public static Gov_Recipient Init()
        {
            return new Gov_Recipient();
        }
        public void Add(Gov_RecipientInfo com)
        {
            Gov_Recipient.dal.Add(com);
        }
        public void Update(Gov_RecipientInfo com)
        {
            Gov_Recipient.dal.Update(com);
        }
        public void Delete(int id)
        {
            Gov_Recipient.dal.Delete(id);
        }
        public Gov_RecipientInfo GetById(int id)
        {
            return Gov_Recipient.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Gov_Recipient.dal.GetAll(where, orderBy);
        }
    }
}
