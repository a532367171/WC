using System;
namespace WC.Model
{
    [Serializable]
    public class Sys_UserLoginInfo
    {
        private int _id;
        private string _guid;
        private string _UserName;
        private string _UserInfo;
        private string _LoginIP;
        private string _LoginTime;
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
        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this._UserName = value;
            }
        }
        public string UserInfo
        {
            get
            {
                return this._UserInfo;
            }
            set
            {
                this._UserInfo = value;
            }
        }
        public string LoginIP
        {
            get
            {
                return this._LoginIP;
            }
            set
            {
                this._LoginIP = value;
            }
        }
        public string LoginTime
        {
            get
            {
                return this._LoginTime;
            }
            set
            {
                this._LoginTime = value;
            }
        }
        public Sys_UserLoginInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
    }
}
