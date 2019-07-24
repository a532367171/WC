using System;
namespace WC.Model
{
    [Serializable]
    public class WorkLogInfo
    {
        private int _id;
        private string _guid;
        private string _LogTitle;
        private string _FilePath;
        private string _Notes;
        private int _CreatorID;
        private string _CreatorRealName;
        private string _CreatorDepName;
        private string _ShareUsers;
        private string _AddTime;
        private string _UpdateTime;
        private string _namelist;
        public string UpdateTime
        {
            get
            {
                return this._UpdateTime;
            }
            set
            {
                this._UpdateTime = value;
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
        public string LogTitle
        {
            get
            {
                return this._LogTitle;
            }
            set
            {
                this._LogTitle = value;
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
        public int CreatorID
        {
            get
            {
                return this._CreatorID;
            }
            set
            {
                this._CreatorID = value;
            }
        }
        public string CreatorRealName
        {
            get
            {
                return this._CreatorRealName;
            }
            set
            {
                this._CreatorRealName = value;
            }
        }
        public string CreatorDepName
        {
            get
            {
                return this._CreatorDepName;
            }
            set
            {
                this._CreatorDepName = value;
            }
        }
        public string ShareUsers
        {
            get
            {
                return this._ShareUsers;
            }
            set
            {
                this._ShareUsers = value;
            }
        }
        public string namelist
        {
            get
            {
                return this._namelist;
            }
            set
            {
                this._namelist = value;
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
        public WorkLogInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
