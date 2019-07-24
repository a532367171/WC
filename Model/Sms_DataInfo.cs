using System;
namespace WC.Model
{
    [Serializable]
    public class Sms_DataInfo
    {
        private int _id;
        private string _guid;
        private int _UserID;
        private string _RealName;
        private string _DepName;
        private string _Subject;
        private string _PhoneList;
        private int _IsLongMessage;
        private string _AddTime;
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
        public int UserID
        {
            get
            {
                return this._UserID;
            }
            set
            {
                this._UserID = value;
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
        public string Subject
        {
            get
            {
                return this._Subject;
            }
            set
            {
                this._Subject = value;
            }
        }
        public string PhoneList
        {
            get
            {
                return this._PhoneList;
            }
            set
            {
                this._PhoneList = value;
            }
        }
        public int IsLongMessage
        {
            get
            {
                return this._IsLongMessage;
            }
            set
            {
                this._IsLongMessage = value;
            }
        }
        public string AddTime
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
        public Sms_DataInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
