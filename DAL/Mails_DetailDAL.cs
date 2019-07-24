using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Mails_DetailDAL : IMails_Detail
    {
        private EntityControl control;
        public Mails_DetailDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Mails_DetailInfo Mails_Detail_)
        {
            this.control.AddEntity(Mails_Detail_);
        }
        public void Update(Mails_DetailInfo Mails_Detail_)
        {
            this.control.UpdateEntity(Mails_Detail_, Mails_Detail_.id);
        }
        public void Delete(int id)
        {
            Mails_DetailInfo mails_DetailInfo = new Mails_DetailInfo();
            mails_DetailInfo.id = id;
            this.control.DeleteEntity(mails_DetailInfo);
        }
        public Mails_DetailInfo GetById(int id)
        {
            return (Mails_DetailInfo)this.control.GetEntity("WC.Model.Mails_DetailInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Mails_DetailInfo", where, orderBy);
        }
    }
}
