using System;
namespace WC.Model
{
    [Serializable]
    public class Sys_SealInfo
    {
        private int _id;
        private string _guid;
        private string _SealName;
        private string _FilePath;
        private string _TagName;
        private string _userlist;
        private string _namelist;
        private string _Notes;
        private DateTime _AddTime;
        private int _Status;
        private string _PWD;
        private int _Uid;
        private int _ComID;
        public string PWD
        {
            get
            {
                return this._PWD;
            }
            set
            {
                this._PWD = value;
            }
        }
        public int Uid
        {
            get
            {
                return this._Uid;
            }
            set
            {
                this._Uid = value;
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
        public string SealName
        {
            get
            {
                return this._SealName;
            }
            set
            {
                this._SealName = value;
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
        public string TagName
        {
            get
            {
                return this._TagName;
            }
            set
            {
                this._TagName = value;
            }
        }
        public string userlist
        {
            get
            {
                return this._userlist;
            }
            set
            {
                this._userlist = value;
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
        public int Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this._Status = value;
            }
        }
        public Sys_SealInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
