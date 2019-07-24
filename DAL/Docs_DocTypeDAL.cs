using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Docs_DocTypeDAL : IDocs_DocType
    {
        private EntityControl control;
        public Docs_DocTypeDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Docs_DocTypeInfo Docs_DocType_)
        {
            this.control.AddEntity(Docs_DocType_);
        }
        public void Update(Docs_DocTypeInfo Docs_DocType_)
        {
            this.control.UpdateEntity(Docs_DocType_, Docs_DocType_.id);
        }
        public void Delete(int id)
        {
            Docs_DocTypeInfo docs_DocTypeInfo = new Docs_DocTypeInfo();
            docs_DocTypeInfo.id = id;
            this.control.DeleteEntity(docs_DocTypeInfo);
        }
        public Docs_DocTypeInfo GetById(int id)
        {
            return (Docs_DocTypeInfo)this.control.GetEntity("WC.Model.Docs_DocTypeInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Docs_DocTypeInfo", where, orderBy);
        }
    }
}
