using System;
namespace WC.Model
{
    [Serializable]
    public class PaperDownloadInfo
    {
        private int _id;
        private string _guid;
        private int _PaperID;
        private int _DUserID;
        private string _DUserName;
        private string _DDepName;
        private string _DPaperName;
        private string _DPaperNo;
        private string _DPaperSymbol;
        private string _DSendDep;
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
        public int PaperID
        {
            get
            {
                return this._PaperID;
            }
            set
            {
                this._PaperID = value;
            }
        }
        public int DUserID
        {
            get
            {
                return this._DUserID;
            }
            set
            {
                this._DUserID = value;
            }
        }
        public string DUserName
        {
            get
            {
                return this._DUserName;
            }
            set
            {
                this._DUserName = value;
            }
        }
        public string DDepName
        {
            get
            {
                return this._DDepName;
            }
            set
            {
                this._DDepName = value;
            }
        }
        public string DPaperName
        {
            get
            {
                return this._DPaperName;
            }
            set
            {
                this._DPaperName = value;
            }
        }
        public string DPaperNo
        {
            get
            {
                return this._DPaperNo;
            }
            set
            {
                this._DPaperNo = value;
            }
        }
        public string DPaperSymbol
        {
            get
            {
                return this._DPaperSymbol;
            }
            set
            {
                this._DPaperSymbol = value;
            }
        }
        public string DSendDep
        {
            get
            {
                return this._DSendDep;
            }
            set
            {
                this._DSendDep = value;
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
        public PaperDownloadInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
