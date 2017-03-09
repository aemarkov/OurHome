using OurHome.EntityFramework;
using EntityFramework.DynamicFilters;

namespace OurHome.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly OurHomeDbContext _context;

        public InitialHostDbBuilder(OurHomeDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
