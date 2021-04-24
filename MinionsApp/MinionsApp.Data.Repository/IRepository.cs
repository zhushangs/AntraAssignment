﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MinionsApp.Data.Repository
{
    public interface IRepository<T> where T:class
    {
        int Insert(T item);
        int Update(T item);
        int CallSP(T item);
        int Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);


    }
}
