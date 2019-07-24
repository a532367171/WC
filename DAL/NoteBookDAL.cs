using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class NoteBookDAL : INoteBook
    {
        private EntityControl control;
        public NoteBookDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(NoteBookInfo NoteBook_)
        {
            this.control.AddEntity(NoteBook_);
        }
        public void Update(NoteBookInfo NoteBook_)
        {
            this.control.UpdateEntity(NoteBook_, NoteBook_.id);
        }
        public void Delete(int id)
        {
            NoteBookInfo noteBookInfo = new NoteBookInfo();
            noteBookInfo.id = id;
            this.control.DeleteEntity(noteBookInfo);
        }
        public NoteBookInfo GetById(int id)
        {
            return (NoteBookInfo)this.control.GetEntity("WC.Model.NoteBookInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.NoteBookInfo", where, orderBy);
        }
    }
}
