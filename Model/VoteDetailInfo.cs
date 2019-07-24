using System;
namespace WC.Model
{
	[Serializable]
	public class VoteDetailInfo
	{
		private int _id;
		private string _guid;
		private int _VoteID;
		private string _ItemName;
		private int _VoteUserID;
		private string _VoteRealName;
		private string _VoteDepName;
		private DateTime _AddTime;
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
		public int VoteID
		{
			get
			{
				return this._VoteID;
			}
			set
			{
				this._VoteID = value;
			}
		}
		public string ItemName
		{
			get
			{
				return this._ItemName;
			}
			set
			{
				this._ItemName = value;
			}
		}
		public int VoteUserID
		{
			get
			{
				return this._VoteUserID;
			}
			set
			{
				this._VoteUserID = value;
			}
		}
		public string VoteRealName
		{
			get
			{
				return this._VoteRealName;
			}
			set
			{
				this._VoteRealName = value;
			}
		}
		public string VoteDepName
		{
			get
			{
				return this._VoteDepName;
			}
			set
			{
				this._VoteDepName = value;
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
		public VoteDetailInfo()
		{
			this._guid = Guid.NewGuid().ToString("N");
		}
	}
}
