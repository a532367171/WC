using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IPhoneBook
    {
        void Add(PhoneBookInfo com);
        void Update(PhoneBookInfo com);
        void Delete(int id);
        PhoneBookInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
