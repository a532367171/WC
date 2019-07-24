using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Gov_ModelFileDAL : IGov_ModelFile
    {
        private EntityControl control;
        public Gov_ModelFileDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Gov_ModelFileInfo Gov_ModelFile_)
        {
            this.control.AddEntity(Gov_ModelFile_);
        }
        public void Update(Gov_ModelFileInfo Gov_ModelFile_)
        {
            this.control.UpdateEntity(Gov_ModelFile_, Gov_ModelFile_.id);
        }
        public void Delete(int id)
        {
            Gov_ModelFileInfo gov_ModelFileInfo = new Gov_ModelFileInfo();
            gov_ModelFileInfo.id = id;
            this.control.DeleteEntity(gov_ModelFileInfo);
        }
        public Gov_ModelFileInfo GetById(int id)
        {
            return (Gov_ModelFileInfo)this.control.GetEntity("WC.Model.Gov_ModelFileInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Gov_ModelFileInfo", where, orderBy);
        }
    }
}
