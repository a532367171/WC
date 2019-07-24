using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IFlows_Step
    {
        void Add(Flows_StepInfo com);
        void Update(Flows_StepInfo com);
        void Delete(int id);
        Flows_StepInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}