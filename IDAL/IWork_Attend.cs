using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IWork_Attend
    {
        void Add(Work_AttendInfo com);
        void Update(Work_AttendInfo com);
        void Delete(int id);
        Work_AttendInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
