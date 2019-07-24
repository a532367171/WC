using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Gov_DocDAL : IGov_Doc
    {
        private EntityControl control;
        public Gov_DocDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Gov_DocInfo Gov_Doc_)
        {
            this.control.AddEntity(Gov_Doc_);
        }
        public void Update(Gov_DocInfo Gov_Doc_)
        {
            this.control.UpdateEntity(Gov_Doc_, Gov_Doc_.id);
        }
        public void Delete(int id)
        {
            Gov_DocInfo gov_DocInfo = new Gov_DocInfo();
            gov_DocInfo.id = id;
            this.control.DeleteEntity(gov_DocInfo);
        }
        public Gov_DocInfo GetById(int id)
        {
            return (Gov_DocInfo)this.control.GetEntity("WC.Model.Gov_DocInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Gov_DocInfo", where, orderBy);
        }
    }
}
