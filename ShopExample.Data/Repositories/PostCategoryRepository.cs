

namespace ShopExample.Data.Repositories
{
    using ShopExample.Data.Infrastructure;
    using ShopExample.Model.Model;

    public interface IPostCategoryRepository : IRepository<PostCategory>
    {

    }

    public class PostCategoryRepository : RepositoryBase<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
