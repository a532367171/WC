using System;
namespace WC.Model
{
    [Serializable]
    public class Flows_Model_TypeInfo
    {
        private int _id;
        private string _guid;
        private string _TypeName;
        private string _Notes;
        private int _Orders;
        private int _ParentID;
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
        public Flows_Model_TypeInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
