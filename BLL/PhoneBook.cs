using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class PhoneBook
    {
        private static readonly IPhoneBook dal = DALFactory.CreatePhoneBookDAL();
        private PhoneBook()
        {
        }
        public static PhoneBook Init()
        {
            return new PhoneBook();
        }
        public void Add(PhoneBookInfo com)
        {
            PhoneBook.dal.Add(com);
        }
        public void Update(PhoneBookInfo com)
        {
            PhoneBook.dal.Update(com);
        }
        public void Delete(int id)
        {
            PhoneBook.dal.Delete(id);
        }
        public PhoneBookInfo GetById(int id)
        {
            return PhoneBook.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return PhoneBook.dal.GetAll(where, orderBy);
        }
    }
}
