using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface ICalendarMemo_Calendars
    {
        void Add(Calendars  com);
        void Update(Calendars com);
        void Delete(int id);
        Calendars GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
