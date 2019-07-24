using System;
namespace WC.Model
{
	[Serializable]
	public class CRMInfo
	{
		private int _id;
		private string _guid;
		private int _CreatorID;
		private string _CreatorRealName;
		private string _CreatorDepName;
		private string _CRM_Name;
		private string _Tel;
		private string _Fax;
		private string _Zip;
		private string _Address;
		private string _MainPeople;
		private string _Position;
		private string _Product;
		private string _Grade;
		private string _TypeName;
		private string _Notes;
		private string _FilePath;
		private int _IsShare;
		private string _ShareUsers;
		private string _namelist;
		private DateTime _AddTime;
		private DateTime _UpdateTime;
		private string _QQ;
		private string _Site;
		private string _Email;
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
		public string Fax
		{
			get
			{
				return this._Fax;
			}
			set
			{
				this._Fax = value;
			}
		}
		public string Zip
		{
			get
			{
				return this._Zip;
			}
			set
			{
				this._Zip = value;
			}
		}
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				this._Address = value;
			}
		}
		public string MainPeople
		{
			get
			{
				return this._MainPeople;
			}
			set
			{
				this._MainPeople = value;
			}
		}
		public string Position
		{
			get
			{
				return this._Position;
			}
			set
			{
				this._Position = value;
			}
		}
		public string Product
		{
			get
			{
				return this._Product;
			}
			set
			{
				this._Product = value;
			}
		}
		public string Grade
		{
			get
			{
				return this._Grade;
			}
			set
			{
				this._Grade = value;
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
		public int IsShare
		{
			get
			{
				return this._IsShare;
			}
			set
			{
				this._IsShare = value;
			}
		}
		public string ShareUsers
		{
			get
			{
				return this._ShareUsers;
			}
			set
			{
				this._ShareUsers = value;
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
		public DateTime UpdateTime
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
		public string Site
		{
			get
			{
				return this._Site;
			}
			set
			{
				this._Site = value;
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
		public CRMInfo()
		{
			this._guid = Guid.NewGuid().ToString("N");
		}
	}
}
