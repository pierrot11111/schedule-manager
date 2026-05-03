using System;
using System.Collections.Generic;

namespace pr1
{
    public interface IRepository<T>
    {
        void Add(T item);
        bool Delete(T item);
        IEnumerable<T> GetAll();
        T? Find(Predicate<T> predicate);
    }
}