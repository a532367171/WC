using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IMeeting
    {
        void Add(MeetingInfo com);
        void Update(MeetingInfo com);
        void Delete(int id);
        MeetingInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
