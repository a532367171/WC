using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IFlows_Model_Type
    {
        void Add(Flows_Model_TypeInfo com);
        void Update(Flows_Model_TypeInfo com);
        void Delete(int id);
        Flows_Model_TypeInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}