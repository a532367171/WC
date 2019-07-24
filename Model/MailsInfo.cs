using System;
namespace WC.Model
{
    [Serializable]
    public class MailsInfo
    {
        private int _id;
        private string _guid;
        private int _ReceiverID;
        private int _SenderID;
        private string _SenderGUID;
        private string _SenderRealName;
        private string _SenderDepName;
        private string _Subject;
        private int _IsRead;
        private int _FolderType;
        private DateTime _SendTime;
        private int _SendType;
        private int _did;
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
        public int ReceiverID
        {
            get
            {
                return this._ReceiverID;
            }
            set
            {
                this._ReceiverID = value;
            }
        }
        public int SenderID
        {
            get
            {
                return this._SenderID;
            }
            set
            {
                this._SenderID = value;
            }
        }
        public string SenderGUID
        {
            get
            {
                return this._SenderGUID;
            }
            set
            {
                this._SenderGUID = value;
            }
        }
        public string SenderRealName
        {
            get
            {
                return this._SenderRealName;
            }
            set
            {
                this._SenderRealName = value;
            }
        }
        public string SenderDepName
        {
            get
            {
                return this._SenderDepName;
            }
            set
            {
                this._SenderDepName = value;
            }
        }
        public string Subject
        {
            get
            {
                return this._Subject;
            }
            set
            {
                this._Subject = value;
            }
        }
        public int IsRead
        {
            get
            {
                return this._IsRead;
            }
            set
            {
                this._IsRead = value;
            }
        }
        public int FolderType
        {
            get
            {
                return this._FolderType;
            }
            set
            {
                this._FolderType = value;
            }
        }
        public DateTime SendTime
        {
            get
            {
                return this._SendTime;
            }
            set
            {
                this._SendTime = value;
            }
        }
        public int SendType
        {
            get
            {
                return this._SendType;
            }
            set
            {
                this._SendType = value;
            }
        }
        public int did
        {
            get
            {
                return this._did;
            }
            set
            {
                this._did = value;
            }
        }
        public MailsInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
