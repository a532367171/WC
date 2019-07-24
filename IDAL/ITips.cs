using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface ITips
    {
        void Add(TipsInfo com);
        void Update(TipsInfo com);
        void Delete(int id);
        TipsInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
