using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class News_ArticleDAL : INews_Article
    {
        private EntityControl control;
        public News_ArticleDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(News_ArticleInfo News_Article_)
        {
            this.control.AddEntity(News_Article_);
        }
        public void Update(News_ArticleInfo News_Article_)
        {
            this.control.UpdateEntity(News_Article_, News_Article_.id);
        }
        public void Delete(int id)
        {
            News_ArticleInfo news_ArticleInfo = new News_ArticleInfo();
            news_ArticleInfo.id = id;
            this.control.DeleteEntity(news_ArticleInfo);
        }
        public News_ArticleInfo GetById(int id)
        {
            return (News_ArticleInfo)this.control.GetEntity("WC.Model.News_ArticleInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.News_ArticleInfo", where, orderBy);
        }
    }
}
