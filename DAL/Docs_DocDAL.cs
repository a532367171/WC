using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Docs_DocDAL : IDocs_Doc
    {
        private EntityControl control;
        public Docs_DocDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Docs_DocInfo Docs_Doc_)
        {
            this.control.AddEntity(Docs_Doc_);
        }
        public void Update(Docs_DocInfo Docs_Doc_)
        {
            this.control.UpdateEntity(Docs_Doc_, Docs_Doc_.id);
        }
        public void Delete(int id)
        {
            Docs_DocInfo docs_DocInfo = new Docs_DocInfo();
            docs_DocInfo.id = id;
            this.control.DeleteEntity(docs_DocInfo);
        }
        public Docs_DocInfo GetById(int id)
        {
            return (Docs_DocInfo)this.control.GetEntity("WC.Model.Docs_DocInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Docs_DocInfo", where, orderBy);
        }
    }
}
