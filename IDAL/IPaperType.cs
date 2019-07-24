using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IPaperType
    {
        void Add(PaperTypeInfo com);
        void Update(PaperTypeInfo com);
        void Delete(int id);
        PaperTypeInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
