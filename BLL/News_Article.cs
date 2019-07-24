using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class News_Article
    {
        private static readonly INews_Article dal = DALFactory.CreateNews_ArticleDAL();
        private News_Article()
        {
        }
        public static News_Article Init()
        {
            return new News_Article();
        }
        public void Add(News_ArticleInfo com)
        {
            News_Article.dal.Add(com);
        }
        public void Update(News_ArticleInfo com)
        {
            News_Article.dal.Update(com);
        }
        public void Delete(int id)
        {
            News_Article.dal.Delete(id);
        }
        public News_ArticleInfo GetById(int id)
        {
            return News_Article.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return News_Article.dal.GetAll(where, orderBy);
        }
    }
}
