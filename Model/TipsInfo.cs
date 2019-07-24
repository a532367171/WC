using System;
namespace WC.Model
{
    [Serializable]
    public class TipsInfo
    {
        private int _id;
        private string _guid;
        private int _Orders;
        private string _Tips;
        private int _ComID;
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
        public string Tips
        {
            get
            {
                return this._Tips;
            }
            set
            {
                this._Tips = value;
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
        public TipsInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
