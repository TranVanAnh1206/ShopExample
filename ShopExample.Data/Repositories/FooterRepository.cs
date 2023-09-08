using ShopExample.Data.Infrastructure;
using ShopExample.Model.Model;

namespace ShopExample.Data.Repositories
{
    interface IFooterRepository : IRepository<Footer>
    {

    }

    public class FooterRepository : RepositoryBase<Footer>, IFooterRepository 
    {
        public FooterRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
