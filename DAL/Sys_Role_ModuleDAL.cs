using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Sys_Role_ModuleDAL : ISys_Role_Module
    {
        private EntityControl control;
        public Sys_Role_ModuleDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Sys_Role_ModuleInfo Sys_Role_Module)
        {
            this.control.AddEntity(Sys_Role_Module);
        }
        public void Update(Sys_Role_ModuleInfo Sys_Role_Module)
        {
            this.control.UpdateEntity(Sys_Role_Module, Sys_Role_Module.id);
        }
        public void Delete(int id)
        {
            if (true)
            {
            }
            Sys_Role_ModuleInfo sys_Role_ModuleInfo = new Sys_Role_ModuleInfo();
            sys_Role_ModuleInfo.id = id;
            this.control.DeleteEntity(sys_Role_ModuleInfo);
        }
        public Sys_Role_ModuleInfo GetById(int id)
        {
            if (true)
            {
            }
            return (Sys_Role_ModuleInfo)this.control.GetEntity("WC.Model.Sys_Role_ModuleInfo", "id", id.ToString());
        }
        //public IList GetAll(string where, string orderBy)
        //{
        //    IList entities;
        //    while (true)
        //    {
        //        bool flag = Utils.CheckSql(where);
        //        int num = 0;
        //        while (true)
        //        {
        //            switch (num)
        //            {
        //                case 0:
        //                    if (!flag)
        //                    {
        //                        num = 1;
        //                        continue;
        //                    }
        //                    entities = this.control.GetEntities("WC.Model.Sys_Role_ModuleInfo", where, orderBy);
        //                    num = 2;
        //                    continue;
        //                case 1:
        //                    goto IL_38;
        //                case 2:
        //                    goto IL_58;
        //            }
        //            break;
        //        }
        //    }
        //IL_38:
        //    throw new Exception("sql注入非法字符串! -- " + where);
        //IL_58:
        //    if (true)
        //    {
        //    }
        //    return entities;
        //}

        public IList GetAll(string where, string orderBy)
        {
            IList entities = new ArrayList();
            if (Utils.CheckSql(where))
            {
                entities = this.control.GetEntities("WC.Model.Sys_Role_ModuleInfo", where, orderBy);
            }
            else
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return entities;
        }

    }
}
