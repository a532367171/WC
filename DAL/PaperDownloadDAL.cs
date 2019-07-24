using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class PaperDownloadDAL : IPaperDownload
    {
        private EntityControl control;
        public PaperDownloadDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(PaperDownloadInfo PaperDownload_)
        {
            this.control.AddEntity(PaperDownload_);
        }
        public void Update(PaperDownloadInfo PaperDownload_)
        {
            this.control.UpdateEntity(PaperDownload_, PaperDownload_.id);
        }
        public void Delete(int id)
        {
            PaperDownloadInfo paperDownloadInfo = new PaperDownloadInfo();
            paperDownloadInfo.id = id;
            this.control.DeleteEntity(paperDownloadInfo);
        }
        public PaperDownloadInfo GetById(int id)
        {
            return (PaperDownloadInfo)this.control.GetEntity("WC.Model.PaperDownloadInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.PaperDownloadInfo", where, orderBy);
        }
    }
}
