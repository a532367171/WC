using System;
using System.Collections;
using WC.Factory;
using WC.IDAL;
using WC.Model;
namespace WC.BLL
{
    public class Flows_ModelFile
    {
        private static readonly IFlows_ModelFile dal = DALFactory.CreateFlows_ModelFileDAL();
        private Flows_ModelFile()
        {
        }
        public static Flows_ModelFile Init()
        {
            return new Flows_ModelFile();
        }
        public void Add(Flows_ModelFileInfo com)
        {
            Flows_ModelFile.dal.Add(com);
        }
        public void Update(Flows_ModelFileInfo com)
        {
            Flows_ModelFile.dal.Update(com);
        }
        public void Delete(int id)
        {
            Flows_ModelFile.dal.Delete(id);
        }
        public Flows_ModelFileInfo GetById(int id)
        {
            return Flows_ModelFile.dal.GetById(id);
        }
        public IList GetAll(string where, string orderBy)
        {
            return Flows_ModelFile.dal.GetAll(where, orderBy);
        }
    }
}
