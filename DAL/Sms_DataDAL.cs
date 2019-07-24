using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Sms_DataDAL : ISms_Data
    {
        private EntityControl control;
        public Sms_DataDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Sms_DataInfo Sms_Data_)
        {
            this.control.AddEntity(Sms_Data_);
        }
        public void Update(Sms_DataInfo Sms_Data_)
        {
            this.control.UpdateEntity(Sms_Data_, Sms_Data_.id);
        }
        public void Delete(int id)
        {
            Sms_DataInfo sms_DataInfo = new Sms_DataInfo();
            sms_DataInfo.id = id;
            this.control.DeleteEntity(sms_DataInfo);
        }
        public Sms_DataInfo GetById(int id)
        {
            return (Sms_DataInfo)this.control.GetEntity("WC.Model.Sms_DataInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Sms_DataInfo", where, orderBy);
        }
    }
}
