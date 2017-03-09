using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using OurHome.EntityFramework;

namespace OurHome.Migrator
{
    [DependsOn(typeof(OurHomeDataModule))]
    public class OurHomeMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<OurHomeDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}