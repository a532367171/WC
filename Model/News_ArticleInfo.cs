using System;
namespace WC.Model
{
    [Serializable]
    public class News_ArticleInfo
    {
        private int _id;
        private string _guid;
        private string _NewsTitle;
        private string _FilePath;
        private string _Notes;
        private int _TypeID;
        private int _CreatorID;
        private string _CreatorRealName;
        private string _CreatorDepName;
        private DateTime _AddTime;
        private string _ShareUsers;
        private string _ShareDeps;
        private string _namelist;
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
        public string NewsTitle
        {
            get
            {
                return this._NewsTitle;
            }
            set
            {
                this._NewsTitle = value;
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
        public int TypeID
        {
            get
            {
                return this._TypeID;
            }
            set
            {
                this._TypeID = value;
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
        public string ShareDeps
        {
            get
            {
                return this._ShareDeps;
            }
            set
            {
                this._ShareDeps = value;
            }
        }
        public News_ArticleInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
