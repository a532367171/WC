using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
	public class CRM_SupDAL : ICRM_Sup
	{
		private EntityControl control;
		public CRM_SupDAL()
		{
			this.control = EntityControl.CreateEntityControl("WC.Model");
		}
		public void Add(CRM_SupInfo CRM_Sup_)
		{
			this.control.AddEntity(CRM_Sup_);
		}
		public void Update(CRM_SupInfo CRM_Sup_)
		{
			this.control.UpdateEntity(CRM_Sup_, CRM_Sup_.id);
		}
		public void Delete(int id)
		{
			CRM_SupInfo cRM_SupInfo = new CRM_SupInfo();
			cRM_SupInfo.id = id;
			this.control.DeleteEntity(cRM_SupInfo);
		}
		public CRM_SupInfo GetById(int id)
		{
			return (CRM_SupInfo)this.control.GetEntity("WC.Model.CRM_SupInfo", "id", id.ToString());
		}
		public IList GetAll(string where, string orderBy)
		{
			if (!Utils.CheckSql(where))
			{
				throw new Exception("sql注入非法字符串! -- " + where);
			}
			return this.control.GetEntities("WC.Model.CRM_SupInfo", where, orderBy);
		}
	}
}
