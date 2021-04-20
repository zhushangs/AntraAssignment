using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise3
{
    interface IRepository<T> where T : class
    {
        void Insert(T item);
        void Update(T item);
        List<T> Search(string text);
        List<T> GetAll();
        void GetSorted();
        T GetByDate(string date);
        void Delete(string date);

    }
}
