using System;
namespace WC.Model
{
    [Serializable]
    public class News_TypeInfo
    {
        private int _id;
        private string _guid;
        private string _TypeName;
        private string _Notes;
        private int _Orders;
        private int _ComID;
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
        public News_TypeInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
