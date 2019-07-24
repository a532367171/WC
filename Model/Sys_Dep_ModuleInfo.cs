using System;
namespace WC.Model
{
    [Serializable]
    public class Sys_Dep_ModuleInfo
    {
        private int _id;
        private string _guid;
        private int _ModuleID;
        private string _ModuleGUID;
        private int _DepID;
        private string _DepGUID;
        private int _ComID;
        private string _ComGUID;
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
        public int ModuleID
        {
            get
            {
                return this._ModuleID;
            }
            set
            {
                this._ModuleID = value;
            }
        }
        public string ModuleGUID
        {
            get
            {
                return this._ModuleGUID;
            }
            set
            {
                this._ModuleGUID = value;
            }
        }
        public int DepID
        {
            get
            {
                return this._DepID;
            }
            set
            {
                this._DepID = value;
            }
        }
        public string DepGUID
        {
            get
            {
                return this._DepGUID;
            }
            set
            {
                this._DepGUID = value;
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
        public string ComGUID
        {
            get
            {
                return this._ComGUID;
            }
            set
            {
                this._ComGUID = value;
            }
        }
        public Sys_Dep_ModuleInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
        public Sys_Dep_ModuleInfo(int id, string guid, int ModuleID, string ModuleGUID, int DepID, string DepGUID, int ComID, string ComGUID)
        {
            this._id = id;
            this._guid = Guid.NewGuid().ToString("N");
            this._ModuleID = ModuleID;
            this._ModuleGUID = ModuleGUID;
            this._DepID = DepID;
            this._DepGUID = DepGUID;
            this._ComID = ComID;
            this._ComGUID = ComGUID;
        }
    }
}

