using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
	public class CRM
	{
		private static readonly ICRM dal = DALFactory.CreateCRMDAL();
		private CRM()
		{
		}
		public static CRM Init()
		{
			return new CRM();
		}
		public void Add(CRMInfo com)
		{
			CRM.dal.Add(com);
		}
		public void Update(CRMInfo com)
		{
			CRM.dal.Update(com);
		}
		public void Delete(int id)
		{
			CRM.dal.Delete(id);
		}
		public CRMInfo GetById(int id)
		{
			return CRM.dal.GetById(id);
		}
		public IList GetAll(string where, string orderBy)
		{
			return CRM.dal.GetAll(where, orderBy);
		}
	}
}
