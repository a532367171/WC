using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IFlows_Model
    {
        void Add(Flows_ModelInfo com);
        void Update(Flows_ModelInfo com);
        void Delete(int id);
        Flows_ModelInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
