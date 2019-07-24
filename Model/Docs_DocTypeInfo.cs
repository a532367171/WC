using System;
namespace WC.Model
{
    [Serializable]
    public class Docs_DocTypeInfo
    {
        private int _id;
        private string _guid;
        private string _TypeName;
        private int _Uid;
        private string _Notes;
        private int _ComID;
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
        public int Uid
        {
            get
            {
                return this._Uid;
            }
            set
            {
                this._Uid = value;
            }
        }
        public Docs_DocTypeInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
