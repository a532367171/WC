using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class ZEX2DAL : IZEX2
    {
        private EntityControl control;
        public ZEX2DAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(ZEX2Info ZEX2_)
        {
            this.control.AddEntity(ZEX2_);
        }
        public void Update(ZEX2Info ZEX2_)
        {
            this.control.UpdateEntity(ZEX2_, ZEX2_.id);
        }
        public void Delete(int id)
        {
            ZEX2Info zEX2Info = new ZEX2Info();
            zEX2Info.id = id;
            this.control.DeleteEntity(zEX2Info);
        }
        public ZEX2Info GetById(int id)
        {
            return (ZEX2Info)this.control.GetEntity("WC.Model.ZEX2Info", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.ZEX2Info", where, orderBy);
        }
    }
}
