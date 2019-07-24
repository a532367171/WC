using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IGov_Model_Type
    {
        void Add(Gov_Model_TypeInfo com);
        void Update(Gov_Model_TypeInfo com);
        void Delete(int id);
        Gov_Model_TypeInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
