using System;
namespace WC.Model
{
    [Serializable]
    public class Gov_ModelStepInfo
    {
        private int _id;
        private string _guid;
        private int _Flow_ModelID;
        private string _Step_Name;
        private string _Step_Remark;
        private int _Step_Orders;
        private int _RightToFinish;
        private int _MailAlert;
        private int _IsEnd;
        private int _IsHead;
        private int _IsUserEdit;
        private int _IsUserFile;
        private int _Step_Type;
        private string _UserList;
        private string _NameList;
        private string _UserList_dep;
        private string _NameList_dep;
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
        public int Flow_ModelID
        {
            get
            {
                return this._Flow_ModelID;
            }
            set
            {
                this._Flow_ModelID = value;
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
        public int Step_Type
        {
            get
            {
                return this._Step_Type;
            }
            set
            {
                this._Step_Type = value;
            }
        }
        public string UserList
        {
            get
            {
                return this._UserList;
            }
            set
            {
                this._UserList = value;
            }
        }
        public string NameList
        {
            get
            {
                return this._NameList;
            }
            set
            {
                this._NameList = value;
            }
        }
        public string UserList_dep
        {
            get
            {
                return this._UserList_dep;
            }
            set
            {
                this._UserList_dep = value;
            }
        }
        public string NameList_dep
        {
            get
            {
                return this._NameList_dep;
            }
            set
            {
                this._NameList_dep = value;
            }
        }
        public Gov_ModelStepInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
