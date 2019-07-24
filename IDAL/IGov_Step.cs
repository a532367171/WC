using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IGov_Step
    {
        void Add(Gov_StepInfo com);
        void Update(Gov_StepInfo com);
        void Delete(int id);
        Gov_StepInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
