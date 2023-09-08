using ShopExample.Data.Infrastructure;
using ShopExample.Model.Model;

namespace ShopExample.Data.Repositories
{
    interface IPageRepository : IRepository<Page>
    {

    }

    public class PageRepository : RepositoryBase<Page>, IPageRepository
    {
        public PageRepository(IDbFactory dbFactory) : base (dbFactory)
        {

        }
    }
}
