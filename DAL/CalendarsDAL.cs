using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class CalendarsDAL : ICalendarMemo_Calendars
    {
        private EntityControl control;
        public CalendarsDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Calendars Calendar_)
        {
            this.control.AddEntity(Calendar_);
        }
        public void Update(Calendars Calendar_)
        {
            this.control.UpdateEntity(Calendar_, Calendar_.ID);
        }
        public void Delete(int id)
        {
            Calendars Calendar = new Calendars();
            Calendar.ID = id;
            this.control.DeleteEntity(Calendar);
        }
        public Calendars GetById(int id)
        {
            return (Calendars)this.control.GetEntity("WC.Model.Calendar", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Calendar", where, orderBy);
        }
    }
}
