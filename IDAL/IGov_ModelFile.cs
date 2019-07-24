using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IGov_ModelFile
    {
        void Add(Gov_ModelFileInfo com);
        void Update(Gov_ModelFileInfo com);
        void Delete(int id);
        Gov_ModelFileInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
