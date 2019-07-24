using System;
namespace WC.Model
{
    [Serializable]
    public class Gov_ModelInfo
    {
        private int _id;
        private string _guid;
        private string _Flow_Name;
        private int _CreatorID;
        private string _CreatorRealName;
        private string _CreatorDepName;
        private string _Remark;
        private string _ModelFileID;
        private DateTime _AddTime;
        private int _IsComplete;
        private int _ComID;
        private string _ShareDeps;
        private string _namelist;
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
        public string Flow_Name
        {
            get
            {
                return this._Flow_Name;
            }
            set
            {
                this._Flow_Name = value;
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
        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                this._Remark = value;
            }
        }
        public string ModelFileID
        {
            get
            {
                return this._ModelFileID;
            }
            set
            {
                this._ModelFileID = value;
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
        public int IsComplete
        {
            get
            {
                return this._IsComplete;
            }
            set
            {
                this._IsComplete = value;
            }
        }
        public Gov_ModelInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
