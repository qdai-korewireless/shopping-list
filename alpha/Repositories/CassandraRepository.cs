using System;
using Cassandra;

namespace alpha.Repositories
{
    public class CassandraRepository
    {
        private readonly Cluster myCassandraCluster = null;

        public CassandraRepository()
        {
            myCassandraCluster = Cluster.Builder().AddContactPoint("localhost").Build();
        }

    }
}
