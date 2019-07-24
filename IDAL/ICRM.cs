using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
	public interface ICRM
	{
		void Add(CRMInfo com);
		void Update(CRMInfo com);
		void Delete(int id);
		CRMInfo GetById(int id);
		IList GetAll(string where, string orderBy);
	}
}
