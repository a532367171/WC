using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
	public class CRM_Sup
	{
		private static readonly ICRM_Sup dal = DALFactory.CreateCRM_SupDAL();
		private CRM_Sup()
		{
		}
		public static CRM_Sup Init()
		{
			return new CRM_Sup();
		}
		public void Add(CRM_SupInfo com)
		{
			CRM_Sup.dal.Add(com);
		}
		public void Update(CRM_SupInfo com)
		{
			CRM_Sup.dal.Update(com);
		}
		public void Delete(int id)
		{
			CRM_Sup.dal.Delete(id);
		}
		public CRM_SupInfo GetById(int id)
		{
			return CRM_Sup.dal.GetById(id);
		}
		public IList GetAll(string where, string orderBy)
		{
			return CRM_Sup.dal.GetAll(where, orderBy);
		}
	}
}
