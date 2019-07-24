using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class MeetingDAL : IMeeting
    {
        private EntityControl control;
        public MeetingDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(MeetingInfo Meeting_)
        {
            this.control.AddEntity(Meeting_);
        }
        public void Update(MeetingInfo Meeting_)
        {
            this.control.UpdateEntity(Meeting_, Meeting_.id);
        }
        public void Delete(int id)
        {
            MeetingInfo meetingInfo = new MeetingInfo();
            meetingInfo.id = id;
            this.control.DeleteEntity(meetingInfo);
        }
        public MeetingInfo GetById(int id)
        {
            return (MeetingInfo)this.control.GetEntity("WC.Model.MeetingInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.MeetingInfo", where, orderBy);
        }
    }
}
