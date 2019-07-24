using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
	public class CRM_Contact
	{
		private static readonly ICRM_Contact dal = DALFactory.CreateCRM_ContactDAL();
		private CRM_Contact()
		{
		}
		public static CRM_Contact Init()
		{
			return new CRM_Contact();
		}
		public void Add(CRM_ContactInfo com)
		{
			CRM_Contact.dal.Add(com);
		}
		public void Update(CRM_ContactInfo com)
		{
			CRM_Contact.dal.Update(com);
		}
		public void Delete(int id)
		{
			CRM_Contact.dal.Delete(id);
		}
		public CRM_ContactInfo GetById(int id)
		{
			return CRM_Contact.dal.GetById(id);
		}
		public IList GetAll(string where, string orderBy)
		{
			return CRM_Contact.dal.GetAll(where, orderBy);
		}
	}
}
