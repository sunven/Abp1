using System.Data.Common;
using System.Data.Entity;

namespace Abp.EntityFramework.EntityFramework
{
    public class AbpDbContext : DbContext
    {
        private string v;
        private DbConnection connection;
        private bool v1;

        public AbpDbContext(string v)
        {
            this.v = v;
        }

        public AbpDbContext(DbConnection connection, bool v1)
        {
            this.connection = connection;
            this.v1 = v1;
        }
    }
}