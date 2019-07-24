﻿using System;
using System.Collections;
using WC.Model;
namespace WC.IDAL
{
    public interface ITasks_User
    {
        void Add(Tasks_UserInfo com);
        void Update(Tasks_UserInfo com);
        void Delete(int id);
        Tasks_UserInfo GetById(int id);
        IList GetAll(string where, string orderBy);
    }
}
