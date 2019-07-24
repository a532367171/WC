using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IPaperDownload
    {
        void Add(PaperDownloadInfo com);
        void Update(PaperDownloadInfo com);
        void Delete(int id);
        PaperDownloadInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
