using ShopExample.Data.Infrastructure;
using ShopExample.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace ShopExample.Data.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        /// <summary>
        /// Phương thức này không nằm trong tập phương thức có sắn của Class RepositoryBase thì phải tạo mới riêng
        /// trong class RepositoryBase Hầu như đã có tất cả các phương thức mà đảm bảo được thao tác truy suất cơ bản
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}
