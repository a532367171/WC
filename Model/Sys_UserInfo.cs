using System;
namespace WC.Model
{
    [Serializable]
    public class Sys_UserInfo
    {
        //ID
        private int _id;
        //GUID
        private string _guid;
        //账号
        private string _UserName;
        //密码
        private string _PassWord;
        //名字
        private string _RealName;

        private int _Sex;
        private string _Birthday;
        private string _QQ;
        private string _Email;
        private string _Tel;
        private string _Phone;
        //部门
        private int _RoleID;
        private string _RoleGUID;
        //岗位
        private int _DepID;
        private string _DepGUID;
        private string _DepName;

        private string _LastLoginIp;
        private DateTime _LastLoginTime;
        private int _LoginQuantity;
        //0 在岗 1离职
        private int _Status;
        //0 没锁 1锁住
        private int _IsLock;
        private string _RegFromIp;
        private DateTime _RegTime;
        private int _ComID;
        private string _ComGUID;
        private string _Notes;
        private string _JoinTime;
        private int _DirectSupervisor;
        private string _PositionName;
        private string _HomeAddress;
        private int _IsOnline = 0;
        private string _CurrentLoginTime = "";
        private int _MsgTime;
        private int _MemoShare;
        private string _PerPic;
        private int _Orders;
        private int _et1;
        private int _et2;
        private int _et3;
        private string _et4;
        private string _et5;
        private string _et6;
        public string JoinTime
        {
            get
            {
                return this._JoinTime;
            }
            set
            {
                this._JoinTime = value;
            }
        }
        public int DirectSupervisor
        {
            get
            {
                return this._DirectSupervisor;
            }
            set
            {
                this._DirectSupervisor = value;
            }
        }
        public string PositionName
        {
            get
            {
                return this._PositionName;
            }
            set
            {
                this._PositionName = value;
            }
        }
        public string HomeAddress
        {
            get
            {
                return this._HomeAddress;
            }
            set
            {
                this._HomeAddress = value;
            }
        }
        public int IsOnline
        {
            get
            {
                return this._IsOnline;
            }
            set
            {
                this._IsOnline = value;
            }
        }
        public string CurrentLoginTime
        {
            get
            {
                return this._CurrentLoginTime;
            }
            set
            {
                this._CurrentLoginTime = value;
            }
        }
        public string QQ
        {
            get
            {
                return this._QQ;
            }
            set
            {
                this._QQ = value;
            }
        }
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this._Email = value;
            }
        }
        public int MsgTime
        {
            get
            {
                return this._MsgTime;
            }
            set
            {
                this._MsgTime = value;
            }
        }
        public int MemoShare
        {
            get
            {
                return this._MemoShare;
            }
            set
            {
                this._MemoShare = value;
            }
        }
        public string PerPic
        {
            get
            {
                return this._PerPic;
            }
            set
            {
                this._PerPic = value;
            }
        }
        public int Orders
        {
            get
            {
                return this._Orders;
            }
            set
            {
                this._Orders = value;
            }
        }
        public int et1
        {
            get
            {
                return this._et1;
            }
            set
            {
                this._et1 = value;
            }
        }
        public int et2
        {
            get
            {
                return this._et2;
            }
            set
            {
                this._et2 = value;
            }
        }
        public int et3
        {
            get
            {
                return this._et3;
            }
            set
            {
                this._et3 = value;
            }
        }
        public string et4
        {
            get
            {
                return this._et4;
            }
            set
            {
                this._et4 = value;
            }
        }
        public string et5
        {
            get
            {
                return this._et5;
            }
            set
            {
                this._et5 = value;
            }
        }
        public string et6
        {
            get
            {
                return this._et6;
            }
            set
            {
                this._et6 = value;
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
        public string PassWord
        {
            get
            {
                return this._PassWord;
            }
            set
            {
                this._PassWord = value;
            }
        }
        public string RealName
        {
            get
            {
                return this._RealName;
            }
            set
            {
                this._RealName = value;
            }
        }
        public int Sex
        {
            get
            {
                return this._Sex;
            }
            set
            {
                this._Sex = value;
            }
        }
        public string Birthday
        {
            get
            {
                return this._Birthday;
            }
            set
            {
                this._Birthday = value;
            }
        }
        public string Phone
        {
            get
            {
                return this._Phone;
            }
            set
            {
                this._Phone = value;
            }
        }
        public string Tel
        {
            get
            {
                return this._Tel;
            }
            set
            {
                this._Tel = value;
            }
        }
        public int RoleID
        {
            get
            {
                return this._RoleID;
            }
            set
            {
                this._RoleID = value;
            }
        }
        public string RoleGUID
        {
            get
            {
                return this._RoleGUID;
            }
            set
            {
                this._RoleGUID = value;
            }
        }
        public int DepID
        {
            get
            {
                return this._DepID;
            }
            set
            {
                this._DepID = value;
            }
        }
        public string DepGUID
        {
            get
            {
                return this._DepGUID;
            }
            set
            {
                this._DepGUID = value;
            }
        }
        public string DepName
        {
            get
            {
                return this._DepName;
            }
            set
            {
                this._DepName = value;
            }
        }
        public string LastLoginIp
        {
            get
            {
                return this._LastLoginIp;
            }
            set
            {
                this._LastLoginIp = value;
            }
        }
        public DateTime LastLoginTime
        {
            get
            {
                return this._LastLoginTime;
            }
            set
            {
                this._LastLoginTime = value;
            }
        }
        public int LoginQuantity
        {
            get
            {
                return this._LoginQuantity;
            }
            set
            {
                this._LoginQuantity = value;
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
        public int IsLock
        {
            get
            {
                return this._IsLock;
            }
            set
            {
                this._IsLock = value;
            }
        }
        public string RegFromIp
        {
            get
            {
                return this._RegFromIp;
            }
            set
            {
                this._RegFromIp = value;
            }
        }
        public DateTime RegTime
        {
            get
            {
                return this._RegTime;
            }
            set
            {
                this._RegTime = value;
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
        public string ComGUID
        {
            get
            {
                return this._ComGUID;
            }
            set
            {
                this._ComGUID = value;
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
        public Sys_UserInfo()
        {
            this._guid = Guid.NewGuid().ToString("N");
        }
        public Sys_UserInfo(int id, string guid, string UserName, string PassWord, string RealName, int Sex, string Birthday, string Phone, int RoleID, string RoleGUID, int DepID, string DepGUID, string DepName, string LastLoginIp, DateTime LastLoginTime, int LoginQuantity, int Status, int IsLock, string RegFromIp, DateTime RegTime, int ComID, string ComGUID, string Notes)
        {
            this._id = id;
            this._guid = guid;
            this._UserName = UserName;
            this._PassWord = PassWord;
            this._RealName = RealName;
            this._Sex = Sex;
            this._Birthday = Birthday;
            this._Phone = Phone;
            this._RoleID = RoleID;
            this._RoleGUID = RoleGUID;
            this._DepID = DepID;
            this._DepGUID = DepGUID;
            this._DepName = DepName;
            this._LastLoginIp = LastLoginIp;
            this._LastLoginTime = LastLoginTime;
            this._LoginQuantity = LoginQuantity;
            this._Status = Status;
            this._IsLock = IsLock;
            this._RegFromIp = RegFromIp;
            this._RegTime = RegTime;
            this._ComID = ComID;
            this._ComGUID = ComGUID;
            this._Notes = Notes;
        }
    }
}
