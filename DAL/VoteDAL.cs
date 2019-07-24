using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
	public class VoteDAL : IVote
	{
		private EntityControl control;
		public VoteDAL()
		{
			this.control = EntityControl.CreateEntityControl("WC.Model");
		}
		public void Add(VoteInfo Vote_)
		{
			this.control.AddEntity(Vote_);
		}
		public void Update(VoteInfo Vote_)
		{
			this.control.UpdateEntity(Vote_, Vote_.id);
		}
		public void Delete(int id)
		{
			VoteInfo voteInfo = new VoteInfo();
			voteInfo.id = id;
			this.control.DeleteEntity(voteInfo);
		}
		public VoteInfo GetById(int id)
		{
			return (VoteInfo)this.control.GetEntity("WC.Model.VoteInfo", "id", id.ToString());
		}
		public IList GetAll(string where, string orderBy)
		{
			if (!Utils.CheckSql(where))
			{
				throw new Exception("sql注入非法字符串! -- " + where);
			}
			return this.control.GetEntities("WC.Model.VoteInfo", where, orderBy);
		}
	}
}
