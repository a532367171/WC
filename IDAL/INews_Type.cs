using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface INews_Type
    {
        void Add(News_TypeInfo com);
        void Update(News_TypeInfo com);
        void Delete(int id);
        News_TypeInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
