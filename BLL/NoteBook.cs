using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class NoteBook
    {
        private static readonly INoteBook dal = DALFactory.CreateNoteBookDAL();
        private NoteBook()
        {
        }
        public static NoteBook Init()
        {
            return new NoteBook();
        }
        public void Add(NoteBookInfo com)
        {
            NoteBook.dal.Add(com);
        }
        public void Update(NoteBookInfo com)
        {
            NoteBook.dal.Update(com);
        }
        public void Delete(int id)
        {
            NoteBook.dal.Delete(id);
        }
        public NoteBookInfo GetById(int id)
        {
            return NoteBook.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return NoteBook.dal.GetAll(where, orderBy);
        }
    }
}
