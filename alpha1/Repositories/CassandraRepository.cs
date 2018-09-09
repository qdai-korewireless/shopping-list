using System;
using System.Collections.Generic;
using Cassandra.Mapping;

namespace alpha.Repositories
{

    public interface ICassandraRepository<T> : IRepository<T> where T : IIdentity
    {

    }

    public class CassandraRepository<T>: ICassandraRepository<T> where T: IIdentity
    {
        IMapper mapper;

        public CassandraRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Guid Add(T item)
        {
            item.Id = Guid.NewGuid();
            mapper.Insert(item);
            return item.Id;
        }

        public void Delete(T item)
        {
            mapper.Delete(item);
        }

        public T Get(Guid id)
        {
            var item = mapper.Single<T>("where id = ?", id);
            return item;
        }

        public IEnumerable<T> GetAll()
        {
            var items = mapper.Fetch<T>();
            return items;
        }

        public IEnumerable<T> GetBy(string query, params object[] param)
        {
            var items = mapper.Fetch<T>(query, param);
            return items;
        }

        public void Update(T item)
        {
            mapper.Update(item);
        }
    }
}
