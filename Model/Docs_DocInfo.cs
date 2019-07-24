using System;
namespace WC.Model
{
    [Serializable]
    public class Docs_DocInfo
    {
        private int _id;
        private string _guid;
        private string _DocTitle;
        private string _FilePath;
        private string _Notes;
        private int _CreatorID;
        private string _CreatorRealName;
        private string _CreatorDepName;
        private int _IsShare;
        private string _ShareUsers;
        private DateTime _AddTime;
        private string _namelist;
        private int _DocTypeID;
        private int _ComID;
        public int DocTypeID
        {
            get
            {
                return this._DocTypeID;
            }
            set
            {
                this._DocTypeID = value;
            }
        }
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
        public string DocTitle
        {
            get
            {
                return this._DocTitle;
            }
            set
            {
                this._DocTitle = value;
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
        public int IsShare
        {
            get
            {
                return this._IsShare;
            }
            set
            {
                this._IsShare = value;
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
        public Docs_DocInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
