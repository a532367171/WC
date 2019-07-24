using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IWorkLog
    {
        void Add(WorkLogInfo com);
        void Update(WorkLogInfo com);
        void Delete(int id);
        WorkLogInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
