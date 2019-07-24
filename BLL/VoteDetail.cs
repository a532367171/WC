using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
	public class VoteDetail
	{
		private static readonly IVoteDetail dal = DALFactory.CreateVoteDetailDAL();
		private VoteDetail()
		{
		}
		public static VoteDetail Init()
		{
			return new VoteDetail();
		}
		public void Add(VoteDetailInfo com)
		{
			VoteDetail.dal.Add(com);
		}
		public void Update(VoteDetailInfo com)
		{
			VoteDetail.dal.Update(com);
		}
		public void Delete(int id)
		{
			VoteDetail.dal.Delete(id);
		}
		public VoteDetailInfo GetById(int id)
		{
			return VoteDetail.dal.GetById(id);
		}
		public IList GetAll(string where, string orderBy)
		{
			return VoteDetail.dal.GetAll(where, orderBy);
		}
	}
}
