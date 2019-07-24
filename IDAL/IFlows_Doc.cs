using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IFlows_Doc
    {
        void Add(Flows_DocInfo com);
        void Update(Flows_DocInfo com);
        void Delete(int id);
        Flows_DocInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
