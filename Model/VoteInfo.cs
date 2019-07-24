using System;
namespace WC.Model
{
	[Serializable]
	public class VoteInfo
	{
		private int _id;
		private string _guid;
		private string _VoteTitle;
		private string _VoteContent;
		private int _IsValide;
		private int _IsMultiple;
		private int _ShowUser;
		private int _CreateUserID;
		private string _CreateRealName;
		private string _CreateDepName;
		private DateTime _AddTime;
		private string _userlist;
		private string _namelist;
		private string _VoteNotes;
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
		public string VoteNotes
		{
			get
			{
				return this._VoteNotes;
			}
			set
			{
				this._VoteNotes = value;
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
		public string VoteTitle
		{
			get
			{
				return this._VoteTitle;
			}
			set
			{
				this._VoteTitle = value;
			}
		}
		public string VoteContent
		{
			get
			{
				return this._VoteContent;
			}
			set
			{
				this._VoteContent = value;
			}
		}
		public int IsValide
		{
			get
			{
				return this._IsValide;
			}
			set
			{
				this._IsValide = value;
			}
		}
		public int IsMultiple
		{
			get
			{
				return this._IsMultiple;
			}
			set
			{
				this._IsMultiple = value;
			}
		}
		public int ShowUser
		{
			get
			{
				return this._ShowUser;
			}
			set
			{
				this._ShowUser = value;
			}
		}
		public int CreateUserID
		{
			get
			{
				return this._CreateUserID;
			}
			set
			{
				this._CreateUserID = value;
			}
		}
		public string CreateRealName
		{
			get
			{
				return this._CreateRealName;
			}
			set
			{
				this._CreateRealName = value;
			}
		}
		public string CreateDepName
		{
			get
			{
				return this._CreateDepName;
			}
			set
			{
				this._CreateDepName = value;
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
		public VoteInfo()
		{
			this._guid = Guid.NewGuid().ToString("N");
		}
	}
}
