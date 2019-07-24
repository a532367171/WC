using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
	public class VoteDetailDAL : IVoteDetail
	{
		private EntityControl control;
		public VoteDetailDAL()
		{
			this.control = EntityControl.CreateEntityControl("WC.Model");
		}
		public void Add(VoteDetailInfo VoteDetail_)
		{
			this.control.AddEntity(VoteDetail_);
		}
		public void Update(VoteDetailInfo VoteDetail_)
		{
			this.control.UpdateEntity(VoteDetail_, VoteDetail_.id);
		}
		public void Delete(int id)
		{
			VoteDetailInfo voteDetailInfo = new VoteDetailInfo();
			voteDetailInfo.id = id;
			this.control.DeleteEntity(voteDetailInfo);
		}
		public VoteDetailInfo GetById(int id)
		{
			return (VoteDetailInfo)this.control.GetEntity("WC.Model.VoteDetailInfo", "id", id.ToString());
		}
		public IList GetAll(string where, string orderBy)
		{
			if (!Utils.CheckSql(where))
			{
				throw new Exception("sql注入非法字符串! -- " + where);
			}
			return this.control.GetEntities("WC.Model.VoteDetailInfo", where, orderBy);
		}
	}
}
