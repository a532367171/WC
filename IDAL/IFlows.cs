using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IFlows
    {
        void Add(FlowsInfo com);
        void Update(FlowsInfo com);
        void Delete(int id);
        FlowsInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
