using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Sys_UserDAL : ISys_User
    {
        private EntityControl control;
        public Sys_UserDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Sys_UserInfo Sys_User)
        {
            this.control.AddEntity(Sys_User);
        }
        public void Update(Sys_UserInfo Sys_User)
        {
            this.control.UpdateEntity(Sys_User, Sys_User.id);
        }
        public void Delete(int id)
        {
            if (true)
            {
            }
            Sys_UserInfo sys_UserInfo = new Sys_UserInfo();
            sys_UserInfo.id = id;
            this.control.DeleteEntity(sys_UserInfo);
        }
        public Sys_UserInfo GetById(int id)
        {
            if (true)
            {
            }
            return (Sys_UserInfo)this.control.GetEntity("WC.Model.Sys_UserInfo", "id", id.ToString());
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
        //                    goto IL_38;
        //                case 1:
        //                    if (!flag)
        //                    {
        //                        num = 0;
        //                        continue;
        //                    }
        //                    entities = this.control.GetEntities("WC.Model.Sys_UserInfo", where, orderBy);
        //                    num = 2;
        //                    continue;
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
                entities = this.control.GetEntities("WC.Model.Sys_UserInfo", where, orderBy);
            }
            else
            {
                throw new Exception("sql注入非法字符串! -- " + where);
            }
            return entities;
        }



    }
}
