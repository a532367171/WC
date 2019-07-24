using System;
namespace WC.Model
{
    [Serializable]
    public class Gov_RecipientInfo
    {
        private int _id;
        private string _guid;
        private int _Flow_ID;
        private int _UserID;
        private string _UserRealName;
        private string _UserDepName;
        private int _Sign;
        private string _FeedBack;
        private DateTime _SignTime;
        private int _ComID;
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
        public int Flow_ID
        {
            get
            {
                return this._Flow_ID;
            }
            set
            {
                this._Flow_ID = value;
            }
        }
        public int UserID
        {
            get
            {
                return this._UserID;
            }
            set
            {
                this._UserID = value;
            }
        }
        public string UserRealName
        {
            get
            {
                return this._UserRealName;
            }
            set
            {
                this._UserRealName = value;
            }
        }
        public string UserDepName
        {
            get
            {
                return this._UserDepName;
            }
            set
            {
                this._UserDepName = value;
            }
        }
        public int Sign
        {
            get
            {
                return this._Sign;
            }
            set
            {
                this._Sign = value;
            }
        }
        public string FeedBack
        {
            get
            {
                return this._FeedBack;
            }
            set
            {
                this._FeedBack = value;
            }
        }
        public DateTime SignTime
        {
            get
            {
                return this._SignTime;
            }
            set
            {
                this._SignTime = value;
            }
        }
        public Gov_RecipientInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
