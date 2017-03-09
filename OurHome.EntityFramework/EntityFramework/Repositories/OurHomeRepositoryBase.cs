using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace OurHome.EntityFramework.Repositories
{
    public abstract class OurHomeRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<OurHomeDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected OurHomeRepositoryBase(IDbContextProvider<OurHomeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class OurHomeRepositoryBase<TEntity> : OurHomeRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected OurHomeRepositoryBase(IDbContextProvider<OurHomeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
