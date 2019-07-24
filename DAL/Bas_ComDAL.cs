using System;
using System.Collections;
using WC.Common;
using WC.IDAL;
using WC.Model;
using WC.Tool;
namespace WC.DAL
{
    public class Bas_ComDAL : IBas_Com
    {
        private EntityControl control;
        public Bas_ComDAL()
        {
            this.control = EntityControl.CreateEntityControl("WC.Model");
        }
        public void Add(Bas_ComInfo Bas_Com)
        {
            this.control.AddEntity(Bas_Com);
        }
        public void Update(Bas_ComInfo Bas_Com)
        {
            this.control.UpdateEntity(Bas_Com, Bas_Com.id);
        }
        public void Delete(int id)
        {
            if (true)
            {
            }
            Bas_ComInfo bas_ComInfo = new Bas_ComInfo();
            bas_ComInfo.id = id;
            this.control.DeleteEntity(bas_ComInfo);
        }
        public Bas_ComInfo GetById(int id)
        {
            if (true)
            {
            }
            return (Bas_ComInfo)this.control.GetEntity("WC.Model.Bas_ComInfo", "id", id.ToString());
        }
        //public IList GetAll(string where, string orderBy)
        //{
        //    IList entities=new ArrayList();
        //    while (true)
        //    {
        //        bool flag = Utils.CheckSql(where);
        //        int num = 2;
        //        while (true)
        //        {
        //            switch (num)
        //            {
        //                case 0:
        //                    goto IL_58;
        //                case 1:
        //                    goto IL_38;
        //                case 2:
        //                    if (!flag)
        //                    {
        //                        num = 1;
        //                        continue;
        //                    }
        //                    entities = this.control.GetEntities("WC.Model.Bas_ComInfo", where, orderBy);
        //                    num = 0;
        //                    continue;
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
            if( Utils.CheckSql(where))
                  {           
                        entities = this.control.GetEntities("WC.Model.Bas_ComInfo", where, orderBy);               
                  }
            else
                  {
                         throw new Exception("sql注入非法字符串! -- " + where);
                  }
          return entities;
        }
    }
}
