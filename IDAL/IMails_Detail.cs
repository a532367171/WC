using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IMails_Detail
    {
        void Add(Mails_DetailInfo com);
        void Update(Mails_DetailInfo com);
        void Delete(int id);
        Mails_DetailInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
