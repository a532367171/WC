using System;
namespace WC.Model
{
    [Serializable]
    public class Sys_DepInfo
    {
        private int _id;
        private string _guid;
        private string _DepName;
        private string _Notes;
        private int _ParentID;
        private string _ParentGUID;
        private int _IsPosition;
        private int _ComID;
        private string _ComGUID;
        private int _Orders;
        private string _Phone;
        private string _ch;
        private string _sh;
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
        public string DepName
        {
            get
            {
                return this._DepName;
            }
            set
            {
                this._DepName = value;
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
        public int ParentID
        {
            get
            {
                return this._ParentID;
            }
            set
            {
                this._ParentID = value;
            }
        }
        public string ParentGUID
        {
            get
            {
                return this._ParentGUID;
            }
            set
            {
                this._ParentGUID = value;
            }
        }
        public int IsPosition
        {
            get
            {
                return this._IsPosition;
            }
            set
            {
                this._IsPosition = value;
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
        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {
                this._Phone = value;
            }
        }
        public string Ch
        {
            get
            {
                return this._ch;
            }
            set
            {
                this._ch = value;
            }
        }
        public string Sh
        {
            get
            {
                return this._sh;
            }
            set
            {
                this._sh = value;
            }
        }
        public Sys_DepInfo()
        {
            this._guid = Guid.NewGuid().ToString();
        }
        public Sys_DepInfo(int id, string guid, string DepName, string Notes, int ParentID, string ParentGUID, int IsPosition, int ComID, string ComGUID)
        {
            this._id = id;
            this._guid = Guid.NewGuid().ToString();
            this._DepName = DepName;
            this._Notes = Notes;
            this._ParentID = ParentID;
            this._ParentGUID = ParentGUID;
            this._IsPosition = IsPosition;
            this._ComID = ComID;
            this._ComGUID = ComGUID;
        }
    }
}
