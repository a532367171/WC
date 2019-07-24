using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Gov_ModelFile
    {
        private static readonly IGov_ModelFile dal = DALFactory.CreateGov_ModelFileDAL();
        private Gov_ModelFile()
        {
        }
        public static Gov_ModelFile Init()
        {
            return new Gov_ModelFile();
        }
        public void Add(Gov_ModelFileInfo com)
        {
            Gov_ModelFile.dal.Add(com);
        }
        public void Update(Gov_ModelFileInfo com)
        {
            Gov_ModelFile.dal.Update(com);
        }
        public void Delete(int id)
        {
            Gov_ModelFile.dal.Delete(id);
        }
        public Gov_ModelFileInfo GetById(int id)
        {
            return Gov_ModelFile.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Gov_ModelFile.dal.GetAll(where, orderBy);
        }
    }
}
