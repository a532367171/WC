﻿using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface IDocs_Doc
    {
        void Add(Docs_DocInfo com);
        void Update(Docs_DocInfo com);
        void Delete(int id);
        Docs_DocInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
