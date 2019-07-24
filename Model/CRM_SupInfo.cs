using System;
namespace WC.Model
{
	[Serializable]
	public class CRM_SupInfo
	{
		private int _id;
		private string _guid;
		private int _CreatorID;
		private string _CreatorRealName;
		private string _CreatorDepName;
		private string _Sup_Name;
		private string _MainPeople;
		private string _Tel;
		private string _Addr;
		private string _Notes;
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
		public string Sup_Name
		{
			get
			{
				return this._Sup_Name;
			}
			set
			{
				this._Sup_Name = value;
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
		public string Addr
		{
			get
			{
				return this._Addr;
			}
			set
			{
				this._Addr = value;
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
		public CRM_SupInfo()
		{
			this._guid = Guid.NewGuid().ToString("N");
		}
	}
}
