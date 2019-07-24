using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IGov_StepAction
    {
        void Add(Gov_StepActionInfo com);
        void Update(Gov_StepActionInfo com);
        void Delete(int id);
        Gov_StepActionInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
