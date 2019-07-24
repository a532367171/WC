using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class TipsDAL : ITips
    {
        private EntityControl control;
        public TipsDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(TipsInfo Tips_)
        {
            this.control.AddEntity(Tips_);
        }
        public void Update(TipsInfo Tips_)
        {
            this.control.UpdateEntity(Tips_, Tips_.id);
        }
        public void Delete(int id)
        {
            TipsInfo tipsInfo = new TipsInfo();
            tipsInfo.id = id;
            this.control.DeleteEntity(tipsInfo);
        }
        public TipsInfo GetById(int id)
        {
            return (TipsInfo)this.control.GetEntity("WC.Model.TipsInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.TipsInfo", where, orderBy);
        }
    }
}
