using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Sys_ModuleDAL : ISys_Module
    {
        private EntityControl control;
        public Sys_ModuleDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Sys_ModuleInfo Sys_Module)
        {
            this.control.AddEntity(Sys_Module);
        }
        public void Update(Sys_ModuleInfo Sys_Module)
        {
            this.control.UpdateEntity(Sys_Module, Sys_Module.id);
        }
        public void Delete(int id)
        {
            if (true)
            {
            }
            Sys_ModuleInfo sys_ModuleInfo = new Sys_ModuleInfo();
            sys_ModuleInfo.id = id;
            this.control.DeleteEntity(sys_ModuleInfo);
        }
        public Sys_ModuleInfo GetById(int id)
        {
            if (true)
            {
            }
            return (Sys_ModuleInfo)this.control.GetEntity("WC.Model.Sys_ModuleInfo", "id", id.ToString());
        }
        //public IList GetAll(string where, string orderBy)
        //{
        //    IList entities;
        //    while (true)
        //    {
        //        bool flag = Utils.CheckSql(where);
        //        int num = 1;
        //        while (true)
        //        {
        //            switch (num)
        //            {
        //                case 0:
        //                    goto IL_58;
        //                case 1:
        //                    if (!flag)
        //                    {
        //                        num = 2;
        //                        continue;
        //                    }
        //                    entities = this.control.GetEntities("WC.Model.Sys_ModuleInfo", where, orderBy);
        //                    num = 0;
        //                    continue;
        //                case 2:
        //                    goto IL_38;
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
                entities = this.control.GetEntities("WC.Model.Sys_ModuleInfo", where, orderBy);
            }
            else
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return entities;
        }

    }
}
