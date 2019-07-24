using System;
namespace WC.Model
{
    [Serializable]
    public class Sys_ModuleInfo
    {
        private int _id;
        private string _guid;
        private string _TypeName;
        private string _ModuleName;
        private string _ModuleUrl;
        private int _Orders;
        private int _IsShow;
        private string _Notes;
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
        public string TypeName
        {
            get
            {
                return this._TypeName;
            }
            set
            {
                this._TypeName = value;
            }
        }
        public string ModuleName
        {
            get
            {
                return this._ModuleName;
            }
            set
            {
                this._ModuleName = value;
            }
        }
        public string ModuleUrl
        {
            get
            {
                return this._ModuleUrl;
            }
            set
            {
                this._ModuleUrl = value;
            }
        }
        public int Orders
        {
            get
            {
                return this._Orders;
            }
            set
            {
                this._Orders = value;
            }
        }
        public int IsShow
        {
            get
            {
                return this._IsShow;
            }
            set
            {
                this._IsShow = value;
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
        public Sys_ModuleInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
        public Sys_ModuleInfo(int id, string guid, string TypeName, string ModuleName, string ModuleUrl, int Orders, int IsShow, string Notes, int ComID, string ComGUID)
        {
            this._id = id;
            this._guid = guid;
            this._TypeName = TypeName;
            this._ModuleName = ModuleName;
            this._ModuleUrl = ModuleUrl;
            this._Orders = Orders;
            this._IsShow = IsShow;
            this._Notes = Notes;
            this._ComID = ComID;
            this._ComGUID = ComGUID;
        }
    }
}
