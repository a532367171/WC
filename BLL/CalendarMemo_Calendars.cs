using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class CalendarMemo_Calendars
    {
        private static readonly ICalendarMemo_Calendars dal = DALFactory.CreateCalendarMemo_CalendarsDAL();
        private CalendarMemo_Calendars()
        {
        }
        public static CalendarMemo_Calendars Init()
        {
            return new CalendarMemo_Calendars();
        }
        public void Add(Calendars com)
        {
            CalendarMemo_Calendars.dal.Add(com);
        }
        public void Update(Calendars com)
        {
            CalendarMemo_Calendars.dal.Update(com);
        }
        public void Delete(int id)
        {
            CalendarMemo_Calendars.dal.Delete(id);
        }
        public Calendars GetById(int id)
        {
            return CalendarMemo_Calendars.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return CalendarMemo_Calendars.dal.GetAll(where, orderBy);
        }
    }
}
