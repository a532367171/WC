using System;
namespace WC.Model
{
    [Serializable]
    public class PhoneBookInfo
    {
        private int _id;
        private string _guid;
        private int _UserID;
        private string _RealName;
        private string _DepName;
        private DateTime _AddTime;
        private string _Person;
        private string _Phone;
        private string _TagName;
        private string _Notes;
        private int _ComID;
        public int ComID
        {
            get
            {
                return this._ComID;
            }
            set
            {
                this._ComID = value;
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
        public string Person
        {
            get
            {
                return this._Person;
            }
            set
            {
                this._Person = value;
            }
        }
        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {
                this._Phone = value;
            }
        }
        public string TagName
        {
            get
            {
                return this._TagName;
            }
            set
            {
                this._TagName = value;
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
        public PhoneBookInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
