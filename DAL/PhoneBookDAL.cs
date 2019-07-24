using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class PhoneBookDAL : IPhoneBook
    {
        private EntityControl control;
        public PhoneBookDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(PhoneBookInfo PhoneBook_)
        {
            this.control.AddEntity(PhoneBook_);
        }
        public void Update(PhoneBookInfo PhoneBook_)
        {
            this.control.UpdateEntity(PhoneBook_, PhoneBook_.id);
        }
        public void Delete(int id)
        {
            PhoneBookInfo phoneBookInfo = new PhoneBookInfo();
            phoneBookInfo.id = id;
            this.control.DeleteEntity(phoneBookInfo);
        }
        public PhoneBookInfo GetById(int id)
        {
            return (PhoneBookInfo)this.control.GetEntity("WC.Model.PhoneBookInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.PhoneBookInfo", where, orderBy);
        }
    }
}
