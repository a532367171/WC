using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IGov
    {
        void Add(GovInfo com);
        void Update(GovInfo com);
        void Delete(int id);
        GovInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
