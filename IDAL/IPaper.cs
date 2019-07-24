using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IPaper
    {
        void Add(PaperInfo com);
        void Update(PaperInfo com);
        void Delete(int id);
        PaperInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
