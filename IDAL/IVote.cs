using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
	public interface IVote
	{
		void Add(VoteInfo com);
		void Update(VoteInfo com);
		void Delete(int id);
		VoteInfo GetById(int id);
		IList GetAll(string where, string orderBy);
	}
}
