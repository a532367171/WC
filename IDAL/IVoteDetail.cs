using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
	public interface IVoteDetail
	{
		void Add(VoteDetailInfo com);
		void Update(VoteDetailInfo com);
		void Delete(int id);
		VoteDetailInfo GetById(int id);
		IList GetAll(string where, string orderBy);
	}
}
