

namespace ShopExample.Data.Repositories
{
    using ShopExample.Data.Infrastructure;
    using ShopExample.Model.Model;

    interface IVisitorStatisticRepository : IRepository<VisitorStatistic>
    {

    }

    public class VisitorStatisticRepository : RepositoryBase<VisitorStatistic>, IVisitorStatisticRepository
    {
        public VisitorStatisticRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
