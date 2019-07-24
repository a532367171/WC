using System;
namespace WC.Model
{
    [Serializable]
    public class Flows_StepActionInfo
    {
        private int _id;
        private string _guid;
        private int _UserID;
        private string _UserRealName;
        private string _UserDepName;
        private int _Operation;
        private string _OperationWord;
        private int _OperationStepID;
        private int _BackStepID;
        private int _FlowID;
        private DateTime _AddTime;
        private string _OperationStepName;
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
        public int Operation
        {
            get
            {
                return this._Operation;
            }
            set
            {
                this._Operation = value;
            }
        }
        public string OperationWord
        {
            get
            {
                return this._OperationWord;
            }
            set
            {
                this._OperationWord = value;
            }
        }
        public int OperationStepID
        {
            get
            {
                return this._OperationStepID;
            }
            set
            {
                this._OperationStepID = value;
            }
        }
        public int BackStepID
        {
            get
            {
                return this._BackStepID;
            }
            set
            {
                this._BackStepID = value;
            }
        }
        public int FlowID
        {
            get
            {
                return this._FlowID;
            }
            set
            {
                this._FlowID = value;
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
        public string OperationStepName
        {
            get
            {
                return this._OperationStepName;
            }
            set
            {
                this._OperationStepName = value;
            }
        }
        public Flows_StepActionInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
