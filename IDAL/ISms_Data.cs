using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface ISms_Data
    {
        void Add(Sms_DataInfo com);
        void Update(Sms_DataInfo com);
        void Delete(int id);
        Sms_DataInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
