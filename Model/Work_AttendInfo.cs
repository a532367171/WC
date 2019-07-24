using System;
namespace WC.Model
{
    [Serializable]
    public class Work_AttendInfo
    {
        private int _id;
        private string _guid;
        private int _UID;
        private int _DepID;
        private string _RealName;
        private string _DepName;
        private int _AttendType;
        private int _AttendTimeID;
        private string _StandardTimes;
        private string _StandardNames;
        private string _SignTimes;
        private string _SignDates;
        private string _SignJudge;
        private DateTime _BeginTime;
        private string _B1;
        private string _B2;
        private DateTime _EndTime;
        private string _E1;
        private string _E2;
        private string _TravelAddress;
        private string _Notes;
        private DateTime _AddTime;
        public int id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        public string guid
        {
            get
            {
                return this._guid;
            }
            set
            {
                this._guid = value;
            }
        }
        public int UID
        {
            get
            {
                return this._UID;
            }
            set
            {
                this._UID = value;
            }
        }
        public int DepID
        {
            get
            {
                return this._DepID;
            }
            set
            {
                this._DepID = value;
            }
        }
        public string RealName
        {
            get
            {
                return this._RealName;
            }
            set
            {
                this._RealName = value;
            }
        }
        public string DepName
        {
            get
            {
                return this._DepName;
            }
            set
            {
                this._DepName = value;
            }
        }
        public int AttendType
        {
            get
            {
                return this._AttendType;
            }
            set
            {
                this._AttendType = value;
            }
        }
        public int AttendTimeID
        {
            get
            {
                return this._AttendTimeID;
            }
            set
            {
                this._AttendTimeID = value;
            }
        }
        public string StandardTimes
        {
            get
            {
                return this._StandardTimes;
            }
            set
            {
                this._StandardTimes = value;
            }
        }
        public string StandardNames
        {
            get
            {
                return this._StandardNames;
            }
            set
            {
                this._StandardNames = value;
            }
        }
        public string SignTimes
        {
            get
            {
                return this._SignTimes;
            }
            set
            {
                this._SignTimes = value;
            }
        }
        public string SignDates
        {
            get
            {
                return this._SignDates;
            }
            set
            {
                this._SignDates = value;
            }
        }
        public string SignJudge
        {
            get
            {
                return this._SignJudge;
            }
            set
            {
                this._SignJudge = value;
            }
        }
        public DateTime BeginTime
        {
            get
            {
                return this._BeginTime;
            }
            set
            {
                this._BeginTime = value;
            }
        }
        public string B1
        {
            get
            {
                return this._B1;
            }
            set
            {
                this._B1 = value;
            }
        }
        public string B2
        {
            get
            {
                return this._B2;
            }
            set
            {
                this._B2 = value;
            }
        }
        public DateTime EndTime
        {
            get
            {
                return this._EndTime;
            }
            set
            {
                this._EndTime = value;
            }
        }
        public string E1
        {
            get
            {
                return this._E1;
            }
            set
            {
                this._E1 = value;
            }
        }
        public string E2
        {
            get
            {
                return this._E2;
            }
            set
            {
                this._E2 = value;
            }
        }
        public string TravelAddress
        {
            get
            {
                return this._TravelAddress;
            }
            set
            {
                this._TravelAddress = value;
            }
        }
        public string Notes
        {
            get
            {
                return this._Notes;
            }
            set
            {
                this._Notes = value;
            }
        }
        public DateTime AddTime
        {
            get
            {
                return this._AddTime;
            }
            set
            {
                this._AddTime = value;
            }
        }
        public Work_AttendInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
