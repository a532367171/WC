using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IZEX2
    {
        void Add(ZEX2Info com);
        void Update(ZEX2Info com);
        void Delete(int id);
        ZEX2Info GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
