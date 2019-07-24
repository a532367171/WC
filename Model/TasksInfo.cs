using System;
namespace WC.Model
{
    [Serializable]
    public class TasksInfo
    {
        private int _id;
        private string _guid;
        private string _TaskName;
        private int _TypeID;
        private string _TypeName;
        private string _Important;
        private int _Status;
        private int _IsOtherSee;
        private int _OnceSubmit;
        private int _CreatorID;
        private string _CreatorRealName;
        private string _CreatorDepName;
        private string _ManageUserList;
        private string _ManageNameList;
        private string _ExecuteUserList;
        private string _ExecuteNameList;
        private string _AddTime;
        private string _UpdateTime;
        private string _ExpectTime;
        private string _Notes;
        private string _FilePath;
        private int _IsComplete;
        private string _Records;
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
        public string TaskName
        {
            get
            {
                return this._TaskName;
            }
            set
            {
                this._TaskName = value;
            }
        }
        public int TypeID
        {
            get
            {
                return this._TypeID;
            }
            set
            {
                this._TypeID = value;
            }
        }
        public string TypeName
        {
            get
            {
                return this._TypeName;
            }
            set
            {
                this._TypeName = value;
            }
        }
        public string Important
        {
            get
            {
                return this._Important;
            }
            set
            {
                this._Important = value;
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
        public int IsOtherSee
        {
            get
            {
                return this._IsOtherSee;
            }
            set
            {
                this._IsOtherSee = value;
            }
        }
        public int OnceSubmit
        {
            get
            {
                return this._OnceSubmit;
            }
            set
            {
                this._OnceSubmit = value;
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
        public string ManageUserList
        {
            get
            {
                return this._ManageUserList;
            }
            set
            {
                this._ManageUserList = value;
            }
        }
        public string ManageNameList
        {
            get
            {
                return this._ManageNameList;
            }
            set
            {
                this._ManageNameList = value;
            }
        }
        public string ExecuteUserList
        {
            get
            {
                return this._ExecuteUserList;
            }
            set
            {
                this._ExecuteUserList = value;
            }
        }
        public string ExecuteNameList
        {
            get
            {
                return this._ExecuteNameList;
            }
            set
            {
                this._ExecuteNameList = value;
            }
        }
        public string AddTime
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
        public string UpdateTime
        {
            get
            {
                return this._UpdateTime;
            }
            set
            {
                this._UpdateTime = value;
            }
        }
        public string ExpectTime
        {
            get
            {
                return this._ExpectTime;
            }
            set
            {
                this._ExpectTime = value;
            }
        }
        public string Notes
        {
            get
            {
                return this._Notes;
            }
            set
            {
                this._Notes = value;
            }
        }
        public string FilePath
        {
            get
            {
                return this._FilePath;
            }
            set
            {
                this._FilePath = value;
            }
        }
        public int IsComplete
        {
            get
            {
                return this._IsComplete;
            }
            set
            {
                this._IsComplete = value;
            }
        }
        public string Records
        {
            get
            {
                return this._Records;
            }
            set
            {
                this._Records = value;
            }
        }
        public TasksInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
