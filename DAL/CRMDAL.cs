using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
	public class CRMDAL : ICRM
	{
		private EntityControl control;
		public CRMDAL()
		{
			this.control = EntityControl.CreateEntityControl("WC.Model");
		}
		public void Add(CRMInfo CRM_)
		{
			this.control.AddEntity(CRM_);
		}
		public void Update(CRMInfo CRM_)
		{
			this.control.UpdateEntity(CRM_, CRM_.id);
		}
		public void Delete(int id)
		{
			CRMInfo cRMInfo = new CRMInfo();
			cRMInfo.id = id;
			this.control.DeleteEntity(cRMInfo);
		}
		public CRMInfo GetById(int id)
		{
			return (CRMInfo)this.control.GetEntity("WC.Model.CRMInfo", "id", id.ToString());
		}
		public IList GetAll(string where, string orderBy)
		{
			if (!Utils.CheckSql(where))
			{
				throw new Exception("sql注入非法字符串! -- " + where);
			}
			return this.control.GetEntities("WC.Model.CRMInfo", where, orderBy);
		}
	}
}
