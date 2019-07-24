using System;
namespace WC.Model
{
    [Serializable]
    public class Flows_DocInfo
    {
        private int _id;
        private string _guid;
        private int _Flow_ID;
        private int _StepAction_ID;
        private int _UserID;
        private string _UserRealName;
        private string _UserDepName;
        private string _DocPath;
        private DateTime _AddTime;
        private int _ComID;
        private string _DocBody;
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
        public string DocBody
        {
            get
            {
                return this._DocBody;
            }
            set
            {
                this._DocBody = value;
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
        public int StepAction_ID
        {
            get
            {
                return this._StepAction_ID;
            }
            set
            {
                this._StepAction_ID = value;
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
        public string DocPath
        {
            get
            {
                return this._DocPath;
            }
            set
            {
                this._DocPath = value;
            }
        }
        public DateTime AddTime
        {
            get
            {
                return this._AddTime;
            }
            set
            {
                this._AddTime = value;
            }
        }
        public Flows_DocInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
