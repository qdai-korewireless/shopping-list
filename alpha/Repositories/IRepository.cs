using System;
using System.Collections.Generic;
using Cassandra;

namespace alpha.Repositories
{
    public interface IRepository<T> where T : IIdentity
    {
        T Get(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetBy(string query, params object[] param);
        Guid Add(T item);
        void Update(T item);
        void Delete(T item);

    }

    public interface IIdentity{
        Guid Id { get; set; }
    }
}
