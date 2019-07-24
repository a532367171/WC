using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IGov_Model
    {
        void Add(Gov_ModelInfo com);
        void Update(Gov_ModelInfo com);
        void Delete(int id);
        Gov_ModelInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
