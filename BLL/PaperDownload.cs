using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class PaperDownload
    {
        private static readonly IPaperDownload dal = DALFactory.CreatePaperDownloadDAL();
        private PaperDownload()
        {
        }
        public static PaperDownload Init()
        {
            return new PaperDownload();
        }
        public void Add(PaperDownloadInfo com)
        {
            PaperDownload.dal.Add(com);
        }
        public void Update(PaperDownloadInfo com)
        {
            PaperDownload.dal.Update(com);
        }
        public void Delete(int id)
        {
            PaperDownload.dal.Delete(id);
        }
        public PaperDownloadInfo GetById(int id)
        {
            return PaperDownload.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return PaperDownload.dal.GetAll(where, orderBy);
        }
    }
}
