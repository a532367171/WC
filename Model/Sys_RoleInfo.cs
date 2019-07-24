using System;
namespace WC.Model
{
    [Serializable]
    public class Sys_RoleInfo
    {
        private int _id;
        private string _guid;
        private string _RoleName;
        private int _ComID;
        private string _ComGUID;
        private string _Notes;
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
        public string RoleName
        {
            get
            {
                return this._RoleName;
            }
            set
            {
                this._RoleName = value;
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
        public Sys_RoleInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
        public Sys_RoleInfo(int id, string guid, string RoleName, int ComID, string ComGUID)
        {
            this._id = id;
            this._guid = guid;
            this._RoleName = RoleName;
            this._ComID = ComID;
            this._ComGUID = ComGUID;
        }
    }
}
