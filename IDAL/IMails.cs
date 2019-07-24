using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IMails
    {
        void Add(MailsInfo com);
        void Update(MailsInfo com);
        void Delete(int id);
        MailsInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
