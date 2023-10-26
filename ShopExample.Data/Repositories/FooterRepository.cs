using ShopExample.Data.Infrastructure;
using ShopExample.Model.Model;

namespace ShopExample.Data.Repositories
{
    public interface IFooterRepository : IRepository<Footer>
    {

    }

    public class FooterRepository : RepositoryBase<Footer>, IFooterRepository 
    {
        public FooterRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
