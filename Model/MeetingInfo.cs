using System;
namespace WC.Model
{
    [Serializable]
    public class MeetingInfo
    {
        private int _id;
        private string _guid;
        private string _Bodys;
        private string _CTime;
        private string _Address;
        private string _Recorder;
        private string _ListPerson;
        private string _AbsencePerson;
        private string _Chaired;
        private string _MainTopics;
        private string _Remarks;
        private string _FilePath;
        private int _UserID;
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
        public string Bodys
        {
            get
            {
                return this._Bodys;
            }
            set
            {
                this._Bodys = value;
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
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                this._Address = value;
            }
        }
        public string Recorder
        {
            get
            {
                return this._Recorder;
            }
            set
            {
                this._Recorder = value;
            }
        }
        public string ListPerson
        {
            get
            {
                return this._ListPerson;
            }
            set
            {
                this._ListPerson = value;
            }
        }
        public string AbsencePerson
        {
            get
            {
                return this._AbsencePerson;
            }
            set
            {
                this._AbsencePerson = value;
            }
        }
        public string Chaired
        {
            get
            {
                return this._Chaired;
            }
            set
            {
                this._Chaired = value;
            }
        }
        public string MainTopics
        {
            get
            {
                return this._MainTopics;
            }
            set
            {
                this._MainTopics = value;
            }
        }
        public string Remarks
        {
            get
            {
                return this._Remarks;
            }
            set
            {
                this._Remarks = value;
            }
        }
        public string FilePath
        {
            get
            {
                return this._FilePath;
            }
            set
            {
                this._FilePath = value;
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
        public MeetingInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
