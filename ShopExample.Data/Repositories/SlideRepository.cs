

namespace ShopExample.Data.Repositories
{
    using ShopExample.Data.Infrastructure;
    using ShopExample.Model.Model;

    interface ISlideRepository : IRepository<Slide>
    {

    }

    public class SlideRepository : RepositoryBase<Slide>, ISlideRepository
    {
        public SlideRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
