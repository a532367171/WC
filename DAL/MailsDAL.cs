using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class MailsDAL : IMails
    {
        private EntityControl control;
        public MailsDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(MailsInfo Mails_)
        {
            this.control.AddEntity(Mails_);
        }
        public void Update(MailsInfo Mails_)
        {
            this.control.UpdateEntity(Mails_, Mails_.id);
        }
        public void Delete(int id)
        {
            MailsInfo mailsInfo = new MailsInfo();
            mailsInfo.id = id;
            this.control.DeleteEntity(mailsInfo);
        }
        public MailsInfo GetById(int id)
        {
            return (MailsInfo)this.control.GetEntity("WC.Model.MailsInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.MailsInfo", where, orderBy);
        }
    }
}
