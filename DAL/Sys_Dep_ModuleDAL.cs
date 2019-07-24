using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Sys_Dep_ModuleDAL : ISys_Dep_Module
    {
        private EntityControl control;
        public Sys_Dep_ModuleDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Sys_Dep_ModuleInfo Sys_Dep_Module)
        {
            this.control.AddEntity(Sys_Dep_Module);
        }
        public void Update(Sys_Dep_ModuleInfo Sys_Dep_Module)
        {
            this.control.UpdateEntity(Sys_Dep_Module, Sys_Dep_Module.id);
        }
        public void Delete(int id)
        {
            if (true)
            {
            }
            Sys_Dep_ModuleInfo sys_Dep_ModuleInfo = new Sys_Dep_ModuleInfo();
            sys_Dep_ModuleInfo.id = id;
            this.control.DeleteEntity(sys_Dep_ModuleInfo);
        }
        public Sys_Dep_ModuleInfo GetById(int id)
        {
            if (true)
            {
            }
            return (Sys_Dep_ModuleInfo)this.control.GetEntity("WC.Model.Sys_Dep_ModuleInfo", "id", id.ToString());
        }
        public IList GetAll(string where, string orderBy)
        {
            IList entities=null ;
            while (true)
            {
                bool flag = Utils.CheckSql(where);
                int num = 0;
                while (true)
                {
                    switch (num)
                    {
                        case 0:
                            if (!flag)
                            {
                                num = 2;
                                continue;
                            }
                            entities = this.control.GetEntities("WC.Model.Sys_Dep_ModuleInfo", where, orderBy);
                            num = 1;
                            continue;
                        case 1:
                            goto IL_58;
                        case 2:
                            goto IL_38;
                    }
                    break;
                }
            }
        IL_38:
            throw new Exception("sql注入非法字符串! -- " + where);
        IL_58:
            if (true)
            {
            }
            return entities;
        }
    }
}
