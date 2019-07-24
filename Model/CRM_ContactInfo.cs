using System;
namespace WC.Model
{
	[Serializable]
	public class CRM_ContactInfo
	{
		private int _id;
		private string _guid;
		private int _cid;
		private int _CreatorID;
		private string _CreatorRealName;
		private string _CreatorDepName;
		private DateTime _AddTime;
		private string _ContactAim;
		private string _ContactCharge;
		private string _ContactChargeType;
		private string _ContactType;
		private string _ContactState;
		private string _ContactDetail;
		private string _ContactPeople;
		private string _CRM_Name;
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
		public string CRM_Name
		{
			get
			{
				return this._CRM_Name;
			}
			set
			{
				this._CRM_Name = value;
			}
		}
		public int cid
		{
			get
			{
				return this._cid;
			}
			set
			{
				this._cid = value;
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
		public string ContactAim
		{
			get
			{
				return this._ContactAim;
			}
			set
			{
				this._ContactAim = value;
			}
		}
		public string ContactCharge
		{
			get
			{
				return this._ContactCharge;
			}
			set
			{
				this._ContactCharge = value;
			}
		}
		public string ContactChargeType
		{
			get
			{
				return this._ContactChargeType;
			}
			set
			{
				this._ContactChargeType = value;
			}
		}
		public string ContactType
		{
			get
			{
				return this._ContactType;
			}
			set
			{
				this._ContactType = value;
			}
		}
		public string ContactState
		{
			get
			{
				return this._ContactState;
			}
			set
			{
				this._ContactState = value;
			}
		}
		public string ContactDetail
		{
			get
			{
				return this._ContactDetail;
			}
			set
			{
				this._ContactDetail = value;
			}
		}
		public string ContactPeople
		{
			get
			{
				return this._ContactPeople;
			}
			set
			{
				this._ContactPeople = value;
			}
		}
		public CRM_ContactInfo()
		{
			this._guid = Guid.NewGuid().ToString("N");
		}
	}
}
