using System;
namespace WC.Model
{
    [Serializable]
    public class Gov_ModelFileInfo
    {
        private int _id;
        private string _guid;
        private string _FormTitle;
        private string _FilePath = "";
        private int _CreatorID;
        private string _CreatorRealName;
        private string _CreatorDepName;
        private DateTime _AddTime;
        private int _ComID;
        private string _DocBody;
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
        public string DocBody
        {
            get
            {
                return this._DocBody;
            }
            set
            {
                this._DocBody = value;
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
        public string FormTitle
        {
            get
            {
                return this._FormTitle;
            }
            set
            {
                this._FormTitle = value;
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
        public Gov_ModelFileInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
