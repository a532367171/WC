using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class PaperDAL : IPaper
    {
        private EntityControl control;
        public PaperDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(PaperInfo Paper_)
        {
            this.control.AddEntity(Paper_);
        }
        public void Update(PaperInfo Paper_)
        {
            this.control.UpdateEntity(Paper_, Paper_.id);
        }
        public void Delete(int id)
        {
            PaperInfo paperInfo = new PaperInfo();
            paperInfo.id = id;
            this.control.DeleteEntity(paperInfo);
        }
        public PaperInfo GetById(int id)
        {
            return (PaperInfo)this.control.GetEntity("WC.Model.PaperInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.PaperInfo", where, orderBy);
        }
    }
}
