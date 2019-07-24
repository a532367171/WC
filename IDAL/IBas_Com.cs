using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IBas_Com
    {
        void Add(Bas_ComInfo com);
        void Update(Bas_ComInfo com);
        void Delete(int id);
        Bas_ComInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
