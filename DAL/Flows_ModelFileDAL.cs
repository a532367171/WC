using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Flows_ModelFileDAL : IFlows_ModelFile
    {
        private EntityControl control;
        public Flows_ModelFileDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Flows_ModelFileInfo Flows_ModelFile_)
        {
            this.control.AddEntity(Flows_ModelFile_);
        }
        public void Update(Flows_ModelFileInfo Flows_ModelFile_)
        {
            this.control.UpdateEntity(Flows_ModelFile_, Flows_ModelFile_.id);
        }
        public void Delete(int id)
        {
            Flows_ModelFileInfo flows_ModelFileInfo = new Flows_ModelFileInfo();
            flows_ModelFileInfo.id = id;
            this.control.DeleteEntity(flows_ModelFileInfo);
        }
        public Flows_ModelFileInfo GetById(int id)
        {
            return (Flows_ModelFileInfo)this.control.GetEntity("WC.Model.Flows_ModelFileInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            if (!Utils.CheckSql(where))
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return this.control.GetEntities("WC.Model.Flows_ModelFileInfo", where, orderBy);
        }
    }
}
