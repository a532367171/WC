using System;
namespace WC.Model
{
    [Serializable]
    public class Bas_ComInfo
    {
        private int _id;
        private string _guid;
        private string _ComName;
        private DateTime _AddTime;
        private int _MsgState;
        private string _Notes;
        private int _IsLock;
        private DateTime _StartTime;
        private DateTime _EndTime;
        private string _WebUrl;
        private string _Logo;
        private int _BBSState;
        private int _ComTypeID;
        private int _et1;
        private int _et2;
        private int _et3;
        private string _et4;
        private string _et5;
        private string _et6;
        private int _TipsState;
        private int _ValidCodeState;
        public int ComTypeID
        {
            get
            {
                return this._ComTypeID;
            }
            set
            {
                this._ComTypeID = value;
            }
        }
        public int BBSState
        {
            get
            {
                return this._BBSState;
            }
            set
            {
                this._BBSState = value;
            }
        }
        public string Logo
        {
            get
            {
                return this._Logo;
            }
            set
            {
                this._Logo = value;
            }
        }
        public string WebUrl
        {
            get
            {
                return this._WebUrl;
            }
            set
            {
                this._WebUrl = value;
            }
        }
        public int et1
        {
            get
            {
                return this._et1;
            }
            set
            {
                this._et1 = value;
            }
        }
        public int et2
        {
            get
            {
                return this._et2;
            }
            set
            {
                this._et2 = value;
            }
        }
        public int et3
        {
            get
            {
                return this._et3;
            }
            set
            {
                this._et3 = value;
            }
        }
        public string et4
        {
            get
            {
                return this._et4;
            }
            set
            {
                this._et4 = value;
            }
        }
        public string et5
        {
            get
            {
                return this._et5;
            }
            set
            {
                this._et5 = value;
            }
        }
        public string et6
        {
            get
            {
                return this._et6;
            }
            set
            {
                this._et6 = value;
            }
        }
        public int TipsState
        {
            get
            {
                return this._TipsState;
            }
            set
            {
                this._TipsState = value;
            }
        }
        public int ValidCodeState
        {
            get
            {
                return this._ValidCodeState;
            }
            set
            {
                this._ValidCodeState = value;
            }
        }
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
        public string ComName
        {
            get
            {
                return this._ComName;
            }
            set
            {
                this._ComName = value;
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
        public int MsgState
        {
            get
            {
                return this._MsgState;
            }
            set
            {
                this._MsgState = value;
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
        public int IsLock
        {
            get
            {
                return this._IsLock;
            }
            set
            {
                this._IsLock = value;
            }
        }
        public DateTime StartTime
        {
            get
            {
                return this._StartTime;
            }
            set
            {
                this._StartTime = value;
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
        public Bas_ComInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
