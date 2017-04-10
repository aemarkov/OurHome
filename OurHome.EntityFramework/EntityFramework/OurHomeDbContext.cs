using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using OurHome.Authorization.Roles;
using OurHome.Domain;
using OurHome.Domain.Directories;
using OurHome.MultiTenancy;
using OurHome.Users;

namespace OurHome.EntityFramework
{
    public class OurHomeDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public OurHomeDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in OurHomeDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of OurHomeDbContext since ABP automatically handles it.
         */
        public OurHomeDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public OurHomeDbContext(DbConnection connection)
            : base(connection, true)
        {

        }

        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Registrator> Registrators { get; set; }
        public IDbSet<ResourceType> ResourceTypes { get; set; }
        public IDbSet<City> Cities { get; set; }
        public IDbSet<News> News { get; set; }

        public IDbSet<ResourceConsumption> ConsumptionHistory { get; set; }
    }
}
