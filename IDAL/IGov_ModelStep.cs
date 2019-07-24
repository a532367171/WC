using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IGov_ModelStep
    {
        void Add(Gov_ModelStepInfo com);
        void Update(Gov_ModelStepInfo com);
        void Delete(int id);
        Gov_ModelStepInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
