using System;
namespace WC.Model
{
    [Serializable]
    public class NoteBookInfo
    {
        private int _id;
        private string _guid;
        private int _UserID;
        private string _RealName;
        private string _DepName;
        private DateTime _AddTime;
        private string _Bodys;
        private string _Subject;
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
        public NoteBookInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
