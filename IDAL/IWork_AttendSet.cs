using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IWork_AttendSet
    {
        void Add(Work_AttendSetInfo com);
        void Update(Work_AttendSetInfo com);
        void Delete(int id);
        Work_AttendSetInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
