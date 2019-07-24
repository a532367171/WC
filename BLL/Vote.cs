using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
	public class Vote
	{
		private static readonly IVote dal = DALFactory.CreateVoteDAL();
		private Vote()
		{
		}
		public static Vote Init()
		{
			return new Vote();
		}
		public void Add(VoteInfo com)
		{
			Vote.dal.Add(com);
		}
		public void Update(VoteInfo com)
		{
			Vote.dal.Update(com);
		}
		public void Delete(int id)
		{
			Vote.dal.Delete(id);
		}
		public VoteInfo GetById(int id)
		{
			return Vote.dal.GetById(id);
		}
		public IList GetAll(string where, string orderBy)
		{
			return Vote.dal.GetAll(where, orderBy);
		}
	}
}
