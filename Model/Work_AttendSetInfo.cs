using System;
namespace WC.Model
{
    [Serializable]
    public class Work_AttendSetInfo
    {
        private int _id;
        private string _guid;
        private string _AttendTimes;
        private string _AttendNames;
        private string _Offset;
        private int _WorkKind;
        public int WorkKind
        {
            get
            {
                return this._WorkKind;
            }
            set
            {
                this._WorkKind = value;
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
        public string AttendTimes
        {
            get
            {
                return this._AttendTimes;
            }
            set
            {
                this._AttendTimes = value;
            }
        }
        public string AttendNames
        {
            get
            {
                return this._AttendNames;
            }
            set
            {
                this._AttendNames = value;
            }
        }
        public string Offset
        {
            get
            {
                return this._Offset;
            }
            set
            {
                this._Offset = value;
            }
        }
        public Work_AttendSetInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
