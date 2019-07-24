using System;
namespace WC.Model
{
    [Serializable]
    public class ZEX2Info
    {
        private int _id;
        private string _guid;
        private int _e1;
        private int _e2;
        private int _e3;
        private int _e4;
        private string _e5;
        private string _e6;
        private string _e7;
        private string _e8;
        private string _e9;
        private DateTime _e10;
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
        public int e1
        {
            get
            {
                return this._e1;
            }
            set
            {
                this._e1 = value;
            }
        }
        public int e2
        {
            get
            {
                return this._e2;
            }
            set
            {
                this._e2 = value;
            }
        }
        public int e3
        {
            get
            {
                return this._e3;
            }
            set
            {
                this._e3 = value;
            }
        }
        public int e4
        {
            get
            {
                return this._e4;
            }
            set
            {
                this._e4 = value;
            }
        }
        public string e5
        {
            get
            {
                return this._e5;
            }
            set
            {
                this._e5 = value;
            }
        }
        public string e6
        {
            get
            {
                return this._e6;
            }
            set
            {
                this._e6 = value;
            }
        }
        public string e7
        {
            get
            {
                return this._e7;
            }
            set
            {
                this._e7 = value;
            }
        }
        public string e8
        {
            get
            {
                return this._e8;
            }
            set
            {
                this._e8 = value;
            }
        }
        public string e9
        {
            get
            {
                return this._e9;
            }
            set
            {
                this._e9 = value;
            }
        }
        public DateTime e10
        {
            get
            {
                return this._e10;
            }
            set
            {
                this._e10 = value;
            }
        }
        public ZEX2Info()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
