using System;
namespace WC.Model
{
    [Serializable]
    public class Sys_Role_ModuleInfo
    {
        private int _id;
        private string _guid;
        private int _RoleID;
        private int _ModuleID;
        private string _RoleGUID;
        private string _ModuleGUID;
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
        public int RoleID
        {
            get
            {
                return this._RoleID;
            }
            set
            {
                this._RoleID = value;
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
        public string RoleGUID
        {
            get
            {
                return this._RoleGUID;
            }
            set
            {
                this._RoleGUID = value;
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
        public Sys_Role_ModuleInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
        public Sys_Role_ModuleInfo(int id, string guid, int RoleID, int ModuleID, string RoleGUID, string ModuleGUID, int ComID, string ComGUID)
        {
            this._id = id;
            this._guid = guid;
            this._RoleID = RoleID;
            this._ModuleID = ModuleID;
            this._RoleGUID = RoleGUID;
            this._ModuleGUID = ModuleGUID;
            this._ComID = ComID;
            this._ComGUID = ComGUID;
        }
    }
}
