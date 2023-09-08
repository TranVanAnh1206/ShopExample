

namespace ShopExample.Data.Repositories
{
    using ShopExample.Data.Infrastructure;
    using ShopExample.Model.Model;

    public interface IPostTagRepository : IRepository<PostTag>
    {

    }

    public class PostTagRepository : RepositoryBase<PostTag>, IPostTagRepository
    {
        public PostTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
