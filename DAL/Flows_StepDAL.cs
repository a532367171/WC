
using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
	public class Flows_StepDAL : IFlows_Step
	{
		private EntityControl control;
		public Flows_StepDAL()
		{
			this.control = EntityControl.CreateEntityControl("WC.Model");
		}
		public void Add(Flows_StepInfo Flows_Step_)
		{
			this.control.AddEntity(Flows_Step_);
		}
		public void Update(Flows_StepInfo Flows_Step_)
		{
			this.control.UpdateEntity(Flows_Step_, Flows_Step_.id);
		}
		public void Delete(int id)
		{
			Flows_StepInfo flows_StepInfo = new Flows_StepInfo();
			flows_StepInfo.id = id;
			this.control.DeleteEntity(flows_StepInfo);
		}
		public Flows_StepInfo GetById(int id)
		{
			return (Flows_StepInfo)this.control.GetEntity("WC.Model.Flows_StepInfo", "id", id.ToString());
		}
		public IList GetAll(string where, string orderBy)
		{
			if (!Utils.CheckSql(where))
			{
				throw new Exception("sql注入非法字符串! -- " + where);
			}
			return this.control.GetEntities("WC.Model.Flows_StepInfo", where, orderBy);
		}
	}
}
