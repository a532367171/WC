using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Flows_DocDAL : IFlows_Doc
    {
        private EntityControl control;
        public Flows_DocDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Flows_DocInfo Flows_Doc_)
        {
            this.control.AddEntity(Flows_Doc_);
        }
        public void Update(Flows_DocInfo Flows_Doc_)
        {
            this.control.UpdateEntity(Flows_Doc_, Flows_Doc_.id);
        }
        public void Delete(int id)
        {
            Flows_DocInfo flows_DocInfo = new Flows_DocInfo();
            flows_DocInfo.id = id;
            this.control.DeleteEntity(flows_DocInfo);
        }
        public Flows_DocInfo GetById(int id)
        {
            return (Flows_DocInfo)this.control.GetEntity("WC.Model.Flows_DocInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Flows_DocInfo", where, orderBy);
        }
    }
}
