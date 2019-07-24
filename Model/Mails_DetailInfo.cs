using System;
namespace WC.Model
{
    [Serializable]
    public class Mails_DetailInfo
    {
        private int _id;
        private string _guid;
        private string _SendIDs;
        private string _SendRealNames;
        private string _CcIDs;
        private string _CcRealNames;
        private string _BccIDs;
        private string _BccRealNames;
        private string _Bodys;
        private string _Attachments;
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
        public string SendIDs
        {
            get
            {
                return this._SendIDs;
            }
            set
            {
                this._SendIDs = value;
            }
        }
        public string SendRealNames
        {
            get
            {
                return this._SendRealNames;
            }
            set
            {
                this._SendRealNames = value;
            }
        }
        public string CcIDs
        {
            get
            {
                return this._CcIDs;
            }
            set
            {
                this._CcIDs = value;
            }
        }
        public string CcRealNames
        {
            get
            {
                return this._CcRealNames;
            }
            set
            {
                this._CcRealNames = value;
            }
        }
        public string BccIDs
        {
            get
            {
                return this._BccIDs;
            }
            set
            {
                this._BccIDs = value;
            }
        }
        public string BccRealNames
        {
            get
            {
                return this._BccRealNames;
            }
            set
            {
                this._BccRealNames = value;
            }
        }
        public string Bodys
        {
            get
            {
                return this._Bodys;
            }
            set
            {
                this._Bodys = value;
            }
        }
        public string Attachments
        {
            get
            {
                return this._Attachments;
            }
            set
            {
                this._Attachments = value;
            }
        }
        public Mails_DetailInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
