using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
	public interface ICRM_Contact
	{
		void Add(CRM_ContactInfo com);
		void Update(CRM_ContactInfo com);
		void Delete(int id);
		CRM_ContactInfo GetById(int id);
		IList GetAll(string where, string orderBy);
	}
}
