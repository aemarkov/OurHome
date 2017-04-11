using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Dynamic;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using OurHome.Migrations.SeedData;
using EntityFramework.DynamicFilters;
using OurHome.Domain.Directories;
using OurHome.EntityFramework;

namespace OurHome.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<OurHome.EntityFramework.OurHomeDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OurHome";
        }

        protected override void Seed(OurHome.EntityFramework.OurHomeDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            CreateResourceTypes(context);

            context.SaveChanges();
        }

        //Создает типы ресурсов
        private void CreateResourceTypes(OurHomeDbContext ctx)
        {
            CreateResourceTypeIfNotExists(ctx, ResourceType.ELECTRICITY, "Электричество", "кВт/ч");
            CreateResourceTypeIfNotExists(ctx, ResourceType.GAS, "Газ", "м³");
            CreateResourceTypeIfNotExists(ctx, ResourceType.COLD_WATER, "Холодная вода", "м³");
            CreateResourceTypeIfNotExists(ctx, ResourceType.HOT_WATER, "Горячая вода", "м³");
        }

        //Создает запись справочника, если не существует
        private void CreateResourceTypeIfNotExists(OurHomeDbContext ctx, string value, string text, string unit)
        {
            if (!ctx.ResourceTypes.Any(x=>x.Value== value))
            {
                ctx.ResourceTypes.Add(new ResourceType() {Value = value, DisplayText = text, Unit = unit});
            }
        }
    }

}
