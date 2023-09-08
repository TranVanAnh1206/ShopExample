using ShopExample.Data.Infrastructure;
using ShopExample.Model.Model;

namespace ShopExample.Data.Repositories
{
    interface IOrderDetailRepository : IRepository<OrderDetail>
    {

    }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base (dbFactory)
        {

        }
    }
}
