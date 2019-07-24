using System;
namespace WC.Model
{
    [Serializable]
    public class Gov_StepInfo
    {
        private int _id;
        private string _guid;
        private int _Flow_ID;
        private string _Step_Name;
        private string _Step_Remark;
        private int _Step_Orders;
        private int _RightToFinish;
        private int _MailAlert;
        private int _IsEnd;
        private int _IsHead;
        private int _IsUserEdit;
        private int _IsUserFile;
        private string _userlist;
        private string _namelist;
        private int _IsAct;
        private string _Acts;
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
        public string Step_Name
        {
            get
            {
                return this._Step_Name;
            }
            set
            {
                this._Step_Name = value;
            }
        }
        public string Step_Remark
        {
            get
            {
                return this._Step_Remark;
            }
            set
            {
                this._Step_Remark = value;
            }
        }
        public int Step_Orders
        {
            get
            {
                return this._Step_Orders;
            }
            set
            {
                this._Step_Orders = value;
            }
        }
        public int RightToFinish
        {
            get
            {
                return this._RightToFinish;
            }
            set
            {
                this._RightToFinish = value;
            }
        }
        public int MailAlert
        {
            get
            {
                return this._MailAlert;
            }
            set
            {
                this._MailAlert = value;
            }
        }
        public int IsEnd
        {
            get
            {
                return this._IsEnd;
            }
            set
            {
                this._IsEnd = value;
            }
        }
        public int IsHead
        {
            get
            {
                return this._IsHead;
            }
            set
            {
                this._IsHead = value;
            }
        }
        public int IsUserEdit
        {
            get
            {
                return this._IsUserEdit;
            }
            set
            {
                this._IsUserEdit = value;
            }
        }
        public int IsUserFile
        {
            get
            {
                return this._IsUserFile;
            }
            set
            {
                this._IsUserFile = value;
            }
        }
        public string userlist
        {
            get
            {
                return this._userlist;
            }
            set
            {
                this._userlist = value;
            }
        }
        public string namelist
        {
            get
            {
                return this._namelist;
            }
            set
            {
                this._namelist = value;
            }
        }
        public int IsAct
        {
            get
            {
                return this._IsAct;
            }
            set
            {
                this._IsAct = value;
            }
        }
        public string Acts
        {
            get
            {
                return this._Acts;
            }
            set
            {
                this._Acts = value;
            }
        }
        public Gov_StepInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
