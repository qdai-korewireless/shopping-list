using System;
using System.Collections.Generic;
using Cassandra;

namespace alpha.Repositories
{
    public interface IRepository<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
