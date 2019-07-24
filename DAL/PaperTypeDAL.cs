using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class PaperTypeDAL : IPaperType
    {
        private EntityControl control;
        public PaperTypeDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(PaperTypeInfo PaperType_)
        {
            this.control.AddEntity(PaperType_);
        }
        public void Update(PaperTypeInfo PaperType_)
        {
            this.control.UpdateEntity(PaperType_, PaperType_.id);
        }
        public void Delete(int id)
        {
            PaperTypeInfo paperTypeInfo = new PaperTypeInfo();
            paperTypeInfo.id = id;
            this.control.DeleteEntity(paperTypeInfo);
        }
        public PaperTypeInfo GetById(int id)
        {
            return (PaperTypeInfo)this.control.GetEntity("WC.Model.PaperTypeInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.PaperTypeInfo", where, orderBy);
        }
    }
}
