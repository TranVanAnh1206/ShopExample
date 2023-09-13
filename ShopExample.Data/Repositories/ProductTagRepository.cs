using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopExample.Data.Infrastructure;
using ShopExample.Model.Model;

namespace ShopExample.Data.Repositories
{

    public interface IProductTagRepository : IRepository<ProductTag>
    {

    }

    public class ProductTagRepository : RepositoryBase<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
