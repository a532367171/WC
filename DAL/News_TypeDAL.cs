using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class News_TypeDAL : INews_Type
    {
        private EntityControl control;
        public News_TypeDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(News_TypeInfo News_Type_)
        {
            this.control.AddEntity(News_Type_);
        }
        public void Update(News_TypeInfo News_Type_)
        {
            this.control.UpdateEntity(News_Type_, News_Type_.id);
        }
        public void Delete(int id)
        {
            News_TypeInfo news_TypeInfo = new News_TypeInfo();
            news_TypeInfo.id = id;
            this.control.DeleteEntity(news_TypeInfo);
        }
        public News_TypeInfo GetById(int id)
        {
            return (News_TypeInfo)this.control.GetEntity("WC.Model.News_TypeInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.News_TypeInfo", where, orderBy);
        }
    }
}
