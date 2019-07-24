using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
	public interface ICRM_Sup
	{
		void Add(CRM_SupInfo com);
		void Update(CRM_SupInfo com);
		void Delete(int id);
		CRM_SupInfo GetById(int id);
		IList GetAll(string where, string orderBy);
	}
}
