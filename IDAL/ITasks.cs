using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface ITasks
    {
        void Add(TasksInfo com);
        void Update(TasksInfo com);
        void Delete(int id);
        TasksInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
