using System;
namespace WC.Model
{
    [Serializable]
    public class Tasks_UserInfo
    {
        private int _id;
        private string _guid;
        private int _TaskID;
        private int _UserID;
        private string _RealName;
        private string _DepName;
        private int _WorkTag;
        private string _WorkTitle;
        private string _WorkNotes;
        private string _FilePath;
        private string _AddTime;
        private string _Instruction;
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
        public int TaskID
        {
            get
            {
                return this._TaskID;
            }
            set
            {
                this._TaskID = value;
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
        public int WorkTag
        {
            get
            {
                return this._WorkTag;
            }
            set
            {
                this._WorkTag = value;
            }
        }
        public string WorkTitle
        {
            get
            {
                return this._WorkTitle;
            }
            set
            {
                this._WorkTitle = value;
            }
        }
        public string WorkNotes
        {
            get
            {
                return this._WorkNotes;
            }
            set
            {
                this._WorkNotes = value;
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
        public string Instruction
        {
            get
            {
                return this._Instruction;
            }
            set
            {
                this._Instruction = value;
            }
        }
        public Tasks_UserInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
