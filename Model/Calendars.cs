using System;
namespace WC.Model
{
    [Serializable]
    public class Calendars
    {
        private int _ID;
        private string _UID;
        private string _EID;
        private string _EName;
        private string _STime;
        private string _ETime;
        private string _CTime;
        private DateTime _MTime;
        private int _LogicDelete;
        private string _MEMO;
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                this._ID = value;
            }
        }
        public string UID
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
        public string EID
        {
            get
            {
                return this._EID;
            }
            set
            {
                this._EID = value;
            }
        }
        public string EName
        {
            get
            {
                return this._EName;
            }
            set
            {
                this._EName = value;
            }
        }
        public string STime
        {
            get
            {
                return this._STime;
            }
            set
            {
                this._STime = value;
            }
        }
        public string ETime
        {
            get
            {
                return this._ETime;
            }
            set
            {
                this._ETime = value;
            }
        }
        public string CTime
        {
            get
            {
                return this._CTime;
            }
            set
            {
                this._CTime = value;
            }
        }
        public DateTime MTime
        {
            get
            {
                return this._MTime;
            }
            set
            {
                this._MTime = value;
            }
        }
        public int LogicDelete
        {
            get
            {
                return this._LogicDelete;
            }
            set
            {
                this._LogicDelete = value;
            }
        }
        public string MEMO
        {
            get
            {
                return this._MEMO;
            }
            set
            {
                this._MEMO = value;
            }
        }
    }
}
