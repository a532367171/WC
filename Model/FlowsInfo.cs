using System;
namespace WC.Model
{
    [Serializable]
    public class FlowsInfo
    {
        private int _id;
        private string _guid;
        private string _Flow_Name;
        private int _CurrentStepID;
        private string _CurrentStepName;
        private string _CurrentStepUserList;
        private string _HasOperatedUserList;
        private int _CreatorID;
        private string _CreatorRealName;
        private string _CreatorDepName;
        private string _Remark;
        private int _Status;
        private string _Flow_Files;
        private DateTime _AddTime;
        private DateTime _ValidTime;
        private int _IsValid;
        private string _CurrentDocPath;
        private string _ModelName;
        private int _ComID;
        private string _ViewUserList;
        private string _DocBody;
        public string ModelName
        {
            get
            {
                return this._ModelName;
            }
            set
            {
                this._ModelName = value;
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
        public string ViewUserList
        {
            get
            {
                return this._ViewUserList;
            }
            set
            {
                this._ViewUserList = value;
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
        public string Flow_Name
        {
            get
            {
                return this._Flow_Name;
            }
            set
            {
                this._Flow_Name = value;
            }
        }
        public int CurrentStepID
        {
            get
            {
                return this._CurrentStepID;
            }
            set
            {
                this._CurrentStepID = value;
            }
        }
        public string CurrentStepName
        {
            get
            {
                return this._CurrentStepName;
            }
            set
            {
                this._CurrentStepName = value;
            }
        }
        public string CurrentStepUserList
        {
            get
            {
                return this._CurrentStepUserList;
            }
            set
            {
                this._CurrentStepUserList = value;
            }
        }
        public string HasOperatedUserList
        {
            get
            {
                return this._HasOperatedUserList;
            }
            set
            {
                this._HasOperatedUserList = value;
            }
        }
        public int CreatorID
        {
            get
            {
                return this._CreatorID;
            }
            set
            {
                this._CreatorID = value;
            }
        }
        public string CreatorRealName
        {
            get
            {
                return this._CreatorRealName;
            }
            set
            {
                this._CreatorRealName = value;
            }
        }
        public string CreatorDepName
        {
            get
            {
                return this._CreatorDepName;
            }
            set
            {
                this._CreatorDepName = value;
            }
        }
        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                this._Remark = value;
            }
        }
        public int Status
        {
            get
            {
                return this._Status;
            }
            set
            {
                this._Status = value;
            }
        }
        public string Flow_Files
        {
            get
            {
                return this._Flow_Files;
            }
            set
            {
                this._Flow_Files = value;
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
        public DateTime ValidTime
        {
            get
            {
                return this._ValidTime;
            }
            set
            {
                this._ValidTime = value;
            }
        }
        public int IsValid
        {
            get
            {
                return this._IsValid;
            }
            set
            {
                this._IsValid = value;
            }
        }
        public string CurrentDocPath
        {
            get
            {
                return this._CurrentDocPath;
            }
            set
            {
                this._CurrentDocPath = value;
            }
        }
        public FlowsInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
