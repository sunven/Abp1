using Abp.EntityFramework.EntityFramework;
using System.Data.Common;
using System.Threading.Tasks;

namespace Test.Abp.EntityFramework
{
    public class SimpleTaskSystemDbContext : AbpDbContext
    {

        public SimpleTaskSystemDbContext()
            : base("Default")
        {

        }

        public SimpleTaskSystemDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public SimpleTaskSystemDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
