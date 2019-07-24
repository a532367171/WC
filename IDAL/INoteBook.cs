using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface INoteBook
    {
        void Add(NoteBookInfo com);
        void Update(NoteBookInfo com);
        void Delete(int id);
        NoteBookInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
