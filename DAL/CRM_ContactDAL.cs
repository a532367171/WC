using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
	public class CRM_ContactDAL : ICRM_Contact
	{
		private EntityControl control;
		public CRM_ContactDAL()
		{
			this.control = EntityControl.CreateEntityControl("WC.Model");
		}
		public void Add(CRM_ContactInfo CRM_Contact_)
		{
			this.control.AddEntity(CRM_Contact_);
		}
		public void Update(CRM_ContactInfo CRM_Contact_)
		{
			this.control.UpdateEntity(CRM_Contact_, CRM_Contact_.id);
		}
		public void Delete(int id)
		{
			CRM_ContactInfo cRM_ContactInfo = new CRM_ContactInfo();
			cRM_ContactInfo.id = id;
			this.control.DeleteEntity(cRM_ContactInfo);
		}
		public CRM_ContactInfo GetById(int id)
		{
			return (CRM_ContactInfo)this.control.GetEntity("WC.Model.CRM_ContactInfo", "id", id.ToString());
		}
		public IList GetAll(string where, string orderBy)
		{
			if (!Utils.CheckSql(where))
			{
				throw new Exception("sql注入非法字符串! -- " + where);
			}
			return this.control.GetEntities("WC.Model.CRM_ContactInfo", where, orderBy);
		}
	}
}
