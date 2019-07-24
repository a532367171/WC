using System;
namespace WC.Model
{
    [Serializable]
    public class PaperInfo
    {
        private int _id;
        private string _guid;
        private string _PaperName;
        private int _TypeID;
        private int _CreatorID;
        private string _CreatorRealName;
        private string _CreatorDepName;
        private string _SendDep;
        private string _PaperKind = "";
        private string _PaperSymbol;
        private string _PaperGrade;
        private string _PaperUrgency = "";
        private string _PaperDate;
        private string _FilePath;
        private string _PaperNO = "";
        private string _ShareDeps;
        private string _namelist;
        private string _Notes;
        private string _AddTime;
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
        public string PaperName
        {
            get
            {
                return this._PaperName;
            }
            set
            {
                this._PaperName = value;
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
        public string SendDep
        {
            get
            {
                return this._SendDep;
            }
            set
            {
                this._SendDep = value;
            }
        }
        public string PaperKind
        {
            get
            {
                return this._PaperKind;
            }
            set
            {
                this._PaperKind = value;
            }
        }
        public string PaperSymbol
        {
            get
            {
                return this._PaperSymbol;
            }
            set
            {
                this._PaperSymbol = value;
            }
        }
        public string PaperGrade
        {
            get
            {
                return this._PaperGrade;
            }
            set
            {
                this._PaperGrade = value;
            }
        }
        public string PaperUrgency
        {
            get
            {
                return this._PaperUrgency;
            }
            set
            {
                this._PaperUrgency = value;
            }
        }
        public string PaperDate
        {
            get
            {
                return this._PaperDate;
            }
            set
            {
                this._PaperDate = value;
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
        public string PaperNO
        {
            get
            {
                return this._PaperNO;
            }
            set
            {
                this._PaperNO = value;
            }
        }
        public string ShareDeps
        {
            get
            {
                return this._ShareDeps;
            }
            set
            {
                this._ShareDeps = value;
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
        public PaperInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
