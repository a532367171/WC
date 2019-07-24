using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Meeting
    {
        private static readonly IMeeting dal = DALFactory.CreateMeetingDAL();
        private Meeting()
        {
        }
        public static Meeting Init()
        {
            return new Meeting();
        }
        public void Add(MeetingInfo com)
        {
            Meeting.dal.Add(com);
        }
        public void Update(MeetingInfo com)
        {
            Meeting.dal.Update(com);
        }
        public void Delete(int id)
        {
            Meeting.dal.Delete(id);
        }
        public MeetingInfo GetById(int id)
        {
            return Meeting.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Meeting.dal.GetAll(where, orderBy);
        }
    }
}
